using MobileTCC.Controller;
using MobileTCC.Helpers;
using MobileTCC.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileTCC.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Configuracoes : ContentPage
	{
        private IList<TB_USER_DATA2> usuario;

        public Configuracoes()
        {
            InitializeComponent();
        }

        public async void GetUserData()
        {
            UserController usuarioController = new UserController();
            usuario = await usuarioController.GetUserData(Preferences.Get("userID", 0));
         

            EntryUserName.Text = usuario[0].USER_STR_NOME;
            EntryUserPassword.Text = usuario[0].USER_STR_SENHA;
            EntryUserEmail.Text = usuario[0].USER_STR_EMAIL;
            EntryUserSexo.Text = usuario[0].USER_STR_SEXO;
            EntryUserIdade.Text = usuario[0].USER_INT_IDADE.ToString();

           
        }

        protected override void OnAppearing()
        {
            GetUserData();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            UserController userController = new UserController();
            if (!String.IsNullOrEmpty(EntryUserName.Text) && !String.IsNullOrEmpty(EntryUserPassword.Text) && !String.IsNullOrEmpty(EntryUserEmail.Text) && !String.IsNullOrEmpty(EntryUserSexo.Text) && !String.IsNullOrEmpty(EntryUserIdade.Text))
            {
                var result = await userController.PatchUser(Preferences.Get("userID", 9999), EntryUserName.Text,
           Convert.ToInt32(EntryUserIdade.Text), EntryUserSexo.Text, EntryUserEmail.Text, EntryUserPassword.Text, 0, 0);

                if (result == null)
                {
                    await DisplayAlert("Sucesso", "Dados atualizados com sucesso", "Ok");
                }
                else
                {
                    await DisplayAlert("Erro", "Erro na atualizacao dos dados, tente novamente mais tarde.", "Ok");
                }
            }
            else
            {
                await DisplayAlert("Erro", "Por favor verifique os campos antes de enviar", "Ok");

            }

        }
    }

}