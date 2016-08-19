namespace OFC
{
    partial class frmFacturacionManual
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
            this.pnlDerecho = new System.Windows.Forms.Panel();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnVistaDefinitiva = new System.Windows.Forms.Button();
            this.lblVistaPreliminar = new System.Windows.Forms.Label();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.tbcFactura = new System.Windows.Forms.TabControl();
            this.tbpNroFactura = new System.Windows.Forms.TabPage();
            this.btnVistaPreliminarFactura = new System.Windows.Forms.Button();
            this.btnVistaPreliminarRemito = new System.Windows.Forms.Button();
            this.txtRenglones = new System.Windows.Forms.TextBox();
            this.btnImprimirRemito = new System.Windows.Forms.Button();
            this.btnImprimirFactura = new System.Windows.Forms.Button();
            this.lblNroFactura = new System.Windows.Forms.Label();
            this.lblNroRemito = new System.Windows.Forms.Label();
            this.txtNroFactura = new System.Windows.Forms.TextBox();
            this.txtNroRemito = new System.Windows.Forms.TextBox();
            this.btnCambiarRemito = new System.Windows.Forms.Button();
            this.btnCambiarFactura = new System.Windows.Forms.Button();
            this.lblTipoFactura = new System.Windows.Forms.Label();
            this.lblDatosDelCliente = new System.Windows.Forms.Label();
            this.lblBonificacion = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtBonificacion = new System.Windows.Forms.TextBox();
            this.lblIva = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.txtIva = new System.Windows.Forms.TextBox();
            this.txtSubtotal = new System.Windows.Forms.TextBox();
            this.dgvFacturaPendiente = new System.Windows.Forms.DataGridView();
            this.lblFacturaPendiente = new System.Windows.Forms.Label();
            this.pnlIzquierda1 = new System.Windows.Forms.Panel();
            this.cbhSoloRemito = new System.Windows.Forms.CheckBox();
            this.txtPorcentajeDeBonificacion = new System.Windows.Forms.TextBox();
            this.lblBonificacionDelCliente = new System.Windows.Forms.Label();
            this.cbhIva105 = new System.Windows.Forms.CheckBox();
            this.btnXCliente = new System.Windows.Forms.Button();
            this.cbhSoloFactura = new System.Windows.Forms.CheckBox();
            this.cbxNombreDelCliente = new System.Windows.Forms.ComboBox();
            this.lblNombreDelCliente = new System.Windows.Forms.Label();
            this.cbxCodCliente = new System.Windows.Forms.ComboBox();
            this.lblDatosCliente = new System.Windows.Forms.Label();
            this.lblCodCliente = new System.Windows.Forms.Label();
            this.pnlIzquierda2 = new System.Windows.Forms.Panel();
            this.cbxCodProducto = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtCodigoDeBarras = new System.Windows.Forms.TextBox();
            this.btnXCalcular = new System.Windows.Forms.Button();
            this.btnX = new System.Windows.Forms.Button();
            this.pnlDatosCubierta = new System.Windows.Forms.Panel();
            this.cbxServicioAdicional = new System.Windows.Forms.ComboBox();
            this.lblServicioAdicional = new System.Windows.Forms.Label();
            this.txtNroSerie = new System.Windows.Forms.TextBox();
            this.cbxMedidaDeCubierta = new System.Windows.Forms.ComboBox();
            this.lblMedidaDeCubierta = new System.Windows.Forms.Label();
            this.lblTrabajoServicio = new System.Windows.Forms.Label();
            this.cbxTrabajoServicio = new System.Windows.Forms.ComboBox();
            this.lblNroSerie = new System.Windows.Forms.Label();
            this.cbxMarca = new System.Windows.Forms.ComboBox();
            this.lblMarca = new System.Windows.Forms.Label();
            this.txtCoche = new System.Windows.Forms.TextBox();
            this.lblCoche = new System.Windows.Forms.Label();
            this.rdbDescripcion = new System.Windows.Forms.RadioButton();
            this.btnProcesar = new System.Windows.Forms.Button();
            this.rdbProducto = new System.Windows.Forms.RadioButton();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblImporte = new System.Windows.Forms.Label();
            this.lblPrecioUnitario = new System.Windows.Forms.Label();
            this.txtPrecioUnitario = new System.Windows.Forms.TextBox();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.lblDatosDelItem = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.cbxProducto = new System.Windows.Forms.ComboBox();
            this.pnlDerecho.SuspendLayout();
            this.tbcFactura.SuspendLayout();
            this.tbpNroFactura.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturaPendiente)).BeginInit();
            this.pnlIzquierda1.SuspendLayout();
            this.pnlIzquierda2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlDatosCubierta.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDerecho
            // 
            this.pnlDerecho.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlDerecho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDerecho.Controls.Add(this.btnExportar);
            this.pnlDerecho.Controls.Add(this.btnVistaDefinitiva);
            this.pnlDerecho.Controls.Add(this.lblVistaPreliminar);
            this.pnlDerecho.Controls.Add(this.btnBorrar);
            this.pnlDerecho.Controls.Add(this.btnRegistrar);
            this.pnlDerecho.Controls.Add(this.tbcFactura);
            this.pnlDerecho.Controls.Add(this.lblFacturaPendiente);
            this.pnlDerecho.Location = new System.Drawing.Point(709, 12);
            this.pnlDerecho.Name = "pnlDerecho";
            this.pnlDerecho.Size = new System.Drawing.Size(649, 677);
            this.pnlDerecho.TabIndex = 3;
            // 
            // btnExportar
            // 
            this.btnExportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportar.Location = new System.Drawing.Point(279, 622);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(97, 35);
            this.btnExportar.TabIndex = 30;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnVistaDefinitiva
            // 
            this.btnVistaDefinitiva.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnVistaDefinitiva.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVistaDefinitiva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVistaDefinitiva.Location = new System.Drawing.Point(573, 12);
            this.btnVistaDefinitiva.Name = "btnVistaDefinitiva";
            this.btnVistaDefinitiva.Size = new System.Drawing.Size(68, 25);
            this.btnVistaDefinitiva.TabIndex = 16;
            this.btnVistaDefinitiva.Text = ">>";
            this.btnVistaDefinitiva.UseVisualStyleBackColor = false;
            this.btnVistaDefinitiva.Click += new System.EventHandler(this.btnVistaDefinitiva_Click);
            // 
            // lblVistaPreliminar
            // 
            this.lblVistaPreliminar.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lblVistaPreliminar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblVistaPreliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVistaPreliminar.Location = new System.Drawing.Point(430, 12);
            this.lblVistaPreliminar.Name = "lblVistaPreliminar";
            this.lblVistaPreliminar.Size = new System.Drawing.Size(137, 25);
            this.lblVistaPreliminar.TabIndex = 35;
            this.lblVistaPreliminar.Text = "Vista Preliminar";
            this.lblVistaPreliminar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBorrar
            // 
            this.btnBorrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBorrar.Location = new System.Drawing.Point(10, 622);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(97, 35);
            this.btnBorrar.TabIndex = 29;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrar.Location = new System.Drawing.Point(541, 622);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(97, 35);
            this.btnRegistrar.TabIndex = 31;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // tbcFactura
            // 
            this.tbcFactura.Controls.Add(this.tbpNroFactura);
            this.tbcFactura.Location = new System.Drawing.Point(3, 44);
            this.tbcFactura.Name = "tbcFactura";
            this.tbcFactura.SelectedIndex = 0;
            this.tbcFactura.Size = new System.Drawing.Size(645, 568);
            this.tbcFactura.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tbcFactura.TabIndex = 17;
            // 
            // tbpNroFactura
            // 
            this.tbpNroFactura.Controls.Add(this.btnVistaPreliminarFactura);
            this.tbpNroFactura.Controls.Add(this.btnVistaPreliminarRemito);
            this.tbpNroFactura.Controls.Add(this.txtRenglones);
            this.tbpNroFactura.Controls.Add(this.btnImprimirRemito);
            this.tbpNroFactura.Controls.Add(this.btnImprimirFactura);
            this.tbpNroFactura.Controls.Add(this.lblNroFactura);
            this.tbpNroFactura.Controls.Add(this.lblNroRemito);
            this.tbpNroFactura.Controls.Add(this.txtNroFactura);
            this.tbpNroFactura.Controls.Add(this.txtNroRemito);
            this.tbpNroFactura.Controls.Add(this.btnCambiarRemito);
            this.tbpNroFactura.Controls.Add(this.btnCambiarFactura);
            this.tbpNroFactura.Controls.Add(this.lblTipoFactura);
            this.tbpNroFactura.Controls.Add(this.lblDatosDelCliente);
            this.tbpNroFactura.Controls.Add(this.lblBonificacion);
            this.tbpNroFactura.Controls.Add(this.lblTotal);
            this.tbpNroFactura.Controls.Add(this.txtBonificacion);
            this.tbpNroFactura.Controls.Add(this.lblIva);
            this.tbpNroFactura.Controls.Add(this.txtTotal);
            this.tbpNroFactura.Controls.Add(this.lblSubtotal);
            this.tbpNroFactura.Controls.Add(this.txtIva);
            this.tbpNroFactura.Controls.Add(this.txtSubtotal);
            this.tbpNroFactura.Controls.Add(this.dgvFacturaPendiente);
            this.tbpNroFactura.Location = new System.Drawing.Point(4, 24);
            this.tbpNroFactura.Name = "tbpNroFactura";
            this.tbpNroFactura.Padding = new System.Windows.Forms.Padding(3);
            this.tbpNroFactura.Size = new System.Drawing.Size(637, 540);
            this.tbpNroFactura.TabIndex = 1;
            this.tbpNroFactura.Text = "F1";
            this.tbpNroFactura.UseVisualStyleBackColor = true;
            // 
            // btnVistaPreliminarFactura
            // 
            this.btnVistaPreliminarFactura.BackgroundImage = global::OFC.Properties.Resources.vista_preliminar1;
            this.btnVistaPreliminarFactura.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVistaPreliminarFactura.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVistaPreliminarFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnVistaPreliminarFactura.Location = new System.Drawing.Point(480, 500);
            this.btnVistaPreliminarFactura.Name = "btnVistaPreliminarFactura";
            this.btnVistaPreliminarFactura.Size = new System.Drawing.Size(48, 37);
            this.btnVistaPreliminarFactura.TabIndex = 37;
            this.btnVistaPreliminarFactura.UseVisualStyleBackColor = true;
            this.btnVistaPreliminarFactura.Click += new System.EventHandler(this.btnVistaPreliminarFactura_Click);
            // 
            // btnVistaPreliminarRemito
            // 
            this.btnVistaPreliminarRemito.BackgroundImage = global::OFC.Properties.Resources.vista_preliminar1;
            this.btnVistaPreliminarRemito.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVistaPreliminarRemito.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVistaPreliminarRemito.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnVistaPreliminarRemito.Location = new System.Drawing.Point(105, 500);
            this.btnVistaPreliminarRemito.Name = "btnVistaPreliminarRemito";
            this.btnVistaPreliminarRemito.Size = new System.Drawing.Size(48, 37);
            this.btnVistaPreliminarRemito.TabIndex = 36;
            this.btnVistaPreliminarRemito.UseVisualStyleBackColor = true;
            this.btnVistaPreliminarRemito.Click += new System.EventHandler(this.btnVistaPreliminarRemito_Click);
            // 
            // txtRenglones
            // 
            this.txtRenglones.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtRenglones.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtRenglones.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtRenglones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRenglones.Location = new System.Drawing.Point(287, 508);
            this.txtRenglones.MaxLength = 3;
            this.txtRenglones.Name = "txtRenglones";
            this.txtRenglones.ReadOnly = true;
            this.txtRenglones.Size = new System.Drawing.Size(39, 21);
            this.txtRenglones.TabIndex = 132;
            this.txtRenglones.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnImprimirRemito
            // 
            this.btnImprimirRemito.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimirRemito.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnImprimirRemito.Location = new System.Drawing.Point(3, 500);
            this.btnImprimirRemito.Name = "btnImprimirRemito";
            this.btnImprimirRemito.Size = new System.Drawing.Size(96, 37);
            this.btnImprimirRemito.TabIndex = 131;
            this.btnImprimirRemito.Text = "Imp. Remito";
            this.btnImprimirRemito.UseVisualStyleBackColor = true;
            this.btnImprimirRemito.Click += new System.EventHandler(this.btnImprimirRemito_Click);
            // 
            // btnImprimirFactura
            // 
            this.btnImprimirFactura.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimirFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnImprimirFactura.Location = new System.Drawing.Point(534, 500);
            this.btnImprimirFactura.Name = "btnImprimirFactura";
            this.btnImprimirFactura.Size = new System.Drawing.Size(96, 37);
            this.btnImprimirFactura.TabIndex = 130;
            this.btnImprimirFactura.Text = "Imp. Factura";
            this.btnImprimirFactura.UseVisualStyleBackColor = true;
            this.btnImprimirFactura.Click += new System.EventHandler(this.btnImprimirFactura_Click);
            // 
            // lblNroFactura
            // 
            this.lblNroFactura.AutoSize = true;
            this.lblNroFactura.Location = new System.Drawing.Point(343, 22);
            this.lblNroFactura.Name = "lblNroFactura";
            this.lblNroFactura.Size = new System.Drawing.Size(74, 15);
            this.lblNroFactura.TabIndex = 129;
            this.lblNroFactura.Text = "Nro. Factura";
            // 
            // lblNroRemito
            // 
            this.lblNroRemito.AutoSize = true;
            this.lblNroRemito.Location = new System.Drawing.Point(24, 22);
            this.lblNroRemito.Name = "lblNroRemito";
            this.lblNroRemito.Size = new System.Drawing.Size(73, 15);
            this.lblNroRemito.TabIndex = 128;
            this.lblNroRemito.Text = "Nro. Remito";
            // 
            // txtNroFactura
            // 
            this.txtNroFactura.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtNroFactura.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtNroFactura.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtNroFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroFactura.Location = new System.Drawing.Point(423, 19);
            this.txtNroFactura.MaxLength = 80;
            this.txtNroFactura.Name = "txtNroFactura";
            this.txtNroFactura.ReadOnly = true;
            this.txtNroFactura.Size = new System.Drawing.Size(120, 21);
            this.txtNroFactura.TabIndex = 19;
            this.txtNroFactura.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtNroRemito
            // 
            this.txtNroRemito.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtNroRemito.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtNroRemito.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtNroRemito.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroRemito.Location = new System.Drawing.Point(103, 19);
            this.txtNroRemito.MaxLength = 80;
            this.txtNroRemito.Name = "txtNroRemito";
            this.txtNroRemito.ReadOnly = true;
            this.txtNroRemito.Size = new System.Drawing.Size(120, 21);
            this.txtNroRemito.TabIndex = 17;
            this.txtNroRemito.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnCambiarRemito
            // 
            this.btnCambiarRemito.BackgroundImage = global::OFC.Properties.Resources.add1;
            this.btnCambiarRemito.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCambiarRemito.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCambiarRemito.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCambiarRemito.Location = new System.Drawing.Point(229, 18);
            this.btnCambiarRemito.Name = "btnCambiarRemito";
            this.btnCambiarRemito.Size = new System.Drawing.Size(63, 22);
            this.btnCambiarRemito.TabIndex = 18;
            this.btnCambiarRemito.UseVisualStyleBackColor = true;
            this.btnCambiarRemito.Click += new System.EventHandler(this.btnCambiarRemito_Click);
            // 
            // btnCambiarFactura
            // 
            this.btnCambiarFactura.BackgroundImage = global::OFC.Properties.Resources.add1;
            this.btnCambiarFactura.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCambiarFactura.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCambiarFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCambiarFactura.Location = new System.Drawing.Point(549, 18);
            this.btnCambiarFactura.Name = "btnCambiarFactura";
            this.btnCambiarFactura.Size = new System.Drawing.Size(63, 22);
            this.btnCambiarFactura.TabIndex = 20;
            this.btnCambiarFactura.UseVisualStyleBackColor = true;
            this.btnCambiarFactura.Click += new System.EventHandler(this.btnCambiarFactura_Click);
            // 
            // lblTipoFactura
            // 
            this.lblTipoFactura.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblTipoFactura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTipoFactura.Font = new System.Drawing.Font("Comic Sans MS", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoFactura.Location = new System.Drawing.Point(566, 58);
            this.lblTipoFactura.Name = "lblTipoFactura";
            this.lblTipoFactura.Size = new System.Drawing.Size(68, 68);
            this.lblTipoFactura.TabIndex = 22;
            this.lblTipoFactura.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDatosDelCliente
            // 
            this.lblDatosDelCliente.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblDatosDelCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDatosDelCliente.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.lblDatosDelCliente.Location = new System.Drawing.Point(3, 58);
            this.lblDatosDelCliente.Name = "lblDatosDelCliente";
            this.lblDatosDelCliente.Size = new System.Drawing.Size(557, 68);
            this.lblDatosDelCliente.TabIndex = 21;
            this.lblDatosDelCliente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBonificacion
            // 
            this.lblBonificacion.AutoSize = true;
            this.lblBonificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBonificacion.Location = new System.Drawing.Point(454, 439);
            this.lblBonificacion.Name = "lblBonificacion";
            this.lblBonificacion.Size = new System.Drawing.Size(74, 15);
            this.lblBonificacion.TabIndex = 123;
            this.lblBonificacion.Text = "Bonificación";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(494, 465);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(34, 15);
            this.lblTotal.TabIndex = 108;
            this.lblTotal.Text = "Total";
            // 
            // txtBonificacion
            // 
            this.txtBonificacion.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtBonificacion.Location = new System.Drawing.Point(534, 436);
            this.txtBonificacion.MaxLength = 80;
            this.txtBonificacion.Name = "txtBonificacion";
            this.txtBonificacion.ReadOnly = true;
            this.txtBonificacion.Size = new System.Drawing.Size(97, 21);
            this.txtBonificacion.TabIndex = 24;
            this.txtBonificacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblIva
            // 
            this.lblIva.AutoSize = true;
            this.lblIva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIva.Location = new System.Drawing.Point(259, 465);
            this.lblIva.Name = "lblIva";
            this.lblIva.Size = new System.Drawing.Size(22, 15);
            this.lblIva.TabIndex = 106;
            this.lblIva.Text = "Iva";
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtTotal.Location = new System.Drawing.Point(534, 462);
            this.txtTotal.MaxLength = 80;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(97, 21);
            this.txtTotal.TabIndex = 27;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal.Location = new System.Drawing.Point(5, 465);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(52, 15);
            this.lblSubtotal.TabIndex = 105;
            this.lblSubtotal.Text = "Subtotal";
            // 
            // txtIva
            // 
            this.txtIva.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtIva.Location = new System.Drawing.Point(287, 463);
            this.txtIva.MaxLength = 80;
            this.txtIva.Name = "txtIva";
            this.txtIva.ReadOnly = true;
            this.txtIva.Size = new System.Drawing.Size(97, 21);
            this.txtIva.TabIndex = 26;
            this.txtIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtSubtotal.Location = new System.Drawing.Point(63, 463);
            this.txtSubtotal.MaxLength = 80;
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.ReadOnly = true;
            this.txtSubtotal.Size = new System.Drawing.Size(97, 21);
            this.txtSubtotal.TabIndex = 25;
            this.txtSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dgvFacturaPendiente
            // 
            this.dgvFacturaPendiente.AllowUserToAddRows = false;
            this.dgvFacturaPendiente.AllowUserToDeleteRows = false;
            this.dgvFacturaPendiente.AllowUserToResizeColumns = false;
            this.dgvFacturaPendiente.AllowUserToResizeRows = false;
            this.dgvFacturaPendiente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFacturaPendiente.Location = new System.Drawing.Point(3, 129);
            this.dgvFacturaPendiente.MultiSelect = false;
            this.dgvFacturaPendiente.Name = "dgvFacturaPendiente";
            this.dgvFacturaPendiente.ReadOnly = true;
            this.dgvFacturaPendiente.RowHeadersVisible = false;
            this.dgvFacturaPendiente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFacturaPendiente.Size = new System.Drawing.Size(631, 290);
            this.dgvFacturaPendiente.TabIndex = 23;
            // 
            // lblFacturaPendiente
            // 
            this.lblFacturaPendiente.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblFacturaPendiente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFacturaPendiente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFacturaPendiente.Location = new System.Drawing.Point(3, 12);
            this.lblFacturaPendiente.Name = "lblFacturaPendiente";
            this.lblFacturaPendiente.Size = new System.Drawing.Size(421, 25);
            this.lblFacturaPendiente.TabIndex = 8;
            this.lblFacturaPendiente.Text = "Factura Pendiente";
            this.lblFacturaPendiente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlIzquierda1
            // 
            this.pnlIzquierda1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlIzquierda1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlIzquierda1.Controls.Add(this.cbhSoloRemito);
            this.pnlIzquierda1.Controls.Add(this.txtPorcentajeDeBonificacion);
            this.pnlIzquierda1.Controls.Add(this.lblBonificacionDelCliente);
            this.pnlIzquierda1.Controls.Add(this.cbhIva105);
            this.pnlIzquierda1.Controls.Add(this.btnXCliente);
            this.pnlIzquierda1.Controls.Add(this.cbhSoloFactura);
            this.pnlIzquierda1.Controls.Add(this.cbxNombreDelCliente);
            this.pnlIzquierda1.Controls.Add(this.lblNombreDelCliente);
            this.pnlIzquierda1.Controls.Add(this.cbxCodCliente);
            this.pnlIzquierda1.Controls.Add(this.lblDatosCliente);
            this.pnlIzquierda1.Controls.Add(this.lblCodCliente);
            this.pnlIzquierda1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlIzquierda1.Location = new System.Drawing.Point(12, 12);
            this.pnlIzquierda1.Name = "pnlIzquierda1";
            this.pnlIzquierda1.Size = new System.Drawing.Size(649, 169);
            this.pnlIzquierda1.TabIndex = 1;
            // 
            // cbhSoloRemito
            // 
            this.cbhSoloRemito.AutoSize = true;
            this.cbhSoloRemito.Location = new System.Drawing.Point(536, 80);
            this.cbhSoloRemito.Name = "cbhSoloRemito";
            this.cbhSoloRemito.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbhSoloRemito.Size = new System.Drawing.Size(94, 19);
            this.cbhSoloRemito.TabIndex = 5;
            this.cbhSoloRemito.Text = "Solo Remito";
            this.cbhSoloRemito.UseVisualStyleBackColor = true;
            // 
            // txtPorcentajeDeBonificacion
            // 
            this.txtPorcentajeDeBonificacion.Location = new System.Drawing.Point(135, 112);
            this.txtPorcentajeDeBonificacion.MaxLength = 5;
            this.txtPorcentajeDeBonificacion.Name = "txtPorcentajeDeBonificacion";
            this.txtPorcentajeDeBonificacion.Size = new System.Drawing.Size(57, 21);
            this.txtPorcentajeDeBonificacion.TabIndex = 3;
            this.txtPorcentajeDeBonificacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPorcentajeDeBonificacion_KeyPress);
            // 
            // lblBonificacionDelCliente
            // 
            this.lblBonificacionDelCliente.AutoSize = true;
            this.lblBonificacionDelCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBonificacionDelCliente.Location = new System.Drawing.Point(10, 115);
            this.lblBonificacionDelCliente.Name = "lblBonificacionDelCliente";
            this.lblBonificacionDelCliente.Size = new System.Drawing.Size(113, 15);
            this.lblBonificacionDelCliente.TabIndex = 113;
            this.lblBonificacionDelCliente.Text = "% Bonif. del Cliente";
            // 
            // cbhIva105
            // 
            this.cbhIva105.AutoSize = true;
            this.cbhIva105.Location = new System.Drawing.Point(551, 55);
            this.cbhIva105.Name = "cbhIva105";
            this.cbhIva105.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbhIva105.Size = new System.Drawing.Size(79, 19);
            this.cbhIva105.TabIndex = 4;
            this.cbhIva105.Text = "Iva 10.5%";
            this.cbhIva105.UseVisualStyleBackColor = true;
            // 
            // btnXCliente
            // 
            this.btnXCliente.BackColor = System.Drawing.Color.Transparent;
            this.btnXCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXCliente.Location = new System.Drawing.Point(562, 134);
            this.btnXCliente.Name = "btnXCliente";
            this.btnXCliente.Size = new System.Drawing.Size(68, 23);
            this.btnXCliente.TabIndex = 7;
            this.btnXCliente.Text = ">>";
            this.btnXCliente.UseVisualStyleBackColor = false;
            this.btnXCliente.Click += new System.EventHandler(this.btnXCliente_Click);
            // 
            // cbhSoloFactura
            // 
            this.cbhSoloFactura.AutoSize = true;
            this.cbhSoloFactura.Location = new System.Drawing.Point(535, 105);
            this.cbhSoloFactura.Name = "cbhSoloFactura";
            this.cbhSoloFactura.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbhSoloFactura.Size = new System.Drawing.Size(95, 19);
            this.cbhSoloFactura.TabIndex = 6;
            this.cbhSoloFactura.Text = "Solo Factura";
            this.cbhSoloFactura.UseVisualStyleBackColor = true;
            // 
            // cbxNombreDelCliente
            // 
            this.cbxNombreDelCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxNombreDelCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxNombreDelCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxNombreDelCliente.FormattingEnabled = true;
            this.cbxNombreDelCliente.Location = new System.Drawing.Point(135, 83);
            this.cbxNombreDelCliente.Name = "cbxNombreDelCliente";
            this.cbxNombreDelCliente.Size = new System.Drawing.Size(351, 23);
            this.cbxNombreDelCliente.TabIndex = 2;
            this.cbxNombreDelCliente.SelectedIndexChanged += new System.EventHandler(this.cbxNombreDelCliente_SelectedIndexChanged);
            // 
            // lblNombreDelCliente
            // 
            this.lblNombreDelCliente.AutoSize = true;
            this.lblNombreDelCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreDelCliente.Location = new System.Drawing.Point(10, 86);
            this.lblNombreDelCliente.Name = "lblNombreDelCliente";
            this.lblNombreDelCliente.Size = new System.Drawing.Size(113, 15);
            this.lblNombreDelCliente.TabIndex = 112;
            this.lblNombreDelCliente.Text = "Nombre del Cliente";
            // 
            // cbxCodCliente
            // 
            this.cbxCodCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxCodCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxCodCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxCodCliente.FormattingEnabled = true;
            this.cbxCodCliente.Location = new System.Drawing.Point(135, 55);
            this.cbxCodCliente.Name = "cbxCodCliente";
            this.cbxCodCliente.Size = new System.Drawing.Size(351, 23);
            this.cbxCodCliente.TabIndex = 1;
            this.cbxCodCliente.SelectedIndexChanged += new System.EventHandler(this.cbxCodCliente_SelectedIndexChanged);
            // 
            // lblDatosCliente
            // 
            this.lblDatosCliente.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblDatosCliente.Location = new System.Drawing.Point(3, 12);
            this.lblDatosCliente.Name = "lblDatosCliente";
            this.lblDatosCliente.Size = new System.Drawing.Size(641, 25);
            this.lblDatosCliente.TabIndex = 70;
            this.lblDatosCliente.Text = "Datos del Cliente y Factura";
            this.lblDatosCliente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCodCliente
            // 
            this.lblCodCliente.AutoSize = true;
            this.lblCodCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodCliente.Location = new System.Drawing.Point(10, 58);
            this.lblCodCliente.Name = "lblCodCliente";
            this.lblCodCliente.Size = new System.Drawing.Size(73, 15);
            this.lblCodCliente.TabIndex = 15;
            this.lblCodCliente.Text = "Cod. Cliente";
            // 
            // pnlIzquierda2
            // 
            this.pnlIzquierda2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlIzquierda2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlIzquierda2.Controls.Add(this.cbxCodProducto);
            this.pnlIzquierda2.Controls.Add(this.pictureBox1);
            this.pnlIzquierda2.Controls.Add(this.txtCodigoDeBarras);
            this.pnlIzquierda2.Controls.Add(this.btnXCalcular);
            this.pnlIzquierda2.Controls.Add(this.btnX);
            this.pnlIzquierda2.Controls.Add(this.pnlDatosCubierta);
            this.pnlIzquierda2.Controls.Add(this.rdbDescripcion);
            this.pnlIzquierda2.Controls.Add(this.btnProcesar);
            this.pnlIzquierda2.Controls.Add(this.rdbProducto);
            this.pnlIzquierda2.Controls.Add(this.txtDescripcion);
            this.pnlIzquierda2.Controls.Add(this.lblImporte);
            this.pnlIzquierda2.Controls.Add(this.lblPrecioUnitario);
            this.pnlIzquierda2.Controls.Add(this.txtPrecioUnitario);
            this.pnlIzquierda2.Controls.Add(this.txtImporte);
            this.pnlIzquierda2.Controls.Add(this.lblDatosDelItem);
            this.pnlIzquierda2.Controls.Add(this.txtCantidad);
            this.pnlIzquierda2.Controls.Add(this.lblCantidad);
            this.pnlIzquierda2.Controls.Add(this.cbxProducto);
            this.pnlIzquierda2.Location = new System.Drawing.Point(12, 187);
            this.pnlIzquierda2.Name = "pnlIzquierda2";
            this.pnlIzquierda2.Size = new System.Drawing.Size(649, 502);
            this.pnlIzquierda2.TabIndex = 2;
            // 
            // cbxCodProducto
            // 
            this.cbxCodProducto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxCodProducto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxCodProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxCodProducto.FormattingEnabled = true;
            this.cbxCodProducto.Location = new System.Drawing.Point(135, 118);
            this.cbxCodProducto.Name = "cbxCodProducto";
            this.cbxCodProducto.Size = new System.Drawing.Size(82, 23);
            this.cbxCodProducto.TabIndex = 5;
            this.cbxCodProducto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxCodProducto_KeyDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::OFC.Properties.Resources.codigo_de_barras;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(427, 172);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(202, 30);
            this.pictureBox1.TabIndex = 139;
            this.pictureBox1.TabStop = false;
            // 
            // txtCodigoDeBarras
            // 
            this.txtCodigoDeBarras.Location = new System.Drawing.Point(427, 145);
            this.txtCodigoDeBarras.MaxLength = 120;
            this.txtCodigoDeBarras.Name = "txtCodigoDeBarras";
            this.txtCodigoDeBarras.Size = new System.Drawing.Size(202, 21);
            this.txtCodigoDeBarras.TabIndex = 7;
            this.txtCodigoDeBarras.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoDeBarras_KeyDown);
            // 
            // btnXCalcular
            // 
            this.btnXCalcular.BackColor = System.Drawing.Color.Transparent;
            this.btnXCalcular.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXCalcular.Location = new System.Drawing.Point(561, 351);
            this.btnXCalcular.Name = "btnXCalcular";
            this.btnXCalcular.Size = new System.Drawing.Size(68, 23);
            this.btnXCalcular.TabIndex = 11;
            this.btnXCalcular.Text = ">>";
            this.btnXCalcular.UseVisualStyleBackColor = false;
            this.btnXCalcular.Click += new System.EventHandler(this.btnXCalcular_Click);
            // 
            // btnX
            // 
            this.btnX.BackColor = System.Drawing.Color.Transparent;
            this.btnX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnX.Location = new System.Drawing.Point(427, 308);
            this.btnX.Name = "btnX";
            this.btnX.Size = new System.Drawing.Size(68, 23);
            this.btnX.TabIndex = 9;
            this.btnX.Text = ">>";
            this.btnX.UseVisualStyleBackColor = false;
            this.btnX.Click += new System.EventHandler(this.btnX_Click);
            // 
            // pnlDatosCubierta
            // 
            this.pnlDatosCubierta.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlDatosCubierta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDatosCubierta.Controls.Add(this.cbxServicioAdicional);
            this.pnlDatosCubierta.Controls.Add(this.lblServicioAdicional);
            this.pnlDatosCubierta.Controls.Add(this.txtNroSerie);
            this.pnlDatosCubierta.Controls.Add(this.cbxMedidaDeCubierta);
            this.pnlDatosCubierta.Controls.Add(this.lblMedidaDeCubierta);
            this.pnlDatosCubierta.Controls.Add(this.lblTrabajoServicio);
            this.pnlDatosCubierta.Controls.Add(this.cbxTrabajoServicio);
            this.pnlDatosCubierta.Controls.Add(this.lblNroSerie);
            this.pnlDatosCubierta.Controls.Add(this.cbxMarca);
            this.pnlDatosCubierta.Controls.Add(this.lblMarca);
            this.pnlDatosCubierta.Controls.Add(this.txtCoche);
            this.pnlDatosCubierta.Controls.Add(this.lblCoche);
            this.pnlDatosCubierta.Location = new System.Drawing.Point(135, 147);
            this.pnlDatosCubierta.Name = "pnlDatosCubierta";
            this.pnlDatosCubierta.Size = new System.Drawing.Size(286, 184);
            this.pnlDatosCubierta.TabIndex = 8;
            // 
            // cbxServicioAdicional
            // 
            this.cbxServicioAdicional.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxServicioAdicional.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxServicioAdicional.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxServicioAdicional.FormattingEnabled = true;
            this.cbxServicioAdicional.Location = new System.Drawing.Point(128, 150);
            this.cbxServicioAdicional.Name = "cbxServicioAdicional";
            this.cbxServicioAdicional.Size = new System.Drawing.Size(143, 23);
            this.cbxServicioAdicional.TabIndex = 6;
            // 
            // lblServicioAdicional
            // 
            this.lblServicioAdicional.AutoSize = true;
            this.lblServicioAdicional.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServicioAdicional.Location = new System.Drawing.Point(7, 153);
            this.lblServicioAdicional.Name = "lblServicioAdicional";
            this.lblServicioAdicional.Size = new System.Drawing.Size(103, 15);
            this.lblServicioAdicional.TabIndex = 129;
            this.lblServicioAdicional.Text = "Servicio Adicional";
            // 
            // txtNroSerie
            // 
            this.txtNroSerie.Location = new System.Drawing.Point(128, 94);
            this.txtNroSerie.MaxLength = 10;
            this.txtNroSerie.Name = "txtNroSerie";
            this.txtNroSerie.Size = new System.Drawing.Size(143, 21);
            this.txtNroSerie.TabIndex = 4;
            // 
            // cbxMedidaDeCubierta
            // 
            this.cbxMedidaDeCubierta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxMedidaDeCubierta.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxMedidaDeCubierta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxMedidaDeCubierta.FormattingEnabled = true;
            this.cbxMedidaDeCubierta.Location = new System.Drawing.Point(128, 36);
            this.cbxMedidaDeCubierta.Name = "cbxMedidaDeCubierta";
            this.cbxMedidaDeCubierta.Size = new System.Drawing.Size(143, 23);
            this.cbxMedidaDeCubierta.TabIndex = 2;
            // 
            // lblMedidaDeCubierta
            // 
            this.lblMedidaDeCubierta.AutoSize = true;
            this.lblMedidaDeCubierta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMedidaDeCubierta.Location = new System.Drawing.Point(7, 39);
            this.lblMedidaDeCubierta.Name = "lblMedidaDeCubierta";
            this.lblMedidaDeCubierta.Size = new System.Drawing.Size(115, 15);
            this.lblMedidaDeCubierta.TabIndex = 118;
            this.lblMedidaDeCubierta.Text = "Medida de Cubierta";
            // 
            // lblTrabajoServicio
            // 
            this.lblTrabajoServicio.AutoSize = true;
            this.lblTrabajoServicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrabajoServicio.Location = new System.Drawing.Point(7, 124);
            this.lblTrabajoServicio.Name = "lblTrabajoServicio";
            this.lblTrabajoServicio.Size = new System.Drawing.Size(49, 15);
            this.lblTrabajoServicio.TabIndex = 119;
            this.lblTrabajoServicio.Text = "Trabajo";
            // 
            // cbxTrabajoServicio
            // 
            this.cbxTrabajoServicio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxTrabajoServicio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxTrabajoServicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxTrabajoServicio.FormattingEnabled = true;
            this.cbxTrabajoServicio.Location = new System.Drawing.Point(128, 121);
            this.cbxTrabajoServicio.Name = "cbxTrabajoServicio";
            this.cbxTrabajoServicio.Size = new System.Drawing.Size(143, 23);
            this.cbxTrabajoServicio.TabIndex = 5;
            // 
            // lblNroSerie
            // 
            this.lblNroSerie.AutoSize = true;
            this.lblNroSerie.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroSerie.Location = new System.Drawing.Point(7, 97);
            this.lblNroSerie.Name = "lblNroSerie";
            this.lblNroSerie.Size = new System.Drawing.Size(62, 15);
            this.lblNroSerie.TabIndex = 128;
            this.lblNroSerie.Text = "Nro. Serie";
            // 
            // cbxMarca
            // 
            this.cbxMarca.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxMarca.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxMarca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxMarca.FormattingEnabled = true;
            this.cbxMarca.Location = new System.Drawing.Point(128, 65);
            this.cbxMarca.Name = "cbxMarca";
            this.cbxMarca.Size = new System.Drawing.Size(143, 23);
            this.cbxMarca.TabIndex = 3;
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarca.Location = new System.Drawing.Point(7, 68);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(42, 15);
            this.lblMarca.TabIndex = 126;
            this.lblMarca.Text = "Marca";
            // 
            // txtCoche
            // 
            this.txtCoche.Location = new System.Drawing.Point(128, 9);
            this.txtCoche.MaxLength = 20;
            this.txtCoche.Name = "txtCoche";
            this.txtCoche.Size = new System.Drawing.Size(143, 21);
            this.txtCoche.TabIndex = 1;
            // 
            // lblCoche
            // 
            this.lblCoche.AutoSize = true;
            this.lblCoche.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCoche.Location = new System.Drawing.Point(7, 12);
            this.lblCoche.Name = "lblCoche";
            this.lblCoche.Size = new System.Drawing.Size(109, 15);
            this.lblCoche.TabIndex = 73;
            this.lblCoche.Text = "Subcliente \\ Coche";
            // 
            // rdbDescripcion
            // 
            this.rdbDescripcion.AutoSize = true;
            this.rdbDescripcion.Location = new System.Drawing.Point(13, 92);
            this.rdbDescripcion.Name = "rdbDescripcion";
            this.rdbDescripcion.Size = new System.Drawing.Size(90, 19);
            this.rdbDescripcion.TabIndex = 2;
            this.rdbDescripcion.TabStop = true;
            this.rdbDescripcion.Text = "Descripción";
            this.rdbDescripcion.UseVisualStyleBackColor = true;
            this.rdbDescripcion.CheckedChanged += new System.EventHandler(this.rdbDescripcion_CheckedChanged);
            // 
            // btnProcesar
            // 
            this.btnProcesar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProcesar.Location = new System.Drawing.Point(532, 447);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(97, 35);
            this.btnProcesar.TabIndex = 13;
            this.btnProcesar.Text = "Procesar >>";
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // rdbProducto
            // 
            this.rdbProducto.AutoSize = true;
            this.rdbProducto.Checked = true;
            this.rdbProducto.Location = new System.Drawing.Point(13, 119);
            this.rdbProducto.Name = "rdbProducto";
            this.rdbProducto.Size = new System.Drawing.Size(65, 19);
            this.rdbProducto.TabIndex = 4;
            this.rdbProducto.TabStop = true;
            this.rdbProducto.Text = "Artículo";
            this.rdbProducto.UseVisualStyleBackColor = true;
            this.rdbProducto.CheckedChanged += new System.EventHandler(this.rdbProducto_CheckedChanged);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(135, 91);
            this.txtDescripcion.MaxLength = 120;
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(494, 21);
            this.txtDescripcion.TabIndex = 3;
            // 
            // lblImporte
            // 
            this.lblImporte.AutoSize = true;
            this.lblImporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImporte.Location = new System.Drawing.Point(10, 383);
            this.lblImporte.Name = "lblImporte";
            this.lblImporte.Size = new System.Drawing.Size(84, 15);
            this.lblImporte.TabIndex = 138;
            this.lblImporte.Text = "Importe (s/iva)";
            // 
            // lblPrecioUnitario
            // 
            this.lblPrecioUnitario.AutoSize = true;
            this.lblPrecioUnitario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecioUnitario.Location = new System.Drawing.Point(10, 355);
            this.lblPrecioUnitario.Name = "lblPrecioUnitario";
            this.lblPrecioUnitario.Size = new System.Drawing.Size(123, 15);
            this.lblPrecioUnitario.TabIndex = 137;
            this.lblPrecioUnitario.Text = "Precio de Lista (s/iva)";
            // 
            // txtPrecioUnitario
            // 
            this.txtPrecioUnitario.Location = new System.Drawing.Point(135, 353);
            this.txtPrecioUnitario.MaxLength = 12;
            this.txtPrecioUnitario.Name = "txtPrecioUnitario";
            this.txtPrecioUnitario.Size = new System.Drawing.Size(420, 21);
            this.txtPrecioUnitario.TabIndex = 10;
            this.txtPrecioUnitario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioUnitario_KeyPress);
            // 
            // txtImporte
            // 
            this.txtImporte.Location = new System.Drawing.Point(135, 380);
            this.txtImporte.MaxLength = 12;
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.ReadOnly = true;
            this.txtImporte.Size = new System.Drawing.Size(494, 21);
            this.txtImporte.TabIndex = 12;
            this.txtImporte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImporte_KeyPress);
            // 
            // lblDatosDelItem
            // 
            this.lblDatosDelItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblDatosDelItem.Location = new System.Drawing.Point(3, 11);
            this.lblDatosDelItem.Name = "lblDatosDelItem";
            this.lblDatosDelItem.Size = new System.Drawing.Size(641, 25);
            this.lblDatosDelItem.TabIndex = 136;
            this.lblDatosDelItem.Text = "Datos del Item";
            this.lblDatosDelItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(135, 55);
            this.txtCantidad.MaxLength = 5;
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(494, 21);
            this.txtCantidad.TabIndex = 1;
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.Location = new System.Drawing.Point(10, 58);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(56, 15);
            this.lblCantidad.TabIndex = 135;
            this.lblCantidad.Text = "Cantidad";
            // 
            // cbxProducto
            // 
            this.cbxProducto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxProducto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxProducto.FormattingEnabled = true;
            this.cbxProducto.Location = new System.Drawing.Point(223, 118);
            this.cbxProducto.Name = "cbxProducto";
            this.cbxProducto.Size = new System.Drawing.Size(406, 23);
            this.cbxProducto.TabIndex = 6;
            this.cbxProducto.SelectedIndexChanged += new System.EventHandler(this.cbxProducto_SelectedIndexChanged);
            this.cbxProducto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxCodProducto_KeyDown);
            // 
            // frmFacturacionManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 730);
            this.Controls.Add(this.pnlIzquierda2);
            this.Controls.Add(this.pnlIzquierda1);
            this.Controls.Add(this.pnlDerecho);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmFacturacionManual";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facturación Manual";
            this.Load += new System.EventHandler(this.frmFacturacionManual_Load);
            this.pnlDerecho.ResumeLayout(false);
            this.tbcFactura.ResumeLayout(false);
            this.tbpNroFactura.ResumeLayout(false);
            this.tbpNroFactura.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturaPendiente)).EndInit();
            this.pnlIzquierda1.ResumeLayout(false);
            this.pnlIzquierda1.PerformLayout();
            this.pnlIzquierda2.ResumeLayout(false);
            this.pnlIzquierda2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlDatosCubierta.ResumeLayout(false);
            this.pnlDatosCubierta.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDerecho;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.TabControl tbcFactura;
        private System.Windows.Forms.TabPage tbpNroFactura;
        private System.Windows.Forms.Label lblBonificacion;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtBonificacion;
        private System.Windows.Forms.Label lblIva;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.TextBox txtIva;
        private System.Windows.Forms.TextBox txtSubtotal;
        private System.Windows.Forms.DataGridView dgvFacturaPendiente;
        private System.Windows.Forms.Label lblFacturaPendiente;
        private System.Windows.Forms.Panel pnlIzquierda1;
        private System.Windows.Forms.ComboBox cbxNombreDelCliente;
        private System.Windows.Forms.Label lblNombreDelCliente;
        private System.Windows.Forms.ComboBox cbxCodCliente;
        private System.Windows.Forms.Label lblDatosCliente;
        private System.Windows.Forms.Label lblCodCliente;
        private System.Windows.Forms.Label lblTipoFactura;
        private System.Windows.Forms.Label lblDatosDelCliente;
        private System.Windows.Forms.Button btnVistaDefinitiva;
        private System.Windows.Forms.Label lblVistaPreliminar;
        private System.Windows.Forms.CheckBox cbhSoloFactura;
        private System.Windows.Forms.Label lblNroFactura;
        private System.Windows.Forms.Label lblNroRemito;
        private System.Windows.Forms.TextBox txtNroFactura;
        private System.Windows.Forms.TextBox txtNroRemito;
        private System.Windows.Forms.Button btnCambiarRemito;
        private System.Windows.Forms.Button btnCambiarFactura;
        private System.Windows.Forms.Button btnXCliente;
        private System.Windows.Forms.Panel pnlIzquierda2;
        private System.Windows.Forms.Button btnX;
        private System.Windows.Forms.Panel pnlDatosCubierta;
        private System.Windows.Forms.TextBox txtNroSerie;
        private System.Windows.Forms.ComboBox cbxMedidaDeCubierta;
        private System.Windows.Forms.Label lblMedidaDeCubierta;
        private System.Windows.Forms.Label lblTrabajoServicio;
        private System.Windows.Forms.ComboBox cbxTrabajoServicio;
        private System.Windows.Forms.Label lblNroSerie;
        private System.Windows.Forms.ComboBox cbxMarca;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.TextBox txtCoche;
        private System.Windows.Forms.Label lblCoche;
        private System.Windows.Forms.RadioButton rdbDescripcion;
        private System.Windows.Forms.Button btnProcesar;
        private System.Windows.Forms.RadioButton rdbProducto;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblImporte;
        private System.Windows.Forms.Label lblPrecioUnitario;
        private System.Windows.Forms.TextBox txtPrecioUnitario;
        private System.Windows.Forms.TextBox txtImporte;
        private System.Windows.Forms.Label lblDatosDelItem;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.ComboBox cbxProducto;
        private System.Windows.Forms.Button btnXCalcular;
        private System.Windows.Forms.Button btnImprimirRemito;
        private System.Windows.Forms.Button btnImprimirFactura;
        private System.Windows.Forms.CheckBox cbhIva105;
        private System.Windows.Forms.TextBox txtRenglones;
        private System.Windows.Forms.TextBox txtCodigoDeBarras;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnVistaPreliminarFactura;
        private System.Windows.Forms.Button btnVistaPreliminarRemito;
        private System.Windows.Forms.ComboBox cbxCodProducto;
        private System.Windows.Forms.ComboBox cbxServicioAdicional;
        private System.Windows.Forms.Label lblServicioAdicional;
        private System.Windows.Forms.Label lblBonificacionDelCliente;
        private System.Windows.Forms.TextBox txtPorcentajeDeBonificacion;
        private System.Windows.Forms.CheckBox cbhSoloRemito;
        private System.Windows.Forms.Button btnExportar;
    }
}