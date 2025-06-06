﻿using System;
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
using MaterialSkin.Controls;
using System.Configuration;
using System.Collections.Specialized;
using System.Drawing.Text;
using System.IO;
using System.Reflection;

namespace Menus
{
    public partial class TelaLogin : Form
    {
        Thread nt;


        public TelaLogin()
        {
            InitializeComponent();




        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        public string strConexao = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public const string strSelectData = "SELECT FAC_STR_NOME, CUR_STR_NOME, MAT_STR_NOME FROM TB_USER AS U JOIN TB_USER_FAC AS F ON U.USER_INT_ID = F.USER_INT_ID JOIN TB_FACULDADE AS F2 ON F2.FAC_INT_ID = F.FAC_INT_ID  JOIN TB_CURSO AS C ON U.USER_INT_ID = C.USER_INT_ID JOIN TB_MATERIA AS M ON U.USER_INT_ID = M.USER_INT_ID WHERE U.USER_STR_EMAIL = @USER_STR_EMAIL";


        public void SelectUserConfig(string emailRecebe)
        {
            using (SqlConnection objConexao = new SqlConnection(strConexao))
            {
                using (SqlCommand objCommand = new SqlCommand(strSelectData, objConexao))
                {
                    objConexao.Open();

                    objCommand.Parameters.AddWithValue("@USER_STR_EMAIL", emailRecebe);

                    SqlDataReader da = objCommand.ExecuteReader();
                    while (da.Read())
                    {
                        Login.Facul = da.GetValue(0).ToString();
                        Login.Curso = da.GetValue(1).ToString();
                        Login.Materia = da.GetValue(2).ToString();
                    }




                    da.Close();
                    objConexao.Close();

                }
            }
        }


        private void btnentrar_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=atenaserver.database.windows.net;Initial Catalog=atenadatabase;Persist Security Info=True;User ID=atenaadmin;Password=mogueno1234!@#$");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM TB_USER WHERE USER_STR_EMAIL='" + txtusuario.Text + "' AND USER_STR_SENHA='" + txtsenha.Text + "'", con);
            DataTable dt = new DataTable(); 
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {

                Login.Usuario = txtusuario.Text;

                SelectUserConfig(txtusuario.Text);
                this.Hide();
                new Menuprinc(txtusuario.Text).Show();
            }
            else
            {
                MessageBox.Show("Usuário ou senha incorretos");
            }
        }

        private void btncadastrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            new TelaCadastrar().Show();
        }

        private void btnface_Click(object sender, EventArgs e)
        {
        }

        private void TelaLogin_Load(object sender, EventArgs e)
        {

        }

        private void lbsenha_Click(object sender, EventArgs e)
        {

        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=atenaserver.database.windows.net;Initial Catalog=atenadatabase;Persist Security Info=True;User ID=atenaadmin;Password=mogueno1234!@#$");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM TB_USER WHERE USER_STR_EMAIL='" + txtusuario.Text + "' AND USER_STR_SENHA='" + txtsenha.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {

                Login.Usuario = txtusuario.Text;

                SelectUserConfig(txtusuario.Text);
                this.Hide();
                new Menuprinc(txtusuario.Text).Show();
            }
            else
            {
                MessageBox.Show("Usuário ou senha incorretos");
            }
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new TelaCadastrar().Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbusuario_Click(object sender, EventArgs e)
        {

        }
    }
}
