using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using Franken_.App_Code;
using BitMiracle.LibTiff.Classic;
using System.IO;

namespace Franken_
{
    public partial class NewFont : Form
    {
        App_Code.Font myFont = null;
        int SelectedGlyph = -1;
        App_Code.DataPipe db = new DataPipe();
        int PageStart = 0;
        int PageStop = 100;
        int DisplaySize = 55;

        public NewFont()
        {
            InitializeComponent();

            myFont = new App_Code.Font();
            remAllButton.Enabled = false;
            delGlyphButton.Enabled = false;
            reclassifyButton.Enabled = false;
            clipboardButton.Enabled = false;
            displaySizeBar.Enabled = false;
            prevPageButton.Enabled = false;
            nextPageButton.Enabled = false;
        }

        public NewFont(string FontID)
        {
            InitializeComponent();

            myFont = new App_Code.Font(FontID, true, true);

            fontNameBox.Text = myFont.Name;
            fontLineHeightBox.Value = System.Convert.ToDecimal(myFont.LineHeight);
            fontItalicBox.Checked = myFont.Italic == 1 ? true : false;
            fontBoldBox.Checked = myFont.Bold == 1 ? true : false;
            fontFixedBox.Checked = myFont.Fixed == 1 ? true : false;
            fontSerifBox.Checked = myFont.Serif == 1 ? true : false;
            fontFrakturBox.Checked = myFont.Fraktur == 1 ? true : false;

            imageContextEdit.Click += imageContextEdit_Click;
            imageContextShowInfo.Click += imageContextShowInfo_Click;
            imageContextDelete.Click += imageContextDelete_Click;

            RefreshGlyphBox();
        }

        public void RefreshGlyphBox()
        {
            remAllButton.Enabled = false;
            reclassifyButton.Enabled = false;
            displaySizeBar.Enabled = false;
            clipboardButton.Enabled = false;
            prevPageButton.Enabled = false;
            nextPageButton.Enabled = false;
            delGlyphButton.Enabled = false;

            SelectedGlyph = -1;
            imagePanel.Controls.Clear();
            glyphBox.Items.Clear();

            if (myFont.Glyphs != null)
            {
                foreach (Glyph G in myFont.Glyphs)
                {
                    glyphBox.Items.Add(G);
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            myFont.Name = fontNameBox.Text;
            myFont.LineHeight = System.Convert.ToInt32(fontLineHeightBox.Value);
            myFont.Bold = System.Convert.ToInt32(fontBoldBox.Checked);
            myFont.Fixed = System.Convert.ToInt32(fontFixedBox.Checked);
            myFont.Fraktur = System.Convert.ToInt32(fontFrakturBox.Checked);
            myFont.Italic = System.Convert.ToInt32(fontItalicBox.Checked);
            myFont.Serif = System.Convert.ToInt32(fontSerifBox.Checked);

            myFont.Save(false);

            if (SelectedGlyph > -1)
            {
                myFont.Glyphs[SelectedGlyph].Save(false);
            }

            this.Close();
        }

        private void glyphBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PageStart = 0;
            PageStop = 100;
            RefreshCharList();
        }

        private void RefreshCharList()
        {
            if (SelectedGlyph > -1)
            {
                myFont.Glyphs[SelectedGlyph].Save(false);
            }

            imagePanel.Controls.Clear();

            if (myFont != null)
            {
                SelectedGlyph = myFont.FindGlyph(((App_Code.Glyph)glyphBox.SelectedItem).Unicode);

                displaySizeBar.Enabled = true;
                remAllButton.Enabled = true;
                reclassifyButton.Enabled = true;
                clipboardButton.Enabled = true;
                delGlyphButton.Enabled = true;
                CheckPagingValues();

                if (SelectedGlyph > -1)
                {
                    xOffsetBox.Value = System.Convert.ToDecimal(myFont.Glyphs[SelectedGlyph].XOffset);
                    yOffsetBox.Value = System.Convert.ToDecimal(myFont.Glyphs[SelectedGlyph].YOffset);

                    for (int x = PageStart; x < PageStop; x++)
                    {
                        Button B = new Button();
                        B.Name = myFont.Glyphs[SelectedGlyph].Images[x].ID;

                        if(File.Exists(db.DataDirectory + myFont.Glyphs[SelectedGlyph].Images[x].Path))
                        {
                            using (FileStream stream = new FileStream(db.DataDirectory + myFont.Glyphs[SelectedGlyph].Images[x].Path, FileMode.Open, FileAccess.Read))
                            {
                                B.Image = Image.FromStream(stream);
                            }
                        
                            B.Height = DisplaySize;
                            B.Width = DisplaySize;
                        

                            if (myFont.Glyphs[SelectedGlyph].Images[x].Status == "REM")
                            {
                                B.BackColor = Color.Red;
                                B.ForeColor = Color.Red;
                            }

                            B.ContextMenuStrip = imageContextMenu;
                            B.Click += imageButton_Click;
                            //B.MouseUp += B_MouseClick;
                            imagePanel.Controls.Add(B);
                        }
                    }
                }
            }
        }

        void imageContextEdit_Click(object sender, EventArgs e)
        {
            string ImgID = ((sender as ToolStripMenuItem).GetCurrentParent() as ContextMenuStrip).SourceControl.Name;

            if (db.GetRows("select img_path from images where img_id = " + ImgID))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo(db.DataDirectory + db.GetCell(0, "img_path"));
                //startInfo.Verb = "edit";
                Process.Start(startInfo);

                DialogResult myResult = MessageBox.Show("Launching Image Editor.  After editing, click OK to reload images.", "Edit Image", MessageBoxButtons.OKCancel, MessageBoxIcon.None);
                if (myResult == System.Windows.Forms.DialogResult.OK)
                    RefreshCharList();
            }
        }

