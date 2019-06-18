using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TEWebForms.Models.Responses
{
    public class IndicatorResponse
    {
        public string Country { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public DateTime? LatestValueDate { get; set; }
        public string LatestValue { get; set; }
        public string Source { get; set; }
        public string Unit { get; set; }
        public string URL { get; set; }
        public string CategoryGroup { get; set; }
        public string Adjustment { get; set; }
        public string Frequency { get; set; }
        public string HistoricalDataSymbol { get; set; }
        public DateTime? CreateDate { get; set; }
        public string PreviousValue { get; set; }
        public DateTime? PreviousValueDate { get; set; }
    }
}