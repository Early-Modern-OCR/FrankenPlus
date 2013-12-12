using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using BitMiracle.LibTiff.Classic;
using System.ComponentModel;
using System.IO;

namespace Franken_.App_Code
{
    class ImageWriter
    {
        DataPipe db = new DataPipe();

        public string BaseName = ""; //THIS WILL BE THE WORKING NAME OF THE TRANSCRIPT (FOLDER NAME, ETC)
        public string OutputPath = ""; //THIS IS THE PATH TO THE FOLDER
        public string TranscriptPath = ""; //THIS IS THE PATH TO THE TRANSCRIPT TEXT FILE
        public int SeriesNo = 0; //THERE WILL LIKELY BE MULTIPLE TIFFS PER TRANSCRIPT FILE, THIS HELPS US NAME THEM UNIQUELY

        public App_Code.Font myFont = null; //THE FONT WE'RE USING
        public App_Code.SubList mySubs = null; //THE SUBSTITUTION LIST
        public string LangName = ""; //THIS IS A PREFIX ADDED TO ALL RESULTING FILES (FOR TESSERACT)

        //ALL STATIC VALUES *MUST* BE DIVISIBLE BY 8 (BYTE SIZE).  ALL ARE NUMBER OF PIXELS.
        static int BYTESIZE = 8; //DUH
        static int HEIGHT = 3000; //THE HEIGHT OF THE DOCUMENT
        static int WIDTH = 4000; //THE WIDTH OF THE DOCUMENT
        static int LETTER_SPACE = 0; //THE SPACE BETWEEN EACH LETTER
        static int MARGIN = 16; //THE DOCUMENT MARGIN
        static int WORD_SPACE = 24; //THE SPACE BETWEEN WORDS
        static int LINE_SPACE = 16; //THE SPACE BETWEEN LINES
        static byte ALL_WHITE = 0; //THIS IS ACTUALLY THE BYTE VALUE FOR SETTING AN 8 PIXEL WIDE TIFF SWATH TO WHITE

        public byte[][] IMAGE = new byte[HEIGHT][]; //THIS IS WHERE WE KEEP TRACK OF THE PIXELS

        public System.Collections.Generic.List<string> UnaccountedFor = new List<string>(); //WHERE WE KEEP TRACK OF ANY CHARACTERS NOT ACCOUNTED FOR IN FONT

        System.Collections.Generic.List<GlyphKeeper> GlyphWord = new List<GlyphKeeper>(); //THE CONTAINER FOR WORDS BEFORE THEY ARE WRITTEN
        int CurrentLineTopHeight = MARGIN;
        int CurrentLineBottomHeight = MARGIN;
        int ByteCursor = MARGIN / BYTESIZE;

