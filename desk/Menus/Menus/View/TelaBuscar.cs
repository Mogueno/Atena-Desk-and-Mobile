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
using Transitions;

namespace Menus
{
    public partial class TelaBuscar : MaterialForm
    {
		public TelaBuscar(string texto)
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
            this.Hide();
            new TelaBuscar_Texto(lbRecebeEmailMenu.Text).Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            new TelaBuscar_Faculdade(lbRecebeEmailMenu.Text).Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            new TelaBuscar_Curso(lbRecebeEmailMenu.Text).Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            new TelaBuscar_Materia(lbRecebeEmailMenu.Text).Show();
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            new TelaBuscar_Custom(lbRecebeEmailMenu.Text).Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                Transition.run(button10, "Height", 30, new TransitionType_EaseInEaseOut(100));
            }
            catch (Exception ex)
            {
                MessageBox.Show("deu ruim\n\n"+ex);
            }
        }
    }
}
