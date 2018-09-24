using DomainModel.Entities;
using DomainModel.Interfaces;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services
{
    public class BoardGameRestApi : IBoardGameAPI
    {
        private string _baseUrl = "https://bgg-json.azurewebsites.net";
        private RestClient _restClient;

        public BoardGameRestApi()
        {
            _restClient = new RestClient(_baseUrl);
        }

        public IEnumerable<BoardGame> GetAllByUser(User user)
        {
            RestRequest request = new RestRequest("collection/{userName}");
            request.AddUrlSegment("userName", user.Name);

            IRestResponse response = _restClient.Execute(request);
            var content = response.Content;

            return new List<BoardGame>();
        }
    }
}
