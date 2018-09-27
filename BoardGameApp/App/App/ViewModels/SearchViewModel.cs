using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using App.Models;
using App.Views;

namespace App.ViewModels
{
    public class SearchViewModel : BaseViewModel
    {
        string searchText = "NotFromEarthMe";
        public string SearchText
        {
            get { return searchText; }
            set { SetProperty(ref searchText, value); }
        }

        public SearchViewModel()
        {
            Title = "Board Game Matcher";
        }
    }
}