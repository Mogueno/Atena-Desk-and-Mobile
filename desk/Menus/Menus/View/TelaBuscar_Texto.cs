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
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace Menus
{
    public partial class TelaBuscar_Texto : MaterialForm
    {
		public TelaBuscar_Texto(string texto)
        {
            InitializeComponent();

            lbRecebeEmailMenu.Text = texto;

            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            TopMost = true;
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


        }

        private void Menuprinc_Load(object sender, EventArgs e)
        {

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

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            flowLayoutPanel4.Controls.Clear();
            string searchContent = txtSearchBox.Text;
            try
            {
                bancoMainEntities1 ht2 = new bancoMainEntities1();
                var content = ht2.TB_NOTA_STR.Where(b => b.STR_STR_PATH.Contains(searchContent) || b.STR_STR_TITLE.Contains(searchContent)).ToList();
                if (content.Count != 0)
                {
                    for (int i = 0; i < content.Count; i++)
                    {
                        Button button = new Button();
                        button.Tag = content[i].STR_INT_ID;
                        button.Text = content[i].STR_STR_TITLE;
                        button.Width = flowLayoutPanel4.Width - 5;
                        button.Cursor = Cursors.Hand;
                        button.Click += new EventHandler(this.button_Click);
                        flowLayoutPanel4.Controls.Add(button);
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

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            new TelaBuscar(lbRecebeEmailMenu.Text).Show();
        }

        private void flowLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
