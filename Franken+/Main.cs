using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Xml.Xsl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using BitMiracle.LibTiff.Classic;
using System.IO;
using System.IO.Compression;
using Franken_.App_Code;

namespace Franken_
{
    public partial class Main : Form
    {
        DataPipe db = new DataPipe();
        Progress progressWindow;
        string Job = "";
        string InitializationError = "";

        string LangName = "";
        string FontID = "";
        string TiffXMLFolder = "";
        string MakeImagesFolder = "";
        string ProcessStatus = "Starting...";

        SubList mySubList = null;

        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (CheckIfInitialized())
            {
                try
                {
                    RefreshFontList();
                    RefreshSubList();
                    RefreshLangList();
                }
                catch (Exception E)
                {
                    MessageBox.Show("Franken+ was unable to initialize properly.  If this is the first time you are running Franken+, chances are you need to select Settings->Reset Database in order to properly set up tables.");
                }
            }
            else
            {
                MessageBox.Show(InitializationError);
            }
        }

        private bool CheckIfInitialized()
        {
            bool GoodToGo = false;
            InitializationError = "";

            string ConnectionResults = db.CheckConnection();

            if (ConnectionResults != "Connection successful, and database found!")
            {
                InitializationError += "This may be the first time you are running Franken+, as it is unable to connect to the MySQL database.  It may also be the case that the server is not running, or your credentials have changed.  If this is your first time to run Franken+, go to Menu->Settings and set up your connection; after verifying your connection, click Reset Database to set up Franken+ tables.";
            }

            if (InitializationError == "") { GoodToGo = true; }

            return GoodToGo;
        }

        private void RefreshFontList()
        {
            fontBox.Items.Clear();
            if (db.GetRows("select font_id from fonts order by font_name asc"))
            {
                foreach (DataRow DR in db.Bucket.Rows)
                {
                    App_Code.Font f = new App_Code.Font(DR[0].ToString(), false, false);
                    fontBox.Items.Add(f);
                }
            }
        }

        private void RefreshSubList()
        {
            substitutionsList.Items.Clear();
            mySubList = new SubList();
            string[] Keys = mySubList.Characters.Keys.ToArray<string>();
            foreach (string K in Keys)
            {
                string Substitution = K + " => " + mySubList.Characters[K];
                substitutionsList.Items.Add(Substitution);
            }
        }

        private void RefreshLangList()
        {
            langBox.Items.Clear();
            if (db.GetRows("select lang_id from languages order by lang_name asc"))
            {
                foreach (DataRow DR in db.Bucket.Rows)
                {
                    App_Code.Language L = new App_Code.Language(DR[0].ToString());
                    langBox.Items.Add(L);
                }
            }
        }

        private void DoTiffXMLIngestion(ref BackgroundWorker Slave, string LangName, string FontID, string TiffXMLFolder, bool UseSubList)
        {
            double Increment = 1;

            if (FontID != "" && FontID != "" && TiffXMLFolder != "")
            {
                App_Code.Font myFont = new App_Code.Font(FontID, true, true);

                string FullInputDir = TiffXMLFolder + "\\";
                string FullOutputDir = db.DataDirectory + "\\GlyphExtraction\\Output\\" + myFont.ID;

                string[] InputFiles = System.IO.Directory.GetFiles(FullInputDir, "*.xml", SearchOption.TopDirectoryOnly);

                if (InputFiles.Count() > 0)
                {
                    Increment = 50 / InputFiles.Count();
                }
                int CurrentProgress = 0;

                foreach (string F in InputFiles)
                {
                    if (Slave.CancellationPending)
                    {
                        break;
                    }
                    else
                    {
                        string inputFileName = F.Replace(FullInputDir, "");

                        if (inputFileName.EndsWith(".xml") && File.Exists(F.Replace(".xml", ".tif")))
                        {
                            if (!System.IO.Directory.Exists(FullOutputDir + "\\" + inputFileName.Replace(".xml", "")))
                            {
                                System.IO.Directory.CreateDirectory(FullOutputDir + "\\" + inputFileName.Replace(".xml", ""));
                            }

                            ProcessStatus = "Extracting " + inputFileName + "...";
                            Slave.ReportProgress(((int)(CurrentProgress * Increment)));

                            string inputImageFilePath = FullInputDir + inputFileName.Replace(".xml", ".tif");
                            string inputXmlFilePath = FullInputDir + inputFileName;
                            string outputFolderPath = FullOutputDir + "\\" + inputFileName.Replace(".xml", "");

                            PageXml pageXml = PageXmlFactory.GetPageXml(F);

                            string extractor = pageXml.ImageExtratorRelPath;
                            string command = string.Format(@"{0}\GlyphExtraction\{1}", db.DataDirectory, extractor);
                            FileInfo extractorExec = new FileInfo(command);
                            string options = pageXml.CreateImageExtractorCommandLine(inputImageFilePath, inputXmlFilePath, outputFolderPath);

                            ExecuteCommand(command, options, extractorExec.DirectoryName);
                            CurrentProgress++;
                            ProcessStatus = "Processing extracted images...";
                            Slave.ReportProgress(((int)(CurrentProgress * Increment)));

                            myFont.IngestImages(LangName, myFont.Name, inputFileName.Replace(".xml", ""), FullInputDir + "\\" + inputFileName, FullOutputDir + "\\" + inputFileName.Replace(".xml", ""), UseSubList);
                        }
                    }

                    CurrentProgress++;
                    ProcessStatus = "Moving to next TIF/XML pair...";
                    Slave.ReportProgress(((int)(CurrentProgress * Increment)));
                }
            }
        }

