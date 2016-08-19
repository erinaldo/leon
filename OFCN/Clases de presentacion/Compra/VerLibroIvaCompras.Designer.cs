namespace OFC
{
    partial class frmVerLibroIvaCompras
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
            this.crvLibroIvaCompras = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvLibroIvaCompras
            // 
            this.crvLibroIvaCompras.ActiveViewIndex = -1;
            this.crvLibroIvaCompras.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvLibroIvaCompras.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvLibroIvaCompras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvLibroIvaCompras.Location = new System.Drawing.Point(0, 0);
            this.crvLibroIvaCompras.Name = "crvLibroIvaCompras";
            this.crvLibroIvaCompras.Size = new System.Drawing.Size(1026, 730);
            this.crvLibroIvaCompras.TabIndex = 1;
            this.crvLibroIvaCompras.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmVerLibroIvaCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 730);
            this.Controls.Add(this.crvLibroIvaCompras);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmVerLibroIvaCompras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Libro Iva Compras";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.VerLibroIvaCompras_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvLibroIvaCompras;
    }
}