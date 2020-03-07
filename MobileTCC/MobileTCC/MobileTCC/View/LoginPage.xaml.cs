﻿using MobileTCC.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MobileTCC.View;
using Xamarin.Auth;
using MobileTCC.Helpers;
using System.Diagnostics;
using Newtonsoft.Json;

namespace MobileTCC.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        Account account;
        AccountStore store;

        public LoginPage ()
		{
            SetValue(NavigationPage.HasNavigationBarProperty, false);
            InitializeComponent();
            store = AccountStore.Create();
        }

        async void BtnRegister_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrationPage());
        }

        void BtnLogin_Clicked(object sender, EventArgs e)
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
            var db = new SQLiteConnection(dbpath);

            var myquery = db.Table<RegUserTable>().Where(u=>u.UserName.Equals(txbUserName.Text) && u.Password.Equals(txbPassword.Text)).FirstOrDefault();

            if(myquery != null)
            {
                App.Current.MainPage = new NavigationPage(new MainPageApp());
            }
            else
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var result = await this.DisplayAlert("Erro", "Usuario nao encontrado, tente novamente", "Yes", "Cancel");

                    if (result)
                        await Navigation.PushAsync(new LoginPage());
                    else
                    {
                        await Navigation.PushAsync(new LoginPage());
                    }

                });
            }

        }

        private void BtnGoogle_Clicked(object sender, EventArgs e)
        {
            string clientId = null;
            string redirectUri = null;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    clientId = Constants.iOSClientId;
                    redirectUri = Constants.iOSRedirectUrl;
                    break;

                case Device.Android:
                    clientId = Constants.AndroidClientId;
                    redirectUri = Constants.AndroidRedirectUrl;
                    break;
            }

            account = store.FindAccountsForService(Constants.AppName).FirstOrDefault();

            var authenticator = new OAuth2Authenticator(
                clientId,
                null,
                Constants.Scope,
                new Uri(Constants.AuthorizeUrl),
                new Uri(redirectUri),
                new Uri(Constants.AccessTokenUrl),
                null,
                true);

            authenticator.Completed += OnAuthCompleted;
            authenticator.Error += OnAuthError;

            AuthenticationState.Authenticator = authenticator;

            var presenter = new Xamarin.Auth.Presenters.OAuthLoginPresenter();
            presenter.Login(authenticator);
        }

        async void OnAuthCompleted(object sender, AuthenticatorCompletedEventArgs e)
        {
            var authenticator = sender as OAuth2Authenticator;
            if (authenticator != null)
            {
                authenticator.Completed -= OnAuthCompleted;
                authenticator.Error -= OnAuthError;
            }

            User userdata = null;
            if (e.IsAuthenticated)
            {
                // If the user is authenticated, request their basic user data from Google
                // UserInfoUrl = https://www.googleapis.com/oauth2/v2/userinfo
                var request = new OAuth2Request("GET", new Uri(Constants.UserInfoUrl), null, e.Account);
                var response = await request.GetResponseAsync();
                if (response != null)
                {
                    // Deserialize the data and store it in the account store
                    // The users email address will be used to identify data in SimpleDB
                    string userJson = await response.GetResponseTextAsync();
                    userdata = JsonConvert.DeserializeObject<User>(userJson);
                }

                if (account != null)
                {
                    store.Delete(account, Constants.AppName);
                }

                await store.SaveAsync(account = e.Account, Constants.AppName);

                
                var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
                var db = new SQLiteConnection(dbpath);

                db.CreateTable<RegUserTable>();

                var item = new RegUserTable()
                {
                    Email = userdata.Email,
                    gImage = userdata.Picture
                };

                db.Insert(item);
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var result = await this.DisplayAlert("Sucesso", "Cadastro Feito com Sucesso", "Yes", "Cancel");
                    if (result)
                        App.Current.MainPage = new NavigationPage(new MainPageApp());
                });
                

            }
        }

        void OnAuthError(object sender, AuthenticatorErrorEventArgs e)
        {
            var authenticator = sender as OAuth2Authenticator;
            if (authenticator != null)
            {
                authenticator.Completed -= OnAuthCompleted;
                authenticator.Error -= OnAuthError;
            }

            Debug.WriteLine("Authentication error: " + e.Message);
        }
    }
}