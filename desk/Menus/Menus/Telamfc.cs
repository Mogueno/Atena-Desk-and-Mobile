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
    public partial class Telamfc : Form
    {
        Thread ne;
        public Telamfc()
        {
            InitializeComponent();
        }

        private void btnconcluir_Click(object sender, EventArgs e)
        {
            this.Close();
            ne = new Thread(novoform4);
            ne.SetApartmentState(ApartmentState.STA);
            ne.Start();
        }

        private void novoform4()
        {
            Application.Run(new TelaLogin());
        }

        private void btnfinalizar_Click(object sender, EventArgs e)
        {
            this.Close();
            ne = new Thread(novoform5);
            ne.SetApartmentState(ApartmentState.STA);
            ne.Start();
        }

        private void novoform5()
        {
            Application.Run(new Menuprinc());
        }
    }
}
