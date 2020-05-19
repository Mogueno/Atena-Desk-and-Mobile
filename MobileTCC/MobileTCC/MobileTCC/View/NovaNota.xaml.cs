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
		}
        public NovaNota(TableNotas nota)
        {
            InitializeComponent();
            this.BindingContext = this;
            txtCodigo.IsVisible = true;

            txtCodigo.Text = nota.Id.ToString();

            btSalvar.Text = "Alterar";
            btExcluir.IsVisible = true;
            txtTitulo.Text = nota.Titulo;
            txtDados.Text = nota.Dados;
            this.IsBusy = false;

        }


        private async void BtExcluir_Clicked(object sender, EventArgs e)
        {
            ServiceDBNotas dbNotas = new ServiceDBNotas(Application.Caminho);
            var resp = await DisplayAlert("Excluir", "Deseja realmente excluir?", "Sim", "Não");
            if (resp == true)
            {
                int id = Convert.ToInt32(txtCodigo.Text);
                dbNotas.ExcluirNota(id);
                await DisplayAlert("Resultado da operação ", dbNotas.Mensagem, "OK");
            }
        }

        private async void BtSalvar_Clicked_1(object sender, EventArgs e)
        {
            this.IsBusy = true;
            var masterPage = this.Parent as TabbedPage;

            try
            {
                TableNotas nota = new TableNotas();
                nota.Titulo = txtTitulo.Text;
                nota.Dados = txtDados.Text;
                ServiceDBNotas dbNotas = new ServiceDBNotas(Application.Caminho);
                if (btSalvar.Text == "Inserir")
                {
                    dbNotas.InserirNota(nota);
                    this.IsBusy = false;
                    //DisplayAlert("Resultado da operação ", dbNotas.Mensagem, "OK");
                    // Levar o usuario para a primeira aba (home)

                }
               else
                { //Alterar
                    nota.Id = Convert.ToInt32(txtCodigo.Text);
                    dbNotas.AlterarNota(nota);
                    this.IsBusy = false;
                    DisplayAlert("Resultado da operação ", dbNotas.Mensagem, "OK");
                }
            }
            catch (Exception ex)
            {
                this.IsBusy = false;
                DisplayAlert("Erro ", ex.Message, "OK");
            }
        }
    }
}