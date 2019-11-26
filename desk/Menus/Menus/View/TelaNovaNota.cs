using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Menus.Model;
using MaterialSkin.Controls;

namespace Menus
{
	public partial class TelaNovaNota : MaterialForm
	{
		public TelaNovaNota(string texto)
		{
			InitializeComponent();

            lbRecebeEmailNovaNota.Text = texto;
		}


        public const string strSelectUser = "SELECT USER_INT_ID FROM TB_USER WHERE USER_STR_EMAIL = @USER_STR_EMAIL_VAR";

        private void GravarNota(string EmailVar, string NotaContent)
        {
            try
            {
                Dados objDados = new Dados();

                Cadastro user =  objDados.SelectNota(EmailVar,NotaContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Deu ruim" + ex.Message);
            }
        }
        private void btnAdicionar_Click(object sender, EventArgs e)
        {

            Cadastro user = new Cadastro();
            if (!String.IsNullOrEmpty(txtNota.Text))
            {
                 GravarNota("21", txtNota.Text);
            }
        }

        private void TelaNovaNota_Load(object sender, EventArgs e)
        {

        }
    }
}
