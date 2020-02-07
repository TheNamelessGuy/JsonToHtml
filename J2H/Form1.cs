using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace J2H
{
    public partial class fJ2H : Form
    {
        public fJ2H()
        {
            InitializeComponent();

            // Disables buttons
            this.btnCreateHtmlFile.Enabled = false;
            this.btnShowHtmlFile.Enabled = false;

            // Sets the file type that the openFileDialog can open
            this.opnfdJsonFile.Filter = "JSON files (*.json)|*.json";
            this.opnfdJsonFile.FilterIndex = 1;
        }

        // On "Search" button click opens openFileDialog and if selects a file sets the adjacent text box to the file path and name
        private void btnJsonFileLocation_Click(object sender, EventArgs e)
        {
            if (this.opnfdJsonFile.ShowDialog() == DialogResult.OK)
            {
                this.txtbJsonFileLocation.Text = this.opnfdJsonFile.FileName;
            }
        }

        // On "Set" button click opens folderBrowserDialog and if selects a folder sets the adjacent text box to the folder path
        private void btnHtmlFileLocation_Click(object sender, EventArgs e)
        {
            if (this.fldbdHtmlFileLocation.ShowDialog() == DialogResult.OK)
            {
                this.txtbHtmlFileLocation.Text = this.fldbdHtmlFileLocation.SelectedPath;
            }
        }

        // Checks if all text box fields are not empty and if they aren't enables the "Create" button
        private void txtbJsonFileHtmlFile_TextChanged(object sender, EventArgs e)
        {
            if (this.txtbJsonFileLocation.Text != "" && this.txtbHtmlFileLocation.Text != "" && this.txtbHtmlFileName.Text != "")
            {
                this.btnCreateHtmlFile.Enabled = true;
            }
            else
            {
                this.btnCreateHtmlFile.Enabled = false;
            }
        }

        private void btnCreateHtmlFile_Click(object sender, EventArgs e)
        {

        }
    }
}