        public ImageWriter(ref BackgroundWorker Slave, ref string ProcessStatus, string LangName, string FontID, string TransPath, bool UseSubList)
        {
            this.myFont = new Font(FontID, true, true);
            this.mySubs = new SubList();

            CurrentLineBottomHeight = CurrentLineTopHeight + myFont.LineHeight;
            this.LangName = LangName;
            this.TranscriptPath = TransPath;

            //GET BASE NAME FOR FOLDER
            string[] TransParts = this.TranscriptPath.Split(new char[] { '\\' });
            BaseName = TransParts[TransParts.Length - 1].ToLower().Replace(".txt", "");

            //MAKE FOLDER
            OutputPath = db.DataDirectory + "\\TiffBoxPairs\\" + myFont.ID + "\\" + BaseName;
            if (!System.IO.Directory.Exists(db.DataDirectory + "\\TiffBoxPairs"))
            {
                System.IO.Directory.CreateDirectory(db.DataDirectory + "\\TiffBoxPairs");
            }
            if (!System.IO.Directory.Exists(db.DataDirectory + "\\TiffBoxPairs\\" + myFont.ID))
            {
                System.IO.Directory.CreateDirectory(db.DataDirectory + "\\TiffBoxPairs\\" + myFont.ID);
            }
            if (System.IO.Directory.Exists(OutputPath))
            {
                Directory.Delete(OutputPath, true);
                System.Threading.Thread.Sleep(3000);
                System.IO.Directory.CreateDirectory(OutputPath);
            }
            else
            {
                System.IO.Directory.CreateDirectory(OutputPath);
            }

            //TURN CANVAS ALL WHITE
            for (int h = 0; h < HEIGHT; h++)
            {
                IMAGE[h] = new byte[WIDTH / BYTESIZE];

                for (int bw = 0; bw < (WIDTH / BYTESIZE); bw++)
                {
                    IMAGE[h][bw] = ALL_WHITE;
                }
            }

            //GET TRANSCRIPT WORDS
            System.IO.StreamReader Fin = new System.IO.StreamReader(TranscriptPath);
            string wordString = Fin.ReadToEnd().Replace("\n", " ").Replace("\r", " ");
            if(UseSubList)
                wordString = mySubs.ReplaceAll(wordString);

            string[] Words = wordString.Split(new char[] { ' ' });
            Fin.Close();

            double Increment = 100 / Words.Length;

            //WRITE WORDS
            for (int x = 0; x < Words.Length; x++)
            {
                if (Slave.CancellationPending)
                {
                    break;
                }
                else
                {
                    ProcessStatus = "Writing word \"" + Words[x] + "\"...";
                    Slave.ReportProgress(((int)(x * Increment)));
                }

                if (Words[x].Trim() != "")
                {
                    char[] Letters = Words[x].ToCharArray();
                    for (int y = 0; y < Letters.Length; y++)
                    {
                        //for testing purposes, test for a character
                        /*
                        if (Letters[y] == '-')
                        {
                            string nothing = "break here";
                        }
                        */

                        if (!UnaccountedFor.Contains(Letters[y].ToString()))
                        {
                            bool AccountedFor = false;

                            int gIndex = myFont.FindGlyph(Letters[y].ToString());
                            if (gIndex > -1)
                            {
                                AccountedFor = myFont.Glyphs[gIndex].HasAvailableImage();
                            }

                            if (AccountedFor)
                            {
                                AddGlyph(myFont.Glyphs[gIndex]);
                            }
                            else
                            {
                                UnaccountedFor.Add(Letters[y].ToString());
                            }
                        }
                    }

                    WriteGlyphWord();
                }
            }

            //CHECK TO SEE IF A TIFF FILE REMAINS TO BE WRITTEN
            bool NeedToWrite = false;
            for (int h = 0; h < HEIGHT; h++)
            {
                if (!NeedToWrite)
                {
                    for (int bw = 0; bw < (WIDTH / BYTESIZE); bw++)
                    {
                        if (IMAGE[h][bw] != ALL_WHITE)
                        {
                            NeedToWrite = true;
                            break;
                        }
                    }
                }
                else
                    break;
            }

            if(NeedToWrite)
                WriteImage(OutputPath + "\\" + this.LangName + "." + myFont.Name + ".exp" + SeriesNo.ToString() + ".tif");

            //LOG THE UNACCOUNTED CHARACTERS
            if (UnaccountedFor.Count > 0)
            {
                System.IO.StreamWriter Fout = new System.IO.StreamWriter(OutputPath + "\\unaccounted-for-characters.txt", true);
                Fout.WriteLine("Transcript: " + TranscriptPath);
                Fout.WriteLine(System.DateTime.Now.ToShortDateString() + " " + System.DateTime.Now.ToShortTimeString());
                foreach (string S in UnaccountedFor)
                {
                    string Formatted = S + " (";
                    char[] chars = S.ToCharArray();

                    for (int x = 0; x < chars.Length; x++)
                    {
                        if (x > 0) { Formatted += " "; }
                        Formatted += string.Format("U+{0:x4}", (int)chars[x]);
                    }

                    Formatted += ")";
                    Fout.WriteLine(Formatted);
                }

                Fout.WriteLine(" ");
                Fout.WriteLine(" ");

                Fout.Close();
            }

        }

