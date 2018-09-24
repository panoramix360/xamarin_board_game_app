using DomainModel.Entities;
using DomainService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

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

        public IEnumerable<BoardGame> GetAllBoardGames()
        {
            return _boardGameService.GetAll();
        }

    }
}
