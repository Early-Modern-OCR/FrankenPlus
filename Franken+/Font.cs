using System;
using System.Data;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Franken_.App_Code
{
    class Language
    {
        public string ID = "";
        public string Name = "";
        private DataPipe db = new DataPipe();

        public Language()
        {
        }

        public Language(string LangID)
        {
            if (db.GetRows("select * from languages where lang_id = " + LangID))
            {
                ID = LangID;
                Name = db.Bucket.Rows[0]["lang_name"].ToString();
            }
        }

        public override string ToString()
        {
            return this.Name;
        }

        public void Save()
        {
            if (ID == "")
            {
                ID = db.GetNewID("languages");
                db.ExecuteCommand("insert into languages (lang_id, lang_name) values (" + this.ID + ", '" + db.FixString(this.Name) + "')");
            }
            else
            {
                db.ExecuteCommand("update languages set lang_name = '" + db.FixString(this.Name) + "' where lang_id = " + this.ID);
            }
        }

        public void Delete()
        {
            db.ExecuteCommand("delete from languages where lang_id = " + this.ID);
        }
    }

    class Font
    {
        public string ID = "";
        public string LangID = "0";
        public string Name = "";
        public int LineHeight = 0;
        public int Italic = 0;
        public int Bold = 0;
        public int Fixed = 0;
        public int Serif = 0;
        public int Fraktur = 0;
        DataPipe db = new DataPipe();

        public System.Collections.Generic.List<Glyph> Glyphs = new List<Glyph>();
        SubList mySubs = new SubList();

        public Font()
        {
        }

        public Font(string ID, bool LoadGlyphs, bool LoadImages)
        {
            if (db.GetRows("select * from fonts where font_id = " + ID))
            {
                this.ID = ID;
                this.LangID = db.GetCell(0, "font_lang_id");
                this.Name = db.GetCell(0, "font_name");
                this.LineHeight = System.Convert.ToInt32(db.GetCell(0, "font_line_height"));
                this.Italic = System.Convert.ToInt32(db.GetCell(0, "font_italic"));
                this.Bold = System.Convert.ToInt32(db.GetCell(0, "font_bold"));
                this.Fixed = System.Convert.ToInt32(db.GetCell(0, "font_fixed"));
                this.Serif = System.Convert.ToInt32(db.GetCell(0, "font_serif"));
                this.Fraktur = System.Convert.ToInt32(db.GetCell(0, "font_fraktur"));
            }

            if (LoadGlyphs)
            {
                RefreshGlyphs(LoadImages);
            }
        }

        public override string ToString()
        {
            return this.Name;
        }

        public void RefreshGlyphs(bool LoadImages)
        {
            this.Glyphs.Clear();

            if (this.ID != "")
            {
                if (db.GetRows("select glyph_id from glyphs where glyph_font_id = " + this.ID + " order by glyph_unicode asc"))
                {
                    DataTable GlyphTable = db.Bucket.Copy();

                    for (int x = 0; x < GlyphTable.Rows.Count; x++)
                    {
                        Glyph G = new Glyph(GlyphTable.Rows[x][0].ToString(), LoadImages);
                        Glyphs.Add(G);
                    }
                }
            }
        }

        public void IngestImages(string LangName, string FontName, string BaseName, string XMLFile, string PathToImages, bool UseSubList)
        {
            PageXml pageXml = PageXmlFactory.GetPageXml(XMLFile);

            var Extracts = pageXml.GetGlyphs();

            string[] GlyphFiles = System.IO.Directory.GetFiles(PathToImages);

            foreach (var E in Extracts)
            {
                if (E.ID != "" && E.Unicode.Trim() != "")
                {
                    string ImagePath = "";
                    string FixedChar = E.Unicode.Trim();
                    if(UseSubList)
                        FixedChar = FixGlyphChar(FixedChar);

                    for (int x = 0; x < GlyphFiles.Length; x++)
                    {
                        if (GlyphFiles[x].Replace(PathToImages + "\\", "").Replace(BaseName + "_", "").Replace(".tif", "") == E.ID)
                        {
                            ImagePath = GlyphFiles[x].Replace(db.DataDirectory, "");
                            break;
                        }
                    }

                    if (ImagePath != "")
                    {
                        int gIndex = this.FindGlyph(FixedChar);

                        if (gIndex < 0)
                        {
                            this.AddGlyph(FixedChar, ImagePath);
                        }
                        else
                        {
                            this.Glyphs[gIndex].AddImage(ImagePath);
                        }
                    }
                }
            }
        }

        public int FindGlyph(string Unicode)
        {
            int Index = -1;

            for (int x = 0; x < Glyphs.Count; x++)
            {
                if (Glyphs[x].Unicode.Trim() == Unicode.Trim())
                {
                    Index = x;
                    break;
                }
            }

            return Index;
        }

        public void AddGlyph(string Unicode, string ImagePath)
        {
            Glyph G = new Glyph();
            G.FontID = this.ID;
            G.Unicode = Unicode;
            G.Save(false);
            G.AddImage(ImagePath);
            Glyphs.Add(G);
        }

        public string AddEmptyGlyph(string Unicode)
        {
            Glyph G = new Glyph();
            G.FontID = this.ID;
            G.Unicode = Unicode;
            G.Save(false);
            return G.ID;
        }

        public string FixGlyphChar(string Char)
        {
            string NewChar = Char;

            if (mySubs.Characters.ContainsKey(Char))
            {
                NewChar = mySubs.Characters[Char];
            }

            return NewChar;
        }

        public void Save(bool IncludeChildren)
        {
            if (this.ID == "")
            {
                this.ID = db.GetNewID("fonts");
                db.ExecuteCommand("insert into fonts (font_id, font_lang_id, font_name, font_italic, font_bold, font_fixed, font_serif, font_fraktur, font_line_height) values (" + this.ID + ", " + this.LangID + ", '" + db.FixString(this.Name) + "', " + this.Italic + ", " + this.Bold + ", " + this.Fixed + ", " + this.Serif + ", " + this.Fraktur + ", " + this.LineHeight + ")");
            }
            else
            {
                db.ExecuteCommand("update fonts set font_name = '" + db.FixString(this.Name) + "', " +
                    "font_lang_id = " + this.LangID + ", " +
                    "font_italic = " + this.Italic + ", " + 
                    "font_bold = " + this.Bold + ", " + 
                    "font_fixed = " + this.Fixed + ", " +
                    "font_serif = " + this.Serif + ", " +
                    "font_fraktur = " + this.Fraktur + ", " +
                    "font_line_height = " + this.LineHeight + " " +
                    "where font_id = " + this.ID);

                if (this.Glyphs != null && IncludeChildren)
                {
                    for (int x = 0; x < this.Glyphs.Count; x++)
                    {
                        this.Glyphs[x].Save(IncludeChildren);
                    }
                }
            }
        }

        public void Delete()
        {
            if (this.ID != "")
            {
                if (this.Glyphs != null)
                {
                    for (int x = 0; x < this.Glyphs.Count; x++)
                    {
                        this.Glyphs[x].Delete();
                    }
                }

                db.ExecuteCommand("delete from fonts where font_id = " + this.ID);
            }
        }
    }

    class Glyph
    {
        public string ID = "";
        public string FontID = "";
        public string Unicode = "";
        public bool HasMore = false;
        public int Frequency = 0;
        public float XOffset = 0;
        public float YOffset = 0;
        DataPipe db = new DataPipe();

        public System.Collections.Generic.List<GlyphImage> Images = new List<GlyphImage>();

        public Glyph()
        { }

        public Glyph(string ID, bool LoadImages)
        {
            if (db.GetRows("select * from glyphs where glyph_id = " + ID))
            {
                this.ID = ID;
                this.FontID = db.GetCell(0, "glyph_font_id");
                this.Unicode = db.GetCell(0, "glyph_unicode");
                this.Frequency = System.Convert.ToInt32(db.GetCell(0, "glyph_frequency"));
                this.XOffset = System.Convert.ToInt32(db.GetCell(0, "glyph_x_offset"));
                this.YOffset = System.Convert.ToInt32(db.GetCell(0, "glyph_y_offset"));
            }

            if (LoadImages)
            {
                RefreshImages();
            }
        }

        public override string ToString()
        {
            string Formatted = this.Unicode + " (";
            char[] chars = this.Unicode.ToCharArray();

            for (int x = 0; x < chars.Length; x++)
            {
                if (x > 0) { Formatted += " "; }
                Formatted += string.Format("U+{0:x4}", (int)chars[x]);
            }

            Formatted += ")";

            return Formatted;
        }

        public void RefreshImages()
        {
            this.Images.Clear();

            if (db.GetRows("select img_id from images where img_glyph_id = " + this.ID))
            {
                DataTable ImageTable = db.Bucket.Copy();

                for (int x = 0; x < ImageTable.Rows.Count; x++)
                {
                    if (x > 199)
                    {
                        HasMore = true;
                        break;
                    }
                    GlyphImage GI = new GlyphImage(ImageTable.Rows[x][0].ToString());
                    this.Images.Add(GI);
                }
            }
        }

        public bool HasAvailableImage()
        {
            int REMedImages = 0;
            bool Available = false;

            foreach (GlyphImage GI in Images)
            {
                if (GI.Status == "REM")
                    REMedImages++;
            }

            if (Images.Count > REMedImages) { Available = true; }
            return Available;
        }

        public string GetRandomImage()
        {
            string ImagePath = "";

            System.Collections.Generic.List<int> AvailableImages = new List<int>();

            for (int x = 0; x < Images.Count; x++)
            {
                if (Images[x].Status != "REM" && System.IO.File.Exists(db.DataDirectory + Images[x].Path))
                    AvailableImages.Add(x);
            }

            if (AvailableImages.Count == 1)
            {
                ImagePath = this.Images[AvailableImages[0]].Path;
            }
            else if (AvailableImages.Count > 0)
            {
                Random R = new Random(System.DateTime.Now.Millisecond);
                int rIndex = R.Next(0, AvailableImages.Count - 1);

                ImagePath = this.Images[AvailableImages[rIndex]].Path;
            }

            return ImagePath;
        }

        public void AddImage(string ImagePath)
        {
            GlyphImage GI = new GlyphImage();
            GI.GlyphID = this.ID;
            GI.Path = ImagePath;
            GI.Save();
            this.Images.Add(GI);
        }

        public int FindImage(string ImageID)
        {
            int Index = -1;

            for (int x = 0; x < this.Images.Count; x++)
            {
                if (this.Images[x].ID == ImageID)
                {
                    Index = x;
                    break;
                }
            }

            return Index;
        }

        public void Save(bool IncludeChildren)
        {
            if (this.ID == "")
            {
                this.ID = db.GetNewID("glyphs");
                db.ExecuteCommand("insert into glyphs (glyph_id, glyph_font_id, glyph_unicode, glyph_frequency, glyph_x_offset, glyph_y_offset) values (" + this.ID + ", " + this.FontID + ", '" + db.FixString(this.Unicode) + "', " + this.Frequency + ", " + this.XOffset + ", " + this.YOffset + ")");
            }
            else
            {
                db.ExecuteCommand("update glyphs set glyph_font_id = " + this.FontID + ", " +
                    "glyph_unicode = '" + db.FixString(this.Unicode) + "', " +
                    "glyph_frequency = " + this.Frequency + ", " +
                    "glyph_x_offset = " + this.XOffset + ", " +
                    "glyph_y_offset = " + this.YOffset + " " +
                    "where glyph_id = " + this.ID);

                if (this.Images != null && IncludeChildren)
                {
                    for (int x = 0; x < this.Images.Count; x++)
                    {
                        this.Images[x].Save();
                    }
                }
            }
        }

        public void Delete()
        {
            if (this.Images != null)
            {
                for (int x = 0; x < this.Images.Count; x++)
                {
                    this.Images[x].Delete(false);
                }
            }

            db.ExecuteCommand("delete from glyphs where glyph_id = " + this.ID);
        }
    }

    class GlyphImage
    {
        public string ID = "";
        public string GlyphID = "";
        public string Path = "";
        public string Status = "";

        DataPipe db = new DataPipe();

        public GlyphImage()
        { }

        public GlyphImage(string ID)
        {
            if (db.GetRows("select * from images where img_id = " + ID))
            {
                this.ID = ID;
                this.GlyphID = db.GetCell(0, "img_glyph_id");
                this.Path = db.GetCell(0, "img_path");
                this.Status = db.GetCell(0, "img_status");
            }
        }

        public void Save()
        {
            if (this.ID == "")
            {
                this.ID = db.GetNewID("images");
                db.ExecuteCommand("insert into images (img_id, img_glyph_id, img_path, img_status) values (" + this.ID + ", " + this.GlyphID + ", '" + db.FixString(this.Path) + "', '" + db.FixString(this.Status) + "')");
            }
            else
            {
                db.ExecuteCommand("update images set img_glyph_id = " + this.GlyphID + ", " +
                    "img_path = '" + db.FixString(this.Path) + "', " +
                    "img_status = '" + db.FixString(this.Status) + "' " +
                    "where img_id = " + this.ID);
            }
        }

        public void Delete(bool DeleteFile)
        {
            if (this.ID != "")
            {
                db.ExecuteCommand("delete from images where img_id = " + this.ID);

                if (DeleteFile)
                {
                    try
                    {
                        if (System.IO.File.Exists(db.DataDirectory + this.Path))
                        {
                            System.IO.File.Delete(db.DataDirectory + this.Path);
                        }
                    }

                    catch (Exception E) { }
                }
            }
        }
    }

    class SubList
    {
        public System.Collections.Generic.Dictionary<string, string> Characters = new Dictionary<string, string>();
        DataPipe db = new DataPipe();

        public SubList()
        {
            if (db.GetRows("select * from character_subs"))
            {
                foreach (DataRow DR in db.Bucket.Rows)
                {
                    Characters.Add(DR["cs_character"].ToString(), DR["cs_sub"].ToString());
                }
            }
        }

        public string ReplaceAll(string Input)
        {
            string Output = Input;

            if (Characters.Count > 0)
            {
                string[] Terms = Characters.Keys.ToArray<string>();
                foreach (string Term in Terms)
                {
                    Output = Output.Replace(Term, Characters[Term]);
                }
            }

            return Output;
        }

        public void Add(string Character, string Substitution)
        {
            Characters.Add(Character, Substitution);
            db.ExecuteCommand("insert into character_subs (cs_character, cs_sub) values ('" + Character + "', '" + Substitution + "')");
        }

        public void Delete(string Substitution)
        {
            if (Substitution.Contains(" => "))
            {
                string[] SubParts = Substitution.Split(new string[] { " => " }, StringSplitOptions.None);
                if (SubParts.Length == 2)
                {
                    Characters.Remove(SubParts[0]);
                    db.ExecuteCommand("delete from character_subs where cs_character = '" + SubParts[0] + "'");
                }
            }
        }
    }
}
