using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TEWebForms.Factory;
using TEWebForms.Models.Responses;

namespace TEWebForms.Services
{
    public class IndicatorService
    {
        private ApiClient ApiClient;
        public IndicatorService()
        {
            ApiClient = ApiClientFactory.Instance;
        }
        public async Task<List<IndicatorResponse>> GetIndicatorsAsync()
        {
            var requestUrl = ApiClient.CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "indicators"));
            return await ApiClient.GetTAsync<List<IndicatorResponse>>(requestUrl);
        }
        public List<IndicatorResponse> GetIndicators()
        {
            return GetIndicatorsAsync().Result;
        }
        public async Task<List<IndicatorResponse>> GetCountryIndicatorsAsync(string country)
        {
            var requestUrl = ApiClient.CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "country/all"));
            return await ApiClient.GetTAsync<List<IndicatorResponse>>(requestUrl);
        }
        public List<IndicatorResponse> GetCountryIndicator(string country)
        {
            return GetCountryIndicatorsAsync(country).Result;
        }
    }
}