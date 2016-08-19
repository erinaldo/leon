namespace OFC
{
    partial class frmPrincipal
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
            this.pnlIzquierdo = new System.Windows.Forms.Panel();
            this.lblCargandoComplementos = new System.Windows.Forms.Label();
            this.pbrCargandoComplementos = new System.Windows.Forms.ProgressBar();
            this.btnContabilidad = new System.Windows.Forms.Button();
            this.btnFondos = new System.Windows.Forms.Button();
            this.btnVenta = new System.Windows.Forms.Button();
            this.btnCompra = new System.Windows.Forms.Button();
            this.btnStock = new System.Windows.Forms.Button();
            this.pnlDerecho = new System.Windows.Forms.Panel();
            this.txtEmpresa = new System.Windows.Forms.TextBox();
            this.btnEstadisticas = new System.Windows.Forms.Button();
            this.btnConfiguracion = new System.Windows.Forms.Button();
            this.pnlIzquierdo.SuspendLayout();
            this.pnlDerecho.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlIzquierdo
            // 
            this.pnlIzquierdo.BackColor = System.Drawing.Color.DimGray;
            this.pnlIzquierdo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlIzquierdo.Controls.Add(this.lblCargandoComplementos);
            this.pnlIzquierdo.Controls.Add(this.pbrCargandoComplementos);
            this.pnlIzquierdo.Controls.Add(this.btnContabilidad);
            this.pnlIzquierdo.Controls.Add(this.btnFondos);
            this.pnlIzquierdo.Controls.Add(this.btnVenta);
            this.pnlIzquierdo.Controls.Add(this.btnCompra);
            this.pnlIzquierdo.Controls.Add(this.btnStock);
            this.pnlIzquierdo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlIzquierdo.Location = new System.Drawing.Point(0, 0);
            this.pnlIzquierdo.Name = "pnlIzquierdo";
            this.pnlIzquierdo.Size = new System.Drawing.Size(176, 724);
            this.pnlIzquierdo.TabIndex = 1;
            // 
            // lblCargandoComplementos
            // 
            this.lblCargandoComplementos.AutoSize = true;
            this.lblCargandoComplementos.BackColor = System.Drawing.Color.DimGray;
            this.lblCargandoComplementos.ForeColor = System.Drawing.Color.White;
            this.lblCargandoComplementos.Location = new System.Drawing.Point(20, 659);
            this.lblCargandoComplementos.Name = "lblCargandoComplementos";
            this.lblCargandoComplementos.Size = new System.Drawing.Size(134, 13);
            this.lblCargandoComplementos.TabIndex = 13;
            this.lblCargandoComplementos.Text = "Cargando Complementos...";
            this.lblCargandoComplementos.Visible = false;
            // 
            // pbrCargandoComplementos
            // 
            this.pbrCargandoComplementos.Location = new System.Drawing.Point(3, 675);
            this.pbrCargandoComplementos.Name = "pbrCargandoComplementos";
            this.pbrCargandoComplementos.Size = new System.Drawing.Size(168, 23);
            this.pbrCargandoComplementos.TabIndex = 12;
            this.pbrCargandoComplementos.Visible = false;
            // 
            // btnContabilidad
            // 
            this.btnContabilidad.BackColor = System.Drawing.SystemColors.Control;
            this.btnContabilidad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnContabilidad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnContabilidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContabilidad.Location = new System.Drawing.Point(3, 331);
            this.btnContabilidad.Name = "btnContabilidad";
            this.btnContabilidad.Size = new System.Drawing.Size(168, 56);
            this.btnContabilidad.TabIndex = 4;
            this.btnContabilidad.Text = "Contabilidad";
            this.btnContabilidad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnContabilidad.UseVisualStyleBackColor = false;
            this.btnContabilidad.Visible = false;
            // 
            // btnFondos
            // 
            this.btnFondos.BackColor = System.Drawing.SystemColors.Control;
            this.btnFondos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnFondos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFondos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFondos.Location = new System.Drawing.Point(3, 429);
            this.btnFondos.Name = "btnFondos";
            this.btnFondos.Size = new System.Drawing.Size(168, 56);
            this.btnFondos.TabIndex = 5;
            this.btnFondos.Text = "Fondos";
            this.btnFondos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFondos.UseVisualStyleBackColor = false;
            this.btnFondos.Visible = false;
            // 
            // btnVenta
            // 
            this.btnVenta.BackColor = System.Drawing.SystemColors.Control;
            this.btnVenta.BackgroundImage = global::OFC.Properties.Resources.ventas_chico;
            this.btnVenta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnVenta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVenta.Location = new System.Drawing.Point(3, 44);
            this.btnVenta.Name = "btnVenta";
            this.btnVenta.Size = new System.Drawing.Size(168, 56);
            this.btnVenta.TabIndex = 1;
            this.btnVenta.Text = "Ventas";
            this.btnVenta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVenta.UseVisualStyleBackColor = false;
            this.btnVenta.Click += new System.EventHandler(this.btnVenta_Click);
            // 
            // btnCompra
            // 
            this.btnCompra.BackColor = System.Drawing.SystemColors.Control;
            this.btnCompra.BackgroundImage = global::OFC.Properties.Resources.compras_chico;
            this.btnCompra.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCompra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompra.Location = new System.Drawing.Point(3, 137);
            this.btnCompra.Name = "btnCompra";
            this.btnCompra.Size = new System.Drawing.Size(168, 56);
            this.btnCompra.TabIndex = 2;
            this.btnCompra.Text = "Compras";
            this.btnCompra.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCompra.UseVisualStyleBackColor = false;
            this.btnCompra.Click += new System.EventHandler(this.btnCompra_Click);
            // 
            // btnStock
            // 
            this.btnStock.BackColor = System.Drawing.SystemColors.Control;
            this.btnStock.BackgroundImage = global::OFC.Properties.Resources.stock_chico;
            this.btnStock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnStock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStock.Location = new System.Drawing.Point(3, 233);
            this.btnStock.Name = "btnStock";
            this.btnStock.Size = new System.Drawing.Size(168, 56);
            this.btnStock.TabIndex = 3;
            this.btnStock.Text = "Stock";
            this.btnStock.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStock.UseVisualStyleBackColor = false;
            this.btnStock.Click += new System.EventHandler(this.btnStock_Click);
            // 
            // pnlDerecho
            // 
            this.pnlDerecho.BackColor = System.Drawing.Color.DimGray;
            this.pnlDerecho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDerecho.Controls.Add(this.txtEmpresa);
            this.pnlDerecho.Controls.Add(this.btnEstadisticas);
            this.pnlDerecho.Controls.Add(this.btnConfiguracion);
            this.pnlDerecho.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDerecho.Location = new System.Drawing.Point(1184, 0);
            this.pnlDerecho.Name = "pnlDerecho";
            this.pnlDerecho.Size = new System.Drawing.Size(176, 724);
            this.pnlDerecho.TabIndex = 2;
            // 
            // txtEmpresa
            // 
            this.txtEmpresa.BackColor = System.Drawing.SystemColors.GrayText;
            this.txtEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmpresa.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtEmpresa.Location = new System.Drawing.Point(3, 44);
            this.txtEmpresa.Multiline = true;
            this.txtEmpresa.Name = "txtEmpresa";
            this.txtEmpresa.Size = new System.Drawing.Size(168, 56);
            this.txtEmpresa.TabIndex = 4;
            this.txtEmpresa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnEstadisticas
            // 
            this.btnEstadisticas.BackColor = System.Drawing.SystemColors.Control;
            this.btnEstadisticas.BackgroundImage = global::OFC.Properties.Resources.estadisticas_chico;
            this.btnEstadisticas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnEstadisticas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEstadisticas.Enabled = false;
            this.btnEstadisticas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstadisticas.Location = new System.Drawing.Point(3, 233);
            this.btnEstadisticas.Name = "btnEstadisticas";
            this.btnEstadisticas.Size = new System.Drawing.Size(168, 56);
            this.btnEstadisticas.TabIndex = 2;
            this.btnEstadisticas.Text = "Estadísticas";
            this.btnEstadisticas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEstadisticas.UseVisualStyleBackColor = false;
            // 
            // btnConfiguracion
            // 
            this.btnConfiguracion.BackColor = System.Drawing.SystemColors.Control;
            this.btnConfiguracion.BackgroundImage = global::OFC.Properties.Resources.configuracion_chico;
            this.btnConfiguracion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnConfiguracion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfiguracion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfiguracion.Location = new System.Drawing.Point(3, 137);
            this.btnConfiguracion.Name = "btnConfiguracion";
            this.btnConfiguracion.Size = new System.Drawing.Size(168, 56);
            this.btnConfiguracion.TabIndex = 1;
            this.btnConfiguracion.Text = "Configuración";
            this.btnConfiguracion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfiguracion.UseVisualStyleBackColor = false;
            this.btnConfiguracion.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1360, 724);
            this.Controls.Add(this.pnlDerecho);
            this.Controls.Add(this.pnlIzquierdo);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.IsMdiContainer = true;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LEON";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.pnlIzquierdo.ResumeLayout(false);
            this.pnlIzquierdo.PerformLayout();
            this.pnlDerecho.ResumeLayout(false);
            this.pnlDerecho.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnVenta;
        private System.Windows.Forms.Button btnCompra;
        private System.Windows.Forms.Button btnStock;
        private System.Windows.Forms.Panel pnlIzquierdo;
        private System.Windows.Forms.Panel pnlDerecho;
        private System.Windows.Forms.Button btnConfiguracion;
        private System.Windows.Forms.Button btnEstadisticas;
        private System.Windows.Forms.Button btnContabilidad;
        private System.Windows.Forms.Button btnFondos;
        private System.Windows.Forms.Label lblCargandoComplementos;
        private System.Windows.Forms.ProgressBar pbrCargandoComplementos;
        private System.Windows.Forms.TextBox txtEmpresa;


    }
}