        private void ExecuteCommand(string Command, string Parameters, string workingDirectory)
        {
            ProcessStartInfo processInfo;
            Process process;

            processInfo = new ProcessStartInfo(Command, Parameters);
            processInfo.WorkingDirectory = workingDirectory;
            processInfo.CreateNoWindow = false;
            processInfo.WindowStyle = ProcessWindowStyle.Minimized;
            processInfo.UseShellExecute = true;

            process = Process.Start(processInfo);
            process.WaitForExit();
            process.Close();
        }

        private void editFontButton_Click(object sender, EventArgs e)
        {
            if (fontBox.SelectedItem != null)
            {
                this.Enabled = false;
                NewFont NF = new NewFont(((App_Code.Font)fontBox.SelectedItem).ID);
                NF.ShowDialog();
                RefreshFontList();
                this.Enabled = true;
            }
            else
            {
                MessageBox.Show("Please select a font.");
            }
        }

        private void createFontButton_Click(object sender, EventArgs e)
        {
            NewFont NF = new NewFont();
            NF.ShowDialog();
            RefreshFontList();
        }

        private void transTextBrowseButton_Click(object sender, EventArgs e)
        {
            fileBrowser.Filter = "Text Files (*.txt)|*.txt";
            DialogResult DR = fileBrowser.ShowDialog();
            if (DR == System.Windows.Forms.DialogResult.OK)
            {
                transTextBox.Text = fileBrowser.FileName;
            }
        }

        private void createTiffBoxButton_Click(object sender, EventArgs e)
        {
            Job = "MakeImages";
            MakeImagesFolder = transTextBox.Text;
            if (fontBox.SelectedItem != null) { FontID = ((App_Code.Font)fontBox.SelectedItem).ID; }
            if (langBox.SelectedItem != null) { LangName = ((App_Code.Language)langBox.SelectedItem).Name; }

            if (LangName == "") { MessageBox.Show("Please enter a language name."); }
            else if (FontID == "") { MessageBox.Show("Please select a font."); }
            else if (MakeImagesFolder == "") { MessageBox.Show("Please select an input folder."); }
            else if (backgroundWorker.IsBusy != true)
            {
                progressWindow = new Progress();
                progressWindow.Canceled += progressWindow_Canceled;
                progressWindow.Show();
                backgroundWorker.RunWorkerAsync();
            }
        }

        private void tiffXMLBrowseButton_Click(object sender, EventArgs e)
        {
            DialogResult DR = folderBrowser.ShowDialog();
            if (DR == System.Windows.Forms.DialogResult.OK)
            {
                tiffXMLInputBox.Text = folderBrowser.SelectedPath;
            }
        }

