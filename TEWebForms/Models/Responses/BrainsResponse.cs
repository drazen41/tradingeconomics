using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TEWebForms.Models.Responses
{
    public class BrainsResponse
    {
        public InfoResponse Info { get; set; }
        public List<HitsResponse> Hits { get; set; }
        public int Stance { get; set; }
    }
}