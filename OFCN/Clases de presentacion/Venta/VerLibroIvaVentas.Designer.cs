namespace OFC
{
    partial class frmVerLibroIvaVentas
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
            this.crvLibroIvaVentas = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvLibroIvaVentas
            // 
            this.crvLibroIvaVentas.ActiveViewIndex = -1;
            this.crvLibroIvaVentas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvLibroIvaVentas.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvLibroIvaVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvLibroIvaVentas.Location = new System.Drawing.Point(0, 0);
            this.crvLibroIvaVentas.Name = "crvLibroIvaVentas";
            this.crvLibroIvaVentas.Size = new System.Drawing.Size(1026, 730);
            this.crvLibroIvaVentas.TabIndex = 0;
            this.crvLibroIvaVentas.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmVerLibroIvaVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 730);
            this.Controls.Add(this.crvLibroIvaVentas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmVerLibroIvaVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Libro Iva Ventas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmVerLibroIvaVentas_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvLibroIvaVentas;
    }
}