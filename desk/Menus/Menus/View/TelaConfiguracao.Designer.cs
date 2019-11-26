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
            this.btnEditarCadastro = new MaterialSkin.Controls.MaterialFlatButton();
            this.txtSexo = new System.Windows.Forms.TextBox();
            this.txtIdade = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lbIdade = new MaterialSkin.Controls.MaterialLabel();
            this.lbSexo = new MaterialSkin.Controls.MaterialLabel();
            this.lbNome = new MaterialSkin.Controls.MaterialLabel();
            this.lbDados = new System.Windows.Forms.Label();
            this.lbRecebeEmailConfig = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.AutoSize = true;
            this.btnAtualizar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAtualizar.Depth = 0;
            this.btnAtualizar.Location = new System.Drawing.Point(272, 372);
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
            // btnEditarCadastro
            // 
            this.btnEditarCadastro.AutoSize = true;
            this.btnEditarCadastro.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEditarCadastro.Depth = 0;
            this.btnEditarCadastro.Location = new System.Drawing.Point(436, 372);
            this.btnEditarCadastro.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnEditarCadastro.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnEditarCadastro.Name = "btnEditarCadastro";
            this.btnEditarCadastro.Primary = false;
            this.btnEditarCadastro.Size = new System.Drawing.Size(133, 36);
            this.btnEditarCadastro.TabIndex = 28;
            this.btnEditarCadastro.Text = "Editar Cadastro";
            this.btnEditarCadastro.UseVisualStyleBackColor = true;
            // 
            // txtSexo
            // 
            this.txtSexo.Location = new System.Drawing.Point(183, 174);
            this.txtSexo.Name = "txtSexo";
            this.txtSexo.Size = new System.Drawing.Size(537, 20);
            this.txtSexo.TabIndex = 1;
            // 
            // txtIdade
            // 
            this.txtIdade.Location = new System.Drawing.Point(183, 203);
            this.txtIdade.Name = "txtIdade";
            this.txtIdade.Size = new System.Drawing.Size(537, 20);
            this.txtIdade.TabIndex = 2;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(183, 143);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(537, 20);
            this.txtNome.TabIndex = 0;
            // 
            // lbIdade
            // 
            this.lbIdade.AutoSize = true;
            this.lbIdade.BackColor = System.Drawing.Color.White;
            this.lbIdade.Depth = 0;
            this.lbIdade.Font = new System.Drawing.Font("Roboto", 11F);
            this.lbIdade.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbIdade.Location = new System.Drawing.Point(36, 202);
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
            this.lbSexo.Location = new System.Drawing.Point(36, 174);
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
            this.lbNome.Location = new System.Drawing.Point(37, 146);
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
            this.lbDados.Location = new System.Drawing.Point(291, 75);
            this.lbDados.Name = "lbDados";
            this.lbDados.Size = new System.Drawing.Size(226, 37);
            this.lbDados.TabIndex = 13;
            this.lbDados.Text = "SEUS DADOS";
            // 
            // lbRecebeEmailConfig
            // 
            this.lbRecebeEmailConfig.AutoSize = true;
            this.lbRecebeEmailConfig.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbRecebeEmailConfig.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbRecebeEmailConfig.Location = new System.Drawing.Point(41, 98);
            this.lbRecebeEmailConfig.Name = "lbRecebeEmailConfig";
            this.lbRecebeEmailConfig.Size = new System.Drawing.Size(0, 13);
            this.lbRecebeEmailConfig.TabIndex = 30;
            // 
            // TelaConfiguracao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbRecebeEmailConfig);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.btnEditarCadastro);
            this.Controls.Add(this.txtSexo);
            this.Controls.Add(this.txtIdade);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lbIdade);
            this.Controls.Add(this.lbSexo);
            this.Controls.Add(this.lbNome);
            this.Controls.Add(this.lbDados);
            this.Name = "TelaConfiguracao";
            this.Text = "TelaConfiguracao";
            this.Load += new System.EventHandler(this.TelaConfiguracao_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private MaterialSkin.Controls.MaterialFlatButton btnAtualizar;
		private MaterialSkin.Controls.MaterialFlatButton btnEditarCadastro;
		private System.Windows.Forms.TextBox txtSexo;
		private System.Windows.Forms.TextBox txtIdade;
		private System.Windows.Forms.TextBox txtNome;
		private MaterialSkin.Controls.MaterialLabel lbIdade;
		private MaterialSkin.Controls.MaterialLabel lbSexo;
		private MaterialSkin.Controls.MaterialLabel lbNome;
		private System.Windows.Forms.Label lbDados;
        private System.Windows.Forms.Label lbRecebeEmailConfig;
    }
}