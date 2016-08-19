namespace OFC
{
    partial class frmBuscarComprobante
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlDerecho = new System.Windows.Forms.Panel();
            this.btnLimpiarVista = new System.Windows.Forms.Button();
            this.tbcComprobante = new System.Windows.Forms.TabControl();
            this.tbpNroComprobante = new System.Windows.Forms.TabPage();
            this.lblPagado = new System.Windows.Forms.Label();
            this.dgvFacturasAsociadas = new System.Windows.Forms.DataGridView();
            this.txtTipoDeComprobante = new System.Windows.Forms.TextBox();
            this.txtFechaDeRegistro = new System.Windows.Forms.TextBox();
            this.lblFechaDeRegistro = new System.Windows.Forms.Label();
            this.chbAnulado = new System.Windows.Forms.CheckBox();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.lblNroComprobante = new System.Windows.Forms.Label();
            this.btnAnular = new System.Windows.Forms.Button();
            this.txtNroComprobante = new System.Windows.Forms.TextBox();
            this.lblTipoFactura = new System.Windows.Forms.Label();
            this.lblDatosDelCliente = new System.Windows.Forms.Label();
            this.lblBonificacion = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtBonificacion = new System.Windows.Forms.TextBox();
            this.lblIva = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.txtIva = new System.Windows.Forms.TextBox();
            this.txtSubtotal = new System.Windows.Forms.TextBox();
            this.dgvComprobanteRegistrado = new System.Windows.Forms.DataGridView();
            this.lblComprobanteRegistrado = new System.Windows.Forms.Label();
            this.pnlIzquierda = new System.Windows.Forms.Panel();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.lblFiltroFechaHasta = new System.Windows.Forms.Label();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.lblFiltroFechaDesde = new System.Windows.Forms.Label();
            this.lblOB_3 = new System.Windows.Forms.Label();
            this.lblOP_1 = new System.Windows.Forms.Label();
            this.lblOB_2 = new System.Windows.Forms.Label();
            this.lblOB_1 = new System.Windows.Forms.Label();
            this.txtFiltroNroDeComprobante = new System.Windows.Forms.TextBox();
            this.lblFiltroNroDeComprobante = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.cbxFiltroTipoDeComprobante = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.cbxFiltroNombreDeCliente = new System.Windows.Forms.ComboBox();
            this.cbxFiltroCodCliente = new System.Windows.Forms.ComboBox();
            this.lblFiltroNombreDeCliente = new System.Windows.Forms.Label();
            this.lblFiltroCodCliente = new System.Windows.Forms.Label();
            this.lblFiltroTipoDeComprobante = new System.Windows.Forms.Label();
            this.lblResultado = new System.Windows.Forms.Label();
            this.dgvComprobantes = new System.Windows.Forms.DataGridView();
            this.pnlDerecho.SuspendLayout();
            this.tbcComprobante.SuspendLayout();
            this.tbpNroComprobante.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturasAsociadas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComprobanteRegistrado)).BeginInit();
            this.pnlIzquierda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComprobantes)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDerecho
            // 
            this.pnlDerecho.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlDerecho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDerecho.Controls.Add(this.btnLimpiarVista);
            this.pnlDerecho.Controls.Add(this.tbcComprobante);
            this.pnlDerecho.Controls.Add(this.lblComprobanteRegistrado);
            this.pnlDerecho.Location = new System.Drawing.Point(692, 12);
            this.pnlDerecho.Name = "pnlDerecho";
            this.pnlDerecho.Size = new System.Drawing.Size(666, 680);
            this.pnlDerecho.TabIndex = 2;
            // 
            // btnLimpiarVista
            // 
            this.btnLimpiarVista.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnLimpiarVista.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiarVista.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarVista.Location = new System.Drawing.Point(555, 10);
            this.btnLimpiarVista.Name = "btnLimpiarVista";
            this.btnLimpiarVista.Size = new System.Drawing.Size(102, 28);
            this.btnLimpiarVista.TabIndex = 1;
            this.btnLimpiarVista.Text = "Limpiar Vista";
            this.btnLimpiarVista.UseVisualStyleBackColor = false;
            this.btnLimpiarVista.Click += new System.EventHandler(this.btnLimpiarVista_Click);
            // 
            // tbcComprobante
            // 
            this.tbcComprobante.Controls.Add(this.tbpNroComprobante);
            this.tbcComprobante.Location = new System.Drawing.Point(3, 44);
            this.tbcComprobante.Name = "tbcComprobante";
            this.tbcComprobante.SelectedIndex = 0;
            this.tbcComprobante.Size = new System.Drawing.Size(658, 621);
            this.tbcComprobante.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tbcComprobante.TabIndex = 101;
            // 
            // tbpNroComprobante
            // 
            this.tbpNroComprobante.Controls.Add(this.lblPagado);
            this.tbpNroComprobante.Controls.Add(this.dgvFacturasAsociadas);
            this.tbpNroComprobante.Controls.Add(this.txtTipoDeComprobante);
            this.tbpNroComprobante.Controls.Add(this.txtFechaDeRegistro);
            this.tbpNroComprobante.Controls.Add(this.lblFechaDeRegistro);
            this.tbpNroComprobante.Controls.Add(this.chbAnulado);
            this.tbpNroComprobante.Controls.Add(this.btnImprimir);
            this.tbpNroComprobante.Controls.Add(this.lblNroComprobante);
            this.tbpNroComprobante.Controls.Add(this.btnAnular);
            this.tbpNroComprobante.Controls.Add(this.txtNroComprobante);
            this.tbpNroComprobante.Controls.Add(this.lblTipoFactura);
            this.tbpNroComprobante.Controls.Add(this.lblDatosDelCliente);
            this.tbpNroComprobante.Controls.Add(this.lblBonificacion);
            this.tbpNroComprobante.Controls.Add(this.lblTotal);
            this.tbpNroComprobante.Controls.Add(this.txtBonificacion);
            this.tbpNroComprobante.Controls.Add(this.lblIva);
            this.tbpNroComprobante.Controls.Add(this.txtTotal);
            this.tbpNroComprobante.Controls.Add(this.lblSubtotal);
            this.tbpNroComprobante.Controls.Add(this.txtIva);
            this.tbpNroComprobante.Controls.Add(this.txtSubtotal);
            this.tbpNroComprobante.Controls.Add(this.dgvComprobanteRegistrado);
            this.tbpNroComprobante.Location = new System.Drawing.Point(4, 22);
            this.tbpNroComprobante.Name = "tbpNroComprobante";
            this.tbpNroComprobante.Padding = new System.Windows.Forms.Padding(3);
            this.tbpNroComprobante.Size = new System.Drawing.Size(650, 595);
            this.tbpNroComprobante.TabIndex = 1;
            this.tbpNroComprobante.Text = "C1";
            this.tbpNroComprobante.UseVisualStyleBackColor = true;
            // 
            // lblPagado
            // 
            this.lblPagado.AutoSize = true;
            this.lblPagado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPagado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPagado.ForeColor = System.Drawing.Color.Crimson;
            this.lblPagado.Location = new System.Drawing.Point(220, 544);
            this.lblPagado.Name = "lblPagado";
            this.lblPagado.Size = new System.Drawing.Size(224, 26);
            this.lblPagado.TabIndex = 19;
            this.lblPagado.Text = "PAGADO / CANCELADO";
            this.lblPagado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPagado.Visible = false;
            // 
            // dgvFacturasAsociadas
            // 
            this.dgvFacturasAsociadas.AllowUserToAddRows = false;
            this.dgvFacturasAsociadas.AllowUserToDeleteRows = false;
            this.dgvFacturasAsociadas.AllowUserToResizeColumns = false;
            this.dgvFacturasAsociadas.AllowUserToResizeRows = false;
            this.dgvFacturasAsociadas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvFacturasAsociadas.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFacturasAsociadas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFacturasAsociadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFacturasAsociadas.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvFacturasAsociadas.Location = new System.Drawing.Point(527, 82);
            this.dgvFacturasAsociadas.MultiSelect = false;
            this.dgvFacturasAsociadas.Name = "dgvFacturasAsociadas";
            this.dgvFacturasAsociadas.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFacturasAsociadas.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvFacturasAsociadas.RowHeadersVisible = false;
            this.dgvFacturasAsociadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFacturasAsociadas.Size = new System.Drawing.Size(120, 68);
            this.dgvFacturasAsociadas.TabIndex = 8;
            this.dgvFacturasAsociadas.Visible = false;
            // 
            // txtTipoDeComprobante
            // 
            this.txtTipoDeComprobante.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtTipoDeComprobante.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtTipoDeComprobante.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtTipoDeComprobante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTipoDeComprobante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoDeComprobante.Location = new System.Drawing.Point(3, 7);
            this.txtTipoDeComprobante.MaxLength = 80;
            this.txtTipoDeComprobante.Name = "txtTipoDeComprobante";
            this.txtTipoDeComprobante.ReadOnly = true;
            this.txtTipoDeComprobante.Size = new System.Drawing.Size(644, 22);
            this.txtTipoDeComprobante.TabIndex = 1;
            this.txtTipoDeComprobante.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtFechaDeRegistro
            // 
            this.txtFechaDeRegistro.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtFechaDeRegistro.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtFechaDeRegistro.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtFechaDeRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaDeRegistro.Location = new System.Drawing.Point(399, 44);
            this.txtFechaDeRegistro.MaxLength = 80;
            this.txtFechaDeRegistro.Name = "txtFechaDeRegistro";
            this.txtFechaDeRegistro.ReadOnly = true;
            this.txtFechaDeRegistro.Size = new System.Drawing.Size(161, 21);
            this.txtFechaDeRegistro.TabIndex = 5;
            this.txtFechaDeRegistro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblFechaDeRegistro
            // 
            this.lblFechaDeRegistro.AutoSize = true;
            this.lblFechaDeRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaDeRegistro.Location = new System.Drawing.Point(286, 47);
            this.lblFechaDeRegistro.Name = "lblFechaDeRegistro";
            this.lblFechaDeRegistro.Size = new System.Drawing.Size(107, 15);
            this.lblFechaDeRegistro.TabIndex = 4;
            this.lblFechaDeRegistro.Text = "Fecha de Registro";
            // 
            // chbAnulado
            // 
            this.chbAnulado.AutoSize = true;
            this.chbAnulado.Enabled = false;
            this.chbAnulado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbAnulado.Location = new System.Drawing.Point(576, 45);
            this.chbAnulado.Name = "chbAnulado";
            this.chbAnulado.Size = new System.Drawing.Size(71, 19);
            this.chbAnulado.TabIndex = 6;
            this.chbAnulado.Text = "Anulado";
            this.chbAnulado.UseVisualStyleBackColor = true;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.White;
            this.btnImprimir.BackgroundImage = global::OFC.Properties.Resources.vista_preliminar1;
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnImprimir.Location = new System.Drawing.Point(548, 539);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(96, 37);
            this.btnImprimir.TabIndex = 20;
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // lblNroComprobante
            // 
            this.lblNroComprobante.AutoSize = true;
            this.lblNroComprobante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroComprobante.Location = new System.Drawing.Point(6, 48);
            this.lblNroComprobante.Name = "lblNroComprobante";
            this.lblNroComprobante.Size = new System.Drawing.Size(108, 15);
            this.lblNroComprobante.TabIndex = 2;
            this.lblNroComprobante.Text = "Nro. Comprobante";
            // 
            // btnAnular
            // 
            this.btnAnular.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnular.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnular.Location = new System.Drawing.Point(6, 539);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(96, 37);
            this.btnAnular.TabIndex = 18;
            this.btnAnular.Text = "Anular";
            this.btnAnular.UseVisualStyleBackColor = true;
            this.btnAnular.Click += new System.EventHandler(this.btnAnular_Click);
            // 
            // txtNroComprobante
            // 
            this.txtNroComprobante.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtNroComprobante.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtNroComprobante.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtNroComprobante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroComprobante.Location = new System.Drawing.Point(120, 45);
            this.txtNroComprobante.MaxLength = 80;
            this.txtNroComprobante.Name = "txtNroComprobante";
            this.txtNroComprobante.ReadOnly = true;
            this.txtNroComprobante.Size = new System.Drawing.Size(151, 21);
            this.txtNroComprobante.TabIndex = 3;
            this.txtNroComprobante.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblTipoFactura
            // 
            this.lblTipoFactura.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblTipoFactura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTipoFactura.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoFactura.Location = new System.Drawing.Point(527, 82);
            this.lblTipoFactura.Name = "lblTipoFactura";
            this.lblTipoFactura.Size = new System.Drawing.Size(120, 68);
            this.lblTipoFactura.TabIndex = 22;
            this.lblTipoFactura.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDatosDelCliente
            // 
            this.lblDatosDelCliente.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblDatosDelCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDatosDelCliente.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.lblDatosDelCliente.Location = new System.Drawing.Point(3, 82);
            this.lblDatosDelCliente.Name = "lblDatosDelCliente";
            this.lblDatosDelCliente.Size = new System.Drawing.Size(518, 68);
            this.lblDatosDelCliente.TabIndex = 7;
            this.lblDatosDelCliente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBonificacion
            // 
            this.lblBonificacion.AutoSize = true;
            this.lblBonificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBonificacion.Location = new System.Drawing.Point(467, 468);
            this.lblBonificacion.Name = "lblBonificacion";
            this.lblBonificacion.Size = new System.Drawing.Size(74, 15);
            this.lblBonificacion.TabIndex = 10;
            this.lblBonificacion.Text = "Bonificación";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(507, 494);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(34, 15);
            this.lblTotal.TabIndex = 16;
            this.lblTotal.Text = "Total";
            // 
            // txtBonificacion
            // 
            this.txtBonificacion.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtBonificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBonificacion.Location = new System.Drawing.Point(547, 465);
            this.txtBonificacion.MaxLength = 80;
            this.txtBonificacion.Name = "txtBonificacion";
            this.txtBonificacion.ReadOnly = true;
            this.txtBonificacion.Size = new System.Drawing.Size(97, 21);
            this.txtBonificacion.TabIndex = 11;
            this.txtBonificacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblIva
            // 
            this.lblIva.AutoSize = true;
            this.lblIva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIva.Location = new System.Drawing.Point(278, 494);
            this.lblIva.Name = "lblIva";
            this.lblIva.Size = new System.Drawing.Size(22, 15);
            this.lblIva.TabIndex = 14;
            this.lblIva.Text = "Iva";
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(547, 491);
            this.txtTotal.MaxLength = 80;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(97, 21);
            this.txtTotal.TabIndex = 17;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal.Location = new System.Drawing.Point(5, 494);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(52, 15);
            this.lblSubtotal.TabIndex = 12;
            this.lblSubtotal.Text = "Subtotal";
            // 
            // txtIva
            // 
            this.txtIva.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtIva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIva.Location = new System.Drawing.Point(306, 492);
            this.txtIva.MaxLength = 80;
            this.txtIva.Name = "txtIva";
            this.txtIva.ReadOnly = true;
            this.txtIva.Size = new System.Drawing.Size(97, 21);
            this.txtIva.TabIndex = 15;
            this.txtIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtSubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubtotal.Location = new System.Drawing.Point(63, 492);
            this.txtSubtotal.MaxLength = 80;
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.ReadOnly = true;
            this.txtSubtotal.Size = new System.Drawing.Size(97, 21);
            this.txtSubtotal.TabIndex = 13;
            this.txtSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dgvComprobanteRegistrado
            // 
            this.dgvComprobanteRegistrado.AllowUserToAddRows = false;
            this.dgvComprobanteRegistrado.AllowUserToDeleteRows = false;
            this.dgvComprobanteRegistrado.AllowUserToResizeColumns = false;
            this.dgvComprobanteRegistrado.AllowUserToResizeRows = false;
            this.dgvComprobanteRegistrado.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvComprobanteRegistrado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvComprobanteRegistrado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvComprobanteRegistrado.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvComprobanteRegistrado.Location = new System.Drawing.Point(3, 153);
            this.dgvComprobanteRegistrado.MultiSelect = false;
            this.dgvComprobanteRegistrado.Name = "dgvComprobanteRegistrado";
            this.dgvComprobanteRegistrado.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvComprobanteRegistrado.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvComprobanteRegistrado.RowHeadersVisible = false;
            this.dgvComprobanteRegistrado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvComprobanteRegistrado.Size = new System.Drawing.Size(644, 299);
            this.dgvComprobanteRegistrado.TabIndex = 9;
            // 
            // lblComprobanteRegistrado
            // 
            this.lblComprobanteRegistrado.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblComprobanteRegistrado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblComprobanteRegistrado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComprobanteRegistrado.Location = new System.Drawing.Point(3, 12);
            this.lblComprobanteRegistrado.Name = "lblComprobanteRegistrado";
            this.lblComprobanteRegistrado.Size = new System.Drawing.Size(546, 25);
            this.lblComprobanteRegistrado.TabIndex = 100;
            this.lblComprobanteRegistrado.Text = "Comprobante Registrado";
            this.lblComprobanteRegistrado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlIzquierda
            // 
            this.pnlIzquierda.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlIzquierda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlIzquierda.Controls.Add(this.dtpFechaHasta);
            this.pnlIzquierda.Controls.Add(this.lblFiltroFechaHasta);
            this.pnlIzquierda.Controls.Add(this.dtpFechaDesde);
            this.pnlIzquierda.Controls.Add(this.lblFiltroFechaDesde);
            this.pnlIzquierda.Controls.Add(this.lblOB_3);
            this.pnlIzquierda.Controls.Add(this.lblOP_1);
            this.pnlIzquierda.Controls.Add(this.lblOB_2);
            this.pnlIzquierda.Controls.Add(this.lblOB_1);
            this.pnlIzquierda.Controls.Add(this.txtFiltroNroDeComprobante);
            this.pnlIzquierda.Controls.Add(this.lblFiltroNroDeComprobante);
            this.pnlIzquierda.Controls.Add(this.btnLimpiar);
            this.pnlIzquierda.Controls.Add(this.cbxFiltroTipoDeComprobante);
            this.pnlIzquierda.Controls.Add(this.btnBuscar);
            this.pnlIzquierda.Controls.Add(this.cbxFiltroNombreDeCliente);
            this.pnlIzquierda.Controls.Add(this.cbxFiltroCodCliente);
            this.pnlIzquierda.Controls.Add(this.lblFiltroNombreDeCliente);
            this.pnlIzquierda.Controls.Add(this.lblFiltroCodCliente);
            this.pnlIzquierda.Controls.Add(this.lblFiltroTipoDeComprobante);
            this.pnlIzquierda.Controls.Add(this.lblResultado);
            this.pnlIzquierda.Controls.Add(this.dgvComprobantes);
            this.pnlIzquierda.Location = new System.Drawing.Point(12, 12);
            this.pnlIzquierda.Name = "pnlIzquierda";
            this.pnlIzquierda.Size = new System.Drawing.Size(652, 680);
            this.pnlIzquierda.TabIndex = 1;
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaHasta.Location = new System.Drawing.Point(200, 156);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(286, 21);
            this.dtpFechaHasta.TabIndex = 6;
            // 
            // lblFiltroFechaHasta
            // 
            this.lblFiltroFechaHasta.AutoSize = true;
            this.lblFiltroFechaHasta.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblFiltroFechaHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltroFechaHasta.Location = new System.Drawing.Point(17, 161);
            this.lblFiltroFechaHasta.Name = "lblFiltroFechaHasta";
            this.lblFiltroFechaHasta.Size = new System.Drawing.Size(127, 15);
            this.lblFiltroFechaHasta.TabIndex = 105;
            this.lblFiltroFechaHasta.Text = "Filtro por Fecha Hasta";
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaDesde.Location = new System.Drawing.Point(200, 129);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(286, 21);
            this.dtpFechaDesde.TabIndex = 5;
            // 
            // lblFiltroFechaDesde
            // 
            this.lblFiltroFechaDesde.AutoSize = true;
            this.lblFiltroFechaDesde.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblFiltroFechaDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltroFechaDesde.Location = new System.Drawing.Point(17, 134);
            this.lblFiltroFechaDesde.Name = "lblFiltroFechaDesde";
            this.lblFiltroFechaDesde.Size = new System.Drawing.Size(131, 15);
            this.lblFiltroFechaDesde.TabIndex = 104;
            this.lblFiltroFechaDesde.Text = "Filtro por Fecha Desde";
            // 
            // lblOB_3
            // 
            this.lblOB_3.AutoSize = true;
            this.lblOB_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOB_3.Location = new System.Drawing.Point(492, 77);
            this.lblOB_3.Name = "lblOB_3";
            this.lblOB_3.Size = new System.Drawing.Size(38, 15);
            this.lblOB_3.TabIndex = 108;
            this.lblOB_3.Text = "( OB )";
            // 
            // lblOP_1
            // 
            this.lblOP_1.AutoSize = true;
            this.lblOP_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOP_1.Location = new System.Drawing.Point(492, 106);
            this.lblOP_1.Name = "lblOP_1";
            this.lblOP_1.Size = new System.Drawing.Size(38, 15);
            this.lblOP_1.TabIndex = 109;
            this.lblOP_1.Text = "( OP )";
            // 
            // lblOB_2
            // 
            this.lblOB_2.AutoSize = true;
            this.lblOB_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOB_2.Location = new System.Drawing.Point(492, 48);
            this.lblOB_2.Name = "lblOB_2";
            this.lblOB_2.Size = new System.Drawing.Size(38, 15);
            this.lblOB_2.TabIndex = 107;
            this.lblOB_2.Text = "( OB )";
            // 
            // lblOB_1
            // 
            this.lblOB_1.AutoSize = true;
            this.lblOB_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOB_1.Location = new System.Drawing.Point(492, 19);
            this.lblOB_1.Name = "lblOB_1";
            this.lblOB_1.Size = new System.Drawing.Size(38, 15);
            this.lblOB_1.TabIndex = 106;
            this.lblOB_1.Text = "( OB )";
            // 
            // txtFiltroNroDeComprobante
            // 
            this.txtFiltroNroDeComprobante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltroNroDeComprobante.Location = new System.Drawing.Point(199, 103);
            this.txtFiltroNroDeComprobante.MaxLength = 20;
            this.txtFiltroNroDeComprobante.Name = "txtFiltroNroDeComprobante";
            this.txtFiltroNroDeComprobante.Size = new System.Drawing.Size(287, 21);
            this.txtFiltroNroDeComprobante.TabIndex = 4;
            this.txtFiltroNroDeComprobante.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxFiltro_KeyDown);
            // 
            // lblFiltroNroDeComprobante
            // 
            this.lblFiltroNroDeComprobante.AutoSize = true;
            this.lblFiltroNroDeComprobante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltroNroDeComprobante.Location = new System.Drawing.Point(17, 106);
            this.lblFiltroNroDeComprobante.Name = "lblFiltroNroDeComprobante";
            this.lblFiltroNroDeComprobante.Size = new System.Drawing.Size(176, 15);
            this.lblFiltroNroDeComprobante.TabIndex = 103;
            this.lblFiltroNroDeComprobante.Text = "Filtro por Nro. de Comprobante";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(547, 103);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(86, 35);
            this.btnLimpiar.TabIndex = 8;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // cbxFiltroTipoDeComprobante
            // 
            this.cbxFiltroTipoDeComprobante.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxFiltroTipoDeComprobante.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxFiltroTipoDeComprobante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxFiltroTipoDeComprobante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxFiltroTipoDeComprobante.FormattingEnabled = true;
            this.cbxFiltroTipoDeComprobante.Location = new System.Drawing.Point(200, 74);
            this.cbxFiltroTipoDeComprobante.Name = "cbxFiltroTipoDeComprobante";
            this.cbxFiltroTipoDeComprobante.Size = new System.Drawing.Size(286, 23);
            this.cbxFiltroTipoDeComprobante.TabIndex = 3;
            this.cbxFiltroTipoDeComprobante.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxFiltro_KeyDown);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(547, 57);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(86, 35);
            this.btnBuscar.TabIndex = 7;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // cbxFiltroNombreDeCliente
            // 
            this.cbxFiltroNombreDeCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxFiltroNombreDeCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxFiltroNombreDeCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxFiltroNombreDeCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxFiltroNombreDeCliente.FormattingEnabled = true;
            this.cbxFiltroNombreDeCliente.Location = new System.Drawing.Point(200, 45);
            this.cbxFiltroNombreDeCliente.Name = "cbxFiltroNombreDeCliente";
            this.cbxFiltroNombreDeCliente.Size = new System.Drawing.Size(286, 23);
            this.cbxFiltroNombreDeCliente.TabIndex = 2;
            this.cbxFiltroNombreDeCliente.SelectedIndexChanged += new System.EventHandler(this.cbxFiltroNombreDeCliente_SelectedIndexChanged);
            this.cbxFiltroNombreDeCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxFiltro_KeyDown);
            // 
            // cbxFiltroCodCliente
            // 
            this.cbxFiltroCodCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxFiltroCodCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxFiltroCodCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxFiltroCodCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxFiltroCodCliente.FormattingEnabled = true;
            this.cbxFiltroCodCliente.Location = new System.Drawing.Point(200, 16);
            this.cbxFiltroCodCliente.Name = "cbxFiltroCodCliente";
            this.cbxFiltroCodCliente.Size = new System.Drawing.Size(286, 23);
            this.cbxFiltroCodCliente.TabIndex = 1;
            this.cbxFiltroCodCliente.SelectedIndexChanged += new System.EventHandler(this.cbxFiltroCodCliente_SelectedIndexChanged);
            this.cbxFiltroCodCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxFiltro_KeyDown);
            // 
            // lblFiltroNombreDeCliente
            // 
            this.lblFiltroNombreDeCliente.AutoSize = true;
            this.lblFiltroNombreDeCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltroNombreDeCliente.Location = new System.Drawing.Point(17, 48);
            this.lblFiltroNombreDeCliente.Name = "lblFiltroNombreDeCliente";
            this.lblFiltroNombreDeCliente.Size = new System.Drawing.Size(161, 15);
            this.lblFiltroNombreDeCliente.TabIndex = 101;
            this.lblFiltroNombreDeCliente.Text = "Filtro por Nombre de Cliente";
            // 
            // lblFiltroCodCliente
            // 
            this.lblFiltroCodCliente.AutoSize = true;
            this.lblFiltroCodCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltroCodCliente.Location = new System.Drawing.Point(17, 19);
            this.lblFiltroCodCliente.Name = "lblFiltroCodCliente";
            this.lblFiltroCodCliente.Size = new System.Drawing.Size(124, 15);
            this.lblFiltroCodCliente.TabIndex = 100;
            this.lblFiltroCodCliente.Text = "Filtro por Cod. Cliente";
            // 
            // lblFiltroTipoDeComprobante
            // 
            this.lblFiltroTipoDeComprobante.AutoSize = true;
            this.lblFiltroTipoDeComprobante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltroTipoDeComprobante.Location = new System.Drawing.Point(17, 77);
            this.lblFiltroTipoDeComprobante.Name = "lblFiltroTipoDeComprobante";
            this.lblFiltroTipoDeComprobante.Size = new System.Drawing.Size(177, 15);
            this.lblFiltroTipoDeComprobante.TabIndex = 102;
            this.lblFiltroTipoDeComprobante.Text = "Filtro por Tipo de Comprobante";
            // 
            // lblResultado
            // 
            this.lblResultado.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblResultado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblResultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultado.Location = new System.Drawing.Point(16, 200);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(617, 25);
            this.lblResultado.TabIndex = 110;
            this.lblResultado.Text = "Resultado";
            this.lblResultado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvComprobantes
            // 
            this.dgvComprobantes.AllowUserToAddRows = false;
            this.dgvComprobantes.AllowUserToDeleteRows = false;
            this.dgvComprobantes.AllowUserToResizeColumns = false;
            this.dgvComprobantes.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvComprobantes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvComprobantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvComprobantes.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvComprobantes.Location = new System.Drawing.Point(16, 228);
            this.dgvComprobantes.MultiSelect = false;
            this.dgvComprobantes.Name = "dgvComprobantes";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvComprobantes.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvComprobantes.RowHeadersVisible = false;
            this.dgvComprobantes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvComprobantes.Size = new System.Drawing.Size(617, 437);
            this.dgvComprobantes.TabIndex = 9;
            this.dgvComprobantes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvComprobantes_CellClick);
            // 
            // frmBuscarComprobante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 730);
            this.Controls.Add(this.pnlDerecho);
            this.Controls.Add(this.pnlIzquierda);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmBuscarComprobante";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar Comprobante de Venta";
            this.Load += new System.EventHandler(this.frmBuscarComprobante_Load);
            this.pnlDerecho.ResumeLayout(false);
            this.tbcComprobante.ResumeLayout(false);
            this.tbpNroComprobante.ResumeLayout(false);
            this.tbpNroComprobante.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturasAsociadas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComprobanteRegistrado)).EndInit();
            this.pnlIzquierda.ResumeLayout(false);
            this.pnlIzquierda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComprobantes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDerecho;
        private System.Windows.Forms.Label lblComprobanteRegistrado;
        private System.Windows.Forms.Panel pnlIzquierda;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.ComboBox cbxFiltroTipoDeComprobante;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cbxFiltroNombreDeCliente;
        private System.Windows.Forms.ComboBox cbxFiltroCodCliente;
        private System.Windows.Forms.Label lblFiltroNombreDeCliente;
        private System.Windows.Forms.Label lblFiltroCodCliente;
        private System.Windows.Forms.Label lblFiltroTipoDeComprobante;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.DataGridView dgvComprobantes;
        private System.Windows.Forms.TabControl tbcComprobante;
        private System.Windows.Forms.TabPage tbpNroComprobante;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Label lblNroComprobante;
        private System.Windows.Forms.TextBox txtNroComprobante;
        private System.Windows.Forms.Label lblTipoFactura;
        private System.Windows.Forms.Label lblDatosDelCliente;
        private System.Windows.Forms.Label lblBonificacion;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtBonificacion;
        private System.Windows.Forms.Label lblIva;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.TextBox txtIva;
        private System.Windows.Forms.TextBox txtSubtotal;
        private System.Windows.Forms.DataGridView dgvComprobanteRegistrado;
        private System.Windows.Forms.Button btnAnular;
        private System.Windows.Forms.CheckBox chbAnulado;
        private System.Windows.Forms.Label lblFiltroNroDeComprobante;
        private System.Windows.Forms.TextBox txtFiltroNroDeComprobante;
        private System.Windows.Forms.TextBox txtFechaDeRegistro;
        private System.Windows.Forms.Label lblFechaDeRegistro;
        private System.Windows.Forms.Label lblOB_3;
        private System.Windows.Forms.Label lblOP_1;
        private System.Windows.Forms.Label lblOB_2;
        private System.Windows.Forms.Label lblOB_1;
        private System.Windows.Forms.TextBox txtTipoDeComprobante;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.Label lblFiltroFechaHasta;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.Label lblFiltroFechaDesde;
        private System.Windows.Forms.Button btnLimpiarVista;
        private System.Windows.Forms.DataGridView dgvFacturasAsociadas;
        private System.Windows.Forms.Label lblPagado;
    }
}