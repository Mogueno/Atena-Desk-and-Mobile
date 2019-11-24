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
		Thread pt;
		public Menuprinc()
        {
            InitializeComponent();
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

		private void Button2_Click(object sender, EventArgs e)
		{
			this.Close();
			pt = new Thread(novoform7);
			pt.SetApartmentState(ApartmentState.STA);
			pt.Start();
		}

		private void novoform7()
		{
			Application.Run(new TelaNovaNota());
		}

		private void Button3_Click(object sender, EventArgs e)
		{
			this.Close();
			pt = new Thread(novoform8);
			pt.SetApartmentState(ApartmentState.STA);
			pt.Start();
		}

		private void novoform8()
		{
			Application.Run(new TelaConfiguracao());
		}

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://scholar.google.com.br/");
        }
    }
}
