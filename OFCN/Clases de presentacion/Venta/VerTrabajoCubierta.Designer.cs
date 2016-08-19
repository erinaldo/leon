namespace OFC
{
    partial class frmVerTrabajoCubierta
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
            this.crvTrabajoCubierta = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvTrabajoCubierta
            // 
            this.crvTrabajoCubierta.ActiveViewIndex = -1;
            this.crvTrabajoCubierta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvTrabajoCubierta.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvTrabajoCubierta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvTrabajoCubierta.Location = new System.Drawing.Point(0, 0);
            this.crvTrabajoCubierta.Name = "crvTrabajoCubierta";
            this.crvTrabajoCubierta.Size = new System.Drawing.Size(1026, 730);
            this.crvTrabajoCubierta.TabIndex = 0;
            this.crvTrabajoCubierta.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmVerTrabajoCubierta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 730);
            this.Controls.Add(this.crvTrabajoCubierta);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmVerTrabajoCubierta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trabajos y Neumáticos en Planta";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmVerTrabajoCubierta_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvTrabajoCubierta;
    }
}