using System;
using System.Net.Http;
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
        }

        public async Task<string> GetRequest(string url)
        {
            var response = await _httpClient.GetAsync(new Uri(_baseUrl + url));

            if(response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return "";
        }
    }
}
