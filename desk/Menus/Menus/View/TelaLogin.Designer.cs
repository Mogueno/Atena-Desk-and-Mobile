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
            this.lbusuario = new System.Windows.Forms.Label();
            this.txtusuario = new System.Windows.Forms.TextBox();
            this.lbsenha = new System.Windows.Forms.Label();
            this.txtsenha = new System.Windows.Forms.TextBox();
            this.btncadastrar = new System.Windows.Forms.Button();
            this.btnentrar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lbusuario
            // 
            this.lbusuario.AutoSize = true;
            this.lbusuario.BackColor = System.Drawing.Color.Transparent;
            this.lbusuario.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbusuario.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbusuario.Location = new System.Drawing.Point(131, 31);
            this.lbusuario.Name = "lbusuario";
            this.lbusuario.Size = new System.Drawing.Size(104, 29);
            this.lbusuario.TabIndex = 0;
            this.lbusuario.Text = "Usuario";
            // 
            // txtusuario
            // 
            this.txtusuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.txtusuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtusuario.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtusuario.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtusuario.Location = new System.Drawing.Point(22, 63);
            this.txtusuario.Name = "txtusuario";
            this.txtusuario.Size = new System.Drawing.Size(322, 30);
            this.txtusuario.TabIndex = 1;
            this.txtusuario.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lbsenha
            // 
            this.lbsenha.AutoSize = true;
            this.lbsenha.BackColor = System.Drawing.Color.Transparent;
            this.lbsenha.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbsenha.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbsenha.Location = new System.Drawing.Point(140, 109);
            this.lbsenha.Name = "lbsenha";
            this.lbsenha.Size = new System.Drawing.Size(87, 29);
            this.lbsenha.TabIndex = 0;
            this.lbsenha.Text = "Senha";
            this.lbsenha.Click += new System.EventHandler(this.lbsenha_Click);
            // 
            // txtsenha
            // 
            this.txtsenha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.txtsenha.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtsenha.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsenha.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtsenha.Location = new System.Drawing.Point(22, 141);
            this.txtsenha.Name = "txtsenha";
            this.txtsenha.PasswordChar = '*';
            this.txtsenha.Size = new System.Drawing.Size(322, 30);
            this.txtsenha.TabIndex = 2;
            this.txtsenha.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btncadastrar
            // 
            this.btncadastrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.btncadastrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btncadastrar.FlatAppearance.BorderSize = 0;
            this.btncadastrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncadastrar.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncadastrar.ForeColor = System.Drawing.Color.White;
            this.btncadastrar.Location = new System.Drawing.Point(22, 277);
            this.btncadastrar.Name = "btncadastrar";
            this.btncadastrar.Size = new System.Drawing.Size(322, 49);
            this.btncadastrar.TabIndex = 4;
            this.btncadastrar.Text = "CADASTRE-SE";
            this.btncadastrar.UseVisualStyleBackColor = false;
            this.btncadastrar.Click += new System.EventHandler(this.btncadastrar_Click);
            // 
            // btnentrar
            // 
            this.btnentrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.btnentrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnentrar.FlatAppearance.BorderSize = 0;
            this.btnentrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnentrar.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnentrar.ForeColor = System.Drawing.Color.White;
            this.btnentrar.Location = new System.Drawing.Point(22, 208);
            this.btnentrar.Name = "btnentrar";
            this.btnentrar.Size = new System.Drawing.Size(322, 49);
            this.btnentrar.TabIndex = 3;
            this.btnentrar.Text = "ENTRAR";
            this.btnentrar.UseVisualStyleBackColor = false;
            this.btnentrar.Click += new System.EventHandler(this.btnentrar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(22, 92);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(322, 1);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(22, 170);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(322, 1);
            this.panel2.TabIndex = 6;
            // 
            // TelaLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(371, 349);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnentrar);
            this.Controls.Add(this.btncadastrar);
            this.Controls.Add(this.txtsenha);
            this.Controls.Add(this.lbsenha);
            this.Controls.Add(this.txtusuario);
            this.Controls.Add(this.lbusuario);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TelaLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.TelaLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbusuario;
        private System.Windows.Forms.TextBox txtusuario;
        private System.Windows.Forms.Label lbsenha;
        private System.Windows.Forms.TextBox txtsenha;
        private System.Windows.Forms.Button btncadastrar;
        private System.Windows.Forms.Button btnentrar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}

