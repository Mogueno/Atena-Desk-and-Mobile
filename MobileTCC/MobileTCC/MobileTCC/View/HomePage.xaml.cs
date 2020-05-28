using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MobileTCC.Helpers;
using MobileTCC.Model;
using MobileTCC.Controller;
using Xamarin.Essentials;
using System.Collections;
using System.Collections.ObjectModel;

namespace MobileTCC.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
		public HomePage ()
		{
			InitializeComponent ();
            this.BindingContext = this;
            ListaNotas.ItemsSource = new ObservableCollection<RootObject>();

        }

        public async void ListaItems()
        {
            NotaController notaController = new NotaController();
            // Pega as notas com o userID
            RootObject result = await notaController.GetAllNotas(Preferences.Get("userID", 99999));
            ListaNotas.ItemsSource = result.reqSendData.ToList();
        }
        private void ListaNotas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

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
            ListaItems();
        }
    }
}