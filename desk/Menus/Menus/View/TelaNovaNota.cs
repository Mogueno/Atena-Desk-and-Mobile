using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using Menus.Model;

namespace Menus
{
	public partial class TelaNovaNota : MaterialForm
	{
		public TelaNovaNota()
		{
			InitializeComponent();
		}
        private void GravarNota(string EmailVar, string NotaContent)
        {
            try
            {
                Dados objDados = new Dados();

                objDados.SelectNota(EmailVar,NotaContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Deu ruim" + ex.Message);
            }
        }
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtNota.Text))
            {
                GravarNota(txtNota)
            }
        }
    }
}
