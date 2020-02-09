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

        public Content(J2H main_form, dynamic value)
        {
            this.main_form = main_form;

            if (value.GetType().ToString() != "Newtonsoft.Json.Linq.JValue")
            {
                if (main_form.checkIfHtmlTag(value.Name) && value.Name != "content")
                {
                    this.content_type = "element";
                    this.content_e = new Element(this.main_form, value);
                }
                else if (value.Name == "content")
                {
                    this.content_type = "string";
                    this.content_s = value.Value;
                }
            }
            else
            {
                this.content_type = "string";
                this.content_s = value.Value;
            }
        }
    }
}
