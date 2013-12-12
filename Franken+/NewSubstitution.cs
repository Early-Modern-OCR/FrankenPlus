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
    public partial class NewSubstitution : Form
    {
        public NewSubstitution()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (charBox.Text != "" && subBox.Text != "")
            {
                App_Code.SubList Subs = new App_Code.SubList();
                Subs.Add(charBox.Text, subBox.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter a character and a substitution.");
            }
        }
    }
}
