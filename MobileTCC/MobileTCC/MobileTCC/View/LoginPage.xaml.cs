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

        async void BtnLogin_Clicked(object sender, EventArgs e){

            //Busca se o usuario ja existe
            IList<TB_USERReturn> verificaLogin = await userController.GetExistentUser(txbUserName.Text, txbPassword.Text);
            if (verificaLogin.Count != 0)
            {
                //Join na req do getUserID pra trazer Fac, cur e mat
                Preferences.Set("userID", verificaLogin[0].USER_INT_ID);
                //Preferences.Set("facID", verificaLogin[0].USER_FAC_ID);
                //Preferences.Set("curID", verificaLogin[0].USER_CUR_ID);
                //Preferences.Set("matID1", verificaLogin[0].USER_MAT_ID);
                //Preferences.Set("matID2", verificaLogin[0].USER_MAT_ID);
                /*SELECT* FROM TB_USER
                JOIN TB_USER_FAC ON TB_USER.USER_INT_ID = TB_USER_FAC.USER_INT_ID

                JOIN TB_USER_CUR ON TB_USER.USER_INT_ID = TB_USER_CUR.USER_INT_ID

                JOIN TB_USER_MAT ON TB_USER.USER_INT_ID = TB_USER_MAT.USER_INT_ID
                WHERE TB_USER.USER_INT_ID =*/

                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Erro", "Usuario nao encontrado, tente novamente", "Ok");

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

                TB_USERReturn query = await UserController.AddNewUser(userdata.Name, 0, userdata.Gender, userdata.Email, "1234" ,0 ,1);

                if (query.newUser == false)
                {
                    Application.Current.MainPage = new NavigationPage(new MainPageApp());
                    await DisplayAlert("Erro", "Email já encontrado!", "Ok");
                }
                else
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await DisplayAlert("Sucesso", "Cadastro Feito com Sucesso. Confira seus dados na aba Configuracoes!", "Yes");
                        await Navigation.PopAsync();
                    });
                }
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