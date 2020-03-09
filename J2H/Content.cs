using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace J2H
{
    public class Content
    {
        // Variable declaration
        public string type { get; set; }
        public string value_string { get; set; }
        public Element value_element { get; set; }

        public Content(dynamic value, bool head_style_element)
        {
            this.fillContent(value, head_style_element);
        }

        private void fillContent(dynamic value, bool head_style_element)
        {
            // Checks what kind of content it is and if it is not a string create a element and otherwise fills the string sets type string
            if (value.GetType().ToString() != "Newtonsoft.Json.Linq.JValue")
            {
                if (value.Name.ToLower() != "text")
                {
                    this.type = "Element";
                    this.value_element = new Element(value, head_style_element);
                }
                else if (value.Name.ToLower() == "text")
                {
                    this.type = "String";
                    this.value_string = value.Value;
                }
            }
            else
            {
                this.type = "String";
                this.value_string = value.Value;
            }
        }

        // Converts to string and returns it
        public string convertToString(int tab_counter, bool head_style_element)
        {
            string content = "";
            tab_counter++;

            if (this.type == "String")
            {
                for (int i = 0; i < tab_counter; i++)
                    content += "\t";

                content += $"{this.value_string}\n";
            }
            else if (this.type == "Element")
            {
                content += this.value_element.convertToString(tab_counter-1, head_style_element);
            }

            return content;
        }
    }
}
