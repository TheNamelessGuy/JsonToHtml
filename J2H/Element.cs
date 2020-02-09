using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace J2H
{
    public class Element
    {
        private J2H main_form;
        public string element_name { get; set; }
        public List<Property> properties { get; set; }
        public List<Content> content { get; set; }

        public Element(J2H main_form, dynamic element)
        {
            this.main_form = main_form;

            this.properties = new List<Property>();
            this.content = new List<Content>();
            this.element_name = element.Name;

            fillLists(element.Value);
        }

        private void fillLists(dynamic element_value)
        {
            Content new_content;
            Property new_property;

            if (element_value.GetType().ToString() != "Newtonsoft.Json.Linq.JValue")
            {
                foreach (JProperty value in element_value.Properties())
                {
                    if (value.GetType().ToString().Contains("Newtonsoft.Json.Linq."))
                    {
                        if (this.main_form.checkIfHtmlTag(value.Name))
                        {
                            new_content = new Content(main_form, value);
                            this.content.Add(new_content);
                        }
                        else
                        {
                            new_property = new Property(this.main_form, value);
                            this.properties.Add(new_property);
                        }
                    }
                    else
                    {
                        new_content = new Content(main_form, value);
                        this.content.Add(new_content);
                    }
                }
            }
            else
            {
                new_content = new Content(main_form, element_value);
                this.content.Add(new_content);
            }
        }
    }
}