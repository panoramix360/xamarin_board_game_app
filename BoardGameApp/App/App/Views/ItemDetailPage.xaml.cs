using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using App.Models;
using App.ViewModels;

namespace App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                viewModel.LoadBoardGameCommand.Execute(null);
            } else
            {
                DisplayAlert("Alerta", "Favor conectar a internet para ter acesso a essa funcionalidade", "Cancelar");
            }
        }
    }
}