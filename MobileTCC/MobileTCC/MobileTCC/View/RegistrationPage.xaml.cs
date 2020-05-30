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
using static MobileTCC.Model.TableUsuario;
using MobileTCC.Helpers;
using MobileTCC.Controller;
using Xamarin.Essentials;

namespace MobileTCC.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegistrationPage : ContentPage
    {
		public RegistrationPage ()
		{
            InitializeComponent ();
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#0083c9");

        }


        private void Button_Clicked(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                string userName ="" ;
                string userPassword = "";
                string userSexo = "";
                string userEmail = "";
                int userIdade= 0 ;

                if (!String.IsNullOrEmpty(EntryUserName.Text) && !String.IsNullOrEmpty(EntryUserPassword.Text) && !String.IsNullOrEmpty(EntryUserEmail.Text) && !String.IsNullOrEmpty(EntryUserSexo.Text) && !String.IsNullOrEmpty(EntryUserIdade.Text))
                {
                    userName = EntryUserName.Text.ToString();

                    userPassword = EntryUserPassword.Text.ToString();

                    userEmail = EntryUserEmail.Text.ToString();

                    userSexo = EntryUserSexo.Text.ToString();

                    userIdade = Convert.ToInt32(EntryUserIdade.Text);

                    TB_USERReturn query = await UserController.AddNewUser(userName, userIdade, userSexo, userEmail, userPassword, 0, 0);
                    if (query.newUser == false)
                    {
                        await this.DisplayAlert("Erro", "Email já encontrado!", "Ok");
                    }
                    else
                    {
                        Preferences.Set("userID", query.USER_INT_ID);
                        await this.DisplayAlert("Sucesso", "Cadastro Feito com Sucesso, agora vamos cadastrar suas materias!", "Ok");
                        await Navigation.PushAsync(new RegistrationPageNext());
                    }
                    
                }
                else
                {
                    await DisplayAlert("Erro", "Por favor, complete todos os campos","Ok");
                }
            });
        }
    }
}