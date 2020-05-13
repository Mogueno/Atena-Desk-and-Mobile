namespace Desktop_View
{
    partial class TTelaInicial
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
            this.btnGoogleS = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnNovanota = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnConfiguracoes = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // btnGoogleS
            // 
            this.btnGoogleS.AutoSize = true;
            this.btnGoogleS.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGoogleS.Depth = 0;
            this.btnGoogleS.Location = new System.Drawing.Point(137, 381);
            this.btnGoogleS.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnGoogleS.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnGoogleS.Name = "btnGoogleS";
            this.btnGoogleS.Primary = false;
            this.btnGoogleS.Size = new System.Drawing.Size(137, 36);
            this.btnGoogleS.TabIndex = 5;
            this.btnGoogleS.Text = "Google Schollar";
            this.btnGoogleS.UseVisualStyleBackColor = true;
            // 
            // btnNovanota
            // 
            this.btnNovanota.AutoSize = true;
            this.btnNovanota.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnNovanota.Depth = 0;
            this.btnNovanota.Location = new System.Drawing.Point(358, 381);
            this.btnNovanota.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnNovanota.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnNovanota.Name = "btnNovanota";
            this.btnNovanota.Primary = false;
            this.btnNovanota.Size = new System.Drawing.Size(89, 36);
            this.btnNovanota.TabIndex = 6;
            this.btnNovanota.Text = "Nova Nota";
            this.btnNovanota.UseVisualStyleBackColor = true;
            // 
            // btnConfiguracoes
            // 
            this.btnConfiguracoes.AutoSize = true;
            this.btnConfiguracoes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnConfiguracoes.Depth = 0;
            this.btnConfiguracoes.Location = new System.Drawing.Point(551, 381);
            this.btnConfiguracoes.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnConfiguracoes.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnConfiguracoes.Name = "btnConfiguracoes";
            this.btnConfiguracoes.Primary = false;
            this.btnConfiguracoes.Size = new System.Drawing.Size(122, 36);
            this.btnConfiguracoes.TabIndex = 7;
            this.btnConfiguracoes.Text = "Configurações";
            this.btnConfiguracoes.UseVisualStyleBackColor = true;
            // 
            // materialDivider1
            // 
            this.materialDivider1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialDivider1.Depth = 0;
            this.materialDivider1.Location = new System.Drawing.Point(-6, 236);
            this.materialDivider1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider1.Name = "materialDivider1";
            this.materialDivider1.Size = new System.Drawing.Size(807, 10);
            this.materialDivider1.TabIndex = 8;
            this.materialDivider1.Text = "materialDivider1";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(290, 285);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(206, 19);
            this.materialLabel1.TabIndex = 9;
            this.materialLabel1.Text = " {{ Features do app em lista }}";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(325, 136);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(140, 19);
            this.materialLabel2.TabIndex = 10;
            this.materialLabel2.Text = "{{ View das notas }}";
            // 
            // TTelaInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.materialDivider1);
            this.Controls.Add(this.btnConfiguracoes);
            this.Controls.Add(this.btnNovanota);
            this.Controls.Add(this.btnGoogleS);
            this.Name = "TTelaInicial";
            this.Text = "TTelaInicial";
            this.Load += new System.EventHandler(this.TTelaInicial_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialFlatButton btnGoogleS;
        private MaterialSkin.Controls.MaterialFlatButton btnNovanota;
        private MaterialSkin.Controls.MaterialFlatButton btnConfiguracoes;
        private MaterialSkin.Controls.MaterialDivider materialDivider1;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
    }
}