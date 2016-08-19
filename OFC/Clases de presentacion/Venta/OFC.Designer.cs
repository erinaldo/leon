namespace OFC
{
    partial class frmOFC
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlEspecial = new System.Windows.Forms.Panel();
            this.btnCobranza = new System.Windows.Forms.Button();
            this.btnBuscarComprobante = new System.Windows.Forms.Button();
            this.lblEspecial = new System.Windows.Forms.Label();
            this.btnLibroIvaVentas = new System.Windows.Forms.Button();
            this.btnHistoricoDeCubiertas = new System.Windows.Forms.Button();
            this.pnlClientes = new System.Windows.Forms.Panel();
            this.btnTalonarioDeRecibo = new System.Windows.Forms.Button();
            this.lblClientes = new System.Windows.Forms.Label();
            this.btnProductosYServicios = new System.Windows.Forms.Button();
            this.btnCliente = new System.Windows.Forms.Button();
            this.btnListaDePrecio = new System.Windows.Forms.Button();
            this.pnlFacturacion = new System.Windows.Forms.Panel();
            this.btnConRemito = new System.Windows.Forms.Button();
            this.btnFacturacionManual = new System.Windows.Forms.Button();
            this.btnFacturacionAutomatica = new System.Windows.Forms.Button();
            this.lblFacturacion = new System.Windows.Forms.Label();
            this.pnlCuentaCorriente = new System.Windows.Forms.Panel();
            this.btnCCNotaDeDebito = new System.Windows.Forms.Button();
            this.btnCCNotaDeCredito = new System.Windows.Forms.Button();
            this.btnCCRecibo = new System.Windows.Forms.Button();
            this.lblMovimientosDeCuenta = new System.Windows.Forms.Label();
            this.btnCCMovimiento = new System.Windows.Forms.Button();
            this.pnlOrdenesDeTrabajo = new System.Windows.Forms.Panel();
            this.btnDespachar = new System.Windows.Forms.Button();
            this.btnOdtNueva = new System.Windows.Forms.Button();
            this.lblOrdenesDeTrabajo = new System.Windows.Forms.Label();
            this.btnOdtBusqueda = new System.Windows.Forms.Button();
            this.pnlEspecial.SuspendLayout();
            this.pnlClientes.SuspendLayout();
            this.pnlFacturacion.SuspendLayout();
            this.pnlCuentaCorriente.SuspendLayout();
            this.pnlOrdenesDeTrabajo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlEspecial
            // 
            this.pnlEspecial.BackColor = System.Drawing.SystemColors.Control;
            this.pnlEspecial.BackgroundImage = global::OFC.Properties.Resources.icono4;
            this.pnlEspecial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlEspecial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlEspecial.Controls.Add(this.btnCobranza);
            this.pnlEspecial.Controls.Add(this.btnBuscarComprobante);
            this.pnlEspecial.Controls.Add(this.lblEspecial);
            this.pnlEspecial.Controls.Add(this.btnLibroIvaVentas);
            this.pnlEspecial.Controls.Add(this.btnHistoricoDeCubiertas);
            this.pnlEspecial.Location = new System.Drawing.Point(657, 346);
            this.pnlEspecial.Name = "pnlEspecial";
            this.pnlEspecial.Size = new System.Drawing.Size(319, 335);
            this.pnlEspecial.TabIndex = 7;
            // 
            // btnCobranza
            // 
            this.btnCobranza.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnCobranza.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCobranza.Font = new System.Drawing.Font("Calibri", 11.25F);
            this.btnCobranza.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnCobranza.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCobranza.Location = new System.Drawing.Point(3, 277);
            this.btnCobranza.Name = "btnCobranza";
            this.btnCobranza.Size = new System.Drawing.Size(108, 47);
            this.btnCobranza.TabIndex = 3;
            this.btnCobranza.Text = "Cobranza";
            this.btnCobranza.UseVisualStyleBackColor = false;
            this.btnCobranza.Click += new System.EventHandler(this.btnCobranzaYFacturacion_Click);
            // 
            // btnBuscarComprobante
            // 
            this.btnBuscarComprobante.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnBuscarComprobante.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarComprobante.Font = new System.Drawing.Font("Calibri", 11.25F);
            this.btnBuscarComprobante.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnBuscarComprobante.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBuscarComprobante.Location = new System.Drawing.Point(3, 224);
            this.btnBuscarComprobante.Name = "btnBuscarComprobante";
            this.btnBuscarComprobante.Size = new System.Drawing.Size(108, 47);
            this.btnBuscarComprobante.TabIndex = 1;
            this.btnBuscarComprobante.Text = "Buscar Comprobante";
            this.btnBuscarComprobante.UseVisualStyleBackColor = false;
            this.btnBuscarComprobante.Click += new System.EventHandler(this.btnBuscarComprobante_Click);
            // 
            // lblEspecial
            // 
            this.lblEspecial.AutoSize = true;
            this.lblEspecial.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEspecial.Location = new System.Drawing.Point(111, 13);
            this.lblEspecial.Name = "lblEspecial";
            this.lblEspecial.Size = new System.Drawing.Size(100, 24);
            this.lblEspecial.TabIndex = 1;
            this.lblEspecial.Text = "ESPECIAL";
            // 
            // btnLibroIvaVentas
            // 
            this.btnLibroIvaVentas.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnLibroIvaVentas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLibroIvaVentas.Font = new System.Drawing.Font("Calibri", 11.25F);
            this.btnLibroIvaVentas.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnLibroIvaVentas.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLibroIvaVentas.Location = new System.Drawing.Point(206, 277);
            this.btnLibroIvaVentas.Name = "btnLibroIvaVentas";
            this.btnLibroIvaVentas.Size = new System.Drawing.Size(108, 47);
            this.btnLibroIvaVentas.TabIndex = 4;
            this.btnLibroIvaVentas.Text = "Libro Iva Ventas";
            this.btnLibroIvaVentas.UseVisualStyleBackColor = false;
            this.btnLibroIvaVentas.Click += new System.EventHandler(this.btnLibroIvaVentas_Click);
            // 
            // btnHistoricoDeCubiertas
            // 
            this.btnHistoricoDeCubiertas.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnHistoricoDeCubiertas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHistoricoDeCubiertas.Font = new System.Drawing.Font("Calibri", 11.25F);
            this.btnHistoricoDeCubiertas.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnHistoricoDeCubiertas.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnHistoricoDeCubiertas.Location = new System.Drawing.Point(206, 224);
            this.btnHistoricoDeCubiertas.Name = "btnHistoricoDeCubiertas";
            this.btnHistoricoDeCubiertas.Size = new System.Drawing.Size(108, 47);
            this.btnHistoricoDeCubiertas.TabIndex = 2;
            this.btnHistoricoDeCubiertas.Text = "Histórico de Cubiertas";
            this.btnHistoricoDeCubiertas.UseVisualStyleBackColor = false;
            this.btnHistoricoDeCubiertas.Click += new System.EventHandler(this.btnHistoricoDeCubiertas_Click);
            // 
            // pnlClientes
            // 
            this.pnlClientes.BackColor = System.Drawing.SystemColors.Control;
            this.pnlClientes.BackgroundImage = global::OFC.Properties.Resources.icono2;
            this.pnlClientes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlClientes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlClientes.Controls.Add(this.btnTalonarioDeRecibo);
            this.pnlClientes.Controls.Add(this.lblClientes);
            this.pnlClientes.Controls.Add(this.btnProductosYServicios);
            this.pnlClientes.Controls.Add(this.btnCliente);
            this.pnlClientes.Controls.Add(this.btnListaDePrecio);
            this.pnlClientes.Location = new System.Drawing.Point(7, 346);
            this.pnlClientes.Name = "pnlClientes";
            this.pnlClientes.Size = new System.Drawing.Size(319, 335);
            this.pnlClientes.TabIndex = 5;
            // 
            // btnTalonarioDeRecibo
            // 
            this.btnTalonarioDeRecibo.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnTalonarioDeRecibo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTalonarioDeRecibo.Font = new System.Drawing.Font("Calibri", 11.25F);
            this.btnTalonarioDeRecibo.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnTalonarioDeRecibo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnTalonarioDeRecibo.Location = new System.Drawing.Point(215, 277);
            this.btnTalonarioDeRecibo.Name = "btnTalonarioDeRecibo";
            this.btnTalonarioDeRecibo.Size = new System.Drawing.Size(99, 47);
            this.btnTalonarioDeRecibo.TabIndex = 8;
            this.btnTalonarioDeRecibo.Text = "Talonario de Recibo";
            this.btnTalonarioDeRecibo.UseVisualStyleBackColor = false;
            this.btnTalonarioDeRecibo.Click += new System.EventHandler(this.btnTalonarioDeRecibo_Click);
            // 
            // lblClientes
            // 
            this.lblClientes.AutoSize = true;
            this.lblClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientes.Location = new System.Drawing.Point(59, 13);
            this.lblClientes.Name = "lblClientes";
            this.lblClientes.Size = new System.Drawing.Size(205, 24);
            this.lblClientes.TabIndex = 1;
            this.lblClientes.Text = "CLIENTES Y PRECIOS";
            // 
            // btnProductosYServicios
            // 
            this.btnProductosYServicios.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnProductosYServicios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProductosYServicios.Font = new System.Drawing.Font("Calibri", 11.25F);
            this.btnProductosYServicios.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnProductosYServicios.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnProductosYServicios.Location = new System.Drawing.Point(4, 277);
            this.btnProductosYServicios.Name = "btnProductosYServicios";
            this.btnProductosYServicios.Size = new System.Drawing.Size(99, 47);
            this.btnProductosYServicios.TabIndex = 2;
            this.btnProductosYServicios.Text = "Trabajos y Servicios";
            this.btnProductosYServicios.UseVisualStyleBackColor = false;
            this.btnProductosYServicios.Click += new System.EventHandler(this.btnProductosYServicios_Click);
            // 
            // btnCliente
            // 
            this.btnCliente.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCliente.Font = new System.Drawing.Font("Calibri", 11.25F);
            this.btnCliente.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnCliente.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCliente.Location = new System.Drawing.Point(4, 224);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(99, 47);
            this.btnCliente.TabIndex = 1;
            this.btnCliente.Text = "Cliente";
            this.btnCliente.UseVisualStyleBackColor = false;
            this.btnCliente.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnListaDePrecio
            // 
            this.btnListaDePrecio.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnListaDePrecio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnListaDePrecio.Font = new System.Drawing.Font("Calibri", 11.25F);
            this.btnListaDePrecio.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnListaDePrecio.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnListaDePrecio.Location = new System.Drawing.Point(215, 224);
            this.btnListaDePrecio.Name = "btnListaDePrecio";
            this.btnListaDePrecio.Size = new System.Drawing.Size(99, 47);
            this.btnListaDePrecio.TabIndex = 3;
            this.btnListaDePrecio.Text = "Lista de Precio";
            this.btnListaDePrecio.UseVisualStyleBackColor = false;
            this.btnListaDePrecio.Click += new System.EventHandler(this.btnListaDePrecio_Click);
            // 
            // pnlFacturacion
            // 
            this.pnlFacturacion.BackColor = System.Drawing.SystemColors.Control;
            this.pnlFacturacion.BackgroundImage = global::OFC.Properties.Resources.icono5;
            this.pnlFacturacion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlFacturacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFacturacion.Controls.Add(this.btnConRemito);
            this.pnlFacturacion.Controls.Add(this.btnFacturacionManual);
            this.pnlFacturacion.Controls.Add(this.btnFacturacionAutomatica);
            this.pnlFacturacion.Controls.Add(this.lblFacturacion);
            this.pnlFacturacion.Location = new System.Drawing.Point(657, 5);
            this.pnlFacturacion.Name = "pnlFacturacion";
            this.pnlFacturacion.Size = new System.Drawing.Size(319, 335);
            this.pnlFacturacion.TabIndex = 3;
            // 
            // btnConRemito
            // 
            this.btnConRemito.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnConRemito.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConRemito.Font = new System.Drawing.Font("Calibri", 11.25F);
            this.btnConRemito.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnConRemito.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnConRemito.Location = new System.Drawing.Point(106, 279);
            this.btnConRemito.Name = "btnConRemito";
            this.btnConRemito.Size = new System.Drawing.Size(99, 47);
            this.btnConRemito.TabIndex = 2;
            this.btnConRemito.Text = "Facturar Remito";
            this.btnConRemito.UseVisualStyleBackColor = false;
            this.btnConRemito.Click += new System.EventHandler(this.btnConRemito_Click);
            // 
            // btnFacturacionManual
            // 
            this.btnFacturacionManual.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnFacturacionManual.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFacturacionManual.Font = new System.Drawing.Font("Calibri", 11.25F);
            this.btnFacturacionManual.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnFacturacionManual.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFacturacionManual.Location = new System.Drawing.Point(211, 279);
            this.btnFacturacionManual.Name = "btnFacturacionManual";
            this.btnFacturacionManual.Size = new System.Drawing.Size(103, 47);
            this.btnFacturacionManual.TabIndex = 3;
            this.btnFacturacionManual.Text = "Comprobante Manual";
            this.btnFacturacionManual.UseVisualStyleBackColor = false;
            this.btnFacturacionManual.Click += new System.EventHandler(this.btnFacturacionManual_Click);
            // 
            // btnFacturacionAutomatica
            // 
            this.btnFacturacionAutomatica.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnFacturacionAutomatica.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFacturacionAutomatica.Font = new System.Drawing.Font("Calibri", 11.25F);
            this.btnFacturacionAutomatica.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnFacturacionAutomatica.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFacturacionAutomatica.Location = new System.Drawing.Point(3, 279);
            this.btnFacturacionAutomatica.Name = "btnFacturacionAutomatica";
            this.btnFacturacionAutomatica.Size = new System.Drawing.Size(97, 47);
            this.btnFacturacionAutomatica.TabIndex = 1;
            this.btnFacturacionAutomatica.Text = "Facturar Orden";
            this.btnFacturacionAutomatica.UseVisualStyleBackColor = false;
            this.btnFacturacionAutomatica.Click += new System.EventHandler(this.btnFacturar_Click);
            // 
            // lblFacturacion
            // 
            this.lblFacturacion.AutoSize = true;
            this.lblFacturacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFacturacion.Location = new System.Drawing.Point(89, 10);
            this.lblFacturacion.Name = "lblFacturacion";
            this.lblFacturacion.Size = new System.Drawing.Size(145, 24);
            this.lblFacturacion.TabIndex = 1;
            this.lblFacturacion.Text = "FACTURACION";
            // 
            // pnlCuentaCorriente
            // 
            this.pnlCuentaCorriente.BackColor = System.Drawing.SystemColors.Control;
            this.pnlCuentaCorriente.BackgroundImage = global::OFC.Properties.Resources.icono3;
            this.pnlCuentaCorriente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlCuentaCorriente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCuentaCorriente.Controls.Add(this.btnCCNotaDeDebito);
            this.pnlCuentaCorriente.Controls.Add(this.btnCCNotaDeCredito);
            this.pnlCuentaCorriente.Controls.Add(this.btnCCRecibo);
            this.pnlCuentaCorriente.Controls.Add(this.lblMovimientosDeCuenta);
            this.pnlCuentaCorriente.Controls.Add(this.btnCCMovimiento);
            this.pnlCuentaCorriente.Location = new System.Drawing.Point(332, 179);
            this.pnlCuentaCorriente.Name = "pnlCuentaCorriente";
            this.pnlCuentaCorriente.Size = new System.Drawing.Size(319, 328);
            this.pnlCuentaCorriente.TabIndex = 4;
            // 
            // btnCCNotaDeDebito
            // 
            this.btnCCNotaDeDebito.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnCCNotaDeDebito.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCCNotaDeDebito.Font = new System.Drawing.Font("Calibri", 11.25F);
            this.btnCCNotaDeDebito.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnCCNotaDeDebito.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCCNotaDeDebito.Location = new System.Drawing.Point(3, 276);
            this.btnCCNotaDeDebito.Name = "btnCCNotaDeDebito";
            this.btnCCNotaDeDebito.Size = new System.Drawing.Size(108, 47);
            this.btnCCNotaDeDebito.TabIndex = 3;
            this.btnCCNotaDeDebito.Text = "Nota de Débito";
            this.btnCCNotaDeDebito.UseVisualStyleBackColor = false;
            this.btnCCNotaDeDebito.Click += new System.EventHandler(this.btnMdcNotaDeDebito_Click);
            // 
            // btnCCNotaDeCredito
            // 
            this.btnCCNotaDeCredito.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnCCNotaDeCredito.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCCNotaDeCredito.Font = new System.Drawing.Font("Calibri", 11.25F);
            this.btnCCNotaDeCredito.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnCCNotaDeCredito.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCCNotaDeCredito.Location = new System.Drawing.Point(206, 276);
            this.btnCCNotaDeCredito.Name = "btnCCNotaDeCredito";
            this.btnCCNotaDeCredito.Size = new System.Drawing.Size(108, 47);
            this.btnCCNotaDeCredito.TabIndex = 4;
            this.btnCCNotaDeCredito.Text = "Nota de Crédito";
            this.btnCCNotaDeCredito.UseVisualStyleBackColor = false;
            this.btnCCNotaDeCredito.Click += new System.EventHandler(this.btnNotaDeCredito_Click);
            // 
            // btnCCRecibo
            // 
            this.btnCCRecibo.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnCCRecibo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCCRecibo.Font = new System.Drawing.Font("Calibri", 11.25F);
            this.btnCCRecibo.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnCCRecibo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCCRecibo.Location = new System.Drawing.Point(206, 223);
            this.btnCCRecibo.Name = "btnCCRecibo";
            this.btnCCRecibo.Size = new System.Drawing.Size(108, 47);
            this.btnCCRecibo.TabIndex = 2;
            this.btnCCRecibo.Text = "Recibo";
            this.btnCCRecibo.UseVisualStyleBackColor = false;
            this.btnCCRecibo.Click += new System.EventHandler(this.btnRecibo_Click);
            // 
            // lblMovimientosDeCuenta
            // 
            this.lblMovimientosDeCuenta.AutoSize = true;
            this.lblMovimientosDeCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovimientosDeCuenta.Location = new System.Drawing.Point(18, 11);
            this.lblMovimientosDeCuenta.Name = "lblMovimientosDeCuenta";
            this.lblMovimientosDeCuenta.Size = new System.Drawing.Size(287, 24);
            this.lblMovimientosDeCuenta.TabIndex = 1;
            this.lblMovimientosDeCuenta.Text = "CUENTA CORRIENTE CLIENTE";
            this.lblMovimientosDeCuenta.Click += new System.EventHandler(this.lblMovimientosDeCuenta_Click);
            // 
            // btnCCMovimiento
            // 
            this.btnCCMovimiento.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnCCMovimiento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCCMovimiento.Font = new System.Drawing.Font("Calibri", 11.25F);
            this.btnCCMovimiento.Location = new System.Drawing.Point(3, 224);
            this.btnCCMovimiento.Name = "btnCCMovimiento";
            this.btnCCMovimiento.Size = new System.Drawing.Size(108, 46);
            this.btnCCMovimiento.TabIndex = 1;
            this.btnCCMovimiento.Text = "Movimientos";
            this.btnCCMovimiento.UseVisualStyleBackColor = false;
            this.btnCCMovimiento.Click += new System.EventHandler(this.btnCuentaCorriente_Click);
            // 
            // pnlOrdenesDeTrabajo
            // 
            this.pnlOrdenesDeTrabajo.BackColor = System.Drawing.SystemColors.Control;
            this.pnlOrdenesDeTrabajo.BackgroundImage = global::OFC.Properties.Resources.icono1;
            this.pnlOrdenesDeTrabajo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlOrdenesDeTrabajo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlOrdenesDeTrabajo.Controls.Add(this.btnDespachar);
            this.pnlOrdenesDeTrabajo.Controls.Add(this.btnOdtNueva);
            this.pnlOrdenesDeTrabajo.Controls.Add(this.lblOrdenesDeTrabajo);
            this.pnlOrdenesDeTrabajo.Controls.Add(this.btnOdtBusqueda);
            this.pnlOrdenesDeTrabajo.Location = new System.Drawing.Point(7, 5);
            this.pnlOrdenesDeTrabajo.Name = "pnlOrdenesDeTrabajo";
            this.pnlOrdenesDeTrabajo.Size = new System.Drawing.Size(319, 335);
            this.pnlOrdenesDeTrabajo.TabIndex = 1;
            // 
            // btnDespachar
            // 
            this.btnDespachar.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnDespachar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDespachar.Font = new System.Drawing.Font("Calibri", 11.25F);
            this.btnDespachar.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnDespachar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDespachar.Location = new System.Drawing.Point(215, 279);
            this.btnDespachar.Name = "btnDespachar";
            this.btnDespachar.Size = new System.Drawing.Size(99, 47);
            this.btnDespachar.TabIndex = 3;
            this.btnDespachar.Text = "Despachar";
            this.btnDespachar.UseVisualStyleBackColor = false;
            this.btnDespachar.Click += new System.EventHandler(this.btnDespachar_Click);
            // 
            // btnOdtNueva
            // 
            this.btnOdtNueva.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnOdtNueva.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOdtNueva.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOdtNueva.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnOdtNueva.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnOdtNueva.Location = new System.Drawing.Point(3, 279);
            this.btnOdtNueva.Name = "btnOdtNueva";
            this.btnOdtNueva.Size = new System.Drawing.Size(99, 47);
            this.btnOdtNueva.TabIndex = 1;
            this.btnOdtNueva.Text = "Nueva";
            this.btnOdtNueva.UseVisualStyleBackColor = false;
            this.btnOdtNueva.Click += new System.EventHandler(this.btnOdtNueva_Click);
            // 
            // lblOrdenesDeTrabajo
            // 
            this.lblOrdenesDeTrabajo.AutoSize = true;
            this.lblOrdenesDeTrabajo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrdenesDeTrabajo.Location = new System.Drawing.Point(47, 10);
            this.lblOrdenesDeTrabajo.Name = "lblOrdenesDeTrabajo";
            this.lblOrdenesDeTrabajo.Size = new System.Drawing.Size(226, 24);
            this.lblOrdenesDeTrabajo.TabIndex = 1;
            this.lblOrdenesDeTrabajo.Text = "ORDENES DE TRABAJO";
            // 
            // btnOdtBusqueda
            // 
            this.btnOdtBusqueda.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnOdtBusqueda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOdtBusqueda.Font = new System.Drawing.Font("Calibri", 11.25F);
            this.btnOdtBusqueda.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnOdtBusqueda.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnOdtBusqueda.Location = new System.Drawing.Point(109, 279);
            this.btnOdtBusqueda.Name = "btnOdtBusqueda";
            this.btnOdtBusqueda.Size = new System.Drawing.Size(99, 47);
            this.btnOdtBusqueda.TabIndex = 2;
            this.btnOdtBusqueda.Text = "Búsqueda";
            this.btnOdtBusqueda.UseVisualStyleBackColor = false;
            this.btnOdtBusqueda.Click += new System.EventHandler(this.btnOrdenesDeTrabajo_Click);
            // 
            // frmOFC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(982, 684);
            this.Controls.Add(this.pnlEspecial);
            this.Controls.Add(this.pnlClientes);
            this.Controls.Add(this.pnlFacturacion);
            this.Controls.Add(this.pnlCuentaCorriente);
            this.Controls.Add(this.pnlOrdenesDeTrabajo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "frmOFC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OFC - Distribuidora Martelli S.A.";
            this.Load += new System.EventHandler(this.OFC_Load);
            this.pnlEspecial.ResumeLayout(false);
            this.pnlEspecial.PerformLayout();
            this.pnlClientes.ResumeLayout(false);
            this.pnlClientes.PerformLayout();
            this.pnlFacturacion.ResumeLayout(false);
            this.pnlFacturacion.PerformLayout();
            this.pnlCuentaCorriente.ResumeLayout(false);
            this.pnlCuentaCorriente.PerformLayout();
            this.pnlOrdenesDeTrabajo.ResumeLayout(false);
            this.pnlOrdenesDeTrabajo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOdtBusqueda;
        private System.Windows.Forms.Button btnCCMovimiento;
        private System.Windows.Forms.Button btnCliente;
        private System.Windows.Forms.Button btnProductosYServicios;
        private System.Windows.Forms.Button btnListaDePrecio;
        private System.Windows.Forms.Button btnLibroIvaVentas;
        private System.Windows.Forms.Panel pnlOrdenesDeTrabajo;
        private System.Windows.Forms.Button btnOdtNueva;
        private System.Windows.Forms.Label lblOrdenesDeTrabajo;
        private System.Windows.Forms.Panel pnlCuentaCorriente;
        private System.Windows.Forms.Button btnCCRecibo;
        private System.Windows.Forms.Label lblMovimientosDeCuenta;
        private System.Windows.Forms.Button btnCCNotaDeCredito;
        private System.Windows.Forms.Panel pnlFacturacion;
        private System.Windows.Forms.Button btnFacturacionManual;
        private System.Windows.Forms.Button btnFacturacionAutomatica;
        private System.Windows.Forms.Label lblFacturacion;
        private System.Windows.Forms.Button btnCCNotaDeDebito;
        private System.Windows.Forms.Button btnHistoricoDeCubiertas;
        private System.Windows.Forms.Panel pnlClientes;
        private System.Windows.Forms.Label lblClientes;
        private System.Windows.Forms.Panel pnlEspecial;
        private System.Windows.Forms.Label lblEspecial;
        private System.Windows.Forms.Button btnBuscarComprobante;
        private System.Windows.Forms.Button btnCobranza;
        private System.Windows.Forms.Button btnDespachar;
        private System.Windows.Forms.Button btnConRemito;
        private System.Windows.Forms.Button btnTalonarioDeRecibo;

    }
}

