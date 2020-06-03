namespace Menus
{
    partial class TelaLogin
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaLogin));
            this.lbusuario = new System.Windows.Forms.Label();
            this.txtusuario = new System.Windows.Forms.TextBox();
            this.lbsenha = new System.Windows.Forms.Label();
            this.txtsenha = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.roundedButton1 = new Menus.RoundedButton();
            this.roundedButton2 = new Menus.RoundedButton();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbusuario
            // 
            this.lbusuario.AutoSize = true;
            this.lbusuario.BackColor = System.Drawing.Color.Transparent;
            this.lbusuario.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbusuario.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbusuario.Location = new System.Drawing.Point(131, 132);
            this.lbusuario.Name = "lbusuario";
            this.lbusuario.Size = new System.Drawing.Size(99, 30);
            this.lbusuario.TabIndex = 0;
            this.lbusuario.Text = "Usuário";
            this.lbusuario.Click += new System.EventHandler(this.lbusuario_Click);
            // 
            // txtusuario
            // 
            this.txtusuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.txtusuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtusuario.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtusuario.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtusuario.Location = new System.Drawing.Point(22, 164);
            this.txtusuario.Name = "txtusuario";
            this.txtusuario.Size = new System.Drawing.Size(322, 30);
            this.txtusuario.TabIndex = 1;
            this.txtusuario.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lbsenha
            // 
            this.lbsenha.AutoSize = true;
            this.lbsenha.BackColor = System.Drawing.Color.Transparent;
            this.lbsenha.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbsenha.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbsenha.Location = new System.Drawing.Point(140, 210);
            this.lbsenha.Name = "lbsenha";
            this.lbsenha.Size = new System.Drawing.Size(87, 30);
            this.lbsenha.TabIndex = 0;
            this.lbsenha.Text = "Senha";
            this.lbsenha.Click += new System.EventHandler(this.lbsenha_Click);
            // 
            // txtsenha
            // 
            this.txtsenha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.txtsenha.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtsenha.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsenha.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtsenha.Location = new System.Drawing.Point(22, 242);
            this.txtsenha.Name = "txtsenha";
            this.txtsenha.PasswordChar = '*';
            this.txtsenha.Size = new System.Drawing.Size(322, 30);
            this.txtsenha.TabIndex = 2;
            this.txtsenha.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.panel1.Location = new System.Drawing.Point(22, 193);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(322, 1);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.panel2.Location = new System.Drawing.Point(22, 271);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(322, 1);
            this.panel2.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Menus.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(82, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(197, 86);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // roundedButton1
            // 
            this.roundedButton1.BackColor = System.Drawing.Color.Transparent;
            this.roundedButton1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.roundedButton1.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.roundedButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.roundedButton1.FlatAppearance.BorderSize = 0;
            this.roundedButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.roundedButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.roundedButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButton1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundedButton1.ForeColor = System.Drawing.Color.White;
            this.roundedButton1.Location = new System.Drawing.Point(17, 309);
            this.roundedButton1.Name = "roundedButton1";
            this.roundedButton1.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.roundedButton1.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.roundedButton1.OnHoverTextColor = System.Drawing.Color.White;
            this.roundedButton1.Size = new System.Drawing.Size(332, 49);
            this.roundedButton1.TabIndex = 8;
            this.roundedButton1.Text = "Login";
            this.roundedButton1.TextColor = System.Drawing.Color.White;
            this.roundedButton1.UseVisualStyleBackColor = false;
            this.roundedButton1.Click += new System.EventHandler(this.roundedButton1_Click);
            // 
            // roundedButton2
            // 
            this.roundedButton2.BackColor = System.Drawing.Color.Transparent;
            this.roundedButton2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.roundedButton2.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.roundedButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.roundedButton2.FlatAppearance.BorderSize = 0;
            this.roundedButton2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.roundedButton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.roundedButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButton2.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundedButton2.Location = new System.Drawing.Point(17, 378);
            this.roundedButton2.Name = "roundedButton2";
            this.roundedButton2.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.roundedButton2.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.roundedButton2.OnHoverTextColor = System.Drawing.Color.White;
            this.roundedButton2.Size = new System.Drawing.Size(332, 49);
            this.roundedButton2.TabIndex = 9;
            this.roundedButton2.Text = "Cadastre-se";
            this.roundedButton2.TextColor = System.Drawing.Color.White;
            this.roundedButton2.UseVisualStyleBackColor = false;
            this.roundedButton2.Click += new System.EventHandler(this.roundedButton2_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.BackgroundImage = global::Menus.Properties.Resources.signs__2___1_;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button5.Location = new System.Drawing.Point(322, 5);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(43, 42);
            this.button5.TabIndex = 10;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // TelaLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(371, 454);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.roundedButton2);
            this.Controls.Add(this.roundedButton1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtsenha);
            this.Controls.Add(this.lbsenha);
            this.Controls.Add(this.txtusuario);
            this.Controls.Add(this.lbusuario);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TelaLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.TelaLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbusuario;
        private System.Windows.Forms.TextBox txtusuario;
        private System.Windows.Forms.Label lbsenha;
        private System.Windows.Forms.TextBox txtsenha;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private RoundedButton roundedButton1;
        private RoundedButton roundedButton2;
        private System.Windows.Forms.Button button5;
    }
}

