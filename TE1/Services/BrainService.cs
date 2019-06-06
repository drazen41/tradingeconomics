using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TE1.Models.Responses;

namespace TE1.Services
{
    public class BrainService
    {
        public BrainsResponse GetBrainsResponse(string query)
        {
            return  ApiService.GetBrainsResponse(query).Result;
        }
        public IEnumerable<HitsResponse> GetHitsResponse(string query)
        {
            return ApiService.GetBrainsResponse(query).Result.Hits;
        }
    }
}