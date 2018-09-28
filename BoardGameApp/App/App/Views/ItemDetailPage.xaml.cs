using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using App.Models;
using App.ViewModels;
using DomainModel.Entities;

namespace App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        public BoardGame BoardGame { get; set; }

        public ItemDetailPage(BoardGame boardGame)
        {
            InitializeComponent();

            Title = boardGame.Name;
            BoardGame = boardGame;

            image.Source = boardGame.ImageUrl;
            description.Text = boardGame.Description;
            yearPublished.Text = boardGame.YearPublished + "";
            numberOfPlayers.Text = boardGame.MinPlayers + "-" + boardGame.MaxPlayers + " jogadores";
            playtime.Text = boardGame.PlayingTime + " minutos";
        }

        public async void OnGoToBGG_Clicked(object sender, EventArgs e)
        {
            await Browser.OpenAsync(new Uri("https://boardgamegeek.com/boardgame/" + BoardGame.GameId), BrowserLaunchMode.SystemPreferred);
        }
    }
}