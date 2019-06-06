using CSharpExamples;
using System.Collections;
using TE1.Models.Responses;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace TE1.Services
{
    public class RatingService
    {
        public RatingResponse GetRatingForCountry(string country)
        {
            List<RatingResponse> lista = ApiService.GetRatingsByCountry(country).Result.ToList();
            return lista.First();
        }
        public IEnumerable<RatingResponse> GetRatingForCountries(string[] countries)
        {
            List<RatingResponse> lista = ApiService.GetRatingsByCountries(countries).Result.ToList();
            return lista;
        }
        public IEnumerable<RatingResponse> GetHistoricalRatings(string[] countries)
        {
            IEnumerable<RatingResponse> lista = ApiService.GetHistoricalRatings(countries).Result;
            return lista;
        }
    }
}