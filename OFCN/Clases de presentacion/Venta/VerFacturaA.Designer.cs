namespace OFC
{
    partial class frmVerFacturaA
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
            this.crvFacturaA = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvFacturaA
            // 
            this.crvFacturaA.ActiveViewIndex = -1;
            this.crvFacturaA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvFacturaA.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvFacturaA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvFacturaA.Location = new System.Drawing.Point(0, 0);
            this.crvFacturaA.Name = "crvFacturaA";
            this.crvFacturaA.Size = new System.Drawing.Size(1026, 730);
            this.crvFacturaA.TabIndex = 0;
            this.crvFacturaA.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmVerFacturaA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 730);
            this.Controls.Add(this.crvFacturaA);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmVerFacturaA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comprobante Digital";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmVerFacturaA_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvFacturaA;
    }
}