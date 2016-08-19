namespace OFC
{
    partial class frmOrdenDePago
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
            this.pnlDerecho = new System.Windows.Forms.Panel();
            this.btnReporteFacturasImpagas = new System.Windows.Forms.Button();
            this.pnlPagoParcial = new System.Windows.Forms.Panel();
            this.lblImporteACancelar = new System.Windows.Forms.Label();
            this.txtImporteDePagoParcial = new System.Windows.Forms.TextBox();
            this.btnPagoParcial = new System.Windows.Forms.Button();
            this.lblImportePagados = new System.Windows.Forms.Label();
            this.txtImportePagados = new System.Windows.Forms.TextBox();
            this.dgvPagoDelMes = new System.Windows.Forms.DataGridView();
            this.lblPagosRealizadosEnElMes = new System.Windows.Forms.Label();
            this.lblSaldoDeudor = new System.Windows.Forms.Label();
            this.btnMarcarPago = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.lblFacturasImpagasDelProveedor = new System.Windows.Forms.Label();
            this.dgvFacturasImpagas = new System.Windows.Forms.DataGridView();
            this.pnlIzquierdo = new System.Windows.Forms.Panel();
            this.lblDiferencia = new System.Windows.Forms.Label();
            this.lblFechaDelComprobante = new System.Windows.Forms.Label();
            this.lblDiferenciaDeImportes = new System.Windows.Forms.Label();
            this.txtImporteDePago = new System.Windows.Forms.TextBox();
            this.dtpFechaDelComprobante = new System.Windows.Forms.DateTimePicker();
            this.lblImporteCancelado = new System.Windows.Forms.Label();
            this.btnDetalleRetencion = new System.Windows.Forms.Button();
            this.cbxTipoDeRetencion = new System.Windows.Forms.ComboBox();
            this.lblTipoDeRetencion = new System.Windows.Forms.Label();
            this.btnLimpiarVista = new System.Windows.Forms.Button();
            this.btnRestar = new System.Windows.Forms.Button();
            this.btnSumar = new System.Windows.Forms.Button();
            this.dgvDatosDelPago = new System.Windows.Forms.DataGridView();
            this.txtImporteTotal = new System.Windows.Forms.TextBox();
            this.lblImporteTotal = new System.Windows.Forms.Label();
            this.txtImportePago = new System.Windows.Forms.TextBox();
            this.lblImportePago = new System.Windows.Forms.Label();
            this.lblFacturasAsociadas = new System.Windows.Forms.Label();
            this.lblFormaDePago = new System.Windows.Forms.Label();
            this.txtDetalle = new System.Windows.Forms.TextBox();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.dgvFacturas = new System.Windows.Forms.DataGridView();
            this.btnX = new System.Windows.Forms.Button();
            this.txtNroOrdenDePago = new System.Windows.Forms.TextBox();
            this.cbxNombreDelProveedor = new System.Windows.Forms.ComboBox();
            this.lblNombreDelProveedor = new System.Windows.Forms.Label();
            this.txtImporteFacturas = new System.Windows.Forms.TextBox();
            this.lblFactura = new System.Windows.Forms.Label();
            this.cbxCodProveedor = new System.Windows.Forms.ComboBox();
            this.lblImporteFacturas = new System.Windows.Forms.Label();
            this.lblCodProveedor = new System.Windows.Forms.Label();
            this.cbxModalidadDePago = new System.Windows.Forms.ComboBox();
            this.lblModalidadDePago = new System.Windows.Forms.Label();
            this.lblDatosOrdenDePago = new System.Windows.Forms.Label();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.lblNroOrdenDePago = new System.Windows.Forms.Label();
            this.pnlDerecho.SuspendLayout();
            this.pnlPagoParcial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagoDelMes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturasImpagas)).BeginInit();
            this.pnlIzquierdo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosDelPago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDerecho
            // 
            this.pnlDerecho.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlDerecho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDerecho.Controls.Add(this.btnReporteFacturasImpagas);
            this.pnlDerecho.Controls.Add(this.pnlPagoParcial);
            this.pnlDerecho.Controls.Add(this.lblImportePagados);
            this.pnlDerecho.Controls.Add(this.txtImportePagados);
            this.pnlDerecho.Controls.Add(this.dgvPagoDelMes);
            this.pnlDerecho.Controls.Add(this.lblPagosRealizadosEnElMes);
            this.pnlDerecho.Controls.Add(this.lblSaldoDeudor);
            this.pnlDerecho.Controls.Add(this.btnMarcarPago);
            this.pnlDerecho.Controls.Add(this.btnAgregar);
            this.pnlDerecho.Controls.Add(this.lblFacturasImpagasDelProveedor);
            this.pnlDerecho.Controls.Add(this.dgvFacturasImpagas);
            this.pnlDerecho.Location = new System.Drawing.Point(705, 12);
            this.pnlDerecho.Name = "pnlDerecho";
            this.pnlDerecho.Size = new System.Drawing.Size(649, 680);
            this.pnlDerecho.TabIndex = 2;
            // 
            // btnReporteFacturasImpagas
            // 
            this.btnReporteFacturasImpagas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReporteFacturasImpagas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporteFacturasImpagas.Location = new System.Drawing.Point(502, 41);
            this.btnReporteFacturasImpagas.Name = "btnReporteFacturasImpagas";
            this.btnReporteFacturasImpagas.Size = new System.Drawing.Size(127, 25);
            this.btnReporteFacturasImpagas.TabIndex = 1;
            this.btnReporteFacturasImpagas.Text = "Reporte Detallado";
            this.btnReporteFacturasImpagas.UseVisualStyleBackColor = true;
            this.btnReporteFacturasImpagas.Click += new System.EventHandler(this.btnReporteFacturasImpagas_Click);
            // 
            // pnlPagoParcial
            // 
            this.pnlPagoParcial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPagoParcial.Controls.Add(this.lblImporteACancelar);
            this.pnlPagoParcial.Controls.Add(this.txtImporteDePagoParcial);
            this.pnlPagoParcial.Controls.Add(this.btnPagoParcial);
            this.pnlPagoParcial.Location = new System.Drawing.Point(137, 363);
            this.pnlPagoParcial.Name = "pnlPagoParcial";
            this.pnlPagoParcial.Size = new System.Drawing.Size(390, 56);
            this.pnlPagoParcial.TabIndex = 3;
            this.pnlPagoParcial.Tag = "";
            // 
            // lblImporteACancelar
            // 
            this.lblImporteACancelar.AutoSize = true;
            this.lblImporteACancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImporteACancelar.Location = new System.Drawing.Point(18, 19);
            this.lblImporteACancelar.Name = "lblImporteACancelar";
            this.lblImporteACancelar.Size = new System.Drawing.Size(98, 15);
            this.lblImporteACancelar.TabIndex = 129;
            this.lblImporteACancelar.Text = "Importe de Pago";
            // 
            // txtImporteDePagoParcial
            // 
            this.txtImporteDePagoParcial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtImporteDePagoParcial.Location = new System.Drawing.Point(122, 17);
            this.txtImporteDePagoParcial.MaxLength = 12;
            this.txtImporteDePagoParcial.Name = "txtImporteDePagoParcial";
            this.txtImporteDePagoParcial.Size = new System.Drawing.Size(125, 21);
            this.txtImporteDePagoParcial.TabIndex = 1;
            this.txtImporteDePagoParcial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImporteDePagoParcial_KeyPress);
            // 
            // btnPagoParcial
            // 
            this.btnPagoParcial.BackColor = System.Drawing.Color.Transparent;
            this.btnPagoParcial.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPagoParcial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPagoParcial.Location = new System.Drawing.Point(253, 9);
            this.btnPagoParcial.Name = "btnPagoParcial";
            this.btnPagoParcial.Size = new System.Drawing.Size(114, 35);
            this.btnPagoParcial.TabIndex = 2;
            this.btnPagoParcial.Text = "<< Pago Parcial";
            this.btnPagoParcial.UseVisualStyleBackColor = false;
            this.btnPagoParcial.Click += new System.EventHandler(this.btnPagoParcial_Click);
            // 
            // lblImportePagados
            // 
            this.lblImportePagados.AutoSize = true;
            this.lblImportePagados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImportePagados.Location = new System.Drawing.Point(439, 648);
            this.lblImportePagados.Name = "lblImportePagados";
            this.lblImportePagados.Size = new System.Drawing.Size(79, 15);
            this.lblImportePagados.TabIndex = 127;
            this.lblImportePagados.Text = "Importe Total";
            // 
            // txtImportePagados
            // 
            this.txtImportePagados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImportePagados.Location = new System.Drawing.Point(524, 647);
            this.txtImportePagados.MaxLength = 10;
            this.txtImportePagados.Name = "txtImportePagados";
            this.txtImportePagados.ReadOnly = true;
            this.txtImportePagados.Size = new System.Drawing.Size(105, 21);
            this.txtImportePagados.TabIndex = 6;
            // 
            // dgvPagoDelMes
            // 
            this.dgvPagoDelMes.AllowUserToAddRows = false;
            this.dgvPagoDelMes.AllowUserToDeleteRows = false;
            this.dgvPagoDelMes.AllowUserToResizeColumns = false;
            this.dgvPagoDelMes.AllowUserToResizeRows = false;
            this.dgvPagoDelMes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPagoDelMes.Location = new System.Drawing.Point(17, 452);
            this.dgvPagoDelMes.MultiSelect = false;
            this.dgvPagoDelMes.Name = "dgvPagoDelMes";
            this.dgvPagoDelMes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvPagoDelMes.Size = new System.Drawing.Size(612, 189);
            this.dgvPagoDelMes.TabIndex = 5;
            // 
            // lblPagosRealizadosEnElMes
            // 
            this.lblPagosRealizadosEnElMes.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblPagosRealizadosEnElMes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPagosRealizadosEnElMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPagosRealizadosEnElMes.Location = new System.Drawing.Point(17, 424);
            this.lblPagosRealizadosEnElMes.Name = "lblPagosRealizadosEnElMes";
            this.lblPagosRealizadosEnElMes.Size = new System.Drawing.Size(612, 25);
            this.lblPagosRealizadosEnElMes.TabIndex = 111;
            this.lblPagosRealizadosEnElMes.Text = "Ordenes de Pagos del Mes";
            this.lblPagosRealizadosEnElMes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSaldoDeudor
            // 
            this.lblSaldoDeudor.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblSaldoDeudor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSaldoDeudor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldoDeudor.ForeColor = System.Drawing.Color.DarkRed;
            this.lblSaldoDeudor.Location = new System.Drawing.Point(17, 12);
            this.lblSaldoDeudor.Name = "lblSaldoDeudor";
            this.lblSaldoDeudor.Size = new System.Drawing.Size(612, 26);
            this.lblSaldoDeudor.TabIndex = 110;
            this.lblSaldoDeudor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnMarcarPago
            // 
            this.btnMarcarPago.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMarcarPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMarcarPago.Location = new System.Drawing.Point(533, 372);
            this.btnMarcarPago.Name = "btnMarcarPago";
            this.btnMarcarPago.Size = new System.Drawing.Size(96, 35);
            this.btnMarcarPago.TabIndex = 4;
            this.btnMarcarPago.Text = "Marcar Pago";
            this.btnMarcarPago.UseVisualStyleBackColor = true;
            this.btnMarcarPago.Click += new System.EventHandler(this.btnMarcarPago_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.Transparent;
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(17, 372);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(114, 35);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "<< Pago Total";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lblFacturasImpagasDelProveedor
            // 
            this.lblFacturasImpagasDelProveedor.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblFacturasImpagasDelProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFacturasImpagasDelProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFacturasImpagasDelProveedor.Location = new System.Drawing.Point(17, 41);
            this.lblFacturasImpagasDelProveedor.Name = "lblFacturasImpagasDelProveedor";
            this.lblFacturasImpagasDelProveedor.Size = new System.Drawing.Size(479, 25);
            this.lblFacturasImpagasDelProveedor.TabIndex = 18;
            this.lblFacturasImpagasDelProveedor.Text = "Facturas y Notas de Débitos: Impagas o con Pago Parcial";
            this.lblFacturasImpagasDelProveedor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvFacturasImpagas
            // 
            this.dgvFacturasImpagas.AllowUserToAddRows = false;
            this.dgvFacturasImpagas.AllowUserToDeleteRows = false;
            this.dgvFacturasImpagas.AllowUserToResizeColumns = false;
            this.dgvFacturasImpagas.AllowUserToResizeRows = false;
            this.dgvFacturasImpagas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFacturasImpagas.Location = new System.Drawing.Point(17, 69);
            this.dgvFacturasImpagas.MultiSelect = false;
            this.dgvFacturasImpagas.Name = "dgvFacturasImpagas";
            this.dgvFacturasImpagas.RowHeadersVisible = false;
            this.dgvFacturasImpagas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvFacturasImpagas.Size = new System.Drawing.Size(612, 288);
            this.dgvFacturasImpagas.TabIndex = 19;
            // 
            // pnlIzquierdo
            // 
            this.pnlIzquierdo.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlIzquierdo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlIzquierdo.Controls.Add(this.lblDiferencia);
            this.pnlIzquierdo.Controls.Add(this.lblFechaDelComprobante);
            this.pnlIzquierdo.Controls.Add(this.lblDiferenciaDeImportes);
            this.pnlIzquierdo.Controls.Add(this.txtImporteDePago);
            this.pnlIzquierdo.Controls.Add(this.dtpFechaDelComprobante);
            this.pnlIzquierdo.Controls.Add(this.lblImporteCancelado);
            this.pnlIzquierdo.Controls.Add(this.btnDetalleRetencion);
            this.pnlIzquierdo.Controls.Add(this.cbxTipoDeRetencion);
            this.pnlIzquierdo.Controls.Add(this.lblTipoDeRetencion);
            this.pnlIzquierdo.Controls.Add(this.btnLimpiarVista);
            this.pnlIzquierdo.Controls.Add(this.btnRestar);
            this.pnlIzquierdo.Controls.Add(this.btnSumar);
            this.pnlIzquierdo.Controls.Add(this.dgvDatosDelPago);
            this.pnlIzquierdo.Controls.Add(this.txtImporteTotal);
            this.pnlIzquierdo.Controls.Add(this.lblImporteTotal);
            this.pnlIzquierdo.Controls.Add(this.txtImportePago);
            this.pnlIzquierdo.Controls.Add(this.lblImportePago);
            this.pnlIzquierdo.Controls.Add(this.lblFacturasAsociadas);
            this.pnlIzquierdo.Controls.Add(this.lblFormaDePago);
            this.pnlIzquierdo.Controls.Add(this.txtDetalle);
            this.pnlIzquierdo.Controls.Add(this.lblDetalle);
            this.pnlIzquierdo.Controls.Add(this.btnQuitar);
            this.pnlIzquierdo.Controls.Add(this.dgvFacturas);
            this.pnlIzquierdo.Controls.Add(this.btnX);
            this.pnlIzquierdo.Controls.Add(this.txtNroOrdenDePago);
            this.pnlIzquierdo.Controls.Add(this.cbxNombreDelProveedor);
            this.pnlIzquierdo.Controls.Add(this.lblNombreDelProveedor);
            this.pnlIzquierdo.Controls.Add(this.txtImporteFacturas);
            this.pnlIzquierdo.Controls.Add(this.lblFactura);
            this.pnlIzquierdo.Controls.Add(this.cbxCodProveedor);
            this.pnlIzquierdo.Controls.Add(this.lblImporteFacturas);
            this.pnlIzquierdo.Controls.Add(this.lblCodProveedor);
            this.pnlIzquierdo.Controls.Add(this.cbxModalidadDePago);
            this.pnlIzquierdo.Controls.Add(this.lblModalidadDePago);
            this.pnlIzquierdo.Controls.Add(this.lblDatosOrdenDePago);
            this.pnlIzquierdo.Controls.Add(this.btnRegistrar);
            this.pnlIzquierdo.Controls.Add(this.lblNroOrdenDePago);
            this.pnlIzquierdo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlIzquierdo.Location = new System.Drawing.Point(12, 12);
            this.pnlIzquierdo.Name = "pnlIzquierdo";
            this.pnlIzquierdo.Size = new System.Drawing.Size(649, 680);
            this.pnlIzquierdo.TabIndex = 1;
            // 
            // lblDiferencia
            // 
            this.lblDiferencia.AutoSize = true;
            this.lblDiferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiferencia.Location = new System.Drawing.Point(14, 648);
            this.lblDiferencia.Name = "lblDiferencia";
            this.lblDiferencia.Size = new System.Drawing.Size(63, 15);
            this.lblDiferencia.TabIndex = 160;
            this.lblDiferencia.Text = "Diferencia";
            // 
            // lblFechaDelComprobante
            // 
            this.lblFechaDelComprobante.AutoSize = true;
            this.lblFechaDelComprobante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaDelComprobante.Location = new System.Drawing.Point(273, 51);
            this.lblFechaDelComprobante.Name = "lblFechaDelComprobante";
            this.lblFechaDelComprobante.Size = new System.Drawing.Size(41, 15);
            this.lblFechaDelComprobante.TabIndex = 149;
            this.lblFechaDelComprobante.Text = "Fecha";
            // 
            // lblDiferenciaDeImportes
            // 
            this.lblDiferenciaDeImportes.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblDiferenciaDeImportes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDiferenciaDeImportes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiferenciaDeImportes.ForeColor = System.Drawing.Color.DarkRed;
            this.lblDiferenciaDeImportes.Location = new System.Drawing.Point(136, 643);
            this.lblDiferenciaDeImportes.Name = "lblDiferenciaDeImportes";
            this.lblDiferenciaDeImportes.Size = new System.Drawing.Size(73, 26);
            this.lblDiferenciaDeImportes.TabIndex = 159;
            this.lblDiferenciaDeImportes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtImporteDePago
            // 
            this.txtImporteDePago.Location = new System.Drawing.Point(436, 296);
            this.txtImporteDePago.MaxLength = 10;
            this.txtImporteDePago.Name = "txtImporteDePago";
            this.txtImporteDePago.ReadOnly = true;
            this.txtImporteDePago.Size = new System.Drawing.Size(194, 21);
            this.txtImporteDePago.TabIndex = 9;
            // 
            // dtpFechaDelComprobante
            // 
            this.dtpFechaDelComprobante.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaDelComprobante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaDelComprobante.Location = new System.Drawing.Point(320, 48);
            this.dtpFechaDelComprobante.Name = "dtpFechaDelComprobante";
            this.dtpFechaDelComprobante.Size = new System.Drawing.Size(310, 21);
            this.dtpFechaDelComprobante.TabIndex = 2;
            // 
            // lblImporteCancelado
            // 
            this.lblImporteCancelado.AutoSize = true;
            this.lblImporteCancelado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImporteCancelado.Location = new System.Drawing.Point(332, 299);
            this.lblImporteCancelado.Name = "lblImporteCancelado";
            this.lblImporteCancelado.Size = new System.Drawing.Size(98, 15);
            this.lblImporteCancelado.TabIndex = 129;
            this.lblImporteCancelado.Text = "Importe de Pago";
            // 
            // btnDetalleRetencion
            // 
            this.btnDetalleRetencion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDetalleRetencion.Location = new System.Drawing.Point(517, 371);
            this.btnDetalleRetencion.Name = "btnDetalleRetencion";
            this.btnDetalleRetencion.Size = new System.Drawing.Size(113, 24);
            this.btnDetalleRetencion.TabIndex = 12;
            this.btnDetalleRetencion.Text = "Detalle Retención";
            this.btnDetalleRetencion.UseVisualStyleBackColor = true;
            this.btnDetalleRetencion.Click += new System.EventHandler(this.btnDetalleRetencion_Click);
            // 
            // cbxTipoDeRetencion
            // 
            this.cbxTipoDeRetencion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxTipoDeRetencion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxTipoDeRetencion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxTipoDeRetencion.FormattingEnabled = true;
            this.cbxTipoDeRetencion.Location = new System.Drawing.Point(405, 371);
            this.cbxTipoDeRetencion.Name = "cbxTipoDeRetencion";
            this.cbxTipoDeRetencion.Size = new System.Drawing.Size(106, 23);
            this.cbxTipoDeRetencion.TabIndex = 11;
            // 
            // lblTipoDeRetencion
            // 
            this.lblTipoDeRetencion.AutoSize = true;
            this.lblTipoDeRetencion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoDeRetencion.Location = new System.Drawing.Point(323, 375);
            this.lblTipoDeRetencion.Name = "lblTipoDeRetencion";
            this.lblTipoDeRetencion.Size = new System.Drawing.Size(76, 15);
            this.lblTipoDeRetencion.TabIndex = 128;
            this.lblTipoDeRetencion.Text = "T. Retención";
            // 
            // btnLimpiarVista
            // 
            this.btnLimpiarVista.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnLimpiarVista.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiarVista.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarVista.Location = new System.Drawing.Point(542, 11);
            this.btnLimpiarVista.Name = "btnLimpiarVista";
            this.btnLimpiarVista.Size = new System.Drawing.Size(102, 27);
            this.btnLimpiarVista.TabIndex = 20;
            this.btnLimpiarVista.Text = "Limpiar Vista";
            this.btnLimpiarVista.UseVisualStyleBackColor = false;
            this.btnLimpiarVista.Click += new System.EventHandler(this.btnLimpiarVista_Click);
            // 
            // btnRestar
            // 
            this.btnRestar.BackColor = System.Drawing.Color.Transparent;
            this.btnRestar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestar.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnRestar.Location = new System.Drawing.Point(570, 581);
            this.btnRestar.Name = "btnRestar";
            this.btnRestar.Size = new System.Drawing.Size(60, 24);
            this.btnRestar.TabIndex = 17;
            this.btnRestar.Text = "X";
            this.btnRestar.UseVisualStyleBackColor = false;
            this.btnRestar.Click += new System.EventHandler(this.btnRestar_Click);
            // 
            // btnSumar
            // 
            this.btnSumar.BackColor = System.Drawing.Color.Transparent;
            this.btnSumar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSumar.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnSumar.Location = new System.Drawing.Point(570, 453);
            this.btnSumar.Name = "btnSumar";
            this.btnSumar.Size = new System.Drawing.Size(60, 24);
            this.btnSumar.TabIndex = 15;
            this.btnSumar.Text = ">>";
            this.btnSumar.UseVisualStyleBackColor = false;
            this.btnSumar.Click += new System.EventHandler(this.btnSumar_Click);
            // 
            // dgvDatosDelPago
            // 
            this.dgvDatosDelPago.AllowUserToAddRows = false;
            this.dgvDatosDelPago.AllowUserToDeleteRows = false;
            this.dgvDatosDelPago.AllowUserToResizeColumns = false;
            this.dgvDatosDelPago.AllowUserToResizeRows = false;
            this.dgvDatosDelPago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatosDelPago.Location = new System.Drawing.Point(135, 482);
            this.dgvDatosDelPago.MultiSelect = false;
            this.dgvDatosDelPago.Name = "dgvDatosDelPago";
            this.dgvDatosDelPago.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDatosDelPago.Size = new System.Drawing.Size(495, 93);
            this.dgvDatosDelPago.TabIndex = 16;
            // 
            // txtImporteTotal
            // 
            this.txtImporteTotal.Location = new System.Drawing.Point(135, 611);
            this.txtImporteTotal.MaxLength = 10;
            this.txtImporteTotal.Name = "txtImporteTotal";
            this.txtImporteTotal.ReadOnly = true;
            this.txtImporteTotal.Size = new System.Drawing.Size(495, 21);
            this.txtImporteTotal.TabIndex = 18;
            // 
            // lblImporteTotal
            // 
            this.lblImporteTotal.AutoSize = true;
            this.lblImporteTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImporteTotal.Location = new System.Drawing.Point(14, 614);
            this.lblImporteTotal.Name = "lblImporteTotal";
            this.lblImporteTotal.Size = new System.Drawing.Size(79, 15);
            this.lblImporteTotal.TabIndex = 126;
            this.lblImporteTotal.Text = "Importe Total";
            // 
            // txtImportePago
            // 
            this.txtImportePago.Location = new System.Drawing.Point(135, 455);
            this.txtImportePago.MaxLength = 10;
            this.txtImportePago.Name = "txtImportePago";
            this.txtImportePago.Size = new System.Drawing.Size(429, 21);
            this.txtImportePago.TabIndex = 14;
            this.txtImportePago.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImportePago_KeyPress);
            // 
            // lblImportePago
            // 
            this.lblImportePago.AutoSize = true;
            this.lblImportePago.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImportePago.Location = new System.Drawing.Point(14, 458);
            this.lblImportePago.Name = "lblImportePago";
            this.lblImportePago.Size = new System.Drawing.Size(49, 15);
            this.lblImportePago.TabIndex = 124;
            this.lblImportePago.Text = "Importe";
            // 
            // lblFacturasAsociadas
            // 
            this.lblFacturasAsociadas.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblFacturasAsociadas.Location = new System.Drawing.Point(3, 117);
            this.lblFacturasAsociadas.Name = "lblFacturasAsociadas";
            this.lblFacturasAsociadas.Size = new System.Drawing.Size(641, 25);
            this.lblFacturasAsociadas.TabIndex = 122;
            this.lblFacturasAsociadas.Text = "Facturas / Débitos Asociados";
            this.lblFacturasAsociadas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFormaDePago
            // 
            this.lblFormaDePago.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblFormaDePago.Location = new System.Drawing.Point(3, 332);
            this.lblFormaDePago.Name = "lblFormaDePago";
            this.lblFormaDePago.Size = new System.Drawing.Size(641, 25);
            this.lblFormaDePago.TabIndex = 121;
            this.lblFormaDePago.Text = "Forma de Pago";
            this.lblFormaDePago.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDetalle
            // 
            this.txtDetalle.Location = new System.Drawing.Point(135, 401);
            this.txtDetalle.MaxLength = 250;
            this.txtDetalle.Multiline = true;
            this.txtDetalle.Name = "txtDetalle";
            this.txtDetalle.Size = new System.Drawing.Size(495, 48);
            this.txtDetalle.TabIndex = 13;
            // 
            // lblDetalle
            // 
            this.lblDetalle.AutoSize = true;
            this.lblDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalle.Location = new System.Drawing.Point(14, 404);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Size = new System.Drawing.Size(46, 15);
            this.lblDetalle.TabIndex = 120;
            this.lblDetalle.Text = "Detalle";
            // 
            // btnQuitar
            // 
            this.btnQuitar.BackColor = System.Drawing.Color.Transparent;
            this.btnQuitar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuitar.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnQuitar.Location = new System.Drawing.Point(570, 266);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(60, 24);
            this.btnQuitar.TabIndex = 7;
            this.btnQuitar.Text = "X";
            this.btnQuitar.UseVisualStyleBackColor = false;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // dgvFacturas
            // 
            this.dgvFacturas.AllowUserToAddRows = false;
            this.dgvFacturas.AllowUserToDeleteRows = false;
            this.dgvFacturas.AllowUserToResizeColumns = false;
            this.dgvFacturas.AllowUserToResizeRows = false;
            this.dgvFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFacturas.Location = new System.Drawing.Point(135, 155);
            this.dgvFacturas.MultiSelect = false;
            this.dgvFacturas.Name = "dgvFacturas";
            this.dgvFacturas.RowHeadersVisible = false;
            this.dgvFacturas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvFacturas.Size = new System.Drawing.Size(495, 105);
            this.dgvFacturas.TabIndex = 6;
            // 
            // btnX
            // 
            this.btnX.BackColor = System.Drawing.Color.Transparent;
            this.btnX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnX.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnX.Location = new System.Drawing.Point(570, 75);
            this.btnX.Name = "btnX";
            this.btnX.Size = new System.Drawing.Size(60, 24);
            this.btnX.TabIndex = 5;
            this.btnX.Text = ">>";
            this.btnX.UseVisualStyleBackColor = false;
            this.btnX.Click += new System.EventHandler(this.btnX_Click);
            // 
            // txtNroOrdenDePago
            // 
            this.txtNroOrdenDePago.Location = new System.Drawing.Point(136, 48);
            this.txtNroOrdenDePago.MaxLength = 20;
            this.txtNroOrdenDePago.Name = "txtNroOrdenDePago";
            this.txtNroOrdenDePago.ReadOnly = true;
            this.txtNroOrdenDePago.Size = new System.Drawing.Size(131, 21);
            this.txtNroOrdenDePago.TabIndex = 1;
            // 
            // cbxNombreDelProveedor
            // 
            this.cbxNombreDelProveedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxNombreDelProveedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxNombreDelProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxNombreDelProveedor.FormattingEnabled = true;
            this.cbxNombreDelProveedor.Location = new System.Drawing.Point(349, 77);
            this.cbxNombreDelProveedor.Name = "cbxNombreDelProveedor";
            this.cbxNombreDelProveedor.Size = new System.Drawing.Size(215, 23);
            this.cbxNombreDelProveedor.TabIndex = 4;
            this.cbxNombreDelProveedor.SelectedIndexChanged += new System.EventHandler(this.cbxNombreDelProveedor_SelectedIndexChanged);
            this.cbxNombreDelProveedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxProveedor_KeyDown);
            // 
            // lblNombreDelProveedor
            // 
            this.lblNombreDelProveedor.AutoSize = true;
            this.lblNombreDelProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreDelProveedor.Location = new System.Drawing.Point(212, 79);
            this.lblNombreDelProveedor.Name = "lblNombreDelProveedor";
            this.lblNombreDelProveedor.Size = new System.Drawing.Size(131, 15);
            this.lblNombreDelProveedor.TabIndex = 118;
            this.lblNombreDelProveedor.Text = "Nombre del Proveedor";
            // 
            // txtImporteFacturas
            // 
            this.txtImporteFacturas.Location = new System.Drawing.Point(135, 296);
            this.txtImporteFacturas.MaxLength = 10;
            this.txtImporteFacturas.Name = "txtImporteFacturas";
            this.txtImporteFacturas.ReadOnly = true;
            this.txtImporteFacturas.Size = new System.Drawing.Size(191, 21);
            this.txtImporteFacturas.TabIndex = 8;
            // 
            // lblFactura
            // 
            this.lblFactura.AutoSize = true;
            this.lblFactura.Location = new System.Drawing.Point(14, 155);
            this.lblFactura.Name = "lblFactura";
            this.lblFactura.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblFactura.Size = new System.Drawing.Size(105, 15);
            this.lblFactura.TabIndex = 79;
            this.lblFactura.Text = "Facturas / Débitos";
            // 
            // cbxCodProveedor
            // 
            this.cbxCodProveedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxCodProveedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxCodProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxCodProveedor.FormattingEnabled = true;
            this.cbxCodProveedor.Location = new System.Drawing.Point(111, 76);
            this.cbxCodProveedor.Name = "cbxCodProveedor";
            this.cbxCodProveedor.Size = new System.Drawing.Size(95, 23);
            this.cbxCodProveedor.TabIndex = 3;
            this.cbxCodProveedor.SelectedIndexChanged += new System.EventHandler(this.cbxCodProveedor_SelectedIndexChanged);
            this.cbxCodProveedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxProveedor_KeyDown);
            // 
            // lblImporteFacturas
            // 
            this.lblImporteFacturas.AutoSize = true;
            this.lblImporteFacturas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImporteFacturas.Location = new System.Drawing.Point(14, 299);
            this.lblImporteFacturas.Name = "lblImporteFacturas";
            this.lblImporteFacturas.Size = new System.Drawing.Size(110, 15);
            this.lblImporteFacturas.TabIndex = 78;
            this.lblImporteFacturas.Text = "Importe Fac. / Déb.";
            // 
            // lblCodProveedor
            // 
            this.lblCodProveedor.AutoSize = true;
            this.lblCodProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodProveedor.Location = new System.Drawing.Point(14, 80);
            this.lblCodProveedor.Name = "lblCodProveedor";
            this.lblCodProveedor.Size = new System.Drawing.Size(91, 15);
            this.lblCodProveedor.TabIndex = 114;
            this.lblCodProveedor.Text = "Cod. Proveedor";
            // 
            // cbxModalidadDePago
            // 
            this.cbxModalidadDePago.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxModalidadDePago.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxModalidadDePago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxModalidadDePago.FormattingEnabled = true;
            this.cbxModalidadDePago.Location = new System.Drawing.Point(135, 372);
            this.cbxModalidadDePago.Name = "cbxModalidadDePago";
            this.cbxModalidadDePago.Size = new System.Drawing.Size(182, 23);
            this.cbxModalidadDePago.TabIndex = 10;
            // 
            // lblModalidadDePago
            // 
            this.lblModalidadDePago.AutoSize = true;
            this.lblModalidadDePago.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModalidadDePago.Location = new System.Drawing.Point(14, 375);
            this.lblModalidadDePago.Name = "lblModalidadDePago";
            this.lblModalidadDePago.Size = new System.Drawing.Size(115, 15);
            this.lblModalidadDePago.TabIndex = 73;
            this.lblModalidadDePago.Text = "Modalidad de Pago";
            // 
            // lblDatosOrdenDePago
            // 
            this.lblDatosOrdenDePago.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblDatosOrdenDePago.Location = new System.Drawing.Point(3, 12);
            this.lblDatosOrdenDePago.Name = "lblDatosOrdenDePago";
            this.lblDatosOrdenDePago.Size = new System.Drawing.Size(533, 25);
            this.lblDatosOrdenDePago.TabIndex = 70;
            this.lblDatosOrdenDePago.Text = "Datos de la Orden de Pago";
            this.lblDatosOrdenDePago.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrar.Location = new System.Drawing.Point(534, 638);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(96, 35);
            this.btnRegistrar.TabIndex = 20;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // lblNroOrdenDePago
            // 
            this.lblNroOrdenDePago.AutoSize = true;
            this.lblNroOrdenDePago.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroOrdenDePago.Location = new System.Drawing.Point(14, 51);
            this.lblNroOrdenDePago.Name = "lblNroOrdenDePago";
            this.lblNroOrdenDePago.Size = new System.Drawing.Size(116, 15);
            this.lblNroOrdenDePago.TabIndex = 11;
            this.lblNroOrdenDePago.Text = "Nro. Orden de Pago";
            // 
            // frmOrdenDePago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 730);
            this.Controls.Add(this.pnlDerecho);
            this.Controls.Add(this.pnlIzquierdo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmOrdenDePago";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Orden de Pago";
            this.Load += new System.EventHandler(this.frmOrdenDePago_Load);
            this.pnlDerecho.ResumeLayout(false);
            this.pnlDerecho.PerformLayout();
            this.pnlPagoParcial.ResumeLayout(false);
            this.pnlPagoParcial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagoDelMes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturasImpagas)).EndInit();
            this.pnlIzquierdo.ResumeLayout(false);
            this.pnlIzquierdo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosDelPago)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDerecho;
        private System.Windows.Forms.Label lblSaldoDeudor;
        private System.Windows.Forms.Button btnMarcarPago;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label lblFacturasImpagasDelProveedor;
        private System.Windows.Forms.DataGridView dgvFacturasImpagas;
        private System.Windows.Forms.Panel pnlIzquierdo;
        private System.Windows.Forms.ComboBox cbxTipoDeRetencion;
        private System.Windows.Forms.Label lblTipoDeRetencion;
        private System.Windows.Forms.Button btnLimpiarVista;
        private System.Windows.Forms.Button btnRestar;
        private System.Windows.Forms.Button btnSumar;
        private System.Windows.Forms.DataGridView dgvDatosDelPago;
        private System.Windows.Forms.TextBox txtImporteTotal;
        private System.Windows.Forms.Label lblImporteTotal;
        private System.Windows.Forms.TextBox txtImportePago;
        private System.Windows.Forms.Label lblImportePago;
        private System.Windows.Forms.Label lblFacturasAsociadas;
        private System.Windows.Forms.Label lblFormaDePago;
        private System.Windows.Forms.TextBox txtDetalle;
        private System.Windows.Forms.Label lblDetalle;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.DataGridView dgvFacturas;
        private System.Windows.Forms.Button btnX;
        private System.Windows.Forms.TextBox txtNroOrdenDePago;
        private System.Windows.Forms.ComboBox cbxNombreDelProveedor;
        private System.Windows.Forms.Label lblNombreDelProveedor;
        private System.Windows.Forms.TextBox txtImporteFacturas;
        private System.Windows.Forms.Label lblFactura;
        private System.Windows.Forms.ComboBox cbxCodProveedor;
        private System.Windows.Forms.Label lblImporteFacturas;
        private System.Windows.Forms.Label lblCodProveedor;
        private System.Windows.Forms.ComboBox cbxModalidadDePago;
        private System.Windows.Forms.Label lblModalidadDePago;
        private System.Windows.Forms.Label lblDatosOrdenDePago;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Label lblNroOrdenDePago;
        private System.Windows.Forms.Button btnDetalleRetencion;
        private System.Windows.Forms.DataGridView dgvPagoDelMes;
        private System.Windows.Forms.Label lblPagosRealizadosEnElMes;
        private System.Windows.Forms.Label lblImportePagados;
        private System.Windows.Forms.TextBox txtImportePagados;
        private System.Windows.Forms.Button btnPagoParcial;
        private System.Windows.Forms.Panel pnlPagoParcial;
        private System.Windows.Forms.Label lblImporteACancelar;
        private System.Windows.Forms.TextBox txtImporteDePagoParcial;
        private System.Windows.Forms.TextBox txtImporteDePago;
        private System.Windows.Forms.Label lblImporteCancelado;
        private System.Windows.Forms.Label lblFechaDelComprobante;
        private System.Windows.Forms.DateTimePicker dtpFechaDelComprobante;
        private System.Windows.Forms.Button btnReporteFacturasImpagas;
        private System.Windows.Forms.Label lblDiferencia;
        private System.Windows.Forms.Label lblDiferenciaDeImportes;
    }
}