using MobileTCC.Model;
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
using System.Data;
using System.Net.NetworkInformation;
using System.ServiceModel;
using static MobileTCC.Model.TableUsuario;
using Xamarin.Essentials;
using MobileTCC.Controller;

namespace MobileTCC.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        Account account;
        AccountStore store;
        UserController userController = new UserController();
        FaculdadeController faculdadeController = new FaculdadeController();

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

-        {
            var db = new SQLiteConnection(App.Caminho);
            db.CreateTable<TableUsuario>();

            var myquery = db.Table<TableUsuario>().Where(u=>u.Login.Equals(txbUserName.Text) && u.Senha.Equals(txbPassword.Text)).FirstOrDefault();

            if(myquery != null)
            {
                Preferences.Set("userId", myquery.Id.ToString());

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

                // Utilizar o mesmo arquivo de banco para essa operacao (app)
                var db = new SQLiteConnection(App.Caminho);

                db.CreateTable<TableUsuario>();

                var item = new TableUsuario()
                {
                    Email = userdata.Email,
                    Login = userdata.Name,
                    GImage = userdata.Picture,
                    Senha = "1234",
                    Sexo = userdata.Gender,
                    GLogin = true,
                };

                db.Insert(item);
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var result = await this.DisplayAlert("Sucesso", "Cadastro Feito com Sucesso. Altere sua senha registrada dentro de configurações.", "Yes", "Cancel");
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
            Device.BeginInvokeOnMainThread(async () =>
            {
                await this.DisplayAlert("Erro ao fazer login", "Por favor tente novamente mais tarde" , "Ok");
            });

        }

        private async void BtnTeste_Clicked(object sender, EventArgs e)
        {
            //GET ALL USERS
            //IEnumerable<TB_USER> result = await userController.GetAllUsers();

            //POST A NEW USER
            //var result = await userController.AddNewUser("testexamarin", 10, "xamarin", "emailxamarin@xamarin.com", "senhaxamarin", "0", "1");

            //PATCH A CURRENT USER
            //var result = await userController.PatchUser( 26 ,"patchxamarain", 10, "patch", "patch@xamarin.com", "patchxamarin", "0", "1");

            //DELETE A USER
            //var result = await userController.DeleteUser( 26 );

            //GET ALL FACULDADES
            //var result = await faculdadeController.GetAllFaculdades();
        }
    }
}