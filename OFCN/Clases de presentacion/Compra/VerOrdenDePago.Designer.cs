namespace OFC
{
    partial class frmVerOrdenDePago
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
            this.crvOrdenDePago = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvOrdenDePago
            // 
            this.crvOrdenDePago.ActiveViewIndex = -1;
            this.crvOrdenDePago.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvOrdenDePago.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvOrdenDePago.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvOrdenDePago.Location = new System.Drawing.Point(0, 0);
            this.crvOrdenDePago.Name = "crvOrdenDePago";
            this.crvOrdenDePago.Size = new System.Drawing.Size(1020, 724);
            this.crvOrdenDePago.TabIndex = 2;
            this.crvOrdenDePago.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmVerOrdenDePago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 724);
            this.Controls.Add(this.crvOrdenDePago);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmVerOrdenDePago";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Orden de Pago";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmVerOrdenDePago_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvOrdenDePago;
    }
}