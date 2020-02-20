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
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Runtime.InteropServices;

namespace Menus
{

    public partial class TelaConfiguracao : MaterialForm
    {
        public TelaConfiguracao(string textao)
        {
            InitializeComponent();

            lbRecebeEmailConfig.Text = textao;
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            TopMost = true;

        }


        Cadastro user = new Cadastro();

        public string strConexao = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public const string strSelectUser = "SELECT USER_STR_NOME, USER_INT_IDADE, USER_STR_SEXO FROM TB_USER WHERE USER_STR_EMAIL = @USER_STR_EMAIL_VAR";

        public const string strUpdateUser = "UPDATE TB_USER SET USER_STR_NOME = @USER_STR_NOME, USER_INT_IDADE = @USER_INT_IDADE, USER_STR_SEXO = @USER_STR_SEXO WHERE USER_STR_EMAIL = @USER_STR_EMAIL";



        public void SelectUserConfig(string emailRecebe)
        {
            using (SqlConnection objConexao = new SqlConnection(strConexao))
            {
                using (SqlCommand objCommand = new SqlCommand(strSelectUser, objConexao))
                {
                    objConexao.Open();

                    objCommand.Parameters.AddWithValue("@USER_STR_EMAIL_VAR", emailRecebe);

                    SqlDataReader da = objCommand.ExecuteReader();
                    while (da.Read())
                    {
                        txtNome.Text = da.GetValue(0).ToString();
                        txtHello.Text = "Olá "+da.GetValue(0).ToString();
                        txtIdade.Text = da.GetValue(1).ToString();
                        txtSexo.Text = da.GetValue(2).ToString();
                    }




                    da.Close();
                    objConexao.Close();

                }
            }
        }

        public void UpdateUserConfig(string emailRecebe, string nome, string idade, string sexo)
        {
            using (SqlConnection objConexao = new SqlConnection(strConexao))
            {
                using (SqlCommand objCommand = new SqlCommand(strUpdateUser, objConexao))
                {
                    objConexao.Open();

                    objCommand.Parameters.AddWithValue("@USER_STR_EMAIL", emailRecebe);
                    objCommand.Parameters.AddWithValue("@USER_STR_NOME", nome);
                    objCommand.Parameters.AddWithValue("@USER_STR_SEXO", sexo);
                    objCommand.Parameters.AddWithValue("@USER_INT_IDADE", idade);



                    int retorno = objCommand.ExecuteNonQuery();
                    
                    if(retorno == 1)
                    {
                        MessageBox.Show("Deu certo");
                    }

                    objConexao.Close();

                }
            }
        }


        private void UpdateUser(string EmailVar, string nomevar, string idadevar, string sexovar)
        {

            try
            {
                UpdateUserConfig(EmailVar, nomevar, idadevar, sexovar);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Deu ruim" + ex.Message);
            }
        }
        private void GetUser(string EmailVar)
        {

            try
            {
                SelectUserConfig(EmailVar);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Deu ruim" + ex);
            }
        }


        private void TelaConfiguracao_Load(object sender, EventArgs e)
        {
            try
            {
                bancoMainEntities1 ht1 = new bancoMainEntities1();
                var id = ht1.TB_USER.Where(a => a.USER_STR_EMAIL == lbRecebeEmailConfig.Text).SingleOrDefault();
                var email = id.USER_INT_ID;
                var item = ht1.TB_PICTURES.Where(a => a.USER_INT_ID == email).FirstOrDefault();
                byte[] arr = item.PIC_IMG_MAIN;
                MemoryStream ms1 = new MemoryStream(arr);
                pictureBox1.Image = Image.FromStream(ms1);
            }
            catch
            {
                pictureBox1.Image = pictureBox1.InitialImage;
            }

            GetUser(lbRecebeEmailConfig.Text);

            lbMateriaShow.Text = Login.Materia;
            lbFaculShow.Text = Login.Facul;
            lbCursoShow.Text = Login.Curso;

        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            UpdateUser(lbRecebeEmailConfig.Text, txtNome.Text, txtIdade.Text, txtSexo.Text);
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
        }

