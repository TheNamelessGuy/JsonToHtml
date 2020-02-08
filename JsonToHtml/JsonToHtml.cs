using System;
using System.IO;
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
using System.Drawing.Drawing2D;

namespace JsonToHtml
{
    public partial class fJsonToHtml : Form
    {
        string output_file_path = "";
        string input_file_path = "";
        string input_file = "";
        dynamic input;
        string output = "";
        string[] html_tags = {
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
        string created_file_path = "";
        int in_body_or_head = -1;
        bool first_element;
        bool style_first = false;
        bool rearranging_properties = false;
        bool after_contant = false;

        public fJsonToHtml()
        {
            InitializeComponent();

            this.ofdInput.InitialDirectory = "C:\\";
            this.ofdInput.Filter = "JSON files (*.json)|*.json";
            this.ofdInput.FilterIndex = 1;
            this.ofdInput.RestoreDirectory = true;
        }

        private void TxtboxInputOutput_TextChanged(object sender, EventArgs e)
        {
            this.input_file_path = txtboxInput.Text;
            this.output_file_path = txtboxOutput.Text;

            if (this.txtboxInput.Text != "" && this.txtboxOutput.Text != "")
            {
                this.btnCreate.Enabled = true;
            }
            else
            {
                this.btnCreate.Enabled = false;
            }
        }

        private void BtnInput_Click(object sender, EventArgs e)
        {
            if (this.ofdInput.ShowDialog() == DialogResult.OK)
            {
                this.txtboxInput.Text = this.ofdInput.FileName;
            }
        }

        private void BtnOutput_Click(object sender, EventArgs e)
        {
            if (this.fbdOutput.ShowDialog() == DialogResult.OK)
            {
                this.txtboxOutput.Text = this.fbdOutput.SelectedPath;
            }
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            if (CheckIfOutputFileExists())
            {
                if (MessageBox.Show("The file already exists, do you wish to override it?", "File Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        StreamReader input_reader = new StreamReader(input_file_path);
                        input_file = input_reader.ReadToEnd();
                        input = JsonConvert.DeserializeObject(input_file);
                        input_reader.Close();

                        GenerateOutput();
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                try
                {
                    StreamReader input_reader = new StreamReader(input_file_path);
                    input_file = input_reader.ReadToEnd();
                    this.input = JsonConvert.DeserializeObject(input_file);
                    input_reader.Close();

                    GenerateOutput();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            DialogResult message = MessageBox.Show("Do you want to open the file in a browser or the loaction of the created file?\nYes - browser\nNo - file location", "Open", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (message == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(created_file_path + "\\output.html");
            }
            else if (message == DialogResult.No)
            {
                System.Diagnostics.Process.Start(created_file_path);
            }
        }

        private bool CheckIfOutputFileExists()
        {
            try
            {
                if (File.Exists(this.output_file_path + "\\output.html"))
                    return true;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private void GenerateOutput()
        {
            this.output = "";
            bool language = false;

            foreach (JProperty property_html in this.input.Properties())
            {
                if ((property_html.Name == "doctype" || property_html.Name == "Doctype" || property_html.Name == "DOCTYPE") && (property_html.Value != null || property_html.Value.ToString() != ""))
                {
                    this.output += "<!" + property_html.Name + " " + property_html.Value + ">\n";
                }
                else if ((property_html.Name == "language" || property_html.Name == "Language" || property_html.Name == "LANGUAGE") && (property_html.Value != null || property_html.Value.ToString() != ""))
                {
                    this.output += "<html " + property_html.Name +"=\"" + property_html.Value +"\">\n";
                    language = true;
                }
            }

            if (!language)
                this.output += "<html>";


            foreach (JProperty property in this.input.Properties())
            {
                if (((property.Name == "doctype" || property.Name == "Doctype" || property.Name == "DOCTYPE") && (property.Value != null || property.Value.ToString() != "")) || ((property.Name == "language" || property.Name == "Language" || property.Name == "LANGUAGE") && (property.Value != null || property.Value.ToString() != ""))) { }
                else
                {
                    if (property.Name == "head" || property.Name == "HEAD" || property.Name == "Head")
                    {
                        this.in_body_or_head = 0;
                    }
                    else if (property.Name == "body" || property.Name == "BODY" || property.Name == "Body")
                    {
                        this.in_body_or_head = 1;
                    }

                    this.output += "<" + property.Name;
                    GenerateOutputPropertiesDeconstruction(property.Value);
                    this.output += "></" + property.Name + ">\n";
                }
            }
            this.output += "</html>";

            outputCodeCleanUp();

            try
            {
                StreamWriter output_writer = new StreamWriter(output_file_path + "\\output.html");
                output_writer.Write(this.output);
                output_writer.Flush();
                MessageBox.Show("File successfully converted and created!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                created_file_path = output_file_path;
                btnShow.Enabled = true;
                output_writer.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerateOutputPropertiesDeconstruction(dynamic properties)
        {
            first_element = true;
            foreach (JProperty property_in_property in properties.Properties())
            {
                if (property_in_property.Value.GetType().ToString() == "Newtonsoft.Json.Linq.JObject")
                {
                    if (CheckIfItIsAnHtmlTag(property_in_property.Name))
                    {
                        this.output += ">\n<" + property_in_property.Name;

                        if (in_body_or_head == 0)
                            GenerateOutputPropertiesDeconstruction(property_in_property.Value);
                        else if (in_body_or_head == 1)
                            rearrangeHtmlTagElements(property_in_property.Value);

                        if (this.after_contant)
                        {
                            this.output += "</" + property_in_property.Name + ">\n";
                            this.after_contant = false;
                        }
                        else
                            this.output += ">\n</" + property_in_property.Name + ">\n";
                    }
                    else
                    {
                        if (property_in_property.Name == "style" || property_in_property.Name == "STYLE" || property_in_property.Name == "Style")
                        {
                            if (in_body_or_head == 0)
                            {
                                this.output += ">\n<" + property_in_property.Name + ">";
                                GenerateStyleTagInHead(property_in_property.Value);
                                this.output += "</" + property_in_property.Name + ">\n";
                            }
                            else if (in_body_or_head == 1)
                            {
                                this.output += " " + property_in_property.Name + "=\"";
                                GenerateStyleInBody(property_in_property.Value);
                                this.output += "\"";

                                if (first_element)
                                    style_first = true;
                            }
                        }
                        else
                        {
                            this.output += " name=\"" + property_in_property.Name + "\"";
                            GenerateOutputPropertiesDeconstruction(property_in_property.Value);
                        }
                    }
                }
                else if (property_in_property.Value.GetType().ToString() == "Newtonsoft.Json.Linq.JValue")
                {
                    if (CheckIfItIsAnHtmlTag(property_in_property.Name))
                    {
                        if (this.first_element)
                            this.output += ">\n<" + property_in_property.Name + ">" + property_in_property.Value + "</" + property_in_property.Name + ">\n";
                        else
                            this.output += "<" + property_in_property.Name + ">" + property_in_property.Value + "</" + property_in_property.Name;
                    }
                    else
                    {
                        if (rearranging_properties)
                        {
                            this.output += property_in_property.Name + ":" + property_in_property.Value + ";";
                        }
                        else
                            this.output += " " + property_in_property.Name + "=\"" + property_in_property.Value + "\"";
                    }
                }
                if (this.style_first)
                {
                    this.style_first = false;
                    this.first_element = true;
                }
                else
                    this.first_element = false;
            }
        }

        private void rearrangeHtmlTagElements(dynamic elements)
        {
            foreach (JProperty property in elements.Properties())
            {
                if (!CheckIfItIsAnHtmlTag(property.Name) || property.Name == "STYLE" || property.Name == "style" || property.Name == "Style")
                {
                    if (property.Value.GetType().ToString() == "Newtonsoft.Json.Linq.JValue")
                    {
                        this.output += " " + property.Name + "=\"" + property.Value + "\"";
                    }
                    else
                    {
                        this.output += " " + property.Name + "=\"";
                        this.rearranging_properties = true;
                        GenerateOutputPropertiesDeconstruction(property.Value);
                        this.rearranging_properties = false;
                        this.output += "\"";
                    }
                }
            }

            foreach (JProperty property in elements.Properties())
            {
                if (CheckIfItIsAnHtmlTag(property.Name))
                {
                    if (property.Name == "content")
                    {
                        this.output += ">\n" + property.Value + "\n";
                        this.after_contant = true;
                    }
                    else
                    {
                        if (property.Value.GetType().ToString() == "Newtonsoft.Json.Linq.JValue")
                        {
                            if (this.after_contant)
                            {
                                this.output += "<" + property.Name + ">" + property.Value + "</" + property.Name;
                                this.after_contant = false;
                            }
                            else
                                this.output += ">\n<" + property.Name + ">" + property.Value + "</" + property.Name + ">\n";
                        }
                        else
                        {
                            this.output += "<" + property.Name;
                            first_element = true;
                            GenerateOutputPropertiesDeconstruction(property.Value);
                            this.output += ">\n</" + property.Name;
                        }
                    }
                }
            }
        }

        private void GenerateStyleTagInHead(dynamic style_tag)
        {
            foreach (JProperty style_property in style_tag.Properties())
            {
                if (CheckIfItIsAnHtmlTag(style_property.Name))
                    this.output += "\n" + style_property.Name + " {\n";
                else
                    this.output += "\n." + style_property.Name + " {\n";

                foreach (JProperty property in style_property.Value)
                {
                    this.output += property.Name + ": " + property.Value + ";\n";
                }
                this.output += "}\n";
            }
        }

        private void GenerateStyleInBody(dynamic tag_style)
        {
            foreach (JProperty style_property in tag_style.Properties())
            {
                this.output += style_property.Name + ":" + style_property.Value + ";";
            }
        }

        private bool CheckIfItIsAnHtmlTag(string is_tag)
        {
            foreach (string tag in html_tags)
            {
                if (is_tag.ToLower() == tag.ToLower())
                    return true;
            }
            return false;
        }

        private void outputCodeCleanUp()
        {
            string clean_output = "";
            bool change = false;

            if (this.output.Contains(">></"))
            {
                clean_output = this.output.Replace(">></", ">\n</");
                change = true;
            }
            if (this.output.Contains(">\n></"))
            {
                clean_output = this.output.Replace(">\n></", ">\n</");
                change = true;
            }
            if (this.output.Contains(">\n>"))
            {
                clean_output = this.output.Replace(">\n>", ">");
                change = true;
            }

            if (change)
                this.output = clean_output;
        }
    }
}