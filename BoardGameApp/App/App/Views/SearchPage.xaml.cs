using App.ViewModels;
using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SearchPage : ContentPage
	{
        SearchViewModel viewModel;

        public SearchPage ()
		{
            InitializeComponent();

            BindingContext = viewModel = new SearchViewModel();
        }

        async void OnSearchButtonClicked(object sender, EventArgs e)
        {
            await App.Service.GetAllBoardGamesByUser(new User(viewModel.SearchText));
            await Navigation.PushAsync(new ItemsPage());
        }
    }
}