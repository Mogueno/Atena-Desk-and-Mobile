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
            this.IsBusy = false;
        }

        public async void PopulatePickers()
        {
            this.IsBusy = true;
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
            this.IsBusy = false;

            //INSERIR ID FACULDADE NA TABELA TB_USER_FAC
            //Pegar ID faculdade depois de selecionada.

            //Rota que busca todos os cursos
            //CURSO - puxa cursos da table TB_CURSO, e salva o tb_curso_id que foi selecionado
            //Insere na TB_USER_CUR o id da materia junto com o ID do usuario

            //ROTA que busca todas as materias
            //Inserir picker de hora pra materia
            //MATERIA - Puxa materias da table tb_materia, e salva o tb_materia_id que foi selecionado+
            //Insere na TB_USER_MAT com o id do curso junto com id do usuario

            //Rota que insere o  idfacul id curso e idmaterias em suas respectivas tabelas

        }

        void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int facID = picker.SelectedIndex;
            Preferences.Set("facID", facID + 1);
        }

        private void CursosList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MateriasList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MateriasList2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BtnInsertFaculdade_Clicked(object sender, EventArgs e)
        {
            if ((MateriasList1.SelectedIndex != -1) && (MateriasList2.SelectedIndex != -1) && (CursosList.SelectedIndex != -1) && (FaculdadesList.SelectedIndex != -1))
            {
                // Insert na rota /facdata
                DisplayAlert("Sucesso", "Seu cadastro foi concluido", "Ok");
            }
            else
            {
                DisplayAlert("Erro", "Selecione todos os campos antes de prosseguir", "Ok");
            }
        }
    }
}