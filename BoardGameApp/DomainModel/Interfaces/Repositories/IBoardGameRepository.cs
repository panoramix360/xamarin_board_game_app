using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Interfaces
{
    public interface IBoardGameRepository
    {
        IEnumerable<BoardGame> GetAll();
        BoardGame Get(Guid id);
    }
}
