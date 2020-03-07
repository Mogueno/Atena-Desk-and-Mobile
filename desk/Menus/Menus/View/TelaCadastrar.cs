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
using System.Data.SqlClient;
using MaterialSkin.Controls;

namespace Menus
{
    public partial class TelaCadastrar : Form
    {
        Thread nf;



        public string retorna()
        {
            string emailLogin = txtLogin3.Text;

            return emailLogin;
        }

        public string emailMain;

        public TelaCadastrar()
        {
            InitializeComponent();
        }

        private void GravarFacul(string EmailUser, string NomeFacul, string NomeCurso, string NomeMateria, string HoraMateria)
        {
            try
            {
                Dados objDados = new Dados();

                objDados.SelectFacul(EmailUser, NomeFacul);

                objDados.SelectCurso(EmailUser, NomeCurso);

                objDados.SelectMateria(EmailUser, NomeMateria, HoraMateria);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Deu ruim" + ex.Message);
            }
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
                MessageBox.Show("Deu ruim" + ex);
            }
        }

        private void SelectUser(string EmailVar)
        {

            try
            {
                Dados objDados = new Dados();

                objDados.SelectUser(EmailVar);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Deu ruim" + ex);
            }
        }

        private void btnconcluir_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Pichau\Documents\bancoMain.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM TB_USER WHERE USER_STR_EMAIL='" + txtLogin3.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                MessageBox.Show("ERRO\n\n Usuário já existente");
            }
            else
            {
                if (!String.IsNullOrEmpty(txtNome3.Text) && !String.IsNullOrEmpty(txtIdade3.Text) && !String.IsNullOrEmpty(txtSexo3.Text) && !String.IsNullOrEmpty(txtLogin3.Text) && !String.IsNullOrEmpty(txtSenha3.Text))
                {
                    Login.Usuario = txtLogin3.Text;

                    GravarUser(txtNome3.Text, txtIdade3.Text, txtSexo3.Text, txtLogin3.Text, txtSenha3.Text, "0", "0");

                    emailMain = retorna();

                    SelectUser(retorna());

                    panel7.BringToFront();
                }

                else
                {
                    MessageBox.Show("Um ou mais campos estão em branco");
                }
            }

        }

        private void TelaCadastrar_Load(object sender, EventArgs e)
        {
        }

        private void btnVoltarLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            new TelaLogin().Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnfinalizar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtuniversidade.Text))
            {
                Login.Materia = txtmateria1.Text;
                Login.Curso = txtcurso.Text;
                Login.Facul = txtuniversidade.Text;



                GravarFacul(txtLogin3.Text, txtuniversidade.Text, txtcurso.Text, txtmateria1.Text, txthora1.Text);

                this.Hide();
                new Menuprinc(txtLogin3.Text).Show();
            }

            else
            {
                MessageBox.Show("um ou mais campos estão vazios");
            }
        }
    }
}
