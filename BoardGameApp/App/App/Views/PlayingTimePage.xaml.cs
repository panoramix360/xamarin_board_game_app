using App.Models;
using DomainModel.Entities.Enums;
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
	public partial class PlayingTimePage : ContentPage
	{

        private FilterSelection _filterSelection;

		public PlayingTimePage (FilterSelection filterSelection)
		{
			InitializeComponent ();
            _filterSelection = filterSelection;

        }

        public async void OnNextPageClick(object sender, EventArgs e)
        {
            switch(playingTime.SelectedIndex)
            {
                case 0:
                    _filterSelection.PlayingTime = PlayingTimeEnum.ThirtyMinutes;
                    break;
                case 1:
                    _filterSelection.PlayingTime = PlayingTimeEnum.OneHour;
                    break;
                case 2:
                    _filterSelection.PlayingTime = PlayingTimeEnum.TwoHours;
                    break;
                case 3:
                    _filterSelection.PlayingTime = PlayingTimeEnum.MoreThanTwoHours;
                    break;
            }
            await Navigation.PushAsync(new ItemsPage(_filterSelection));
        }
    }
}