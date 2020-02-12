using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace J2H
{
    public class HTMLPage
    {
        // Variable declaration
        private J2H main_form;
        public List<Element> elements { get; set; }

        // Constructor sets the variables value
        public HTMLPage(J2H main_form, dynamic json_file)
        {
            this.main_form = main_form;

            this.elements = new List<Element>();

            this.fillList(json_file);
        }

        // Fill the "elements" list with Elements
        private void fillList(dynamic json_file)
        {
            Element new_element;
            JObject new_json_file = new JObject();

            // Checks if there is a "doctype" in the file and sets it first
            foreach (JProperty element in json_file.Properties())
            {
                if (!main_form.checkIfHtmlTag(element.Name.ToLower()) && element.Name.ToLower() == "doctype")
                {
                    new_element = new Element(main_form, element);
                    this.elements.Add(new_element);

                    json_file.Property(element.Name).Remove();
                    break;
                }
            }

            // Create html tag and adds it to the list
            new_json_file.Add("html", json_file);
            new_element = new Element(main_form, new_json_file.First);
            this.elements.Add(new_element);
        }

        // Converts the html page as an object to string and returns it
        public string convertToString()
        {
            string html_page = "";
            int tab_counter = -1;

            foreach (Element element in elements)
            {
                html_page += element.convertToString(tab_counter, false);
            }

            return html_page;
        }
    }
}
