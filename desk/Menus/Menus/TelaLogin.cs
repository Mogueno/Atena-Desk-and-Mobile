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
    public partial class TelaLogin : Form
    {
        Thread nt;

        public TelaLogin()
        {
            InitializeComponent();
        }

        private void TelaLogin_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnentrar_Click(object sender, EventArgs e)
        {
            if (txtusuario.Text == "gabriel" && txtsenha.Text == "gabriel")
            {
                this.Close();
                nt = new Thread(Menuprinc);
                nt.SetApartmentState(ApartmentState.STA);
                nt.Start();

            }
            else
            {
                MessageBox.Show("Senha ou Login inválida");
            }
        }

        private void Menuprinc()
        {
            Application.Run(new Menuprinc());
        }

        private void btncadastrar_Click(object sender, EventArgs e)
        {
            this.Close();
            nt = new Thread(novoform6);
            nt.SetApartmentState(ApartmentState.STA);
            nt.Start();
        }

        private void novoform6()
        {
            Application.Run(new TelaCadastrar());
        }
    }
}
