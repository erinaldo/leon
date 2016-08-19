namespace OFC
{
    partial class frmNotaDeDebito
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
            this.pnlIzquierda = new System.Windows.Forms.Panel();
            this.rdbGravado = new System.Windows.Forms.RadioButton();
            this.rdbExento = new System.Windows.Forms.RadioButton();
            this.pnlGravado = new System.Windows.Forms.Panel();
            this.lblMotivoDeGasto = new System.Windows.Forms.Label();
            this.cbxMotivoDeGasto = new System.Windows.Forms.ComboBox();
            this.lblImporteGravado = new System.Windows.Forms.Label();
            this.lblDescripcionGravado = new System.Windows.Forms.Label();
            this.txtImporteGravado = new System.Windows.Forms.TextBox();
            this.txtDescripcionGravado = new System.Windows.Forms.TextBox();
            this.pnlExento = new System.Windows.Forms.Panel();
            this.lblDescripcionExento = new System.Windows.Forms.Label();
            this.txtFechaDeCheque = new System.Windows.Forms.TextBox();
            this.lblFechaDeCheque = new System.Windows.Forms.Label();
            this.txtDescripcionExento = new System.Windows.Forms.TextBox();
            this.txtBanco = new System.Windows.Forms.TextBox();
            this.txtImporteExento = new System.Windows.Forms.TextBox();
            this.lblBanco = new System.Windows.Forms.Label();
            this.lblImporteExento = new System.Windows.Forms.Label();
            this.txtNroDeCheque = new System.Windows.Forms.TextBox();
            this.lblNroDeCheque = new System.Windows.Forms.Label();
            this.btnXCliente = new System.Windows.Forms.Button();
            this.lblDatosDelItem = new System.Windows.Forms.Label();
            this.btnProcesar = new System.Windows.Forms.Button();
            this.cbxNombreDelCliente = new System.Windows.Forms.ComboBox();
            this.lblNombreDelCliente = new System.Windows.Forms.Label();
            this.cbxCodCliente = new System.Windows.Forms.ComboBox();
            this.lblDatosDeLaNotaDeDebito = new System.Windows.Forms.Label();
            this.lblCodCliente = new System.Windows.Forms.Label();
            this.pnlDerecho = new System.Windows.Forms.Panel();
            this.btnVistaDefinitiva = new System.Windows.Forms.Button();
            this.lblVistaPreliminar = new System.Windows.Forms.Label();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.tbcNotasDeDebito = new System.Windows.Forms.TabControl();
            this.tbpNroNotaDeDebito = new System.Windows.Forms.TabPage();
            this.btnVistaPreliminar = new System.Windows.Forms.Button();
            this.btnCambiarFactura = new System.Windows.Forms.Button();
            this.lblTipoFactura = new System.Windows.Forms.Label();
            this.lblDatosDelCliente = new System.Windows.Forms.Label();
            this.lblBonificacion = new System.Windows.Forms.Label();
            this.txtNroNotaDeDebito = new System.Windows.Forms.TextBox();
            this.lblNroNotaDeDebito = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtBonificacion = new System.Windows.Forms.TextBox();
            this.lblIva = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.txtIva = new System.Windows.Forms.TextBox();
            this.txtSubtotal = new System.Windows.Forms.TextBox();
            this.dgvNotasDeDebito = new System.Windows.Forms.DataGridView();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.lblNotasDeDebito = new System.Windows.Forms.Label();
            this.pnlIzquierda.SuspendLayout();
            this.pnlGravado.SuspendLayout();
            this.pnlExento.SuspendLayout();
            this.pnlDerecho.SuspendLayout();
            this.tbcNotasDeDebito.SuspendLayout();
            this.tbpNroNotaDeDebito.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotasDeDebito)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlIzquierda
            // 
            this.pnlIzquierda.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlIzquierda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlIzquierda.Controls.Add(this.rdbGravado);
            this.pnlIzquierda.Controls.Add(this.rdbExento);
            this.pnlIzquierda.Controls.Add(this.pnlGravado);
            this.pnlIzquierda.Controls.Add(this.pnlExento);
            this.pnlIzquierda.Controls.Add(this.btnXCliente);
            this.pnlIzquierda.Controls.Add(this.lblDatosDelItem);
            this.pnlIzquierda.Controls.Add(this.btnProcesar);
            this.pnlIzquierda.Controls.Add(this.cbxNombreDelCliente);
            this.pnlIzquierda.Controls.Add(this.lblNombreDelCliente);
            this.pnlIzquierda.Controls.Add(this.cbxCodCliente);
            this.pnlIzquierda.Controls.Add(this.lblDatosDeLaNotaDeDebito);
            this.pnlIzquierda.Controls.Add(this.lblCodCliente);
            this.pnlIzquierda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlIzquierda.Location = new System.Drawing.Point(12, 12);
            this.pnlIzquierda.Name = "pnlIzquierda";
            this.pnlIzquierda.Size = new System.Drawing.Size(649, 680);
            this.pnlIzquierda.TabIndex = 1;
            // 
            // rdbGravado
            // 
            this.rdbGravado.AutoSize = true;
            this.rdbGravado.BackColor = System.Drawing.Color.Transparent;
            this.rdbGravado.Location = new System.Drawing.Point(287, 315);
            this.rdbGravado.Name = "rdbGravado";
            this.rdbGravado.Size = new System.Drawing.Size(71, 19);
            this.rdbGravado.TabIndex = 5;
            this.rdbGravado.Text = "Gravado";
            this.rdbGravado.UseVisualStyleBackColor = false;
            this.rdbGravado.CheckedChanged += new System.EventHandler(this.rdbGravado_CheckedChanged);
            // 
            // rdbExento
            // 
            this.rdbExento.AutoSize = true;
            this.rdbExento.BackColor = System.Drawing.Color.Transparent;
            this.rdbExento.Checked = true;
            this.rdbExento.Location = new System.Drawing.Point(290, 141);
            this.rdbExento.Name = "rdbExento";
            this.rdbExento.Size = new System.Drawing.Size(63, 19);
            this.rdbExento.TabIndex = 4;
            this.rdbExento.TabStop = true;
            this.rdbExento.Text = "Exento";
            this.rdbExento.UseVisualStyleBackColor = false;
            this.rdbExento.CheckedChanged += new System.EventHandler(this.rdbExento_CheckedChanged);
            // 
            // pnlGravado
            // 
            this.pnlGravado.Controls.Add(this.lblMotivoDeGasto);
            this.pnlGravado.Controls.Add(this.cbxMotivoDeGasto);
            this.pnlGravado.Controls.Add(this.lblImporteGravado);
            this.pnlGravado.Controls.Add(this.lblDescripcionGravado);
            this.pnlGravado.Controls.Add(this.txtImporteGravado);
            this.pnlGravado.Controls.Add(this.txtDescripcionGravado);
            this.pnlGravado.Enabled = false;
            this.pnlGravado.Location = new System.Drawing.Point(16, 345);
            this.pnlGravado.Name = "pnlGravado";
            this.pnlGravado.Size = new System.Drawing.Size(612, 113);
            this.pnlGravado.TabIndex = 3;
            // 
            // lblMotivoDeGasto
            // 
            this.lblMotivoDeGasto.AutoSize = true;
            this.lblMotivoDeGasto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMotivoDeGasto.Location = new System.Drawing.Point(9, 21);
            this.lblMotivoDeGasto.Name = "lblMotivoDeGasto";
            this.lblMotivoDeGasto.Size = new System.Drawing.Size(95, 15);
            this.lblMotivoDeGasto.TabIndex = 135;
            this.lblMotivoDeGasto.Text = "Motivo de Gasto";
            // 
            // cbxMotivoDeGasto
            // 
            this.cbxMotivoDeGasto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxMotivoDeGasto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxMotivoDeGasto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxMotivoDeGasto.FormattingEnabled = true;
            this.cbxMotivoDeGasto.Location = new System.Drawing.Point(131, 18);
            this.cbxMotivoDeGasto.Name = "cbxMotivoDeGasto";
            this.cbxMotivoDeGasto.Size = new System.Drawing.Size(466, 23);
            this.cbxMotivoDeGasto.TabIndex = 1;
            // 
            // lblImporteGravado
            // 
            this.lblImporteGravado.AutoSize = true;
            this.lblImporteGravado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImporteGravado.Location = new System.Drawing.Point(9, 50);
            this.lblImporteGravado.Name = "lblImporteGravado";
            this.lblImporteGravado.Size = new System.Drawing.Size(49, 15);
            this.lblImporteGravado.TabIndex = 122;
            this.lblImporteGravado.Text = "Importe";
            // 
            // lblDescripcionGravado
            // 
            this.lblDescripcionGravado.AutoSize = true;
            this.lblDescripcionGravado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcionGravado.Location = new System.Drawing.Point(9, 77);
            this.lblDescripcionGravado.Name = "lblDescripcionGravado";
            this.lblDescripcionGravado.Size = new System.Drawing.Size(72, 15);
            this.lblDescripcionGravado.TabIndex = 134;
            this.lblDescripcionGravado.Text = "Descripción";
            // 
            // txtImporteGravado
            // 
            this.txtImporteGravado.Location = new System.Drawing.Point(131, 47);
            this.txtImporteGravado.MaxLength = 12;
            this.txtImporteGravado.Name = "txtImporteGravado";
            this.txtImporteGravado.Size = new System.Drawing.Size(466, 21);
            this.txtImporteGravado.TabIndex = 2;
            this.txtImporteGravado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImporteGravado_KeyPress);
            // 
            // txtDescripcionGravado
            // 
            this.txtDescripcionGravado.Location = new System.Drawing.Point(131, 74);
            this.txtDescripcionGravado.MaxLength = 20;
            this.txtDescripcionGravado.Name = "txtDescripcionGravado";
            this.txtDescripcionGravado.Size = new System.Drawing.Size(466, 21);
            this.txtDescripcionGravado.TabIndex = 3;
            // 
            // pnlExento
            // 
            this.pnlExento.Controls.Add(this.lblDescripcionExento);
            this.pnlExento.Controls.Add(this.txtFechaDeCheque);
            this.pnlExento.Controls.Add(this.lblFechaDeCheque);
            this.pnlExento.Controls.Add(this.txtDescripcionExento);
            this.pnlExento.Controls.Add(this.txtBanco);
            this.pnlExento.Controls.Add(this.txtImporteExento);
            this.pnlExento.Controls.Add(this.lblBanco);
            this.pnlExento.Controls.Add(this.lblImporteExento);
            this.pnlExento.Controls.Add(this.txtNroDeCheque);
            this.pnlExento.Controls.Add(this.lblNroDeCheque);
            this.pnlExento.Enabled = false;
            this.pnlExento.Location = new System.Drawing.Point(16, 170);
            this.pnlExento.Name = "pnlExento";
            this.pnlExento.Size = new System.Drawing.Size(612, 111);
            this.pnlExento.TabIndex = 2;
            // 
            // lblDescripcionExento
            // 
            this.lblDescripcionExento.AutoSize = true;
            this.lblDescripcionExento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcionExento.Location = new System.Drawing.Point(8, 20);
            this.lblDescripcionExento.Name = "lblDescripcionExento";
            this.lblDescripcionExento.Size = new System.Drawing.Size(72, 15);
            this.lblDescripcionExento.TabIndex = 127;
            this.lblDescripcionExento.Text = "Descripción";
            // 
            // txtFechaDeCheque
            // 
            this.txtFechaDeCheque.Location = new System.Drawing.Point(130, 71);
            this.txtFechaDeCheque.MaxLength = 10;
            this.txtFechaDeCheque.Name = "txtFechaDeCheque";
            this.txtFechaDeCheque.Size = new System.Drawing.Size(225, 21);
            this.txtFechaDeCheque.TabIndex = 4;
            // 
            // lblFechaDeCheque
            // 
            this.lblFechaDeCheque.AutoSize = true;
            this.lblFechaDeCheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaDeCheque.Location = new System.Drawing.Point(8, 74);
            this.lblFechaDeCheque.Name = "lblFechaDeCheque";
            this.lblFechaDeCheque.Size = new System.Drawing.Size(104, 15);
            this.lblFechaDeCheque.TabIndex = 119;
            this.lblFechaDeCheque.Text = "Fecha de Cheque";
            // 
            // txtDescripcionExento
            // 
            this.txtDescripcionExento.Location = new System.Drawing.Point(130, 17);
            this.txtDescripcionExento.MaxLength = 20;
            this.txtDescripcionExento.Name = "txtDescripcionExento";
            this.txtDescripcionExento.Size = new System.Drawing.Size(466, 21);
            this.txtDescripcionExento.TabIndex = 1;
            // 
            // txtBanco
            // 
            this.txtBanco.Location = new System.Drawing.Point(130, 44);
            this.txtBanco.MaxLength = 20;
            this.txtBanco.Name = "txtBanco";
            this.txtBanco.Size = new System.Drawing.Size(225, 21);
            this.txtBanco.TabIndex = 2;
            // 
            // txtImporteExento
            // 
            this.txtImporteExento.Location = new System.Drawing.Point(416, 71);
            this.txtImporteExento.MaxLength = 12;
            this.txtImporteExento.Name = "txtImporteExento";
            this.txtImporteExento.Size = new System.Drawing.Size(180, 21);
            this.txtImporteExento.TabIndex = 5;
            this.txtImporteExento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImporteExento_KeyPress);
            // 
            // lblBanco
            // 
            this.lblBanco.AutoSize = true;
            this.lblBanco.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBanco.Location = new System.Drawing.Point(8, 47);
            this.lblBanco.Name = "lblBanco";
            this.lblBanco.Size = new System.Drawing.Size(42, 15);
            this.lblBanco.TabIndex = 126;
            this.lblBanco.Text = "Banco";
            // 
            // lblImporteExento
            // 
            this.lblImporteExento.AutoSize = true;
            this.lblImporteExento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImporteExento.Location = new System.Drawing.Point(361, 74);
            this.lblImporteExento.Name = "lblImporteExento";
            this.lblImporteExento.Size = new System.Drawing.Size(49, 15);
            this.lblImporteExento.TabIndex = 129;
            this.lblImporteExento.Text = "Importe";
            // 
            // txtNroDeCheque
            // 
            this.txtNroDeCheque.Location = new System.Drawing.Point(460, 44);
            this.txtNroDeCheque.MaxLength = 10;
            this.txtNroDeCheque.Name = "txtNroDeCheque";
            this.txtNroDeCheque.Size = new System.Drawing.Size(136, 21);
            this.txtNroDeCheque.TabIndex = 3;
            // 
            // lblNroDeCheque
            // 
            this.lblNroDeCheque.AutoSize = true;
            this.lblNroDeCheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroDeCheque.Location = new System.Drawing.Point(361, 47);
            this.lblNroDeCheque.Name = "lblNroDeCheque";
            this.lblNroDeCheque.Size = new System.Drawing.Size(93, 15);
            this.lblNroDeCheque.TabIndex = 128;
            this.lblNroDeCheque.Text = "Nro. de Cheque";
            // 
            // btnXCliente
            // 
            this.btnXCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXCliente.Location = new System.Drawing.Point(574, 55);
            this.btnXCliente.Name = "btnXCliente";
            this.btnXCliente.Size = new System.Drawing.Size(56, 23);
            this.btnXCliente.TabIndex = 3;
            this.btnXCliente.Text = ">>";
            this.btnXCliente.UseVisualStyleBackColor = true;
            this.btnXCliente.Click += new System.EventHandler(this.btnXCliente_Click);
            // 
            // lblDatosDelItem
            // 
            this.lblDatosDelItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblDatosDelItem.Location = new System.Drawing.Point(3, 100);
            this.lblDatosDelItem.Name = "lblDatosDelItem";
            this.lblDatosDelItem.Size = new System.Drawing.Size(641, 25);
            this.lblDatosDelItem.TabIndex = 116;
            this.lblDatosDelItem.Text = "Datos del Item";
            this.lblDatosDelItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnProcesar
            // 
            this.btnProcesar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProcesar.Location = new System.Drawing.Point(531, 498);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(97, 35);
            this.btnProcesar.TabIndex = 6;
            this.btnProcesar.Text = "Procesar >>";
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // cbxNombreDelCliente
            // 
            this.cbxNombreDelCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxNombreDelCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxNombreDelCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxNombreDelCliente.FormattingEnabled = true;
            this.cbxNombreDelCliente.Location = new System.Drawing.Point(339, 56);
            this.cbxNombreDelCliente.Name = "cbxNombreDelCliente";
            this.cbxNombreDelCliente.Size = new System.Drawing.Size(229, 23);
            this.cbxNombreDelCliente.TabIndex = 2;
            this.cbxNombreDelCliente.SelectedIndexChanged += new System.EventHandler(this.cbxNombreDelCliente_SelectedIndexChanged);
            // 
            // lblNombreDelCliente
            // 
            this.lblNombreDelCliente.AutoSize = true;
            this.lblNombreDelCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreDelCliente.Location = new System.Drawing.Point(220, 59);
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
            this.cbxCodCliente.Location = new System.Drawing.Point(110, 56);
            this.cbxCodCliente.Name = "cbxCodCliente";
            this.cbxCodCliente.Size = new System.Drawing.Size(102, 23);
            this.cbxCodCliente.TabIndex = 1;
            this.cbxCodCliente.SelectedIndexChanged += new System.EventHandler(this.cbxCodCliente_SelectedIndexChanged);
            // 
            // lblDatosDeLaNotaDeDebito
            // 
            this.lblDatosDeLaNotaDeDebito.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblDatosDeLaNotaDeDebito.Location = new System.Drawing.Point(3, 12);
            this.lblDatosDeLaNotaDeDebito.Name = "lblDatosDeLaNotaDeDebito";
            this.lblDatosDeLaNotaDeDebito.Size = new System.Drawing.Size(641, 25);
            this.lblDatosDeLaNotaDeDebito.TabIndex = 70;
            this.lblDatosDeLaNotaDeDebito.Text = "Datos de la Nota de Débito";
            this.lblDatosDeLaNotaDeDebito.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCodCliente
            // 
            this.lblCodCliente.AutoSize = true;
            this.lblCodCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodCliente.Location = new System.Drawing.Point(13, 59);
            this.lblCodCliente.Name = "lblCodCliente";
            this.lblCodCliente.Size = new System.Drawing.Size(73, 15);
            this.lblCodCliente.TabIndex = 15;
            this.lblCodCliente.Text = "Cod. Cliente";
            // 
            // pnlDerecho
            // 
            this.pnlDerecho.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlDerecho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDerecho.Controls.Add(this.btnVistaDefinitiva);
            this.pnlDerecho.Controls.Add(this.lblVistaPreliminar);
            this.pnlDerecho.Controls.Add(this.btnBorrar);
            this.pnlDerecho.Controls.Add(this.btnRegistrar);
            this.pnlDerecho.Controls.Add(this.tbcNotasDeDebito);
            this.pnlDerecho.Controls.Add(this.lblNotasDeDebito);
            this.pnlDerecho.Location = new System.Drawing.Point(709, 12);
            this.pnlDerecho.Name = "pnlDerecho";
            this.pnlDerecho.Size = new System.Drawing.Size(649, 680);
            this.pnlDerecho.TabIndex = 4;
            // 
            // btnVistaDefinitiva
            // 
            this.btnVistaDefinitiva.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnVistaDefinitiva.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVistaDefinitiva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVistaDefinitiva.Location = new System.Drawing.Point(573, 12);
            this.btnVistaDefinitiva.Name = "btnVistaDefinitiva";
            this.btnVistaDefinitiva.Size = new System.Drawing.Size(63, 25);
            this.btnVistaDefinitiva.TabIndex = 2;
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
            this.lblVistaPreliminar.TabIndex = 1;
            this.lblVistaPreliminar.Text = "Vista Preliminar";
            this.lblVistaPreliminar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBorrar
            // 
            this.btnBorrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBorrar.Location = new System.Drawing.Point(7, 627);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(97, 35);
            this.btnBorrar.TabIndex = 13;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrar.Location = new System.Drawing.Point(541, 627);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(97, 35);
            this.btnRegistrar.TabIndex = 14;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // tbcNotasDeDebito
            // 
            this.tbcNotasDeDebito.Controls.Add(this.tbpNroNotaDeDebito);
            this.tbcNotasDeDebito.Location = new System.Drawing.Point(3, 44);
            this.tbcNotasDeDebito.Name = "tbcNotasDeDebito";
            this.tbcNotasDeDebito.SelectedIndex = 0;
            this.tbcNotasDeDebito.Size = new System.Drawing.Size(645, 572);
            this.tbcNotasDeDebito.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tbcNotasDeDebito.TabIndex = 17;
            // 
            // tbpNroNotaDeDebito
            // 
            this.tbpNroNotaDeDebito.Controls.Add(this.btnVistaPreliminar);
            this.tbpNroNotaDeDebito.Controls.Add(this.btnCambiarFactura);
            this.tbpNroNotaDeDebito.Controls.Add(this.lblTipoFactura);
            this.tbpNroNotaDeDebito.Controls.Add(this.lblDatosDelCliente);
            this.tbpNroNotaDeDebito.Controls.Add(this.lblBonificacion);
            this.tbpNroNotaDeDebito.Controls.Add(this.txtNroNotaDeDebito);
            this.tbpNroNotaDeDebito.Controls.Add(this.lblNroNotaDeDebito);
            this.tbpNroNotaDeDebito.Controls.Add(this.lblTotal);
            this.tbpNroNotaDeDebito.Controls.Add(this.txtBonificacion);
            this.tbpNroNotaDeDebito.Controls.Add(this.lblIva);
            this.tbpNroNotaDeDebito.Controls.Add(this.txtTotal);
            this.tbpNroNotaDeDebito.Controls.Add(this.lblSubtotal);
            this.tbpNroNotaDeDebito.Controls.Add(this.txtIva);
            this.tbpNroNotaDeDebito.Controls.Add(this.txtSubtotal);
            this.tbpNroNotaDeDebito.Controls.Add(this.dgvNotasDeDebito);
            this.tbpNroNotaDeDebito.Controls.Add(this.btnImprimir);
            this.tbpNroNotaDeDebito.Location = new System.Drawing.Point(4, 24);
            this.tbpNroNotaDeDebito.Name = "tbpNroNotaDeDebito";
            this.tbpNroNotaDeDebito.Padding = new System.Windows.Forms.Padding(3);
            this.tbpNroNotaDeDebito.Size = new System.Drawing.Size(637, 544);
            this.tbpNroNotaDeDebito.TabIndex = 1;
            this.tbpNroNotaDeDebito.Text = "F1";
            this.tbpNroNotaDeDebito.UseVisualStyleBackColor = true;
            // 
            // btnVistaPreliminar
            // 
            this.btnVistaPreliminar.BackgroundImage = global::OFC.Properties.Resources.vista_preliminar1;
            this.btnVistaPreliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVistaPreliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVistaPreliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnVistaPreliminar.Location = new System.Drawing.Point(480, 505);
            this.btnVistaPreliminar.Name = "btnVistaPreliminar";
            this.btnVistaPreliminar.Size = new System.Drawing.Size(48, 37);
            this.btnVistaPreliminar.TabIndex = 48;
            this.btnVistaPreliminar.UseVisualStyleBackColor = true;
            this.btnVistaPreliminar.Click += new System.EventHandler(this.btnVistaPreliminar_Click);
            // 
            // btnCambiarFactura
            // 
            this.btnCambiarFactura.BackgroundImage = global::OFC.Properties.Resources.add1;
            this.btnCambiarFactura.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCambiarFactura.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCambiarFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCambiarFactura.Location = new System.Drawing.Point(566, 17);
            this.btnCambiarFactura.Name = "btnCambiarFactura";
            this.btnCambiarFactura.Size = new System.Drawing.Size(63, 22);
            this.btnCambiarFactura.TabIndex = 4;
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
            this.lblTipoFactura.TabIndex = 6;
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
            this.lblDatosDelCliente.TabIndex = 5;
            this.lblDatosDelCliente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBonificacion
            // 
            this.lblBonificacion.AutoSize = true;
            this.lblBonificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBonificacion.Location = new System.Drawing.Point(454, 447);
            this.lblBonificacion.Name = "lblBonificacion";
            this.lblBonificacion.Size = new System.Drawing.Size(74, 15);
            this.lblBonificacion.TabIndex = 123;
            this.lblBonificacion.Text = "Bonificación";
            // 
            // txtNroNotaDeDebito
            // 
            this.txtNroNotaDeDebito.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtNroNotaDeDebito.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtNroNotaDeDebito.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtNroNotaDeDebito.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroNotaDeDebito.Location = new System.Drawing.Point(131, 19);
            this.txtNroNotaDeDebito.MaxLength = 80;
            this.txtNroNotaDeDebito.Name = "txtNroNotaDeDebito";
            this.txtNroNotaDeDebito.Size = new System.Drawing.Size(429, 21);
            this.txtNroNotaDeDebito.TabIndex = 3;
            this.txtNroNotaDeDebito.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblNroNotaDeDebito
            // 
            this.lblNroNotaDeDebito.AutoSize = true;
            this.lblNroNotaDeDebito.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroNotaDeDebito.Location = new System.Drawing.Point(7, 21);
            this.lblNroNotaDeDebito.Name = "lblNroNotaDeDebito";
            this.lblNroNotaDeDebito.Size = new System.Drawing.Size(115, 15);
            this.lblNroNotaDeDebito.TabIndex = 116;
            this.lblNroNotaDeDebito.Text = "Nro. Nota de Débito";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(494, 474);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(34, 15);
            this.lblTotal.TabIndex = 108;
            this.lblTotal.Text = "Total";
            // 
            // txtBonificacion
            // 
            this.txtBonificacion.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtBonificacion.Location = new System.Drawing.Point(534, 444);
            this.txtBonificacion.MaxLength = 80;
            this.txtBonificacion.Name = "txtBonificacion";
            this.txtBonificacion.ReadOnly = true;
            this.txtBonificacion.Size = new System.Drawing.Size(97, 21);
            this.txtBonificacion.TabIndex = 8;
            this.txtBonificacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblIva
            // 
            this.lblIva.AutoSize = true;
            this.lblIva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIva.Location = new System.Drawing.Point(259, 473);
            this.lblIva.Name = "lblIva";
            this.lblIva.Size = new System.Drawing.Size(22, 15);
            this.lblIva.TabIndex = 106;
            this.lblIva.Text = "Iva";
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtTotal.Location = new System.Drawing.Point(534, 471);
            this.txtTotal.MaxLength = 80;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(97, 21);
            this.txtTotal.TabIndex = 11;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal.Location = new System.Drawing.Point(5, 473);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(52, 15);
            this.lblSubtotal.TabIndex = 105;
            this.lblSubtotal.Text = "Subtotal";
            // 
            // txtIva
            // 
            this.txtIva.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtIva.Location = new System.Drawing.Point(287, 471);
            this.txtIva.MaxLength = 80;
            this.txtIva.Name = "txtIva";
            this.txtIva.ReadOnly = true;
            this.txtIva.Size = new System.Drawing.Size(97, 21);
            this.txtIva.TabIndex = 10;
            this.txtIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtSubtotal.Location = new System.Drawing.Point(63, 471);
            this.txtSubtotal.MaxLength = 80;
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.ReadOnly = true;
            this.txtSubtotal.Size = new System.Drawing.Size(97, 21);
            this.txtSubtotal.TabIndex = 9;
            this.txtSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dgvNotasDeDebito
            // 
            this.dgvNotasDeDebito.AllowUserToAddRows = false;
            this.dgvNotasDeDebito.AllowUserToDeleteRows = false;
            this.dgvNotasDeDebito.AllowUserToResizeColumns = false;
            this.dgvNotasDeDebito.AllowUserToResizeRows = false;
            this.dgvNotasDeDebito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNotasDeDebito.Location = new System.Drawing.Point(3, 129);
            this.dgvNotasDeDebito.MultiSelect = false;
            this.dgvNotasDeDebito.Name = "dgvNotasDeDebito";
            this.dgvNotasDeDebito.ReadOnly = true;
            this.dgvNotasDeDebito.RowHeadersVisible = false;
            this.dgvNotasDeDebito.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNotasDeDebito.Size = new System.Drawing.Size(631, 303);
            this.dgvNotasDeDebito.TabIndex = 7;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.Location = new System.Drawing.Point(534, 506);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(97, 35);
            this.btnImprimir.TabIndex = 12;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // lblNotasDeDebito
            // 
            this.lblNotasDeDebito.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblNotasDeDebito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNotasDeDebito.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotasDeDebito.Location = new System.Drawing.Point(3, 12);
            this.lblNotasDeDebito.Name = "lblNotasDeDebito";
            this.lblNotasDeDebito.Size = new System.Drawing.Size(421, 25);
            this.lblNotasDeDebito.TabIndex = 8;
            this.lblNotasDeDebito.Text = "Notas de Débito Pendiente";
            this.lblNotasDeDebito.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmNotaDeDebito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 730);
            this.Controls.Add(this.pnlDerecho);
            this.Controls.Add(this.pnlIzquierda);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmNotaDeDebito";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nota de Débito";
            this.Load += new System.EventHandler(this.frmNotaDeDebito_Load);
            this.pnlIzquierda.ResumeLayout(false);
            this.pnlIzquierda.PerformLayout();
            this.pnlGravado.ResumeLayout(false);
            this.pnlGravado.PerformLayout();
            this.pnlExento.ResumeLayout(false);
            this.pnlExento.PerformLayout();
            this.pnlDerecho.ResumeLayout(false);
            this.tbcNotasDeDebito.ResumeLayout(false);
            this.tbpNroNotaDeDebito.ResumeLayout(false);
            this.tbpNroNotaDeDebito.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotasDeDebito)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlIzquierda;
        private System.Windows.Forms.ComboBox cbxNombreDelCliente;
        private System.Windows.Forms.Label lblNombreDelCliente;
        private System.Windows.Forms.ComboBox cbxCodCliente;
        private System.Windows.Forms.ComboBox cbxMotivoDeGasto;
        private System.Windows.Forms.Label lblDatosDeLaNotaDeDebito;
        private System.Windows.Forms.Label lblCodCliente;
        private System.Windows.Forms.Button btnProcesar;
        private System.Windows.Forms.Panel pnlDerecho;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.TabControl tbcNotasDeDebito;
        private System.Windows.Forms.TabPage tbpNroNotaDeDebito;
        private System.Windows.Forms.Label lblBonificacion;
        private System.Windows.Forms.TextBox txtNroNotaDeDebito;
        private System.Windows.Forms.Label lblNroNotaDeDebito;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtBonificacion;
        private System.Windows.Forms.Label lblIva;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.TextBox txtIva;
        private System.Windows.Forms.TextBox txtSubtotal;
        private System.Windows.Forms.DataGridView dgvNotasDeDebito;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Label lblNotasDeDebito;
        private System.Windows.Forms.TextBox txtDescripcionExento;
        private System.Windows.Forms.TextBox txtImporteGravado;
        private System.Windows.Forms.Label lblImporteGravado;
        private System.Windows.Forms.Label lblDatosDelItem;
        private System.Windows.Forms.Label lblTipoFactura;
        private System.Windows.Forms.Label lblDatosDelCliente;
        private System.Windows.Forms.Button btnCambiarFactura;
        private System.Windows.Forms.Button btnVistaDefinitiva;
        private System.Windows.Forms.Label lblVistaPreliminar;
        private System.Windows.Forms.Button btnXCliente;
        private System.Windows.Forms.Label lblFechaDeCheque;
        private System.Windows.Forms.TextBox txtFechaDeCheque;
        private System.Windows.Forms.TextBox txtImporteExento;
        private System.Windows.Forms.Label lblImporteExento;
        private System.Windows.Forms.Label lblNroDeCheque;
        private System.Windows.Forms.TextBox txtNroDeCheque;
        private System.Windows.Forms.Label lblBanco;
        private System.Windows.Forms.TextBox txtBanco;
        private System.Windows.Forms.Label lblDescripcionGravado;
        private System.Windows.Forms.TextBox txtDescripcionGravado;
        private System.Windows.Forms.Panel pnlGravado;
        private System.Windows.Forms.Panel pnlExento;
        private System.Windows.Forms.RadioButton rdbGravado;
        private System.Windows.Forms.RadioButton rdbExento;
        private System.Windows.Forms.Label lblMotivoDeGasto;
        private System.Windows.Forms.Label lblDescripcionExento;
        private System.Windows.Forms.Button btnVistaPreliminar;
    }
}