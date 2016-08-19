namespace OFC
{
    partial class frmImpresionDeOrdenDePago
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
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnVistaPreliminarOP = new System.Windows.Forms.Button();
            this.lblVistaPreviaOrdenDePago = new System.Windows.Forms.Label();
            this.lblVistaPreviaRetencion = new System.Windows.Forms.Label();
            this.gbxVistaPrevia = new System.Windows.Forms.GroupBox();
            this.btnVistaPreliminarRT = new System.Windows.Forms.Button();
            this.btnContinuar = new System.Windows.Forms.Button();
            this.gbxVistaPrevia.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnImprimir
            // 
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.Location = new System.Drawing.Point(12, 102);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(145, 35);
            this.btnImprimir.TabIndex = 2;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnVistaPreliminarOP
            // 
            this.btnVistaPreliminarOP.BackgroundImage = global::OFC.Properties.Resources.vista_preliminar1;
            this.btnVistaPreliminarOP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVistaPreliminarOP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVistaPreliminarOP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnVistaPreliminarOP.Location = new System.Drawing.Point(102, 20);
            this.btnVistaPreliminarOP.Name = "btnVistaPreliminarOP";
            this.btnVistaPreliminarOP.Size = new System.Drawing.Size(32, 26);
            this.btnVistaPreliminarOP.TabIndex = 1;
            this.btnVistaPreliminarOP.UseVisualStyleBackColor = true;
            this.btnVistaPreliminarOP.Click += new System.EventHandler(this.btnVistaPreliminar_Click);
            // 
            // lblVistaPreviaOrdenDePago
            // 
            this.lblVistaPreviaOrdenDePago.AutoSize = true;
            this.lblVistaPreviaOrdenDePago.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVistaPreviaOrdenDePago.Location = new System.Drawing.Point(6, 26);
            this.lblVistaPreviaOrdenDePago.Name = "lblVistaPreviaOrdenDePago";
            this.lblVistaPreviaOrdenDePago.Size = new System.Drawing.Size(90, 15);
            this.lblVistaPreviaOrdenDePago.TabIndex = 3;
            this.lblVistaPreviaOrdenDePago.Text = "Orden de Pago";
            // 
            // lblVistaPreviaRetencion
            // 
            this.lblVistaPreviaRetencion.AutoSize = true;
            this.lblVistaPreviaRetencion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVistaPreviaRetencion.Location = new System.Drawing.Point(6, 56);
            this.lblVistaPreviaRetencion.Name = "lblVistaPreviaRetencion";
            this.lblVistaPreviaRetencion.Size = new System.Drawing.Size(63, 15);
            this.lblVistaPreviaRetencion.TabIndex = 4;
            this.lblVistaPreviaRetencion.Text = "Retención";
            // 
            // gbxVistaPrevia
            // 
            this.gbxVistaPrevia.Controls.Add(this.btnVistaPreliminarRT);
            this.gbxVistaPrevia.Controls.Add(this.lblVistaPreviaOrdenDePago);
            this.gbxVistaPrevia.Controls.Add(this.btnVistaPreliminarOP);
            this.gbxVistaPrevia.Controls.Add(this.lblVistaPreviaRetencion);
            this.gbxVistaPrevia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxVistaPrevia.Location = new System.Drawing.Point(12, 12);
            this.gbxVistaPrevia.Name = "gbxVistaPrevia";
            this.gbxVistaPrevia.Size = new System.Drawing.Size(145, 84);
            this.gbxVistaPrevia.TabIndex = 1;
            this.gbxVistaPrevia.TabStop = false;
            this.gbxVistaPrevia.Text = "Vista Previa";
            // 
            // btnVistaPreliminarRT
            // 
            this.btnVistaPreliminarRT.BackgroundImage = global::OFC.Properties.Resources.vista_preliminar1;
            this.btnVistaPreliminarRT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVistaPreliminarRT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVistaPreliminarRT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnVistaPreliminarRT.Location = new System.Drawing.Point(102, 50);
            this.btnVistaPreliminarRT.Name = "btnVistaPreliminarRT";
            this.btnVistaPreliminarRT.Size = new System.Drawing.Size(32, 26);
            this.btnVistaPreliminarRT.TabIndex = 2;
            this.btnVistaPreliminarRT.UseVisualStyleBackColor = true;
            this.btnVistaPreliminarRT.Click += new System.EventHandler(this.btnVistaPreliminarRT_Click);
            // 
            // btnContinuar
            // 
            this.btnContinuar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnContinuar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinuar.Location = new System.Drawing.Point(12, 143);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(145, 35);
            this.btnContinuar.TabIndex = 3;
            this.btnContinuar.Text = "Continuar";
            this.btnContinuar.UseVisualStyleBackColor = true;
            this.btnContinuar.Click += new System.EventHandler(this.btnContinuar_Click);
            // 
            // frmImpresionDeOrdenDePago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(166, 190);
            this.Controls.Add(this.btnContinuar);
            this.Controls.Add(this.gbxVistaPrevia);
            this.Controls.Add(this.btnImprimir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "frmImpresionDeOrdenDePago";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Impresión";
            this.Load += new System.EventHandler(this.frmImpresionDeOrdenDePago_Load);
            this.gbxVistaPrevia.ResumeLayout(false);
            this.gbxVistaPrevia.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnVistaPreliminarOP;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Label lblVistaPreviaOrdenDePago;
        private System.Windows.Forms.Label lblVistaPreviaRetencion;
        private System.Windows.Forms.GroupBox gbxVistaPrevia;
        private System.Windows.Forms.Button btnVistaPreliminarRT;
        private System.Windows.Forms.Button btnContinuar;
    }
}