        private void btnVoltar2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Menuprinc(lbRecebeEmailConfig.Text).Show();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog opendlg = new OpenFileDialog();
            if (opendlg.ShowDialog() == DialogResult.OK)
            {

                Image img = Image.FromFile(opendlg.FileName);
                MemoryStream ms = new MemoryStream();
                img.Save(ms, img.RawFormat);
                bancoMainEntities1 ht = new bancoMainEntities1();
                var id = ht.TB_USER.Where(a => a.USER_STR_EMAIL == lbRecebeEmailConfig.Text).SingleOrDefault();
                var email = id.USER_INT_ID;
                ht.TB_PICTURES.Add(new TB_PICTURES() { PIC_IMG_MAIN = ms.ToArray(), USER_INT_ID = email});
                ht.SaveChanges();
                var item = ht.TB_PICTURES.Where(a => a.USER_INT_ID == email).FirstOrDefault();
                byte[] arr = item.PIC_IMG_MAIN;
                MemoryStream ms1 = new MemoryStream(arr);
                pictureBox1.Image = Image.FromStream(ms1);
            }
        }

        private void lbDados_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opendlg = new OpenFileDialog();
            if (opendlg.ShowDialog() == DialogResult.OK)
            {

                Image img = Image.FromFile(opendlg.FileName);
                MemoryStream ms = new MemoryStream();
                img.Save(ms, img.RawFormat);
                bancoMainEntities1 ht = new bancoMainEntities1();
                var id = ht.TB_USER.Where(a => a.USER_STR_EMAIL == lbRecebeEmailConfig.Text).SingleOrDefault();
                var email = id.USER_INT_ID;
                var result = ht.TB_PICTURES.SingleOrDefault(a => a.USER_INT_ID == email);
                if (result != null)
                {
                    result.PIC_IMG_MAIN = ms.ToArray();
                    ht.SaveChanges();
                }
                else
                {
                    ht.TB_PICTURES.Add(new TB_PICTURES() { PIC_IMG_MAIN = ms.ToArray(), USER_INT_ID = email });
                    ht.SaveChanges();
                }
                var item = ht.TB_PICTURES.Where(a => a.USER_INT_ID == email).FirstOrDefault();
                byte[] arr = item.PIC_IMG_MAIN;
                MemoryStream ms1 = new MemoryStream(arr);
                pictureBox1.Image = Image.FromStream(ms1);
            }
        }

        private void lbRecebeEmailConfig_Click(object sender, EventArgs e)
        {

        }

        private void txtSexo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtIdade_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbMateriaShow_Click(object sender, EventArgs e)
        {

        }

        private void lbCursoShow_Click(object sender, EventArgs e)
        {

        }

        private void lbMateria_Click(object sender, EventArgs e)
        {

        }

        private void lbCurso_Click(object sender, EventArgs e)
        {

        }

        private void lbFaculShow_Click(object sender, EventArgs e)
        {

        }

        private void lbIdade_Click(object sender, EventArgs e)
        {

        }

        private void lbFaculdade_Click(object sender, EventArgs e)
        {

        }

        private void lbSexo_Click(object sender, EventArgs e)
        {

        }

        private void lbNome_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                bancoMainEntities1 ht1 = new bancoMainEntities1();
                var id = ht1.TB_USER.   Where(a => a.USER_STR_EMAIL == lbRecebeEmailConfig.Text).SingleOrDefault();
                var email = id.USER_INT_ID;
                var item = ht1.TB_PICTURES.Where(a => a.USER_INT_ID == email).FirstOrDefault();
                byte[] arr = item.PIC_IMG_MAIN;
                MemoryStream ms1 = new MemoryStream(arr);
                pictureBox1.Image = Image.FromStream(ms1);
            }
            catch
            {
                pictureBox1.Image = pictureBox1.InitialImage;
            }
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Menus.Properties.Resources.User_icon_BLACK_01;
        }
    }
}
