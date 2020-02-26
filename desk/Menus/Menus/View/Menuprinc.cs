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
                            button.Width = flowLayoutPanel2.Width -25;
                            button.FlatStyle = FlatStyle.Flat;
                            button.BackColor = Color.FromArgb(11, 7, 17);
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

        private void Label2_Click(object sender, EventArgs e)
        {

        }

		private void Button2_Click(object sender, EventArgs e)
		{
            panel7.BringToFront();
		}

		private void Button3_Click(object sender, EventArgs e)
		{
            panel10.BringToFront();


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
            lbMainTitle.Text = title.STR_STR_TITLE;
            lbMainDescription.Text = title.STR_STR_PATH;


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

            GetUser(lbRecebeEmailMenu.Text);
            lbRecebeEmailConfig.Text = lbRecebeEmailMenu.Text; 
            lbMateriaShow.Text = Login.Materia;
            lbFaculShow.Text = Login.Facul;
            lbCursoShow.Text = Login.Curso;
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

        private void button4_Click_1(object sender, EventArgs e)
        {
            panelSearch.BringToFront();
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

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
                                m.Result = (IntPtr)13/*HTTOPLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)12/*HTTOP*/ ;
                            else
                                m.Result = (IntPtr)14/*HTTOPRIGHT*/ ;
                        }
                        else if (clientPoint.Y <= (Size.Height - RESIZE_HANDLE_SIZE))
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)10/*HTLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)2/*HTCAPTION*/ ;
                            else
                                m.Result = (IntPtr)11/*HTRIGHT*/ ;
                        }
                        else
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)16/*HTBOTTOMLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)15/*HTBOTTOM*/ ;
                            else
                                m.Result = (IntPtr)17/*HTBOTTOMRIGHT*/ ;
                        }
                    }
                    return;
            }
            base.WndProc(ref m);
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
            this.Close();
        }

        private void panelSearch_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtSearchBox.Text))
            {
                flowLayoutPanel4.Controls.Clear();
                string searchContent = txtSearchBox.Text;
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
                            button.Width = flowLayoutPanel4.Width - 5;
                            button.Cursor = Cursors.Hand;
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
                flowLayoutPanel4.Controls.Clear();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panelSearch.SendToBack();
            panelFacul.BringToFront();

            try
            {
                bancoMainEntities1 ht3 = new bancoMainEntities1();
                var content = ht3.TB_FACULDADE.ToList();
                if (content.Count != 0)
                {
                    for (int i = 0; i < content.Count; i++)
                    {
                        Button button = new Button();
                        button.Tag = content[i].FAC_INT_ID;
                        button.Text = content[i].FAC_STR_NOME;
                        button.Width = flowLayoutPanel4.Width - 5;
                        button.Cursor = Cursors.Hand;
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

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            panelSearch.SendToBack();
            panel3.BringToFront();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            panelSearch.SendToBack();
            panelFacul.BringToFront();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            panelSearch.SendToBack();
            panel3.BringToFront();
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
                            button.Cursor = Cursors.Hand;
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
                flowLayoutPanel4.Controls.Clear();
            }
        }

        private void panelTexto_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
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

        private void flowLayoutPanel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            panelCurso.BringToFront();
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
            panelCurso.BringToFront();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            panelTexto.BringToFront();
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {

        }

        public string strConexao2 = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public const string strSelectUser = "SELECT U.USER_INT_ID, F.FAC_INT_ID, C.CUR_INT_ID, M.MAT_INT_ID FROM TB_USER AS U JOIN TB_FACULDADE AS F ON U.USER_INT_ID = F.USER_INT_ID JOIN TB_CURSO AS C ON U.USER_INT_ID = C.USER_INT_ID JOIN TB_MATERIA AS M ON U.USER_INT_ID = M.USER_INT_ID WHERE U.USER_STR_EMAIL = @USER_STR_EMAIL";

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
                                panel3.BringToFront();
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
            panel3.BringToFront();
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbCursoShow_Click(object sender, EventArgs e)
        {

        }

        private void lbMateria_Click(object sender, EventArgs e)
        {

        }

        private void lbCurso_Click(object sender, EventArgs e)
        {

        }

        private void lbFaculShow_Click(object sender, EventArgs e)
        {

        }

        private void lbFaculdade_Click(object sender, EventArgs e)
        {

        }

        private void lbMateriaShow_Click(object sender, EventArgs e)
        {

        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            UpdateUser(lbRecebeEmailMenu.Text, txtNome.Text, txtIdade.Text, txtSexo.Text);
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
            UpdateUser(lbRecebeEmailMenu.Text, txtNome.Text, txtIdade.Text, txtSexo.Text);
        }
    }
}
