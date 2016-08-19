namespace OFC
{
    partial class frmLibroIvaCompras
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
            this.btnAceptar = new System.Windows.Forms.Button();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.lblFiltroFechaHasta = new System.Windows.Forms.Label();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.lblFiltroFechaDesde = new System.Windows.Forms.Label();
            this.btnDescargarCompleto = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(192, 71);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(131, 36);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaHasta.Location = new System.Drawing.Point(100, 39);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(222, 21);
            this.dtpFechaHasta.TabIndex = 3;
            // 
            // lblFiltroFechaHasta
            // 
            this.lblFiltroFechaHasta.AutoSize = true;
            this.lblFiltroFechaHasta.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblFiltroFechaHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltroFechaHasta.Location = new System.Drawing.Point(14, 44);
            this.lblFiltroFechaHasta.Name = "lblFiltroFechaHasta";
            this.lblFiltroFechaHasta.Size = new System.Drawing.Size(76, 15);
            this.lblFiltroFechaHasta.TabIndex = 107;
            this.lblFiltroFechaHasta.Text = "Fecha Hasta";
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaDesde.Location = new System.Drawing.Point(100, 12);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(222, 21);
            this.dtpFechaDesde.TabIndex = 2;
            // 
            // lblFiltroFechaDesde
            // 
            this.lblFiltroFechaDesde.AutoSize = true;
            this.lblFiltroFechaDesde.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblFiltroFechaDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltroFechaDesde.Location = new System.Drawing.Point(14, 17);
            this.lblFiltroFechaDesde.Name = "lblFiltroFechaDesde";
            this.lblFiltroFechaDesde.Size = new System.Drawing.Size(80, 15);
            this.lblFiltroFechaDesde.TabIndex = 106;
            this.lblFiltroFechaDesde.Text = "Fecha Desde";
            // 
            // btnDescargarCompleto
            // 
            this.btnDescargarCompleto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDescargarCompleto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDescargarCompleto.Location = new System.Drawing.Point(12, 71);
            this.btnDescargarCompleto.Name = "btnDescargarCompleto";
            this.btnDescargarCompleto.Size = new System.Drawing.Size(131, 36);
            this.btnDescargarCompleto.TabIndex = 108;
            this.btnDescargarCompleto.Text = "Descargar Completo";
            this.btnDescargarCompleto.UseVisualStyleBackColor = true;
            this.btnDescargarCompleto.Click += new System.EventHandler(this.btnDescargarCompleto_Click);
            // 
            // frmLibroIvaCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(335, 119);
            this.Controls.Add(this.btnDescargarCompleto);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.dtpFechaHasta);
            this.Controls.Add(this.lblFiltroFechaHasta);
            this.Controls.Add(this.dtpFechaDesde);
            this.Controls.Add(this.lblFiltroFechaDesde);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmLibroIvaCompras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Libro Iva Compras";
            this.Load += new System.EventHandler(this.frmLibroIvaCompras_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.Label lblFiltroFechaHasta;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.Label lblFiltroFechaDesde;
        private System.Windows.Forms.Button btnDescargarCompleto;
    }
}