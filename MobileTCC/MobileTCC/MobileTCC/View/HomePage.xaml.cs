using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MobileTCC.Helpers;
using MobileTCC.Model;

namespace MobileTCC.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
		public HomePage ()
		{
			InitializeComponent ();
            AtualizaLista();

        }

        public void AtualizaLista()
        {
            ServiceDBNotas dbNotas = new ServiceDBNotas(Application.Caminho);
            ListaNotas.ItemsSource = dbNotas.ListarNota();
        }

        private void ListaNotas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            TableNotas nota = (TableNotas)
            ListaNotas.SelectedItem;
            // chamada da pagina cadastrar
        }

        private async void BtnEditar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NovaNota());
        }

        private void BtnExcluir_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Excluir", "Voce reamente deseja Excluir?", "Sim", "Nao");

        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            AtualizaLista();
        }
    }
}