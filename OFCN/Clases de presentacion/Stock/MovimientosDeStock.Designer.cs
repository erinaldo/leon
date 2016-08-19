namespace OFC
{
    partial class frmMovimientosDeStock
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
            this.pnlIzquierda = new System.Windows.Forms.Panel();
            this.btnReportePorArticulo = new System.Windows.Forms.Button();
            this.cbxFiltroDescripcionArticulo = new System.Windows.Forms.ComboBox();
            this.cbxFiltroPorArticulo = new System.Windows.Forms.ComboBox();
            this.btnReportePorFecha = new System.Windows.Forms.Button();
            this.lblFiltroPorArticulo = new System.Windows.Forms.Label();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.lblFiltroFechaHasta = new System.Windows.Forms.Label();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.lblFiltroFechaDesde = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.lblResultado = new System.Windows.Forms.Label();
            this.dgvMovimientosDeStock = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.pnlIzquierda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientosDeStock)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlIzquierda
            // 
            this.pnlIzquierda.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlIzquierda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlIzquierda.Controls.Add(this.btnReportePorArticulo);
            this.pnlIzquierda.Controls.Add(this.cbxFiltroDescripcionArticulo);
            this.pnlIzquierda.Controls.Add(this.cbxFiltroPorArticulo);
            this.pnlIzquierda.Controls.Add(this.btnReportePorFecha);
            this.pnlIzquierda.Controls.Add(this.lblFiltroPorArticulo);
            this.pnlIzquierda.Controls.Add(this.dtpFechaHasta);
            this.pnlIzquierda.Controls.Add(this.lblFiltroFechaHasta);
            this.pnlIzquierda.Controls.Add(this.dtpFechaDesde);
            this.pnlIzquierda.Controls.Add(this.lblFiltroFechaDesde);
            this.pnlIzquierda.Controls.Add(this.btnLimpiar);
            this.pnlIzquierda.Controls.Add(this.lblResultado);
            this.pnlIzquierda.Controls.Add(this.dgvMovimientosDeStock);
            this.pnlIzquierda.Controls.Add(this.btnBuscar);
            this.pnlIzquierda.Location = new System.Drawing.Point(12, 12);
            this.pnlIzquierda.Name = "pnlIzquierda";
            this.pnlIzquierda.Size = new System.Drawing.Size(1346, 679);
            this.pnlIzquierda.TabIndex = 2;
            // 
            // btnReportePorArticulo
            // 
            this.btnReportePorArticulo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReportePorArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportePorArticulo.Location = new System.Drawing.Point(1215, 625);
            this.btnReportePorArticulo.Name = "btnReportePorArticulo";
            this.btnReportePorArticulo.Size = new System.Drawing.Size(114, 39);
            this.btnReportePorArticulo.TabIndex = 9;
            this.btnReportePorArticulo.Text = "Reporte por Artículo";
            this.btnReportePorArticulo.UseVisualStyleBackColor = true;
            // 
            // cbxFiltroDescripcionArticulo
            // 
            this.cbxFiltroDescripcionArticulo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxFiltroDescripcionArticulo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxFiltroDescripcionArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxFiltroDescripcionArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxFiltroDescripcionArticulo.FormattingEnabled = true;
            this.cbxFiltroDescripcionArticulo.Location = new System.Drawing.Point(316, 12);
            this.cbxFiltroDescripcionArticulo.Name = "cbxFiltroDescripcionArticulo";
            this.cbxFiltroDescripcionArticulo.Size = new System.Drawing.Size(287, 23);
            this.cbxFiltroDescripcionArticulo.TabIndex = 2;
            this.cbxFiltroDescripcionArticulo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxFiltro_KeyDown);
            // 
            // cbxFiltroPorArticulo
            // 
            this.cbxFiltroPorArticulo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxFiltroPorArticulo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxFiltroPorArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxFiltroPorArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxFiltroPorArticulo.FormattingEnabled = true;
            this.cbxFiltroPorArticulo.Location = new System.Drawing.Point(218, 12);
            this.cbxFiltroPorArticulo.Name = "cbxFiltroPorArticulo";
            this.cbxFiltroPorArticulo.Size = new System.Drawing.Size(92, 23);
            this.cbxFiltroPorArticulo.TabIndex = 1;
            this.cbxFiltroPorArticulo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxFiltro_KeyDown);
            // 
            // btnReportePorFecha
            // 
            this.btnReportePorFecha.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReportePorFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportePorFecha.Location = new System.Drawing.Point(1095, 625);
            this.btnReportePorFecha.Name = "btnReportePorFecha";
            this.btnReportePorFecha.Size = new System.Drawing.Size(114, 39);
            this.btnReportePorFecha.TabIndex = 8;
            this.btnReportePorFecha.Text = "Reporte por Fecha";
            this.btnReportePorFecha.UseVisualStyleBackColor = true;
            // 
            // lblFiltroPorArticulo
            // 
            this.lblFiltroPorArticulo.AutoSize = true;
            this.lblFiltroPorArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltroPorArticulo.Location = new System.Drawing.Point(15, 15);
            this.lblFiltroPorArticulo.Name = "lblFiltroPorArticulo";
            this.lblFiltroPorArticulo.Size = new System.Drawing.Size(98, 15);
            this.lblFiltroPorArticulo.TabIndex = 103;
            this.lblFiltroPorArticulo.Text = "Filtro por Artículo";
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaHasta.Location = new System.Drawing.Point(218, 68);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(385, 21);
            this.dtpFechaHasta.TabIndex = 4;
            // 
            // lblFiltroFechaHasta
            // 
            this.lblFiltroFechaHasta.AutoSize = true;
            this.lblFiltroFechaHasta.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblFiltroFechaHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltroFechaHasta.Location = new System.Drawing.Point(15, 73);
            this.lblFiltroFechaHasta.Name = "lblFiltroFechaHasta";
            this.lblFiltroFechaHasta.Size = new System.Drawing.Size(193, 15);
            this.lblFiltroFechaHasta.TabIndex = 106;
            this.lblFiltroFechaHasta.Text = "Filtro por Fecha de Registro Hasta";
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaDesde.Location = new System.Drawing.Point(218, 41);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(385, 21);
            this.dtpFechaDesde.TabIndex = 3;
            // 
            // lblFiltroFechaDesde
            // 
            this.lblFiltroFechaDesde.AutoSize = true;
            this.lblFiltroFechaDesde.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblFiltroFechaDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltroFechaDesde.Location = new System.Drawing.Point(15, 46);
            this.lblFiltroFechaDesde.Name = "lblFiltroFechaDesde";
            this.lblFiltroFechaDesde.Size = new System.Drawing.Size(197, 15);
            this.lblFiltroFechaDesde.TabIndex = 105;
            this.lblFiltroFechaDesde.Text = "Filtro por Fecha de Registro Desde";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(640, 54);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(96, 35);
            this.btnLimpiar.TabIndex = 6;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // lblResultado
            // 
            this.lblResultado.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblResultado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblResultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultado.Location = new System.Drawing.Point(16, 112);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(1313, 25);
            this.lblResultado.TabIndex = 107;
            this.lblResultado.Text = "Resultado";
            this.lblResultado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvMovimientosDeStock
            // 
            this.dgvMovimientosDeStock.AllowUserToAddRows = false;
            this.dgvMovimientosDeStock.AllowUserToDeleteRows = false;
            this.dgvMovimientosDeStock.AllowUserToResizeColumns = false;
            this.dgvMovimientosDeStock.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMovimientosDeStock.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMovimientosDeStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMovimientosDeStock.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMovimientosDeStock.Location = new System.Drawing.Point(16, 140);
            this.dgvMovimientosDeStock.MultiSelect = false;
            this.dgvMovimientosDeStock.Name = "dgvMovimientosDeStock";
            this.dgvMovimientosDeStock.ReadOnly = true;
            this.dgvMovimientosDeStock.RowHeadersVisible = false;
            this.dgvMovimientosDeStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvMovimientosDeStock.Size = new System.Drawing.Size(1313, 479);
            this.dgvMovimientosDeStock.TabIndex = 7;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(640, 13);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(96, 35);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // frmMovimientosDeStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 730);
            this.Controls.Add(this.pnlIzquierda);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmMovimientosDeStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Movimientos de Stock";
            this.Load += new System.EventHandler(this.frmMovimientosDeStock_Load);
            this.pnlIzquierda.ResumeLayout(false);
            this.pnlIzquierda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientosDeStock)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlIzquierda;
        private System.Windows.Forms.Button btnReportePorFecha;
        private System.Windows.Forms.Label lblFiltroPorArticulo;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.Label lblFiltroFechaHasta;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.Label lblFiltroFechaDesde;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.DataGridView dgvMovimientosDeStock;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cbxFiltroPorArticulo;
        private System.Windows.Forms.ComboBox cbxFiltroDescripcionArticulo;
        private System.Windows.Forms.Button btnReportePorArticulo;
    }
}