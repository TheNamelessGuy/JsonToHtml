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
        public string property_type { get; set; }
        public string property_name { get; set; }
        public string property_value_s { get; set; }
        public List<Property> property_value_p { get; set; }

        public Property(J2H main_form, dynamic value)
        {
            this.main_form = main_form;

            this.property_value_p = new List<Property>();
            this.property_name = value.Name;

            if (value.Value.GetType().ToString() == "Newtonsoft.Json.Linq.JObject")
            {
                this.property_type = "properties";
                this.fillList(value.Value);
            }
            else
            {
                this.property_type = "string";
                this.property_value_s = value.Value;
           }
        }

        private void fillList(dynamic value_value)
        {
            Property new_property;

            foreach (JProperty value in value_value.Properties())
            {
                new_property = new Property(this.main_form, value);
                this.property_value_p.Add(new_property);
            }
        }
    }
}
