﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TEWebForms.Models.Responses
{
    public class FacetsResponse
    {
        public List<CountryResponse> Country { get; set; }
        public List<UnitResponse> Unit { get; set; }
        public List<CurrencyResponse> Currency { get; set; }
    }
}