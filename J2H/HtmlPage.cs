﻿using System;
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
        private J2H main_form;
        private List<Element> elements { get; set; }

        public HTMLPage(J2H main_form, dynamic json_file)
        {
            this.main_form = main_form;
            this.fillList(json_file);
        }

        private void fillList(dynamic json_file)
        {
            Element new_element;
            foreach (JProperty element in json_file.Properties())
            {
                if (main_form.checkIfHtmlTag(element.Name))
                {
                    new_element = new Element(element.Name, element.Value);
                }
                else
                {

                }
            }
        }
    }
}
