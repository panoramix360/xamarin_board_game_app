using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Interfaces
{
    public interface IBoardGameAPI
    {
        Task<IEnumerable<BoardGame>> GetAllByUser(User user);
    }
}
