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

namespace Menus
{
    public partial class Menuprinc : MaterialForm
    {
		public Menuprinc(string texto)
        {
            InitializeComponent();

            lbRecebeEmailMenu.Text = texto;
        }

        public string strConexao = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public const string strSelectNote = "SELECT N1.STR_STR_PATH, U.USER_INT_ID, U.USER_STR_EMAIL FROM TB_NOTA_STR AS N1 JOIN TB_NOTA AS N2 ON N1.NOTA_INT_ID = N2.NOTA_INT_ID JOIN TB_USER AS U ON N2.USER_INT_ID = U.USER_INT_ID WHERE U.USER_STR_EMAIL = @USER_STR_EMAIL";

        public void SelectNoteConfig(string emailRecebe)
        {
            using (SqlConnection objConexao = new SqlConnection(strConexao))
            {
                using (SqlCommand objCommand = new SqlCommand(strSelectNote, objConexao))
                {
                    objConexao.Open();

                    objCommand.Parameters.AddWithValue("@USER_STR_EMAIL", emailRecebe);


                    SqlDataReader da = objCommand.ExecuteReader();
                    if (da.HasRows)
                    {
                        while (da.Read())
                        {
                            Button button = new Button();
                            button.Tag = da.GetString(0);
                            button.Text = da.GetString(0);
                            button.Width = flowLayoutPanel1.Width - 5;
                            button.Cursor = Cursors.Hand;
                            flowLayoutPanel1.Controls.Add(button);
                        }
                    }
                    da.Close();
                    objConexao.Close();

                }
            }
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

		private void Button2_Click(object sender, EventArgs e)
		{
			this.Hide();
            new TelaNovaNota(lbRecebeEmailMenu.Text).Show();
		}

		private void Button3_Click(object sender, EventArgs e)
		{
            this.Hide();
            new TelaConfiguracao(lbRecebeEmailMenu.Text).Show();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://scholar.google.com.br/");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new TelaLogin().Show();
        }

        private void GetNote(string EmailVar)
        {

            try
            {
                SelectNoteConfig(EmailVar);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Deu ruim" + ex);
            }
        }

        private void Menuprinc_Load(object sender, EventArgs e)
        {
            GetNote(lbRecebeEmailMenu.Text);
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
