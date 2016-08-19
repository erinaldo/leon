namespace OFC
{
    partial class frmCPC
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
            this.pnlEspecial = new System.Windows.Forms.Panel();
            this.btnPagos = new System.Windows.Forms.Button();
            this.btnCompraVencimientos = new System.Windows.Forms.Button();
            this.btnBuscarComprobante = new System.Windows.Forms.Button();
            this.lblEspecial = new System.Windows.Forms.Label();
            this.btnLibroIvaCompras = new System.Windows.Forms.Button();
            this.pnlProveedores = new System.Windows.Forms.Panel();
            this.btnListaDePrecio = new System.Windows.Forms.Button();
            this.btnConcepto = new System.Windows.Forms.Button();
            this.lblProveedoresYConceptos = new System.Windows.Forms.Label();
            this.btnProveedor = new System.Windows.Forms.Button();
            this.pnlCompra = new System.Windows.Forms.Panel();
            this.btnIniciarFactura = new System.Windows.Forms.Button();
            this.btnCompraArticulos = new System.Windows.Forms.Button();
            this.btnCompraConceptos = new System.Windows.Forms.Button();
            this.lblFacturacion = new System.Windows.Forms.Label();
            this.pnlCuentaCorriente = new System.Windows.Forms.Panel();
            this.btnNotaDeDebitoDeArticulos = new System.Windows.Forms.Button();
            this.btnCCOrdenDePago = new System.Windows.Forms.Button();
            this.btnNotaDeDebitoDeConceptos = new System.Windows.Forms.Button();
            this.lblMovimientosDeCuenta = new System.Windows.Forms.Label();
            this.btnNotaDeCreditoDeArticulos = new System.Windows.Forms.Button();
            this.btnCCMovimiento = new System.Windows.Forms.Button();
            this.btnNotaDeCreditoDeConceptos = new System.Windows.Forms.Button();
            this.pnlEspecial.SuspendLayout();
            this.pnlProveedores.SuspendLayout();
            this.pnlCompra.SuspendLayout();
            this.pnlCuentaCorriente.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlEspecial
            // 
            this.pnlEspecial.BackColor = System.Drawing.SystemColors.Control;
            this.pnlEspecial.BackgroundImage = global::OFC.Properties.Resources.icono4;
            this.pnlEspecial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlEspecial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlEspecial.Controls.Add(this.btnPagos);
            this.pnlEspecial.Controls.Add(this.btnCompraVencimientos);
            this.pnlEspecial.Controls.Add(this.btnBuscarComprobante);
            this.pnlEspecial.Controls.Add(this.lblEspecial);
            this.pnlEspecial.Controls.Add(this.btnLibroIvaCompras);
            this.pnlEspecial.Location = new System.Drawing.Point(497, 345);
            this.pnlEspecial.Name = "pnlEspecial";
            this.pnlEspecial.Size = new System.Drawing.Size(473, 327);
            this.pnlEspecial.TabIndex = 4;
            // 
            // btnPagos
            // 
            this.btnPagos.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnPagos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPagos.Font = new System.Drawing.Font("Calibri", 11.25F);
            this.btnPagos.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnPagos.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPagos.Location = new System.Drawing.Point(246, 275);
            this.btnPagos.Name = "btnPagos";
            this.btnPagos.Size = new System.Drawing.Size(108, 46);
            this.btnPagos.TabIndex = 3;
            this.btnPagos.Text = "Pagos";
            this.btnPagos.UseVisualStyleBackColor = false;
            this.btnPagos.Click += new System.EventHandler(this.btnPagos_Click);
            // 
            // btnCompraVencimientos
            // 
            this.btnCompraVencimientos.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnCompraVencimientos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCompraVencimientos.Enabled = false;
            this.btnCompraVencimientos.Font = new System.Drawing.Font("Calibri", 11.25F);
            this.btnCompraVencimientos.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnCompraVencimientos.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCompraVencimientos.Location = new System.Drawing.Point(117, 275);
            this.btnCompraVencimientos.Name = "btnCompraVencimientos";
            this.btnCompraVencimientos.Size = new System.Drawing.Size(108, 46);
            this.btnCompraVencimientos.TabIndex = 2;
            this.btnCompraVencimientos.Text = "Vencimientos";
            this.btnCompraVencimientos.UseVisualStyleBackColor = false;
            // 
            // btnBuscarComprobante
            // 
            this.btnBuscarComprobante.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnBuscarComprobante.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarComprobante.Font = new System.Drawing.Font("Calibri", 11.25F);
            this.btnBuscarComprobante.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnBuscarComprobante.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBuscarComprobante.Location = new System.Drawing.Point(3, 275);
            this.btnBuscarComprobante.Name = "btnBuscarComprobante";
            this.btnBuscarComprobante.Size = new System.Drawing.Size(108, 46);
            this.btnBuscarComprobante.TabIndex = 1;
            this.btnBuscarComprobante.Text = "Buscar Comprobante";
            this.btnBuscarComprobante.UseVisualStyleBackColor = false;
            this.btnBuscarComprobante.Click += new System.EventHandler(this.btnBuscarComprobante_Click);
            // 
            // lblEspecial
            // 
            this.lblEspecial.AutoSize = true;
            this.lblEspecial.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEspecial.Location = new System.Drawing.Point(189, 13);
            this.lblEspecial.Name = "lblEspecial";
            this.lblEspecial.Size = new System.Drawing.Size(100, 24);
            this.lblEspecial.TabIndex = 1;
            this.lblEspecial.Text = "ESPECIAL";
            // 
            // btnLibroIvaCompras
            // 
            this.btnLibroIvaCompras.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnLibroIvaCompras.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLibroIvaCompras.Font = new System.Drawing.Font("Calibri", 11.25F);
            this.btnLibroIvaCompras.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnLibroIvaCompras.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLibroIvaCompras.Location = new System.Drawing.Point(360, 275);
            this.btnLibroIvaCompras.Name = "btnLibroIvaCompras";
            this.btnLibroIvaCompras.Size = new System.Drawing.Size(108, 46);
            this.btnLibroIvaCompras.TabIndex = 4;
            this.btnLibroIvaCompras.Text = "Libro Iva Compras";
            this.btnLibroIvaCompras.UseVisualStyleBackColor = false;
            this.btnLibroIvaCompras.Click += new System.EventHandler(this.btnLibroIvaCompras_Click);
            // 
            // pnlProveedores
            // 
            this.pnlProveedores.BackColor = System.Drawing.SystemColors.Control;
            this.pnlProveedores.BackgroundImage = global::OFC.Properties.Resources.proveedores;
            this.pnlProveedores.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlProveedores.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlProveedores.Controls.Add(this.btnListaDePrecio);
            this.pnlProveedores.Controls.Add(this.btnConcepto);
            this.pnlProveedores.Controls.Add(this.lblProveedoresYConceptos);
            this.pnlProveedores.Controls.Add(this.btnProveedor);
            this.pnlProveedores.Location = new System.Drawing.Point(12, 345);
            this.pnlProveedores.Name = "pnlProveedores";
            this.pnlProveedores.Size = new System.Drawing.Size(473, 327);
            this.pnlProveedores.TabIndex = 3;
            // 
            // btnListaDePrecio
            // 
            this.btnListaDePrecio.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnListaDePrecio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnListaDePrecio.Font = new System.Drawing.Font("Calibri", 11.25F);
            this.btnListaDePrecio.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnListaDePrecio.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnListaDePrecio.Location = new System.Drawing.Point(360, 275);
            this.btnListaDePrecio.Name = "btnListaDePrecio";
            this.btnListaDePrecio.Size = new System.Drawing.Size(108, 46);
            this.btnListaDePrecio.TabIndex = 3;
            this.btnListaDePrecio.Text = "Lista de Precio";
            this.btnListaDePrecio.UseVisualStyleBackColor = false;
            this.btnListaDePrecio.Click += new System.EventHandler(this.btnListaDePrecio_Click);
            // 
            // btnConcepto
            // 
            this.btnConcepto.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnConcepto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConcepto.Font = new System.Drawing.Font("Calibri", 11.25F);
            this.btnConcepto.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnConcepto.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnConcepto.Location = new System.Drawing.Point(183, 275);
            this.btnConcepto.Name = "btnConcepto";
            this.btnConcepto.Size = new System.Drawing.Size(108, 46);
            this.btnConcepto.TabIndex = 2;
            this.btnConcepto.Text = "Concepto";
            this.btnConcepto.UseVisualStyleBackColor = false;
            this.btnConcepto.Click += new System.EventHandler(this.btnConcepto_Click);
            // 
            // lblProveedoresYConceptos
            // 
            this.lblProveedoresYConceptos.AutoSize = true;
            this.lblProveedoresYConceptos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProveedoresYConceptos.Location = new System.Drawing.Point(109, 13);
            this.lblProveedoresYConceptos.Name = "lblProveedoresYConceptos";
            this.lblProveedoresYConceptos.Size = new System.Drawing.Size(259, 24);
            this.lblProveedoresYConceptos.TabIndex = 1;
            this.lblProveedoresYConceptos.Text = "PROVEEDORES Y PRECIOS";
            // 
            // btnProveedor
            // 
            this.btnProveedor.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnProveedor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProveedor.Font = new System.Drawing.Font("Calibri", 11.25F);
            this.btnProveedor.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnProveedor.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnProveedor.Location = new System.Drawing.Point(3, 275);
            this.btnProveedor.Name = "btnProveedor";
            this.btnProveedor.Size = new System.Drawing.Size(108, 46);
            this.btnProveedor.TabIndex = 1;
            this.btnProveedor.Text = "Proveedor";
            this.btnProveedor.UseVisualStyleBackColor = false;
            this.btnProveedor.Click += new System.EventHandler(this.btnProveedor_Click);
            // 
            // pnlCompra
            // 
            this.pnlCompra.BackColor = System.Drawing.SystemColors.Control;
            this.pnlCompra.BackgroundImage = global::OFC.Properties.Resources.compras;
            this.pnlCompra.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCompra.Controls.Add(this.btnIniciarFactura);
            this.pnlCompra.Controls.Add(this.btnCompraArticulos);
            this.pnlCompra.Controls.Add(this.btnCompraConceptos);
            this.pnlCompra.Controls.Add(this.lblFacturacion);
            this.pnlCompra.Location = new System.Drawing.Point(497, 12);
            this.pnlCompra.Name = "pnlCompra";
            this.pnlCompra.Size = new System.Drawing.Size(473, 327);
            this.pnlCompra.TabIndex = 2;
            // 
            // btnIniciarFactura
            // 
            this.btnIniciarFactura.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnIniciarFactura.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIniciarFactura.Font = new System.Drawing.Font("Calibri", 11.25F);
            this.btnIniciarFactura.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnIniciarFactura.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnIniciarFactura.Location = new System.Drawing.Point(3, 275);
            this.btnIniciarFactura.Name = "btnIniciarFactura";
            this.btnIniciarFactura.Size = new System.Drawing.Size(108, 46);
            this.btnIniciarFactura.TabIndex = 1;
            this.btnIniciarFactura.Text = "Iniciar Factura";
            this.btnIniciarFactura.UseVisualStyleBackColor = false;
            this.btnIniciarFactura.Click += new System.EventHandler(this.btnIniciarFactura_Click);
            // 
            // btnCompraArticulos
            // 
            this.btnCompraArticulos.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnCompraArticulos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCompraArticulos.Font = new System.Drawing.Font("Calibri", 11.25F);
            this.btnCompraArticulos.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnCompraArticulos.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCompraArticulos.Location = new System.Drawing.Point(360, 275);
            this.btnCompraArticulos.Name = "btnCompraArticulos";
            this.btnCompraArticulos.Size = new System.Drawing.Size(108, 46);
            this.btnCompraArticulos.TabIndex = 3;
            this.btnCompraArticulos.Text = "Factura de Artículos";
            this.btnCompraArticulos.UseVisualStyleBackColor = false;
            this.btnCompraArticulos.Click += new System.EventHandler(this.btnCompraArticulos_Click);
            // 
            // btnCompraConceptos
            // 
            this.btnCompraConceptos.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnCompraConceptos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCompraConceptos.Font = new System.Drawing.Font("Calibri", 11.25F);
            this.btnCompraConceptos.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnCompraConceptos.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCompraConceptos.Location = new System.Drawing.Point(182, 275);
            this.btnCompraConceptos.Name = "btnCompraConceptos";
            this.btnCompraConceptos.Size = new System.Drawing.Size(108, 46);
            this.btnCompraConceptos.TabIndex = 2;
            this.btnCompraConceptos.Text = "Factura de Conceptos";
            this.btnCompraConceptos.UseVisualStyleBackColor = false;
            this.btnCompraConceptos.Click += new System.EventHandler(this.btnCompraConceptos_Click);
            // 
            // lblFacturacion
            // 
            this.lblFacturacion.AutoSize = true;
            this.lblFacturacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFacturacion.Location = new System.Drawing.Point(187, 12);
            this.lblFacturacion.Name = "lblFacturacion";
            this.lblFacturacion.Size = new System.Drawing.Size(92, 24);
            this.lblFacturacion.TabIndex = 1;
            this.lblFacturacion.Text = "COMPRA";
            // 
            // pnlCuentaCorriente
            // 
            this.pnlCuentaCorriente.BackColor = System.Drawing.SystemColors.Control;
            this.pnlCuentaCorriente.BackgroundImage = global::OFC.Properties.Resources.icono3;
            this.pnlCuentaCorriente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlCuentaCorriente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCuentaCorriente.Controls.Add(this.btnNotaDeDebitoDeArticulos);
            this.pnlCuentaCorriente.Controls.Add(this.btnCCOrdenDePago);
            this.pnlCuentaCorriente.Controls.Add(this.btnNotaDeDebitoDeConceptos);
            this.pnlCuentaCorriente.Controls.Add(this.lblMovimientosDeCuenta);
            this.pnlCuentaCorriente.Controls.Add(this.btnNotaDeCreditoDeArticulos);
            this.pnlCuentaCorriente.Controls.Add(this.btnCCMovimiento);
            this.pnlCuentaCorriente.Controls.Add(this.btnNotaDeCreditoDeConceptos);
            this.pnlCuentaCorriente.Location = new System.Drawing.Point(12, 12);
            this.pnlCuentaCorriente.Name = "pnlCuentaCorriente";
            this.pnlCuentaCorriente.Size = new System.Drawing.Size(473, 327);
            this.pnlCuentaCorriente.TabIndex = 1;
            // 
            // btnNotaDeDebitoDeArticulos
            // 
            this.btnNotaDeDebitoDeArticulos.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnNotaDeDebitoDeArticulos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNotaDeDebitoDeArticulos.Font = new System.Drawing.Font("Calibri", 11.25F);
            this.btnNotaDeDebitoDeArticulos.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnNotaDeDebitoDeArticulos.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNotaDeDebitoDeArticulos.Location = new System.Drawing.Point(360, 275);
            this.btnNotaDeDebitoDeArticulos.Name = "btnNotaDeDebitoDeArticulos";
            this.btnNotaDeDebitoDeArticulos.Size = new System.Drawing.Size(108, 46);
            this.btnNotaDeDebitoDeArticulos.TabIndex = 6;
            this.btnNotaDeDebitoDeArticulos.Text = "Débito de Artículos";
            this.btnNotaDeDebitoDeArticulos.UseVisualStyleBackColor = false;
            this.btnNotaDeDebitoDeArticulos.Click += new System.EventHandler(this.btnNotaDeDebitoDeArticulos_Click);
            // 
            // btnCCOrdenDePago
            // 
            this.btnCCOrdenDePago.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnCCOrdenDePago.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCCOrdenDePago.Font = new System.Drawing.Font("Calibri", 11.25F);
            this.btnCCOrdenDePago.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnCCOrdenDePago.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCCOrdenDePago.Location = new System.Drawing.Point(3, 171);
            this.btnCCOrdenDePago.Name = "btnCCOrdenDePago";
            this.btnCCOrdenDePago.Size = new System.Drawing.Size(108, 46);
            this.btnCCOrdenDePago.TabIndex = 1;
            this.btnCCOrdenDePago.Text = "Orden de Pago";
            this.btnCCOrdenDePago.UseVisualStyleBackColor = false;
            this.btnCCOrdenDePago.Click += new System.EventHandler(this.btnCCOrdenDePago_Click);
            // 
            // btnNotaDeDebitoDeConceptos
            // 
            this.btnNotaDeDebitoDeConceptos.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnNotaDeDebitoDeConceptos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNotaDeDebitoDeConceptos.Font = new System.Drawing.Font("Calibri", 11.25F);
            this.btnNotaDeDebitoDeConceptos.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnNotaDeDebitoDeConceptos.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNotaDeDebitoDeConceptos.Location = new System.Drawing.Point(360, 223);
            this.btnNotaDeDebitoDeConceptos.Name = "btnNotaDeDebitoDeConceptos";
            this.btnNotaDeDebitoDeConceptos.Size = new System.Drawing.Size(108, 46);
            this.btnNotaDeDebitoDeConceptos.TabIndex = 4;
            this.btnNotaDeDebitoDeConceptos.Text = "Débito de Conceptos";
            this.btnNotaDeDebitoDeConceptos.UseVisualStyleBackColor = false;
            this.btnNotaDeDebitoDeConceptos.Click += new System.EventHandler(this.btnNotaDeDebitoDeConceptos_Click);
            // 
            // lblMovimientosDeCuenta
            // 
            this.lblMovimientosDeCuenta.AutoSize = true;
            this.lblMovimientosDeCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovimientosDeCuenta.Location = new System.Drawing.Point(80, 12);
            this.lblMovimientosDeCuenta.Name = "lblMovimientosDeCuenta";
            this.lblMovimientosDeCuenta.Size = new System.Drawing.Size(328, 24);
            this.lblMovimientosDeCuenta.TabIndex = 1;
            this.lblMovimientosDeCuenta.Text = "CUENTA CORRIENTE PROVEEDOR";
            // 
            // btnNotaDeCreditoDeArticulos
            // 
            this.btnNotaDeCreditoDeArticulos.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnNotaDeCreditoDeArticulos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNotaDeCreditoDeArticulos.Font = new System.Drawing.Font("Calibri", 11.25F);
            this.btnNotaDeCreditoDeArticulos.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnNotaDeCreditoDeArticulos.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNotaDeCreditoDeArticulos.Location = new System.Drawing.Point(3, 275);
            this.btnNotaDeCreditoDeArticulos.Name = "btnNotaDeCreditoDeArticulos";
            this.btnNotaDeCreditoDeArticulos.Size = new System.Drawing.Size(108, 46);
            this.btnNotaDeCreditoDeArticulos.TabIndex = 5;
            this.btnNotaDeCreditoDeArticulos.Text = "Crédito de Artículos";
            this.btnNotaDeCreditoDeArticulos.UseVisualStyleBackColor = false;
            this.btnNotaDeCreditoDeArticulos.Click += new System.EventHandler(this.btnNotaDeCreditoDeArticulos_Click);
            // 
            // btnCCMovimiento
            // 
            this.btnCCMovimiento.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnCCMovimiento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCCMovimiento.Font = new System.Drawing.Font("Calibri", 11.25F);
            this.btnCCMovimiento.Location = new System.Drawing.Point(360, 171);
            this.btnCCMovimiento.Name = "btnCCMovimiento";
            this.btnCCMovimiento.Size = new System.Drawing.Size(108, 46);
            this.btnCCMovimiento.TabIndex = 2;
            this.btnCCMovimiento.Text = "Movimientos";
            this.btnCCMovimiento.UseVisualStyleBackColor = false;
            this.btnCCMovimiento.Click += new System.EventHandler(this.btnCCMovimiento_Click);
            // 
            // btnNotaDeCreditoDeConceptos
            // 
            this.btnNotaDeCreditoDeConceptos.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnNotaDeCreditoDeConceptos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNotaDeCreditoDeConceptos.Font = new System.Drawing.Font("Calibri", 11.25F);
            this.btnNotaDeCreditoDeConceptos.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnNotaDeCreditoDeConceptos.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNotaDeCreditoDeConceptos.Location = new System.Drawing.Point(3, 223);
            this.btnNotaDeCreditoDeConceptos.Name = "btnNotaDeCreditoDeConceptos";
            this.btnNotaDeCreditoDeConceptos.Size = new System.Drawing.Size(108, 46);
            this.btnNotaDeCreditoDeConceptos.TabIndex = 3;
            this.btnNotaDeCreditoDeConceptos.Text = "Crédito de Conceptos";
            this.btnNotaDeCreditoDeConceptos.UseVisualStyleBackColor = false;
            this.btnNotaDeCreditoDeConceptos.Click += new System.EventHandler(this.btnNotaDeCreditoDeConceptos_Click);
            // 
            // frmCPC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 684);
            this.Controls.Add(this.pnlEspecial);
            this.Controls.Add(this.pnlProveedores);
            this.Controls.Add(this.pnlCompra);
            this.Controls.Add(this.pnlCuentaCorriente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "frmCPC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CPC";
            this.Load += new System.EventHandler(this.frmCPC_Load);
            this.pnlEspecial.ResumeLayout(false);
            this.pnlEspecial.PerformLayout();
            this.pnlProveedores.ResumeLayout(false);
            this.pnlProveedores.PerformLayout();
            this.pnlCompra.ResumeLayout(false);
            this.pnlCompra.PerformLayout();
            this.pnlCuentaCorriente.ResumeLayout(false);
            this.pnlCuentaCorriente.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlEspecial;
        private System.Windows.Forms.Button btnPagos;
        private System.Windows.Forms.Button btnBuscarComprobante;
        private System.Windows.Forms.Label lblEspecial;
        private System.Windows.Forms.Button btnLibroIvaCompras;
        private System.Windows.Forms.Panel pnlProveedores;
        private System.Windows.Forms.Label lblProveedoresYConceptos;
        private System.Windows.Forms.Button btnProveedor;
        private System.Windows.Forms.Panel pnlCompra;
        private System.Windows.Forms.Button btnCompraArticulos;
        private System.Windows.Forms.Button btnCompraConceptos;
        private System.Windows.Forms.Label lblFacturacion;
        private System.Windows.Forms.Panel pnlCuentaCorriente;
        private System.Windows.Forms.Button btnNotaDeDebitoDeConceptos;
        private System.Windows.Forms.Button btnNotaDeCreditoDeConceptos;
        private System.Windows.Forms.Button btnCCOrdenDePago;
        private System.Windows.Forms.Label lblMovimientosDeCuenta;
        private System.Windows.Forms.Button btnCCMovimiento;
        private System.Windows.Forms.Button btnConcepto;
        private System.Windows.Forms.Button btnCompraVencimientos;
        private System.Windows.Forms.Button btnIniciarFactura;
        private System.Windows.Forms.Button btnListaDePrecio;
        private System.Windows.Forms.Button btnNotaDeCreditoDeArticulos;
        private System.Windows.Forms.Button btnNotaDeDebitoDeArticulos;
    }
}