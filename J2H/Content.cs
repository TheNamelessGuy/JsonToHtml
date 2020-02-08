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
        private J2H main_form;
        public string content_type { get; }
        public string content_s { get; set; }
        public Element content_e { get; set; }

        public Content(J2H main_form, dynamic element_value)
        {
            this.main_form = main_form;

            if (element_value.GetType().ToString().Contains("Newtonsoft.Json.Linq."))
            {
                if (main_form.checkIfHtmlTag(element_value.Name) && element_value.Name != "content")
                {
                    content_e = new Element(element_value.Name, element_value.Value);
                }
                else if (element_value.Name == "content")
                {
                    this.content_s = element_value;
                    this.content_type = "string";
                }
            }
            else
            {
                this.content_s = element_value;
                this.content_type = "string";
            }
        }
    }
}
