using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CSharpExamples;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TE1.Models.Responses;
using System.Net;
using System.Threading;
using System.Web.Script.Serialization;

namespace TE1.Services
{
    public class ApiService
    {
        private static string _clientKey = "rflo8xtosclgl3i:e46covymlcpjx2z";
        
        public async static Task<IEnumerable<RatingResponse>> GetRatingsByCountry(string country)
        {
            IEnumerable<RatingResponse> rr = null;
            string data = await Ratings.GetRatingsByCountry(country);
            JavaScriptSerializer jss = new JavaScriptSerializer();
            rr = jss.Deserialize<IList<RatingResponse>>(data);
            return rr;
            
        }
        public async static Task<IEnumerable<RatingResponse>> GetRatingsByCountries(string[] countries)
        {
            IEnumerable<RatingResponse> rr = null;
            string data = await Ratings.GetRatingsByCountries(countries);
            JavaScriptSerializer jss = new JavaScriptSerializer();
            rr = jss.Deserialize<IList<RatingResponse>>(data);
            return rr;

        }
        public async static Task<IEnumerable<RatingResponse>> GetHistoricalRatings(string[] countries)
        {
            IEnumerable<RatingResponse> rr = null;
            //string data = await Ratings.GetHistoricalRatings(countries);
            string data = await HttpRequester($"/ratings/{string.Join(",", countries)}");
            JavaScriptSerializer jss = new JavaScriptSerializer();
            rr = jss.Deserialize<IList<RatingResponse>>(data);
            return rr;

        }
        //https://brains.tradingeconomics.com/v2/search/wb,fred,comtrade?q=nigeria&pp=50&p=0&_=1557934352427&stance=2
        public async static Task<string> BrainsData(string query, string baseURL= "https://brains.tradingeconomics.com/")
        {
            string url = "v2/search/wb,fred,comtrade?q=";
            var q = string.IsNullOrEmpty(query) ? "nigeria&pp=50&p=0&_=1557934352427&stance=2" : query;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseURL);
                    client.DefaultRequestHeaders.Clear();

                    //ADD Acept Header to tell the server what data type you want
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                    HttpResponseMessage response = await client.GetAsync(url + q);

                    response.EnsureSuccessStatusCode();

                    return await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception e)
            {
                return $"Error at HttpRequester with msg: {e}";
            }
        }
        public async static Task<string> HttpRequester(string url, string baseURL = "https://api.tradingeconomics.com/")
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseURL);
                    client.DefaultRequestHeaders.Clear();

                    //ADD Acept Header to tell the server what data type you want
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //ADD Authorization
                    AuthenticationHeaderValue auth = new AuthenticationHeaderValue("Client", _clientKey);
                    client.DefaultRequestHeaders.Authorization = auth;

                    HttpResponseMessage response = await client.GetAsync(url);

                    response.EnsureSuccessStatusCode();

                    return await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception e)
            {
                return $"Error at HttpRequester with msg: {e}";
            }
        }
    }
   
}

