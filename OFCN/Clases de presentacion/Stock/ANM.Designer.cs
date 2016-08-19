namespace OFC
{
    partial class frmANM
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
            this.pnlStock = new System.Windows.Forms.Panel();
            this.btnInventarioDeArticulos = new System.Windows.Forms.Button();
            this.btnTrabajosYCubiertas = new System.Windows.Forms.Button();
            this.lblStock = new System.Windows.Forms.Label();
            this.btnMovimientos = new System.Windows.Forms.Button();
            this.btnArticulosYNeumaticos = new System.Windows.Forms.Button();
            this.pnlStock.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlStock
            // 
            this.pnlStock.BackColor = System.Drawing.SystemColors.Control;
            this.pnlStock.BackgroundImage = global::OFC.Properties.Resources.stock;
            this.pnlStock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStock.Controls.Add(this.btnInventarioDeArticulos);
            this.pnlStock.Controls.Add(this.btnTrabajosYCubiertas);
            this.pnlStock.Controls.Add(this.lblStock);
            this.pnlStock.Controls.Add(this.btnMovimientos);
            this.pnlStock.Controls.Add(this.btnArticulosYNeumaticos);
            this.pnlStock.Location = new System.Drawing.Point(12, 12);
            this.pnlStock.Name = "pnlStock";
            this.pnlStock.Size = new System.Drawing.Size(958, 660);
            this.pnlStock.TabIndex = 1;
            // 
            // btnInventarioDeArticulos
            // 
            this.btnInventarioDeArticulos.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnInventarioDeArticulos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInventarioDeArticulos.Enabled = false;
            this.btnInventarioDeArticulos.Font = new System.Drawing.Font("Calibri", 11.25F);
            this.btnInventarioDeArticulos.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnInventarioDeArticulos.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnInventarioDeArticulos.Location = new System.Drawing.Point(672, 389);
            this.btnInventarioDeArticulos.Name = "btnInventarioDeArticulos";
            this.btnInventarioDeArticulos.Size = new System.Drawing.Size(108, 47);
            this.btnInventarioDeArticulos.TabIndex = 4;
            this.btnInventarioDeArticulos.Text = "Inventario de Artículos";
            this.btnInventarioDeArticulos.UseVisualStyleBackColor = false;
            // 
            // btnTrabajosYCubiertas
            // 
            this.btnTrabajosYCubiertas.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnTrabajosYCubiertas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTrabajosYCubiertas.Font = new System.Drawing.Font("Calibri", 11.25F);
            this.btnTrabajosYCubiertas.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnTrabajosYCubiertas.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnTrabajosYCubiertas.Location = new System.Drawing.Point(672, 207);
            this.btnTrabajosYCubiertas.Name = "btnTrabajosYCubiertas";
            this.btnTrabajosYCubiertas.Size = new System.Drawing.Size(108, 47);
            this.btnTrabajosYCubiertas.TabIndex = 3;
            this.btnTrabajosYCubiertas.Text = "Neumáticos en Planta";
            this.btnTrabajosYCubiertas.UseVisualStyleBackColor = false;
            this.btnTrabajosYCubiertas.Click += new System.EventHandler(this.btnTrabajosYCubiertas_Click);
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStock.Location = new System.Drawing.Point(309, 36);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(362, 24);
            this.lblStock.TabIndex = 1;
            this.lblStock.Text = "STOCK DE ARTICULOS Y NEUMATICOS";
            // 
            // btnMovimientos
            // 
            this.btnMovimientos.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnMovimientos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMovimientos.Font = new System.Drawing.Font("Calibri", 11.25F);
            this.btnMovimientos.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnMovimientos.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMovimientos.Location = new System.Drawing.Point(172, 389);
            this.btnMovimientos.Name = "btnMovimientos";
            this.btnMovimientos.Size = new System.Drawing.Size(108, 46);
            this.btnMovimientos.TabIndex = 2;
            this.btnMovimientos.Text = "Movimientos de Artículos";
            this.btnMovimientos.UseVisualStyleBackColor = false;
            this.btnMovimientos.Click += new System.EventHandler(this.btnMovimientos_Click);
            // 
            // btnArticulosYNeumaticos
            // 
            this.btnArticulosYNeumaticos.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnArticulosYNeumaticos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnArticulosYNeumaticos.Font = new System.Drawing.Font("Calibri", 11.25F);
            this.btnArticulosYNeumaticos.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnArticulosYNeumaticos.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnArticulosYNeumaticos.Location = new System.Drawing.Point(172, 208);
            this.btnArticulosYNeumaticos.Name = "btnArticulosYNeumaticos";
            this.btnArticulosYNeumaticos.Size = new System.Drawing.Size(108, 46);
            this.btnArticulosYNeumaticos.TabIndex = 1;
            this.btnArticulosYNeumaticos.Text = "Artículos y Neumáticos";
            this.btnArticulosYNeumaticos.UseVisualStyleBackColor = false;
            this.btnArticulosYNeumaticos.Click += new System.EventHandler(this.btnArticulosYNeumaticos_Click);
            // 
            // frmANM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 684);
            this.Controls.Add(this.pnlStock);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "frmANM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ANM";
            this.Load += new System.EventHandler(this.frmANM_Load);
            this.pnlStock.ResumeLayout(false);
            this.pnlStock.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlStock;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Button btnArticulosYNeumaticos;
        private System.Windows.Forms.Button btnMovimientos;
        private System.Windows.Forms.Button btnTrabajosYCubiertas;
        private System.Windows.Forms.Button btnInventarioDeArticulos;
    }
}