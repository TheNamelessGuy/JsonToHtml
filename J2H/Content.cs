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
        private J2H main_form;
        public string type { get; set; }
        public string value_string { get; set; }
        public Element value_element { get; set; }

        public Content(J2H main_form, dynamic value)
        {
            this.main_form = main_form;

            this.fillContent(value);
        }

        private void fillContent(dynamic value)
        {
            // Checks what kind of content it is and if it is not a string create a element and otherwise fills the string sets type string
            if (value.GetType().ToString() != "Newtonsoft.Json.Linq.JValue")
            {
                if ((main_form.checkIfHtmlTag(value.Name.ToLower()) && value.Name.ToLower() != "text") || (!this.main_form.checkIfHtmlAttribute(value.Name.ToLower())))
                {
                    this.type = "Element";
                    this.value_element = new Element(this.main_form, value);
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
