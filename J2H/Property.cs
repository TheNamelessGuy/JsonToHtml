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
        // Variable declaration
        public string type { get; set; }
        public string name { get; set; }
        public string value_string { get; set; }
        public List<Property> value_properties { get; set; }

        public Property(dynamic value)
        {
            this.value_properties = new List<Property>();
            this.name = value.Name;

            this.fillProperty(value.Value);
        }

        // Fills the list with the properties
        private void fillProperty(dynamic value)
        {
            Property new_property;

            // Checks if values value contains more values and creates them
            if (value.GetType().ToString() == "Newtonsoft.Json.Linq.JObject")
            {
                this.type = "Properties";
                foreach (JProperty value_value in value.Properties())
                {
                    new_property = new Property(value_value);
                    this.value_properties.Add(new_property);
                }
            }
            else
            {
                this.type = "String";
                this.value_string = value;
            }
        }

        // Converts to string and returns it
        public string convertToString(bool parent_element, bool style_properties, bool class_properties, bool final_attribute)
        {
            string return_property = "";

            if (this.name == "viewport")
            {
                return_property += $" name=\"{this.name}\" content=\"";

                foreach (Property property in this.value_properties)
                {
                    if (property.Equals(this.value_properties.Last()))
                        return_property += property.convertToString(false, false, false, true);
                    else
                        return_property += property.convertToString(false, false, false, false);
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
                            if (property.Equals(this.value_properties.Last()))
                            {
                                if (this.name == "style")
                                {
                                    return_property += property.convertToString(false, true, false, true);
                                }
                                else if (this.name == "class")
                                {
                                    return_property += property.convertToString(false, false, true, true);
                                }
                                else
                                {
                                    return_property += property.convertToString(false, false, false, true);
                                }
                            }
                            else
                            {
                                if (this.name == "style")
                                {
                                    return_property += property.convertToString(false, true, false, false);
                                }
                                else if (this.name == "class")
                                {
                                    return_property += property.convertToString(false, false, true, false);
                                }
                                else
                                {
                                    return_property += property.convertToString(false, false, false, false);
                                }
                            }
                        }
                    }

                    return_property += $"\"";
                }
                else
                {
                    if (final_attribute)
                    {
                        if (style_properties)
                        {
                            return_property += $"{this.name}:{this.value_string};";
                        }
                        else if (class_properties)
                        {
                            return_property += $"{this.value_string}";
                        }
                        else
                        {
                            return_property += $"{this.name}={this.value_string}";
                        }
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
            }

            return return_property;
        }
    }
}
