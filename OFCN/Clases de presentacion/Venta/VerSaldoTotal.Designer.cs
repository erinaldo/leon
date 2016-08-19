namespace OFC
{
    partial class frmVerSaldoTotal
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
            this.crvSaldoTotal = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvSaldoTotal
            // 
            this.crvSaldoTotal.ActiveViewIndex = -1;
            this.crvSaldoTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvSaldoTotal.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvSaldoTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvSaldoTotal.Location = new System.Drawing.Point(0, 0);
            this.crvSaldoTotal.Name = "crvSaldoTotal";
            this.crvSaldoTotal.Size = new System.Drawing.Size(1026, 730);
            this.crvSaldoTotal.TabIndex = 0;
            this.crvSaldoTotal.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmVerSaldoTotal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 730);
            this.Controls.Add(this.crvSaldoTotal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmVerSaldoTotal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Saldos Totales";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmVerSaldoTotal_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvSaldoTotal;
    }
}