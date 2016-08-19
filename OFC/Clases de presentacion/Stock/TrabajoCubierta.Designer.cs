namespace OFC
{
    partial class frmTrabajoCubierta
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
            this.pnlIzquierda = new System.Windows.Forms.Panel();
            this.btnReporte = new System.Windows.Forms.Button();
            this.btnLimpiarGrilla = new System.Windows.Forms.Button();
            this.cbxFiltroMedidaDeCubierta = new System.Windows.Forms.ComboBox();
            this.cbxFiltroTrabajo = new System.Windows.Forms.ComboBox();
            this.lblFiltroMedidaDeCubierta = new System.Windows.Forms.Label();
            this.lblResultado = new System.Windows.Forms.Label();
            this.dgvTrabajoCubiertas = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblFiltroTrabajo = new System.Windows.Forms.Label();
            this.pnlIzquierda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrabajoCubiertas)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlIzquierda
            // 
            this.pnlIzquierda.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlIzquierda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlIzquierda.Controls.Add(this.btnReporte);
            this.pnlIzquierda.Controls.Add(this.btnLimpiarGrilla);
            this.pnlIzquierda.Controls.Add(this.cbxFiltroMedidaDeCubierta);
            this.pnlIzquierda.Controls.Add(this.cbxFiltroTrabajo);
            this.pnlIzquierda.Controls.Add(this.lblFiltroMedidaDeCubierta);
            this.pnlIzquierda.Controls.Add(this.lblResultado);
            this.pnlIzquierda.Controls.Add(this.dgvTrabajoCubiertas);
            this.pnlIzquierda.Controls.Add(this.btnBuscar);
            this.pnlIzquierda.Controls.Add(this.lblFiltroTrabajo);
            this.pnlIzquierda.Location = new System.Drawing.Point(12, 12);
            this.pnlIzquierda.Name = "pnlIzquierda";
            this.pnlIzquierda.Size = new System.Drawing.Size(1346, 679);
            this.pnlIzquierda.TabIndex = 1;
            // 
            // btnReporte
            // 
            this.btnReporte.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporte.Location = new System.Drawing.Point(1185, 630);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(144, 35);
            this.btnReporte.TabIndex = 7;
            this.btnReporte.Text = "Reporte";
            this.btnReporte.UseVisualStyleBackColor = true;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // btnLimpiarGrilla
            // 
            this.btnLimpiarGrilla.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiarGrilla.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarGrilla.Location = new System.Drawing.Point(628, 26);
            this.btnLimpiarGrilla.Name = "btnLimpiarGrilla";
            this.btnLimpiarGrilla.Size = new System.Drawing.Size(96, 35);
            this.btnLimpiarGrilla.TabIndex = 4;
            this.btnLimpiarGrilla.Text = "Limpiar";
            this.btnLimpiarGrilla.UseVisualStyleBackColor = true;
            this.btnLimpiarGrilla.Click += new System.EventHandler(this.btnLimpiarGrilla_Click);
            // 
            // cbxFiltroMedidaDeCubierta
            // 
            this.cbxFiltroMedidaDeCubierta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxFiltroMedidaDeCubierta.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxFiltroMedidaDeCubierta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxFiltroMedidaDeCubierta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxFiltroMedidaDeCubierta.FormattingEnabled = true;
            this.cbxFiltroMedidaDeCubierta.Location = new System.Drawing.Point(187, 46);
            this.cbxFiltroMedidaDeCubierta.Name = "cbxFiltroMedidaDeCubierta";
            this.cbxFiltroMedidaDeCubierta.Size = new System.Drawing.Size(297, 23);
            this.cbxFiltroMedidaDeCubierta.TabIndex = 2;
            this.cbxFiltroMedidaDeCubierta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxFiltro_KeyDown);
            // 
            // cbxFiltroTrabajo
            // 
            this.cbxFiltroTrabajo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxFiltroTrabajo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxFiltroTrabajo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxFiltroTrabajo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxFiltroTrabajo.FormattingEnabled = true;
            this.cbxFiltroTrabajo.Location = new System.Drawing.Point(187, 17);
            this.cbxFiltroTrabajo.Name = "cbxFiltroTrabajo";
            this.cbxFiltroTrabajo.Size = new System.Drawing.Size(297, 23);
            this.cbxFiltroTrabajo.TabIndex = 1;
            this.cbxFiltroTrabajo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxFiltro_KeyDown);
            // 
            // lblFiltroMedidaDeCubierta
            // 
            this.lblFiltroMedidaDeCubierta.AutoSize = true;
            this.lblFiltroMedidaDeCubierta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltroMedidaDeCubierta.Location = new System.Drawing.Point(15, 49);
            this.lblFiltroMedidaDeCubierta.Name = "lblFiltroMedidaDeCubierta";
            this.lblFiltroMedidaDeCubierta.Size = new System.Drawing.Size(166, 15);
            this.lblFiltroMedidaDeCubierta.TabIndex = 10;
            this.lblFiltroMedidaDeCubierta.Text = "Filtro por Medida de Cubierta";
            // 
            // lblResultado
            // 
            this.lblResultado.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblResultado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblResultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultado.Location = new System.Drawing.Point(16, 83);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(1313, 25);
            this.lblResultado.TabIndex = 8;
            this.lblResultado.Text = "Resultado";
            this.lblResultado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvTrabajoCubiertas
            // 
            this.dgvTrabajoCubiertas.AllowUserToAddRows = false;
            this.dgvTrabajoCubiertas.AllowUserToDeleteRows = false;
            this.dgvTrabajoCubiertas.AllowUserToResizeColumns = false;
            this.dgvTrabajoCubiertas.AllowUserToResizeRows = false;
            this.dgvTrabajoCubiertas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrabajoCubiertas.Location = new System.Drawing.Point(16, 111);
            this.dgvTrabajoCubiertas.MultiSelect = false;
            this.dgvTrabajoCubiertas.Name = "dgvTrabajoCubiertas";
            this.dgvTrabajoCubiertas.ReadOnly = true;
            this.dgvTrabajoCubiertas.RowHeadersVisible = false;
            this.dgvTrabajoCubiertas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTrabajoCubiertas.Size = new System.Drawing.Size(1313, 506);
            this.dgvTrabajoCubiertas.TabIndex = 6;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(526, 26);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(96, 35);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblFiltroTrabajo
            // 
            this.lblFiltroTrabajo.AutoSize = true;
            this.lblFiltroTrabajo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltroTrabajo.Location = new System.Drawing.Point(15, 20);
            this.lblFiltroTrabajo.Name = "lblFiltroTrabajo";
            this.lblFiltroTrabajo.Size = new System.Drawing.Size(100, 15);
            this.lblFiltroTrabajo.TabIndex = 3;
            this.lblFiltroTrabajo.Text = "Filtro por Trabajo";
            // 
            // frmTrabajoCubierta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 730);
            this.Controls.Add(this.pnlIzquierda);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmTrabajoCubierta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trabajos y Neumáticos en Planta";
            this.Load += new System.EventHandler(this.frmTrabajoCubierta_Load);
            this.pnlIzquierda.ResumeLayout(false);
            this.pnlIzquierda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrabajoCubiertas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlIzquierda;
        private System.Windows.Forms.Button btnReporte;
        private System.Windows.Forms.Button btnLimpiarGrilla;
        private System.Windows.Forms.ComboBox cbxFiltroMedidaDeCubierta;
        private System.Windows.Forms.ComboBox cbxFiltroTrabajo;
        private System.Windows.Forms.Label lblFiltroMedidaDeCubierta;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.DataGridView dgvTrabajoCubiertas;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblFiltroTrabajo;
    }
}