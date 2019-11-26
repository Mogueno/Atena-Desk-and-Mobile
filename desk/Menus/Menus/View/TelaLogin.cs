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
using System.Data.SqlClient;

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
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\odasf\Documents\bancoMain.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM TB_USER WHERE USER_STR_EMAIL='" + txtusuario.Text + "' AND USER_STR_SENHA='" + txtsenha.Text + "'", con);
            DataTable dt = new DataTable(); 
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                new Menuprinc(txtusuario.Text).Show();
            }
            else
                MessageBox.Show("Usuário ou senha incorretos");    
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
