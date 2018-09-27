using App.Models;
using DomainModel.Entities;
using DomainService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameApp
{
    public class BoardGameAppService
    {
        public ObservableCollection<BoardGame> BoardGames { get; set; }
        
        private BoardGameService _boardGameService;

        public BoardGameAppService(BoardGameService boardGameService)
        {
            _boardGameService = boardGameService;

            BoardGames = new ObservableCollection<BoardGame>();
        }

        public Task<IEnumerable<BoardGame>> GetAllBoardGamesByUser(User user)
        {
            return _boardGameService.GetAllByUser(user);
        }

        public IEnumerable<BoardGame> GetAllBoardGames()
        {
            return _boardGameService.GetAll();
        }
        
        public IEnumerable<BoardGame> GetAllBoardGamesOffline(FilterSelection filter)
        {
            return _boardGameService.GetBoardGamesDatabase(filter);
        }
    }
}
