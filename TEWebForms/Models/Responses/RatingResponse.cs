using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TEWebForms.Models.Responses
{
    public class RatingResponse
    {
        public string Country { get; set; }
        public double? TE { get; set; }
        public DateTime Date { get; set; }
        public string Agency { get; set; }
        public string Rating { get; set; }
        public string Outlook { get; set; }
        public string TE_Outlook { get; set; }
        public string SP { get; set; }
        public string SP_Outlook { get; set; }
        public string Moodys { get; set; }
        public string Moodys_Outlook { get; set; }
        public string Fitch { get; set; }
        public string Fitch_outlook { get; set; }

    }
}