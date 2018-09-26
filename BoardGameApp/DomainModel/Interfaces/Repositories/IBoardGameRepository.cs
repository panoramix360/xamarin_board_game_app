using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Interfaces
{
    public interface IBoardGameRepository
    {
        IEnumerable<BoardGame> GetAll();
        BoardGame Get(Guid id);
        void SaveAll(IEnumerable<BoardGame> games);
        void RemoveAll();
    }
}
