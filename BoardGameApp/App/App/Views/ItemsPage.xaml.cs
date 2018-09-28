using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

using App.Models;
using App.Views;
using App.ViewModels;
using DomainModel.Entities;

namespace App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel(new FilterSelection());
        }

        public ItemsPage(FilterSelection filterSelection)
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel(filterSelection);
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var boardGameItem = args.SelectedItem as BoardGame;
            if (boardGameItem == null)
                return;

            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                var boardGame = await App.Service.GetBoardGameById(boardGameItem.GameId);
                await Navigation.PushAsync(new ItemDetailPage(boardGame));
            }
            else
            {
                DisplayAlert("Alerta", "Favor conectar a internet para ter acesso a essa funcionalidade", "Cancelar");
            }

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}