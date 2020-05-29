using MobileTCC.Controller;
using MobileTCC.Helpers;
using MobileTCC.Model;
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
	public partial class NovaNota : ContentPage
	{
        public IList<TB_USER_DATA2> userData;
        public NovaNota ()
		{
			InitializeComponent ();
            this.BindingContext = this;
            this.IsBusy = false;
        }
        public NovaNota(string titulo, string conteudo, int matID, int notaID)
        {
            InitializeComponent();
            this.BindingContext = this;
            txtTitulo.Text = titulo;
            txtDados.Text = conteudo;
            lbMatId.Text = matID.ToString();
            lbNotaId.Text = notaID.ToString();
            btSalvar.Text = "Atualizar";
            btExcluir.IsVisible = true;
        }

        private async void BtExcluir_Clicked(object sender, EventArgs e)
        {
            var resp = await DisplayAlert("Excluir", "Deseja realmente excluir?", "Sim", "Não");
            if (resp == true)
            {
                await DisplayAlert("Resultado da operação ", "Deletado" , "OK");
            }
        }

        private async void BtSalvar_Clicked_1(object sender, EventArgs e)
        {
            if(btSalvar.Text == "Atualizar")
            {
                //update da nota no banco
                NotaController notaController = new NotaController();
                var retorno = await notaController.PatchNota(Preferences.Get("userID", 9999), Convert.ToInt16(lbNotaId.Text), txtTitulo.Text, txtDados.Text);
                if (retorno.patched)
                {
                    await DisplayAlert("Sucesso", "Nota atualizada com sucesso", "Ok");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Ocorreu um erro", "Por favor, tente mais tarde.", "Ok");
                }
            }
            else
            {
                //Insercao de nova nota
                NotaController notaController = new NotaController();
                UserController userController = new UserController();
                userData = await userController.GetUserData(Preferences.Get("userID", 9999));
                var operation = await notaController.AddNewNota(Preferences.Get("userID", 9999), userData[0].FAC_INT_ID, userData[0].CUR_INT_ID, userData[0].MAT_INT_ID, txtDados.Text, txtTitulo.Text);

                if (operation.inserted)
                {
                    await DisplayAlert("Sucesso", "Nota inserida com sucesso", "Ok");
                    await Navigation.PopToRootAsync();
                }
                else
                {
                    await DisplayAlert("Ocorreu um erro", "Por favor, tente mais tarde.", "Ok");
                }
            }
        }
    }
}