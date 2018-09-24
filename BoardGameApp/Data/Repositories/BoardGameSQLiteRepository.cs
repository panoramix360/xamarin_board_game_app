using DomainModel.Entities;
using DomainModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public class BoardGameSQLiteRepository : IBoardGameRepository
    {
        public BoardGame Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BoardGame> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
