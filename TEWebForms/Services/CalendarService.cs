using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TEWebForms.Factory;
using TEWebForms.Models.Responses;

namespace TEWebForms.Services
{
    public class CalendarService
    {
        private ApiClient ApiClient;
        public CalendarService()
        {
            ApiClient = ApiClientFactory.Instance;
        }
        public async Task<List<CalendarResponse>> GetCalendarsAsync()
        {
            var requestUrl = ApiClient.CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "calendar"));
            return await ApiClient.GetTAsync<List<CalendarResponse>>(requestUrl);
        }
        public List<CalendarResponse> GetCalendars()
        {
            return GetCalendarsAsync().Result;
        }
    }
}