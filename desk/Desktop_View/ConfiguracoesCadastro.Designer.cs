namespace Desktop_View
{
    partial class ConfiguracoesCadastro
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
            this.lbDados = new System.Windows.Forms.Label();
            this.lbNome = new MaterialSkin.Controls.MaterialLabel();
            this.lbIdade = new MaterialSkin.Controls.MaterialLabel();
            this.lbSexo = new MaterialSkin.Controls.MaterialLabel();
            this.lbFaculdade = new MaterialSkin.Controls.MaterialLabel();
            this.lbMateria = new MaterialSkin.Controls.MaterialLabel();
            this.lbCurso = new MaterialSkin.Controls.MaterialLabel();
            this.lbHorario = new MaterialSkin.Controls.MaterialLabel();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtFaculdade = new System.Windows.Forms.TextBox();
            this.txtMateria = new System.Windows.Forms.TextBox();
            this.txtIdade = new System.Windows.Forms.TextBox();
            this.txtSexo = new System.Windows.Forms.TextBox();
            this.txtCurso = new System.Windows.Forms.TextBox();
            this.txtHorario = new System.Windows.Forms.TextBox();
            this.btnEditarCadastro = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnAtualizar = new MaterialSkin.Controls.MaterialFlatButton();
            this.SuspendLayout();
            // 
            // lbDados
            // 
            this.lbDados.AutoSize = true;
            this.lbDados.BackColor = System.Drawing.Color.White;
            this.lbDados.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDados.Location = new System.Drawing.Point(290, 76);
            this.lbDados.Name = "lbDados";
            this.lbDados.Size = new System.Drawing.Size(226, 37);
            this.lbDados.TabIndex = 0;
            this.lbDados.Text = "SEUS DADOS";
            // 
            // lbNome
            // 
            this.lbNome.AutoSize = true;
            this.lbNome.BackColor = System.Drawing.Color.White;
            this.lbNome.Depth = 0;
            this.lbNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lbNome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbNome.Location = new System.Drawing.Point(36, 147);
            this.lbNome.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbNome.Name = "lbNome";
            this.lbNome.Size = new System.Drawing.Size(54, 18);
            this.lbNome.TabIndex = 1;
            this.lbNome.Text = "NOME";
            this.lbNome.Click += new System.EventHandler(this.materialLabel1_Click);
            // 
            // lbIdade
            // 
            this.lbIdade.AutoSize = true;
            this.lbIdade.BackColor = System.Drawing.Color.White;
            this.lbIdade.Depth = 0;
            this.lbIdade.Font = new System.Drawing.Font("Roboto", 11F);
            this.lbIdade.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbIdade.Location = new System.Drawing.Point(35, 203);
            this.lbIdade.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbIdade.Name = "lbIdade";
            this.lbIdade.Size = new System.Drawing.Size(52, 19);
            this.lbIdade.TabIndex = 3;
            this.lbIdade.Text = "IDADE";
            // 
            // lbSexo
            // 
            this.lbSexo.AutoSize = true;
            this.lbSexo.BackColor = System.Drawing.Color.White;
            this.lbSexo.Depth = 0;
            this.lbSexo.Font = new System.Drawing.Font("Roboto", 11F);
            this.lbSexo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbSexo.Location = new System.Drawing.Point(35, 175);
            this.lbSexo.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbSexo.Name = "lbSexo";
            this.lbSexo.Size = new System.Drawing.Size(46, 19);
            this.lbSexo.TabIndex = 1;
            this.lbSexo.Text = "SEXO";
            this.lbSexo.Click += new System.EventHandler(this.materialLabel1_Click);
            // 
            // lbFaculdade
            // 
            this.lbFaculdade.AutoSize = true;
            this.lbFaculdade.BackColor = System.Drawing.Color.White;
            this.lbFaculdade.Depth = 0;
            this.lbFaculdade.Font = new System.Drawing.Font("Roboto", 11F);
            this.lbFaculdade.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbFaculdade.Location = new System.Drawing.Point(36, 234);
            this.lbFaculdade.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbFaculdade.Name = "lbFaculdade";
            this.lbFaculdade.Size = new System.Drawing.Size(94, 19);
            this.lbFaculdade.TabIndex = 1;
            this.lbFaculdade.Text = "FACULDADE";
            this.lbFaculdade.Click += new System.EventHandler(this.materialLabel1_Click);
            // 
            // lbMateria
            // 
            this.lbMateria.AutoSize = true;
            this.lbMateria.BackColor = System.Drawing.Color.White;
            this.lbMateria.Depth = 0;
            this.lbMateria.Font = new System.Drawing.Font("Roboto", 11F);
            this.lbMateria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbMateria.Location = new System.Drawing.Point(35, 262);
            this.lbMateria.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbMateria.Name = "lbMateria";
            this.lbMateria.Size = new System.Drawing.Size(73, 19);
            this.lbMateria.TabIndex = 1;
            this.lbMateria.Text = "MATÉRIA";
            this.lbMateria.Click += new System.EventHandler(this.materialLabel1_Click);
            // 
            // lbCurso
            // 
            this.lbCurso.AutoSize = true;
            this.lbCurso.BackColor = System.Drawing.Color.White;
            this.lbCurso.Depth = 0;
            this.lbCurso.Font = new System.Drawing.Font("Roboto", 11F);
            this.lbCurso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbCurso.Location = new System.Drawing.Point(35, 290);
            this.lbCurso.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbCurso.Name = "lbCurso";
            this.lbCurso.Size = new System.Drawing.Size(57, 19);
            this.lbCurso.TabIndex = 3;
            this.lbCurso.Text = "CURSO";
            // 
            // lbHorario
            // 
            this.lbHorario.AutoSize = true;
            this.lbHorario.BackColor = System.Drawing.Color.White;
            this.lbHorario.Depth = 0;
            this.lbHorario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lbHorario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbHorario.Location = new System.Drawing.Point(36, 318);
            this.lbHorario.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbHorario.Name = "lbHorario";
            this.lbHorario.Size = new System.Drawing.Size(77, 18);
            this.lbHorario.TabIndex = 4;
            this.lbHorario.Text = "HORÁRIO";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(182, 144);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(537, 20);
            this.txtNome.TabIndex = 5;
            // 
            // txtFaculdade
            // 
            this.txtFaculdade.Location = new System.Drawing.Point(182, 233);
            this.txtFaculdade.Name = "txtFaculdade";
            this.txtFaculdade.Size = new System.Drawing.Size(537, 20);
            this.txtFaculdade.TabIndex = 6;
            // 
            // txtMateria
            // 
            this.txtMateria.Location = new System.Drawing.Point(182, 263);
            this.txtMateria.Name = "txtMateria";
            this.txtMateria.Size = new System.Drawing.Size(537, 20);
            this.txtMateria.TabIndex = 7;
            // 
            // txtIdade
            // 
            this.txtIdade.Location = new System.Drawing.Point(182, 204);
            this.txtIdade.Name = "txtIdade";
            this.txtIdade.Size = new System.Drawing.Size(537, 20);
            this.txtIdade.TabIndex = 8;
            // 
            // txtSexo
            // 
            this.txtSexo.Location = new System.Drawing.Point(182, 175);
            this.txtSexo.Name = "txtSexo";
            this.txtSexo.Size = new System.Drawing.Size(537, 20);
            this.txtSexo.TabIndex = 9;
            // 
            // txtCurso
            // 
            this.txtCurso.Location = new System.Drawing.Point(182, 291);
            this.txtCurso.Name = "txtCurso";
            this.txtCurso.Size = new System.Drawing.Size(537, 20);
            this.txtCurso.TabIndex = 10;
            // 
            // txtHorario
            // 
            this.txtHorario.Location = new System.Drawing.Point(182, 319);
            this.txtHorario.Name = "txtHorario";
            this.txtHorario.Size = new System.Drawing.Size(537, 20);
            this.txtHorario.TabIndex = 11;
            // 
            // btnEditarCadastro
            // 
            this.btnEditarCadastro.AutoSize = true;
            this.btnEditarCadastro.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEditarCadastro.Depth = 0;
            this.btnEditarCadastro.Location = new System.Drawing.Point(435, 373);
            this.btnEditarCadastro.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnEditarCadastro.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnEditarCadastro.Name = "btnEditarCadastro";
            this.btnEditarCadastro.Primary = false;
            this.btnEditarCadastro.Size = new System.Drawing.Size(133, 36);
            this.btnEditarCadastro.TabIndex = 12;
            this.btnEditarCadastro.Text = "Editar Cadastro";
            this.btnEditarCadastro.UseVisualStyleBackColor = true;
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.AutoSize = true;
            this.btnAtualizar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAtualizar.Depth = 0;
            this.btnAtualizar.Location = new System.Drawing.Point(271, 373);
            this.btnAtualizar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAtualizar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Primary = false;
            this.btnAtualizar.Size = new System.Drawing.Size(85, 36);
            this.btnAtualizar.TabIndex = 12;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            // 
            // ConfiguracoesCadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.btnEditarCadastro);
            this.Controls.Add(this.txtHorario);
            this.Controls.Add(this.txtCurso);
            this.Controls.Add(this.txtSexo);
            this.Controls.Add(this.txtIdade);
            this.Controls.Add(this.txtMateria);
            this.Controls.Add(this.txtFaculdade);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lbHorario);
            this.Controls.Add(this.lbCurso);
            this.Controls.Add(this.lbIdade);
            this.Controls.Add(this.lbMateria);
            this.Controls.Add(this.lbFaculdade);
            this.Controls.Add(this.lbSexo);
            this.Controls.Add(this.lbNome);
            this.Controls.Add(this.lbDados);
            this.Name = "ConfiguracoesCadastro";
            this.Text = " ";
            this.Load += new System.EventHandler(this.ConfiguracoesCadastro_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbDados;
        private MaterialSkin.Controls.MaterialLabel lbNome;
        private MaterialSkin.Controls.MaterialLabel lbIdade;
        private MaterialSkin.Controls.MaterialLabel lbSexo;
        private MaterialSkin.Controls.MaterialLabel lbFaculdade;
        private MaterialSkin.Controls.MaterialLabel lbMateria;
        private MaterialSkin.Controls.MaterialLabel lbCurso;
        private MaterialSkin.Controls.MaterialLabel lbHorario;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtFaculdade;
        private System.Windows.Forms.TextBox txtMateria;
        private System.Windows.Forms.TextBox txtIdade;
        private System.Windows.Forms.TextBox txtHorario;
        private MaterialSkin.Controls.MaterialFlatButton btnEditarCadastro;
        private MaterialSkin.Controls.MaterialFlatButton btnAtualizar;
        private System.Windows.Forms.TextBox txtSexo;
        private System.Windows.Forms.TextBox txtCurso;
    }
}