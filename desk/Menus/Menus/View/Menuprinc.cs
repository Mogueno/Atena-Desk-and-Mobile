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

namespace Menus
{
    public partial class Menuprinc : Form
    {
		public Menuprinc(string texto)
        {
            InitializeComponent();

            lbRecebeEmailMenu.Text = texto;
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
    }
}
