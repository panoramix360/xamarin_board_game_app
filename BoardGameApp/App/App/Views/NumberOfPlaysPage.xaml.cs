using App.Models;
using DomainModel.Entities.Enums;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NumberOfPlaysPage : ContentPage
	{
        private FilterSelection _filterSelection;

		public NumberOfPlaysPage(FilterSelection filterSelection)
		{
			InitializeComponent();

            _filterSelection = filterSelection;

        }

        public async void OnFinishClick(object sender, EventArgs e)
        {
            if(numberOfPlays.SelectedIndex != -1)
            {
                switch (numberOfPlays.SelectedIndex)
                {
                    case 0:
                        _filterSelection.NumberOfPlays = NumberOfPlaysEnum.LessPlayed;
                        break;
                    case 1:
                        _filterSelection.NumberOfPlays = NumberOfPlaysEnum.MorePlayed;
                        break;
                }
                await Navigation.PushAsync(new ItemsPage(_filterSelection));
            } else
            {
                await DisplayAlert("Alerta", "Informe por o que deseja ordenar", "Cancelar");
            }
        }
    }
}