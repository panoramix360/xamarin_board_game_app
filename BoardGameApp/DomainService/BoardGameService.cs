using App.Models;
using DomainModel.Entities;
using DomainModel.Entities.Enums;
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
                BoardGame boardGame = new BoardGame(b.gameId, b.name, b.image, b.thumbnail,
                    b.minPlayers, b.maxPlayers, b.playingTime, b.isExpansion, b.averageRating, b.rank, b.numPlays, b.owned);

                games.Add(boardGame);
            });

            _repository.RemoveAll();
            _repository.SaveAll(games);
            return games;
        }

        private int GetTimeInMinutes(PlayingTimeEnum playingTimeEnum)
        {
            switch (playingTimeEnum)
            {
                case PlayingTimeEnum.ThirtyMinutes:
                    return 30;
                    break;
                case PlayingTimeEnum.OneHour:
                    return 60;
                    break;
                case PlayingTimeEnum.TwoHours:
                    return 120;
                    break;
                default:
                    return int.MaxValue;
                    break;
            }
        }

        public IEnumerable<BoardGame> GetBoardGamesDatabase(FilterSelection filter)
        {
            int maxPlayingTime = GetTimeInMinutes(filter.PlayingTime);
            bool orderMorePlayed = NumberOfPlaysEnum.MorePlayed.Equals(filter.NumberOfPlays);

            var data = _repository.GetAll()
                .Where(g => g.Owned
                    && (filter.NumberOfPlayers >= g.MinPlayers && filter.NumberOfPlayers <= g.MaxPlayers)
                    && g.PlayingTime <= maxPlayingTime);

            return orderMorePlayed
                ? data.OrderByDescending(g => g.NumPlays)
                : data.OrderBy(g => g.NumPlays);
        }

        public async Task<BoardGame> GetBoardGameById(int gameId)
        {
            BoardGameDetailDTO boardGameDetailDTO = await _api.GetBoardGameById(gameId);

            BoardGame boardGame = new BoardGame();
            boardGame.GameId = boardGameDetailDTO.gameId;
            boardGame.Name = boardGameDetailDTO.name;
            boardGame.Description = boardGameDetailDTO.description;
            boardGame.YearPublished = boardGameDetailDTO.yearPublished;
            boardGame.ImageUrl = boardGameDetailDTO.image;
            boardGame.MinPlayers = boardGameDetailDTO.minPlayers;
            boardGame.MaxPlayers = boardGameDetailDTO.maxPlayers;
            boardGame.PlayingTime = boardGameDetailDTO.playingTime;
            boardGame.IsExpansion = boardGameDetailDTO.isExpansion;
            boardGame.AverageRating = boardGameDetailDTO.averageRating;
            boardGame.Rank = boardGameDetailDTO.rank;

            return boardGame;
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
