namespace OFC
{
    partial class frmMovimientosCuentaCorrienteProveedor
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
            this.lblNotas1 = new System.Windows.Forms.Label();
            this.lblX2 = new System.Windows.Forms.Label();
            this.lblX1 = new System.Windows.Forms.Label();
            this.btnImprimirResumen = new System.Windows.Forms.Button();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.lblFiltroFechaHasta = new System.Windows.Forms.Label();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.lblFiltroFechaDesde = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.lblSaldoDeudor = new System.Windows.Forms.Label();
            this.lblDatosDelProveedor = new System.Windows.Forms.Label();
            this.cbxFiltroNombreDelProveedor = new System.Windows.Forms.ComboBox();
            this.cbxFiltroCodProveedor = new System.Windows.Forms.ComboBox();
            this.btnImprimirSaldosTotales = new System.Windows.Forms.Button();
            this.lblMovimientos = new System.Windows.Forms.Label();
            this.dgvMovimientos = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblFiltroCodProveedor = new System.Windows.Forms.Label();
            this.lblFiltroNombreDelProveedor = new System.Windows.Forms.Label();
            this.pnlIzquierda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlIzquierda
            // 
            this.pnlIzquierda.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlIzquierda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlIzquierda.Controls.Add(this.lblNotas1);
            this.pnlIzquierda.Controls.Add(this.lblX2);
            this.pnlIzquierda.Controls.Add(this.lblX1);
            this.pnlIzquierda.Controls.Add(this.btnImprimirResumen);
            this.pnlIzquierda.Controls.Add(this.dtpFechaHasta);
            this.pnlIzquierda.Controls.Add(this.lblFiltroFechaHasta);
            this.pnlIzquierda.Controls.Add(this.dtpFechaDesde);
            this.pnlIzquierda.Controls.Add(this.lblFiltroFechaDesde);
            this.pnlIzquierda.Controls.Add(this.btnLimpiar);
            this.pnlIzquierda.Controls.Add(this.lblSaldoDeudor);
            this.pnlIzquierda.Controls.Add(this.lblDatosDelProveedor);
            this.pnlIzquierda.Controls.Add(this.cbxFiltroNombreDelProveedor);
            this.pnlIzquierda.Controls.Add(this.cbxFiltroCodProveedor);
            this.pnlIzquierda.Controls.Add(this.btnImprimirSaldosTotales);
            this.pnlIzquierda.Controls.Add(this.lblMovimientos);
            this.pnlIzquierda.Controls.Add(this.dgvMovimientos);
            this.pnlIzquierda.Controls.Add(this.btnBuscar);
            this.pnlIzquierda.Controls.Add(this.lblFiltroCodProveedor);
            this.pnlIzquierda.Controls.Add(this.lblFiltroNombreDelProveedor);
            this.pnlIzquierda.Location = new System.Drawing.Point(12, 12);
            this.pnlIzquierda.Name = "pnlIzquierda";
            this.pnlIzquierda.Size = new System.Drawing.Size(1342, 680);
            this.pnlIzquierda.TabIndex = 2;
            // 
            // lblNotas1
            // 
            this.lblNotas1.AutoSize = true;
            this.lblNotas1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotas1.Location = new System.Drawing.Point(13, 639);
            this.lblNotas1.Name = "lblNotas1";
            this.lblNotas1.Size = new System.Drawing.Size(314, 15);
            this.lblNotas1.TabIndex = 112;
            this.lblNotas1.Text = "( * ) Dato obligatorio para obtener el resumen de cuenta.";
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
            this.dtpFechaHasta.Location = new System.Drawing.Point(218, 97);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(261, 21);
            this.dtpFechaHasta.TabIndex = 5;
            // 
            // lblFiltroFechaHasta
            // 
            this.lblFiltroFechaHasta.AutoSize = true;
            this.lblFiltroFechaHasta.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblFiltroFechaHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltroFechaHasta.Location = new System.Drawing.Point(15, 102);
            this.lblFiltroFechaHasta.Name = "lblFiltroFechaHasta";
            this.lblFiltroFechaHasta.Size = new System.Drawing.Size(193, 15);
            this.lblFiltroFechaHasta.TabIndex = 105;
            this.lblFiltroFechaHasta.Text = "Filtro por Fecha de Registro Hasta";
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaDesde.Location = new System.Drawing.Point(218, 70);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(261, 21);
            this.dtpFechaDesde.TabIndex = 4;
            // 
            // lblFiltroFechaDesde
            // 
            this.lblFiltroFechaDesde.AutoSize = true;
            this.lblFiltroFechaDesde.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblFiltroFechaDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltroFechaDesde.Location = new System.Drawing.Point(15, 75);
            this.lblFiltroFechaDesde.Name = "lblFiltroFechaDesde";
            this.lblFiltroFechaDesde.Size = new System.Drawing.Size(197, 15);
            this.lblFiltroFechaDesde.TabIndex = 104;
            this.lblFiltroFechaDesde.Text = "Filtro por Fecha de Registro Desde";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(383, 127);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(96, 36);
            this.btnLimpiar.TabIndex = 7;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // lblSaldoDeudor
            // 
            this.lblSaldoDeudor.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblSaldoDeudor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSaldoDeudor.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldoDeudor.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lblSaldoDeudor.Location = new System.Drawing.Point(516, 12);
            this.lblSaldoDeudor.Name = "lblSaldoDeudor";
            this.lblSaldoDeudor.Size = new System.Drawing.Size(303, 151);
            this.lblSaldoDeudor.TabIndex = 109;
            this.lblSaldoDeudor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDatosDelProveedor
            // 
            this.lblDatosDelProveedor.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblDatosDelProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDatosDelProveedor.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatosDelProveedor.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lblDatosDelProveedor.Location = new System.Drawing.Point(825, 12);
            this.lblDatosDelProveedor.Name = "lblDatosDelProveedor";
            this.lblDatosDelProveedor.Size = new System.Drawing.Size(503, 151);
            this.lblDatosDelProveedor.TabIndex = 110;
            this.lblDatosDelProveedor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxFiltroNombreDelProveedor
            // 
            this.cbxFiltroNombreDelProveedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxFiltroNombreDelProveedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxFiltroNombreDelProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxFiltroNombreDelProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxFiltroNombreDelProveedor.FormattingEnabled = true;
            this.cbxFiltroNombreDelProveedor.Location = new System.Drawing.Point(218, 41);
            this.cbxFiltroNombreDelProveedor.Name = "cbxFiltroNombreDelProveedor";
            this.cbxFiltroNombreDelProveedor.Size = new System.Drawing.Size(261, 23);
            this.cbxFiltroNombreDelProveedor.TabIndex = 2;
            this.cbxFiltroNombreDelProveedor.SelectedIndexChanged += new System.EventHandler(this.cbxFiltroNombreDelProveedor_SelectedIndexChanged);
            this.cbxFiltroNombreDelProveedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxFiltro_KeyDown);
            // 
            // cbxFiltroCodProveedor
            // 
            this.cbxFiltroCodProveedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxFiltroCodProveedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxFiltroCodProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxFiltroCodProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxFiltroCodProveedor.FormattingEnabled = true;
            this.cbxFiltroCodProveedor.Location = new System.Drawing.Point(218, 12);
            this.cbxFiltroCodProveedor.Name = "cbxFiltroCodProveedor";
            this.cbxFiltroCodProveedor.Size = new System.Drawing.Size(261, 23);
            this.cbxFiltroCodProveedor.TabIndex = 1;
            this.cbxFiltroCodProveedor.SelectedIndexChanged += new System.EventHandler(this.cbxFiltroCodProveedor_SelectedIndexChanged);
            this.cbxFiltroCodProveedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxFiltro_KeyDown);
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
            this.lblMovimientos.Location = new System.Drawing.Point(16, 176);
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
            this.dgvMovimientos.Location = new System.Drawing.Point(16, 204);
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
            this.dgvMovimientos.Size = new System.Drawing.Size(1312, 409);
            this.dgvMovimientos.TabIndex = 8;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(218, 127);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(96, 36);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblFiltroCodProveedor
            // 
            this.lblFiltroCodProveedor.AutoSize = true;
            this.lblFiltroCodProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltroCodProveedor.Location = new System.Drawing.Point(15, 15);
            this.lblFiltroCodProveedor.Name = "lblFiltroCodProveedor";
            this.lblFiltroCodProveedor.Size = new System.Drawing.Size(142, 15);
            this.lblFiltroCodProveedor.TabIndex = 101;
            this.lblFiltroCodProveedor.Text = "Filtro por Cod. Proveedor";
            // 
            // lblFiltroNombreDelProveedor
            // 
            this.lblFiltroNombreDelProveedor.AutoSize = true;
            this.lblFiltroNombreDelProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltroNombreDelProveedor.Location = new System.Drawing.Point(15, 44);
            this.lblFiltroNombreDelProveedor.Name = "lblFiltroNombreDelProveedor";
            this.lblFiltroNombreDelProveedor.Size = new System.Drawing.Size(182, 15);
            this.lblFiltroNombreDelProveedor.TabIndex = 102;
            this.lblFiltroNombreDelProveedor.Text = "Filtro por Nombre del Proveedor";
            // 
            // frmMovimientosCuentaCorrienteProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 730);
            this.Controls.Add(this.pnlIzquierda);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmMovimientosCuentaCorrienteProveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Movimientos de Cuenta Corriente Proveedor";
            this.Load += new System.EventHandler(this.frmMovimientosCuentaCorrienteProveedor_Load);
            this.pnlIzquierda.ResumeLayout(false);
            this.pnlIzquierda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlIzquierda;
        private System.Windows.Forms.Label lblNotas1;
        private System.Windows.Forms.Label lblX2;
        private System.Windows.Forms.Label lblX1;
        private System.Windows.Forms.Button btnImprimirResumen;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.Label lblFiltroFechaHasta;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.Label lblFiltroFechaDesde;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblSaldoDeudor;
        private System.Windows.Forms.Label lblDatosDelProveedor;
        private System.Windows.Forms.ComboBox cbxFiltroNombreDelProveedor;
        private System.Windows.Forms.ComboBox cbxFiltroCodProveedor;
        private System.Windows.Forms.Button btnImprimirSaldosTotales;
        private System.Windows.Forms.Label lblMovimientos;
        private System.Windows.Forms.DataGridView dgvMovimientos;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblFiltroCodProveedor;
        private System.Windows.Forms.Label lblFiltroNombreDelProveedor;
    }
}