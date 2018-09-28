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
        public ItemDetailViewModel(BoardGame boardGame)
        {
            Title = boardGame.Name;
        }
    }
}
