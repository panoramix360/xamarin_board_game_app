using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using DomainModel.Entities;
using Xamarin.Forms;

namespace App.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public BoardGame BoardGame { get; set; }
        public BoardGame BoardGameDetail { get; set; }

        public Command LoadBoardGameCommand { get; set; }

        public ItemDetailViewModel(BoardGame boardGame = null)
        {
            Title = boardGame?.Name;
            BoardGame = boardGame;

            LoadBoardGameCommand = new Command(async () => await ExecuteLoadBoardGameCommand());
        }

        async Task ExecuteLoadBoardGameCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var boardGame = await App.Service.GetBoardGameById(BoardGame.GameId);
                BoardGameDetail.Description = boardGame.Description;
                BoardGameDetail.YearPublished = boardGame.YearPublished;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
