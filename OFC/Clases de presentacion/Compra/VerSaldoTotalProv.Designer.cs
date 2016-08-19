namespace OFC
{
    partial class frmVerSaldoTotalProv
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
            this.crvSaldoTotalProv = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvSaldoTotalProv
            // 
            this.crvSaldoTotalProv.ActiveViewIndex = -1;
            this.crvSaldoTotalProv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvSaldoTotalProv.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvSaldoTotalProv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvSaldoTotalProv.Location = new System.Drawing.Point(0, 0);
            this.crvSaldoTotalProv.Name = "crvSaldoTotalProv";
            this.crvSaldoTotalProv.Size = new System.Drawing.Size(1026, 730);
            this.crvSaldoTotalProv.TabIndex = 1;
            this.crvSaldoTotalProv.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmVerSaldoTotalProv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 730);
            this.Controls.Add(this.crvSaldoTotalProv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmVerSaldoTotalProv";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Saldos Totales";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmVerSaldoTotalProv_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvSaldoTotalProv;
    }
}