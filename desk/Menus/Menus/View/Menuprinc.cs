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
    public partial class Menuprinc : Form
    {
		public Menuprinc(string texto)
        {
            InitializeComponent();
            lbRecebeEmailMenu.Text = texto;
        }

        public string strConexao = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public const string strSelectNote = "SELECT N1.STR_STR_PATH, N1.STR_STR_TITLE, N1.STR_INT_ID, U.USER_INT_ID, U.USER_STR_EMAIL FROM TB_NOTA_STR AS N1 JOIN TB_NOTA AS N2 ON N1.NOTA_INT_ID = N2.NOTA_INT_ID JOIN TB_USER AS U ON N2.USER_INT_ID = U.USER_INT_ID WHERE U.USER_STR_EMAIL = @USER_STR_EMAIL";

        public const string strSelectUser2 = "SELECT USER_STR_NOME, USER_INT_IDADE, USER_STR_SEXO FROM TB_USER WHERE USER_STR_EMAIL = @USER_STR_EMAIL_VAR";

        public const string strUpdateUser = "UPDATE TB_USER SET USER_STR_NOME = @USER_STR_NOME, USER_INT_IDADE = @USER_INT_IDADE, USER_STR_SEXO = @USER_STR_SEXO WHERE USER_STR_EMAIL = @USER_STR_EMAIL";


        public void SelectUserConfig(string emailRecebe)
        {
            using (SqlConnection objConexao = new SqlConnection(strConexao))
            {
                using (SqlCommand objCommand = new SqlCommand(strSelectUser2, objConexao))
                {
                    objConexao.Open();

                    objCommand.Parameters.AddWithValue("@USER_STR_EMAIL_VAR", emailRecebe);

                    SqlDataReader da = objCommand.ExecuteReader();
                    while (da.Read())
                    {
                        txtNome.Text = da.GetValue(0).ToString();
                        txtIdade.Text = da.GetValue(1).ToString();
                        txtSexo.Text = da.GetValue(2).ToString();
                    }




                    da.Close();
                    objConexao.Close();

                }
            }
        }

        public void UpdateUserConfig(string emailRecebe, string nome, string idade, string sexo)
        {
            using (SqlConnection objConexao = new SqlConnection(strConexao))
            {
                using (SqlCommand objCommand = new SqlCommand(strUpdateUser, objConexao))
                {
                    objConexao.Open();

                    objCommand.Parameters.AddWithValue("@USER_STR_EMAIL", emailRecebe);
                    objCommand.Parameters.AddWithValue("@USER_STR_NOME", nome);
                    objCommand.Parameters.AddWithValue("@USER_STR_SEXO", sexo);
                    objCommand.Parameters.AddWithValue("@USER_INT_IDADE", idade);



                    int retorno = objCommand.ExecuteNonQuery();

                    if (retorno == 1)
                    {
                        MessageBox.Show("Deu certo");
                    }

                    objConexao.Close();

                }
            }
        }


        private void UpdateUser(string EmailVar, string nomevar, string idadevar, string sexovar)
        {

            try
            {
                UpdateUserConfig(EmailVar, nomevar, idadevar, sexovar);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Deu ruim" + ex.Message);
            }
        }
        private void GetUser(string EmailVar)
        {

            try
            {
                SelectUserConfig(EmailVar);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Deu ruim" + ex);
            }
        }

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
                            string shortFoo = da.GetString(0).Length > 25 ? da.GetString(0).Substring(0, 25) + "..." : da.GetString(0);
                            Button button = new Button();
                            button.Tag = da.GetInt32(2);
                            button.Text = da.GetString(1) + "\n" + shortFoo;
                            button.Width = flowLayoutPanel2.Width -5;
                            button.FlatStyle = FlatStyle.Flat;
                            button.BackColor = Color.FromArgb(33, 33, 33);
                            button.ForeColor = Color.White;
                            button.Cursor = Cursors.Hand;
                            button.Height = 75;
                            button.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            button.Click += new EventHandler(this.button_Click);
                            flowLayoutPanel2.Controls.Add(button);
                        }
                    }
                    da.Close();
                    objConexao.Close();

                }
            }
        }

		private void Button2_Click(object sender, EventArgs e)
		{
            panelNovaNota.BringToFront();
		}

		private void Button3_Click(object sender, EventArgs e)
		{
            panelMinhaConta.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.BringToFront();
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
            textBox5.Text = title.STR_STR_TITLE;
            label9.Text = title.STR_STR_TITLE;
            textBox6.Text = title.STR_STR_PATH;
            label10.Text = title.STR_STR_PATH;
            tableLayoutPanel2.Tag = title.NOTA_INT_ID;
            panel11.Visible = true;
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
            GetNote(lbRecebeEmailMenu.Text);
            bancoMainEntities1 ht2 = new bancoMainEntities1();
            var name = ht2.TB_USER.Where(a => a.USER_STR_EMAIL == lbRecebeEmailMenu.Text).SingleOrDefault();
            var email2 = name.USER_STR_NOME;



            var facul3 = (from str in ht2.TB_USER_FAC
                          join fac in ht2.TB_FACULDADE on str.FAC_INT_ID equals fac.FAC_INT_ID
                          where name.USER_INT_ID == str.USER_INT_ID
                          select new
                          {
                              faculName = fac.FAC_STR_NOME,
                          }).SingleOrDefault();
            var curso3 = (from str in ht2.TB_USER_CUR
                          join cur in ht2.TB_CURSO on str.CUR_INT_ID equals cur.CUR_INT_ID
                          where name.USER_INT_ID == str.USER_INT_ID
                          select new
                          {
                              cursoName = cur.CUR_STR_NOME,
                          }).SingleOrDefault();

            lbNomeMenu.Text = email2;
            lbFacul.Text = facul3.faculName;
            try
            {
                bancoMainEntities1 ht1 = new bancoMainEntities1();
                var id = ht1.TB_USER.Where(a => a.USER_STR_EMAIL == lbRecebeEmailMenu.Text).SingleOrDefault();
                var email = id.USER_INT_ID;
                var item = ht1.TB_PICTURES.Where(a => a.USER_INT_ID == email).FirstOrDefault();
                byte[] arr = item.PIC_IMG_MAIN;
                MemoryStream ms1 = new MemoryStream(arr);
                pictureBox1.Image = Image.FromStream(ms1);
                roundPictureBox1.Image = Image.FromStream(ms1);
            }
            catch
            {
                pictureBox1.Image = pictureBox1.InitialImage;
                roundPictureBox1.Image = pictureBox1.InitialImage;
            }
            flowLayoutPanel2.HorizontalScroll.Maximum = 0;
            flowLayoutPanel2.AutoScroll = false;
            flowLayoutPanel2.VerticalScroll.Visible = false;
            flowLayoutPanel2.AutoScroll = true;

            flowLayoutPanel7.HorizontalScroll.Maximum = 0;
            flowLayoutPanel7.AutoScroll = false;
            flowLayoutPanel7.VerticalScroll.Visible = false;
            flowLayoutPanel7.AutoScroll = true;

            GetUser(lbRecebeEmailMenu.Text);
            lbRecebeEmailConfig.Text = lbRecebeEmailMenu.Text; 
            lbMateriaShow.Text = Login.Materia;
            lbFaculShow.Text = facul3.faculName;
            lbCursoShow.Text = curso3.cursoName;
        }
        private void button4_Click_1(object sender, EventArgs e)
        {
            panelSearch.BringToFront();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x20000; // <--- use 0x20000
                return cp;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            panelSearch.SendToBack();
            panelFacul.BringToFront();

            try
            {
                flowLayoutPanel4.Controls.Clear();
                bancoMainEntities1 ht3 = new bancoMainEntities1();
                var content = ht3.TB_FACULDADE.ToList();
                if (content.Count != 0)
                {
                    for (int i = 0; i < content.Count; i++)
                    {
                        Button button = new Button();
                        button.Tag = content[i].FAC_INT_ID;
                        button.Text = content[i].FAC_STR_NOME;
                        button.FlatStyle = FlatStyle.Flat;
                        button.BackColor = Color.FromArgb(11, 7, 17);
                        button.Cursor = Cursors.Hand;
                        button.Height = 195;
                        button.Width = 195;
                        button.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        button.Cursor = Cursors.Hand;
                        button.Click += new EventHandler(this.buttonSearch_Click);
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

        private void button12_Click(object sender, EventArgs e)
        {
            panelSearch.SendToBack();
            panelHome.BringToFront();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            panelSearch.SendToBack();
            panelFacul.BringToFront();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            panelSearch.SendToBack();
            panelHome.BringToFront();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                flowLayoutPanel7.Controls.Clear();
                string searchContent = textBox1.Text;
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
                            button.Width = flowLayoutPanel7.Width - 5;
                            button.FlatStyle = FlatStyle.Flat;
                            button.BackColor = Color.FromArgb(11, 7, 17);
                            button.Cursor = Cursors.Hand;
                            button.Height = 75;
                            button.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            button.Cursor = Cursors.Hand;
                            button.Click += new EventHandler(this.buttonSearchText_Click);
                            flowLayoutPanel7.Controls.Add(button);
                        }
                    }
                    else
                    {
                        TextBox txt = new TextBox();
                        txt.Text = "Não foram encontrados resultados para a sua pesquisa";
                        flowLayoutPanel7.Controls.Add(txt);
                    }
                }

                catch (Exception ex)
                {
                    ErrorProvider error = new ErrorProvider();
                }
            }
            else
            {
                flowLayoutPanel7.Controls.Clear();
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int s = Convert.ToInt32((sender as Button).Tag);
            panel21.Tag = s;
            panelFacul__Search.BringToFront();
            searchButtons();
        }

        private void buttonCurSearch_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int s = Convert.ToInt32((sender as Button).Tag);
            panel29.Tag = s;
            panelCurso2__Search.BringToFront();
            searchButtonsCurso();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox2.Text))
            {
                flowLayoutPanel9.Controls.Clear();
                string searchContent = textBox2.Text;
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
                            button.Width = flowLayoutPanel7.Width - 5;
                            button.Cursor = Cursors.Hand;
                            flowLayoutPanel9.Controls.Add(button);
                        }
                    }
                    else
                    {
                        TextBox txt = new TextBox();
                        txt.Text = "Não foram encontrados resultados para a sua pesquisa";
                        flowLayoutPanel9.Controls.Add(txt);
                    }
                }

                catch (Exception ex)
                {
                    ErrorProvider error = new ErrorProvider();
                }
            }
            else
            {
                flowLayoutPanel4.Controls.Clear();
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            panelCur.BringToFront();
            try
            {
                bancoMainEntities1 ht3 = new bancoMainEntities1();
                var content = ht3.TB_CURSO.ToList();
                if (content.Count != 0)
                {
                    for (int i = 0; i < content.Count; i++)
                    {
                        Button button = new Button();
                        button.Tag = content[i].CUR_INT_ID;
                        button.Text = content[i].CUR_STR_NOME;
                        button.Width = flowLayoutPanel9.Width - 5;
                        button.Cursor = Cursors.Hand;
                        flowLayoutPanel9.Controls.Add(button);
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

        private void button21_Click(object sender, EventArgs e)
        {
            panelSearch.BringToFront();
        }
        private void return_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            panelSearch.BringToFront();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            panelCurso2.BringToFront();

            try
            {
                flowLayoutPanel4.Controls.Clear();
                bancoMainEntities1 ht3 = new bancoMainEntities1();
                var content = ht3.TB_CURSO.ToList();
                if (content.Count != 0)
                {
                    for (int i = 0; i < content.Count; i++)
                    {
                        Button button = new Button();
                        button.Tag = content[i].CUR_INT_ID;
                        button.Text = content[i].CUR_STR_NOME;
                        button.FlatStyle = FlatStyle.Flat;
                        button.BackColor = Color.FromArgb(11, 7, 17);
                        button.Cursor = Cursors.Hand;
                        button.Height = 195;
                        button.Width = 195;
                        button.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        button.Cursor = Cursors.Hand;
                        button.Click += new EventHandler(this.buttonCurSearch_Click);
                        flowLayoutPanel14.Controls.Add(button);
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

        private void button6_Click_1(object sender, EventArgs e)
        {
            panelTexto.BringToFront();
        }

        public string strConexao2 = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public const string strSelectUser = "SELECT U.USER_INT_ID, F.FAC_INT_ID, C.CUR_INT_ID, M.MAT_INT_ID FROM TB_USER AS U JOIN TB_USER_FAC AS F ON U.USER_INT_ID = F.USER_INT_ID JOIN TB_USER_CUR AS C ON U.USER_INT_ID = C.USER_INT_ID JOIN TB_MATERIA AS M ON U.USER_INT_ID = M.USER_INT_ID WHERE U.USER_STR_EMAIL = @USER_STR_EMAIL";

        public const string strSelectNota = "SELECT NOTA_INT_ID FROM ";


        public const string strInsertNota1 = "INSERT INTO TB_NOTA OUTPUT INSERTED.NOTA_INT_ID VALUES (@FAC_INT_ID, @CUR_INT_ID, @MAT_INT_ID, @USER_INT_ID)";

        public const string strInsertNota2 = "INSERT INTO TB_NOTA_STR VALUES (@STR_STR_PATH, @NOTA_INT_ID, @STR_STR_TITLE)";

        public void SelectNota(string emailRecebe, string notaRecebe, string notaTitulo)
        {
            using (SqlConnection objConexao = new SqlConnection(strConexao2))
            {
                using (SqlCommand objCommand = new SqlCommand(strSelectUser, objConexao))
                {
                    objConexao.Open();

                    objCommand.Parameters.AddWithValue("@USER_STR_EMAIL", emailRecebe);

                    string userId = "";
                    string cursoId = "";
                    string materiaId = "";
                    string faculdadeId = "";
                    int notaId = 0;

                    SqlDataReader da = objCommand.ExecuteReader();
                    while (da.Read())
                    {
                        userId = da.GetValue(0).ToString();
                        faculdadeId = da.GetValue(1).ToString();
                        cursoId = da.GetValue(2).ToString();
                        materiaId = da.GetValue(3).ToString();

                    }

                    da.Close();

                    using (SqlCommand objCommand2 = new SqlCommand(strInsertNota1, objConexao))
                    {
                        objCommand2.Parameters.AddWithValue("@USER_INT_ID", userId);
                        objCommand2.Parameters.AddWithValue("@FAC_INT_ID", faculdadeId);
                        objCommand2.Parameters.AddWithValue("@CUR_INT_ID", cursoId);
                        objCommand2.Parameters.AddWithValue("@MAT_INT_ID", materiaId);


                        notaId = (Int32)objCommand2.ExecuteScalar();


                        using (SqlCommand objCommand3 = new SqlCommand(strInsertNota2, objConexao))
                        {
                            objCommand3.Parameters.AddWithValue("@STR_STR_PATH", notaRecebe);
                            objCommand3.Parameters.AddWithValue("@NOTA_INT_ID", notaId);
                            objCommand3.Parameters.AddWithValue("@STR_STR_TITLE", notaTitulo);

                            int retorno2 = objCommand3.ExecuteNonQuery();

                            if (retorno2 == 1)

                            {
                                MessageBox.Show("Dados inseridos");
                                panelHome.BringToFront();
                                flowLayoutPanel2.Controls.Clear();
                                GetNote(lbRecebeEmailMenu.Text);
                            }


                        }


                    }

                    objConexao.Close();

                }
            }
        }


        private void GravarNota(string EmailVar, string Nota, string Titulo)
        {
            try
            {
                SelectNota(EmailVar, Nota, Titulo);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Deu ruim" + ex);
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {

            Cadastro user = new Cadastro();
            if (!String.IsNullOrEmpty(txtNota.Text) && !String.IsNullOrEmpty(txtTitle.Text))
            {
                GravarNota(lbRecebeEmailMenu.Text, txtNota.Text, txtTitle.Text);
            }
            else
            {
                MessageBox.Show("Digite algo para que seja salvo");
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            panelHome.BringToFront();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(lbRecebeEmailMenu.Text) && !String.IsNullOrEmpty(txtNome.Text) && !String.IsNullOrEmpty(txtIdade.Text) && !String.IsNullOrEmpty(txtSexo.Text))
            {
                UpdateUser(lbRecebeEmailMenu.Text, txtNome.Text, txtIdade.Text, txtSexo.Text);
            }
        }

        private void roundPictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opendlg = new OpenFileDialog();
            if (opendlg.ShowDialog() == DialogResult.OK)
            {

                Image img = Image.FromFile(opendlg.FileName);
                MemoryStream ms = new MemoryStream();
                img.Save(ms, img.RawFormat);
                bancoMainEntities1 ht = new bancoMainEntities1();
                var id = ht.TB_USER.Where(a => a.USER_STR_EMAIL == lbRecebeEmailMenu.Text).SingleOrDefault();
                var email = id.USER_INT_ID;
                var result = ht.TB_PICTURES.SingleOrDefault(a => a.USER_INT_ID == email);
                if (result != null)
                {
                    result.PIC_IMG_MAIN = ms.ToArray();
                    ht.SaveChanges();
                }
                else
                {
                    ht.TB_PICTURES.Add(new TB_PICTURES() { PIC_IMG_MAIN = ms.ToArray(), USER_INT_ID = email });
                    ht.SaveChanges();
                }
                var item = ht.TB_PICTURES.Where(a => a.USER_INT_ID == email).FirstOrDefault();
                byte[] arr = item.PIC_IMG_MAIN;
                MemoryStream ms1 = new MemoryStream(arr);
                roundPictureBox1.Image = Image.FromStream(ms1);
                pictureBox1.Image = Image.FromStream(ms1);
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(lbRecebeEmailMenu.Text) && !String.IsNullOrEmpty(txtNome.Text) && !String.IsNullOrEmpty(txtIdade.Text) && !String.IsNullOrEmpty(txtSexo.Text))
            {
                UpdateUser(lbRecebeEmailMenu.Text, txtNome.Text, txtIdade.Text, txtSexo.Text);
            }
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectionLength = 0;
        }

        private void button28_Click(object sender, EventArgs e)
        {
            textBox5.Visible = true; 
            label9.Visible = false;
            textBox6.Visible = true;
            label10.Visible = false;
        }

        private void button29_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        protected override void WndProc(ref Message m)
        {
            const int RESIZE_HANDLE_SIZE = 10;

            switch (m.Msg)
            {
                case 0x0084/*NCHITTEST*/ :
                    base.WndProc(ref m);

                    if ((int)m.Result == 0x01/*HTCLIENT*/)
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32());
                        Point clientPoint = this.PointToClient(screenPoint);
                        if (clientPoint.Y <= RESIZE_HANDLE_SIZE)
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)3/*HTTOPLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)2/*HTTOP*/ ;
                            else
                                m.Result = (IntPtr)4/*HTTOPRIGHT*/ ;
                        }
                        else if (clientPoint.Y <= (Size.Height - RESIZE_HANDLE_SIZE))
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)1/*HTLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)2/*HTCAPTION*/ ;
                            else
                                m.Result = (IntPtr)1/*HTRIGHT*/ ;
                        }
                        else
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)6/*HTBOTTOMLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)5/*HTBOTTOM*/ ;
                            else
                                m.Result = (IntPtr)7/*HTBOTTOMRIGHT*/ ;
                        }
                    }
                    return;
            }
            base.WndProc(ref m);
        }

        private void buttonSearchText_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int s = Convert.ToInt32((sender as Button).Tag);

            bancoMainEntities1 ht = new bancoMainEntities1();
            var title = ht.TB_NOTA_STR.Where(a => a.STR_INT_ID == s).SingleOrDefault();
            textBox5.Text = title.STR_STR_TITLE;
            label12.Text = title.STR_STR_TITLE;
            textBox3.Text = title.STR_STR_PATH;
            label11.Text = title.STR_STR_PATH;
            panel4.Visible = true;
        }

        private void buttonSearchFacul_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int s = Convert.ToInt32((sender as Button).Tag);

            bancoMainEntities1 ht = new bancoMainEntities1();
            var title = ht.TB_NOTA_STR.Where(a => a.STR_INT_ID == s).SingleOrDefault();
            label14.Text = title.STR_STR_TITLE;
            label13.Text = title.STR_STR_PATH;
            panel20.Visible = true;
        }

        private void buttonSearchCurso_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int s = Convert.ToInt32((sender as Button).Tag);

            bancoMainEntities1 ht = new bancoMainEntities1();
            var title = ht.TB_NOTA_STR.Where(a => a.STR_INT_ID == s).SingleOrDefault();
            label16.Text = title.STR_STR_TITLE;
            label15.Text = title.STR_STR_PATH;
            panel30.Visible = true;
        }

        private void button20_Click(object sender, EventArgs e)
        {

            try
            {
                bancoMainEntities1 ht2 = new bancoMainEntities1();

                int noteId = Convert.ToInt32(tableLayoutPanel2.Tag);

                var itemToRemove = ht2.TB_NOTA_STR.SingleOrDefault(x => x.NOTA_INT_ID == noteId);

                var noteToRemove = ht2.TB_NOTA.SingleOrDefault(x => x.NOTA_INT_ID == noteId);

                if (itemToRemove != null && noteToRemove != null)
                {
                    ht2.TB_NOTA_STR.Remove(itemToRemove);
                    ht2.TB_NOTA.Remove(noteToRemove);
                    ht2.SaveChanges();


                    flowLayoutPanel2.Controls.Clear();
                    textBox5.Clear();
                    label9.Text = "";
                    textBox6.Clear();
                    label10.Text = "";
                    panel11.Visible = false;
                    GetNote(lbRecebeEmailMenu.Text);
                    MessageBox.Show("Nota Excluída com Sucesso");
                }
            }

            catch(Exception ex)
            {
                MessageBox.Show("Deu ruim" + ex);
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox9.Text))
            {
                flowLayoutPanel4.Controls.Clear();
                string searchContent = textBox9.Text;
                try
                {
                    bancoMainEntities1 ht2 = new bancoMainEntities1();
                    var content = ht2.TB_FACULDADE.Where(b => b.FAC_STR_NOME.Contains(searchContent)).ToList();

                    if (content.Count != 0)
                    {
                        for (int i = 0; i < content.Count; i++)
                        {
                            Button button = new Button();
                            button.Tag = content[i].FAC_INT_ID;
                            button.Text = content[i].FAC_STR_NOME;
                            button.FlatStyle = FlatStyle.Flat;
                            button.BackColor = Color.FromArgb(11, 7, 17);
                            button.Cursor = Cursors.Hand;
                            button.Height = 195;
                            button.Width = 195;
                            button.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            button.Cursor = Cursors.Hand;
                            button.Click += new EventHandler(this.buttonSearch_Click);
                            flowLayoutPanel4.Controls.Add(button);
                        }
                    }
                    else
                    {
                        TextBox txt = new TextBox();
                        txt.Text = "Não foram encontrados resultados para a sua pesquisa";
                        flowLayoutPanel4.Controls.Add(txt);
                    }
                }

                catch (Exception ex)
                {
                    ErrorProvider error = new ErrorProvider();
                }
            }
            else
            {
                try
                {
                    flowLayoutPanel4.Controls.Clear();
                    bancoMainEntities1 ht3 = new bancoMainEntities1();
                    var content = ht3.TB_FACULDADE.ToList();
                    if (content.Count != 0)
                    {
                        for (int i = 0; i < content.Count; i++)
                        {
                            Button button = new Button();
                            button.Tag = content[i].FAC_INT_ID;
                            button.Text = content[i].FAC_STR_NOME;
                            button.FlatStyle = FlatStyle.Flat;
                            button.BackColor = Color.FromArgb(11, 7, 17);
                            button.Cursor = Cursors.Hand;
                            button.Height = 195;
                            button.Width = 195;
                            button.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            button.Cursor = Cursors.Hand;
                            button.Click += new EventHandler(this.buttonSearch_Click);
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
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox10.Text))
            {
                flowLayoutPanel10.Controls.Clear();
                string searchContent = textBox10.Text;
                try
                {
                    bancoMainEntities1 ht2 = new bancoMainEntities1();

                    int facId = Convert.ToInt32(panel21.Tag);

                    var entryPoint = (from str in ht2.TB_NOTA_STR
                                      join nota in ht2.TB_NOTA on str.NOTA_INT_ID equals nota.NOTA_INT_ID
                                      where facId == nota.FAC_INT_ID
                                      select new
                                      {
                                          notaTitle = str.STR_STR_TITLE,
                                          notaId = str.STR_INT_ID
                                      }).Where(c => c.notaTitle.Contains(searchContent)).ToList();


                    if (entryPoint.Count != 0)
                    {
                        for (int i = 0; i < entryPoint.Count; i++)
                        {
                            Button button = new Button();
                            button.Tag = entryPoint[i].notaId;
                            button.Text = entryPoint[i].notaTitle;
                            button.Width = flowLayoutPanel10.Width - 5;
                            button.FlatStyle = FlatStyle.Flat;
                            button.BackColor = Color.FromArgb(11, 7, 17);
                            button.Cursor = Cursors.Hand;
                            button.Height = 75;
                            button.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            button.Cursor = Cursors.Hand;
                            button.Click += new EventHandler(this.buttonSearchFacul_Click);
                            flowLayoutPanel10.Controls.Add(button);
                        }
                    }
                    else
                    {
                        TextBox txt = new TextBox();
                        txt.Text = "Não foram encontrados resultados para a sua pesquisa";
                        flowLayoutPanel10.Controls.Add(txt);
                    }
                }

                catch (Exception ex)
                {
                    ErrorProvider error = new ErrorProvider();
                }
            }
            else
            {
                flowLayoutPanel10.Controls.Clear();
                try
                {
                    bancoMainEntities1 ht2 = new bancoMainEntities1();

                    int facId = Convert.ToInt32(panel21.Tag);

                    var entryPoint = (from str in ht2.TB_NOTA_STR
                                      join nota in ht2.TB_NOTA on str.NOTA_INT_ID equals nota.NOTA_INT_ID
                                      where facId == nota.FAC_INT_ID
                                      select new
                                      {
                                          notaTitle = str.STR_STR_TITLE,
                                          notaId = str.STR_INT_ID,
                                      }).ToList();




                    //var content = ht2.TB_NOTA_STR.Where(b => b.STR_STR_PATH.Contains(searchContent) || b.STR_STR_TITLE.Contains(searchContent)).ToList();
                    if (entryPoint.Count != 0)
                    {
                        for (int i = 0; i < entryPoint.Count; i++)
                        {
                            Button button = new Button();
                            button.Tag = entryPoint[i].notaId;
                            button.Text = entryPoint[i].notaTitle;
                            button.Width = flowLayoutPanel10.Width - 5;
                            button.FlatStyle = FlatStyle.Flat;
                            button.BackColor = Color.FromArgb(11, 7, 17);
                            button.Cursor = Cursors.Hand;
                            button.Height = 75;
                            button.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            button.Cursor = Cursors.Hand;
                            button.Click += new EventHandler(this.buttonSearchFacul_Click);
                            flowLayoutPanel10.Controls.Add(button);
                        }
                    }
                    else
                    {
                        TextBox txt = new TextBox();
                        txt.Text = "Não foram encontrados resultados para a sua pesquisa";
                        flowLayoutPanel10.Controls.Add(txt);
                    }
                }

                catch (Exception ex)
                {
                    ErrorProvider error = new ErrorProvider();
                }
            }
        }

        private void searchButtons()
        {

            flowLayoutPanel10.Controls.Clear();
            try
            {
                bancoMainEntities1 ht2 = new bancoMainEntities1();

                int facId = Convert.ToInt32(panel21.Tag);

                var entryPoint = (from str in ht2.TB_NOTA_STR
                                  join nota in ht2.TB_NOTA on str.NOTA_INT_ID equals nota.NOTA_INT_ID
                                  where facId == nota.FAC_INT_ID
                                  select new
                                  {
                                      notaTitle = str.STR_STR_TITLE,
                                      notaId = str.STR_INT_ID,
                                  }).ToList();




                //var content = ht2.TB_NOTA_STR.Where(b => b.STR_STR_PATH.Contains(searchContent) || b.STR_STR_TITLE.Contains(searchContent)).ToList();
                if (entryPoint.Count != 0)
                {
                    for (int i = 0; i < entryPoint.Count; i++)
                    {
                        Button button = new Button();
                        button.Tag = entryPoint[i].notaId;
                        button.Text = entryPoint[i].notaTitle;
                        button.Width = flowLayoutPanel10.Width - 5;
                        button.FlatStyle = FlatStyle.Flat;
                        button.BackColor = Color.FromArgb(11, 7, 17);
                        button.Cursor = Cursors.Hand;
                        button.Height = 75;
                        button.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        button.Cursor = Cursors.Hand;
                        button.Click += new EventHandler(this.buttonSearchFacul_Click);
                        flowLayoutPanel10.Controls.Add(button);
                    }
                }
                else
                {
                    TextBox txt = new TextBox();
                    txt.Text = "Não foram encontrados resultados para a sua pesquisa";
                    flowLayoutPanel10.Controls.Add(txt);
                }
            }

            catch (Exception ex)
            {
                ErrorProvider error = new ErrorProvider();
            }
        }

        private void searchButtonsCurso()
        {

            flowLayoutPanel16.Controls.Clear();
            try
            {
                bancoMainEntities1 ht2 = new bancoMainEntities1();

                int facId = Convert.ToInt32(panel29.Tag);

                var entryPoint = (from str in ht2.TB_NOTA_STR
                                  join nota in ht2.TB_NOTA on str.NOTA_INT_ID equals nota.NOTA_INT_ID
                                  where facId == nota.CUR_INT_ID
                                  select new
                                  {
                                      notaTitle = str.STR_STR_TITLE,
                                      notaId = str.STR_INT_ID,
                                  }).ToList();




                //var content = ht2.TB_NOTA_STR.Where(b => b.STR_STR_PATH.Contains(searchContent) || b.STR_STR_TITLE.Contains(searchContent)).ToList();
                if (entryPoint.Count != 0)
                {
                    for (int i = 0; i < entryPoint.Count; i++)
                    {
                        Button button = new Button();
                        button.Tag = entryPoint[i].notaId;
                        button.Text = entryPoint[i].notaTitle;
                        button.Width = flowLayoutPanel16.Width - 5;
                        button.FlatStyle = FlatStyle.Flat;
                        button.BackColor = Color.FromArgb(11, 7, 17);
                        button.Cursor = Cursors.Hand;
                        button.Height = 75;
                        button.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        button.Cursor = Cursors.Hand;
                        button.Click += new EventHandler(this.buttonSearchCurso_Click);
                        flowLayoutPanel16.Controls.Add(button);
                    }
                }
                else
                {
                    TextBox txt = new TextBox();
                    txt.Text = "Não foram encontrados resultados para a sua pesquisa";
                    flowLayoutPanel16.Controls.Add(txt);
                }
            }

            catch (Exception ex)
            {
                ErrorProvider error = new ErrorProvider();
            }
        }


        private void button33_Click(object sender, EventArgs e)
        {
            panelFacul.BringToFront();
            textBox10.Clear();
            panel20.Visible = false;
        }

        private void button34_Click(object sender, EventArgs e)
        {
            panelHome.BringToFront();
        }

        private void flowLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbCursoShow_Click(object sender, EventArgs e)
        {

        }

        private void lbFaculShow_Click(object sender, EventArgs e)
        {

        }

        private void button40_Click(object sender, EventArgs e)
        {
            panelCurso2.BringToFront();
        }
    }
}
