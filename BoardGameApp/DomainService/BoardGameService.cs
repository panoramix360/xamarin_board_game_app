using DomainModel.Entities;
using DomainModel.EntitiesDTO;
using DomainModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DomainService
{
    public class BoardGameService
    {
        private IBoardGameRepository _repository;
        private IBoardGameAPI _api;

        public BoardGameService(IBoardGameRepository repository, IBoardGameAPI api)
        {
            _repository = repository;
            _api = api;
        }

        public async Task<IEnumerable<BoardGame>> GetAllByUser(User user)
        {
            IEnumerable<BoardGameDTO> boardGamesDTO = await _api.GetAllByUser(user);
            return new List<BoardGame>();
        }

        public IEnumerable<BoardGame> GetAll()
        {
            return _repository.GetAll();
        }

        public BoardGame Get(Guid id)
        {
            return _repository.Get(id);
        }
    }
}
