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
    public partial class TelaCadastrar : Form
    {
        Thread nf;

        public TelaCadastrar()
        {
            InitializeComponent();
        }

        private void TelaCadastrar_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnconcluir_Click(object sender, EventArgs e)
        {
            this.Close();
            nf = new Thread(novoform2);
            nf.SetApartmentState(ApartmentState.STA);
            nf.Start();
        }

        private void novoform2()
        {
            Application.Run(new Telamfc());
        }
    }
}
