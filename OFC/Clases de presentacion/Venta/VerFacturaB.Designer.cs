namespace OFC
{
    partial class frmVerFacturaB
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
            this.crvFacturaB = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvFacturaB
            // 
            this.crvFacturaB.ActiveViewIndex = -1;
            this.crvFacturaB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvFacturaB.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvFacturaB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvFacturaB.Location = new System.Drawing.Point(0, 0);
            this.crvFacturaB.Name = "crvFacturaB";
            this.crvFacturaB.Size = new System.Drawing.Size(1026, 730);
            this.crvFacturaB.TabIndex = 0;
            this.crvFacturaB.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmVerFacturaB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 730);
            this.Controls.Add(this.crvFacturaB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmVerFacturaB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comprobante Digital";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmVerFacturaB_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvFacturaB;
    }
}