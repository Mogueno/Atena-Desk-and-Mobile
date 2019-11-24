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



        public string retorna()
        {
            string emailLogin = txtlogin2.Text;

            return emailLogin;
        }

        public string emailMain;

        public TelaCadastrar()
        {
            InitializeComponent();

        }

        private void GravarUser(string Nome, string Idade, string Sexo, string Email, string Senha, string Facebook, string Google)
        {

            try
            {
                Dados objDados = new Dados();

                objDados.GravarUser(Nome, Idade, Sexo, Email, Senha, Facebook, Google);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Deu ruim" + ex.Message);
            }
        }

        pri
            vate void SelectUser(string EmailVar)
        {

            try
            {
                Dados objDados = new Dados();

                objDados.SelectUser(EmailVar);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Deu ruim" + ex.Message);
            }
        }

        private void btnconcluir_Click(object sender, EventArgs e)
        {


            if (!String.IsNullOrEmpty(txtnome.Text) && !String.IsNullOrEmpty(txtidade.Text) && !String.IsNullOrEmpty(txtsexo.Text) && !String.IsNullOrEmpty(txtlogin2.Text) && !String.IsNullOrEmpty(txtsenha2.Text))
            {
                GravarUser(txtnome.Text, txtidade.Text, txtsexo.Text, txtlogin2.Text, txtsenha2.Text, "0", "0");

                emailMain = retorna();

                SelectUser(retorna());

                var telaAtual = new TelaCadastrar();

                var telaMFC = new Telamfc(txtlogin2.Text);

                telaMFC.Show();


                this.Hide();
            }

            else
            {
                MessageBox.Show("Um ou mais campos estão em branco");
            }

        }
    }
}
