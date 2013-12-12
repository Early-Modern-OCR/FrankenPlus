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
    public partial class Progress : Form
    {
        public event EventHandler<EventArgs> Canceled;

        public Progress()
        {
            InitializeComponent();
        }

        public string Message
        {
            set { statusLabel.Text = value; }
        }

        public int ProgressValue
        {
            set { progressBar.Value = value; }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            // Create a copy of the event to work with
            EventHandler<EventArgs> ea = Canceled;
            /* If there are no subscribers, ea will be null so we need to check
                * to avoid a NullReferenceException. */
            if (ea != null)
                ea(this, e);
        }
    }
}
