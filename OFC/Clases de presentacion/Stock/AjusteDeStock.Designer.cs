namespace OFC
{
    partial class frmAjusteDeStock
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
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.lblNroDeAjuste = new System.Windows.Forms.Label();
            this.txtNroDeAjuste = new System.Windows.Forms.TextBox();
            this.lblArticulo = new System.Windows.Forms.Label();
            this.txtArticulo = new System.Windows.Forms.TextBox();
            this.lblAjuste = new System.Windows.Forms.Label();
            this.lblIngreso = new System.Windows.Forms.Label();
            this.lblEgreso = new System.Windows.Forms.Label();
            this.txtEgreso = new System.Windows.Forms.TextBox();
            this.txtIngreso = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.pnlPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPrincipal.Controls.Add(this.lblNroDeAjuste);
            this.pnlPrincipal.Controls.Add(this.txtNroDeAjuste);
            this.pnlPrincipal.Controls.Add(this.lblArticulo);
            this.pnlPrincipal.Controls.Add(this.txtArticulo);
            this.pnlPrincipal.Controls.Add(this.lblAjuste);
            this.pnlPrincipal.Controls.Add(this.lblIngreso);
            this.pnlPrincipal.Controls.Add(this.lblEgreso);
            this.pnlPrincipal.Controls.Add(this.txtEgreso);
            this.pnlPrincipal.Controls.Add(this.txtIngreso);
            this.pnlPrincipal.Location = new System.Drawing.Point(12, 12);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(509, 173);
            this.pnlPrincipal.TabIndex = 1;
            // 
            // lblNroDeAjuste
            // 
            this.lblNroDeAjuste.AutoSize = true;
            this.lblNroDeAjuste.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroDeAjuste.Location = new System.Drawing.Point(15, 60);
            this.lblNroDeAjuste.Name = "lblNroDeAjuste";
            this.lblNroDeAjuste.Size = new System.Drawing.Size(83, 15);
            this.lblNroDeAjuste.TabIndex = 152;
            this.lblNroDeAjuste.Text = "Nro. de Ajuste";
            // 
            // txtNroDeAjuste
            // 
            this.txtNroDeAjuste.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroDeAjuste.Location = new System.Drawing.Point(158, 57);
            this.txtNroDeAjuste.MaxLength = 8;
            this.txtNroDeAjuste.Name = "txtNroDeAjuste";
            this.txtNroDeAjuste.ReadOnly = true;
            this.txtNroDeAjuste.Size = new System.Drawing.Size(328, 21);
            this.txtNroDeAjuste.TabIndex = 1;
            // 
            // lblArticulo
            // 
            this.lblArticulo.AutoSize = true;
            this.lblArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArticulo.Location = new System.Drawing.Point(15, 87);
            this.lblArticulo.Name = "lblArticulo";
            this.lblArticulo.Size = new System.Drawing.Size(47, 15);
            this.lblArticulo.TabIndex = 103;
            this.lblArticulo.Text = "Artículo";
            // 
            // txtArticulo
            // 
            this.txtArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtArticulo.Location = new System.Drawing.Point(158, 84);
            this.txtArticulo.MaxLength = 80;
            this.txtArticulo.Name = "txtArticulo";
            this.txtArticulo.ReadOnly = true;
            this.txtArticulo.Size = new System.Drawing.Size(328, 21);
            this.txtArticulo.TabIndex = 2;
            // 
            // lblAjuste
            // 
            this.lblAjuste.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblAjuste.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAjuste.Location = new System.Drawing.Point(3, 13);
            this.lblAjuste.Name = "lblAjuste";
            this.lblAjuste.Size = new System.Drawing.Size(501, 25);
            this.lblAjuste.TabIndex = 102;
            this.lblAjuste.Text = "Ajuste";
            this.lblAjuste.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIngreso
            // 
            this.lblIngreso.AutoSize = true;
            this.lblIngreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIngreso.Location = new System.Drawing.Point(15, 113);
            this.lblIngreso.Name = "lblIngreso";
            this.lblIngreso.Size = new System.Drawing.Size(96, 15);
            this.lblIngreso.TabIndex = 149;
            this.lblIngreso.Text = "Cant. de Ingreso";
            // 
            // lblEgreso
            // 
            this.lblEgreso.AutoSize = true;
            this.lblEgreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEgreso.Location = new System.Drawing.Point(15, 140);
            this.lblEgreso.Name = "lblEgreso";
            this.lblEgreso.Size = new System.Drawing.Size(94, 15);
            this.lblEgreso.TabIndex = 150;
            this.lblEgreso.Text = "Cant. de Egreso";
            // 
            // txtEgreso
            // 
            this.txtEgreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEgreso.Location = new System.Drawing.Point(158, 137);
            this.txtEgreso.MaxLength = 8;
            this.txtEgreso.Name = "txtEgreso";
            this.txtEgreso.Size = new System.Drawing.Size(328, 21);
            this.txtEgreso.TabIndex = 4;
            this.txtEgreso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEgreso_KeyPress);
            // 
            // txtIngreso
            // 
            this.txtIngreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIngreso.Location = new System.Drawing.Point(158, 110);
            this.txtIngreso.MaxLength = 8;
            this.txtIngreso.Name = "txtIngreso";
            this.txtIngreso.Size = new System.Drawing.Size(328, 21);
            this.txtIngreso.TabIndex = 3;
            this.txtIngreso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIngreso_KeyPress);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(392, 191);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(129, 35);
            this.btnAceptar.TabIndex = 5;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // frmAjusteDeStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 234);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.pnlPrincipal);
            this.Name = "frmAjusteDeStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ajuste de Stock";
            this.Load += new System.EventHandler(this.frmAjusteDeStock_Load);
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlPrincipal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlPrincipal;
        private System.Windows.Forms.Label lblNroDeAjuste;
        private System.Windows.Forms.TextBox txtNroDeAjuste;
        private System.Windows.Forms.Label lblArticulo;
        private System.Windows.Forms.TextBox txtArticulo;
        private System.Windows.Forms.Label lblAjuste;
        private System.Windows.Forms.Label lblIngreso;
        private System.Windows.Forms.Label lblEgreso;
        private System.Windows.Forms.TextBox txtEgreso;
        private System.Windows.Forms.TextBox txtIngreso;
        private System.Windows.Forms.Button btnAceptar;
    }
}