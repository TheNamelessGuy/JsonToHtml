using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J2H
{
    public class Element
    {
        public string html_tag { get; set; }
        public List<string> tag_properties { get; set; }
        public string content { get; set; }

        public Element()
        {

        }
    }
}