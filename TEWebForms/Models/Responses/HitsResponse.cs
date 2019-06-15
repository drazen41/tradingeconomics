using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TEWebForms.Models.Responses
{
    public class HitsResponse
    {
        public List<string> Country { get; set; }
        public string Category { get; set; }
        public List<string> Currency { get; set; }
        public string IIDS { get; set; }
        public string S { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public List<string> Group { get; set; }
        public List<string> Frequency { get; set; }
        public string Unit { get; set; }
        public string Pretty_Name { get; set; }
        public string Url { get; set; }

    }
}