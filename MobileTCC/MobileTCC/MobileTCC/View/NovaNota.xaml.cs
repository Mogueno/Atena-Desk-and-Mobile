using MobileTCC.Helpers;
using MobileTCC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileTCC.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NovaNota : ContentPage
	{
		public NovaNota ()
		{
			InitializeComponent ();
            this.BindingContext = this;
            this.IsBusy = false;
        }

        private async void BtExcluir_Clicked(object sender, EventArgs e)
        {
            var resp = await DisplayAlert("Excluir", "Deseja realmente excluir?", "Sim", "Não");
            if (resp == true)
            {
                await DisplayAlert("Resultado da operação ", "Deletado" , "OK");
            }
        }

        private  void BtSalvar_Clicked_1(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
    }
}