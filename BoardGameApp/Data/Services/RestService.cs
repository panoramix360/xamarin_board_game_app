using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Data.Services
{
    public class RestService
    {
        private HttpClient _httpClient;
        private string _baseUrl = "https://bgg-json.azurewebsites.net/";

        public RestService()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string> GetRequest(string url)
        {
            var response = await _httpClient.GetAsync(_baseUrl + url);

            if(response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return "";
        }
    }
}
