using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Franken_.App_Code;

namespace Franken_
{
    public partial class Reclassify : Form
    {
        App_Code.Font myFont = null;
        string glyphToReclassifyID = "";
        DataPipe db = new DataPipe();

        public Reclassify(string FontID, string GlyphID)
        {
            InitializeComponent();
            myFont = new App_Code.Font(FontID, true, false);
            glyphToReclassifyID = GlyphID;

            if (myFont.Glyphs != null)
            {
                foreach (Glyph G in myFont.Glyphs)
                {
                    if (G.ID != glyphToReclassifyID)
                    {
                        comboBox.Items.Add(G);
                    }
                    else
                    {
                        comboCharLabel.Text = G.Unicode;
                        boxCharLabel.Text = G.Unicode;
                    }
                }
            }
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (comboButton.Checked)
            {
                comboPanel.Enabled = true;
                boxPanel.Enabled = false;
            }
            else
            {
                comboPanel.Enabled = false;
                boxPanel.Enabled = true;
            }
        }

        private void modeReclassButton_CheckedChanged(object sender, EventArgs e)
        {
            if (modeReclassButton.Checked)
            {
                comboLabel1.Text = "Reclassify all images associated with";
                boxLabel1.Text = "Reclassify all images associated with";
                comboLabel2.Text = "as";
                boxLabel1.Text = "as";
            }
            else
            {
                comboLabel1.Text = "Copy all images associated with";
                boxLabel1.Text = "Copy all images associated with";
                comboLabel2.Text = "to";
                boxLabel1.Text = "to";
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            string newGlyphID = "";

            if (comboButton.Checked)
            {
                if (comboBox.SelectedItem != null)
                {
                    newGlyphID = (comboBox.SelectedItem as Glyph).ID;
                }
                else
                {
                    MessageBox.Show("Please choose a new character for reclassification.");
                }
            }
            else
            {
                if (boxBox.Text != "")
                {
                    for (int x = 0; x < myFont.Glyphs.Count; x++)
                    {
                        if (myFont.Glyphs[x].Unicode == boxBox.Text)
                        {
                            newGlyphID = myFont.Glyphs[x].ID;
                            break;
                        }
                    }

                    if (newGlyphID == "")
                    {
                        newGlyphID = myFont.AddEmptyGlyph(boxBox.Text.Trim());
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a new character for reclassification.");
                }
            }

            if (newGlyphID != "")
            {
                if (modeReclassButton.Checked)
                {
                    db.ExecuteCommand("update images set img_glyph_id = " + newGlyphID + " where img_glyph_id = " + glyphToReclassifyID);
                    db.ExecuteCommand("delete from glyphs where glyph_id = " + glyphToReclassifyID);
                }
                else
                {
                    if (db.GetRows("select * from images where img_glyph_id = " + glyphToReclassifyID))
                    {
                        DataTable Gs = db.Bucket.Copy();
                        foreach (DataRow G in Gs.Rows)
                        {
                            string gID = db.GetNewID("images");
                            db.ExecuteCommand("INSERT INTO images " +
                                "(img_id, img_glyph_id, img_path, img_status) " +
                                "VALUES (" + gID + ", " + newGlyphID + ", '" + db.FixString(G["img_path"].ToString()) + "', '" + db.FixString(G["img_status"].ToString()) + "')");
                        }
                    }
                }

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
