using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using App.Models;
using App.Views;
using DomainModel.Entities;
using System.Collections.Generic;

namespace App.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<BoardGame> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        private FilterSelection _filterSelection;

        public ItemsViewModel(FilterSelection filterSelection)
        {
            Title = "Jogos filtrados";
            _filterSelection = filterSelection;
            Items = new ObservableCollection<BoardGame>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = App.Service.GetAllBoardGamesOffline(_filterSelection);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
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