        private void ingestGlyphsButton_Click(object sender, EventArgs e)
        {
            Job = "IngestGlyphs";
            TiffXMLFolder = tiffXMLInputBox.Text;
            if (fontBox.SelectedItem != null) { FontID = ((App_Code.Font)fontBox.SelectedItem).ID; }
            if (langBox.SelectedItem != null) { LangName = ((App_Code.Language)langBox.SelectedItem).Name; }

            if (LangName == "") { MessageBox.Show("Please enter a language name."); }
            else if (FontID == "") { MessageBox.Show("Please select a font."); }
            else if (TiffXMLFolder == "") { MessageBox.Show("Please select an input folder."); }
            else if (backgroundWorker.IsBusy != true)
            {
                progressWindow = new Progress();
                progressWindow.Canceled += progressWindow_Canceled;
                progressWindow.Show();
                backgroundWorker.RunWorkerAsync();
            }
        }

        void progressWindow_Canceled(object sender, EventArgs e)
        {
            backgroundWorker.CancelAsync();
            progressWindow.Close();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker slave = sender as BackgroundWorker;

            if (Job == "IngestGlyphs")
            {
                DoTiffXMLIngestion(ref slave, LangName, FontID, TiffXMLFolder, subIngestBox.Checked);
            }
            else if (Job == "MakeImages")
            {
                ImageWriter IW = new ImageWriter(ref slave, ref ProcessStatus, LangName, FontID, MakeImagesFolder, subTransBox.Checked);
                if (Directory.Exists(db.DataDirectory + "\\TiffBoxPairs\\" + FontID))
                {
                    Process.Start(db.DataDirectory + "\\TiffBoxPairs\\" + FontID);
                }
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressWindow.Message = ProcessStatus;
            progressWindow.ProgressValue = e.ProgressPercentage;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressWindow.Close();
        }

        private void substitutionsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (substitutionsList.SelectedIndex > -1)
            {
                delSubButton.Enabled = true;
            }
            else
            {
                delSubButton.Enabled = false;
            }
        }

        private void newSubButton_Click(object sender, EventArgs e)
        {
            NewSubstitution subForm = new NewSubstitution();
            subForm.ShowDialog();
            RefreshSubList();
        }

        private void delSubButton_Click(object sender, EventArgs e)
        {
            mySubList.Delete(substitutionsList.SelectedItem as string);
            RefreshSubList();
        }

        private void createLangButton_Click(object sender, EventArgs e)
        {
            NewLanguage langForm = new NewLanguage();
            langForm.ShowDialog();
            RefreshLangList();            
        }

        private void trainTessButton_Click(object sender, EventArgs e)
        {
            if (langBox.SelectedItem != null)
            {
                TrainTesseract trainingForm = new TrainTesseract((langBox.SelectedItem as Language).ID);
                trainingForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a language.");
            }
        }

