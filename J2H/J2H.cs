using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace J2H
{
    public partial class J2H : Form
    {
        public string[] all_html_tags = {
            "a",
            "abbr",
            "acronym",
            "address",
            "applet",
            "area",
            "article",
            "aside",
            "audio",
            "b",
            "base",
            "basefont",
            "bdi",
            "bdo",
            "bgsound",
            "big",
            "blink",
            "blockquote",
            "body",
            "br",
            "button",
            "canvas",
            "caption",
            "center",
            "cite",
            "code",
            "col",
            "colgroup",
            "content",
            "data",
            "datalist",
            "dd",
            "decorator",
            "del",
            "details",
            "dfn",
            "dir",
            "div",
            "dl",
            "dt",
            "element",
            "em",
            "embed",
            "fieldset",
            "figcaption",
            "figure",
            "font",
            "footer",
            "form",
            "frame",
            "frameset",
            "h1",
            "h2",
            "h3",
            "h4",
            "h5",
            "h6",
            "head",
            "header",
            "hgroup",
            "hr",
            "html",
            "i",
            "iframe",
            "img",
            "input",
            "ins",
            "isindex",
            "kbd",
            "keygen",
            "label",
            "legend",
            "li",
            "link",
            "listing",
            "main",
            "map",
            "mark",
            "marquee",
            "menu",
            "menuitem",
            "meta",
            "meter",
            "nav",
            "nobr",
            "noframes",
            "noscript",
            "object",
            "ol",
            "optgroup",
            "option",
            "output",
            "p",
            "param",
            "plaintext",
            "pre",
            "progress",
            "q",
            "rp",
            "rt",
            "ruby",
            "s",
            "samp",
            "script",
            "section",
            "select",
            "shadow",
            "small",
            "source",
            "spacer",
            "span",
            "strike",
            "strong",
            "sub",
            "summary",
            "sup",
            "table",
            "tbody",
            "td",
            "template",
            "textarea",
            "tfoot",
            "th",
            "thead",
            "time",
            "title",
            "tr",
            "track",
            "tt",
            "u",
            "ul",
            "var",
            "video",
            "wbr",
            "xmp"
        };
        HTMLPage html_page;

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
            try
            {
                html_page = new HTMLPage(this , this.opnfdJsonFile);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Checks if the string "is_tag" is an html tag
        public bool checkIfHtmlTag(string is_tag)
        {
            foreach (string tag in all_html_tags)
            {
                if (is_tag == tag)
                    return true;
            }

            return false;
        }
    }
}
