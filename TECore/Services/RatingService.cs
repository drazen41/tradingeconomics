using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TECore.Factory;
using TECore.Models.Responses;

namespace TECore.Services
{
    public class RatingService
    {
        private ApiClient ApiClient;
        public RatingService()
        {
            ApiClient = ApiClientFactory.Instance;
        }
        public async Task<List<RatingResponse>> GetRatings()
        {
            var requestUrl = ApiClient.CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "ratings"));
            return await ApiClient.GetTAsync<List<RatingResponse>>(requestUrl);
        }

    }
}