        public void AddGlyph(App_Code.Glyph G)
        {
            string GlyphFile = "";
            int GlyphWidth = 0;
            int GlyphHeight = 0;
            int GlyphScanSize = 0;
            byte[][] GlyphData;

            GlyphFile = db.DataDirectory + G.GetRandomImage();

            if (GlyphFile != "")
            {
                using (Tiff input = Tiff.Open(GlyphFile, "r"))
                {
                    GlyphWidth = input.GetField(TiffTag.IMAGEWIDTH)[0].ToInt();
                    GlyphHeight = input.GetField(TiffTag.IMAGELENGTH)[0].ToInt();
                    GlyphScanSize = input.ScanlineSize();
                    GlyphData = new byte[GlyphHeight][];

                    if ((GlyphScanSize * 8) < (GlyphWidth + 8))
                    {
                        for (int h = 0; h < GlyphHeight; h++)
                        {
                            GlyphData[h] = new byte[GlyphScanSize];
                            input.ReadScanline(GlyphData[h], h);
                        }

                        if (GlyphHeight > (CurrentLineBottomHeight - CurrentLineTopHeight))
                        {
                            CurrentLineBottomHeight = CurrentLineTopHeight + GlyphHeight;
                        }

                        GlyphWord.Add(new GlyphKeeper(GlyphWidth, GlyphHeight, (int)G.XOffset, (int)G.YOffset, GlyphScanSize, G.Unicode, GlyphData));
                    }
                }
            }
            else
            {
                UnaccountedFor.Add(G.Unicode);
            }
        }

        public void WriteGlyphWord()
        {
            //for testing purposes, reconstruct the word as a string
            /*
            string testString = "";
            foreach (GlyphKeeper G in GlyphWord)
            {
                testString += G.GlyphChar;
            }
            if (testString == "end,")
            {
                testString += "break here!";
            }
            */

            int WordWidth = WORD_SPACE; //MAKE SURE WE ACCOUNT FOR THE SPACE
            int WordHeight = myFont.LineHeight;

            foreach (GlyphKeeper G in GlyphWord)
                WordWidth += G.GlyphWidth + LETTER_SPACE; //SUM THE WIDTH OF EACH CHARACTER (PLUS THE LETTER SPACE)

            foreach (GlyphKeeper G in GlyphWord)
            {
                if (G.GlyphHeight > WordHeight)
                    WordHeight = G.GlyphHeight;
            }

            if (PlaceWord(WordWidth, WordHeight)) //THIS FUNCTION CHECKS TO MAKE SURE THE WORD CAN FIT ON A PAGE, AND STARTS A NEW LINE OR DOCUMENT IF NEEDED
            {
                foreach (GlyphKeeper G in GlyphWord)
                {
                    int GlyphYpos = CurrentLineBottomHeight - G.GlyphHeight + G.GlyphYOffset;
                    int GlyphXpos = ByteCursor * 8;

                    for (int y = 0; y < G.GlyphHeight; y++)
                    {
                        for (int x = 0; x < G.GlyphScanSize; x++)
                        {
                            IMAGE[y + GlyphYpos][x + ByteCursor] = G.GlyphData[y][x];
                        }
                    }

                    AddBoxFileEntry(GlyphXpos, HEIGHT - CurrentLineBottomHeight - G.GlyphYOffset, G.GlyphWidth, G.GlyphHeight, G.GlyphChar);
                    ByteCursor += G.GlyphScanSize + (LETTER_SPACE / BYTESIZE);
                }

                ByteCursor += ((WORD_SPACE - LETTER_SPACE) / BYTESIZE);
            }

            GlyphWord.Clear();
        }

        public bool PlaceWord(int WordWidth, int WordHeight)
        {
            bool FitsOnPage = true;

            if (((WordWidth + (MARGIN * 2)) >= WIDTH) ||
                ((WordHeight + (MARGIN * 2)) >= HEIGHT))
            {
                FitsOnPage = false;
            }
            else
            {
                if (((WordHeight + CurrentLineBottomHeight) + (MARGIN * 2)) >= HEIGHT)
                {
                    StartNewTiff();
                    CurrentLineTopHeight = MARGIN;
                    CurrentLineBottomHeight = MARGIN + WordHeight;
                    ByteCursor = MARGIN / BYTESIZE;
                }
                else if ((WordWidth + (ByteCursor * 8) + (MARGIN * 2)) >= WIDTH)
                {
                    if ((CurrentLineBottomHeight + LINE_SPACE + WordHeight + (MARGIN * 2)) >= HEIGHT)
                    {
                        StartNewTiff();
                        CurrentLineTopHeight = MARGIN;
                        CurrentLineBottomHeight = MARGIN + WordHeight;
                        ByteCursor = MARGIN / BYTESIZE;
                    }
                    else
                    {
                        CurrentLineTopHeight = CurrentLineBottomHeight + LINE_SPACE;
                        CurrentLineBottomHeight = CurrentLineTopHeight + WordHeight;
                        ByteCursor = MARGIN / BYTESIZE;
                    }
                }
            }

            return FitsOnPage;
        }

