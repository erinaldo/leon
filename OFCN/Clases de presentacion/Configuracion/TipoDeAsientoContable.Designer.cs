namespace OFC
{
    partial class frmTipoDeAsientoContable
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlIzquierda = new System.Windows.Forms.Panel();
            this.btnCrearTipoDeAsiento = new System.Windows.Forms.Button();
            this.lblListaDeTipoDeAsiento = new System.Windows.Forms.Label();
            this.btnBorrarTipoDeAsiento = new System.Windows.Forms.Button();
            this.pnlDerechaInferior = new System.Windows.Forms.Panel();
            this.btnGuardarRelacion = new System.Windows.Forms.Button();
            this.cbxTipoDeAsiento = new System.Windows.Forms.ComboBox();
            this.lblTipoDeAsiento = new System.Windows.Forms.Label();
            this.cbxTipoDeComprobante = new System.Windows.Forms.ComboBox();
            this.lblRelacionComprobanteAsiento = new System.Windows.Forms.Label();
            this.lblTipoDeComprobante = new System.Windows.Forms.Label();
            this.lblModulo = new System.Windows.Forms.Label();
            this.cbxModulo = new System.Windows.Forms.ComboBox();
            this.pnlDerecha = new System.Windows.Forms.Panel();
            this.pnlDerechoInterno = new System.Windows.Forms.Panel();
            this.cbxCodigoDeCuenta = new System.Windows.Forms.ComboBox();
            this.btnCancelarDetalleAsiento = new System.Windows.Forms.Button();
            this.btnGuardarDetalleAsiento = new System.Windows.Forms.Button();
            this.lblCodigoDeCuenta = new System.Windows.Forms.Label();
            this.lblDebe = new System.Windows.Forms.Label();
            this.cbxDebe = new System.Windows.Forms.ComboBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblHaber = new System.Windows.Forms.Label();
            this.cbxHaber = new System.Windows.Forms.ComboBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.btnCrearDetalleAsiento = new System.Windows.Forms.Button();
            this.lblDetalleDelTipoDeAsiento = new System.Windows.Forms.Label();
            this.dgvDetalleDelTipoDeAsiento = new System.Windows.Forms.DataGridView();
            this.btnBorrarDetalleAsiento = new System.Windows.Forms.Button();
            this.dgvListaDeTipoDeAsiento = new System.Windows.Forms.DataGridView();
            this.btnCancelarRelacion = new System.Windows.Forms.Button();
            this.lblEtiquetaTipoDeAsiento = new System.Windows.Forms.Label();
            this.pnlIzquierda.SuspendLayout();
            this.pnlDerechaInferior.SuspendLayout();
            this.pnlDerecha.SuspendLayout();
            this.pnlDerechoInterno.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleDelTipoDeAsiento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaDeTipoDeAsiento)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlIzquierda
            // 
            this.pnlIzquierda.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlIzquierda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlIzquierda.Controls.Add(this.btnCrearTipoDeAsiento);
            this.pnlIzquierda.Controls.Add(this.lblListaDeTipoDeAsiento);
            this.pnlIzquierda.Controls.Add(this.dgvListaDeTipoDeAsiento);
            this.pnlIzquierda.Controls.Add(this.btnBorrarTipoDeAsiento);
            this.pnlIzquierda.Location = new System.Drawing.Point(12, 12);
            this.pnlIzquierda.Name = "pnlIzquierda";
            this.pnlIzquierda.Size = new System.Drawing.Size(653, 682);
            this.pnlIzquierda.TabIndex = 1;
            // 
            // btnCrearTipoDeAsiento
            // 
            this.btnCrearTipoDeAsiento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCrearTipoDeAsiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearTipoDeAsiento.Location = new System.Drawing.Point(532, 236);
            this.btnCrearTipoDeAsiento.Name = "btnCrearTipoDeAsiento";
            this.btnCrearTipoDeAsiento.Size = new System.Drawing.Size(48, 33);
            this.btnCrearTipoDeAsiento.TabIndex = 1;
            this.btnCrearTipoDeAsiento.Text = "+";
            this.btnCrearTipoDeAsiento.UseVisualStyleBackColor = true;
            this.btnCrearTipoDeAsiento.Click += new System.EventHandler(this.btnCrearTipoDeAsiento_Click);
            // 
            // lblListaDeTipoDeAsiento
            // 
            this.lblListaDeTipoDeAsiento.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblListaDeTipoDeAsiento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblListaDeTipoDeAsiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListaDeTipoDeAsiento.Location = new System.Drawing.Point(16, 11);
            this.lblListaDeTipoDeAsiento.Name = "lblListaDeTipoDeAsiento";
            this.lblListaDeTipoDeAsiento.Size = new System.Drawing.Size(618, 25);
            this.lblListaDeTipoDeAsiento.TabIndex = 58;
            this.lblListaDeTipoDeAsiento.Text = "Lista de Tipo de Asiento";
            this.lblListaDeTipoDeAsiento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnBorrarTipoDeAsiento
            // 
            this.btnBorrarTipoDeAsiento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBorrarTipoDeAsiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrarTipoDeAsiento.Location = new System.Drawing.Point(586, 236);
            this.btnBorrarTipoDeAsiento.Name = "btnBorrarTipoDeAsiento";
            this.btnBorrarTipoDeAsiento.Size = new System.Drawing.Size(48, 33);
            this.btnBorrarTipoDeAsiento.TabIndex = 2;
            this.btnBorrarTipoDeAsiento.Text = "-";
            this.btnBorrarTipoDeAsiento.UseVisualStyleBackColor = true;
            // 
            // pnlDerechaInferior
            // 
            this.pnlDerechaInferior.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlDerechaInferior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDerechaInferior.Controls.Add(this.btnCancelarRelacion);
            this.pnlDerechaInferior.Controls.Add(this.btnGuardarRelacion);
            this.pnlDerechaInferior.Controls.Add(this.cbxTipoDeAsiento);
            this.pnlDerechaInferior.Controls.Add(this.lblTipoDeAsiento);
            this.pnlDerechaInferior.Controls.Add(this.cbxTipoDeComprobante);
            this.pnlDerechaInferior.Controls.Add(this.lblRelacionComprobanteAsiento);
            this.pnlDerechaInferior.Controls.Add(this.lblTipoDeComprobante);
            this.pnlDerechaInferior.Controls.Add(this.lblModulo);
            this.pnlDerechaInferior.Controls.Add(this.cbxModulo);
            this.pnlDerechaInferior.Location = new System.Drawing.Point(695, 532);
            this.pnlDerechaInferior.Name = "pnlDerechaInferior";
            this.pnlDerechaInferior.Size = new System.Drawing.Size(653, 162);
            this.pnlDerechaInferior.TabIndex = 73;
            // 
            // btnGuardarRelacion
            // 
            this.btnGuardarRelacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarRelacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarRelacion.Location = new System.Drawing.Point(497, 67);
            this.btnGuardarRelacion.Name = "btnGuardarRelacion";
            this.btnGuardarRelacion.Size = new System.Drawing.Size(114, 30);
            this.btnGuardarRelacion.TabIndex = 4;
            this.btnGuardarRelacion.Text = "Guardar";
            this.btnGuardarRelacion.UseVisualStyleBackColor = true;
            // 
            // cbxTipoDeAsiento
            // 
            this.cbxTipoDeAsiento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxTipoDeAsiento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxTipoDeAsiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxTipoDeAsiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxTipoDeAsiento.FormattingEnabled = true;
            this.cbxTipoDeAsiento.Location = new System.Drawing.Point(145, 110);
            this.cbxTipoDeAsiento.Name = "cbxTipoDeAsiento";
            this.cbxTipoDeAsiento.Size = new System.Drawing.Size(315, 23);
            this.cbxTipoDeAsiento.TabIndex = 3;
            // 
            // lblTipoDeAsiento
            // 
            this.lblTipoDeAsiento.AutoSize = true;
            this.lblTipoDeAsiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoDeAsiento.Location = new System.Drawing.Point(13, 113);
            this.lblTipoDeAsiento.Name = "lblTipoDeAsiento";
            this.lblTipoDeAsiento.Size = new System.Drawing.Size(91, 15);
            this.lblTipoDeAsiento.TabIndex = 73;
            this.lblTipoDeAsiento.Text = "Tipo de Asiento";
            // 
            // cbxTipoDeComprobante
            // 
            this.cbxTipoDeComprobante.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxTipoDeComprobante.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxTipoDeComprobante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxTipoDeComprobante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxTipoDeComprobante.FormattingEnabled = true;
            this.cbxTipoDeComprobante.Location = new System.Drawing.Point(145, 81);
            this.cbxTipoDeComprobante.Name = "cbxTipoDeComprobante";
            this.cbxTipoDeComprobante.Size = new System.Drawing.Size(315, 23);
            this.cbxTipoDeComprobante.TabIndex = 2;
            // 
            // lblRelacionComprobanteAsiento
            // 
            this.lblRelacionComprobanteAsiento.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblRelacionComprobanteAsiento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRelacionComprobanteAsiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRelacionComprobanteAsiento.Location = new System.Drawing.Point(16, 11);
            this.lblRelacionComprobanteAsiento.Name = "lblRelacionComprobanteAsiento";
            this.lblRelacionComprobanteAsiento.Size = new System.Drawing.Size(618, 25);
            this.lblRelacionComprobanteAsiento.TabIndex = 76;
            this.lblRelacionComprobanteAsiento.Text = "Relación del Tipo de Comprobante con Tipo de Asiento";
            this.lblRelacionComprobanteAsiento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTipoDeComprobante
            // 
            this.lblTipoDeComprobante.AutoSize = true;
            this.lblTipoDeComprobante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoDeComprobante.Location = new System.Drawing.Point(13, 84);
            this.lblTipoDeComprobante.Name = "lblTipoDeComprobante";
            this.lblTipoDeComprobante.Size = new System.Drawing.Size(126, 15);
            this.lblTipoDeComprobante.TabIndex = 77;
            this.lblTipoDeComprobante.Text = "Tipo de Comprobante";
            // 
            // lblModulo
            // 
            this.lblModulo.AutoSize = true;
            this.lblModulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModulo.Location = new System.Drawing.Point(13, 55);
            this.lblModulo.Name = "lblModulo";
            this.lblModulo.Size = new System.Drawing.Size(49, 15);
            this.lblModulo.TabIndex = 75;
            this.lblModulo.Text = "Módulo";
            // 
            // cbxModulo
            // 
            this.cbxModulo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxModulo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxModulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxModulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxModulo.FormattingEnabled = true;
            this.cbxModulo.Location = new System.Drawing.Point(145, 52);
            this.cbxModulo.Name = "cbxModulo";
            this.cbxModulo.Size = new System.Drawing.Size(315, 23);
            this.cbxModulo.TabIndex = 1;
            // 
            // pnlDerecha
            // 
            this.pnlDerecha.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlDerecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDerecha.Controls.Add(this.lblEtiquetaTipoDeAsiento);
            this.pnlDerecha.Controls.Add(this.pnlDerechoInterno);
            this.pnlDerecha.Controls.Add(this.btnCrearDetalleAsiento);
            this.pnlDerecha.Controls.Add(this.lblDetalleDelTipoDeAsiento);
            this.pnlDerecha.Controls.Add(this.dgvDetalleDelTipoDeAsiento);
            this.pnlDerecha.Controls.Add(this.btnBorrarDetalleAsiento);
            this.pnlDerecha.Location = new System.Drawing.Point(695, 12);
            this.pnlDerecha.Name = "pnlDerecha";
            this.pnlDerecha.Size = new System.Drawing.Size(653, 514);
            this.pnlDerecha.TabIndex = 1;
            // 
            // pnlDerechoInterno
            // 
            this.pnlDerechoInterno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDerechoInterno.Controls.Add(this.cbxCodigoDeCuenta);
            this.pnlDerechoInterno.Controls.Add(this.btnCancelarDetalleAsiento);
            this.pnlDerechoInterno.Controls.Add(this.btnGuardarDetalleAsiento);
            this.pnlDerechoInterno.Controls.Add(this.lblCodigoDeCuenta);
            this.pnlDerechoInterno.Controls.Add(this.lblDebe);
            this.pnlDerechoInterno.Controls.Add(this.cbxDebe);
            this.pnlDerechoInterno.Controls.Add(this.txtDescripcion);
            this.pnlDerechoInterno.Controls.Add(this.lblHaber);
            this.pnlDerechoInterno.Controls.Add(this.cbxHaber);
            this.pnlDerechoInterno.Controls.Add(this.lblDescripcion);
            this.pnlDerechoInterno.Location = new System.Drawing.Point(16, 346);
            this.pnlDerechoInterno.Name = "pnlDerechoInterno";
            this.pnlDerechoInterno.Size = new System.Drawing.Size(618, 146);
            this.pnlDerechoInterno.TabIndex = 76;
            // 
            // cbxCodigoDeCuenta
            // 
            this.cbxCodigoDeCuenta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxCodigoDeCuenta.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxCodigoDeCuenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxCodigoDeCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxCodigoDeCuenta.FormattingEnabled = true;
            this.cbxCodigoDeCuenta.Location = new System.Drawing.Point(135, 20);
            this.cbxCodigoDeCuenta.Name = "cbxCodigoDeCuenta";
            this.cbxCodigoDeCuenta.Size = new System.Drawing.Size(309, 23);
            this.cbxCodigoDeCuenta.TabIndex = 3;
            // 
            // btnCancelarDetalleAsiento
            // 
            this.btnCancelarDetalleAsiento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelarDetalleAsiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarDetalleAsiento.Location = new System.Drawing.Point(481, 98);
            this.btnCancelarDetalleAsiento.Name = "btnCancelarDetalleAsiento";
            this.btnCancelarDetalleAsiento.Size = new System.Drawing.Size(114, 30);
            this.btnCancelarDetalleAsiento.TabIndex = 8;
            this.btnCancelarDetalleAsiento.Text = "Cancelar";
            this.btnCancelarDetalleAsiento.UseVisualStyleBackColor = true;
            // 
            // btnGuardarDetalleAsiento
            // 
            this.btnGuardarDetalleAsiento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarDetalleAsiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarDetalleAsiento.Location = new System.Drawing.Point(481, 62);
            this.btnGuardarDetalleAsiento.Name = "btnGuardarDetalleAsiento";
            this.btnGuardarDetalleAsiento.Size = new System.Drawing.Size(114, 30);
            this.btnGuardarDetalleAsiento.TabIndex = 7;
            this.btnGuardarDetalleAsiento.Text = "Guardar";
            this.btnGuardarDetalleAsiento.UseVisualStyleBackColor = true;
            // 
            // lblCodigoDeCuenta
            // 
            this.lblCodigoDeCuenta.AutoSize = true;
            this.lblCodigoDeCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigoDeCuenta.Location = new System.Drawing.Point(14, 23);
            this.lblCodigoDeCuenta.Name = "lblCodigoDeCuenta";
            this.lblCodigoDeCuenta.Size = new System.Drawing.Size(105, 15);
            this.lblCodigoDeCuenta.TabIndex = 63;
            this.lblCodigoDeCuenta.Text = "Código de Cuenta";
            // 
            // lblDebe
            // 
            this.lblDebe.AutoSize = true;
            this.lblDebe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDebe.Location = new System.Drawing.Point(14, 52);
            this.lblDebe.Name = "lblDebe";
            this.lblDebe.Size = new System.Drawing.Size(37, 15);
            this.lblDebe.TabIndex = 66;
            this.lblDebe.Text = "Debe";
            // 
            // cbxDebe
            // 
            this.cbxDebe.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxDebe.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxDebe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxDebe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxDebe.FormattingEnabled = true;
            this.cbxDebe.Location = new System.Drawing.Point(135, 49);
            this.cbxDebe.Name = "cbxDebe";
            this.cbxDebe.Size = new System.Drawing.Size(309, 23);
            this.cbxDebe.TabIndex = 4;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(135, 107);
            this.txtDescripcion.MaxLength = 10;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(309, 21);
            this.txtDescripcion.TabIndex = 6;
            // 
            // lblHaber
            // 
            this.lblHaber.AutoSize = true;
            this.lblHaber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHaber.Location = new System.Drawing.Point(14, 81);
            this.lblHaber.Name = "lblHaber";
            this.lblHaber.Size = new System.Drawing.Size(41, 15);
            this.lblHaber.TabIndex = 68;
            this.lblHaber.Text = "Haber";
            // 
            // cbxHaber
            // 
            this.cbxHaber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxHaber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxHaber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxHaber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxHaber.FormattingEnabled = true;
            this.cbxHaber.Location = new System.Drawing.Point(135, 78);
            this.cbxHaber.Name = "cbxHaber";
            this.cbxHaber.Size = new System.Drawing.Size(309, 23);
            this.cbxHaber.TabIndex = 5;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.Location = new System.Drawing.Point(14, 110);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(72, 15);
            this.lblDescripcion.TabIndex = 70;
            this.lblDescripcion.Text = "Descripción";
            // 
            // btnCrearDetalleAsiento
            // 
            this.btnCrearDetalleAsiento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCrearDetalleAsiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearDetalleAsiento.Location = new System.Drawing.Point(532, 295);
            this.btnCrearDetalleAsiento.Name = "btnCrearDetalleAsiento";
            this.btnCrearDetalleAsiento.Size = new System.Drawing.Size(48, 33);
            this.btnCrearDetalleAsiento.TabIndex = 1;
            this.btnCrearDetalleAsiento.Text = "+";
            this.btnCrearDetalleAsiento.UseVisualStyleBackColor = true;
            // 
            // lblDetalleDelTipoDeAsiento
            // 
            this.lblDetalleDelTipoDeAsiento.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblDetalleDelTipoDeAsiento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDetalleDelTipoDeAsiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalleDelTipoDeAsiento.Location = new System.Drawing.Point(16, 11);
            this.lblDetalleDelTipoDeAsiento.Name = "lblDetalleDelTipoDeAsiento";
            this.lblDetalleDelTipoDeAsiento.Size = new System.Drawing.Size(618, 25);
            this.lblDetalleDelTipoDeAsiento.TabIndex = 58;
            this.lblDetalleDelTipoDeAsiento.Text = "Detalle del Tipo de Asiento";
            this.lblDetalleDelTipoDeAsiento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvDetalleDelTipoDeAsiento
            // 
            this.dgvDetalleDelTipoDeAsiento.AllowUserToAddRows = false;
            this.dgvDetalleDelTipoDeAsiento.AllowUserToDeleteRows = false;
            this.dgvDetalleDelTipoDeAsiento.AllowUserToResizeColumns = false;
            this.dgvDetalleDelTipoDeAsiento.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalleDelTipoDeAsiento.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDetalleDelTipoDeAsiento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetalleDelTipoDeAsiento.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDetalleDelTipoDeAsiento.Location = new System.Drawing.Point(16, 76);
            this.dgvDetalleDelTipoDeAsiento.MultiSelect = false;
            this.dgvDetalleDelTipoDeAsiento.Name = "dgvDetalleDelTipoDeAsiento";
            this.dgvDetalleDelTipoDeAsiento.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalleDelTipoDeAsiento.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDetalleDelTipoDeAsiento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalleDelTipoDeAsiento.Size = new System.Drawing.Size(618, 213);
            this.dgvDetalleDelTipoDeAsiento.TabIndex = 14;
            // 
            // btnBorrarDetalleAsiento
            // 
            this.btnBorrarDetalleAsiento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBorrarDetalleAsiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrarDetalleAsiento.Location = new System.Drawing.Point(586, 295);
            this.btnBorrarDetalleAsiento.Name = "btnBorrarDetalleAsiento";
            this.btnBorrarDetalleAsiento.Size = new System.Drawing.Size(48, 33);
            this.btnBorrarDetalleAsiento.TabIndex = 2;
            this.btnBorrarDetalleAsiento.Text = "-";
            this.btnBorrarDetalleAsiento.UseVisualStyleBackColor = true;
            // 
            // dgvListaDeTipoDeAsiento
            // 
            this.dgvListaDeTipoDeAsiento.AllowUserToAddRows = false;
            this.dgvListaDeTipoDeAsiento.AllowUserToDeleteRows = false;
            this.dgvListaDeTipoDeAsiento.AllowUserToResizeColumns = false;
            this.dgvListaDeTipoDeAsiento.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListaDeTipoDeAsiento.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListaDeTipoDeAsiento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListaDeTipoDeAsiento.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvListaDeTipoDeAsiento.Location = new System.Drawing.Point(16, 39);
            this.dgvListaDeTipoDeAsiento.MultiSelect = false;
            this.dgvListaDeTipoDeAsiento.Name = "dgvListaDeTipoDeAsiento";
            this.dgvListaDeTipoDeAsiento.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListaDeTipoDeAsiento.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvListaDeTipoDeAsiento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaDeTipoDeAsiento.Size = new System.Drawing.Size(618, 191);
            this.dgvListaDeTipoDeAsiento.TabIndex = 99;
            // 
            // btnCancelarRelacion
            // 
            this.btnCancelarRelacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelarRelacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarRelacion.Location = new System.Drawing.Point(497, 103);
            this.btnCancelarRelacion.Name = "btnCancelarRelacion";
            this.btnCancelarRelacion.Size = new System.Drawing.Size(114, 30);
            this.btnCancelarRelacion.TabIndex = 5;
            this.btnCancelarRelacion.Text = "Cancelar";
            this.btnCancelarRelacion.UseVisualStyleBackColor = true;
            // 
            // lblEtiquetaTipoDeAsiento
            // 
            this.lblEtiquetaTipoDeAsiento.AutoSize = true;
            this.lblEtiquetaTipoDeAsiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEtiquetaTipoDeAsiento.Location = new System.Drawing.Point(13, 49);
            this.lblEtiquetaTipoDeAsiento.Name = "lblEtiquetaTipoDeAsiento";
            this.lblEtiquetaTipoDeAsiento.Size = new System.Drawing.Size(91, 15);
            this.lblEtiquetaTipoDeAsiento.TabIndex = 77;
            this.lblEtiquetaTipoDeAsiento.Text = "Tipo de Asiento";
            // 
            // frmTipoDeAsientoContable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 724);
            this.Controls.Add(this.pnlDerecha);
            this.Controls.Add(this.pnlDerechaInferior);
            this.Controls.Add(this.pnlIzquierda);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmTipoDeAsientoContable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tipo de Asiento Contable";
            this.Load += new System.EventHandler(this.frmTipoDeAsientoContable_Load);
            this.pnlIzquierda.ResumeLayout(false);
            this.pnlDerechaInferior.ResumeLayout(false);
            this.pnlDerechaInferior.PerformLayout();
            this.pnlDerecha.ResumeLayout(false);
            this.pnlDerecha.PerformLayout();
            this.pnlDerechoInterno.ResumeLayout(false);
            this.pnlDerechoInterno.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleDelTipoDeAsiento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaDeTipoDeAsiento)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlIzquierda;
        private System.Windows.Forms.Label lblListaDeTipoDeAsiento;
        private System.Windows.Forms.Panel pnlDerechaInferior;
        private System.Windows.Forms.Button btnCrearTipoDeAsiento;
        private System.Windows.Forms.Button btnBorrarTipoDeAsiento;
        private System.Windows.Forms.ComboBox cbxTipoDeComprobante;
        private System.Windows.Forms.Label lblRelacionComprobanteAsiento;
        private System.Windows.Forms.Label lblTipoDeComprobante;
        private System.Windows.Forms.Label lblModulo;
        private System.Windows.Forms.ComboBox cbxModulo;
        private System.Windows.Forms.ComboBox cbxTipoDeAsiento;
        private System.Windows.Forms.Label lblTipoDeAsiento;
        private System.Windows.Forms.Button btnGuardarRelacion;
        private System.Windows.Forms.DataGridView dgvListaDeTipoDeAsiento;
        private System.Windows.Forms.Panel pnlDerecha;
        private System.Windows.Forms.Panel pnlDerechoInterno;
        private System.Windows.Forms.ComboBox cbxCodigoDeCuenta;
        private System.Windows.Forms.Button btnCancelarDetalleAsiento;
        private System.Windows.Forms.Button btnGuardarDetalleAsiento;
        private System.Windows.Forms.Label lblCodigoDeCuenta;
        private System.Windows.Forms.Label lblDebe;
        private System.Windows.Forms.ComboBox cbxDebe;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblHaber;
        private System.Windows.Forms.ComboBox cbxHaber;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Button btnCrearDetalleAsiento;
        private System.Windows.Forms.Label lblDetalleDelTipoDeAsiento;
        private System.Windows.Forms.DataGridView dgvDetalleDelTipoDeAsiento;
        private System.Windows.Forms.Button btnBorrarDetalleAsiento;
        private System.Windows.Forms.Button btnCancelarRelacion;
        private System.Windows.Forms.Label lblEtiquetaTipoDeAsiento;
    }
}