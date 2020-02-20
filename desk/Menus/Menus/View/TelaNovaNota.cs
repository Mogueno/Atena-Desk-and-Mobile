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
using System.Data.SqlClient;
using System.Configuration;
namespace Menus
{
	public partial class TelaNovaNota : MaterialForm
	{
		public TelaNovaNota(string texto)
		{
			InitializeComponent();

            lbRecebeEmailNovaNota.Text = texto;

            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            TopMost = true;
        }

        public string strConexao = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public const string strSelectUser = "SELECT U.USER_INT_ID, F.FAC_INT_ID, C.CUR_INT_ID, M.MAT_INT_ID FROM TB_USER AS U JOIN TB_FACULDADE AS F ON U.USER_INT_ID = F.USER_INT_ID JOIN TB_CURSO AS C ON U.USER_INT_ID = C.USER_INT_ID JOIN TB_MATERIA AS M ON U.USER_INT_ID = M.USER_INT_ID WHERE U.USER_STR_EMAIL = @USER_STR_EMAIL";

        public const string strSelectNota = "SELECT NOTA_INT_ID FROM ";


        public const string strInsertNota1 = "INSERT INTO TB_NOTA OUTPUT INSERTED.NOTA_INT_ID VALUES (@FAC_INT_ID, @CUR_INT_ID, @MAT_INT_ID, @USER_INT_ID)";

        public const string strInsertNota2 = "INSERT INTO TB_NOTA_STR VALUES (@STR_STR_PATH, @NOTA_INT_ID, @STR_STR_TITLE)";

        public void SelectNota(string emailRecebe, string notaRecebe, string notaTitulo)
        {
            using (SqlConnection objConexao = new SqlConnection(strConexao))
            {
                using (SqlCommand objCommand = new SqlCommand(strSelectUser, objConexao))
                {
                    objConexao.Open();

                    objCommand.Parameters.AddWithValue("@USER_STR_EMAIL", emailRecebe);

                    string userId = "";
                    string cursoId = "";
                    string materiaId = "";
                    string faculdadeId = "";
                    int notaId = 0;

                    SqlDataReader da = objCommand.ExecuteReader();
                    while (da.Read())
                    {
                        userId = da.GetValue(0).ToString();
                        faculdadeId = da.GetValue(1).ToString();
                        cursoId = da.GetValue(2).ToString();
                        materiaId = da.GetValue(3).ToString();

                    }

                    da.Close();

                    using (SqlCommand objCommand2 = new SqlCommand(strInsertNota1, objConexao))
                    {
                        objCommand2.Parameters.AddWithValue("@USER_INT_ID", userId);
                        objCommand2.Parameters.AddWithValue("@FAC_INT_ID", faculdadeId);
                        objCommand2.Parameters.AddWithValue("@CUR_INT_ID", cursoId);
                        objCommand2.Parameters.AddWithValue("@MAT_INT_ID", materiaId);


                        notaId = (Int32)objCommand2.ExecuteScalar();


                            using (SqlCommand objCommand3 = new SqlCommand (strInsertNota2 , objConexao))
                            {
                                objCommand3.Parameters.AddWithValue("@STR_STR_PATH", notaRecebe);
                                objCommand3.Parameters.AddWithValue("@NOTA_INT_ID", notaId);
                                objCommand3.Parameters.AddWithValue("@STR_STR_TITLE", notaTitulo);

                                int retorno2 = objCommand3.ExecuteNonQuery();

                                if (retorno2 == 1)
                                {
                                    MessageBox.Show("Dados inseridos");
                                }


                            }
                        

                    }

                        objConexao.Close();

                }
            }
        }

        private void GravarNota(string EmailVar, string Nota, string Titulo)
        {
            try
            {
                SelectNota(EmailVar, Nota, Titulo);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Deu ruim" + ex);
            }
        }
        private void btnAdicionar_Click(object sender, EventArgs e)
        {

            Cadastro user = new Cadastro();
            if (!String.IsNullOrEmpty(txtNota.Text) && !String.IsNullOrEmpty(txtTitle.Text))
            {
                 GravarNota(Login.Usuario, txtNota.Text, txtTitle.Text);
            }
            else
            {
                MessageBox.Show("Digite algo para que seja salvo");
            }
        }

        private void TelaNovaNota_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Menuprinc(lbRecebeEmailNovaNota.Text).Show();
        }

        private void TelaNovaNota_Load_1(object sender, EventArgs e)
        {
        }
    }
}
