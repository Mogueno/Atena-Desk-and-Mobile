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
using MaterialSkin.Controls;
using System.Configuration;
using System.Collections.Specialized;
using System.Drawing.Text;
using System.IO;
using System.Reflection;

namespace Menus
{
    public partial class ModalShare : Form
    {
        Thread nt;


        public ModalShare(int userId, int notaId)
        {
            InitializeComponent();
            MessageBox.Show("hello " + userId + ", nota número: " + notaId);

            lbTitle.Tag = userId;
            flowLayoutPanel1.Tag = notaId;


            flowLayoutPanel1.Controls.Clear();
            try
            {
                flowLayoutPanel1.Controls.Clear();
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

                if (entryPoint.Count != 0)
                {
                    for (int i = 0; i < entryPoint.Count; i++)
                    {
                        panel1 = new System.Windows.Forms.Panel();
                        lbName = new System.Windows.Forms.Label();
                        lbFaculdade = new System.Windows.Forms.Label();
                        lbEmail = new System.Windows.Forms.Label();
                        flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
                        pictureBox1 = new System.Windows.Forms.PictureBox();
                        //flowLayoutPanel1.SuspendLayout();
                        //panel1.SuspendLayout();
                        //this.flowLayoutPanel2.SuspendLayout();
                        ((ISupportInitialize)(this.pictureBox1)).BeginInit();

                        //
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
                        this.lbEmail.Click += new System.EventHandler(this.label3_Click);
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

                        flowLayoutPanel1.Controls.Add(panel1);
                        this.TopMost = true;
                        this.Focus();
                        this.BringToFront();
                        this.TopMost = false;
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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
            
           this.Activate();
        }

        private void lbsenha_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void shareActions_Click(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            int s = Convert.ToInt32(panel.Tag);
            int nota = Convert.ToInt32(flowLayoutPanel1.Tag);
            int user = Convert.ToInt32(lbTitle.Tag);


            MessageBox.Show("Esse é o ID do usuário " + s);

            try
            {
                bancoMainEntities1 ht = new bancoMainEntities1();

                ht.TB_SHARE.Add(new TB_SHARE() { NOTA_INT_ID = nota, RECIPIENT_INT_ID = s, SENDER_INT_ID = user });
                ht.SaveChanges();

                MessageBox.Show("Nota enviada para o usuário!");

                this.Hide();
            }
            catch (Exception ex)
            {
                ErrorProvider error = new ErrorProvider();
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
