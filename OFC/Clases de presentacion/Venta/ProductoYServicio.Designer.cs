namespace OFC
{
    partial class frmABMProductosYServicios
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
            this.pnlDerecha = new System.Windows.Forms.Panel();
            this.cbhVigenteServicio = new System.Windows.Forms.CheckBox();
            this.cbxFiltroDescripcionServicio = new System.Windows.Forms.ComboBox();
            this.lblConsultaDeServicios = new System.Windows.Forms.Label();
            this.txtDescripcionServicio = new System.Windows.Forms.TextBox();
            this.cbhEsAdicional = new System.Windows.Forms.CheckBox();
            this.btnBorrarServicio = new System.Windows.Forms.Button();
            this.btnNuevoServicio = new System.Windows.Forms.Button();
            this.btnGuardarServicio = new System.Windows.Forms.Button();
            this.lblDescripcionServicio = new System.Windows.Forms.Label();
            this.btnFiltrarServicio = new System.Windows.Forms.Button();
            this.lblFiltroDescripcionServicio = new System.Windows.Forms.Label();
            this.lblResultadoServicios = new System.Windows.Forms.Label();
            this.dgvServicios = new System.Windows.Forms.DataGridView();
            this.pnlDerecha.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicios)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDerecha
            // 
            this.pnlDerecha.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlDerecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDerecha.Controls.Add(this.cbhVigenteServicio);
            this.pnlDerecha.Controls.Add(this.cbxFiltroDescripcionServicio);
            this.pnlDerecha.Controls.Add(this.lblConsultaDeServicios);
            this.pnlDerecha.Controls.Add(this.txtDescripcionServicio);
            this.pnlDerecha.Controls.Add(this.cbhEsAdicional);
            this.pnlDerecha.Controls.Add(this.btnBorrarServicio);
            this.pnlDerecha.Controls.Add(this.btnNuevoServicio);
            this.pnlDerecha.Controls.Add(this.btnGuardarServicio);
            this.pnlDerecha.Controls.Add(this.lblDescripcionServicio);
            this.pnlDerecha.Controls.Add(this.btnFiltrarServicio);
            this.pnlDerecha.Controls.Add(this.lblFiltroDescripcionServicio);
            this.pnlDerecha.Controls.Add(this.lblResultadoServicios);
            this.pnlDerecha.Controls.Add(this.dgvServicios);
            this.pnlDerecha.Location = new System.Drawing.Point(12, 12);
            this.pnlDerecha.Name = "pnlDerecha";
            this.pnlDerecha.Size = new System.Drawing.Size(653, 678);
            this.pnlDerecha.TabIndex = 2;
            // 
            // cbhVigenteServicio
            // 
            this.cbhVigenteServicio.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbhVigenteServicio.Checked = true;
            this.cbhVigenteServicio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbhVigenteServicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbhVigenteServicio.Location = new System.Drawing.Point(12, 630);
            this.cbhVigenteServicio.Name = "cbhVigenteServicio";
            this.cbhVigenteServicio.Size = new System.Drawing.Size(136, 24);
            this.cbhVigenteServicio.TabIndex = 17;
            this.cbhVigenteServicio.Text = "Vigente";
            this.cbhVigenteServicio.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.cbhVigenteServicio.UseVisualStyleBackColor = true;
            // 
            // cbxFiltroDescripcionServicio
            // 
            this.cbxFiltroDescripcionServicio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxFiltroDescripcionServicio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxFiltroDescripcionServicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxFiltroDescripcionServicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxFiltroDescripcionServicio.FormattingEnabled = true;
            this.cbxFiltroDescripcionServicio.Location = new System.Drawing.Point(168, 52);
            this.cbxFiltroDescripcionServicio.Name = "cbxFiltroDescripcionServicio";
            this.cbxFiltroDescripcionServicio.Size = new System.Drawing.Size(309, 23);
            this.cbxFiltroDescripcionServicio.TabIndex = 12;
            this.cbxFiltroDescripcionServicio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxFiltroServicio_KeyDown);
            // 
            // lblConsultaDeServicios
            // 
            this.lblConsultaDeServicios.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblConsultaDeServicios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblConsultaDeServicios.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsultaDeServicios.Location = new System.Drawing.Point(16, 11);
            this.lblConsultaDeServicios.Name = "lblConsultaDeServicios";
            this.lblConsultaDeServicios.Size = new System.Drawing.Size(618, 25);
            this.lblConsultaDeServicios.TabIndex = 58;
            this.lblConsultaDeServicios.Text = "Consulta de Trabajos y Servicios Adicionales";
            this.lblConsultaDeServicios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDescripcionServicio
            // 
            this.txtDescripcionServicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcionServicio.Location = new System.Drawing.Point(134, 577);
            this.txtDescripcionServicio.MaxLength = 10;
            this.txtDescripcionServicio.Name = "txtDescripcionServicio";
            this.txtDescripcionServicio.Size = new System.Drawing.Size(343, 21);
            this.txtDescripcionServicio.TabIndex = 15;
            // 
            // cbhEsAdicional
            // 
            this.cbhEsAdicional.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbhEsAdicional.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbhEsAdicional.Location = new System.Drawing.Point(12, 605);
            this.cbhEsAdicional.Name = "cbhEsAdicional";
            this.cbhEsAdicional.Size = new System.Drawing.Size(136, 24);
            this.cbhEsAdicional.TabIndex = 16;
            this.cbhEsAdicional.Text = "Es Adicional";
            this.cbhEsAdicional.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.cbhEsAdicional.UseVisualStyleBackColor = true;
            // 
            // btnBorrarServicio
            // 
            this.btnBorrarServicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBorrarServicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrarServicio.Location = new System.Drawing.Point(520, 624);
            this.btnBorrarServicio.Name = "btnBorrarServicio";
            this.btnBorrarServicio.Size = new System.Drawing.Size(114, 30);
            this.btnBorrarServicio.TabIndex = 20;
            this.btnBorrarServicio.Text = "Borrar";
            this.btnBorrarServicio.UseVisualStyleBackColor = true;
            this.btnBorrarServicio.Click += new System.EventHandler(this.btnBorrarServicio_Click);
            // 
            // btnNuevoServicio
            // 
            this.btnNuevoServicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevoServicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoServicio.Location = new System.Drawing.Point(520, 553);
            this.btnNuevoServicio.Name = "btnNuevoServicio";
            this.btnNuevoServicio.Size = new System.Drawing.Size(114, 30);
            this.btnNuevoServicio.TabIndex = 18;
            this.btnNuevoServicio.Text = "Nuevo";
            this.btnNuevoServicio.UseVisualStyleBackColor = true;
            this.btnNuevoServicio.Click += new System.EventHandler(this.btnNuevoServicio_Click);
            // 
            // btnGuardarServicio
            // 
            this.btnGuardarServicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarServicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarServicio.Location = new System.Drawing.Point(520, 588);
            this.btnGuardarServicio.Name = "btnGuardarServicio";
            this.btnGuardarServicio.Size = new System.Drawing.Size(114, 30);
            this.btnGuardarServicio.TabIndex = 19;
            this.btnGuardarServicio.Text = "Guardar";
            this.btnGuardarServicio.UseVisualStyleBackColor = true;
            this.btnGuardarServicio.Click += new System.EventHandler(this.btnGuardarServicio_Click);
            // 
            // lblDescripcionServicio
            // 
            this.lblDescripcionServicio.AutoSize = true;
            this.lblDescripcionServicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcionServicio.Location = new System.Drawing.Point(13, 580);
            this.lblDescripcionServicio.Name = "lblDescripcionServicio";
            this.lblDescripcionServicio.Size = new System.Drawing.Size(72, 15);
            this.lblDescripcionServicio.TabIndex = 23;
            this.lblDescripcionServicio.Text = "Descripción";
            // 
            // btnFiltrarServicio
            // 
            this.btnFiltrarServicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrarServicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrarServicio.Location = new System.Drawing.Point(520, 47);
            this.btnFiltrarServicio.Name = "btnFiltrarServicio";
            this.btnFiltrarServicio.Size = new System.Drawing.Size(114, 30);
            this.btnFiltrarServicio.TabIndex = 13;
            this.btnFiltrarServicio.Text = "Filtrar";
            this.btnFiltrarServicio.UseVisualStyleBackColor = true;
            this.btnFiltrarServicio.Click += new System.EventHandler(this.btnFiltrarServicio_Click);
            // 
            // lblFiltroDescripcionServicio
            // 
            this.lblFiltroDescripcionServicio.AutoSize = true;
            this.lblFiltroDescripcionServicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltroDescripcionServicio.Location = new System.Drawing.Point(13, 55);
            this.lblFiltroDescripcionServicio.Name = "lblFiltroDescripcionServicio";
            this.lblFiltroDescripcionServicio.Size = new System.Drawing.Size(123, 15);
            this.lblFiltroDescripcionServicio.TabIndex = 14;
            this.lblFiltroDescripcionServicio.Text = "Filtro por Descripción";
            // 
            // lblResultadoServicios
            // 
            this.lblResultadoServicios.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblResultadoServicios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblResultadoServicios.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultadoServicios.Location = new System.Drawing.Point(16, 97);
            this.lblResultadoServicios.Name = "lblResultadoServicios";
            this.lblResultadoServicios.Size = new System.Drawing.Size(618, 25);
            this.lblResultadoServicios.TabIndex = 8;
            this.lblResultadoServicios.Text = "Resultado";
            this.lblResultadoServicios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvServicios
            // 
            this.dgvServicios.AllowUserToAddRows = false;
            this.dgvServicios.AllowUserToDeleteRows = false;
            this.dgvServicios.AllowUserToResizeColumns = false;
            this.dgvServicios.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvServicios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvServicios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvServicios.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvServicios.Location = new System.Drawing.Point(16, 125);
            this.dgvServicios.MultiSelect = false;
            this.dgvServicios.Name = "dgvServicios";
            this.dgvServicios.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvServicios.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvServicios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvServicios.Size = new System.Drawing.Size(618, 403);
            this.dgvServicios.TabIndex = 14;
            this.dgvServicios.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvServicios_CellContentClick);
            // 
            // frmABMProductosYServicios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 730);
            this.Controls.Add(this.pnlDerecha);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmABMProductosYServicios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trabajos y Servicios";
            this.Load += new System.EventHandler(this.frmABMProductosYServicios_Load);
            this.pnlDerecha.ResumeLayout(false);
            this.pnlDerecha.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDerecha;
        private System.Windows.Forms.Label lblConsultaDeServicios;
        private System.Windows.Forms.TextBox txtDescripcionServicio;
        private System.Windows.Forms.CheckBox cbhEsAdicional;
        private System.Windows.Forms.Button btnBorrarServicio;
        private System.Windows.Forms.Button btnGuardarServicio;
        private System.Windows.Forms.Label lblDescripcionServicio;
        private System.Windows.Forms.Button btnFiltrarServicio;
        private System.Windows.Forms.Label lblFiltroDescripcionServicio;
        private System.Windows.Forms.Label lblResultadoServicios;
        private System.Windows.Forms.DataGridView dgvServicios;
        private System.Windows.Forms.ComboBox cbxFiltroDescripcionServicio;
        private System.Windows.Forms.CheckBox cbhVigenteServicio;
        private System.Windows.Forms.Button btnNuevoServicio;
    }
}