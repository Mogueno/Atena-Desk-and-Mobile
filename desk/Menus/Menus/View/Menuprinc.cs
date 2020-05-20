using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MaterialSkin.Controls;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using Transitions;
using Menus.Model;
using System.Collections.Generic;

namespace Menus
{

    public partial class Menuprinc : Form
    {
        TypeAssistant assistant;
        TypeAssistant accountUpdate;
        EntityFrameworkFunc entFunc = new EntityFrameworkFunc();
        bancoMainEntities1 ht = new bancoMainEntities1();
        public Menuprinc(string texto)
        {
            InitializeComponent();
            lbRecebeEmailMenu.Text = texto;
            Dados dataStrings = new Dados();
            assistant = new TypeAssistant();
            assistant.Idled += assistant_Idled;

            accountUpdate = new TypeAssistant();
            accountUpdate.Idled += accountUpdate_Idled;
        }

        // Insere dados se usuário ficar x tempo sem digitar ------> My Account - Seção de dados pessoais
        void accountUpdate_Idled(object sender, EventArgs e)
        {
            this.Invoke(
            new MethodInvoker(() =>
            {

                try
                {
                    var id = ht.TB_USER.Where(a => a.USER_STR_EMAIL == lbRecebeEmailMenu.Text).SingleOrDefault();
                    var email = id.USER_INT_ID;
                    var result = ht.TB_USER.SingleOrDefault(a => a.USER_INT_ID == email);
                    if (result != null)
                    {
                        result.USER_STR_NOME = txtNome.Text;
                        result.USER_INT_IDADE = Convert.ToInt32(txtIdade.Text);
                        ht.SaveChanges();

                        label10.BringToFront();
                        Transition.run(label10, "Left", 565, new TransitionType_EaseInEaseOut(50));

                        System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();

                        t.Interval = 2000;
                        t.Tick += new EventHandler(timer_Tick);
                        t.Start();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro\n\n\n\n" + ex.Message);
                }
            }));
        }

        // Insere dados se usuário ficar x tempo sem digitar
        void assistant_Idled(object sender, EventArgs e)
        {
            this.Invoke(
            new MethodInvoker(() =>
            {
                bancoMainEntities1 ht = new bancoMainEntities1();
                var id = ht.TB_USER.Where(a => a.USER_STR_EMAIL == lbRecebeEmailMenu.Text).SingleOrDefault();
                int id2 = id.USER_INT_ID;
                int strId = Convert.ToInt32(tableLayoutPanel2.Tag);
                var result = ht.TB_NOTA_STR.SingleOrDefault(a => a.STR_INT_ID == strId);

                if (result != null)
                {
                    result.STR_STR_PATH = textBox6.Text;
                    result.STR_STR_TITLE = textBox5.Text;
                    result.STR_INT_EDITED = id2;
                    ht.SaveChanges();

                    var username = (from str in ht.TB_NOTA_STR
                                    join user in ht.TB_USER on str.STR_INT_EDITED equals user.USER_INT_ID
                                    where str.STR_INT_ID == result.STR_INT_ID
                                    select new
                                    {
                                        userName = user.USER_STR_NOME,
                                    }).SingleOrDefault();
                    try
                    {
                        bancoMainEntities1 ht1 = new bancoMainEntities1();
                        var item = ht1.TB_PICTURES.Where(a => a.USER_INT_ID == id2).FirstOrDefault();
                        byte[] arr = item.PIC_IMG_MAIN;
                        MemoryStream ms1 = new MemoryStream(arr);
                        roundPictureBox2.Image = Image.FromStream(ms1);
                    }
                    catch
                    {
                        roundPictureBox2.Image = pictureBox1.InitialImage;
                    }
                    label35.Text = username.userName;
                    label10.BringToFront();
                    Transition.run(label10, "Left", 565, new TransitionType_EaseInEaseOut(50));

                    System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();


                    t.Interval = 2000;
                    t.Tick += new EventHandler(timer_Tick);
                    t.Start();
                }

            }));
        }

        public string strConexao = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public const string strSelectNote = "SELECT N1.STR_STR_PATH, N1.STR_STR_TITLE, N1.STR_INT_ID FROM TB_NOTA_STR AS N1 JOIN TB_NOTA AS N2 ON N1.STR_INT_ID = N2.STR_INT_ID JOIN TB_USER AS U ON N2.USER_INT_ID = U.USER_INT_ID WHERE U.USER_STR_EMAIL = @USER_STR_EMAIL";

        public const string strSelectUser2 = "SELECT USER_STR_NOME, USER_INT_IDADE, USER_STR_SEXO FROM TB_USER WHERE USER_STR_EMAIL = @USER_STR_EMAIL_VAR";

        public const string strUpdateUser = "UPDATE TB_USER SET USER_STR_NOME = @USER_STR_NOME, USER_INT_IDADE = @USER_INT_IDADE, USER_STR_SEXO = @USER_STR_SEXO WHERE USER_STR_EMAIL = @USER_STR_EMAIL";


        private void timer_Tick(object sender, EventArgs e)
        {
            Transition.run(label10, "Left", 5000, new TransitionType_EaseInEaseOut(50));
        }


        private void appendMaterias(int matId, string matName, string matTime)
        {
            Panel panelDynamic = new Panel();
            TextBox txtDynamic = new TextBox();
            Label lbDynamic = new Label();
            Label lbDynamic2 = new Label();
            Button btnDynamic = new Button();
            MaskedTextBox mtxtDynamic = new MaskedTextBox();
            // 
            // panelMateriaListFirst
            // 
            panelDynamic.AutoSize = true;
            panelDynamic.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            panelDynamic.Controls.Add(txtDynamic);
            panelDynamic.Controls.Add(lbDynamic);
            panelDynamic.Controls.Add(lbDynamic2);
            panelDynamic.Controls.Add(mtxtDynamic);
            panelDynamic.Controls.Add(btnDynamic);
            panelDynamic.Tag = matId;
            panelDynamic.Dock = System.Windows.Forms.DockStyle.Top;
            panelDynamic.Location = new System.Drawing.Point(0, 64);
            panelDynamic.Name = "panel57";
            panelDynamic.Size = new System.Drawing.Size(409, 31);
            panelDynamic.TabIndex = 62;
            // 
            // textBox24
            // 
            txtDynamic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            txtDynamic.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtDynamic.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtDynamic.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            txtDynamic.Location = new System.Drawing.Point(7, 5);
            txtDynamic.Size = new System.Drawing.Size(199, 22);
            txtDynamic.TabIndex = 19;
            txtDynamic.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            txtDynamic.Text = matName;
            // 
            // label47
            // 
            lbDynamic2.AutoSize = true;
            lbDynamic2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            lbDynamic2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            lbDynamic2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            lbDynamic2.Location = new System.Drawing.Point(212, 4);
            lbDynamic2.Name = "label7";
            lbDynamic2.Size = new System.Drawing.Size(58, 25);
            lbDynamic2.TabIndex = 25;
            lbDynamic2.Text = "Hora";
            // 
            // maskedTextBox6
            // 
            mtxtDynamic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            mtxtDynamic.BorderStyle = System.Windows.Forms.BorderStyle.None;
            mtxtDynamic.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            mtxtDynamic.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            mtxtDynamic.Location = new System.Drawing.Point(276, 4);
            mtxtDynamic.Mask = "00:00";
            mtxtDynamic.Text = matTime;
            mtxtDynamic.Size = new System.Drawing.Size(63, 24);
            mtxtDynamic.TabIndex = 28;
            mtxtDynamic.ValidatingType = typeof(System.DateTime);
            // 
            // button
            //
            btnDynamic.BackColor = System.Drawing.Color.Transparent;
            btnDynamic.Cursor = System.Windows.Forms.Cursors.Hand;
            btnDynamic.Dock = System.Windows.Forms.DockStyle.Right;
            btnDynamic.FlatAppearance.BorderSize = 0;
            btnDynamic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnDynamic.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnDynamic.ForeColor = System.Drawing.Color.White;
            btnDynamic.Image = global::Menus.Properties.Resources.image1;
            btnDynamic.Location = new System.Drawing.Point(350, 0);
            btnDynamic.Name = "btnDynamic";
            btnDynamic.Size = new System.Drawing.Size(59, 31);
            btnDynamic.TabIndex = 33;
            btnDynamic.UseVisualStyleBackColor = false;
            btnDynamic.Tag = matId;
            btnDynamic.Click += new EventHandler(this.removeMateria_Click);


            this.panelMateriaList.Controls.Add(panelDynamic);
        }

        private void removeMateria_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int materiaId = Convert.ToInt32(btn.Tag);
            try
            {
                var id = ht.TB_USER.Where(a => a.USER_STR_EMAIL == lbRecebeEmailMenu.Text).SingleOrDefault();
                var userId = id.USER_INT_ID;

                var itemToRemove = ht.TB_USER_MAT.SingleOrDefault(x => x.USER_INT_ID == userId && x.MAT_INT_ID == materiaId);

                ht.TB_USER_MAT.Remove(itemToRemove);
                ht.SaveChanges();

                getMateria();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Deu ruim" + ex);
            }
        }

