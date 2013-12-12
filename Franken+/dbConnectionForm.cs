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
using System.IO;

namespace Franken_
{
    public partial class dbConnectionForm : Form
    {
        DataPipe db = new DataPipe();

        public dbConnectionForm()
        {
            InitializeComponent();
        }

        private void dbConnectionForm_Load(object sender, EventArgs e)
        {
            GetParams();
        }

        private void GetParams()
        {
            dbHostBox.Text = db.Host;
            dbPortBox.Text = db.Port;
            dbDatabaseBox.Text = db.Database;
            dbUserBox.Text = db.User;
            dbPasswordBox.Text = db.Password;
            tessPathBox.Text = db.TessPath;
        }

        private void SetParams()
        {
            db.Host = dbHostBox.Text;
            db.Port = dbPortBox.Text;
            db.Database = dbDatabaseBox.Text;
            db.User = dbUserBox.Text;
            db.Password = dbPasswordBox.Text;
            db.TessPath = tessPathBox.Text;
            db.SaveParams();
            db = new DataPipe();
        }

        private void dbTestButton_Click(object sender, EventArgs e)
        {
            SetParams();
            MessageBox.Show(db.CheckConnection());
        }

        private void dbSaveButton_Click(object sender, EventArgs e)
        {
            SetParams();
            this.Close();
        }

        private void dbCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dbResetButton_Click(object sender, EventArgs e)
        {
            DialogResult myResult = MessageBox.Show("Are you sure you want to clear all data?  All font information and images will be deleted.", "Reset Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (myResult == DialogResult.Yes)
            {
                db.CreateDatabase();

                db.ExecuteCommand("drop table `character_subs`");
                db.ExecuteCommand("drop table `fonts`");
                db.ExecuteCommand("drop table `glyphs`");
                db.ExecuteCommand("drop table `images`");
                db.ExecuteCommand("drop table `keys`");
                db.ExecuteCommand("drop table `languages`");

                db.ExecuteCommand("CREATE TABLE `character_subs` ( " +
                    "`cs_character` varchar(20) COLLATE utf8_bin DEFAULT NULL, " +
                    "`cs_sub` varchar(20) COLLATE utf8_bin DEFAULT NULL " +
                    ") ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin");
                db.ExecuteCommand("CREATE TABLE `fonts` ( " +
                    "`font_id` int(11) NOT NULL DEFAULT '0', " +
                    "`font_name` varchar(50) COLLATE utf8_bin DEFAULT NULL, " +
                    "`font_italic` tinyint(4) DEFAULT NULL, " +
                    "`font_bold` tinyint(4) DEFAULT NULL, " +
                    "`font_fixed` tinyint(4) DEFAULT NULL, " +
                    "`font_serif` tinyint(4) DEFAULT NULL, " +
                    "`font_fraktur` tinyint(4) DEFAULT NULL, " +
                    "`font_line_height` int(11) DEFAULT NULL, " +
                    "`font_lang_id` int(11) DEFAULT NULL," +
                    "PRIMARY KEY (`font_id`) " +
                    ") ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin");
                db.ExecuteCommand("CREATE TABLE `glyphs` ( " +
                    "`glyph_id` int(11) NOT NULL DEFAULT '0', " +
                    "`glyph_font_id` int(11) DEFAULT NULL, " +
                    "`glyph_unicode` varchar(6) COLLATE utf8_bin DEFAULT NULL, " +
                    "`glyph_frequency` int(11) DEFAULT NULL, " +
                    "`glyph_x_offset` int(11) DEFAULT NULL, " +
                    "`glyph_y_offset` int(11) DEFAULT NULL, " +
                    "PRIMARY KEY (`glyph_id`) " +
                    ") ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin");
                db.ExecuteCommand("CREATE TABLE `images` ( " +
                    "`img_id` bigint(11) NOT NULL DEFAULT '0', " +
                    "`img_glyph_id` int(11) DEFAULT NULL, " +
                    "`img_path` varchar(200) DEFAULT NULL, " +
                    "`img_status` varchar(6) DEFAULT NULL, " +
                    "PRIMARY KEY (`img_id`) " +
                    ") ENGINE=InnoDB DEFAULT CHARSET=utf8");
                db.ExecuteCommand("CREATE TABLE `languages` ( " +
                    "`lang_id` int(11) NOT NULL DEFAULT '0', " +
                    "`lang_name` varchar(50) DEFAULT NULL, " +
                    "PRIMARY KEY (`lang_id`) " +
                    ") ENGINE=InnoDB DEFAULT CHARSET=utf8");
                db.ExecuteCommand("CREATE TABLE `keys` ( " +
                    "`keys_table` varchar(20) NOT NULL DEFAULT '', " +
                    "`keys_max` bigint(11) DEFAULT NULL, " +
                    "PRIMARY KEY (`keys_table`) " +
                    ") ENGINE=InnoDB DEFAULT CHARSET=utf8");

                db.ExecuteCommand("INSERT INTO `keys` " +
                    "(keys_table, keys_max) " +
                    "VALUES ('fonts', 1)");
                db.ExecuteCommand("INSERT INTO `keys` " +
                    "(keys_table, keys_max) " +
                    "VALUES ('glyphs', 1)");
                db.ExecuteCommand("INSERT INTO `keys` " +
                    "(keys_table, keys_max) " +
                    "VALUES ('images', 1)");
                db.ExecuteCommand("INSERT INTO `keys` " +
                    "(keys_table, keys_max) " +
                    "VALUES ('languages', 1)");
            }
        }
    }
}
