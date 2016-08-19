namespace OFC
{
    partial class frmVerRetencion
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
            this.crvRetencion = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvRetencion
            // 
            this.crvRetencion.ActiveViewIndex = -1;
            this.crvRetencion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvRetencion.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvRetencion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvRetencion.Location = new System.Drawing.Point(0, 0);
            this.crvRetencion.Name = "crvRetencion";
            this.crvRetencion.Size = new System.Drawing.Size(1020, 724);
            this.crvRetencion.TabIndex = 3;
            this.crvRetencion.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmVerRetencion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 724);
            this.Controls.Add(this.crvRetencion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmVerRetencion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Certificado de Retención";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmVerRetencion_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvRetencion;

    }
}