        private void getMateria()
        {
            panelMateriaList.Controls.Clear();
            try
            {
                var id = ht.TB_USER.Where(a => a.USER_STR_EMAIL == lbRecebeEmailMenu.Text).SingleOrDefault();
                var idUser = id.USER_INT_ID;
                var content = (from str in ht.TB_USER_MAT
                               join mat in ht.TB_MATERIA on str.MAT_INT_ID equals mat.MAT_INT_ID
                               where str.USER_INT_ID == idUser
                               select new
                               {
                                   matId = str.MAT_INT_ID,
                                   matTime = str.USER_MAT_TIME_HORA,
                                   matName = mat.MAT_STR_NOME
                               }).ToList();


                for (int i = 0; i < content.Count; i++) {
                    string time = content[i].matTime.ToString();
                    TimeSpan ts = TimeSpan.Parse(time);
                    appendMaterias(content[i].matId, content[i].matName, ts.ToString(@"hh\:mm"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Deu ruim" + ex);
            }
        }

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
                        
                        if(da.GetValue(2).ToString() == "Masculino")
                        {
                            radioMasculino.Checked = true;
                        }
                        else
                        {
                            radioFeminino.Checked = true;
                        }
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
                            button.Width = flowLayoutPanel2.Width - 5;
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

        public void fetchSharedNoted(dynamic content)
        {
            if (content.Count != 0)
            {
                flowLayoutPanel28.Controls.Clear();

                button10.BackgroundImage = Properties.Resources.notification__4___1_;
                label28.Visible = true;
                label28.Text = Convert.ToString(content.Count);

                for (int i = 0; i < content.Count; i++)
                {
                    string conteudo = content[i].senderName + " enviou uma nota!";

                    Label label30 = new Label();
                    label30.AutoSize = true;
                    label30.BackColor = System.Drawing.Color.Transparent;
                    label30.Dock = System.Windows.Forms.DockStyle.Left;
                    label30.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    label30.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
                    label30.Location = new System.Drawing.Point(13, 10);
                    label30.MaximumSize = new System.Drawing.Size(380, 0);
                    label30.Size = new System.Drawing.Size(377, 87);
                    label30.Tag = content[i].shareId;
                    label30.Cursor = Cursors.Hand;
                    label30.Text = conteudo;
                    label30.Click += new EventHandler(this.showNote__click);


                    flowLayoutPanel28.Controls.Add(label30);
                }
            }
            else
            {
                button10.BackgroundImage = Properties.Resources.notification__3___1_;
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
            var name = ht.TB_USER.Where(a => a.USER_STR_EMAIL == lbRecebeEmailMenu.Text).SingleOrDefault();
            var email2 = name.USER_INT_ID;

            var title = ht.TB_NOTA_STR.Where(a => a.STR_INT_ID == s).SingleOrDefault();
            var noteParent = ht.TB_NOTA.Where(a => a.STR_INT_ID == s && a.USER_INT_ID == email2).SingleOrDefault();

            var username = (from str in ht.TB_NOTA_STR
                            join user in ht.TB_USER on str.STR_INT_EDITED equals user.USER_INT_ID
                            where str.STR_INT_ID == s
                            select new
                            {
                                userName = user.USER_STR_NOME,
                                userId = user.USER_INT_ID
                            }).SingleOrDefault();
            try
            {
                bancoMainEntities1 ht1 = new bancoMainEntities1();
                var item = ht1.TB_PICTURES.Where(a => a.USER_INT_ID == username.userId).FirstOrDefault();
                byte[] arr = item.PIC_IMG_MAIN;
                MemoryStream ms1 = new MemoryStream(arr);
                roundPictureBox2.Image = Image.FromStream(ms1);
            }
            catch
            {
                roundPictureBox2.Image = pictureBox1.InitialImage;
            }
            textBox5.Text = title.STR_STR_TITLE;
            textBox6.Text = title.STR_STR_PATH;
            label35.Text = username.userName;
            tableLayoutPanel2.Tag = title.STR_INT_ID;
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

            var path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, 12, 12);

            this.label28.Region = new Region(path);

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
            labelFaculAccount.Text = facul3.faculName;
            labelCursoAccount.Text = curso3.cursoName;

            getMateria();


            try
            {

                var id = ht2.TB_USER.Where(a => a.USER_STR_EMAIL == lbRecebeEmailMenu.Text).SingleOrDefault();
                var email = id.USER_INT_ID;

                var matList = (from mat in ht2.TB_USER_MAT
                                  join matfull in ht2.TB_MATERIA on mat.MAT_INT_ID equals matfull.MAT_INT_ID
                                  where email == mat.USER_INT_ID
                                  select new
                                  {
                                      matTitle = matfull.MAT_STR_NOME,
                                      matId = mat.MAT_INT_ID
                                  }).ToList();


                if (matList.Count != 0)
                {
                    for (int i = 0; i < matList.Count; i++)
                    {
                        Button button = new Button();
                        button.Tag = matList[i].matId;
                        button.Text = matList[i].matTitle;
                        button.FlatStyle = FlatStyle.Flat;
                        button.UseVisualStyleBackColor = false;
                        button.BackColor = Color.FromArgb(32, 32, 32);
                        button.Margin = new Padding(5);
                        button.ForeColor = Color.White;
                        button.Cursor = Cursors.Hand;
                        button.Height = 40;
                        button.Width = 371;
                        button.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        button.Cursor = Cursors.Hand;
                        button.Click += new EventHandler(this.buttonDrop_Click);
                        flowLayoutPanel18.Controls.Add(button);
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

            try
            {
                var id = ht2.TB_USER.Where(a => a.USER_STR_EMAIL == lbRecebeEmailMenu.Text).SingleOrDefault();
                var email = id.USER_INT_ID;
                var content = entFunc.getSharedNotes(email);

                fetchSharedNoted(content);
            }

            catch (Exception ex)
            {
                ErrorProvider error = new ErrorProvider();
            }
        }
        private void button4_Click_1(object sender, EventArgs e)
        {
            panelSearch.BringToFront();
        }


        private void showNote__click(object sender, EventArgs e)
        {
            Label label = sender as Label;
            int s = Convert.ToInt32(label.Tag);
            btnconcluir.Tag = s;
            confirmNote.BringToFront();

            var content = entFunc.getNoteData(s);


            label32.Text = content.notaTitle;
            label34.Text = content.notaContent;
            confirmNote.Tag = content.notaId;

            NoteData.CurId = content.notaCur;
            NoteData.FacId = content.notaFacul;
            NoteData.MatId = content.notaMat;
            NoteData.Noteid = Convert.ToInt32(content.notaChildId);
        }

        private void buttonDrop_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string s = btn.Text;
            int a = Convert.ToInt32(btn.Tag);
            txtuniversidade.Text = s;
            txtuniversidade.Tag = a;
            Transition.run(flowLayoutPanel18, "Height", 0, new TransitionType_EaseInEaseOut(250));
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

        private void buttonMatSearch_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int s = Convert.ToInt32((sender as Button).Tag);
            panel37.Tag = s;
            panelMateria__Search.BringToFront();
            searchButtonsMateria();
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

        public const string strSelectUser = "SELECT U.USER_INT_ID, F.FAC_INT_ID, C.CUR_INT_ID, M.MAT_INT_ID FROM TB_USER AS U JOIN TB_USER_FAC AS F ON U.USER_INT_ID = F.USER_INT_ID JOIN TB_USER_CUR AS C ON U.USER_INT_ID = C.USER_INT_ID JOIN TB_USER_MAT AS M ON U.USER_INT_ID = M.USER_INT_ID WHERE U.USER_STR_EMAIL = @USER_STR_EMAIL";
        // O PROBLEMA ESTA NO MAT_INT_ID

        public const string strInsertNota3 = "INSERT INTO TB_NOTA_STR OUTPUT INSERTED.STR_INT_ID VALUES (@STR_STR_PATH, @STR_STR_TITLE, @STR_INT_AUTHOR, @STR_INT_EDITED)";

        public const string strInsertNota4 = "INSERT INTO TB_NOTA VALUES (@FAC_INT_ID, @CUR_INT_ID, @MAT_INT_ID, @USER_INT_ID, @STR_INT_ID)";

        public void SelectNota(string emailRecebe, string notaRecebe, string notaTitulo, int Materia)
        {
            using (SqlConnection objConexao = new SqlConnection(strConexao2))
            {
                using (SqlCommand objCommand = new SqlCommand(strSelectUser, objConexao))
                {
                    objConexao.Open();

                    objCommand.Parameters.AddWithValue("@USER_STR_EMAIL", emailRecebe);

                    

                    string userId = "";
                    string cursoId = "";
                    int materiaId = Materia;
                    string faculdadeId = "";
                    int notaId = 0;

                    SqlDataReader da = objCommand.ExecuteReader();
                    while (da.Read())
                    {
                        userId = da.GetValue(0).ToString();
                        faculdadeId = da.GetValue(1).ToString();
                        cursoId = da.GetValue(2).ToString();
                    }

                    da.Close();

                    using (SqlCommand objCommand2 = new SqlCommand(strInsertNota3, objConexao))
                    {

                        objCommand2.Parameters.AddWithValue("@STR_STR_PATH", notaRecebe);
                        objCommand2.Parameters.AddWithValue("@STR_STR_TITLE", notaTitulo);
                        bancoMainEntities1 ht = new bancoMainEntities1();
                        var id = ht.TB_USER.Where(a => a.USER_STR_EMAIL == lbRecebeEmailMenu.Text).SingleOrDefault();
                        var idUser = id.USER_INT_ID;
                        objCommand2.Parameters.AddWithValue("@STR_INT_AUTHOR", idUser);
                        objCommand2.Parameters.AddWithValue("@STR_INT_EDITED", idUser);



                        notaId = (Int32)objCommand2.ExecuteScalar();


                        using (SqlCommand objCommand3 = new SqlCommand(strInsertNota4, objConexao))
                        {
                            objCommand3.Parameters.AddWithValue("@USER_INT_ID", userId);
                            objCommand3.Parameters.AddWithValue("@FAC_INT_ID", faculdadeId);
                            objCommand3.Parameters.AddWithValue("@CUR_INT_ID", cursoId);
                            objCommand3.Parameters.AddWithValue("@MAT_INT_ID", materiaId);
                            objCommand3.Parameters.AddWithValue("@STR_INT_ID", notaId);

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


        private void GravarNota(string EmailVar, string Nota, string Titulo, int Materia)
        {
            try
            {
                SelectNota(EmailVar, Nota, Titulo, Materia);

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
                GravarNota(lbRecebeEmailMenu.Text, txtNota.Text, txtTitle.Text, Convert.ToInt32(txtuniversidade.Tag));
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
            if (!String.IsNullOrEmpty(lbRecebeEmailMenu.Text) && !String.IsNullOrEmpty(txtNome.Text) && !String.IsNullOrEmpty(txtIdade.Text))
            {

                UpdateUser(lbRecebeEmailMenu.Text, txtNome.Text, txtIdade.Text, "masculino");
            }
        }

        private void roundPictureBox1_Click(object sender, EventArgs e)
        {
            //OpenFileDialog opendlg = new OpenFileDialog();
            //if (opendlg.ShowDialog() == DialogResult.OK)
            //{

            //    Image img = Image.FromFile(opendlg.FileName);
            //    MemoryStream ms = new MemoryStream();
            //    img.Save(ms, img.RawFormat);
            //    bancoMainEntities1 ht = new bancoMainEntities1();
            //    var id = ht.TB_USER.Where(a => a.USER_STR_EMAIL == lbRecebeEmailMenu.Text).SingleOrDefault();
            //    var email = id.USER_INT_ID;
            //    var result = ht.TB_PICTURES.SingleOrDefault(a => a.USER_INT_ID == email);
            //    if (result != null)
            //    {
            //        result.PIC_IMG_MAIN = ms.ToArray();
            //        ht.SaveChanges();
            //    }
            //    else
            //    {
            //        ht.TB_PICTURES.Add(new TB_PICTURES() { PIC_IMG_MAIN = ms.ToArray(), USER_INT_ID = email });
            //        ht.SaveChanges();
            //    }
            //    var item = ht.TB_PICTURES.Where(a => a.USER_INT_ID == email).FirstOrDefault();
            //    byte[] arr = item.PIC_IMG_MAIN;
            //    MemoryStream ms1 = new MemoryStream(arr);
            //    roundPictureBox1.Image = Image.FromStream(ms1);
            //    pictureBox1.Image = Image.FromStream(ms1);
            //}
        }

        private void button26_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(lbRecebeEmailMenu.Text) && !String.IsNullOrEmpty(txtNome.Text) && !String.IsNullOrEmpty(txtIdade.Text))
            {
                UpdateUser(lbRecebeEmailMenu.Text, txtNome.Text, txtIdade.Text, "Masculino");
            }
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectionLength = 0;
        }

        private void button28_Click(object sender, EventArgs e)
        {
            textBox5.Visible = true; 
            textBox6.Visible = true;
        }

        private void button29_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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

        private void buttonSearchMateria_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int s = Convert.ToInt32((sender as Button).Tag);

            bancoMainEntities1 ht = new bancoMainEntities1();
            var title = ht.TB_NOTA_STR.Where(a => a.STR_INT_ID == s).SingleOrDefault();
            label18.Text = title.STR_STR_TITLE;
            label17.Text = title.STR_STR_PATH;
            panel40.Visible = true;
        }

        private void button20_Click(object sender, EventArgs e)
        {

            try
            {
                bancoMainEntities1 ht2 = new bancoMainEntities1();

                int noteId = Convert.ToInt32(tableLayoutPanel2.Tag);

                var itemToRemove = ht2.TB_NOTA_STR.SingleOrDefault(x => x.STR_INT_ID == noteId);

                var noteToRemove = ht2.TB_NOTA.Where(x => x.STR_INT_ID == noteId).ToList();

                if (itemToRemove != null && noteToRemove != null)
                {
                    ht2.TB_NOTA_STR.Remove(itemToRemove);
                    for (int i = 0; i < noteToRemove.Count; i++){
                        ht2.TB_NOTA.Remove(noteToRemove[i]);
                    }
                    ht2.SaveChanges();


                    flowLayoutPanel2.Controls.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
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
                                      join nota in ht2.TB_NOTA on str.STR_INT_ID equals nota.STR_INT_ID
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
                                      join nota in ht2.TB_NOTA on str.STR_INT_ID equals nota.STR_INT_ID
                                      where facId == nota.FAC_INT_ID
                                      select new
                                      {
                                          notaTitle = str.STR_STR_TITLE,
                                          notaId = str.STR_INT_ID,
                                      }).ToList();
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
                                  join nota in ht2.TB_NOTA on str.STR_INT_ID equals nota.STR_INT_ID
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
                

                int facId = Convert.ToInt32(panel29.Tag);

                var entryPoint = entFunc.getCurso(facId);

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

        private void searchButtonsMateria()
        {

            flowLayoutPanel21.Controls.Clear();
            try
            {
                bancoMainEntities1 ht2 = new bancoMainEntities1();

                int facId = Convert.ToInt32(panel37.Tag);
                var entryPoint = entFunc.getMateria(facId);




                //var content = ht2.TB_NOTA_STR.Where(b => b.STR_STR_PATH.Contains(searchContent) || b.STR_STR_TITLE.Contains(searchContent)).ToList();
                if (entryPoint.Count != 0)
                {
                    for (int i = 0; i < entryPoint.Count; i++)
                    {
                        Button button = new Button();
                        button.Tag = entryPoint[i].notaId;
                        button.Text = entryPoint[i].notaTitle;
                        button.Width = flowLayoutPanel21.Width - 5;
                        button.FlatStyle = FlatStyle.Flat;
                        button.BackColor = Color.FromArgb(11, 7, 17);
                        button.Cursor = Cursors.Hand;
                        button.Height = 75;
                        button.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        button.Cursor = Cursors.Hand;
                        button.Click += new EventHandler(this.buttonSearchMateria_Click);
                        flowLayoutPanel21.Controls.Add(button);
                    }
                }
                else
                {
                    TextBox txt = new TextBox();
                    txt.Text = "Não foram encontrados resultados para a sua pesquisa";
                    flowLayoutPanel21.Controls.Add(txt);
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

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox12.Text))
            {
                flowLayoutPanel14.Controls.Clear();
                string searchContent = textBox12.Text;
                try
                {
                    bancoMainEntities1 ht2 = new bancoMainEntities1();
                    var content = ht2.TB_CURSO.Where(b => b.CUR_STR_NOME.Contains(searchContent)).ToList();

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
                        TextBox txt = new TextBox();
                        txt.Text = "Não foram encontrados resultados para a sua pesquisa";
                        flowLayoutPanel14.Controls.Add(txt);
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
                    flowLayoutPanel14.Controls.Clear();
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
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox15.Text))
            {
                flowLayoutPanel16.Controls.Clear();
                string searchContent = textBox15.Text;
                try
                {
                    bancoMainEntities1 ht2 = new bancoMainEntities1();

                    int facId = Convert.ToInt32(panel29.Tag);

                    var entryPoint = (from str in ht2.TB_NOTA_STR
                                      join nota in ht2.TB_NOTA on str.STR_INT_ID equals nota.STR_INT_ID
                                      where facId == nota.CUR_INT_ID
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
            else
            {
                flowLayoutPanel16.Controls.Clear();
                try
                {
                    bancoMainEntities1 ht2 = new bancoMainEntities1();

                    int facId = Convert.ToInt32(panel29.Tag);

                    var entryPoint = (from str in ht2.TB_NOTA_STR
                                      join nota in ht2.TB_NOTA on str.STR_INT_ID equals nota.STR_INT_ID
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
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void txtuniversidade_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtuniversidade_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel18.Height == 0)
            {
                Transition.run(flowLayoutPanel18, "Height", 280, new TransitionType_EaseInEaseOut(250));
            }
            else
            {
                Transition.run(flowLayoutPanel18, "Height", 0, new TransitionType_EaseInEaseOut(250));
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panelMateria.BringToFront();

            try
            {
                flowLayoutPanel19.Controls.Clear();
                bancoMainEntities1 ht3 = new bancoMainEntities1();
                var content = ht3.TB_MATERIA.ToList();
                if (content.Count != 0)
                {
                    for (int i = 0; i < content.Count; i++)
                    {
                        Button button = new Button();
                        button.Tag = content[i].MAT_INT_ID;
                        button.Text = content[i].MAT_STR_NOME;
                        button.FlatStyle = FlatStyle.Flat;
                        button.BackColor = Color.FromArgb(11, 7, 17);
                        button.Cursor = Cursors.Hand;
                        button.Height = 195;
                        button.Width = 195;
                        button.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        button.Cursor = Cursors.Hand;
                        button.Click += new EventHandler(this.buttonMatSearch_Click);
                        flowLayoutPanel19.Controls.Add(button);
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

        private void button44_Click(object sender, EventArgs e)
        {
            panelMateria.BringToFront();
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox19.Text))
            {
                flowLayoutPanel21.Controls.Clear();
                string searchContent = textBox19.Text;
                try
                {
                    bancoMainEntities1 ht2 = new bancoMainEntities1();

                    int facId = Convert.ToInt32(panel37.Tag);

                    var entryPoint = (from str in ht2.TB_NOTA_STR
                                      join nota in ht2.TB_NOTA on str.STR_INT_ID equals nota.STR_INT_ID
                                      where facId == nota.MAT_INT_ID
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
                            button.Width = flowLayoutPanel21.Width - 5;
                            button.FlatStyle = FlatStyle.Flat;
                            button.BackColor = Color.FromArgb(11, 7, 17);
                            button.Cursor = Cursors.Hand;
                            button.Height = 75;
                            button.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            button.Cursor = Cursors.Hand;
                            button.Click += new EventHandler(this.buttonSearchMateria_Click);
                            flowLayoutPanel21.Controls.Add(button);
                        }
                    }
                    else
                    {
                        TextBox txt = new TextBox();
                        txt.Text = "Não foram encontrados resultados para a sua pesquisa";
                        flowLayoutPanel21.Controls.Add(txt);
                    }
                }

                catch (Exception ex)
                {
                    ErrorProvider error = new ErrorProvider();
                }
            }
            else
            {
                flowLayoutPanel21.Controls.Clear();
                try
                {
                    bancoMainEntities1 ht2 = new bancoMainEntities1();

                    int facId = Convert.ToInt32(panel37.Tag);

                    var entryPoint = (from str in ht2.TB_NOTA_STR
                                      join nota in ht2.TB_NOTA on str.STR_INT_ID equals nota.STR_INT_ID
                                      where facId == nota.MAT_INT_ID
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
                            button.Width = flowLayoutPanel21.Width - 5;
                            button.FlatStyle = FlatStyle.Flat;
                            button.BackColor = Color.FromArgb(11, 7, 17);
                            button.Cursor = Cursors.Hand;
                            button.Height = 75;
                            button.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            button.Cursor = Cursors.Hand;
                            button.Click += new EventHandler(this.buttonSearchMateria_Click);
                            flowLayoutPanel21.Controls.Add(button);
                        }
                    }
                    else
                    {
                        TextBox txt = new TextBox();
                        txt.Text = "Não foram encontrados resultados para a sua pesquisa";
                        flowLayoutPanel21.Controls.Add(txt);
                    }
                }

                catch (Exception ex)
                {
                    ErrorProvider error = new ErrorProvider();
                }
            }
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox16.Text))
            {
                flowLayoutPanel19.Controls.Clear();
                string searchContent = textBox16.Text;
                try
                {
                    bancoMainEntities1 ht2 = new bancoMainEntities1();
                    var content = ht2.TB_MATERIA.Where(b => b.MAT_STR_NOME.Contains(searchContent)).ToList();

                    if (content.Count != 0)
                    {
                        for (int i = 0; i < content.Count; i++)
                        {
                            Button button = new Button();
                            button.Tag = content[i].MAT_INT_ID;
                            button.Text = content[i].MAT_STR_NOME;
                            button.FlatStyle = FlatStyle.Flat;
                            button.BackColor = Color.FromArgb(11, 7, 17);
                            button.Cursor = Cursors.Hand;
                            button.Height = 195;
                            button.Width = 195;
                            button.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            button.Cursor = Cursors.Hand;
                            button.Click += new EventHandler(this.buttonMatSearch_Click);
                            flowLayoutPanel19.Controls.Add(button);
                        }
                    }
                    else
                    {
                        TextBox txt = new TextBox();
                        txt.Text = "Não foram encontrados resultados para a sua pesquisa";
                        flowLayoutPanel19.Controls.Add(txt);
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
                    flowLayoutPanel19.Controls.Clear();
                    bancoMainEntities1 ht3 = new bancoMainEntities1();
                    var content = ht3.TB_MATERIA.ToList();
                    if (content.Count != 0)
                    {
                        for (int i = 0; i < content.Count; i++)
                        {
                            Button button = new Button();
                            button.Tag = content[i].MAT_INT_ID;
                            button.Text = content[i].MAT_STR_NOME;
                            button.FlatStyle = FlatStyle.Flat;
                            button.BackColor = Color.FromArgb(11, 7, 17);
                            button.Cursor = Cursors.Hand;
                            button.Height = 195;
                            button.Width = 195;
                            button.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            button.Cursor = Cursors.Hand;
                            button.Click += new EventHandler(this.buttonMatSearch_Click);
                            flowLayoutPanel19.Controls.Add(button);
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

        private void button27_Click(object sender, EventArgs e)
        {
            try
            {
                int notaId = Convert.ToInt32(tableLayoutPanel2.Tag);
                bancoMainEntities1 ht1 = new bancoMainEntities1();
                var id = ht1.TB_USER.Where(a => a.USER_STR_EMAIL == lbRecebeEmailMenu.Text).SingleOrDefault();
                var userId = id.USER_INT_ID;
                ModalShare.BringToFront();
                try
                {
                    flowLayoutPanel23.Controls.Clear();
                    bancoMainEntities1 ht3 = new bancoMainEntities1();

                    var entryPoint = (from str in ht3.TB_USER
                                      join facul1 in ht3.TB_USER_FAC on str.USER_INT_ID equals facul1.USER_INT_ID
                                      join facul2 in ht3.TB_FACULDADE on facul1.FAC_INT_ID equals facul2.FAC_INT_ID
                                      select new
                                      {
                                          userName = str.USER_STR_NOME,
                                          userEmail = str.USER_STR_EMAIL,
                                          userFac = facul2.FAC_STR_NOME,
                                          userIdentity = str.USER_INT_ID,
                                      }).ToList();

                    var sharedNotes = (from str in ht3.TB_SHARE
                                      select new
                                      {
                                          noteIdentity = str.NOTA_INT_ID,
                                          userIdentity = str.RECIPIENT_INT_ID
                                      }).ToList();
                    var noteData = (from str in ht3.TB_NOTA
                                       select new
                                       {
                                           noteIdentity = str.STR_INT_ID,
                                           userIdentity = str.USER_INT_ID
                                       }).ToList();

                    if (entryPoint.Count != 0)
                    {
                        for (int i = 0; i < entryPoint.Count; i++)
                        {
                            bool duplicate = false;

                            foreach (var entries in sharedNotes)
                            {
                                if (entries.userIdentity == entryPoint[i].userIdentity && entries.noteIdentity == notaId)
                                {
                                    duplicate = true;
                                }
                            }

                            foreach (var entries in noteData)
                            {
                                if (entries.userIdentity == entryPoint[i].userIdentity && entries.noteIdentity == notaId)
                                {
                                    duplicate = true;
                                }
                            }

                            if (duplicate == false)
                            {

                                panel1 = new System.Windows.Forms.Panel();
                                lbName = new System.Windows.Forms.Label();
                                lbFaculdade = new System.Windows.Forms.Label();
                                lbEmail = new System.Windows.Forms.Label();
                                flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
                                pictureBox1 = new System.Windows.Forms.PictureBox();

                                this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                                this.panel1.Controls.Add(this.pictureBox1);
                                this.panel1.Controls.Add(this.flowLayoutPanel2);
                                this.panel1.Location = new System.Drawing.Point(13, 13);
                                this.panel1.Name = "panel1";
                                this.panel1.Padding = new System.Windows.Forms.Padding(5);
                                this.panel1.Size = new System.Drawing.Size(548, 116);
                                this.panel1.TabIndex = 0;
                                this.panel1.Tag = entryPoint[i].userIdentity;
                                this.panel1.Click += new EventHandler(this.shareActions_Click);

                                if (entryPoint[i].userIdentity == userId)
                                {
                                    panel1.Visible = false;
                                }
                                panel1.Cursor = Cursors.Hand;
                                // 
                                // lbName
                                // 
                                this.lbName.AutoSize = true;
                                this.lbName.BackColor = System.Drawing.Color.Transparent;
                                this.lbName.Font = new System.Drawing.Font("Verdana", 15F);
                                this.lbName.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
                                this.lbName.Location = new System.Drawing.Point(3, 10);
                                this.lbName.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
                                this.lbName.Name = "lbName";
                                this.lbName.Size = new System.Drawing.Size(189, 25);
                                this.lbName.TabIndex = 1;
                                this.lbName.Text = entryPoint[i].userName;
                                this.lbName.Tag = entryPoint[i].userIdentity;
                                this.lbName.Click += new EventHandler(this.shareActionsLabel_Click);
                                lbName.Cursor = Cursors.Hand;
                                // 
                                // lbFaculdade
                                // 
                                this.lbFaculdade.AutoSize = true;
                                this.lbFaculdade.BackColor = System.Drawing.Color.Transparent;
                                this.lbFaculdade.Font = new System.Drawing.Font("Verdana", 13F);
                                this.lbFaculdade.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
                                this.lbFaculdade.Location = new System.Drawing.Point(3, 77);
                                this.lbFaculdade.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
                                this.lbFaculdade.Name = "lbFaculdade";
                                this.lbFaculdade.Size = new System.Drawing.Size(166, 22);
                                this.lbFaculdade.TabIndex = 2;
                                this.lbFaculdade.Text = entryPoint[i].userFac;
                                this.lbFaculdade.Tag = entryPoint[i].userIdentity;
                                this.lbFaculdade.Click += new EventHandler(this.shareActionsLabel_Click);
                                lbFaculdade.Cursor = Cursors.Hand;
                                // 
                                // lbEmail
                                // 
                                this.lbEmail.AutoSize = true;
                                this.lbEmail.BackColor = System.Drawing.Color.Transparent;
                                this.lbEmail.Font = new System.Drawing.Font("Verdana", 13F);
                                this.lbEmail.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
                                this.lbEmail.Location = new System.Drawing.Point(3, 45);
                                this.lbEmail.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
                                this.lbEmail.Name = "lbEmail";
                                this.lbEmail.Size = new System.Drawing.Size(166, 22);
                                this.lbEmail.TabIndex = 3;
                                this.lbEmail.Text = entryPoint[i].userEmail;
                                this.lbEmail.Tag = entryPoint[i].userIdentity;
                                this.lbEmail.Click += new EventHandler(this.shareActionsLabel_Click);
                                lbEmail.Cursor = Cursors.Hand;
                                //this.lbEmail.Click += new System.EventHandler(this.label3_Click);
                                // 
                                // flowLayoutPanel2
                                // 
                                this.flowLayoutPanel2.Controls.Add(this.lbName);
                                this.flowLayoutPanel2.Controls.Add(this.lbEmail);
                                this.flowLayoutPanel2.Controls.Add(this.lbFaculdade);
                                this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
                                this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
                                this.flowLayoutPanel2.Location = new System.Drawing.Point(117, 5);
                                this.flowLayoutPanel2.Name = "flowLayoutPanel2";
                                this.flowLayoutPanel2.Size = new System.Drawing.Size(426, 106);
                                this.flowLayoutPanel2.TabIndex = 4;
                                this.flowLayoutPanel2.Tag = entryPoint[i].userIdentity;
                                this.flowLayoutPanel2.Click += new EventHandler(this.shareActionsFlow_Click);
                                flowLayoutPanel2.Cursor = Cursors.Hand;
                                // 
                                // pictureBox1
                                // 
                                this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
                                this.pictureBox1.Location = new System.Drawing.Point(5, 5);
                                this.pictureBox1.Name = "pictureBox1";
                                this.pictureBox1.Size = new System.Drawing.Size(106, 106);
                                this.pictureBox1.TabIndex = 5;
                                this.pictureBox1.TabStop = false;
                                this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                                this.pictureBox1.InitialImage = global::Menus.Properties.Resources.User_icon_BLACK_01;
                                this.pictureBox1.Tag = entryPoint[i].userIdentity;
                                this.pictureBox1.Click += new EventHandler(this.shareActionsPic_Click);
                                pictureBox1.Cursor = Cursors.Hand;



                                try
                                {
                                    bancoMainEntities1 ht = new bancoMainEntities1();

                                    int idFinal = entryPoint[i].userIdentity;
                                    var item = ht.TB_PICTURES.Where(a => a.USER_INT_ID == idFinal).FirstOrDefault();
                                    byte[] arr = item.PIC_IMG_MAIN;
                                    MemoryStream ms1 = new MemoryStream(arr);
                                    pictureBox1.Image = Image.FromStream(ms1);
                                }
                                catch
                                {
                                    pictureBox1.Image = pictureBox1.InitialImage;
                                }

                                flowLayoutPanel23.Controls.Add(panel1);
                                this.TopMost = true;
                                this.Focus();
                                this.BringToFront();
                                this.TopMost = false;
                            }
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
            catch
            {
            }
        }
        
        private void shareActionsPic_Click(object sender, EventArgs e)
        {
            PictureBox panel = sender as PictureBox;
            int s = Convert.ToInt32(panel.Tag);

            int notaId = Convert.ToInt32(tableLayoutPanel2.Tag);
            bancoMainEntities1 ht1 = new bancoMainEntities1();
            var id = ht1.TB_USER.Where(a => a.USER_STR_EMAIL == lbRecebeEmailMenu.Text).SingleOrDefault();
            var userId = id.USER_INT_ID;

            int nota = Convert.ToInt32(notaId);
            int user = Convert.ToInt32(userId);


            MessageBox.Show("Esse é o ID do usuário " + s);

            try
            {
                bancoMainEntities1 ht = new bancoMainEntities1();

                ht.TB_SHARE.Add(new TB_SHARE() { NOTA_INT_ID = nota, RECIPIENT_INT_ID = s, SENDER_INT_ID = user });
                ht.SaveChanges();

                MessageBox.Show("Nota enviada para o usuário!");

                ModalShare.SendToBack();
            }
            catch (Exception ex)
            {
                ErrorProvider error = new ErrorProvider();
            }
        }
        private void shareActionsFlow_Click(object sender, EventArgs e)
        {
            FlowLayoutPanel panel = sender as FlowLayoutPanel;
            int s = Convert.ToInt32(panel.Tag);

            int notaId = Convert.ToInt32(tableLayoutPanel2.Tag);
            bancoMainEntities1 ht1 = new bancoMainEntities1();
            var id = ht1.TB_USER.Where(a => a.USER_STR_EMAIL == lbRecebeEmailMenu.Text).SingleOrDefault();
            var userId = id.USER_INT_ID;

            int nota = Convert.ToInt32(notaId);
            int user = Convert.ToInt32(userId);


            MessageBox.Show("Esse é o ID do usuário " + s);

            try
            {
                bancoMainEntities1 ht = new bancoMainEntities1();

                ht.TB_SHARE.Add(new TB_SHARE() { NOTA_INT_ID = nota, RECIPIENT_INT_ID = s, SENDER_INT_ID = user });
                ht.SaveChanges();

                MessageBox.Show("Nota enviada para o usuário!");

                ModalShare.SendToBack();
            }
            catch (Exception ex)
            {
                ErrorProvider error = new ErrorProvider();
            }
        }
        private void shareActionsLabel_Click(object sender, EventArgs e)
        {
            Label panel = sender as Label;
            int s = Convert.ToInt32(panel.Tag);

            int notaId = Convert.ToInt32(tableLayoutPanel2.Tag);
            bancoMainEntities1 ht1 = new bancoMainEntities1();
            var id = ht1.TB_USER.Where(a => a.USER_STR_EMAIL == lbRecebeEmailMenu.Text).SingleOrDefault();
            var userId = id.USER_INT_ID;

            int nota = Convert.ToInt32(notaId);
            int user = Convert.ToInt32(userId);


            MessageBox.Show("Esse é o ID do usuário " + s);

            try
            {
                bancoMainEntities1 ht = new bancoMainEntities1();

                ht.TB_SHARE.Add(new TB_SHARE() { NOTA_INT_ID = nota, RECIPIENT_INT_ID = s, SENDER_INT_ID = user });
                ht.SaveChanges();

                MessageBox.Show("Nota enviada para o usuário!");

                ModalShare.SendToBack();
            }
            catch (Exception ex)
            {
                ErrorProvider error = new ErrorProvider();
            }
        }

        private void shareActions_Click(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            int s = Convert.ToInt32(panel.Tag);

            int notaId = Convert.ToInt32(tableLayoutPanel2.Tag);
            bancoMainEntities1 ht1 = new bancoMainEntities1();
            var id = ht1.TB_USER.Where(a => a.USER_STR_EMAIL == lbRecebeEmailMenu.Text).SingleOrDefault();
            var userId = id.USER_INT_ID;

            int nota = Convert.ToInt32(notaId);
            int user = Convert.ToInt32(userId);


            MessageBox.Show("Esse é o ID do usuário " + s);

            try
            {
                bancoMainEntities1 ht = new bancoMainEntities1();

                ht.TB_SHARE.Add(new TB_SHARE() { NOTA_INT_ID = nota, RECIPIENT_INT_ID = s, SENDER_INT_ID = user });
                ht.SaveChanges();

                MessageBox.Show("Nota enviada para o usuário!");

                ModalShare.SendToBack();
            }
            catch (Exception ex)
            {
                ErrorProvider error = new ErrorProvider();
            }
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel28_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            modalNotify.Visible = true;
            modalNotify.BringToFront();
        }

        private void button45_Click(object sender, EventArgs e)
        {
            modalNotify.Visible = false;
        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void btnconcluir_Click(object sender, EventArgs e)
        {
            bancoMainEntities1 ht1 = new bancoMainEntities1();
            var id = ht1.TB_USER.Where(a => a.USER_STR_EMAIL == lbRecebeEmailMenu.Text).SingleOrDefault();
            var userId = id.USER_INT_ID;

            MessageBox.Show("ta ai " + NoteData.FacId+ " " + NoteData.CurId + " " + NoteData.MatId);

            ht1.TB_NOTA.Add(new TB_NOTA() { FAC_INT_ID = NoteData.FacId, CUR_INT_ID = NoteData.CurId, MAT_INT_ID = NoteData.MatId, USER_INT_ID = userId, STR_INT_ID = NoteData.Noteid });
            ht1.SaveChanges();

            int shareId = Convert.ToInt32(btnconcluir.Tag);


            var notificationToRemove = ht1.TB_SHARE.SingleOrDefault(x => x.SHARE_INT_ID == shareId);

            if (notificationToRemove != null)
            {
                ht1.TB_SHARE.Remove(notificationToRemove);
                ht1.SaveChanges();


                flowLayoutPanel28.Controls.Clear();
                try
                {
                    bancoMainEntities1 ht2 = new bancoMainEntities1();
                    var id2 = ht2.TB_USER.Where(a => a.USER_STR_EMAIL == lbRecebeEmailMenu.Text).SingleOrDefault();
                    var email = id2.USER_INT_ID;
                    var content = (from str in ht2.TB_SHARE
                                   join send in ht2.TB_USER on str.SENDER_INT_ID equals send.USER_INT_ID
                                   join recipient in ht2.TB_USER on str.RECIPIENT_INT_ID equals recipient.USER_INT_ID
                                   join nota in ht2.TB_NOTA on str.NOTA_INT_ID equals nota.STR_INT_ID
                                   join notaChild in ht2.TB_NOTA_STR on nota.STR_INT_ID equals notaChild.STR_INT_ID
                                   where email == recipient.USER_INT_ID
                                   select new
                                   {
                                       shareId = str.SHARE_INT_ID,
                                       senderName = send.USER_STR_NOME
                                   }).ToList();

                    fetchSharedNoted(content);
                }

                catch (Exception ex)
                {
                    ErrorProvider error = new ErrorProvider();
                }
            }


            flowLayoutPanel2.Controls.Clear();
            confirmNote.SendToBack();
            GetNote(lbRecebeEmailMenu.Text);
        }

        private void button46_Click(object sender, EventArgs e)
        {
            confirmNote.SendToBack();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            autoSizeTxt(textBox5);
        }



        private void autoSizeTxt(TextBox txt)
        {
            // get number of lines (first line is 0, so add 1)
            int numLines = txt.GetLineFromCharIndex(txt.TextLength) + 2;
            // set height (height of one line * number of lines + spacing)
            txt.Height = txt.Font.Height * numLines;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            autoSizeTxt(textBox6);


            
        }

        private void textBox5_KeyUp(object sender, KeyEventArgs e)
        {
            assistant.TextChanged();
        }

        private void SearchTextBoxTimer_Tick(object sender, EventArgs e)
        {
            
        }

        private void panel44_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button28_Click_1(object sender, EventArgs e)
        {
            ModalShare.SendToBack();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void textBox6_KeyUp(object sender, KeyEventArgs e)
        {
            assistant.TextChanged();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button47_Click(object sender, EventArgs e)
        {

            if(this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
            
        }

        private void panelMinhaConta_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button13_Click_1(object sender, EventArgs e)
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

        private void txtNome_KeyUp(object sender, KeyEventArgs e)
        {
            if (!String.IsNullOrEmpty(lbRecebeEmailMenu.Text) && !String.IsNullOrEmpty(txtNome.Text) && !String.IsNullOrEmpty(txtIdade.Text))
            {
                accountUpdate.TextChanged();
            }
            else
            {
                MessageBox.Show("Um ou mais campos estão vazios!");
            }
        }

        private void panel51_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioMasculino_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = sender as RadioButton;
            string text = radio.Text;

            
            var id = ht.TB_USER.Where(a => a.USER_STR_EMAIL == lbRecebeEmailMenu.Text).SingleOrDefault();
            var email = id.USER_INT_ID;
            var result = ht.TB_USER.SingleOrDefault(a => a.USER_INT_ID == email);
            if (result != null)
            {
                result.USER_STR_SEXO = text;
                ht.SaveChanges();
            }
        
        }
    }
}
