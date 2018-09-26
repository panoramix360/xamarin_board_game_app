using DomainModel.Entities;
using DomainModel.EntitiesDTO;
using DomainModel.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Services
{
    public class BoardGameRestApi : IBoardGameAPI
    {
        private RestService _restService;
        private string _collectionUrl = "collection/";

        public BoardGameRestApi()
        {
            _restService = new RestService();
        }

        public async Task<IEnumerable<BoardGameDTO>> GetAllByUser(User user)
        {
            string strJson = await _restService.GetRequest(_collectionUrl + user.Name);

            var boardGamesDTO = JsonConvert.DeserializeObject<List<BoardGameDTO>>(strJson);

            return boardGamesDTO;
        }
    }
}
