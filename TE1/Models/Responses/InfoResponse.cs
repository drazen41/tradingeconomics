using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TE1.Models.Responses
{
    public class InfoResponse
    {
        public int Hits { get; set; }
        public int Page { get; set; }
        public FacetsResponse Facets { get; set; }
    }
}