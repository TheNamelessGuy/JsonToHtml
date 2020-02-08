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

        public Element(string element_name, dynamic element_value)
        {
            this.element_name = element_name;
        }

        private void fillLists(dynamic element_value)
        {
            Content new_content;
            Property new_property;

            if (element_value.GetType().ToString().Contains("Newtonsoft.Json.Linq."))
            {
                if (main_form.checkIfHtmlTag(element_value.Name))
                {
                    new_content = new Content(main_form, element_value);
                }
                else
                {
                    new_property = new Property();
                }
            }
            else
            {
                new_content = new Content(main_form, element_value);
            }
        }
    }
}