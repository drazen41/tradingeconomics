using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TEWebForms.Models.Responses
{
    public class CalendarResponse
    {
        public DateTime Date { get; set; }
        public string Country { get; set; }
        public string Category { get; set; }
        public string Event { get; set; }
        public string Reference { get; set; }
        public string Source { get; set; }
        public string Actual { get; set; }
        public string Previous { get; set; }
        public string Forecast { get; set; }
        public string TEForecast { get; set; }
        public string URL { get; set; }
        public string DateSpan { get; set; }
        public string Importance { get; set; }
        public string LastUpdate { get; set; }
        public string Revised { get; set; }
        public string OCountry { get; set; }
        public string OCategory { get; set; }
        public string Ticker { get; set; }
        public string Symbol { get; set; }
        public string CalendarID { get; set; }

    }
}