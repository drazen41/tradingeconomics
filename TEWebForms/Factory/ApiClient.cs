using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TEWebForms.Models.Responses;

namespace TEWebForms.Factory
{
    public partial class ApiClient
    {
        private readonly HttpClient httpClient;
        private Uri BaseEndPoint { get; set; }
        private string _clientKey = "rflo8xtosclgl3i:e46covymlcpjx2z";
        public ApiClient(Uri baseEndPoint)
        {
            if (baseEndPoint == null)
                throw new ArgumentNullException("baseEndPoint");
            BaseEndPoint = baseEndPoint;
            httpClient = new HttpClient();
        }
        public async Task<T> GetTAsync<T>(Uri requestUrl)
        {
            addHeaders();
            
            var response = await httpClient.GetAsync(requestUrl);
             
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            var parsed = JToken.Parse(data);
            var a = parsed.ToObject<T>();
            //JavaScriptSerializer jss = new JavaScriptSerializer();
            //return jss.Deserialize<T>(data);

            return  JsonConvert.DeserializeObject<T>(data);
            
        }
        public Uri CreateRequestUri(string relPath, string queryString="")
        {
            var endPoint = new Uri(BaseEndPoint, relPath);
            var uriBuilder = new UriBuilder(endPoint);
            uriBuilder.Query = queryString;
            return uriBuilder.Uri;
        }
        private void addHeaders()
        {
            //ADD Acept Header to tell the server what data type you want
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //ADD Authorization
            AuthenticationHeaderValue auth = new AuthenticationHeaderValue("Client", _clientKey);
            httpClient.DefaultRequestHeaders.Authorization = auth;
        }

    }
}
