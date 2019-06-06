using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TE1.Models.Responses
{
    public class HitsResponse
    {
        public List<string> Country { get; set; }
        public string Category { get; set; }
        public List<string> Currency { get; set; }
        public string IIDS { get; set; }
        public string S { get; set; }
        public string Name { get; set; }
    }
}