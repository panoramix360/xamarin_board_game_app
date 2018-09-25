using DomainModel.Entities;
using DomainModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
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

        public async Task<IEnumerable<BoardGame>> GetAllByUser(User user)
        {
            string strJson = await _restService.GetRequest(_collectionUrl + user.Name);

            IEnumerable<BoardGame> boardGames = null;

            try
            {
                boardGames = Newtonsoft.Json.JsonConvert
                .DeserializeObject<IEnumerable<BoardGame>>(strJson);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            
            return boardGames;
        }
    }
}
