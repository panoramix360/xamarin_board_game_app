using DomainModel.Entities;
using DomainModel.EntitiesDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainModel.Interfaces
{
    public interface IBoardGameAPI
    {
        Task<IEnumerable<BoardGameDTO>> GetAllByUser(User user);
        Task<BoardGameDetailDTO> GetBoardGameById(int gameId);
    }
}
