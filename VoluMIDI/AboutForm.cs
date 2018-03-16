using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VoluMIDI
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            versionLabel.Text = "Version " + Application.ProductVersion;
        }

        private void prolapsoftButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.prolapsoft.com/");
        }
    }
}
