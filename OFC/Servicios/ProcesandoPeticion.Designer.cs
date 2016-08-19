namespace OFC
{
    partial class frmProcesandoPeticion
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
            this.pgbProcesandoPeticion = new System.Windows.Forms.ProgressBar();
            this.lblAguardeUnMomento = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pgbProcesandoPeticion
            // 
            this.pgbProcesandoPeticion.Location = new System.Drawing.Point(15, 25);
            this.pgbProcesandoPeticion.Name = "pgbProcesandoPeticion";
            this.pgbProcesandoPeticion.Size = new System.Drawing.Size(159, 23);
            this.pgbProcesandoPeticion.TabIndex = 0;
            // 
            // lblAguardeUnMomento
            // 
            this.lblAguardeUnMomento.AutoSize = true;
            this.lblAguardeUnMomento.Location = new System.Drawing.Point(12, 9);
            this.lblAguardeUnMomento.Name = "lblAguardeUnMomento";
            this.lblAguardeUnMomento.Size = new System.Drawing.Size(162, 13);
            this.lblAguardeUnMomento.TabIndex = 1;
            this.lblAguardeUnMomento.Text = "Aguarde un momento por favor...";
            // 
            // frmProcesandoPeticion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(189, 65);
            this.Controls.Add(this.lblAguardeUnMomento);
            this.Controls.Add(this.pgbProcesandoPeticion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "frmProcesandoPeticion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Procesando Petición";
            this.Load += new System.EventHandler(this.frmProcesandoPeticion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pgbProcesandoPeticion;
        private System.Windows.Forms.Label lblAguardeUnMomento;
    }
}