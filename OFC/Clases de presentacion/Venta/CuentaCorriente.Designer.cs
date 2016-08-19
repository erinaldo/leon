namespace OFC
{
    partial class frmMovimientosDeCuentaCorriente
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
            this.pnlIzquierda = new System.Windows.Forms.Panel();
            this.lblNotas2 = new System.Windows.Forms.Label();
            this.lblNotas1 = new System.Windows.Forms.Label();
            this.lblXX1 = new System.Windows.Forms.Label();
            this.lblX2 = new System.Windows.Forms.Label();
            this.lblX1 = new System.Windows.Forms.Label();
            this.btnImprimirResumen = new System.Windows.Forms.Button();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.lblFiltroFechaHasta = new System.Windows.Forms.Label();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.lblFiltroFechaDesde = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.txtNroFactura = new System.Windows.Forms.TextBox();
            this.lblFiltroNroDeFactura = new System.Windows.Forms.Label();
            this.lblDatosDelCliente = new System.Windows.Forms.Label();
            this.cbxFiltroNombreDelCliente = new System.Windows.Forms.ComboBox();
            this.cbxFiltroCodCliente = new System.Windows.Forms.ComboBox();
            this.btnImprimirSaldosTotales = new System.Windows.Forms.Button();
            this.lblMovimientos = new System.Windows.Forms.Label();
            this.dgvMovimientos = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblFiltroCodCliente = new System.Windows.Forms.Label();
            this.lblFiltroNombreDelCliente = new System.Windows.Forms.Label();
            this.lblSaldoDeudor = new System.Windows.Forms.Label();
            this.pnlIzquierda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlIzquierda
            // 
            this.pnlIzquierda.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlIzquierda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlIzquierda.Controls.Add(this.lblSaldoDeudor);
            this.pnlIzquierda.Controls.Add(this.lblNotas2);
            this.pnlIzquierda.Controls.Add(this.lblNotas1);
            this.pnlIzquierda.Controls.Add(this.lblXX1);
            this.pnlIzquierda.Controls.Add(this.lblX2);
            this.pnlIzquierda.Controls.Add(this.lblX1);
            this.pnlIzquierda.Controls.Add(this.btnImprimirResumen);
            this.pnlIzquierda.Controls.Add(this.dtpFechaHasta);
            this.pnlIzquierda.Controls.Add(this.lblFiltroFechaHasta);
            this.pnlIzquierda.Controls.Add(this.dtpFechaDesde);
            this.pnlIzquierda.Controls.Add(this.lblFiltroFechaDesde);
            this.pnlIzquierda.Controls.Add(this.btnLimpiar);
            this.pnlIzquierda.Controls.Add(this.txtNroFactura);
            this.pnlIzquierda.Controls.Add(this.lblFiltroNroDeFactura);
            this.pnlIzquierda.Controls.Add(this.lblDatosDelCliente);
            this.pnlIzquierda.Controls.Add(this.cbxFiltroNombreDelCliente);
            this.pnlIzquierda.Controls.Add(this.cbxFiltroCodCliente);
            this.pnlIzquierda.Controls.Add(this.btnImprimirSaldosTotales);
            this.pnlIzquierda.Controls.Add(this.lblMovimientos);
            this.pnlIzquierda.Controls.Add(this.dgvMovimientos);
            this.pnlIzquierda.Controls.Add(this.btnBuscar);
            this.pnlIzquierda.Controls.Add(this.lblFiltroCodCliente);
            this.pnlIzquierda.Controls.Add(this.lblFiltroNombreDelCliente);
            this.pnlIzquierda.Location = new System.Drawing.Point(12, 12);
            this.pnlIzquierda.Name = "pnlIzquierda";
            this.pnlIzquierda.Size = new System.Drawing.Size(1346, 680);
            this.pnlIzquierda.TabIndex = 1;
            // 
            // lblNotas2
            // 
            this.lblNotas2.AutoSize = true;
            this.lblNotas2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotas2.Location = new System.Drawing.Point(13, 649);
            this.lblNotas2.Name = "lblNotas2";
            this.lblNotas2.Size = new System.Drawing.Size(510, 15);
            this.lblNotas2.TabIndex = 113;
            this.lblNotas2.Text = "( ** ) El nro. de comprobante no es considerado un filtro en el reporte de resume" +
    "n de cuenta.";
            // 
            // lblNotas1
            // 
            this.lblNotas1.AutoSize = true;
            this.lblNotas1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotas1.Location = new System.Drawing.Point(13, 628);
            this.lblNotas1.Name = "lblNotas1";
            this.lblNotas1.Size = new System.Drawing.Size(314, 15);
            this.lblNotas1.TabIndex = 112;
            this.lblNotas1.Text = "( * ) Dato obligatorio para obtener el resumen de cuenta.";
            // 
            // lblXX1
            // 
            this.lblXX1.AutoSize = true;
            this.lblXX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblXX1.Location = new System.Drawing.Point(483, 73);
            this.lblXX1.Name = "lblXX1";
            this.lblXX1.Size = new System.Drawing.Size(31, 15);
            this.lblXX1.TabIndex = 108;
            this.lblXX1.Text = "( ** )";
            // 
            // lblX2
            // 
            this.lblX2.AutoSize = true;
            this.lblX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblX2.Location = new System.Drawing.Point(485, 44);
            this.lblX2.Name = "lblX2";
            this.lblX2.Size = new System.Drawing.Size(26, 15);
            this.lblX2.TabIndex = 107;
            this.lblX2.Text = "( * )";
            // 
            // lblX1
            // 
            this.lblX1.AutoSize = true;
            this.lblX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblX1.Location = new System.Drawing.Point(485, 15);
            this.lblX1.Name = "lblX1";
            this.lblX1.Size = new System.Drawing.Size(26, 15);
            this.lblX1.TabIndex = 106;
            this.lblX1.Text = "( * )";
            // 
            // btnImprimirResumen
            // 
            this.btnImprimirResumen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimirResumen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimirResumen.Location = new System.Drawing.Point(974, 628);
            this.btnImprimirResumen.Name = "btnImprimirResumen";
            this.btnImprimirResumen.Size = new System.Drawing.Size(174, 36);
            this.btnImprimirResumen.TabIndex = 9;
            this.btnImprimirResumen.Text = "Resumen de Cuenta";
            this.btnImprimirResumen.UseVisualStyleBackColor = true;
            this.btnImprimirResumen.Click += new System.EventHandler(this.btnImprimirResumen_Click);
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaHasta.Location = new System.Drawing.Point(197, 124);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(282, 21);
            this.dtpFechaHasta.TabIndex = 5;
            // 
            // lblFiltroFechaHasta
            // 
            this.lblFiltroFechaHasta.AutoSize = true;
            this.lblFiltroFechaHasta.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblFiltroFechaHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltroFechaHasta.Location = new System.Drawing.Point(15, 129);
            this.lblFiltroFechaHasta.Name = "lblFiltroFechaHasta";
            this.lblFiltroFechaHasta.Size = new System.Drawing.Size(127, 15);
            this.lblFiltroFechaHasta.TabIndex = 105;
            this.lblFiltroFechaHasta.Text = "Filtro por Fecha Hasta";
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaDesde.Location = new System.Drawing.Point(197, 97);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(282, 21);
            this.dtpFechaDesde.TabIndex = 4;
            // 
            // lblFiltroFechaDesde
            // 
            this.lblFiltroFechaDesde.AutoSize = true;
            this.lblFiltroFechaDesde.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblFiltroFechaDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltroFechaDesde.Location = new System.Drawing.Point(15, 102);
            this.lblFiltroFechaDesde.Name = "lblFiltroFechaDesde";
            this.lblFiltroFechaDesde.Size = new System.Drawing.Size(131, 15);
            this.lblFiltroFechaDesde.TabIndex = 104;
            this.lblFiltroFechaDesde.Text = "Filtro por Fecha Desde";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(383, 154);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(96, 36);
            this.btnLimpiar.TabIndex = 7;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // txtNroFactura
            // 
            this.txtNroFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroFactura.Location = new System.Drawing.Point(197, 70);
            this.txtNroFactura.Name = "txtNroFactura";
            this.txtNroFactura.Size = new System.Drawing.Size(282, 21);
            this.txtNroFactura.TabIndex = 3;
            this.txtNroFactura.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxFiltro_KeyDown);
            // 
            // lblFiltroNroDeFactura
            // 
            this.lblFiltroNroDeFactura.AutoSize = true;
            this.lblFiltroNroDeFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltroNroDeFactura.Location = new System.Drawing.Point(15, 73);
            this.lblFiltroNroDeFactura.Name = "lblFiltroNroDeFactura";
            this.lblFiltroNroDeFactura.Size = new System.Drawing.Size(176, 15);
            this.lblFiltroNroDeFactura.TabIndex = 103;
            this.lblFiltroNroDeFactura.Text = "Filtro por Nro. de Comprobante";
            // 
            // lblDatosDelCliente
            // 
            this.lblDatosDelCliente.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblDatosDelCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDatosDelCliente.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatosDelCliente.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lblDatosDelCliente.Location = new System.Drawing.Point(817, 12);
            this.lblDatosDelCliente.Name = "lblDatosDelCliente";
            this.lblDatosDelCliente.Size = new System.Drawing.Size(511, 133);
            this.lblDatosDelCliente.TabIndex = 110;
            this.lblDatosDelCliente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxFiltroNombreDelCliente
            // 
            this.cbxFiltroNombreDelCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxFiltroNombreDelCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxFiltroNombreDelCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxFiltroNombreDelCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxFiltroNombreDelCliente.FormattingEnabled = true;
            this.cbxFiltroNombreDelCliente.Location = new System.Drawing.Point(197, 41);
            this.cbxFiltroNombreDelCliente.Name = "cbxFiltroNombreDelCliente";
            this.cbxFiltroNombreDelCliente.Size = new System.Drawing.Size(282, 23);
            this.cbxFiltroNombreDelCliente.TabIndex = 2;
            this.cbxFiltroNombreDelCliente.SelectedIndexChanged += new System.EventHandler(this.cbxFiltroNombreDelCliente_SelectedIndexChanged);
            this.cbxFiltroNombreDelCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxFiltro_KeyDown);
            // 
            // cbxFiltroCodCliente
            // 
            this.cbxFiltroCodCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxFiltroCodCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxFiltroCodCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxFiltroCodCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxFiltroCodCliente.FormattingEnabled = true;
            this.cbxFiltroCodCliente.Location = new System.Drawing.Point(197, 12);
            this.cbxFiltroCodCliente.Name = "cbxFiltroCodCliente";
            this.cbxFiltroCodCliente.Size = new System.Drawing.Size(282, 23);
            this.cbxFiltroCodCliente.TabIndex = 1;
            this.cbxFiltroCodCliente.SelectedIndexChanged += new System.EventHandler(this.cbxFiltroCodCliente_SelectedIndexChanged);
            this.cbxFiltroCodCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxFiltro_KeyDown);
            // 
            // btnImprimirSaldosTotales
            // 
            this.btnImprimirSaldosTotales.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimirSaldosTotales.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimirSaldosTotales.Location = new System.Drawing.Point(1154, 628);
            this.btnImprimirSaldosTotales.Name = "btnImprimirSaldosTotales";
            this.btnImprimirSaldosTotales.Size = new System.Drawing.Size(174, 36);
            this.btnImprimirSaldosTotales.TabIndex = 10;
            this.btnImprimirSaldosTotales.Text = "Saldos Totales";
            this.btnImprimirSaldosTotales.UseVisualStyleBackColor = true;
            this.btnImprimirSaldosTotales.Click += new System.EventHandler(this.btnImprimirSaldosTotales_Click);
            // 
            // lblMovimientos
            // 
            this.lblMovimientos.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblMovimientos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMovimientos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovimientos.Location = new System.Drawing.Point(16, 193);
            this.lblMovimientos.Name = "lblMovimientos";
            this.lblMovimientos.Size = new System.Drawing.Size(1312, 25);
            this.lblMovimientos.TabIndex = 111;
            this.lblMovimientos.Text = "Movimientos";
            this.lblMovimientos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvMovimientos
            // 
            this.dgvMovimientos.AllowUserToAddRows = false;
            this.dgvMovimientos.AllowUserToDeleteRows = false;
            this.dgvMovimientos.AllowUserToResizeColumns = false;
            this.dgvMovimientos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMovimientos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMovimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMovimientos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMovimientos.Location = new System.Drawing.Point(16, 221);
            this.dgvMovimientos.MultiSelect = false;
            this.dgvMovimientos.Name = "dgvMovimientos";
            this.dgvMovimientos.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMovimientos.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMovimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvMovimientos.Size = new System.Drawing.Size(1312, 392);
            this.dgvMovimientos.TabIndex = 8;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(197, 154);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(96, 36);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblFiltroCodCliente
            // 
            this.lblFiltroCodCliente.AutoSize = true;
            this.lblFiltroCodCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltroCodCliente.Location = new System.Drawing.Point(15, 15);
            this.lblFiltroCodCliente.Name = "lblFiltroCodCliente";
            this.lblFiltroCodCliente.Size = new System.Drawing.Size(124, 15);
            this.lblFiltroCodCliente.TabIndex = 101;
            this.lblFiltroCodCliente.Text = "Filtro por Cod. Cliente";
            // 
            // lblFiltroNombreDelCliente
            // 
            this.lblFiltroNombreDelCliente.AutoSize = true;
            this.lblFiltroNombreDelCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltroNombreDelCliente.Location = new System.Drawing.Point(15, 44);
            this.lblFiltroNombreDelCliente.Name = "lblFiltroNombreDelCliente";
            this.lblFiltroNombreDelCliente.Size = new System.Drawing.Size(164, 15);
            this.lblFiltroNombreDelCliente.TabIndex = 102;
            this.lblFiltroNombreDelCliente.Text = "Filtro por Nombre del Cliente";
            // 
            // lblSaldoDeudor
            // 
            this.lblSaldoDeudor.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblSaldoDeudor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSaldoDeudor.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldoDeudor.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lblSaldoDeudor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSaldoDeudor.Location = new System.Drawing.Point(534, 12);
            this.lblSaldoDeudor.Name = "lblSaldoDeudor";
            this.lblSaldoDeudor.Size = new System.Drawing.Size(277, 133);
            this.lblSaldoDeudor.TabIndex = 114;
            this.lblSaldoDeudor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmMovimientosDeCuentaCorriente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 730);
            this.Controls.Add(this.pnlIzquierda);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmMovimientosDeCuentaCorriente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Movimientos de Cuenta Corriente Cliente";
            this.Load += new System.EventHandler(this.frmMovimientosDeCuentaCorriente_Load);
            this.pnlIzquierda.ResumeLayout(false);
            this.pnlIzquierda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlIzquierda;
        private System.Windows.Forms.Label lblMovimientos;
        private System.Windows.Forms.DataGridView dgvMovimientos;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblFiltroCodCliente;
        private System.Windows.Forms.Label lblFiltroNombreDelCliente;
        private System.Windows.Forms.Button btnImprimirSaldosTotales;
        private System.Windows.Forms.ComboBox cbxFiltroNombreDelCliente;
        private System.Windows.Forms.ComboBox cbxFiltroCodCliente;
        private System.Windows.Forms.Label lblDatosDelCliente;
        private System.Windows.Forms.TextBox txtNroFactura;
        private System.Windows.Forms.Label lblFiltroNroDeFactura;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.Label lblFiltroFechaDesde;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.Label lblFiltroFechaHasta;
        private System.Windows.Forms.Button btnImprimirResumen;
        private System.Windows.Forms.Label lblXX1;
        private System.Windows.Forms.Label lblX2;
        private System.Windows.Forms.Label lblX1;
        private System.Windows.Forms.Label lblNotas1;
        private System.Windows.Forms.Label lblNotas2;
        private System.Windows.Forms.Label lblSaldoDeudor;
    }
}