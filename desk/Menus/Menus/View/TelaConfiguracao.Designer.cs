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
            this.SuspendLayout();
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.AutoSize = true;
            this.btnAtualizar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAtualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAtualizar.Depth = 0;
            this.btnAtualizar.Location = new System.Drawing.Point(495, 351);
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
            this.txtSexo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtSexo.Location = new System.Drawing.Point(184, 189);
            this.txtSexo.Name = "txtSexo";
            this.txtSexo.Size = new System.Drawing.Size(411, 24);
            this.txtSexo.TabIndex = 1;
            // 
            // txtIdade
            // 
            this.txtIdade.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtIdade.Location = new System.Drawing.Point(184, 218);
            this.txtIdade.Name = "txtIdade";
            this.txtIdade.Size = new System.Drawing.Size(410, 24);
            this.txtIdade.TabIndex = 2;
            // 
            // txtNome
            // 
            this.txtNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtNome.Location = new System.Drawing.Point(184, 159);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(411, 24);
            this.txtNome.TabIndex = 0;
            // 
            // lbIdade
            // 
            this.lbIdade.AutoSize = true;
            this.lbIdade.BackColor = System.Drawing.Color.White;
            this.lbIdade.Depth = 0;
            this.lbIdade.Font = new System.Drawing.Font("Roboto", 11F);
            this.lbIdade.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbIdade.Location = new System.Drawing.Point(37, 217);
            this.lbIdade.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbIdade.Name = "lbIdade";
            this.lbIdade.Size = new System.Drawing.Size(52, 19);
            this.lbIdade.TabIndex = 18;
            this.lbIdade.Text = "IDADE";
            // 
            // lbSexo
            // 
            this.lbSexo.AutoSize = true;
            this.lbSexo.BackColor = System.Drawing.Color.White;
            this.lbSexo.Depth = 0;
            this.lbSexo.Font = new System.Drawing.Font("Roboto", 11F);
            this.lbSexo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbSexo.Location = new System.Drawing.Point(37, 188);
            this.lbSexo.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbSexo.Name = "lbSexo";
            this.lbSexo.Size = new System.Drawing.Size(46, 19);
            this.lbSexo.TabIndex = 14;
            this.lbSexo.Text = "SEXO";
            // 
            // lbNome
            // 
            this.lbNome.AutoSize = true;
            this.lbNome.BackColor = System.Drawing.Color.White;
            this.lbNome.Depth = 0;
            this.lbNome.Font = new System.Drawing.Font("Roboto", 11F);
            this.lbNome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbNome.Location = new System.Drawing.Point(37, 160);
            this.lbNome.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbNome.Name = "lbNome";
            this.lbNome.Size = new System.Drawing.Size(52, 19);
            this.lbNome.TabIndex = 17;
            this.lbNome.Text = "NOME";
            // 
            // lbDados
            // 
            this.lbDados.AutoSize = true;
            this.lbDados.BackColor = System.Drawing.Color.White;
            this.lbDados.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDados.Location = new System.Drawing.Point(200, 80);
            this.lbDados.Name = "lbDados";
            this.lbDados.Size = new System.Drawing.Size(226, 37);
            this.lbDados.TabIndex = 13;
            this.lbDados.Text = "SEUS DADOS";
            // 
            // lbRecebeEmailConfig
            // 
            this.lbRecebeEmailConfig.AutoSize = true;
            this.lbRecebeEmailConfig.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbRecebeEmailConfig.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbRecebeEmailConfig.Location = new System.Drawing.Point(41, 98);
            this.lbRecebeEmailConfig.Name = "lbRecebeEmailConfig";
            this.lbRecebeEmailConfig.Size = new System.Drawing.Size(0, 13);
            this.lbRecebeEmailConfig.TabIndex = 30;
            // 
            // lbFaculdade
            // 
            this.lbFaculdade.AutoSize = true;
            this.lbFaculdade.BackColor = System.Drawing.Color.White;
            this.lbFaculdade.Depth = 0;
            this.lbFaculdade.Font = new System.Drawing.Font("Roboto", 11F);
            this.lbFaculdade.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbFaculdade.Location = new System.Drawing.Point(37, 245);
            this.lbFaculdade.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbFaculdade.Name = "lbFaculdade";
            this.lbFaculdade.Size = new System.Drawing.Size(94, 19);
            this.lbFaculdade.TabIndex = 17;
            this.lbFaculdade.Text = "FACULDADE";
            // 
            // lbCurso
            // 
            this.lbCurso.AutoSize = true;
            this.lbCurso.BackColor = System.Drawing.Color.White;
            this.lbCurso.Depth = 0;
            this.lbCurso.Font = new System.Drawing.Font("Roboto", 11F);
            this.lbCurso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbCurso.Location = new System.Drawing.Point(36, 273);
            this.lbCurso.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbCurso.Name = "lbCurso";
            this.lbCurso.Size = new System.Drawing.Size(57, 19);
            this.lbCurso.TabIndex = 14;
            this.lbCurso.Text = "CURSO";
            // 
            // lbMateria
            // 
            this.lbMateria.AutoSize = true;
            this.lbMateria.BackColor = System.Drawing.Color.White;
            this.lbMateria.Depth = 0;
            this.lbMateria.Font = new System.Drawing.Font("Roboto", 11F);
            this.lbMateria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbMateria.Location = new System.Drawing.Point(36, 301);
            this.lbMateria.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbMateria.Name = "lbMateria";
            this.lbMateria.Size = new System.Drawing.Size(73, 19);
            this.lbMateria.TabIndex = 18;
            this.lbMateria.Text = "MATÉRIA";
            // 
            // lbFaculShow
            // 
            this.lbFaculShow.AutoSize = true;
            this.lbFaculShow.BackColor = System.Drawing.Color.White;
            this.lbFaculShow.Depth = 0;
            this.lbFaculShow.Font = new System.Drawing.Font("Roboto", 11F);
            this.lbFaculShow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbFaculShow.Location = new System.Drawing.Point(180, 245);
            this.lbFaculShow.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbFaculShow.Name = "lbFaculShow";
            this.lbFaculShow.Size = new System.Drawing.Size(0, 19);
            this.lbFaculShow.TabIndex = 17;
            // 
            // lbCursoShow
            // 
            this.lbCursoShow.AutoSize = true;
            this.lbCursoShow.BackColor = System.Drawing.Color.White;
            this.lbCursoShow.Depth = 0;
            this.lbCursoShow.Font = new System.Drawing.Font("Roboto", 11F);
            this.lbCursoShow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbCursoShow.Location = new System.Drawing.Point(179, 273);
            this.lbCursoShow.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbCursoShow.Name = "lbCursoShow";
            this.lbCursoShow.Size = new System.Drawing.Size(0, 19);
            this.lbCursoShow.TabIndex = 14;
            // 
            // lbMateriaShow
            // 
            this.lbMateriaShow.AutoSize = true;
            this.lbMateriaShow.BackColor = System.Drawing.Color.White;
            this.lbMateriaShow.Depth = 0;
            this.lbMateriaShow.Font = new System.Drawing.Font("Roboto", 11F);
            this.lbMateriaShow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbMateriaShow.Location = new System.Drawing.Point(179, 301);
            this.lbMateriaShow.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbMateriaShow.Name = "lbMateriaShow";
            this.lbMateriaShow.Size = new System.Drawing.Size(0, 19);
            this.lbMateriaShow.TabIndex = 18;
            // 
            // btnVoltar2
            // 
            this.btnVoltar2.AutoSize = true;
            this.btnVoltar2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnVoltar2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVoltar2.Depth = 0;
            this.btnVoltar2.Location = new System.Drawing.Point(40, 351);
            this.btnVoltar2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnVoltar2.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnVoltar2.Name = "btnVoltar2";
            this.btnVoltar2.Primary = false;
            this.btnVoltar2.Size = new System.Drawing.Size(64, 36);
            this.btnVoltar2.TabIndex = 31;
            this.btnVoltar2.Text = "VOLTAR";
            this.btnVoltar2.UseVisualStyleBackColor = true;
            this.btnVoltar2.Click += new System.EventHandler(this.btnVoltar2_Click);
            // 
            // TelaConfiguracao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 415);
            this.Controls.Add(this.btnVoltar2);
            this.Controls.Add(this.lbRecebeEmailConfig);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.txtSexo);
            this.Controls.Add(this.txtIdade);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lbMateriaShow);
            this.Controls.Add(this.lbCursoShow);
            this.Controls.Add(this.lbMateria);
            this.Controls.Add(this.lbCurso);
            this.Controls.Add(this.lbFaculShow);
            this.Controls.Add(this.lbIdade);
            this.Controls.Add(this.lbFaculdade);
            this.Controls.Add(this.lbSexo);
            this.Controls.Add(this.lbNome);
            this.Controls.Add(this.lbDados);
            this.Name = "TelaConfiguracao";
            this.Text = "Configurações";
            this.Load += new System.EventHandler(this.TelaConfiguracao_Load);
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
    }
}