using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App.Views;
using BoardGameApp;
using DomainService;
using Data.Services;
using Data.Repositories;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace App
{
    public partial class App : Application
    {

        public static BoardGameAppService Service { get; set; }

        public App()
        {
            InitializeComponent();

            Service = new BoardGameAppService(new BoardGameService(new BoardGameSQLiteRepository(), new BoardGameRestApi()));
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