        private void copyFontButton_Click(object sender, EventArgs e)
        {
            if (fontBox.SelectedItem != null)
            {
                NewLanguage langForm = new NewLanguage(true);
                langForm.ShowDialog();

                if (langForm.NewName != "" && langForm.NewName != (fontBox.SelectedItem as App_Code.Font).Name)
                {
                    App_Code.Font newFont = new App_Code.Font();
                    newFont.Name = langForm.NewName;
                    newFont.LineHeight = (fontBox.SelectedItem as App_Code.Font).LineHeight;
                    newFont.LangID = (fontBox.SelectedItem as App_Code.Font).LangID;
                    newFont.Bold = (fontBox.SelectedItem as App_Code.Font).Bold;
                    newFont.Fixed = (fontBox.SelectedItem as App_Code.Font).Fixed;
                    newFont.Fraktur = (fontBox.SelectedItem as App_Code.Font).Fraktur;
                    newFont.Italic = (fontBox.SelectedItem as App_Code.Font).Italic;
                    newFont.Serif = (fontBox.SelectedItem as App_Code.Font).Serif;
                    newFont.Save(false);

                    string oldDir = db.DataDirectory + "\\GlyphExtraction\\Output\\" + (fontBox.SelectedItem as App_Code.Font).ID;
                    string newDir = db.DataDirectory + "\\GlyphExtraction\\Output\\" + newFont.ID;
                    bool Copied = false;

                    if (Directory.Exists(oldDir))
                    {
                        try
                        {
                            DirectoryInfo Source = new DirectoryInfo(oldDir);
                            DirectoryInfo Target = new DirectoryInfo(newDir);
                            CopyDir(Source, Target);
                            Copied = true;
                        }
                        catch (Exception E)
                        {
                            MessageBox.Show("Unable to copy glyph images to new font!");
                        }
                    }

                    if (Copied)
                    {
                        if (db.GetRows("select * from glyphs where glyph_font_id = " + (fontBox.SelectedItem as App_Code.Font).ID))
                        {
                            using (DataTable GlyphTable = db.Bucket.Copy())
                            {
                                for (int x = 0; x < GlyphTable.Rows.Count; x++)
                                {
                                    Glyph g = new Glyph();
                                    g.FontID = newFont.ID;
                                    g.Unicode = GlyphTable.Rows[x]["glyph_unicode"].ToString();
                                    g.XOffset = float.Parse(GlyphTable.Rows[x]["glyph_x_offset"].ToString());
                                    g.YOffset = float.Parse(GlyphTable.Rows[x]["glyph_y_offset"].ToString());
                                    g.Save(false);

                                    if (db.GetRows("select * from images where img_glyph_id = " + GlyphTable.Rows[x]["glyph_id"].ToString()))
                                    {
                                        using(DataTable ImageTable = db.Bucket.Copy())
                                        {
                                            for(int y = 0; y < ImageTable.Rows.Count; y++)
                                            {
                                                GlyphImage img = new GlyphImage();
                                                img.GlyphID = g.ID;
                                                img.Path = ImageTable.Rows[y]["img_path"].ToString().Replace("\\Output\\" + (fontBox.SelectedItem as App_Code.Font).ID + "\\", "\\Output\\" + newFont.ID + "\\");
                                                img.Status = ImageTable.Rows[y]["img_status"].ToString();
                                                img.Save();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid name for the new font (must be different from the one you are copying).");
                }
            }

            RefreshFontList();
        }

        public static void CopyDir(DirectoryInfo source, DirectoryInfo target)
        {
            if (source.FullName.ToLower() == target.FullName.ToLower())
            {
                return;
            }

            // Check if the target directory exists, if not, create it. 
            if (Directory.Exists(target.FullName) == false)
            {
                Directory.CreateDirectory(target.FullName);
            }

            // Copy each file into it's new directory. 
            foreach (FileInfo fi in source.GetFiles())
            {
                Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
                fi.CopyTo(Path.Combine(target.ToString(), fi.Name), true);
            }

            // Copy each subdirectory using recursion. 
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyDir(diSourceSubDir, nextTargetSubDir);
            }
        }

        private void databaseConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbConnectionForm dbForm = new dbConnectionForm();
            DialogResult res = dbForm.ShowDialog();

            if (res == System.Windows.Forms.DialogResult.OK)
            {
                db = new DataPipe();
                if (CheckIfInitialized())
                {
                    RefreshFontList();
                    RefreshSubList();
                    RefreshLangList();
                }
                else
                {
                    MessageBox.Show("Franken+ was unable to initialize properly.  Please address the following issues and then restart Franken+:\r\n\r\n" + InitializationError);
                }
            }
        }

        private void exportFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontBox.SelectedItem != null)
            {
                string FontName = (fontBox.SelectedItem as App_Code.Font).Name;
                string FontID = (fontBox.SelectedItem as App_Code.Font).ID;
                string FontDir = db.DataDirectory + "\\Temp\\" + FontID;
                string ZipFilePath = db.DataDirectory + "\\Temp\\" + FontName + ".zip";

                if (!Directory.Exists(db.DataDirectory + "\\Temp"))
                {
                    Directory.CreateDirectory(db.DataDirectory + "\\Temp");
                }

                if (Directory.Exists(FontDir))
                {
                    Directory.Delete(FontDir, true);
                }

                if (File.Exists(ZipFilePath))
                {
                    File.Delete(ZipFilePath);
                }

                Directory.CreateDirectory(FontDir);

                if (Directory.Exists(db.DataDirectory + "\\GlyphExtraction\\Output\\" + FontID))
                {
                    DirectoryInfo From = new DirectoryInfo(db.DataDirectory + "\\GlyphExtraction\\Output\\" + FontID);
                    DirectoryInfo To = new DirectoryInfo(FontDir + "\\GlyphExtraction\\Output\\FONTNAME");
                    CopyDir(From, To);
                }

                if (Directory.Exists(db.DataDirectory + "\\TiffBoxPairs\\" + FontID))
                {
                    DirectoryInfo From = new DirectoryInfo(db.DataDirectory + "\\TiffBoxPairs\\" + FontID);
                    DirectoryInfo To = new DirectoryInfo(FontDir + "\\TiffBoxPairs\\FONTNAME");
                    CopyDir(From, To);
                }

                App_Code.Font exFont = new App_Code.Font(FontID, true, true);

                //Write font file
                using (StreamWriter Fout = new StreamWriter(FontDir + "\\font.txt"))
                {
                    Fout.WriteLine("name:" + exFont.Name);
                    Fout.WriteLine("lineheight:" + exFont.LineHeight);
                    Fout.WriteLine("bold:" + exFont.Bold);
                    Fout.WriteLine("fixed:" + exFont.Fixed);
                    Fout.WriteLine("fraktur:" + exFont.Fraktur);
                    Fout.WriteLine("italic:" + exFont.Italic);
                    Fout.WriteLine("serif:" + exFont.Serif);
                    Fout.Close();
                }

                //Write glyphs
                int gCount = 0;
                foreach (Glyph G in exFont.Glyphs)
                {
                    using (StreamWriter Fout = new StreamWriter(FontDir + "\\glyph" + gCount + ".txt", false, Encoding.UTF8))
                    {
                        Fout.WriteLine("unicode:" + G.Unicode);
                        Fout.WriteLine("xoffset:" + G.XOffset);
                        Fout.WriteLine("yoffset:" + G.YOffset);

                        foreach (GlyphImage I in G.Images)
                        {
                            Fout.WriteLine("image:" + I.Path.Replace("\\GlyphExtraction\\Output\\" + FontID, "\\GlyphExtraction\\Output\\FONTNAME") + ": " + I.Status);
                        }

                        Fout.Close();
                    }
                    gCount++;
                }

                //Make zip file
                ZipFile.CreateFromDirectory(FontDir, ZipFilePath);

                //Clean up
                Directory.Delete(FontDir, true);

                MessageBox.Show("Font '" + FontName + "' exported.");
                Process.Start(db.DataDirectory + "\\Temp");
            }
            else
            {
                MessageBox.Show("Please select a font to export using the font dropdown box, and then try again.");
            }
        }

        private void importFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileBrowser.Filter = "Zip Files (*.zip)|*.zip";
            DialogResult res = fileBrowser.ShowDialog();
            string FontZipFile = "";
            string FontName = "";
            string FontDir = "";

            if (res == System.Windows.Forms.DialogResult.OK)
            {
                FontZipFile = fileBrowser.FileName;

                NewLanguage langForm = new NewLanguage(true);
                langForm.ShowDialog();

                if (langForm.NewName != "")
                {
                    FontName = langForm.NewName;
                    App_Code.Font impFont = new App_Code.Font();
                    impFont.Name = FontName;
                    impFont.Save(false);

                    FontDir = db.DataDirectory + "\\Temp\\" + impFont.ID;

                    if(!Directory.Exists(db.DataDirectory + "\\GlyphExtraction\\Output\\" + impFont.ID))
                    {
                        Directory.CreateDirectory(db.DataDirectory + "\\GlyphExtraction\\Output\\" + impFont.ID);
                    }

                    if(!Directory.Exists(db.DataDirectory + "\\TiffBoxPairs\\" + impFont.ID))
                    {
                        Directory.CreateDirectory(db.DataDirectory + "\\TiffBoxPairs\\" + impFont.ID);
                    }

                    if (!Directory.Exists(db.DataDirectory + "\\Temp"))
                    {
                        Directory.CreateDirectory(db.DataDirectory + "\\Temp");
                    }

                    if (Directory.Exists(FontDir))
                    {
                        Directory.Delete(FontDir, true);
                    }

                    ZipFile.ExtractToDirectory(FontZipFile, FontDir);

                    if (Directory.Exists(FontDir))
                    {
                        if (Directory.Exists(FontDir + "\\GlyphExtraction\\Output\\FONTNAME"))
                        {
                            string[] subDirs = Directory.GetDirectories(FontDir + "\\GlyphExtraction\\Output\\FONTNAME");

                            foreach (string subDir in subDirs)
                            {
                                string[] subDirParts = subDir.Split(new char[] { '\\' });
                                string subDirName = subDirParts[subDirParts.Length - 1];

                                DirectoryInfo From = new DirectoryInfo(subDir);
                                DirectoryInfo To = new DirectoryInfo(db.DataDirectory + "\\GlyphExtraction\\Output\\" + impFont.ID + "\\" + subDirName);
                                CopyDir(From, To);
                            }
                        }

                        if (Directory.Exists(FontDir + "\\TiffBoxPairs\\FONTNAME"))
                        {
                            string[] subDirs = Directory.GetDirectories(FontDir + "\\TiffBoxPairs\\FONTNAME");

                            foreach (string subDir in subDirs)
                            {
                                string[] subDirParts = subDir.Split(new char[] { '\\' });
                                string subDirName = subDirParts[subDirParts.Length - 1];

                                DirectoryInfo From = new DirectoryInfo(subDir);
                                DirectoryInfo To = new DirectoryInfo(db.DataDirectory + "\\TiffBoxPairs\\" + impFont.ID + "\\" + subDirName);
                                CopyDir(From, To);
                            }
                        }

                        //read font data
                        if (File.Exists(FontDir + "\\font.txt"))
                        {
                            using (StreamReader Fin = new StreamReader(FontDir + "\\font.txt"))
                            {
                                string Line = "";
                                while ((Line = Fin.ReadLine()) != null)
                                {
                                    string[] lineParts = Line.Split(new char[] { ':' });

                                    switch (lineParts[0])
                                    {
                                        case "lineheight": impFont.LineHeight = System.Convert.ToInt32(lineParts[1].Trim());
                                            break;
                                        case "bold": impFont.Bold = System.Convert.ToInt32(lineParts[1].Trim());
                                            break;
                                        case "fixed": impFont.Fixed = System.Convert.ToInt32(lineParts[1].Trim());
                                            break;
                                        case "fraktur": impFont.Fraktur = System.Convert.ToInt32(lineParts[1].Trim());
                                            break;
                                        case "italic": impFont.Italic = System.Convert.ToInt32(lineParts[1].Trim());
                                            break;
                                        case "serif": impFont.Serif = System.Convert.ToInt32(lineParts[1].Trim());
                                            break;
                                    }
                                }

                                Fin.Close();
                                impFont.Save(false);
                            }
                        }

                        //read glyphs
                        if (impFont.ID != "")
                        {
                            string[] glyphFiles = Directory.GetFiles(FontDir, "glyph*.txt");
                            foreach (string glyphFile in glyphFiles)
                            {
                                Glyph imGlyph = new Glyph();
                                imGlyph.FontID = impFont.ID;

                                using (StreamReader Fin = new StreamReader(glyphFile))
                                {
                                    string Line = "";
                                    while ((Line = Fin.ReadLine()) != null)
                                    {
                                        string[] lineParts = Line.Split(new char[] { ':' });

                                        switch (lineParts[0])
                                        {
                                            case "unicode": if (Line.Trim() == "unicode::")
                                                {
                                                    imGlyph.Unicode = ":";
                                                }
                                                else
                                                {
                                                    imGlyph.Unicode = lineParts[1].Trim();
                                                }
                                                break;
                                            case "xoffset": imGlyph.XOffset = float.Parse(lineParts[1].Trim());
                                                break;
                                            case "yoffset": imGlyph.YOffset = float.Parse(lineParts[1].Trim());
                                                imGlyph.Save(false);
                                                break;
                                            case "image": if (imGlyph.ID != "" && lineParts.Length == 3)
                                                {
                                                    GlyphImage imImg = new GlyphImage();
                                                    imImg.GlyphID = imGlyph.ID;
                                                    imImg.Path = lineParts[1].Trim().Replace("\\GlyphExtraction\\Output\\FONTNAME", "\\GlyphExtraction\\Output\\" + impFont.ID);
                                                    imImg.Status = lineParts[2].Trim();
                                                    imImg.Save();
                                                }
                                                break;
                                        }
                                    }

                                    Fin.Close();
                                }
                            }
                        }

                        //clean up
                        if (Directory.Exists(FontDir))
                        {
                            Directory.Delete(FontDir, true);
                        }

                        RefreshFontList();
                        MessageBox.Show("Font '" + FontName + "' imported successfully.");
                    }
                }
            }
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Process.Start("http://dh-emopweb.tamu.edu/Franken+");
        }

    }   

        
}
