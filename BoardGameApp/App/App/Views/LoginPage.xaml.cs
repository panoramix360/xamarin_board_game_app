﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
		}

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ItemsPage());
            
            //var user = new User
            //{
            //    Username = usernameEntry.Text,
            //    Password = passwordEntry.Text
            //};

            //var isValid = AreCredentialsCorrect(user);
            //if (isValid)
            //{
            //    App.IsUserLoggedIn = true;
            //    Navigation.InsertPageBefore(new MainPage(), this);
            //    await Navigation.PopAsync();
            //}
            //else
            //{
            //    messageLabel.Text = "Login failed";
            //    passwordEntry.Text = string.Empty;
            //}
        }
    }
}