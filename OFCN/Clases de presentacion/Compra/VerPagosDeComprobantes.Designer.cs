namespace OFC
{
    partial class frmVerFacturasDeCompraImpagas
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
            this.crvFacturasDeCompraImpagas = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvFacturasDeCompraImpagas
            // 
            this.crvFacturasDeCompraImpagas.ActiveViewIndex = -1;
            this.crvFacturasDeCompraImpagas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvFacturasDeCompraImpagas.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvFacturasDeCompraImpagas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvFacturasDeCompraImpagas.Location = new System.Drawing.Point(0, 0);
            this.crvFacturasDeCompraImpagas.Name = "crvFacturasDeCompraImpagas";
            this.crvFacturasDeCompraImpagas.Size = new System.Drawing.Size(1366, 730);
            this.crvFacturasDeCompraImpagas.TabIndex = 1;
            this.crvFacturasDeCompraImpagas.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmVerFacturasDeCompraImpagas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 730);
            this.Controls.Add(this.crvFacturasDeCompraImpagas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmVerFacturasDeCompraImpagas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facturas de Compra Impagas / Pago Parcial";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmVerFacturasDeCompraImpagas_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvFacturasDeCompraImpagas;
    }
}