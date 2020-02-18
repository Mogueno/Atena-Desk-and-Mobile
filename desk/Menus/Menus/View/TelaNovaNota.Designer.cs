namespace Menus
{
    partial class TelaNovaNota
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtNota = new System.Windows.Forms.TextBox();
            this.btnAdicionar = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnCancelar = new MaterialSkin.Controls.MaterialFlatButton();
            this.lbRecebeEmailNovaNota = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtNota
            // 
            this.txtNota.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNota.Location = new System.Drawing.Point(217, 223);
            this.txtNota.Multiline = true;
            this.txtNota.Name = "txtNota";
            this.txtNota.Size = new System.Drawing.Size(775, 316);
            this.txtNota.TabIndex = 3;
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.AutoSize = true;
            this.btnAdicionar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAdicionar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdicionar.Depth = 0;
            this.btnAdicionar.Location = new System.Drawing.Point(908, 591);
            this.btnAdicionar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAdicionar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Primary = false;
            this.btnAdicionar.Size = new System.Drawing.Size(84, 36);
            this.btnAdicionar.TabIndex = 4;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.AutoSize = true;
            this.btnCancelar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Depth = 0;
            this.btnCancelar.Location = new System.Drawing.Point(217, 591);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCancelar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Primary = false;
            this.btnCancelar.Size = new System.Drawing.Size(82, 36);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lbRecebeEmailNovaNota
            // 
            this.lbRecebeEmailNovaNota.AutoSize = true;
            this.lbRecebeEmailNovaNota.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbRecebeEmailNovaNota.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbRecebeEmailNovaNota.Location = new System.Drawing.Point(522, 603);
            this.lbRecebeEmailNovaNota.Name = "lbRecebeEmailNovaNota";
            this.lbRecebeEmailNovaNota.Size = new System.Drawing.Size(0, 13);
            this.lbRecebeEmailNovaNota.TabIndex = 5;
            // 
            // txtTitle
            // 
            this.txtTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitle.Location = new System.Drawing.Point(217, 142);
            this.txtTitle.Multiline = true;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(775, 66);
            this.txtTitle.TabIndex = 6;
            // 
            // TelaNovaNota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1386, 788);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lbRecebeEmailNovaNota);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.txtNota);
            this.Name = "TelaNovaNota";
            this.Text = "Nova Nota";
            this.Load += new System.EventHandler(this.TelaNovaNota_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNota;
        private MaterialSkin.Controls.MaterialFlatButton btnAdicionar;
        private MaterialSkin.Controls.MaterialFlatButton btnCancelar;
        private System.Windows.Forms.Label lbRecebeEmailNovaNota;
        private System.Windows.Forms.TextBox txtTitle;
    }
}