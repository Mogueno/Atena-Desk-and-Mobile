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
			this.btnCancelar = new MaterialSkin.Controls.MaterialFlatButton();
			this.btnAdicionar = new MaterialSkin.Controls.MaterialFlatButton();
			this.txtNota = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// btnCancelar
			// 
			this.btnCancelar.AutoSize = true;
			this.btnCancelar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnCancelar.BackColor = System.Drawing.Color.Red;
			this.btnCancelar.Depth = 0;
			this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCancelar.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.btnCancelar.Location = new System.Drawing.Point(13, 399);
			this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.btnCancelar.MouseState = MaterialSkin.MouseState.HOVER;
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Primary = false;
			this.btnCancelar.Size = new System.Drawing.Size(82, 36);
			this.btnCancelar.TabIndex = 5;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.UseVisualStyleBackColor = false;
			// 
			// btnAdicionar
			// 
			this.btnAdicionar.AutoSize = true;
			this.btnAdicionar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnAdicionar.Depth = 0;
			this.btnAdicionar.Location = new System.Drawing.Point(362, 399);
			this.btnAdicionar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.btnAdicionar.MouseState = MaterialSkin.MouseState.HOVER;
			this.btnAdicionar.Name = "btnAdicionar";
			this.btnAdicionar.Primary = false;
			this.btnAdicionar.Size = new System.Drawing.Size(84, 36);
			this.btnAdicionar.TabIndex = 4;
			this.btnAdicionar.Text = "Adicionar";
			this.btnAdicionar.UseVisualStyleBackColor = true;
			// 
			// txtNota
			// 
			this.txtNota.Location = new System.Drawing.Point(4, 74);
			this.txtNota.Multiline = true;
			this.txtNota.Name = "txtNota";
			this.txtNota.Size = new System.Drawing.Size(775, 316);
			this.txtNota.TabIndex = 3;
			// 
			// TelaNovaNota
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.btnCancelar);
			this.Controls.Add(this.btnAdicionar);
			this.Controls.Add(this.txtNota);
			this.Name = "TelaNovaNota";
			this.Text = "TelaNovaNota";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private MaterialSkin.Controls.MaterialFlatButton btnCancelar;
		private MaterialSkin.Controls.MaterialFlatButton btnAdicionar;
		private System.Windows.Forms.TextBox txtNota;
	}
}