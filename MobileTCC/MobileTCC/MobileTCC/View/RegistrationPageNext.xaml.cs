using MobileTCC.Controller;
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
    public partial class RegistrationPageNext : ContentPage
    {
        public RegistrationPageNext()
        {
            InitializeComponent();
            PopulatePickers();
            this.BindingContext = this;
            IsBusy = false;
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#0083c9");
        }

        public async void PopulatePickers()
        {
            IsBusy = true;
            FaculdadeController faculdadeController = new FaculdadeController();
            var tableFac = await faculdadeController.GetAllFaculdades();
            List<string> faculdadeList = new List<string>();
            foreach (var item in tableFac)
            {
                faculdadeList.Add(item.FAC_STR_NOME);
            }
            FaculdadesList.ItemsSource = faculdadeList;

            var tableCur = await faculdadeController.GetAllCursos();
            List<string> cursoList = new List<string>();
            foreach (var item in tableCur)
            {
                cursoList.Add(item.CUR_STR_NOME);
            }
            CursosList.ItemsSource = cursoList;

            var tableMat = await faculdadeController.GetAllMaterias();
            List<string> materiasList1 = new List<string>();
            List<string> materiasList2 = new List<string>();
            foreach (var item in tableMat)
            {
                materiasList1.Add(item.MAT_STR_NOME);
                materiasList2.Add(item.MAT_STR_NOME);
            }

            MateriasList1.ItemsSource = materiasList1;
            MateriasList2.ItemsSource = materiasList2;
            IsBusy = false;
        }

        void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int facID = picker.SelectedIndex;
            Preferences.Set("facID", facID + 1);
        }

        private void CursosList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int curID = picker.SelectedIndex;
            Preferences.Set("curID", curID + 1);
        }

        private void MateriasList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int matID1 = picker.SelectedIndex;
            Preferences.Set("matID1", matID1 + 1);
        }

        private void MateriasList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int matID2 = picker.SelectedIndex;
            Preferences.Set("matID2", matID2 + 1);
        }

        private async void BtnInsertFaculdade_Clicked(object sender, EventArgs e)
        {
            if ((MateriasList1.SelectedIndex != -1) && (MateriasList2.SelectedIndex != -1) && (CursosList.SelectedIndex != -1) && (FaculdadesList.SelectedIndex != -1))
            {
                // Insert na rota /facdata
                FaculdadeController faculdadeController = new FaculdadeController();
                TB_FACULDADEReturn facdata = new TB_FACULDADEReturn();
                facdata = await faculdadeController.FacData(Preferences.Get("userID", 99999), Preferences.Get("facID", 99999), Preferences.Get("curID", 99999), Preferences.Get("matID1", 99999), Preferences.Get("matID2", 99999));

                if (facdata.insertCompleted == true)
                {
                    await DisplayAlert("Sucesso", "Seu cadastro foi concluido, volte para a tela incial e realize o login.", "Ok");
                }
                else
                {
                    await DisplayAlert("Erro", "Ocorreu um erro na criação do seu usuário, por favor tente novamente mais tarde", "Ok");
                }
                
            }
            else
            {
                await DisplayAlert("Erro", "Selecione todos os campos antes de prosseguir", "Ok");
            }
        }
    }
}