using MobileTCC.Helpers;
using MobileTCC.Model;
using SQLite;
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
	public partial class Configuracoes : ContentPage
	{
        public Configuracoes()
        {
            InitializeComponent();
            GetUserData();
        }

        public void GetUserData()
        {
            ServiceDBUserData dbUser = new ServiceDBUserData(Application.Caminho);
            var userData = dbUser.ListarUsuario();
            //EntryUserName.Text = userData[0].Login;
            //EntryUserPassword.Text = userData[0].Senha;
            //EntryUserEmail.Text = userData[0].Email;
            //EntryUserCurso.Text = userData[0].Curso;
            //EntryUserFaculdade.Text = userData[0].Faculdade;
            //EntryUserMateria.Text = userData[0].Materia;
            //EntryUserSexo.Text = userData[0].Sexo;
        }

    }

}