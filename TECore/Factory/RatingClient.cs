using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TECore.Models.Responses;

namespace TECore.Factory
{
    public partial class ApiClient
    {
        public async Task<List<RatingResponse>> GetRatings()
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "ratings"));
            return await GetTAsync<List<RatingResponse>>(requestUrl);
        }
    }
}