        void imageContextShowInfo_Click(object sender, EventArgs e)
        {
            GlyphImage GI = new GlyphImage(((sender as ToolStripMenuItem).GetCurrentParent() as ContextMenuStrip).SourceControl.Name);
            using (Tiff input = Tiff.Open(db.DataDirectory + GI.Path, "r"))
            {
                int GlyphWidth = input.GetField(TiffTag.IMAGEWIDTH)[0].ToInt();
                int GlyphHeight = input.GetField(TiffTag.IMAGELENGTH)[0].ToInt();
                int GlyphScanSize = input.ScanlineSize();

                MessageBox.Show("Width: " + GlyphWidth + Environment.NewLine + "Height: " + GlyphHeight + Environment.NewLine + "Scansize: " + GlyphScanSize + Environment.NewLine + "Path: " + db.DataDirectory + GI.Path);

               
            }
        }

        void imageContextDelete_Click(object sender, EventArgs e)
        {
            if (myFont != null && SelectedGlyph > -1)
            {
                string ImgID = ((sender as ToolStripMenuItem).GetCurrentParent() as ContextMenuStrip).SourceControl.Name;
                for (int x = 0; x < myFont.Glyphs[SelectedGlyph].Images.Count; x++)
                {
                    if (myFont.Glyphs[SelectedGlyph].Images[x].ID == ImgID)
                    {
                        myFont.Glyphs[SelectedGlyph].Images[x].Delete(true);
                        myFont.Glyphs[SelectedGlyph].RefreshImages();
                        RefreshCharList();
                        break;
                    }
                }
            }
        }

        private void CheckPagingValues()
        {
            if(myFont != null && SelectedGlyph > -1)
            {
                if (PageStart <= 0)
                {
                    PageStart = 0;
                    prevPageButton.Enabled = false;
                }
                else
                {
                    prevPageButton.Enabled = true;
                }

                if (PageStop >= myFont.Glyphs[SelectedGlyph].Images.Count)
                {
                    PageStop = myFont.Glyphs[SelectedGlyph].Images.Count;
                    nextPageButton.Enabled = false;
                }
                else
                {
                    nextPageButton.Enabled = true;
                }
            }
        }

        private void imageButton_Click(object sender, EventArgs e)
        {
            int gIndex = myFont.Glyphs[SelectedGlyph].FindImage(((Button)sender).Name);

            if (gIndex > -1)
            {
                if (myFont.Glyphs[SelectedGlyph].Images[gIndex].Status == "REM")
                {
                    myFont.Glyphs[SelectedGlyph].Images[gIndex].Status = "";
                    myFont.Glyphs[SelectedGlyph].Images[gIndex].Save();
                    ((Button)sender).BackColor = Color.Green;
                    ((Button)sender).ForeColor = Color.Green;
                }
                else
                {
                    myFont.Glyphs[SelectedGlyph].Images[gIndex].Status = "REM";
                    myFont.Glyphs[SelectedGlyph].Images[gIndex].Save();
                    ((Button)sender).BackColor = Color.Red;
                    ((Button)sender).ForeColor = Color.Red;
                }
            }
        }

        private void xOffsetBox_ValueChanged(object sender, EventArgs e)
        {
            if (SelectedGlyph > -1)
            {
                myFont.Glyphs[SelectedGlyph].XOffset = (float)xOffsetBox.Value;
            }
        }

        private void yOffsetBox_ValueChanged(object sender, EventArgs e)
        {
            if (SelectedGlyph > -1)
            {
                myFont.Glyphs[SelectedGlyph].YOffset = (float)yOffsetBox.Value;
            }
        }

        private void remAllButton_Click(object sender, EventArgs e)
        {
            if (SelectedGlyph > -1)
            {
                db.ExecuteCommand("update images set img_status = 'REM' where img_glyph_id = " + myFont.Glyphs[SelectedGlyph].ID);
                myFont.Glyphs[SelectedGlyph].RefreshImages();
                RefreshCharList();
            }
        }

