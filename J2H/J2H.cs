using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using HtmlAgilityPack;

namespace J2H
{
    public partial class J2H : Form
    {
        // Variable declaration
        HTMLPage html_page_object;
        string html_page_string = "";
        string file_loaction = "";
        string file_name = "";

        public J2H()
        {
            InitializeComponent();

            // Disables buttons
            this.btnCreateHtmlFile.Enabled = false;
            this.btnShowHtmlFile.Enabled = false;

            // Sets the file type that the openFileDialog can open
            this.opnfdJsonFile.Filter = "JSON files (*.json)|*.json";
            this.opnfdJsonFile.FilterIndex = 1;
        }

        // Opens openFileDialog and if selects a file sets the adjacent text box to the file path and name
        private void btnJsonFileLocation_Click(object sender, EventArgs e)
        {
            if (this.opnfdJsonFile.ShowDialog() == DialogResult.OK)
            {
                this.txtbJsonFileLocation.Text = this.opnfdJsonFile.FileName;
                this.txtbHtmlFileName.Text = this.opnfdJsonFile.SafeFileName.Substring(0, this.opnfdJsonFile.SafeFileName.IndexOf("."));
            }
        }

        // Opens folderBrowserDialog and if selects a folder sets the adjacent text box to the folder path
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
            this.opnfdJsonFile.FileName = this.txtbJsonFileLocation.Text;
            this.fldbdHtmlFileLocation.SelectedPath = this.txtbHtmlFileLocation.Text;

            if (this.txtbJsonFileLocation.Text != "" && this.txtbHtmlFileLocation.Text != "" && this.txtbHtmlFileName.Text != "")
            {
                this.btnCreateHtmlFile.Enabled = true;
            }
            else
            {
                this.btnCreateHtmlFile.Enabled = false;
            }
        }

        // Creates the html page as an object and converts it to string and creates file
        private void btnCreateHtmlFile_Click(object sender, EventArgs e)
        {
            string json_file;
            bool create_file = false;

            try
            {
                // Checks if file exists and if override it
                if (File.Exists($"{this.fldbdHtmlFileLocation.SelectedPath}\\{this.txtbHtmlFileName.Text}.html"))
                {
                    if (MessageBox.Show("The file already exists, do you want to override it?", "Override file!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        create_file = true;
                }
                else
                    create_file = true;

                if (create_file)
                {
                    StreamReader stream_reader = new StreamReader(this.opnfdJsonFile.FileName);

                    json_file = stream_reader.ReadToEnd();
                    html_page_object = new HTMLPage(this, JsonConvert.DeserializeObject(json_file));
                    html_page_string = html_page_object.convertToString();

                    stream_reader.Close();

                    StreamWriter stream_writer = new StreamWriter($"{this.fldbdHtmlFileLocation.SelectedPath}\\{this.txtbHtmlFileName.Text}.html");

                    stream_writer.Write(html_page_string);
                    stream_writer.Flush();

                    stream_writer.Close();

                    this.file_loaction = this.fldbdHtmlFileLocation.SelectedPath;
                    this.file_name = $"{this.txtbHtmlFileName.Text}.html";

                    MessageBox.Show("File successfully created!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.btnShowHtmlFile.Enabled = true;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show($"{error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Opens file in browser or explorer if so chosen
        private void btnShowHtmlFile_Click(object sender, EventArgs e)
        {
            DialogResult message = MessageBox.Show("Do you want to open the file in browser or file explorer?\nYes - browser\nNo - file explorer", "Open how?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            
            if (message == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start($"{this.file_loaction}\\{this.file_name}");
            }
            else if (message == DialogResult.No)
            {
                System.Diagnostics.Process.Start(this.file_loaction);
            }
        }
    }
}
