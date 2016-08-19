namespace OFC
{
    partial class frmVerResumenDeCuentaProv
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
            this.crvResumenDeCuentaProv = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvResumenDeCuentaProv
            // 
            this.crvResumenDeCuentaProv.ActiveViewIndex = -1;
            this.crvResumenDeCuentaProv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvResumenDeCuentaProv.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvResumenDeCuentaProv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvResumenDeCuentaProv.Location = new System.Drawing.Point(0, 0);
            this.crvResumenDeCuentaProv.Name = "crvResumenDeCuentaProv";
            this.crvResumenDeCuentaProv.Size = new System.Drawing.Size(1366, 730);
            this.crvResumenDeCuentaProv.TabIndex = 1;
            this.crvResumenDeCuentaProv.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmVerResumenDeCuentaProv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 730);
            this.Controls.Add(this.crvResumenDeCuentaProv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmVerResumenDeCuentaProv";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resumen de Cuenta";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmVerResumenDeCuentaProv_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvResumenDeCuentaProv;
    }
}