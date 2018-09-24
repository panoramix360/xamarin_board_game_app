using DomainModel.Entities;
using DomainModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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

        public IEnumerable<BoardGame> GetAllByUser(User user)
        {
            return _api.GetAllByUser(user);
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
