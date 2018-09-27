using App.Models;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayerNumberPage : ContentPage
    {
        public PlayerNumberPage()
        {
            InitializeComponent();
        }

        public async void OnNextPageClick(object sender, EventArgs e)
        {
            if(numberOfPlayer.Text != null)
            {
                FilterSelection filterSelection = new FilterSelection();
                filterSelection.NumberOfPlayers = int.Parse(numberOfPlayer.Text);
                await Navigation.PushAsync(new PlayingTimePage(filterSelection));
            } else
            {
                await DisplayAlert("Alerta", "Informe o número de jogadores", "Cancelar");
            }
        }
    }
}