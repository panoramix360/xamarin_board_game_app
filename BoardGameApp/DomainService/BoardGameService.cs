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

        public BoardGameService(IBoardGameRepository repository)
        {
            _repository = repository;
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
