namespace OFC
{
    partial class frmVerRemito
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
            this.crvRemito = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvRemito
            // 
            this.crvRemito.ActiveViewIndex = -1;
            this.crvRemito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvRemito.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvRemito.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvRemito.Location = new System.Drawing.Point(0, 0);
            this.crvRemito.Name = "crvRemito";
            this.crvRemito.Size = new System.Drawing.Size(1026, 730);
            this.crvRemito.TabIndex = 0;
            this.crvRemito.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmVerRemito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 730);
            this.Controls.Add(this.crvRemito);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmVerRemito";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comprobante Digital";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmVerRemito_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvRemito;
    }
}