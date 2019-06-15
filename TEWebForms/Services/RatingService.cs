﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TEWebForms.Factory;
using TEWebForms.Models.Responses;

namespace TEWebForms.Services
{
    public class RatingService
    {
        private ApiClient ApiClient;
        public RatingService()
        {
            ApiClient = ApiClientFactory.Instance;
        }
        public async Task<List<RatingResponse>> GetRatingsAsync()
        {
            var requestUrl = ApiClient.CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "ratings"));
            return await ApiClient.GetTAsync<List<RatingResponse>>(requestUrl);
        }
        public List<RatingResponse> GetRatings()
        {
            return GetRatingsAsync().Result;
        }
    }
}
