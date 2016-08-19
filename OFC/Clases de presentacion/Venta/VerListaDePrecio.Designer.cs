namespace OFC
{
    partial class frmReporteListaDePrecio
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
            this.crvListaDePrecio = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvListaDePrecio
            // 
            this.crvListaDePrecio.ActiveViewIndex = -1;
            this.crvListaDePrecio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvListaDePrecio.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvListaDePrecio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvListaDePrecio.Location = new System.Drawing.Point(0, 0);
            this.crvListaDePrecio.Name = "crvListaDePrecio";
            this.crvListaDePrecio.Size = new System.Drawing.Size(1026, 730);
            this.crvListaDePrecio.TabIndex = 0;
            this.crvListaDePrecio.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmReporteListaDePrecio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 730);
            this.Controls.Add(this.crvListaDePrecio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmReporteListaDePrecio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de Precio";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmVerListaDePrecio_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvListaDePrecio;

    }
}