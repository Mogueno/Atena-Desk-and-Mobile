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
            PopulatePicker();
        }

        public async void PopulatePicker()
        {
            FaculdadeController faculdadeController = new FaculdadeController();
            var table = await faculdadeController.GetAllFaculdades();
            var faculdadeList = new List<string>();
            foreach (var item in table)
            {
                faculdadeList.Add(item.FAC_STR_NOME);
            }
            FaculdadesList.ItemsSource = faculdadeList;


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

    }
}