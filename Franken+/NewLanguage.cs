using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Franken_
{
    public partial class NewLanguage : Form
    {
        bool copyFont = false;
        public string NewName = "";

        public NewLanguage()
        {
            InitializeComponent();
        }

        public NewLanguage(bool CopyFont)
        {
            InitializeComponent();

            copyFont = CopyFont;
            titleLabel.Text = "New font name:";
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (langNameBox.Text != "" && !copyFont)
            {
                App_Code.Language L = new App_Code.Language();
                L.Name = langNameBox.Text;
                L.Save();
                this.Close();
            }
            else if (langNameBox.Text != "" && copyFont)
            {
                NewName = langNameBox.Text;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter a name.");
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