        private void deleteFont_Click(object sender, EventArgs e)
        {
            DialogResult myResult = MessageBox.Show("Are you sure you want to delete " + myFont.Name + " and all of its data?  This process may take several minutes to complete.", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (myResult == DialogResult.Yes)
            {
                this.Enabled = false;
                glyphBox.Controls.Clear();
                myFont.Delete();
                string FontDir = db.DataDirectory + "\\GlyphExtraction\\Output\\" + myFont.ID;
                if(System.IO.Directory.Exists(FontDir))
                {
                    System.IO.Directory.Delete(FontDir, true);
                }

                this.Close();
            }
        }

        private void prevPageButton_Click(object sender, EventArgs e)
        {
            PageStart -= 100;
            PageStop = PageStart + 100;

            RefreshCharList();
        }

        private void nextPageButton_Click(object sender, EventArgs e)
        {
            PageStart += 100;
            PageStop = PageStart + 100;

            RefreshCharList();
        }

        private void reclassifyButton_Click(object sender, EventArgs e)
        {
            if (myFont != null && SelectedGlyph > -1)
            {
                Reclassify reclassWindow = new Reclassify(myFont.ID, myFont.Glyphs[SelectedGlyph].ID);
                if (reclassWindow.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.Enabled = false;
                    myFont.RefreshGlyphs(true);
                    RefreshGlyphBox();
                    this.Enabled = true;
                }
            }
        }

        private void delGlyphButton_Click(object sender, EventArgs e)
        {
            if (myFont != null && SelectedGlyph > -1)
            {
                DialogResult myResult = MessageBox.Show("Are you sure you want to delete the glyph \"" + myFont.Glyphs[SelectedGlyph].Unicode + "\"?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (myResult == DialogResult.Yes)
                {
                    this.Enabled = false;
                    myFont.Glyphs[SelectedGlyph].Delete();
                    myFont.RefreshGlyphs(true);
                    RefreshGlyphBox();
                    this.Enabled = true;
                }
            }
        }

        private void clipboardButton_Click(object sender, EventArgs e)
        {
            if (myFont != null && SelectedGlyph > -1)
            {
                System.Windows.Forms.Clipboard.SetText(myFont.Glyphs[SelectedGlyph].Unicode);
                MessageBox.Show("\"" + myFont.Glyphs[SelectedGlyph].Unicode + "\" copied to clipboard.");
            }
        }

        private void delRemovedButton_Click(object sender, EventArgs e)
        {
            if (myFont != null && SelectedGlyph > -1)
            {
                imagePanel.Controls.Clear();

                if (allPagesBox.Checked)
                {
                    if (db.GetRows("select * from images where img_glyph_id = " + myFont.Glyphs[SelectedGlyph].ID + " and img_status = 'REM'"))
                    {
                        DataTable ImgsToDelete = db.Bucket.Copy();
                        db.ExecuteCommand("delete from images where img_glyph_id = " + myFont.Glyphs[SelectedGlyph].ID + " and img_status = 'REM'");

                        foreach (DataRow DR in ImgsToDelete.Rows)
                        {
                            try
                            {
                                System.IO.File.Delete(db.DataDirectory + DR["img_path"].ToString());
                            }
                            catch (Exception E)
                            { }
                        }
                    }
                }
                else
                {
                    foreach (GlyphImage GI in myFont.Glyphs[SelectedGlyph].Images)
                    {
                        if (GI.Status == "REM")
                            GI.Delete(true);
                    }
                }

                myFont.Glyphs[SelectedGlyph].RefreshImages();
                RefreshCharList();
            }
        }

        private void displaySizeBar_Scroll(object sender, EventArgs e)
        {
            if (SelectedGlyph > -1)
            {
                DisplaySize = displaySizeBar.Value;
                RefreshCharList();
            }
        }

        private void openGlyphDir_Click(object sender, EventArgs e)
        {
            if (myFont != null)
            {
                if (Directory.Exists(db.DataDirectory + "\\GlyphExtraction\\Output\\" + myFont.ID))
                {
                    Process.Start(db.DataDirectory + "\\GlyphExtraction\\Output\\" + myFont.ID);
                }
                else
                {
                    MessageBox.Show("Directory not found.");
                }
            }
        }

        private void openTIFBoxDir_Click(object sender, EventArgs e)
        {
            if (myFont != null)
            {
                if (Directory.Exists(db.DataDirectory + "\\TiffBoxPairs\\" + myFont.ID))
                {
                    Process.Start(db.DataDirectory + "\\TiffBoxPairs\\" + myFont.ID);
                }
                else
                {
                    MessageBox.Show("Directory not found.");
                }
            }
        }
    }
}
