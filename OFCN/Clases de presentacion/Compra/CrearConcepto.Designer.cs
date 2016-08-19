namespace OFC
{
    partial class frmCrearConcepto
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
            this.cbhVigente = new System.Windows.Forms.CheckBox();
            this.cbxPorcentajeIvaCompras = new System.Windows.Forms.ComboBox();
            this.lblPorcentajeIva = new System.Windows.Forms.Label();
            this.cbxDescripcionCuentaCompra = new System.Windows.Forms.ComboBox();
            this.cbxCodigoCuentaCompra = new System.Windows.Forms.ComboBox();
            this.lblDescripcionCuentaCompra = new System.Windows.Forms.Label();
            this.cbxIvaCompras = new System.Windows.Forms.ComboBox();
            this.lblIvaCompras = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblDatosDelCliente = new System.Windows.Forms.Label();
            this.lblCodigoCuentaCompra = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.pnlDerecha.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDerecha
            // 
            this.pnlDerecha.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlDerecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDerecha.Controls.Add(this.cbhVigente);
            this.pnlDerecha.Controls.Add(this.cbxPorcentajeIvaCompras);
            this.pnlDerecha.Controls.Add(this.lblPorcentajeIva);
            this.pnlDerecha.Controls.Add(this.cbxDescripcionCuentaCompra);
            this.pnlDerecha.Controls.Add(this.cbxCodigoCuentaCompra);
            this.pnlDerecha.Controls.Add(this.lblDescripcionCuentaCompra);
            this.pnlDerecha.Controls.Add(this.cbxIvaCompras);
            this.pnlDerecha.Controls.Add(this.lblIvaCompras);
            this.pnlDerecha.Controls.Add(this.btnGuardar);
            this.pnlDerecha.Controls.Add(this.lblDatosDelCliente);
            this.pnlDerecha.Controls.Add(this.lblCodigoCuentaCompra);
            this.pnlDerecha.Controls.Add(this.txtCodigo);
            this.pnlDerecha.Controls.Add(this.lblCodigo);
            this.pnlDerecha.Controls.Add(this.txtDescripcion);
            this.pnlDerecha.Controls.Add(this.lblDescripcion);
            this.pnlDerecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlDerecha.Location = new System.Drawing.Point(12, 12);
            this.pnlDerecha.Name = "pnlDerecha";
            this.pnlDerecha.Size = new System.Drawing.Size(649, 260);
            this.pnlDerecha.TabIndex = 3;
            // 
            // cbhVigente
            // 
            this.cbhVigente.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbhVigente.Checked = true;
            this.cbhVigente.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbhVigente.Enabled = false;
            this.cbhVigente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbhVigente.Location = new System.Drawing.Point(12, 172);
            this.cbhVigente.Name = "cbhVigente";
            this.cbhVigente.Size = new System.Drawing.Size(159, 24);
            this.cbhVigente.TabIndex = 7;
            this.cbhVigente.Text = "Vigente";
            this.cbhVigente.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.cbhVigente.UseVisualStyleBackColor = true;
            // 
            // cbxPorcentajeIvaCompras
            // 
            this.cbxPorcentajeIvaCompras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPorcentajeIvaCompras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxPorcentajeIvaCompras.FormattingEnabled = true;
            this.cbxPorcentajeIvaCompras.Location = new System.Drawing.Point(367, 144);
            this.cbxPorcentajeIvaCompras.Name = "cbxPorcentajeIvaCompras";
            this.cbxPorcentajeIvaCompras.Size = new System.Drawing.Size(263, 23);
            this.cbxPorcentajeIvaCompras.TabIndex = 6;
            // 
            // lblPorcentajeIva
            // 
            this.lblPorcentajeIva.AutoSize = true;
            this.lblPorcentajeIva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPorcentajeIva.Location = new System.Drawing.Point(289, 147);
            this.lblPorcentajeIva.Name = "lblPorcentajeIva";
            this.lblPorcentajeIva.Size = new System.Drawing.Size(66, 15);
            this.lblPorcentajeIva.TabIndex = 139;
            this.lblPorcentajeIva.Text = "Porcentaje";
            // 
            // cbxDescripcionCuentaCompra
            // 
            this.cbxDescripcionCuentaCompra.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxDescripcionCuentaCompra.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxDescripcionCuentaCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxDescripcionCuentaCompra.FormattingEnabled = true;
            this.cbxDescripcionCuentaCompra.Location = new System.Drawing.Point(367, 115);
            this.cbxDescripcionCuentaCompra.Name = "cbxDescripcionCuentaCompra";
            this.cbxDescripcionCuentaCompra.Size = new System.Drawing.Size(263, 23);
            this.cbxDescripcionCuentaCompra.TabIndex = 4;
            // 
            // cbxCodigoCuentaCompra
            // 
            this.cbxCodigoCuentaCompra.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxCodigoCuentaCompra.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxCodigoCuentaCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxCodigoCuentaCompra.FormattingEnabled = true;
            this.cbxCodigoCuentaCompra.Location = new System.Drawing.Point(158, 115);
            this.cbxCodigoCuentaCompra.Name = "cbxCodigoCuentaCompra";
            this.cbxCodigoCuentaCompra.Size = new System.Drawing.Size(125, 23);
            this.cbxCodigoCuentaCompra.TabIndex = 3;
            // 
            // lblDescripcionCuentaCompra
            // 
            this.lblDescripcionCuentaCompra.AutoSize = true;
            this.lblDescripcionCuentaCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcionCuentaCompra.Location = new System.Drawing.Point(289, 118);
            this.lblDescripcionCuentaCompra.Name = "lblDescripcionCuentaCompra";
            this.lblDescripcionCuentaCompra.Size = new System.Drawing.Size(72, 15);
            this.lblDescripcionCuentaCompra.TabIndex = 136;
            this.lblDescripcionCuentaCompra.Text = "Descripción";
            // 
            // cbxIvaCompras
            // 
            this.cbxIvaCompras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxIvaCompras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxIvaCompras.FormattingEnabled = true;
            this.cbxIvaCompras.Location = new System.Drawing.Point(158, 144);
            this.cbxIvaCompras.Name = "cbxIvaCompras";
            this.cbxIvaCompras.Size = new System.Drawing.Size(125, 23);
            this.cbxIvaCompras.TabIndex = 5;
            // 
            // lblIvaCompras
            // 
            this.lblIvaCompras.AutoSize = true;
            this.lblIvaCompras.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIvaCompras.Location = new System.Drawing.Point(14, 147);
            this.lblIvaCompras.Name = "lblIvaCompras";
            this.lblIvaCompras.Size = new System.Drawing.Size(22, 15);
            this.lblIvaCompras.TabIndex = 134;
            this.lblIvaCompras.Text = "Iva";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.Location = new System.Drawing.Point(534, 200);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(96, 35);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.Text = "Crear";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblDatosDelCliente
            // 
            this.lblDatosDelCliente.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblDatosDelCliente.Location = new System.Drawing.Point(3, 12);
            this.lblDatosDelCliente.Name = "lblDatosDelCliente";
            this.lblDatosDelCliente.Size = new System.Drawing.Size(641, 25);
            this.lblDatosDelCliente.TabIndex = 100;
            this.lblDatosDelCliente.Text = "Datos del Concepto";
            this.lblDatosDelCliente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCodigoCuentaCompra
            // 
            this.lblCodigoCuentaCompra.AutoSize = true;
            this.lblCodigoCuentaCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigoCuentaCompra.Location = new System.Drawing.Point(14, 118);
            this.lblCodigoCuentaCompra.Name = "lblCodigoCuentaCompra";
            this.lblCodigoCuentaCompra.Size = new System.Drawing.Size(138, 15);
            this.lblCodigoCuentaCompra.TabIndex = 103;
            this.lblCodigoCuentaCompra.Text = "Cód. de Cuenta Compra";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(158, 62);
            this.txtCodigo.MaxLength = 4;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(472, 21);
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
            this.txtDescripcion.Location = new System.Drawing.Point(158, 89);
            this.txtDescripcion.MaxLength = 80;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(472, 21);
            this.txtDescripcion.TabIndex = 2;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.Location = new System.Drawing.Point(14, 91);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(72, 15);
            this.lblDescripcion.TabIndex = 102;
            this.lblDescripcion.Text = "Descripción";
            // 
            // frmCrearConcepto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 283);
            this.Controls.Add(this.pnlDerecha);
            this.MaximizeBox = false;
            this.Name = "frmCrearConcepto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crear Concepto";
            this.Load += new System.EventHandler(this.frmCrearConcepto_Load);
            this.pnlDerecha.ResumeLayout(false);
            this.pnlDerecha.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDerecha;
        private System.Windows.Forms.CheckBox cbhVigente;
        private System.Windows.Forms.ComboBox cbxPorcentajeIvaCompras;
        private System.Windows.Forms.Label lblPorcentajeIva;
        private System.Windows.Forms.ComboBox cbxDescripcionCuentaCompra;
        private System.Windows.Forms.ComboBox cbxCodigoCuentaCompra;
        private System.Windows.Forms.Label lblDescripcionCuentaCompra;
        private System.Windows.Forms.ComboBox cbxIvaCompras;
        private System.Windows.Forms.Label lblIvaCompras;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblDatosDelCliente;
        private System.Windows.Forms.Label lblCodigoCuentaCompra;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblDescripcion;
    }
}