        public void AddBoxFileEntry(int Xpos, int Ypos, int Width, int Height, string Char)
        {
            var utf8SansBOM = new System.Text.UTF8Encoding(false);

            System.IO.StreamWriter Fout = new System.IO.StreamWriter(OutputPath + "\\" + this.LangName + "." + myFont.Name + ".exp" + SeriesNo.ToString() + ".box", true, utf8SansBOM);
            Fout.Write(Char + " " + Xpos + " " + Ypos + " " + (Xpos + Width).ToString() + " " + (Ypos + Height).ToString() + " 0\n");
            Fout.Close();
        }

        public void StartNewTiff()
        {
            WriteImage(OutputPath + "\\" + this.LangName + "." + myFont.Name + ".exp" + SeriesNo.ToString() + ".tif");
            SeriesNo++;

            CurrentLineTopHeight = MARGIN;
            CurrentLineBottomHeight = CurrentLineTopHeight + myFont.LineHeight;

            for (int h = 0; h < HEIGHT; h++)
            {
                for (int bw = 0; bw < (WIDTH / BYTESIZE); bw++)
                {
                    IMAGE[h][bw] = ALL_WHITE;
                }
            }
        }

        public void WriteImage(string ImagePath)
        {
            using (Tiff output = Tiff.Open(ImagePath, "w"))
            {
                output.SetField(TiffTag.IMAGEWIDTH, WIDTH);
                output.SetField(TiffTag.IMAGELENGTH, HEIGHT);
                output.SetField(TiffTag.SAMPLESPERPIXEL, 1);
                output.SetField(TiffTag.BITSPERSAMPLE, 1);
                output.SetField(TiffTag.PHOTOMETRIC, Photometric.MINISWHITE);

                for (int h = 0; h < HEIGHT; h++)
                {
                    output.WriteScanline(IMAGE[h], h);
                }
            }
        }
    }

    public class GlyphKeeper
    {
        public int GlyphWidth;
        public int GlyphHeight;
        public int GlyphXOffset;
        public int GlyphYOffset;
        public int GlyphScanSize;
        public string GlyphChar;
        public byte[][] GlyphData;

        public GlyphKeeper(int Width, int Height, int XOffset, int YOffset, int ScanSize, string Char, byte[][] Data)
        {
            GlyphWidth = Width;
            GlyphHeight = Height;
            GlyphXOffset = XOffset;
            GlyphYOffset = YOffset;
            GlyphScanSize = ScanSize;
            GlyphChar = Char;

            int ExtraPixels = (GlyphScanSize * 8) - GlyphWidth;

            GlyphData = new byte[GlyphHeight][];
            for (int h = 0; h < GlyphHeight; h++)
            {
                GlyphData[h] = new byte[GlyphScanSize];
                for (int s = 0; s < GlyphScanSize; s++)
                {
                    byte FixedByte = Data[h][s];

                    if (s == GlyphScanSize - 1)
                    {
                        if (ExtraPixels > 0)
                        {
                            byte WHITE = 0;
                            FixedByte = SetBits(FixedByte, WHITE, 0, ExtraPixels);
                        }
                    }

                    GlyphData[h][s] = FixedByte;
                }
            }
        }

        public byte SetBits(byte oldValue, byte newValue, int startBit, int bitCount)
        {
            if (startBit < 0 || startBit > 7 || bitCount < 0 || bitCount > 7
                             || startBit + bitCount > 8)
                throw new OverflowException();

            int mask = (255 >> 8 - bitCount) << startBit;
            return Convert.ToByte((oldValue & (~mask)) | ((newValue << startBit) & mask));
        }
    }
}