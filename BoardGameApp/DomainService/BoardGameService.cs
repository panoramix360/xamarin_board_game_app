using DomainModel.Entities;
using DomainModel.EntitiesDTO;
using DomainModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
            List<BoardGameDTO> boardGamesDTO = (List<BoardGameDTO>) await _api.GetAllByUser(user);
            List<BoardGame> games = new List<BoardGame>();

            boardGamesDTO.ForEach(b =>
            {
                BoardGame boardGame = new BoardGame(b.gameId, b.name, b.image,
                    b.minPlayers, b.maxPlayers, b.playingTime, b.isExpansion, b.averageRating, b.rank, b.numPlays, b.owned);

                games.Add(boardGame);
            });

            _repository.RemoveAll();
            _repository.SaveAll(games);
            return games;
        }

        public IEnumerable<BoardGame> GetBoardGamesDatabase()
        {
            return _repository.GetAll();
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
