using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Interfaces
{
    public interface IBoardGameAPI
    {
        IEnumerable<BoardGame> GetAllByUser(User user);
    }
}
