using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MaterialSkin.Controls;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

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

        public const string strSelectNote = "SELECT N1.STR_STR_PATH, N1.STR_STR_TITLE, N1.STR_INT_ID, U.USER_INT_ID, U.USER_STR_EMAIL FROM TB_NOTA_STR AS N1 JOIN TB_NOTA AS N2 ON N1.NOTA_INT_ID = N2.NOTA_INT_ID JOIN TB_USER AS U ON N2.USER_INT_ID = U.USER_INT_ID WHERE U.USER_STR_EMAIL = @USER_STR_EMAIL";

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
                            button.Tag = da.GetInt32(2);
                            button.Text = da.GetString(1);
                            button.Width = flowLayoutPanel2.Width - 5;
                            button.Cursor = Cursors.Hand;
                            button.Click += new EventHandler(this.button_Click);
                            flowLayoutPanel2.Controls.Add(button);
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

        private void button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int s = Convert.ToInt32((sender as Button).Tag);

            bancoMainEntities1 ht = new bancoMainEntities1();
            var title = ht.TB_NOTA_STR.Where(a => a.STR_INT_ID == s).SingleOrDefault();
            lbMainTitle.Text = title.STR_STR_TITLE;
            lbMainDescription.Text = title.STR_STR_PATH;


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
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            TopMost = true;
            GetNote(lbRecebeEmailMenu.Text);
            bancoMainEntities1 ht2 = new bancoMainEntities1();
            var name = ht2.TB_USER.Where(a => a.USER_STR_EMAIL == lbRecebeEmailMenu.Text).SingleOrDefault();
            var email2 = name.USER_STR_NOME;

            var facul = ht2.TB_FACULDADE.Where(a => a.USER_INT_ID == name.USER_INT_ID).SingleOrDefault();
            lbNomeMenu.Text = email2;
            lbFacul.Text = facul.FAC_STR_NOME;
            try
            {
                bancoMainEntities1 ht1 = new bancoMainEntities1();
                var id = ht1.TB_USER.Where(a => a.USER_STR_EMAIL == lbRecebeEmailMenu.Text).SingleOrDefault();
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

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbRecebeEmailMenu_Click(object sender, EventArgs e)
        {

        }

        private void lbNomeMenu_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new TelaBuscar(lbRecebeEmailMenu.Text).Show();
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
