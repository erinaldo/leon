namespace OFC
{
    partial class frmHistoricoCubiertas
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
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.cbxFiltroNombreDeCliente = new System.Windows.Forms.ComboBox();
            this.cbxFiltroCodCliente = new System.Windows.Forms.ComboBox();
            this.lblFiltroNombreDeCliente = new System.Windows.Forms.Label();
            this.lblResultado = new System.Windows.Forms.Label();
            this.lblFiltroCodCliente = new System.Windows.Forms.Label();
            this.pnlIzquierda = new System.Windows.Forms.Panel();
            this.btnReporte = new System.Windows.Forms.Button();
            this.txtFiltroNroDeOrden = new System.Windows.Forms.TextBox();
            this.lblOP_1 = new System.Windows.Forms.Label();
            this.lblFiltroNroDeOrden = new System.Windows.Forms.Label();
            this.lblOP_2 = new System.Windows.Forms.Label();
            this.lblOB_2 = new System.Windows.Forms.Label();
            this.lblOB_1 = new System.Windows.Forms.Label();
            this.cbxFiltroMedidaDeCubierta = new System.Windows.Forms.ComboBox();
            this.lblFiltroMedidaDeCubierta = new System.Windows.Forms.Label();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.lblFiltroFechaHasta = new System.Windows.Forms.Label();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.lblFiltroFechaDesde = new System.Windows.Forms.Label();
            this.dgvHistoricoCubiertas = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.pnlIzquierda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistoricoCubiertas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(573, 101);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(96, 35);
            this.btnLimpiar.TabIndex = 8;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // cbxFiltroNombreDeCliente
            // 
            this.cbxFiltroNombreDeCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxFiltroNombreDeCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxFiltroNombreDeCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxFiltroNombreDeCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxFiltroNombreDeCliente.FormattingEnabled = true;
            this.cbxFiltroNombreDeCliente.Location = new System.Drawing.Point(187, 43);
            this.cbxFiltroNombreDeCliente.Name = "cbxFiltroNombreDeCliente";
            this.cbxFiltroNombreDeCliente.Size = new System.Drawing.Size(297, 23);
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
            this.cbxFiltroCodCliente.Location = new System.Drawing.Point(187, 14);
            this.cbxFiltroCodCliente.Name = "cbxFiltroCodCliente";
            this.cbxFiltroCodCliente.Size = new System.Drawing.Size(297, 23);
            this.cbxFiltroCodCliente.TabIndex = 1;
            this.cbxFiltroCodCliente.SelectedIndexChanged += new System.EventHandler(this.cbxFiltroCodCliente_SelectedIndexChanged);
            this.cbxFiltroCodCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxFiltro_KeyDown);
            // 
            // lblFiltroNombreDeCliente
            // 
            this.lblFiltroNombreDeCliente.AutoSize = true;
            this.lblFiltroNombreDeCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltroNombreDeCliente.Location = new System.Drawing.Point(15, 46);
            this.lblFiltroNombreDeCliente.Name = "lblFiltroNombreDeCliente";
            this.lblFiltroNombreDeCliente.Size = new System.Drawing.Size(161, 15);
            this.lblFiltroNombreDeCliente.TabIndex = 102;
            this.lblFiltroNombreDeCliente.Text = "Filtro por Nombre de Cliente";
            // 
            // lblResultado
            // 
            this.lblResultado.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblResultado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblResultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultado.Location = new System.Drawing.Point(16, 202);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(1313, 25);
            this.lblResultado.TabIndex = 107;
            this.lblResultado.Text = "Resultado";
            this.lblResultado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFiltroCodCliente
            // 
            this.lblFiltroCodCliente.AutoSize = true;
            this.lblFiltroCodCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltroCodCliente.Location = new System.Drawing.Point(15, 17);
            this.lblFiltroCodCliente.Name = "lblFiltroCodCliente";
            this.lblFiltroCodCliente.Size = new System.Drawing.Size(124, 15);
            this.lblFiltroCodCliente.TabIndex = 101;
            this.lblFiltroCodCliente.Text = "Filtro por Cod. Cliente";
            // 
            // pnlIzquierda
            // 
            this.pnlIzquierda.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlIzquierda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlIzquierda.Controls.Add(this.btnReporte);
            this.pnlIzquierda.Controls.Add(this.txtFiltroNroDeOrden);
            this.pnlIzquierda.Controls.Add(this.lblOP_1);
            this.pnlIzquierda.Controls.Add(this.lblFiltroNroDeOrden);
            this.pnlIzquierda.Controls.Add(this.lblOP_2);
            this.pnlIzquierda.Controls.Add(this.lblOB_2);
            this.pnlIzquierda.Controls.Add(this.lblOB_1);
            this.pnlIzquierda.Controls.Add(this.cbxFiltroMedidaDeCubierta);
            this.pnlIzquierda.Controls.Add(this.lblFiltroMedidaDeCubierta);
            this.pnlIzquierda.Controls.Add(this.dtpFechaHasta);
            this.pnlIzquierda.Controls.Add(this.lblFiltroFechaHasta);
            this.pnlIzquierda.Controls.Add(this.dtpFechaDesde);
            this.pnlIzquierda.Controls.Add(this.lblFiltroFechaDesde);
            this.pnlIzquierda.Controls.Add(this.btnLimpiar);
            this.pnlIzquierda.Controls.Add(this.cbxFiltroNombreDeCliente);
            this.pnlIzquierda.Controls.Add(this.cbxFiltroCodCliente);
            this.pnlIzquierda.Controls.Add(this.lblFiltroNombreDeCliente);
            this.pnlIzquierda.Controls.Add(this.lblResultado);
            this.pnlIzquierda.Controls.Add(this.dgvHistoricoCubiertas);
            this.pnlIzquierda.Controls.Add(this.btnBuscar);
            this.pnlIzquierda.Controls.Add(this.lblFiltroCodCliente);
            this.pnlIzquierda.Location = new System.Drawing.Point(12, 12);
            this.pnlIzquierda.Name = "pnlIzquierda";
            this.pnlIzquierda.Size = new System.Drawing.Size(1346, 679);
            this.pnlIzquierda.TabIndex = 1;
            // 
            // btnReporte
            // 
            this.btnReporte.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporte.Location = new System.Drawing.Point(1215, 628);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(114, 39);
            this.btnReporte.TabIndex = 10;
            this.btnReporte.Text = "Reporte";
            this.btnReporte.UseVisualStyleBackColor = true;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // txtFiltroNroDeOrden
            // 
            this.txtFiltroNroDeOrden.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltroNroDeOrden.Location = new System.Drawing.Point(187, 72);
            this.txtFiltroNroDeOrden.MaxLength = 6;
            this.txtFiltroNroDeOrden.Name = "txtFiltroNroDeOrden";
            this.txtFiltroNroDeOrden.Size = new System.Drawing.Size(297, 21);
            this.txtFiltroNroDeOrden.TabIndex = 3;
            this.txtFiltroNroDeOrden.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxFiltro_KeyDown);
            this.txtFiltroNroDeOrden.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNroOrden_KeyPress);
            // 
            // lblOP_1
            // 
            this.lblOP_1.AutoSize = true;
            this.lblOP_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOP_1.Location = new System.Drawing.Point(490, 75);
            this.lblOP_1.Name = "lblOP_1";
            this.lblOP_1.Size = new System.Drawing.Size(38, 15);
            this.lblOP_1.TabIndex = 79;
            this.lblOP_1.Text = "( OP )";
            // 
            // lblFiltroNroDeOrden
            // 
            this.lblFiltroNroDeOrden.AutoSize = true;
            this.lblFiltroNroDeOrden.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltroNroDeOrden.Location = new System.Drawing.Point(15, 75);
            this.lblFiltroNroDeOrden.Name = "lblFiltroNroDeOrden";
            this.lblFiltroNroDeOrden.Size = new System.Drawing.Size(135, 15);
            this.lblFiltroNroDeOrden.TabIndex = 103;
            this.lblFiltroNroDeOrden.Text = "Filtro por Nro. de Orden";
            // 
            // lblOP_2
            // 
            this.lblOP_2.AutoSize = true;
            this.lblOP_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOP_2.Location = new System.Drawing.Point(490, 104);
            this.lblOP_2.Name = "lblOP_2";
            this.lblOP_2.Size = new System.Drawing.Size(38, 15);
            this.lblOP_2.TabIndex = 76;
            this.lblOP_2.Text = "( OP )";
            // 
            // lblOB_2
            // 
            this.lblOB_2.AutoSize = true;
            this.lblOB_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOB_2.Location = new System.Drawing.Point(490, 46);
            this.lblOB_2.Name = "lblOB_2";
            this.lblOB_2.Size = new System.Drawing.Size(38, 15);
            this.lblOB_2.TabIndex = 75;
            this.lblOB_2.Text = "( OB )";
            // 
            // lblOB_1
            // 
            this.lblOB_1.AutoSize = true;
            this.lblOB_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOB_1.Location = new System.Drawing.Point(490, 17);
            this.lblOB_1.Name = "lblOB_1";
            this.lblOB_1.Size = new System.Drawing.Size(38, 15);
            this.lblOB_1.TabIndex = 74;
            this.lblOB_1.Text = "( OB )";
            // 
            // cbxFiltroMedidaDeCubierta
            // 
            this.cbxFiltroMedidaDeCubierta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxFiltroMedidaDeCubierta.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxFiltroMedidaDeCubierta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxFiltroMedidaDeCubierta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxFiltroMedidaDeCubierta.FormattingEnabled = true;
            this.cbxFiltroMedidaDeCubierta.Location = new System.Drawing.Point(187, 98);
            this.cbxFiltroMedidaDeCubierta.Name = "cbxFiltroMedidaDeCubierta";
            this.cbxFiltroMedidaDeCubierta.Size = new System.Drawing.Size(297, 23);
            this.cbxFiltroMedidaDeCubierta.TabIndex = 4;
            this.cbxFiltroMedidaDeCubierta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxFiltro_KeyDown);
            // 
            // lblFiltroMedidaDeCubierta
            // 
            this.lblFiltroMedidaDeCubierta.AutoSize = true;
            this.lblFiltroMedidaDeCubierta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltroMedidaDeCubierta.Location = new System.Drawing.Point(15, 104);
            this.lblFiltroMedidaDeCubierta.Name = "lblFiltroMedidaDeCubierta";
            this.lblFiltroMedidaDeCubierta.Size = new System.Drawing.Size(166, 15);
            this.lblFiltroMedidaDeCubierta.TabIndex = 104;
            this.lblFiltroMedidaDeCubierta.Text = "Filtro por Medida de Cubierta";
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaHasta.Location = new System.Drawing.Point(187, 154);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(297, 21);
            this.dtpFechaHasta.TabIndex = 6;
            // 
            // lblFiltroFechaHasta
            // 
            this.lblFiltroFechaHasta.AutoSize = true;
            this.lblFiltroFechaHasta.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblFiltroFechaHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltroFechaHasta.Location = new System.Drawing.Point(15, 159);
            this.lblFiltroFechaHasta.Name = "lblFiltroFechaHasta";
            this.lblFiltroFechaHasta.Size = new System.Drawing.Size(127, 15);
            this.lblFiltroFechaHasta.TabIndex = 106;
            this.lblFiltroFechaHasta.Text = "Filtro por Fecha Hasta";
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaDesde.Location = new System.Drawing.Point(187, 127);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(297, 21);
            this.dtpFechaDesde.TabIndex = 5;
            // 
            // lblFiltroFechaDesde
            // 
            this.lblFiltroFechaDesde.AutoSize = true;
            this.lblFiltroFechaDesde.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblFiltroFechaDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltroFechaDesde.Location = new System.Drawing.Point(15, 132);
            this.lblFiltroFechaDesde.Name = "lblFiltroFechaDesde";
            this.lblFiltroFechaDesde.Size = new System.Drawing.Size(131, 15);
            this.lblFiltroFechaDesde.TabIndex = 105;
            this.lblFiltroFechaDesde.Text = "Filtro por Fecha Desde";
            // 
            // dgvHistoricoCubiertas
            // 
            this.dgvHistoricoCubiertas.AllowUserToAddRows = false;
            this.dgvHistoricoCubiertas.AllowUserToDeleteRows = false;
            this.dgvHistoricoCubiertas.AllowUserToResizeColumns = false;
            this.dgvHistoricoCubiertas.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHistoricoCubiertas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHistoricoCubiertas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHistoricoCubiertas.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHistoricoCubiertas.Location = new System.Drawing.Point(16, 230);
            this.dgvHistoricoCubiertas.MultiSelect = false;
            this.dgvHistoricoCubiertas.Name = "dgvHistoricoCubiertas";
            this.dgvHistoricoCubiertas.ReadOnly = true;
            this.dgvHistoricoCubiertas.RowHeadersVisible = false;
            this.dgvHistoricoCubiertas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvHistoricoCubiertas.Size = new System.Drawing.Size(1313, 389);
            this.dgvHistoricoCubiertas.TabIndex = 9;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(573, 54);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(96, 35);
            this.btnBuscar.TabIndex = 7;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // frmHistoricoCubiertas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 730);
            this.Controls.Add(this.pnlIzquierda);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmHistoricoCubiertas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Histórico de Cubiertas";
            this.Load += new System.EventHandler(this.frmHistoricoCubiertas_Load);
            this.pnlIzquierda.ResumeLayout(false);
            this.pnlIzquierda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistoricoCubiertas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.ComboBox cbxFiltroNombreDeCliente;
        private System.Windows.Forms.ComboBox cbxFiltroCodCliente;
        private System.Windows.Forms.Label lblFiltroNombreDeCliente;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.Label lblFiltroCodCliente;
        private System.Windows.Forms.Panel pnlIzquierda;
        private System.Windows.Forms.DataGridView dgvHistoricoCubiertas;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.Label lblFiltroFechaHasta;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.Label lblFiltroFechaDesde;
        private System.Windows.Forms.ComboBox cbxFiltroMedidaDeCubierta;
        private System.Windows.Forms.Label lblFiltroMedidaDeCubierta;
        private System.Windows.Forms.Label lblOP_2;
        private System.Windows.Forms.Label lblOB_2;
        private System.Windows.Forms.Label lblOB_1;
        private System.Windows.Forms.Label lblOP_1;
        private System.Windows.Forms.Label lblFiltroNroDeOrden;
        private System.Windows.Forms.TextBox txtFiltroNroDeOrden;
        private System.Windows.Forms.Button btnReporte;

    }
}