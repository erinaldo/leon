namespace OFC
{
    partial class frmCrearTipoDeAsiento
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
            this.pnlDerecha = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblDatosDelTipoDeAsiento = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblConcepto = new System.Windows.Forms.Label();
            this.pnlDerecha.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDerecha
            // 
            this.pnlDerecha.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlDerecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDerecha.Controls.Add(this.btnGuardar);
            this.pnlDerecha.Controls.Add(this.lblDatosDelTipoDeAsiento);
            this.pnlDerecha.Controls.Add(this.txtCodigo);
            this.pnlDerecha.Controls.Add(this.lblCodigo);
            this.pnlDerecha.Controls.Add(this.txtDescripcion);
            this.pnlDerecha.Controls.Add(this.lblConcepto);
            this.pnlDerecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlDerecha.Location = new System.Drawing.Point(13, 11);
            this.pnlDerecha.Name = "pnlDerecha";
            this.pnlDerecha.Size = new System.Drawing.Size(536, 128);
            this.pnlDerecha.TabIndex = 4;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.Location = new System.Drawing.Point(435, 74);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(96, 35);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.Text = "Crear";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // lblDatosDelTipoDeAsiento
            // 
            this.lblDatosDelTipoDeAsiento.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblDatosDelTipoDeAsiento.Location = new System.Drawing.Point(3, 12);
            this.lblDatosDelTipoDeAsiento.Name = "lblDatosDelTipoDeAsiento";
            this.lblDatosDelTipoDeAsiento.Size = new System.Drawing.Size(528, 25);
            this.lblDatosDelTipoDeAsiento.TabIndex = 100;
            this.lblDatosDelTipoDeAsiento.Text = "Datos del Tipo de Asiento";
            this.lblDatosDelTipoDeAsiento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(89, 61);
            this.txtCodigo.MaxLength = 4;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(323, 21);
            this.txtCodigo.TabIndex = 1;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigo.Location = new System.Drawing.Point(14, 64);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(46, 15);
            this.lblCodigo.TabIndex = 101;
            this.lblCodigo.Text = "Código";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(89, 88);
            this.txtDescripcion.MaxLength = 80;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(323, 21);
            this.txtDescripcion.TabIndex = 2;
            // 
            // lblConcepto
            // 
            this.lblConcepto.AutoSize = true;
            this.lblConcepto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConcepto.Location = new System.Drawing.Point(14, 91);
            this.lblConcepto.Name = "lblConcepto";
            this.lblConcepto.Size = new System.Drawing.Size(59, 15);
            this.lblConcepto.TabIndex = 102;
            this.lblConcepto.Text = "Concepto";
            // 
            // frmCrearTipoDeAsiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 152);
            this.Controls.Add(this.pnlDerecha);
            this.MaximizeBox = false;
            this.Name = "frmCrearTipoDeAsiento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crear Tipo de Asiento";
            this.pnlDerecha.ResumeLayout(false);
            this.pnlDerecha.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDerecha;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblDatosDelTipoDeAsiento;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblConcepto;
    }
}