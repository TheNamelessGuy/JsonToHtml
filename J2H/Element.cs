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
        // Variable declaration
        private J2H main_form;
        public string name { get; set; }
        public List<Property> properties { get; set; }
        public List<Content> content { get; set; }

        // Constructor, sets variables values
        public Element(J2H main_form, dynamic element)
        {
            this.main_form = main_form;

            this.properties = new List<Property>();
            this.content = new List<Content>();
            this.name = element.Name;

            fillLists(element.Value);

            // Checks if the element is head and deletes style tag from list in main form
            if (this.name.ToLower() == "head")
                this.main_form.all_html_tags.Remove("style");
        }

        // Fills the lists
        private void fillLists(dynamic element_value)
        {
            Content new_content;
            Property new_property;
            dynamic attributes;
            JObject new_jobject;

            if (element_value.GetType().ToString() != "Newtonsoft.Json.Linq.JValue")
            {
                foreach (JProperty value in element_value.Properties())
                {
                    if (value.GetType().ToString().Contains("Newtonsoft.Json.Linq."))
                    {
                        if (this.main_form.checkIfHtmlTag(value.Name.ToLower()))
                        {
                            // Checks if elements property value is an array so it create multiple elements with the same name
                            if (value.Value.GetType().ToString() == "Newtonsoft.Json.Linq.JArray")
                            {
                                foreach (dynamic value_value in value.Value)
                                {
                                    new_jobject = new JObject();
                                    new_jobject.Add(value.Name, value_value);

                                    new_content = new Content(this.main_form, new_jobject.First);
                                    this.content.Add(new_content);
                                }
                            }
                            else
                            {
                                new_content = new Content(this.main_form, value);
                                this.content.Add(new_content);
                            }
                        }
                        else if (this.main_form.checkIfHtmlAttribute(value.Name.ToLower()) || value.Name.ToLower() == "attributes")
                        {
                            if (value.Name.ToLower() == "attributes")
                            {
                                attributes = value.Value;

                                foreach (JProperty property in attributes.Properties())
                                {
                                    new_property = new Property(this.main_form, property);
                                    this.properties.Add(new_property);
                                }
                            }
                            else
                            {
                                new_property = new Property(this.main_form, value);
                                this.properties.Add(new_property);
                            }
                        }
                        else
                        {
                            new_content = new Content(this.main_form, value);
                            this.content.Add(new_content);
                        }
                    }
                    else
                    {
                        new_content = new Content(this.main_form, value);
                        this.content.Add(new_content);
                    }
                }
            }
            else
            {
                new_content = new Content(this.main_form, element_value);
                this.content.Add(new_content);
            }
        }

        // Convert the element to string and returns the string version
        public string convertToString(int tab_counter, bool head_style_element)
        {
            string element = "";
            tab_counter++;

            // Creates tabs to pretify html file code
            for (int i = 0; i < tab_counter; i++)
                element += "\t";

            // Check if is the style tag in the head element and creates alternative element string 
            if (head_style_element)
            {
                element += $"{this.name} {{\n";

                foreach (Property property in this.properties)
                {
                    for (int i = 0; i < (tab_counter+1); i++)
                        element += "\t";

                    if (property.type == "String")
                    {
                        element += $"{property.convertToString(false, true, false)}\n";
                    }
                }

                // Creates tabs to pretify html file code
                for (int i = 0; i < tab_counter; i++)
                    element += "\t";

                element += $"}}\n";
            }
            else
            {
                if (this.name.ToLower() == "doctype")
                {
                    element += $"<!{this.name} {this.content[0].value_string}>\n";
                }
                else
                {
                    element += $"<{this.name}";

                    if (this.name.ToLower() != "style")
                    {
                        // First creates the attributes
                        if (this.properties.Count != 0)
                        {
                            foreach (Property property in this.properties)
                            {
                                element += property.convertToString(true, false, false);
                            }
                        }

                        element += ">\n";

                        // Then create the content
                        if (this.content.Count != 0)
                        {
                            foreach (Content content in this.content)
                            {
                                element += content.convertToString(tab_counter, false);
                            }
                        }
                    }
                    else
                    {
                        element += ">\n";

                        foreach (Content content in this.content)
                        {
                            element += content.convertToString(tab_counter, true);
                        }
                    }

                    // Creates tabs to pretify html file code
                    for (int i = 0; i < tab_counter; i++)
                        element += "\t";

                    element += $"</{this.name}>\n";
                }
            }

            return element;
        }
    }
}