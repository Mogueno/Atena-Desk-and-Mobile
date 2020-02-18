namespace Menus
{
	partial class TelaConfiguracao
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaConfiguracao));
            this.btnAtualizar = new MaterialSkin.Controls.MaterialFlatButton();
            this.txtSexo = new System.Windows.Forms.TextBox();
            this.txtIdade = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lbIdade = new MaterialSkin.Controls.MaterialLabel();
            this.lbSexo = new MaterialSkin.Controls.MaterialLabel();
            this.lbNome = new MaterialSkin.Controls.MaterialLabel();
            this.lbDados = new System.Windows.Forms.Label();
            this.lbRecebeEmailConfig = new System.Windows.Forms.Label();
            this.lbFaculdade = new MaterialSkin.Controls.MaterialLabel();
            this.lbCurso = new MaterialSkin.Controls.MaterialLabel();
            this.lbMateria = new MaterialSkin.Controls.MaterialLabel();
            this.lbFaculShow = new MaterialSkin.Controls.MaterialLabel();
            this.lbCursoShow = new MaterialSkin.Controls.MaterialLabel();
            this.lbMateriaShow = new MaterialSkin.Controls.MaterialLabel();
            this.btnVoltar2 = new MaterialSkin.Controls.MaterialFlatButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.txtHello = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.AutoSize = true;
            this.btnAtualizar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAtualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAtualizar.Depth = 0;
            this.btnAtualizar.Location = new System.Drawing.Point(361, 253);
            this.btnAtualizar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAtualizar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Primary = false;
            this.btnAtualizar.Size = new System.Drawing.Size(85, 36);
            this.btnAtualizar.TabIndex = 3;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // txtSexo
            // 
            this.txtSexo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSexo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtSexo.Location = new System.Drawing.Point(7, 130);
            this.txtSexo.Name = "txtSexo";
            this.txtSexo.Size = new System.Drawing.Size(411, 17);
            this.txtSexo.TabIndex = 1;
            this.txtSexo.TextChanged += new System.EventHandler(this.txtSexo_TextChanged);
            // 
            // txtIdade
            // 
            this.txtIdade.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIdade.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtIdade.Location = new System.Drawing.Point(7, 183);
            this.txtIdade.Name = "txtIdade";
            this.txtIdade.Size = new System.Drawing.Size(410, 17);
            this.txtIdade.TabIndex = 2;
            this.txtIdade.TextChanged += new System.EventHandler(this.txtIdade_TextChanged);
            // 
            // txtNome
            // 
            this.txtNome.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtNome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtNome.Location = new System.Drawing.Point(7, 34);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(411, 17);
            this.txtNome.TabIndex = 0;
            this.txtNome.TextChanged += new System.EventHandler(this.txtNome_TextChanged);
            // 
            // lbIdade
            // 
            this.lbIdade.AutoSize = true;
            this.lbIdade.BackColor = System.Drawing.Color.White;
            this.lbIdade.Depth = 0;
            this.lbIdade.Font = new System.Drawing.Font("Roboto", 11F);
            this.lbIdade.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbIdade.Location = new System.Drawing.Point(3, 161);
            this.lbIdade.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbIdade.Name = "lbIdade";
            this.lbIdade.Size = new System.Drawing.Size(45, 19);
            this.lbIdade.TabIndex = 18;
            this.lbIdade.Text = "Idade";
            this.lbIdade.Click += new System.EventHandler(this.lbIdade_Click);
            // 
            // lbSexo
            // 
            this.lbSexo.AutoSize = true;
            this.lbSexo.BackColor = System.Drawing.Color.White;
            this.lbSexo.Depth = 0;
            this.lbSexo.Font = new System.Drawing.Font("Roboto", 11F);
            this.lbSexo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbSexo.Location = new System.Drawing.Point(3, 108);
            this.lbSexo.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbSexo.Name = "lbSexo";
            this.lbSexo.Size = new System.Drawing.Size(42, 19);
            this.lbSexo.TabIndex = 14;
            this.lbSexo.Text = "Sexo";
            this.lbSexo.Click += new System.EventHandler(this.lbSexo_Click);
            // 
            // lbNome
            // 
            this.lbNome.AutoSize = true;
            this.lbNome.BackColor = System.Drawing.Color.White;
            this.lbNome.Depth = 0;
            this.lbNome.Font = new System.Drawing.Font("Roboto", 11F);
            this.lbNome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbNome.Location = new System.Drawing.Point(3, 12);
            this.lbNome.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbNome.Name = "lbNome";
            this.lbNome.Size = new System.Drawing.Size(50, 19);
            this.lbNome.TabIndex = 17;
            this.lbNome.Text = "Nome";
            this.lbNome.Click += new System.EventHandler(this.lbNome_Click);
            // 
            // lbDados
            // 
            this.lbDados.AutoSize = true;
            this.lbDados.BackColor = System.Drawing.Color.White;
            this.lbDados.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDados.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbDados.Location = new System.Drawing.Point(189, 86);
            this.lbDados.Name = "lbDados";
            this.lbDados.Size = new System.Drawing.Size(297, 55);
            this.lbDados.TabIndex = 13;
            this.lbDados.Text = "Minha Conta";
            this.lbDados.Click += new System.EventHandler(this.lbDados_Click);
            // 
            // lbRecebeEmailConfig
            // 
            this.lbRecebeEmailConfig.AutoSize = true;
            this.lbRecebeEmailConfig.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbRecebeEmailConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lbRecebeEmailConfig.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbRecebeEmailConfig.Location = new System.Drawing.Point(13, 82);
            this.lbRecebeEmailConfig.Name = "lbRecebeEmailConfig";
            this.lbRecebeEmailConfig.Size = new System.Drawing.Size(0, 18);
            this.lbRecebeEmailConfig.TabIndex = 30;
            this.lbRecebeEmailConfig.Click += new System.EventHandler(this.lbRecebeEmailConfig_Click);
            // 
            // lbFaculdade
            // 
            this.lbFaculdade.AutoSize = true;
            this.lbFaculdade.BackColor = System.Drawing.Color.White;
            this.lbFaculdade.Depth = 0;
            this.lbFaculdade.Font = new System.Drawing.Font("Roboto", 11F);
            this.lbFaculdade.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbFaculdade.Location = new System.Drawing.Point(881, 181);
            this.lbFaculdade.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbFaculdade.Name = "lbFaculdade";
            this.lbFaculdade.Size = new System.Drawing.Size(94, 19);
            this.lbFaculdade.TabIndex = 17;
            this.lbFaculdade.Text = "FACULDADE";
            this.lbFaculdade.Click += new System.EventHandler(this.lbFaculdade_Click);
            // 
            // lbCurso
            // 
            this.lbCurso.AutoSize = true;
            this.lbCurso.BackColor = System.Drawing.Color.White;
            this.lbCurso.Depth = 0;
            this.lbCurso.Font = new System.Drawing.Font("Roboto", 11F);
            this.lbCurso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbCurso.Location = new System.Drawing.Point(881, 237);
            this.lbCurso.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbCurso.Name = "lbCurso";
            this.lbCurso.Size = new System.Drawing.Size(57, 19);
            this.lbCurso.TabIndex = 14;
            this.lbCurso.Text = "CURSO";
            this.lbCurso.Click += new System.EventHandler(this.lbCurso_Click);
            // 
            // lbMateria
            // 
            this.lbMateria.AutoSize = true;
            this.lbMateria.BackColor = System.Drawing.Color.White;
            this.lbMateria.Depth = 0;
            this.lbMateria.Font = new System.Drawing.Font("Roboto", 11F);
            this.lbMateria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbMateria.Location = new System.Drawing.Point(881, 295);
            this.lbMateria.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbMateria.Name = "lbMateria";
            this.lbMateria.Size = new System.Drawing.Size(73, 19);
            this.lbMateria.TabIndex = 18;
            this.lbMateria.Text = "MATÉRIA";
            this.lbMateria.Click += new System.EventHandler(this.lbMateria_Click);
            // 
            // lbFaculShow
            // 
            this.lbFaculShow.AutoSize = true;
            this.lbFaculShow.BackColor = System.Drawing.Color.White;
            this.lbFaculShow.Depth = 0;
            this.lbFaculShow.Font = new System.Drawing.Font("Roboto", 11F);
            this.lbFaculShow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbFaculShow.Location = new System.Drawing.Point(885, 256);
            this.lbFaculShow.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbFaculShow.Name = "lbFaculShow";
            this.lbFaculShow.Size = new System.Drawing.Size(0, 19);
            this.lbFaculShow.TabIndex = 17;
            this.lbFaculShow.Click += new System.EventHandler(this.lbFaculShow_Click);
            // 
            // lbCursoShow
            // 
            this.lbCursoShow.AutoSize = true;
            this.lbCursoShow.BackColor = System.Drawing.Color.White;
            this.lbCursoShow.Depth = 0;
            this.lbCursoShow.Font = new System.Drawing.Font("Roboto", 11F);
            this.lbCursoShow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbCursoShow.Location = new System.Drawing.Point(885, 203);
            this.lbCursoShow.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbCursoShow.Name = "lbCursoShow";
            this.lbCursoShow.Size = new System.Drawing.Size(0, 19);
            this.lbCursoShow.TabIndex = 14;
            this.lbCursoShow.Click += new System.EventHandler(this.lbCursoShow_Click);
            // 
            // lbMateriaShow
            // 
            this.lbMateriaShow.AutoSize = true;
            this.lbMateriaShow.BackColor = System.Drawing.Color.White;
            this.lbMateriaShow.Depth = 0;
            this.lbMateriaShow.Font = new System.Drawing.Font("Roboto", 11F);
            this.lbMateriaShow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbMateriaShow.Location = new System.Drawing.Point(885, 314);
            this.lbMateriaShow.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbMateriaShow.Name = "lbMateriaShow";
            this.lbMateriaShow.Size = new System.Drawing.Size(0, 19);
            this.lbMateriaShow.TabIndex = 18;
            this.lbMateriaShow.Click += new System.EventHandler(this.lbMateriaShow_Click);
            // 
            // btnVoltar2
            // 
            this.btnVoltar2.AutoSize = true;
            this.btnVoltar2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnVoltar2.BackColor = System.Drawing.SystemColors.Control;
            this.btnVoltar2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVoltar2.Depth = 0;
            this.btnVoltar2.Location = new System.Drawing.Point(12, 282);
            this.btnVoltar2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnVoltar2.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnVoltar2.Name = "btnVoltar2";
            this.btnVoltar2.Primary = false;
            this.btnVoltar2.Size = new System.Drawing.Size(64, 36);
            this.btnVoltar2.TabIndex = 31;
            this.btnVoltar2.Text = "VOLTAR";
            this.btnVoltar2.UseVisualStyleBackColor = false;
            this.btnVoltar2.Click += new System.EventHandler(this.btnVoltar2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 86);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(148, 147);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 33;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.pictureBox1.MouseHover += new System.EventHandler(this.pictureBox1_MouseHover);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.BackColor = System.Drawing.Color.White;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(3, 63);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(51, 19);
            this.materialLabel1.TabIndex = 34;
            this.materialLabel1.Text = "E-mail";
            // 
            // txtHello
            // 
            this.txtHello.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtHello.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtHello.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtHello.Location = new System.Drawing.Point(12, 251);
            this.txtHello.Name = "txtHello";
            this.txtHello.Size = new System.Drawing.Size(148, 17);
            this.txtHello.TabIndex = 35;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtNome);
            this.panel1.Controls.Add(this.materialLabel1);
            this.panel1.Controls.Add(this.btnAtualizar);
            this.panel1.Controls.Add(this.txtSexo);
            this.panel1.Controls.Add(this.txtIdade);
            this.panel1.Controls.Add(this.lbRecebeEmailConfig);
            this.panel1.Controls.Add(this.lbSexo);
            this.panel1.Controls.Add(this.lbNome);
            this.panel1.Controls.Add(this.lbIdade);
            this.panel1.Location = new System.Drawing.Point(197, 168);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 295);
            this.panel1.TabIndex = 36;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // TelaConfiguracao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1386, 788);
            this.ControlBox = false;
            this.Controls.Add(this.txtHello);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnVoltar2);
            this.Controls.Add(this.lbMateriaShow);
            this.Controls.Add(this.lbCursoShow);
            this.Controls.Add(this.lbMateria);
            this.Controls.Add(this.lbCurso);
            this.Controls.Add(this.lbFaculShow);
            this.Controls.Add(this.lbFaculdade);
            this.Controls.Add(this.lbDados);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(58)))), ((int)(((byte)(55)))));
            this.Name = "TelaConfiguracao";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Configurações";
            this.Load += new System.EventHandler(this.TelaConfiguracao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private MaterialSkin.Controls.MaterialFlatButton btnAtualizar;
		private System.Windows.Forms.TextBox txtSexo;
		private System.Windows.Forms.TextBox txtIdade;
		private System.Windows.Forms.TextBox txtNome;
		private MaterialSkin.Controls.MaterialLabel lbIdade;
		private MaterialSkin.Controls.MaterialLabel lbSexo;
		private MaterialSkin.Controls.MaterialLabel lbNome;
		private System.Windows.Forms.Label lbDados;
        private System.Windows.Forms.Label lbRecebeEmailConfig;
        private MaterialSkin.Controls.MaterialLabel lbFaculdade;
        private MaterialSkin.Controls.MaterialLabel lbCurso;
        private MaterialSkin.Controls.MaterialLabel lbMateria;
        private MaterialSkin.Controls.MaterialLabel lbFaculShow;
        private MaterialSkin.Controls.MaterialLabel lbCursoShow;
        private MaterialSkin.Controls.MaterialLabel lbMateriaShow;
        private MaterialSkin.Controls.MaterialFlatButton btnVoltar2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.TextBox txtHello;
        private System.Windows.Forms.Panel panel1;
    }
}