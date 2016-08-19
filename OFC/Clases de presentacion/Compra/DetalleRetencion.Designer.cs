namespace OFC
{
    partial class frmDetalleRetencion
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
            this.txtImporteOrdenDePago = new System.Windows.Forms.TextBox();
            this.lblPeriodo = new System.Windows.Forms.Label();
            this.dtpPeriodo = new System.Windows.Forms.DateTimePicker();
            this.lblImporteOrdenDePago = new System.Windows.Forms.Label();
            this.lblImporteNeto = new System.Windows.Forms.Label();
            this.txtImporteNeto = new System.Windows.Forms.TextBox();
            this.txtImportePagosAnteriores = new System.Windows.Forms.TextBox();
            this.lblImporteNetoPagosAnteriores = new System.Windows.Forms.Label();
            this.lblImporteRetencion = new System.Windows.Forms.Label();
            this.txtImporteRetencionPeriodo = new System.Windows.Forms.TextBox();
            this.txtImporteRetencionAnterior = new System.Windows.Forms.TextBox();
            this.lblImporteRetencionAnterior = new System.Windows.Forms.Label();
            this.lblImporteRetencionActual = new System.Windows.Forms.Label();
            this.txtImporteRetencionActual = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtImporteOrdenDePago
            // 
            this.txtImporteOrdenDePago.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImporteOrdenDePago.Location = new System.Drawing.Point(192, 57);
            this.txtImporteOrdenDePago.MaxLength = 12;
            this.txtImporteOrdenDePago.Name = "txtImporteOrdenDePago";
            this.txtImporteOrdenDePago.Size = new System.Drawing.Size(275, 21);
            this.txtImporteOrdenDePago.TabIndex = 2;
            this.txtImporteOrdenDePago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtImporteOrdenDePago.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImporteOrdenDePago_KeyPress);
            // 
            // lblPeriodo
            // 
            this.lblPeriodo.AutoSize = true;
            this.lblPeriodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriodo.Location = new System.Drawing.Point(12, 34);
            this.lblPeriodo.Name = "lblPeriodo";
            this.lblPeriodo.Size = new System.Drawing.Size(50, 15);
            this.lblPeriodo.TabIndex = 19;
            this.lblPeriodo.Text = "Período";
            // 
            // dtpPeriodo
            // 
            this.dtpPeriodo.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpPeriodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPeriodo.Location = new System.Drawing.Point(192, 30);
            this.dtpPeriodo.Name = "dtpPeriodo";
            this.dtpPeriodo.Size = new System.Drawing.Size(275, 21);
            this.dtpPeriodo.TabIndex = 1;
            // 
            // lblImporteOrdenDePago
            // 
            this.lblImporteOrdenDePago.AutoSize = true;
            this.lblImporteOrdenDePago.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImporteOrdenDePago.Location = new System.Drawing.Point(12, 58);
            this.lblImporteOrdenDePago.Name = "lblImporteOrdenDePago";
            this.lblImporteOrdenDePago.Size = new System.Drawing.Size(135, 15);
            this.lblImporteOrdenDePago.TabIndex = 21;
            this.lblImporteOrdenDePago.Text = "Importe Orden de Pago";
            // 
            // lblImporteNeto
            // 
            this.lblImporteNeto.AutoSize = true;
            this.lblImporteNeto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImporteNeto.Location = new System.Drawing.Point(12, 84);
            this.lblImporteNeto.Name = "lblImporteNeto";
            this.lblImporteNeto.Size = new System.Drawing.Size(78, 15);
            this.lblImporteNeto.TabIndex = 22;
            this.lblImporteNeto.Text = "Importe Neto";
            // 
            // txtImporteNeto
            // 
            this.txtImporteNeto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImporteNeto.Location = new System.Drawing.Point(192, 84);
            this.txtImporteNeto.MaxLength = 12;
            this.txtImporteNeto.Name = "txtImporteNeto";
            this.txtImporteNeto.Size = new System.Drawing.Size(275, 21);
            this.txtImporteNeto.TabIndex = 4;
            this.txtImporteNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtImporteNeto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImporteNeto_KeyPress);
            // 
            // txtImportePagosAnteriores
            // 
            this.txtImportePagosAnteriores.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImportePagosAnteriores.Location = new System.Drawing.Point(192, 109);
            this.txtImportePagosAnteriores.MaxLength = 12;
            this.txtImportePagosAnteriores.Name = "txtImportePagosAnteriores";
            this.txtImportePagosAnteriores.Size = new System.Drawing.Size(275, 21);
            this.txtImportePagosAnteriores.TabIndex = 5;
            this.txtImportePagosAnteriores.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblImporteNetoPagosAnteriores
            // 
            this.lblImporteNetoPagosAnteriores.AutoSize = true;
            this.lblImporteNetoPagosAnteriores.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImporteNetoPagosAnteriores.Location = new System.Drawing.Point(12, 110);
            this.lblImporteNetoPagosAnteriores.Name = "lblImporteNetoPagosAnteriores";
            this.lblImporteNetoPagosAnteriores.Size = new System.Drawing.Size(174, 15);
            this.lblImporteNetoPagosAnteriores.TabIndex = 25;
            this.lblImporteNetoPagosAnteriores.Text = "Importe Neto Pagos Anteriores";
            // 
            // lblImporteRetencion
            // 
            this.lblImporteRetencion.AutoSize = true;
            this.lblImporteRetencion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImporteRetencion.Location = new System.Drawing.Point(12, 191);
            this.lblImporteRetencion.Name = "lblImporteRetencion";
            this.lblImporteRetencion.Size = new System.Drawing.Size(174, 15);
            this.lblImporteRetencion.TabIndex = 26;
            this.lblImporteRetencion.Text = "Importe Retención del Período";
            // 
            // txtImporteRetencionPeriodo
            // 
            this.txtImporteRetencionPeriodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImporteRetencionPeriodo.Location = new System.Drawing.Point(192, 190);
            this.txtImporteRetencionPeriodo.MaxLength = 12;
            this.txtImporteRetencionPeriodo.Name = "txtImporteRetencionPeriodo";
            this.txtImporteRetencionPeriodo.Size = new System.Drawing.Size(275, 21);
            this.txtImporteRetencionPeriodo.TabIndex = 6;
            this.txtImporteRetencionPeriodo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtImporteRetencionPeriodo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImporteRetencion_KeyPress);
            // 
            // txtImporteRetencionAnterior
            // 
            this.txtImporteRetencionAnterior.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImporteRetencionAnterior.Location = new System.Drawing.Point(192, 163);
            this.txtImporteRetencionAnterior.MaxLength = 12;
            this.txtImporteRetencionAnterior.Name = "txtImporteRetencionAnterior";
            this.txtImporteRetencionAnterior.Size = new System.Drawing.Size(275, 21);
            this.txtImporteRetencionAnterior.TabIndex = 7;
            this.txtImporteRetencionAnterior.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblImporteRetencionAnterior
            // 
            this.lblImporteRetencionAnterior.AutoSize = true;
            this.lblImporteRetencionAnterior.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImporteRetencionAnterior.Location = new System.Drawing.Point(12, 164);
            this.lblImporteRetencionAnterior.Name = "lblImporteRetencionAnterior";
            this.lblImporteRetencionAnterior.Size = new System.Drawing.Size(153, 15);
            this.lblImporteRetencionAnterior.TabIndex = 29;
            this.lblImporteRetencionAnterior.Text = "Importe Retención Anterior";
            // 
            // lblImporteRetencionActual
            // 
            this.lblImporteRetencionActual.AutoSize = true;
            this.lblImporteRetencionActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImporteRetencionActual.Location = new System.Drawing.Point(12, 137);
            this.lblImporteRetencionActual.Name = "lblImporteRetencionActual";
            this.lblImporteRetencionActual.Size = new System.Drawing.Size(144, 15);
            this.lblImporteRetencionActual.TabIndex = 30;
            this.lblImporteRetencionActual.Text = "Importe Retención Actual";
            // 
            // txtImporteRetencionActual
            // 
            this.txtImporteRetencionActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImporteRetencionActual.Location = new System.Drawing.Point(192, 136);
            this.txtImporteRetencionActual.MaxLength = 12;
            this.txtImporteRetencionActual.Name = "txtImporteRetencionActual";
            this.txtImporteRetencionActual.Size = new System.Drawing.Size(275, 21);
            this.txtImporteRetencionActual.TabIndex = 8;
            this.txtImporteRetencionActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtImporteRetencionActual.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImporteRetencionActual_KeyPress);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(371, 226);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(96, 35);
            this.btnAceptar.TabIndex = 9;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // frmDetalleRetencion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 274);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtImporteRetencionActual);
            this.Controls.Add(this.lblImporteRetencionActual);
            this.Controls.Add(this.lblImporteRetencionAnterior);
            this.Controls.Add(this.txtImporteRetencionAnterior);
            this.Controls.Add(this.txtImporteRetencionPeriodo);
            this.Controls.Add(this.lblImporteRetencion);
            this.Controls.Add(this.lblImporteNetoPagosAnteriores);
            this.Controls.Add(this.txtImportePagosAnteriores);
            this.Controls.Add(this.txtImporteNeto);
            this.Controls.Add(this.lblImporteNeto);
            this.Controls.Add(this.lblImporteOrdenDePago);
            this.Controls.Add(this.dtpPeriodo);
            this.Controls.Add(this.txtImporteOrdenDePago);
            this.Controls.Add(this.lblPeriodo);
            this.MaximizeBox = false;
            this.Name = "frmDetalleRetencion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalle Retención";
            this.Load += new System.EventHandler(this.DetalleRetencion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtImporteOrdenDePago;
        private System.Windows.Forms.Label lblPeriodo;
        private System.Windows.Forms.DateTimePicker dtpPeriodo;
        private System.Windows.Forms.Label lblImporteOrdenDePago;
        private System.Windows.Forms.Label lblImporteNeto;
        private System.Windows.Forms.TextBox txtImporteNeto;
        private System.Windows.Forms.TextBox txtImportePagosAnteriores;
        private System.Windows.Forms.Label lblImporteNetoPagosAnteriores;
        private System.Windows.Forms.Label lblImporteRetencion;
        private System.Windows.Forms.TextBox txtImporteRetencionPeriodo;
        private System.Windows.Forms.TextBox txtImporteRetencionAnterior;
        private System.Windows.Forms.Label lblImporteRetencionAnterior;
        private System.Windows.Forms.Label lblImporteRetencionActual;
        private System.Windows.Forms.TextBox txtImporteRetencionActual;
        private System.Windows.Forms.Button btnAceptar;
    }
}