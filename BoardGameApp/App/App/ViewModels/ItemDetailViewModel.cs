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
        public int GameId { get; set; }

        public Command LoadBoardGameCommand { get; set; }

        public ItemDetailViewModel(BoardGame boardGame = null)
        {
            Title = boardGame?.Name;
            GameId = boardGame.GameId;
            LoadBoardGameCommand = new Command(async () => await ExecuteLoadBoardGameCommand());
        }

        async Task ExecuteLoadBoardGameCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                BoardGame = await App.Service.GetBoardGameById(GameId);
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
