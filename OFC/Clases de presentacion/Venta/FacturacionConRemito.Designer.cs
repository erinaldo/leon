namespace OFC
{
    partial class frmFacturacionConRemito
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlDerecho = new System.Windows.Forms.Panel();
            this.btnVistaDefinitiva = new System.Windows.Forms.Button();
            this.lblVistaPreliminar = new System.Windows.Forms.Label();
            this.tbcFacturasPendientes = new System.Windows.Forms.TabControl();
            this.tbpNroFactura = new System.Windows.Forms.TabPage();
            this.btnVistaPreliminarFactura = new System.Windows.Forms.Button();
            this.txtRenglones = new System.Windows.Forms.TextBox();
            this.lblTipoFactura = new System.Windows.Forms.Label();
            this.lblNroFactura = new System.Windows.Forms.Label();
            this.lblNroRemito = new System.Windows.Forms.Label();
            this.lblDatosDelCliente = new System.Windows.Forms.Label();
            this.txtNroFactura = new System.Windows.Forms.TextBox();
            this.btnImprimirFactura = new System.Windows.Forms.Button();
            this.txtNroRemito = new System.Windows.Forms.TextBox();
            this.lblBonificacion = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtBonificacion = new System.Windows.Forms.TextBox();
            this.lblIva = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.txtIva = new System.Windows.Forms.TextBox();
            this.txtSubtotal = new System.Windows.Forms.TextBox();
            this.dgvDetalleFactura = new System.Windows.Forms.DataGridView();
            this.btnCambiarFactura = new System.Windows.Forms.Button();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.lblFacturasPendientes = new System.Windows.Forms.Label();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.pnlIzquierda = new System.Windows.Forms.Panel();
            this.lblBonificacionDelCliente = new System.Windows.Forms.Label();
            this.txtPorcentajeDeBonificacion = new System.Windows.Forms.TextBox();
            this.txtCodCliente = new System.Windows.Forms.TextBox();
            this.lblCodCliente = new System.Windows.Forms.Label();
            this.txtNombreDelCliente = new System.Windows.Forms.TextBox();
            this.lblNombreDelCliente = new System.Windows.Forms.Label();
            this.chbDesglosarEnFactura = new System.Windows.Forms.CheckBox();
            this.btnX = new System.Windows.Forms.Button();
            this.cbxMotivoDescuento = new System.Windows.Forms.ComboBox();
            this.lblMotivoDescuento = new System.Windows.Forms.Label();
            this.btnProcesar = new System.Windows.Forms.Button();
            this.txtNroOrden = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.cbxFiltroNroDeRemito = new System.Windows.Forms.ComboBox();
            this.cbxServicioAdicional = new System.Windows.Forms.ComboBox();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.cbxTrabajo = new System.Windows.Forms.ComboBox();
            this.cbxMedidaDeCubierta = new System.Windows.Forms.ComboBox();
            this.lblCoche = new System.Windows.Forms.Label();
            this.txtCoche = new System.Windows.Forms.TextBox();
            this.txtPorcentajeAPagar = new System.Windows.Forms.TextBox();
            this.lblPorcentajeAPagar = new System.Windows.Forms.Label();
            this.lblNroInterno = new System.Windows.Forms.Label();
            this.lblFiltroNroDeRemito = new System.Windows.Forms.Label();
            this.txtNroSerie = new System.Windows.Forms.TextBox();
            this.lblNroSerie = new System.Windows.Forms.Label();
            this.lblServicioAdicional = new System.Windows.Forms.Label();
            this.lblDetalleDelRemito = new System.Windows.Forms.Label();
            this.cbxMarca = new System.Windows.Forms.ComboBox();
            this.dgvOrdenesDeTrabajo = new System.Windows.Forms.DataGridView();
            this.txtNroInterno = new System.Windows.Forms.TextBox();
            this.lblRenglon = new System.Windows.Forms.Label();
            this.lblTrabajo = new System.Windows.Forms.Label();
            this.txtRenglon = new System.Windows.Forms.TextBox();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblMedidaDeCubierta = new System.Windows.Forms.Label();
            this.btnExportar = new System.Windows.Forms.Button();
            this.pnlDerecho.SuspendLayout();
            this.tbcFacturasPendientes.SuspendLayout();
            this.tbpNroFactura.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleFactura)).BeginInit();
            this.pnlIzquierda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenesDeTrabajo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDerecho
            // 
            this.pnlDerecho.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlDerecho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDerecho.Controls.Add(this.btnExportar);
            this.pnlDerecho.Controls.Add(this.btnVistaDefinitiva);
            this.pnlDerecho.Controls.Add(this.lblVistaPreliminar);
            this.pnlDerecho.Controls.Add(this.tbcFacturasPendientes);
            this.pnlDerecho.Controls.Add(this.btnRegistrar);
            this.pnlDerecho.Controls.Add(this.lblFacturasPendientes);
            this.pnlDerecho.Controls.Add(this.btnBorrar);
            this.pnlDerecho.Location = new System.Drawing.Point(737, 12);
            this.pnlDerecho.Name = "pnlDerecho";
            this.pnlDerecho.Size = new System.Drawing.Size(621, 680);
            this.pnlDerecho.TabIndex = 4;
            // 
            // btnVistaDefinitiva
            // 
            this.btnVistaDefinitiva.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnVistaDefinitiva.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVistaDefinitiva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVistaDefinitiva.Location = new System.Drawing.Point(538, 12);
            this.btnVistaDefinitiva.Name = "btnVistaDefinitiva";
            this.btnVistaDefinitiva.Size = new System.Drawing.Size(63, 25);
            this.btnVistaDefinitiva.TabIndex = 1;
            this.btnVistaDefinitiva.Text = ">>";
            this.btnVistaDefinitiva.UseVisualStyleBackColor = false;
            this.btnVistaDefinitiva.Click += new System.EventHandler(this.btnVistaDefinitiva_Click);
            // 
            // lblVistaPreliminar
            // 
            this.lblVistaPreliminar.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lblVistaPreliminar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblVistaPreliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVistaPreliminar.Location = new System.Drawing.Point(395, 12);
            this.lblVistaPreliminar.Name = "lblVistaPreliminar";
            this.lblVistaPreliminar.Size = new System.Drawing.Size(137, 25);
            this.lblVistaPreliminar.TabIndex = 102;
            this.lblVistaPreliminar.Text = "Vista Preliminar";
            this.lblVistaPreliminar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbcFacturasPendientes
            // 
            this.tbcFacturasPendientes.Controls.Add(this.tbpNroFactura);
            this.tbcFacturasPendientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbcFacturasPendientes.Location = new System.Drawing.Point(3, 44);
            this.tbcFacturasPendientes.Multiline = true;
            this.tbcFacturasPendientes.Name = "tbcFacturasPendientes";
            this.tbcFacturasPendientes.SelectedIndex = 0;
            this.tbcFacturasPendientes.Size = new System.Drawing.Size(613, 576);
            this.tbcFacturasPendientes.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tbcFacturasPendientes.TabIndex = 2;
            // 
            // tbpNroFactura
            // 
            this.tbpNroFactura.Controls.Add(this.btnVistaPreliminarFactura);
            this.tbpNroFactura.Controls.Add(this.txtRenglones);
            this.tbpNroFactura.Controls.Add(this.lblTipoFactura);
            this.tbpNroFactura.Controls.Add(this.lblNroFactura);
            this.tbpNroFactura.Controls.Add(this.lblNroRemito);
            this.tbpNroFactura.Controls.Add(this.lblDatosDelCliente);
            this.tbpNroFactura.Controls.Add(this.txtNroFactura);
            this.tbpNroFactura.Controls.Add(this.btnImprimirFactura);
            this.tbpNroFactura.Controls.Add(this.txtNroRemito);
            this.tbpNroFactura.Controls.Add(this.lblBonificacion);
            this.tbpNroFactura.Controls.Add(this.lblTotal);
            this.tbpNroFactura.Controls.Add(this.txtBonificacion);
            this.tbpNroFactura.Controls.Add(this.lblIva);
            this.tbpNroFactura.Controls.Add(this.txtTotal);
            this.tbpNroFactura.Controls.Add(this.lblSubtotal);
            this.tbpNroFactura.Controls.Add(this.txtIva);
            this.tbpNroFactura.Controls.Add(this.txtSubtotal);
            this.tbpNroFactura.Controls.Add(this.dgvDetalleFactura);
            this.tbpNroFactura.Controls.Add(this.btnCambiarFactura);
            this.tbpNroFactura.Location = new System.Drawing.Point(4, 24);
            this.tbpNroFactura.Name = "tbpNroFactura";
            this.tbpNroFactura.Padding = new System.Windows.Forms.Padding(3);
            this.tbpNroFactura.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbpNroFactura.Size = new System.Drawing.Size(605, 548);
            this.tbpNroFactura.TabIndex = 1;
            this.tbpNroFactura.Text = "F1";
            this.tbpNroFactura.UseVisualStyleBackColor = true;
            // 
            // btnVistaPreliminarFactura
            // 
            this.btnVistaPreliminarFactura.BackgroundImage = global::OFC.Properties.Resources.vista_preliminar1;
            this.btnVistaPreliminarFactura.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVistaPreliminarFactura.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVistaPreliminarFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnVistaPreliminarFactura.Location = new System.Drawing.Point(449, 508);
            this.btnVistaPreliminarFactura.Name = "btnVistaPreliminarFactura";
            this.btnVistaPreliminarFactura.Size = new System.Drawing.Size(48, 37);
            this.btnVistaPreliminarFactura.TabIndex = 5;
            this.btnVistaPreliminarFactura.UseVisualStyleBackColor = true;
            this.btnVistaPreliminarFactura.Click += new System.EventHandler(this.btnVistaPreliminarFactura_Click);
            // 
            // txtRenglones
            // 
            this.txtRenglones.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtRenglones.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtRenglones.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtRenglones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRenglones.Location = new System.Drawing.Point(274, 516);
            this.txtRenglones.MaxLength = 3;
            this.txtRenglones.Name = "txtRenglones";
            this.txtRenglones.ReadOnly = true;
            this.txtRenglones.Size = new System.Drawing.Size(39, 21);
            this.txtRenglones.TabIndex = 118;
            this.txtRenglones.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblTipoFactura
            // 
            this.lblTipoFactura.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblTipoFactura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTipoFactura.Font = new System.Drawing.Font("Comic Sans MS", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoFactura.Location = new System.Drawing.Point(531, 51);
            this.lblTipoFactura.Name = "lblTipoFactura";
            this.lblTipoFactura.Size = new System.Drawing.Size(68, 68);
            this.lblTipoFactura.TabIndex = 108;
            this.lblTipoFactura.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNroFactura
            // 
            this.lblNroFactura.AutoSize = true;
            this.lblNroFactura.Location = new System.Drawing.Point(325, 17);
            this.lblNroFactura.Name = "lblNroFactura";
            this.lblNroFactura.Size = new System.Drawing.Size(74, 15);
            this.lblNroFactura.TabIndex = 105;
            this.lblNroFactura.Text = "Nro. Factura";
            // 
            // lblNroRemito
            // 
            this.lblNroRemito.AutoSize = true;
            this.lblNroRemito.Location = new System.Drawing.Point(6, 17);
            this.lblNroRemito.Name = "lblNroRemito";
            this.lblNroRemito.Size = new System.Drawing.Size(73, 15);
            this.lblNroRemito.TabIndex = 103;
            this.lblNroRemito.Text = "Nro. Remito";
            // 
            // lblDatosDelCliente
            // 
            this.lblDatosDelCliente.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblDatosDelCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDatosDelCliente.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatosDelCliente.Location = new System.Drawing.Point(6, 51);
            this.lblDatosDelCliente.Name = "lblDatosDelCliente";
            this.lblDatosDelCliente.Size = new System.Drawing.Size(519, 68);
            this.lblDatosDelCliente.TabIndex = 107;
            this.lblDatosDelCliente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNroFactura
            // 
            this.txtNroFactura.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtNroFactura.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtNroFactura.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtNroFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroFactura.Location = new System.Drawing.Point(405, 14);
            this.txtNroFactura.MaxLength = 80;
            this.txtNroFactura.Name = "txtNroFactura";
            this.txtNroFactura.ReadOnly = true;
            this.txtNroFactura.Size = new System.Drawing.Size(120, 21);
            this.txtNroFactura.TabIndex = 106;
            this.txtNroFactura.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnImprimirFactura
            // 
            this.btnImprimirFactura.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimirFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnImprimirFactura.Location = new System.Drawing.Point(503, 508);
            this.btnImprimirFactura.Name = "btnImprimirFactura";
            this.btnImprimirFactura.Size = new System.Drawing.Size(96, 37);
            this.btnImprimirFactura.TabIndex = 6;
            this.btnImprimirFactura.Text = "Imp. Factura";
            this.btnImprimirFactura.UseVisualStyleBackColor = true;
            this.btnImprimirFactura.Click += new System.EventHandler(this.btnImprimirFactura_Click);
            // 
            // txtNroRemito
            // 
            this.txtNroRemito.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtNroRemito.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtNroRemito.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtNroRemito.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroRemito.Location = new System.Drawing.Point(85, 14);
            this.txtNroRemito.MaxLength = 80;
            this.txtNroRemito.Name = "txtNroRemito";
            this.txtNroRemito.ReadOnly = true;
            this.txtNroRemito.Size = new System.Drawing.Size(169, 21);
            this.txtNroRemito.TabIndex = 104;
            this.txtNroRemito.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblBonificacion
            // 
            this.lblBonificacion.AutoSize = true;
            this.lblBonificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBonificacion.Location = new System.Drawing.Point(422, 445);
            this.lblBonificacion.Name = "lblBonificacion";
            this.lblBonificacion.Size = new System.Drawing.Size(74, 15);
            this.lblBonificacion.TabIndex = 110;
            this.lblBonificacion.Text = "Bonificación";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(462, 471);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(34, 15);
            this.lblTotal.TabIndex = 116;
            this.lblTotal.Text = "Total";
            // 
            // txtBonificacion
            // 
            this.txtBonificacion.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtBonificacion.Location = new System.Drawing.Point(502, 444);
            this.txtBonificacion.MaxLength = 80;
            this.txtBonificacion.Name = "txtBonificacion";
            this.txtBonificacion.ReadOnly = true;
            this.txtBonificacion.Size = new System.Drawing.Size(97, 21);
            this.txtBonificacion.TabIndex = 111;
            this.txtBonificacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblIva
            // 
            this.lblIva.AutoSize = true;
            this.lblIva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIva.Location = new System.Drawing.Point(246, 472);
            this.lblIva.Name = "lblIva";
            this.lblIva.Size = new System.Drawing.Size(22, 15);
            this.lblIva.TabIndex = 114;
            this.lblIva.Text = "Iva";
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtTotal.Location = new System.Drawing.Point(502, 470);
            this.txtTotal.MaxLength = 80;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(97, 21);
            this.txtTotal.TabIndex = 117;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal.Location = new System.Drawing.Point(13, 471);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(52, 15);
            this.lblSubtotal.TabIndex = 112;
            this.lblSubtotal.Text = "Subtotal";
            // 
            // txtIva
            // 
            this.txtIva.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtIva.Location = new System.Drawing.Point(274, 470);
            this.txtIva.MaxLength = 80;
            this.txtIva.Name = "txtIva";
            this.txtIva.ReadOnly = true;
            this.txtIva.Size = new System.Drawing.Size(97, 21);
            this.txtIva.TabIndex = 115;
            this.txtIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtSubtotal.Location = new System.Drawing.Point(71, 469);
            this.txtSubtotal.MaxLength = 80;
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.ReadOnly = true;
            this.txtSubtotal.Size = new System.Drawing.Size(97, 21);
            this.txtSubtotal.TabIndex = 113;
            this.txtSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dgvDetalleFactura
            // 
            this.dgvDetalleFactura.AllowUserToAddRows = false;
            this.dgvDetalleFactura.AllowUserToDeleteRows = false;
            this.dgvDetalleFactura.AllowUserToResizeColumns = false;
            this.dgvDetalleFactura.AllowUserToResizeRows = false;
            this.dgvDetalleFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleFactura.Location = new System.Drawing.Point(6, 122);
            this.dgvDetalleFactura.MultiSelect = false;
            this.dgvDetalleFactura.Name = "dgvDetalleFactura";
            this.dgvDetalleFactura.ReadOnly = true;
            this.dgvDetalleFactura.RowHeadersVisible = false;
            this.dgvDetalleFactura.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDetalleFactura.Size = new System.Drawing.Size(593, 311);
            this.dgvDetalleFactura.TabIndex = 109;
            // 
            // btnCambiarFactura
            // 
            this.btnCambiarFactura.BackgroundImage = global::OFC.Properties.Resources.add1;
            this.btnCambiarFactura.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCambiarFactura.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCambiarFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCambiarFactura.Location = new System.Drawing.Point(531, 13);
            this.btnCambiarFactura.Name = "btnCambiarFactura";
            this.btnCambiarFactura.Size = new System.Drawing.Size(63, 22);
            this.btnCambiarFactura.TabIndex = 3;
            this.btnCambiarFactura.UseVisualStyleBackColor = true;
            this.btnCambiarFactura.Click += new System.EventHandler(this.btnCambiarFactura_Click);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrar.Location = new System.Drawing.Point(510, 630);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(96, 35);
            this.btnRegistrar.TabIndex = 9;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // lblFacturasPendientes
            // 
            this.lblFacturasPendientes.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblFacturasPendientes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFacturasPendientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFacturasPendientes.Location = new System.Drawing.Point(3, 12);
            this.lblFacturasPendientes.Name = "lblFacturasPendientes";
            this.lblFacturasPendientes.Size = new System.Drawing.Size(386, 25);
            this.lblFacturasPendientes.TabIndex = 101;
            this.lblFacturasPendientes.Text = "Factura Pendiente";
            this.lblFacturasPendientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnBorrar
            // 
            this.btnBorrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBorrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrar.Location = new System.Drawing.Point(13, 628);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(96, 37);
            this.btnBorrar.TabIndex = 7;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // pnlIzquierda
            // 
            this.pnlIzquierda.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlIzquierda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlIzquierda.Controls.Add(this.lblBonificacionDelCliente);
            this.pnlIzquierda.Controls.Add(this.txtPorcentajeDeBonificacion);
            this.pnlIzquierda.Controls.Add(this.txtCodCliente);
            this.pnlIzquierda.Controls.Add(this.lblCodCliente);
            this.pnlIzquierda.Controls.Add(this.txtNombreDelCliente);
            this.pnlIzquierda.Controls.Add(this.lblNombreDelCliente);
            this.pnlIzquierda.Controls.Add(this.chbDesglosarEnFactura);
            this.pnlIzquierda.Controls.Add(this.btnX);
            this.pnlIzquierda.Controls.Add(this.cbxMotivoDescuento);
            this.pnlIzquierda.Controls.Add(this.lblMotivoDescuento);
            this.pnlIzquierda.Controls.Add(this.btnProcesar);
            this.pnlIzquierda.Controls.Add(this.txtNroOrden);
            this.pnlIzquierda.Controls.Add(this.btnCancelar);
            this.pnlIzquierda.Controls.Add(this.cbxFiltroNroDeRemito);
            this.pnlIzquierda.Controls.Add(this.cbxServicioAdicional);
            this.pnlIzquierda.Controls.Add(this.btnActualizar);
            this.pnlIzquierda.Controls.Add(this.cbxTrabajo);
            this.pnlIzquierda.Controls.Add(this.cbxMedidaDeCubierta);
            this.pnlIzquierda.Controls.Add(this.lblCoche);
            this.pnlIzquierda.Controls.Add(this.txtCoche);
            this.pnlIzquierda.Controls.Add(this.txtPorcentajeAPagar);
            this.pnlIzquierda.Controls.Add(this.lblPorcentajeAPagar);
            this.pnlIzquierda.Controls.Add(this.lblNroInterno);
            this.pnlIzquierda.Controls.Add(this.lblFiltroNroDeRemito);
            this.pnlIzquierda.Controls.Add(this.txtNroSerie);
            this.pnlIzquierda.Controls.Add(this.lblNroSerie);
            this.pnlIzquierda.Controls.Add(this.lblServicioAdicional);
            this.pnlIzquierda.Controls.Add(this.lblDetalleDelRemito);
            this.pnlIzquierda.Controls.Add(this.cbxMarca);
            this.pnlIzquierda.Controls.Add(this.dgvOrdenesDeTrabajo);
            this.pnlIzquierda.Controls.Add(this.txtNroInterno);
            this.pnlIzquierda.Controls.Add(this.lblRenglon);
            this.pnlIzquierda.Controls.Add(this.lblTrabajo);
            this.pnlIzquierda.Controls.Add(this.txtRenglon);
            this.pnlIzquierda.Controls.Add(this.lblMarca);
            this.pnlIzquierda.Controls.Add(this.lblMedidaDeCubierta);
            this.pnlIzquierda.Location = new System.Drawing.Point(12, 12);
            this.pnlIzquierda.Name = "pnlIzquierda";
            this.pnlIzquierda.Size = new System.Drawing.Size(708, 680);
            this.pnlIzquierda.TabIndex = 3;
            // 
            // lblBonificacionDelCliente
            // 
            this.lblBonificacionDelCliente.AutoSize = true;
            this.lblBonificacionDelCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBonificacionDelCliente.Location = new System.Drawing.Point(511, 397);
            this.lblBonificacionDelCliente.Name = "lblBonificacionDelCliente";
            this.lblBonificacionDelCliente.Size = new System.Drawing.Size(113, 15);
            this.lblBonificacionDelCliente.TabIndex = 120;
            this.lblBonificacionDelCliente.Text = "% Bonif. del Cliente";
            // 
            // txtPorcentajeDeBonificacion
            // 
            this.txtPorcentajeDeBonificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPorcentajeDeBonificacion.Location = new System.Drawing.Point(630, 394);
            this.txtPorcentajeDeBonificacion.MaxLength = 5;
            this.txtPorcentajeDeBonificacion.Name = "txtPorcentajeDeBonificacion";
            this.txtPorcentajeDeBonificacion.Size = new System.Drawing.Size(59, 21);
            this.txtPorcentajeDeBonificacion.TabIndex = 19;
            this.txtPorcentajeDeBonificacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPorcentajeDeBonificacion_KeyPress);
            // 
            // txtCodCliente
            // 
            this.txtCodCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodCliente.Location = new System.Drawing.Point(92, 50);
            this.txtCodCliente.MaxLength = 8;
            this.txtCodCliente.Name = "txtCodCliente";
            this.txtCodCliente.ReadOnly = true;
            this.txtCodCliente.Size = new System.Drawing.Size(97, 21);
            this.txtCodCliente.TabIndex = 2;
            // 
            // lblCodCliente
            // 
            this.lblCodCliente.AutoSize = true;
            this.lblCodCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodCliente.Location = new System.Drawing.Point(13, 53);
            this.lblCodCliente.Name = "lblCodCliente";
            this.lblCodCliente.Size = new System.Drawing.Size(73, 15);
            this.lblCodCliente.TabIndex = 117;
            this.lblCodCliente.Text = "Cód. Cliente";
            // 
            // txtNombreDelCliente
            // 
            this.txtNombreDelCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreDelCliente.Location = new System.Drawing.Point(314, 50);
            this.txtNombreDelCliente.MaxLength = 80;
            this.txtNombreDelCliente.Name = "txtNombreDelCliente";
            this.txtNombreDelCliente.ReadOnly = true;
            this.txtNombreDelCliente.Size = new System.Drawing.Size(375, 21);
            this.txtNombreDelCliente.TabIndex = 3;
            // 
            // lblNombreDelCliente
            // 
            this.lblNombreDelCliente.AutoSize = true;
            this.lblNombreDelCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreDelCliente.Location = new System.Drawing.Point(195, 53);
            this.lblNombreDelCliente.Name = "lblNombreDelCliente";
            this.lblNombreDelCliente.Size = new System.Drawing.Size(113, 15);
            this.lblNombreDelCliente.TabIndex = 118;
            this.lblNombreDelCliente.Text = "Nombre del Cliente";
            // 
            // chbDesglosarEnFactura
            // 
            this.chbDesglosarEnFactura.AutoSize = true;
            this.chbDesglosarEnFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbDesglosarEnFactura.Location = new System.Drawing.Point(332, 591);
            this.chbDesglosarEnFactura.Name = "chbDesglosarEnFactura";
            this.chbDesglosarEnFactura.Size = new System.Drawing.Size(143, 19);
            this.chbDesglosarEnFactura.TabIndex = 15;
            this.chbDesglosarEnFactura.Text = "Desglosar en Factura";
            this.chbDesglosarEnFactura.UseVisualStyleBackColor = true;
            // 
            // btnX
            // 
            this.btnX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnX.Location = new System.Drawing.Point(419, 618);
            this.btnX.Name = "btnX";
            this.btnX.Size = new System.Drawing.Size(56, 23);
            this.btnX.TabIndex = 17;
            this.btnX.Text = ">>";
            this.btnX.UseVisualStyleBackColor = true;
            // 
            // cbxMotivoDescuento
            // 
            this.cbxMotivoDescuento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxMotivoDescuento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxMotivoDescuento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxMotivoDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxMotivoDescuento.FormattingEnabled = true;
            this.cbxMotivoDescuento.Location = new System.Drawing.Point(143, 645);
            this.cbxMotivoDescuento.Name = "cbxMotivoDescuento";
            this.cbxMotivoDescuento.Size = new System.Drawing.Size(332, 23);
            this.cbxMotivoDescuento.TabIndex = 18;
            // 
            // lblMotivoDescuento
            // 
            this.lblMotivoDescuento.AutoSize = true;
            this.lblMotivoDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMotivoDescuento.Location = new System.Drawing.Point(20, 648);
            this.lblMotivoDescuento.Name = "lblMotivoDescuento";
            this.lblMotivoDescuento.Size = new System.Drawing.Size(105, 15);
            this.lblMotivoDescuento.TabIndex = 113;
            this.lblMotivoDescuento.Text = "Motivo Descuento";
            // 
            // btnProcesar
            // 
            this.btnProcesar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProcesar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcesar.Location = new System.Drawing.Point(593, 421);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(96, 35);
            this.btnProcesar.TabIndex = 20;
            this.btnProcesar.Text = "Procesar >>";
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // txtNroOrden
            // 
            this.txtNroOrden.Location = new System.Drawing.Point(481, 647);
            this.txtNroOrden.Name = "txtNroOrden";
            this.txtNroOrden.Size = new System.Drawing.Size(85, 20);
            this.txtNroOrden.TabIndex = 114;
            this.txtNroOrden.Visible = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(593, 630);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(96, 35);
            this.btnCancelar.TabIndex = 22;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cbxFiltroNroDeRemito
            // 
            this.cbxFiltroNroDeRemito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFiltroNroDeRemito.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxFiltroNroDeRemito.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxFiltroNroDeRemito.FormattingEnabled = true;
            this.cbxFiltroNroDeRemito.Location = new System.Drawing.Point(160, 21);
            this.cbxFiltroNroDeRemito.Name = "cbxFiltroNroDeRemito";
            this.cbxFiltroNroDeRemito.Size = new System.Drawing.Size(529, 23);
            this.cbxFiltroNroDeRemito.TabIndex = 1;
            this.cbxFiltroNroDeRemito.SelectedIndexChanged += new System.EventHandler(this.cbxFiltroNroDeRemito_SelectedIndexChanged);
            // 
            // cbxServicioAdicional
            // 
            this.cbxServicioAdicional.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxServicioAdicional.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxServicioAdicional.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxServicioAdicional.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxServicioAdicional.FormattingEnabled = true;
            this.cbxServicioAdicional.Location = new System.Drawing.Point(143, 589);
            this.cbxServicioAdicional.Name = "cbxServicioAdicional";
            this.cbxServicioAdicional.Size = new System.Drawing.Size(183, 23);
            this.cbxServicioAdicional.TabIndex = 14;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.Location = new System.Drawing.Point(593, 589);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(96, 35);
            this.btnActualizar.TabIndex = 21;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // cbxTrabajo
            // 
            this.cbxTrabajo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxTrabajo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxTrabajo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxTrabajo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxTrabajo.FormattingEnabled = true;
            this.cbxTrabajo.Location = new System.Drawing.Point(143, 533);
            this.cbxTrabajo.Name = "cbxTrabajo";
            this.cbxTrabajo.Size = new System.Drawing.Size(332, 23);
            this.cbxTrabajo.TabIndex = 12;
            // 
            // cbxMedidaDeCubierta
            // 
            this.cbxMedidaDeCubierta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxMedidaDeCubierta.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxMedidaDeCubierta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxMedidaDeCubierta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxMedidaDeCubierta.FormattingEnabled = true;
            this.cbxMedidaDeCubierta.Location = new System.Drawing.Point(143, 448);
            this.cbxMedidaDeCubierta.Name = "cbxMedidaDeCubierta";
            this.cbxMedidaDeCubierta.Size = new System.Drawing.Size(332, 23);
            this.cbxMedidaDeCubierta.TabIndex = 9;
            // 
            // lblCoche
            // 
            this.lblCoche.AutoSize = true;
            this.lblCoche.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCoche.Location = new System.Drawing.Point(20, 424);
            this.lblCoche.Name = "lblCoche";
            this.lblCoche.Size = new System.Drawing.Size(109, 15);
            this.lblCoche.TabIndex = 105;
            this.lblCoche.Text = "Subcliente \\ Coche";
            // 
            // txtCoche
            // 
            this.txtCoche.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCoche.Location = new System.Drawing.Point(143, 421);
            this.txtCoche.MaxLength = 20;
            this.txtCoche.Name = "txtCoche";
            this.txtCoche.Size = new System.Drawing.Size(332, 21);
            this.txtCoche.TabIndex = 8;
            // 
            // txtPorcentajeAPagar
            // 
            this.txtPorcentajeAPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPorcentajeAPagar.Location = new System.Drawing.Point(143, 618);
            this.txtPorcentajeAPagar.MaxLength = 5;
            this.txtPorcentajeAPagar.Name = "txtPorcentajeAPagar";
            this.txtPorcentajeAPagar.Size = new System.Drawing.Size(270, 21);
            this.txtPorcentajeAPagar.TabIndex = 16;
            this.txtPorcentajeAPagar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPorcentajeAPagar_KeyPress);
            // 
            // lblPorcentajeAPagar
            // 
            this.lblPorcentajeAPagar.AutoSize = true;
            this.lblPorcentajeAPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPorcentajeAPagar.Location = new System.Drawing.Point(20, 621);
            this.lblPorcentajeAPagar.Name = "lblPorcentajeAPagar";
            this.lblPorcentajeAPagar.Size = new System.Drawing.Size(112, 15);
            this.lblPorcentajeAPagar.TabIndex = 112;
            this.lblPorcentajeAPagar.Text = "Porcentaje a Pagar";
            // 
            // lblNroInterno
            // 
            this.lblNroInterno.AutoSize = true;
            this.lblNroInterno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroInterno.Location = new System.Drawing.Point(20, 565);
            this.lblNroInterno.Name = "lblNroInterno";
            this.lblNroInterno.Size = new System.Drawing.Size(71, 15);
            this.lblNroInterno.TabIndex = 110;
            this.lblNroInterno.Text = "Nro. Interno";
            // 
            // lblFiltroNroDeRemito
            // 
            this.lblFiltroNroDeRemito.AutoSize = true;
            this.lblFiltroNroDeRemito.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltroNroDeRemito.Location = new System.Drawing.Point(13, 24);
            this.lblFiltroNroDeRemito.Name = "lblFiltroNroDeRemito";
            this.lblFiltroNroDeRemito.Size = new System.Drawing.Size(141, 15);
            this.lblFiltroNroDeRemito.TabIndex = 103;
            this.lblFiltroNroDeRemito.Text = "Filtro por Nro. de Remito";
            // 
            // txtNroSerie
            // 
            this.txtNroSerie.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroSerie.Location = new System.Drawing.Point(143, 506);
            this.txtNroSerie.MaxLength = 10;
            this.txtNroSerie.Name = "txtNroSerie";
            this.txtNroSerie.Size = new System.Drawing.Size(332, 21);
            this.txtNroSerie.TabIndex = 11;
            // 
            // lblNroSerie
            // 
            this.lblNroSerie.AutoSize = true;
            this.lblNroSerie.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroSerie.Location = new System.Drawing.Point(20, 507);
            this.lblNroSerie.Name = "lblNroSerie";
            this.lblNroSerie.Size = new System.Drawing.Size(62, 15);
            this.lblNroSerie.TabIndex = 108;
            this.lblNroSerie.Text = "Nro. Serie";
            // 
            // lblServicioAdicional
            // 
            this.lblServicioAdicional.AutoSize = true;
            this.lblServicioAdicional.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServicioAdicional.Location = new System.Drawing.Point(20, 592);
            this.lblServicioAdicional.Name = "lblServicioAdicional";
            this.lblServicioAdicional.Size = new System.Drawing.Size(103, 15);
            this.lblServicioAdicional.TabIndex = 111;
            this.lblServicioAdicional.Text = "Servicio Adicional";
            // 
            // lblDetalleDelRemito
            // 
            this.lblDetalleDelRemito.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblDetalleDelRemito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDetalleDelRemito.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalleDelRemito.Location = new System.Drawing.Point(16, 85);
            this.lblDetalleDelRemito.Name = "lblDetalleDelRemito";
            this.lblDetalleDelRemito.Size = new System.Drawing.Size(673, 25);
            this.lblDetalleDelRemito.TabIndex = 4;
            this.lblDetalleDelRemito.Text = "Detalle del Remito";
            this.lblDetalleDelRemito.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxMarca
            // 
            this.cbxMarca.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxMarca.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxMarca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxMarca.FormattingEnabled = true;
            this.cbxMarca.Location = new System.Drawing.Point(143, 477);
            this.cbxMarca.Name = "cbxMarca";
            this.cbxMarca.Size = new System.Drawing.Size(332, 23);
            this.cbxMarca.TabIndex = 10;
            // 
            // dgvOrdenesDeTrabajo
            // 
            this.dgvOrdenesDeTrabajo.AllowUserToAddRows = false;
            this.dgvOrdenesDeTrabajo.AllowUserToDeleteRows = false;
            this.dgvOrdenesDeTrabajo.AllowUserToResizeColumns = false;
            this.dgvOrdenesDeTrabajo.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrdenesDeTrabajo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOrdenesDeTrabajo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOrdenesDeTrabajo.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvOrdenesDeTrabajo.Location = new System.Drawing.Point(16, 113);
            this.dgvOrdenesDeTrabajo.MultiSelect = false;
            this.dgvOrdenesDeTrabajo.Name = "dgvOrdenesDeTrabajo";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrdenesDeTrabajo.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvOrdenesDeTrabajo.RowHeadersVisible = false;
            this.dgvOrdenesDeTrabajo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrdenesDeTrabajo.Size = new System.Drawing.Size(673, 265);
            this.dgvOrdenesDeTrabajo.TabIndex = 5;
            this.dgvOrdenesDeTrabajo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrdenesDeTrabajo_CellClick);
            // 
            // txtNroInterno
            // 
            this.txtNroInterno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroInterno.Location = new System.Drawing.Point(143, 562);
            this.txtNroInterno.MaxLength = 6;
            this.txtNroInterno.Name = "txtNroInterno";
            this.txtNroInterno.Size = new System.Drawing.Size(332, 21);
            this.txtNroInterno.TabIndex = 13;
            this.txtNroInterno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNroInterno_KeyPress);
            // 
            // lblRenglon
            // 
            this.lblRenglon.AutoSize = true;
            this.lblRenglon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRenglon.Location = new System.Drawing.Point(20, 397);
            this.lblRenglon.Name = "lblRenglon";
            this.lblRenglon.Size = new System.Drawing.Size(54, 15);
            this.lblRenglon.TabIndex = 104;
            this.lblRenglon.Text = "Renglon";
            // 
            // lblTrabajo
            // 
            this.lblTrabajo.AutoSize = true;
            this.lblTrabajo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrabajo.Location = new System.Drawing.Point(20, 536);
            this.lblTrabajo.Name = "lblTrabajo";
            this.lblTrabajo.Size = new System.Drawing.Size(49, 15);
            this.lblTrabajo.TabIndex = 109;
            this.lblTrabajo.Text = "Trabajo";
            // 
            // txtRenglon
            // 
            this.txtRenglon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRenglon.Location = new System.Drawing.Point(143, 394);
            this.txtRenglon.MaxLength = 80;
            this.txtRenglon.Name = "txtRenglon";
            this.txtRenglon.ReadOnly = true;
            this.txtRenglon.Size = new System.Drawing.Size(332, 21);
            this.txtRenglon.TabIndex = 7;
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarca.Location = new System.Drawing.Point(20, 478);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(42, 15);
            this.lblMarca.TabIndex = 107;
            this.lblMarca.Text = "Marca";
            // 
            // lblMedidaDeCubierta
            // 
            this.lblMedidaDeCubierta.AutoSize = true;
            this.lblMedidaDeCubierta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMedidaDeCubierta.Location = new System.Drawing.Point(20, 451);
            this.lblMedidaDeCubierta.Name = "lblMedidaDeCubierta";
            this.lblMedidaDeCubierta.Size = new System.Drawing.Size(115, 15);
            this.lblMedidaDeCubierta.TabIndex = 106;
            this.lblMedidaDeCubierta.Text = "Medida de Cubierta";
            // 
            // btnExportar
            // 
            this.btnExportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar.Location = new System.Drawing.Point(272, 630);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(96, 35);
            this.btnExportar.TabIndex = 8;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // frmFacturacionConRemito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 730);
            this.Controls.Add(this.pnlDerecho);
            this.Controls.Add(this.pnlIzquierda);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmFacturacionConRemito";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facturación con Remito";
            this.Load += new System.EventHandler(this.FacturacionConRemito_Load);
            this.pnlDerecho.ResumeLayout(false);
            this.tbcFacturasPendientes.ResumeLayout(false);
            this.tbpNroFactura.ResumeLayout(false);
            this.tbpNroFactura.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleFactura)).EndInit();
            this.pnlIzquierda.ResumeLayout(false);
            this.pnlIzquierda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenesDeTrabajo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDerecho;
        private System.Windows.Forms.Button btnVistaDefinitiva;
        private System.Windows.Forms.Label lblVistaPreliminar;
        private System.Windows.Forms.TabControl tbcFacturasPendientes;
        private System.Windows.Forms.TabPage tbpNroFactura;
        private System.Windows.Forms.TextBox txtRenglones;
        private System.Windows.Forms.Label lblTipoFactura;
        private System.Windows.Forms.Label lblNroFactura;
        private System.Windows.Forms.Label lblNroRemito;
        private System.Windows.Forms.Label lblDatosDelCliente;
        private System.Windows.Forms.TextBox txtNroFactura;
        private System.Windows.Forms.Button btnImprimirFactura;
        private System.Windows.Forms.TextBox txtNroRemito;
        private System.Windows.Forms.Label lblBonificacion;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtBonificacion;
        private System.Windows.Forms.Label lblIva;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.TextBox txtIva;
        private System.Windows.Forms.TextBox txtSubtotal;
        private System.Windows.Forms.DataGridView dgvDetalleFactura;
        private System.Windows.Forms.Button btnCambiarFactura;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Label lblFacturasPendientes;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Panel pnlIzquierda;
        private System.Windows.Forms.CheckBox chbDesglosarEnFactura;
        private System.Windows.Forms.Button btnX;
        private System.Windows.Forms.ComboBox cbxMotivoDescuento;
        private System.Windows.Forms.Label lblMotivoDescuento;
        private System.Windows.Forms.Button btnProcesar;
        private System.Windows.Forms.TextBox txtNroOrden;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox cbxFiltroNroDeRemito;
        private System.Windows.Forms.ComboBox cbxServicioAdicional;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.ComboBox cbxTrabajo;
        private System.Windows.Forms.ComboBox cbxMedidaDeCubierta;
        private System.Windows.Forms.Label lblCoche;
        private System.Windows.Forms.TextBox txtCoche;
        private System.Windows.Forms.TextBox txtPorcentajeAPagar;
        private System.Windows.Forms.Label lblPorcentajeAPagar;
        private System.Windows.Forms.Label lblNroInterno;
        private System.Windows.Forms.Label lblFiltroNroDeRemito;
        private System.Windows.Forms.TextBox txtNroSerie;
        private System.Windows.Forms.Label lblNroSerie;
        private System.Windows.Forms.Label lblServicioAdicional;
        private System.Windows.Forms.Label lblDetalleDelRemito;
        private System.Windows.Forms.ComboBox cbxMarca;
        private System.Windows.Forms.DataGridView dgvOrdenesDeTrabajo;
        private System.Windows.Forms.TextBox txtNroInterno;
        private System.Windows.Forms.Label lblRenglon;
        private System.Windows.Forms.Label lblTrabajo;
        private System.Windows.Forms.TextBox txtRenglon;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lblMedidaDeCubierta;
        private System.Windows.Forms.TextBox txtCodCliente;
        private System.Windows.Forms.Label lblCodCliente;
        private System.Windows.Forms.TextBox txtNombreDelCliente;
        private System.Windows.Forms.Label lblNombreDelCliente;
        private System.Windows.Forms.Button btnVistaPreliminarFactura;
        private System.Windows.Forms.Label lblBonificacionDelCliente;
        private System.Windows.Forms.TextBox txtPorcentajeDeBonificacion;
        private System.Windows.Forms.Button btnExportar;
    }
}