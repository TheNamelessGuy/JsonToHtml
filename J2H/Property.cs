using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace J2H
{
    public class Property
    {
        private J2H main_form;
        public string type { get; set; }
        public string name { get; set; }
        public string value_string { get; set; }
        public List<Property> value_properties { get; set; }

        public Property(J2H main_form, dynamic value)
        {
            this.main_form = main_form;

            this.value_properties = new List<Property>();
            this.name = value.Name;

            // Checks if values value contains more values and creates them
            if (value.Value.GetType().ToString() == "Newtonsoft.Json.Linq.JObject")
            {
                this.type = "Properties";
                this.fillList(value.Value);
            }
            else
            {
                this.type = "String";
                this.value_string = value.Value;
           }
        }

        // Fills the list with the properties
        private void fillList(dynamic value_value)
        {
            Property new_property;

            foreach (JProperty value in value_value.Properties())
            {
                new_property = new Property(this.main_form, value);
                this.value_properties.Add(new_property);
            }
        }

        // Converts to string and returns it
        public string convertToString(bool parent_element, bool style_properties, bool class_properties)
        {
            string return_property = "";

            if (this.name == "viewport")
            {
                return_property += $" name=\"{this.name}\" content=\"";

                foreach (Property property in this.value_properties)
                {
                    return_property += property.convertToString(false, false, false);
                }

                return_property += "\"";
            }
            else
            {
                if (parent_element)
                {
                    return_property += $" {this.name}=\"";

                    if (this.type == "String")
                    {
                        return_property += $"{this.value_string}";
                    }
                    else
                    {
                        foreach (Property property in this.value_properties)
                        {
                            if (this.name == "style")
                            {
                                return_property += property.convertToString(false, true, false);
                            }
                            else if (this.name == "class")
                            {
                                return_property += property.convertToString(false, false, true);
                            }
                            else
                            {
                                return_property += property.convertToString(false, false, false);
                            }
                        }
                    }

                    return_property += $"\"";
                }
                else
                {
                    if (style_properties)
                    {
                        return_property += $"{this.name}:{this.value_string}; ";
                    }
                    else if (class_properties)
                    {
                        return_property += $"{this.value_string} ";
                    }
                    else
                    {
                        return_property += $"{this.name}={this.value_string}, ";
                    }
                }
            }

            return return_property;
        }
    }
}
