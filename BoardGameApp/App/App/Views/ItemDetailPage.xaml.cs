using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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

            viewModel.LoadBoardGameCommand.Execute(null);
            BindingContext = viewModel;
        }
    }
}