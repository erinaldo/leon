namespace OFC
{
    partial class frmVerResumenDeCuenta
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
            this.crvResumenDeCuenta = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvResumenDeCuenta
            // 
            this.crvResumenDeCuenta.ActiveViewIndex = -1;
            this.crvResumenDeCuenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvResumenDeCuenta.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvResumenDeCuenta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvResumenDeCuenta.Location = new System.Drawing.Point(0, 0);
            this.crvResumenDeCuenta.Name = "crvResumenDeCuenta";
            this.crvResumenDeCuenta.Size = new System.Drawing.Size(1366, 730);
            this.crvResumenDeCuenta.TabIndex = 0;
            this.crvResumenDeCuenta.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmVerResumenDeCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 730);
            this.Controls.Add(this.crvResumenDeCuenta);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmVerResumenDeCuenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resumen de Cuenta";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmVerResumenDeCuenta_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvResumenDeCuenta;

    }
}