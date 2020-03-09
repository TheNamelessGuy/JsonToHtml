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
        public string name { get; set; }
        public List<Property> properties { get; set; }
        public List<Content> content { get; set; }

        // Constructor, sets variables values
        public Element(dynamic element, bool head_style_element)
        {
            this.properties = new List<Property>();
            this.content = new List<Content>();
            this.name = element.Name;

            fillLists(element.Value, head_style_element);
        }

        // Fills the lists
        private void fillLists(dynamic element_value, bool head_style_element)
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
                        if (value.Name.ToLower() == "attributes" || value.Name.ToLower() == "language" || this.name == "meta" || this.name == "link" || (head_style_element && this.name != "style"))
                        {
                            if (this.name.ToLower() == "meta")
                            {
                                if (value.Name.ToLower() == "charset")
                                {
                                    new_property = new Property(value);
                                    this.properties.Add(new_property);
                                }
                                else
                                {
                                    new_property = new Property(new JProperty("name", value.Name));
                                    this.properties.Add(new_property);

                                    new_property = new Property(new JProperty("content", value.Value));
                                    this.properties.Add(new_property);
                                }
                            }
                            else if (value.Name.ToLower() == "attributes")
                            {
                                attributes = value.Value;

                                foreach (JProperty property in attributes.Properties())
                                {
                                    new_property = new Property(property);
                                    this.properties.Add(new_property);
                                }
                            }
                            else
                            {
                                new_property = new Property(value);
                                this.properties.Add(new_property);
                            }
                        }
                        else
                        {
                            // Checks if elements property value is an array so it create multiple elements with the same name
                            if (value.Value.GetType().ToString() == "Newtonsoft.Json.Linq.JArray")
                            {
                                foreach (dynamic value_value in value.Value)
                                {
                                    new_jobject = new JObject(new JProperty(value.Name, value_value));

                                    new_content = new Content(new_jobject.First, false);
                                    this.content.Add(new_content);
                                }
                            }
                            else if (value.Name.ToLower() == "meta")
                            {
                                foreach (dynamic value_value in value.Value)
                                {
                                    new_jobject = new JObject(new JProperty(value.Name, new JObject(value_value)));

                                    new_content = new Content(new_jobject.First, false);
                                    this.content.Add(new_content);
                                }
                            }
                            else if (value.Name.ToLower() == "style")
                            {
                                new_content = new Content(value, true);
                                this.content.Add(new_content);
                            }
                            else
                            {
                                if (head_style_element)
                                {
                                    new_content = new Content(value, head_style_element);
                                    this.content.Add(new_content);
                                }
                                else
                                {
                                    new_content = new Content(value, false);
                                    this.content.Add(new_content);
                                }
                            }
                        }
                    }
                    else
                    {
                        new_content = new Content(value, false);
                        this.content.Add(new_content);
                    }
                }
            }
            else
            {
                new_content = new Content(element_value, false);
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
                        element += $"{property.convertToString(false, true, false, false)}\n";
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
                                element += property.convertToString(true, false, false, false);
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

                    if (this.content.Any())
                    {
                        // Creates tabs to pretify html file code
                        for (int i = 0; i < tab_counter; i++)
                            element += "\t";

                        element += $"</{this.name}>\n";
                    }
                }
            }

            return element;
        }
    }
}