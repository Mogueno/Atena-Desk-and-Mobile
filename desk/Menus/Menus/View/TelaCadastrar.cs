using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Menus.Model;

namespace Menus
{
    public partial class TelaCadastrar : Form
    {
        Thread nf;

        public TelaCadastrar()
        {
            InitializeComponent();
        }

        private void TelaCadastrar_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void GravarUser(string Nome, string Idade, string Sexo, string Email, string Senha, string Facebook, string Google)
        {

            try
            {
                Dados objDados = new Dados();

                objDados.GravarUser(Nome, Idade, Sexo, Email, Senha, Facebook, Google);
            }

            catch(Exception ex)
            {
                MessageBox.Show("Deu ruim" + ex.Message);
            }
        }

        private void btnconcluir_Click(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(txtnome.Text) && !String.IsNullOrEmpty(txtidade.Text) && !String.IsNullOrEmpty(txtsexo.Text) && !String.IsNullOrEmpty(txtlogin2.Text) && !String.IsNullOrEmpty(txtsenha2.Text))
            {
                GravarUser(txtnome.Text, txtidade.Text, txtsexo.Text, txtlogin2.Text, txtsenha2.Text, "0", "0");

                this.Close();
                nf = new Thread(novoform2);
                nf.SetApartmentState(ApartmentState.STA);
                nf.Start();
            }

            else
            {
                MessageBox.Show("Um ou mais campos estão em branco");
            }

        }

        private void novoform2()
        {
            Application.Run(new Telamfc());
        }
    }
}
