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
using Transitions;

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
                //bancoMainEntities1 ht = new bancoMainEntities1();

                //var id = ht.TB_USER.Where(a => a.USER_STR_EMAIL == EmailUser).SingleOrDefault();
                //var email = id.USER_INT_ID;
                //var result = ht.TB_CURSO.SingleOrDefault(a => a.USER_INT_ID == email);
                //if (result != null)
                //{
                //    result.PIC_IMG_MAIN = ms.ToArray();
                //    ht.SaveChanges();
                //}
                //else
                //{
                //    ht.TB_PICTURES.Add(new TB_PICTURES() { PIC_IMG_MAIN = ms.ToArray(), USER_INT_ID = email });
                //    ht.SaveChanges();
                //}


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
            try
            {
                bancoMainEntities1 ht3 = new bancoMainEntities1();
                var content = ht3.TB_FACULDADE.ToList();
                if (content.Count != 0)
                {
                    for (int i = 0; i < content.Count; i++)
                    {
                        Button button = new Button();
                        button.Tag = content[i].FAC_INT_ID;
                        button.Text = content[i].FAC_STR_NOME;
                        button.FlatStyle = FlatStyle.Flat;
                        button.UseVisualStyleBackColor = false;
                        button.BackColor = Color.FromArgb(32, 32, 32);
                        button.Margin = new Padding(5);
                        button.ForeColor = Color.White;
                        button.Cursor = Cursors.Hand;
                        button.Height = 40;
                        button.Width = 397;
                        button.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        button.Cursor = Cursors.Hand;
                        button.Click += new EventHandler(this.button_Click);
                        flowLayoutPanel2.Controls.Add(button);

                    }
                }
                else
                {
                    MessageBox.Show("Não foram encontradas notas");
                }
            }
            catch (Exception ex)
            {
                ErrorProvider error = new ErrorProvider();
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string s = (sender as Button).Text;
            int a = Convert.ToInt32((sender as Button).Tag);
            txtuniversidade.Text = s;
            txtuniversidade.Tag = a;
            Transition.run(flowLayoutPanel2, "Height", 0, new TransitionType_EaseInEaseOut(250));
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
                Login.Usuario = txtLogin3.Text;

                int s = Convert.ToInt32(txtuniversidade.Tag);



                GravarUser(txtNome3.Text, txtIdade3.Text, txtSexo3.Text, txtLogin3.Text, txtSenha3.Text, "0", "0");


                bancoMainEntities1 ht = new bancoMainEntities1();
                var id = ht.TB_USER.Where(a => a.USER_STR_EMAIL == txtLogin3.Text).SingleOrDefault();

                ht.TB_USER_FAC.Add(new TB_USER_FAC() { FAC_INT_ID = s, USER_INT_ID = id.USER_INT_ID });
                ht.SaveChanges();

                emailMain = retorna();

                SelectUser(retorna());

                GravarFacul(txtLogin3.Text, txtuniversidade.Text, txtcurso.Text, txtmateria1.Text, txthora1.Text);

                this.Hide();
                new Menuprinc(txtLogin3.Text).Show();
            }

            else
            {
                MessageBox.Show("um ou mais campos estão vazios");
            }

        }

        private void txtuniversidade_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel2.Height == 0)
            {
                Transition.run(flowLayoutPanel2, "Height", 280, new TransitionType_EaseInEaseOut(250));
            }
            else
            {
                Transition.run(flowLayoutPanel2, "Height", 0, new TransitionType_EaseInEaseOut(250));
            }
        }
    }
}
