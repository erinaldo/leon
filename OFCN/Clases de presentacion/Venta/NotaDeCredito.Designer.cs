namespace OFC
{
    partial class frmNotaDeCredito
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
            this.btnXCliente = new System.Windows.Forms.Button();
            this.lblDatosDelItem = new System.Windows.Forms.Label();
            this.btnX = new System.Windows.Forms.Button();
            this.txtNroFactura = new System.Windows.Forms.TextBox();
            this.cbxNombreDelCliente = new System.Windows.Forms.ComboBox();
            this.lblNombreDelCliente = new System.Windows.Forms.Label();
            this.cbxCodCliente = new System.Windows.Forms.ComboBox();
            this.cbxMotivo = new System.Windows.Forms.ComboBox();
            this.btnProcesar = new System.Windows.Forms.Button();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.txtDetalle = new System.Windows.Forms.TextBox();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.lblDatosDelClienteForm = new System.Windows.Forms.Label();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.lblImporte = new System.Windows.Forms.Label();
            this.lblCodCliente = new System.Windows.Forms.Label();
            this.pnlDerecho = new System.Windows.Forms.Panel();
            this.btnVistaDefinitiva = new System.Windows.Forms.Button();
            this.lblVistaPreliminar = new System.Windows.Forms.Label();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.tbcNotasDeCredito = new System.Windows.Forms.TabControl();
            this.tbpNroNotaDeCredito = new System.Windows.Forms.TabPage();
            this.btnVistaPreliminar = new System.Windows.Forms.Button();
            this.lblTipoFactura = new System.Windows.Forms.Label();
            this.lblNroNotaDeCredito = new System.Windows.Forms.Label();
            this.lblDatosDelCliente = new System.Windows.Forms.Label();
            this.txtNroNotaDeCredito = new System.Windows.Forms.TextBox();
            this.btnCambiarFactura = new System.Windows.Forms.Button();
            this.lblBonificacion = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtBonificacion = new System.Windows.Forms.TextBox();
            this.lblIva = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.txtIva = new System.Windows.Forms.TextBox();
            this.txtSubtotal = new System.Windows.Forms.TextBox();
            this.dgvNotasDeCredito = new System.Windows.Forms.DataGridView();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.lblNotasDeCredito = new System.Windows.Forms.Label();
            this.lblNroFactura = new System.Windows.Forms.Label();
            this.pnlIzquierda.SuspendLayout();
            this.pnlDerecho.SuspendLayout();
            this.tbcNotasDeCredito.SuspendLayout();
            this.tbpNroNotaDeCredito.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotasDeCredito)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlIzquierda
            // 
            this.pnlIzquierda.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlIzquierda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlIzquierda.Controls.Add(this.lblNroFactura);
            this.pnlIzquierda.Controls.Add(this.btnXCliente);
            this.pnlIzquierda.Controls.Add(this.lblDatosDelItem);
            this.pnlIzquierda.Controls.Add(this.btnX);
            this.pnlIzquierda.Controls.Add(this.txtNroFactura);
            this.pnlIzquierda.Controls.Add(this.cbxNombreDelCliente);
            this.pnlIzquierda.Controls.Add(this.lblNombreDelCliente);
            this.pnlIzquierda.Controls.Add(this.cbxCodCliente);
            this.pnlIzquierda.Controls.Add(this.cbxMotivo);
            this.pnlIzquierda.Controls.Add(this.btnProcesar);
            this.pnlIzquierda.Controls.Add(this.lblDetalle);
            this.pnlIzquierda.Controls.Add(this.txtDetalle);
            this.pnlIzquierda.Controls.Add(this.lblMotivo);
            this.pnlIzquierda.Controls.Add(this.lblDatosDelClienteForm);
            this.pnlIzquierda.Controls.Add(this.txtImporte);
            this.pnlIzquierda.Controls.Add(this.lblImporte);
            this.pnlIzquierda.Controls.Add(this.lblCodCliente);
            this.pnlIzquierda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlIzquierda.Location = new System.Drawing.Point(12, 12);
            this.pnlIzquierda.Name = "pnlIzquierda";
            this.pnlIzquierda.Size = new System.Drawing.Size(649, 684);
            this.pnlIzquierda.TabIndex = 1;
            // 
            // btnXCliente
            // 
            this.btnXCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXCliente.Location = new System.Drawing.Point(575, 55);
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
            this.lblDatosDelItem.Location = new System.Drawing.Point(3, 103);
            this.lblDatosDelItem.Name = "lblDatosDelItem";
            this.lblDatosDelItem.Size = new System.Drawing.Size(641, 25);
            this.lblDatosDelItem.TabIndex = 113;
            this.lblDatosDelItem.Text = "Datos del Item";
            this.lblDatosDelItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnX
            // 
            this.btnX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnX.Location = new System.Drawing.Point(575, 175);
            this.btnX.Name = "btnX";
            this.btnX.Size = new System.Drawing.Size(56, 23);
            this.btnX.TabIndex = 6;
            this.btnX.Text = ">>";
            this.btnX.UseVisualStyleBackColor = true;
            this.btnX.Click += new System.EventHandler(this.btnX_Click);
            // 
            // txtNroFactura
            // 
            this.txtNroFactura.Location = new System.Drawing.Point(139, 176);
            this.txtNroFactura.MaxLength = 20;
            this.txtNroFactura.Name = "txtNroFactura";
            this.txtNroFactura.Size = new System.Drawing.Size(430, 21);
            this.txtNroFactura.TabIndex = 5;
            this.txtNroFactura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNroFactura_KeyPress);
            // 
            // cbxNombreDelCliente
            // 
            this.cbxNombreDelCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxNombreDelCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxNombreDelCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxNombreDelCliente.FormattingEnabled = true;
            this.cbxNombreDelCliente.Location = new System.Drawing.Point(319, 56);
            this.cbxNombreDelCliente.Name = "cbxNombreDelCliente";
            this.cbxNombreDelCliente.Size = new System.Drawing.Size(250, 23);
            this.cbxNombreDelCliente.TabIndex = 2;
            this.cbxNombreDelCliente.SelectedIndexChanged += new System.EventHandler(this.cbxNombreDelCliente_SelectedIndexChanged);
            // 
            // lblNombreDelCliente
            // 
            this.lblNombreDelCliente.AutoSize = true;
            this.lblNombreDelCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreDelCliente.Location = new System.Drawing.Point(200, 58);
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
            this.cbxCodCliente.Location = new System.Drawing.Point(93, 55);
            this.cbxCodCliente.Name = "cbxCodCliente";
            this.cbxCodCliente.Size = new System.Drawing.Size(101, 23);
            this.cbxCodCliente.TabIndex = 1;
            this.cbxCodCliente.SelectedIndexChanged += new System.EventHandler(this.cbxCodCliente_SelectedIndexChanged);
            // 
            // cbxMotivo
            // 
            this.cbxMotivo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxMotivo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxMotivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxMotivo.FormattingEnabled = true;
            this.cbxMotivo.Location = new System.Drawing.Point(94, 147);
            this.cbxMotivo.Name = "cbxMotivo";
            this.cbxMotivo.Size = new System.Drawing.Size(537, 23);
            this.cbxMotivo.TabIndex = 4;
            // 
            // btnProcesar
            // 
            this.btnProcesar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProcesar.Location = new System.Drawing.Point(534, 299);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(97, 35);
            this.btnProcesar.TabIndex = 9;
            this.btnProcesar.Text = "Procesar >>";
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // lblDetalle
            // 
            this.lblDetalle.AutoSize = true;
            this.lblDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalle.Location = new System.Drawing.Point(14, 233);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Size = new System.Drawing.Size(46, 15);
            this.lblDetalle.TabIndex = 76;
            this.lblDetalle.Text = "Detalle";
            // 
            // txtDetalle
            // 
            this.txtDetalle.Location = new System.Drawing.Point(93, 230);
            this.txtDetalle.MaxLength = 80;
            this.txtDetalle.Name = "txtDetalle";
            this.txtDetalle.Size = new System.Drawing.Size(538, 21);
            this.txtDetalle.TabIndex = 8;
            // 
            // lblMotivo
            // 
            this.lblMotivo.AutoSize = true;
            this.lblMotivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMotivo.Location = new System.Drawing.Point(14, 150);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(43, 15);
            this.lblMotivo.TabIndex = 73;
            this.lblMotivo.Text = "Motivo";
            // 
            // lblDatosDelClienteForm
            // 
            this.lblDatosDelClienteForm.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblDatosDelClienteForm.Location = new System.Drawing.Point(3, 12);
            this.lblDatosDelClienteForm.Name = "lblDatosDelClienteForm";
            this.lblDatosDelClienteForm.Size = new System.Drawing.Size(641, 25);
            this.lblDatosDelClienteForm.TabIndex = 70;
            this.lblDatosDelClienteForm.Text = "Datos del Cliente";
            this.lblDatosDelClienteForm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtImporte
            // 
            this.txtImporte.Location = new System.Drawing.Point(93, 203);
            this.txtImporte.MaxLength = 12;
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(538, 21);
            this.txtImporte.TabIndex = 7;
            this.txtImporte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImporte_KeyPress);
            // 
            // lblImporte
            // 
            this.lblImporte.AutoSize = true;
            this.lblImporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImporte.Location = new System.Drawing.Point(15, 206);
            this.lblImporte.Name = "lblImporte";
            this.lblImporte.Size = new System.Drawing.Size(49, 15);
            this.lblImporte.TabIndex = 17;
            this.lblImporte.Text = "Importe";
            // 
            // lblCodCliente
            // 
            this.lblCodCliente.AutoSize = true;
            this.lblCodCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodCliente.Location = new System.Drawing.Point(14, 58);
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
            this.pnlDerecho.Controls.Add(this.tbcNotasDeCredito);
            this.pnlDerecho.Controls.Add(this.lblNotasDeCredito);
            this.pnlDerecho.Location = new System.Drawing.Point(709, 12);
            this.pnlDerecho.Name = "pnlDerecho";
            this.pnlDerecho.Size = new System.Drawing.Size(649, 684);
            this.pnlDerecho.TabIndex = 2;
            // 
            // btnVistaDefinitiva
            // 
            this.btnVistaDefinitiva.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnVistaDefinitiva.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVistaDefinitiva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVistaDefinitiva.Location = new System.Drawing.Point(573, 12);
            this.btnVistaDefinitiva.Name = "btnVistaDefinitiva";
            this.btnVistaDefinitiva.Size = new System.Drawing.Size(63, 25);
            this.btnVistaDefinitiva.TabIndex = 1;
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
            this.lblVistaPreliminar.TabIndex = 46;
            this.lblVistaPreliminar.Text = "Vista Preliminar";
            this.lblVistaPreliminar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBorrar
            // 
            this.btnBorrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBorrar.Location = new System.Drawing.Point(10, 630);
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
            this.btnRegistrar.Location = new System.Drawing.Point(541, 630);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(97, 35);
            this.btnRegistrar.TabIndex = 14;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // tbcNotasDeCredito
            // 
            this.tbcNotasDeCredito.Controls.Add(this.tbpNroNotaDeCredito);
            this.tbcNotasDeCredito.Location = new System.Drawing.Point(3, 44);
            this.tbcNotasDeCredito.Name = "tbcNotasDeCredito";
            this.tbcNotasDeCredito.SelectedIndex = 0;
            this.tbcNotasDeCredito.Size = new System.Drawing.Size(645, 579);
            this.tbcNotasDeCredito.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tbcNotasDeCredito.TabIndex = 2;
            // 
            // tbpNroNotaDeCredito
            // 
            this.tbpNroNotaDeCredito.Controls.Add(this.btnVistaPreliminar);
            this.tbpNroNotaDeCredito.Controls.Add(this.lblTipoFactura);
            this.tbpNroNotaDeCredito.Controls.Add(this.lblNroNotaDeCredito);
            this.tbpNroNotaDeCredito.Controls.Add(this.lblDatosDelCliente);
            this.tbpNroNotaDeCredito.Controls.Add(this.txtNroNotaDeCredito);
            this.tbpNroNotaDeCredito.Controls.Add(this.btnCambiarFactura);
            this.tbpNroNotaDeCredito.Controls.Add(this.lblBonificacion);
            this.tbpNroNotaDeCredito.Controls.Add(this.lblTotal);
            this.tbpNroNotaDeCredito.Controls.Add(this.txtBonificacion);
            this.tbpNroNotaDeCredito.Controls.Add(this.lblIva);
            this.tbpNroNotaDeCredito.Controls.Add(this.txtTotal);
            this.tbpNroNotaDeCredito.Controls.Add(this.lblSubtotal);
            this.tbpNroNotaDeCredito.Controls.Add(this.txtIva);
            this.tbpNroNotaDeCredito.Controls.Add(this.txtSubtotal);
            this.tbpNroNotaDeCredito.Controls.Add(this.dgvNotasDeCredito);
            this.tbpNroNotaDeCredito.Controls.Add(this.btnImprimir);
            this.tbpNroNotaDeCredito.Location = new System.Drawing.Point(4, 24);
            this.tbpNroNotaDeCredito.Name = "tbpNroNotaDeCredito";
            this.tbpNroNotaDeCredito.Padding = new System.Windows.Forms.Padding(3);
            this.tbpNroNotaDeCredito.Size = new System.Drawing.Size(637, 551);
            this.tbpNroNotaDeCredito.TabIndex = 1;
            this.tbpNroNotaDeCredito.Text = "F1";
            this.tbpNroNotaDeCredito.UseVisualStyleBackColor = true;
            // 
            // btnVistaPreliminar
            // 
            this.btnVistaPreliminar.BackgroundImage = global::OFC.Properties.Resources.vista_preliminar1;
            this.btnVistaPreliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVistaPreliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVistaPreliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnVistaPreliminar.Location = new System.Drawing.Point(480, 509);
            this.btnVistaPreliminar.Name = "btnVistaPreliminar";
            this.btnVistaPreliminar.Size = new System.Drawing.Size(48, 37);
            this.btnVistaPreliminar.TabIndex = 47;
            this.btnVistaPreliminar.UseVisualStyleBackColor = true;
            this.btnVistaPreliminar.Click += new System.EventHandler(this.btnVistaPreliminar_Click);
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
            // lblNroNotaDeCredito
            // 
            this.lblNroNotaDeCredito.AutoSize = true;
            this.lblNroNotaDeCredito.Location = new System.Drawing.Point(3, 24);
            this.lblNroNotaDeCredito.Name = "lblNroNotaDeCredito";
            this.lblNroNotaDeCredito.Size = new System.Drawing.Size(118, 15);
            this.lblNroNotaDeCredito.TabIndex = 130;
            this.lblNroNotaDeCredito.Text = "Nro. Nota de Crédito";
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
            // txtNroNotaDeCredito
            // 
            this.txtNroNotaDeCredito.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtNroNotaDeCredito.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtNroNotaDeCredito.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtNroNotaDeCredito.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroNotaDeCredito.Location = new System.Drawing.Point(127, 21);
            this.txtNroNotaDeCredito.MaxLength = 80;
            this.txtNroNotaDeCredito.Name = "txtNroNotaDeCredito";
            this.txtNroNotaDeCredito.ReadOnly = true;
            this.txtNroNotaDeCredito.Size = new System.Drawing.Size(433, 21);
            this.txtNroNotaDeCredito.TabIndex = 3;
            this.txtNroNotaDeCredito.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnCambiarFactura
            // 
            this.btnCambiarFactura.BackgroundImage = global::OFC.Properties.Resources.add1;
            this.btnCambiarFactura.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCambiarFactura.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCambiarFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCambiarFactura.Location = new System.Drawing.Point(566, 20);
            this.btnCambiarFactura.Name = "btnCambiarFactura";
            this.btnCambiarFactura.Size = new System.Drawing.Size(63, 22);
            this.btnCambiarFactura.TabIndex = 4;
            this.btnCambiarFactura.UseVisualStyleBackColor = true;
            this.btnCambiarFactura.Click += new System.EventHandler(this.btnCambiarFactura_Click);
            // 
            // lblBonificacion
            // 
            this.lblBonificacion.AutoSize = true;
            this.lblBonificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBonificacion.Location = new System.Drawing.Point(454, 448);
            this.lblBonificacion.Name = "lblBonificacion";
            this.lblBonificacion.Size = new System.Drawing.Size(74, 15);
            this.lblBonificacion.TabIndex = 123;
            this.lblBonificacion.Text = "Bonificación";
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
            this.txtBonificacion.Location = new System.Drawing.Point(534, 445);
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
            this.lblIva.Location = new System.Drawing.Point(259, 474);
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
            this.lblSubtotal.Location = new System.Drawing.Point(5, 474);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(52, 15);
            this.lblSubtotal.TabIndex = 105;
            this.lblSubtotal.Text = "Subtotal";
            // 
            // txtIva
            // 
            this.txtIva.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtIva.Location = new System.Drawing.Point(287, 472);
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
            this.txtSubtotal.Location = new System.Drawing.Point(63, 472);
            this.txtSubtotal.MaxLength = 80;
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.ReadOnly = true;
            this.txtSubtotal.Size = new System.Drawing.Size(97, 21);
            this.txtSubtotal.TabIndex = 9;
            this.txtSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dgvNotasDeCredito
            // 
            this.dgvNotasDeCredito.AllowUserToAddRows = false;
            this.dgvNotasDeCredito.AllowUserToDeleteRows = false;
            this.dgvNotasDeCredito.AllowUserToResizeColumns = false;
            this.dgvNotasDeCredito.AllowUserToResizeRows = false;
            this.dgvNotasDeCredito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNotasDeCredito.Location = new System.Drawing.Point(3, 129);
            this.dgvNotasDeCredito.MultiSelect = false;
            this.dgvNotasDeCredito.Name = "dgvNotasDeCredito";
            this.dgvNotasDeCredito.ReadOnly = true;
            this.dgvNotasDeCredito.RowHeadersVisible = false;
            this.dgvNotasDeCredito.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNotasDeCredito.Size = new System.Drawing.Size(631, 301);
            this.dgvNotasDeCredito.TabIndex = 7;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.Location = new System.Drawing.Point(534, 510);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(97, 35);
            this.btnImprimir.TabIndex = 12;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // lblNotasDeCredito
            // 
            this.lblNotasDeCredito.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblNotasDeCredito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNotasDeCredito.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotasDeCredito.Location = new System.Drawing.Point(3, 12);
            this.lblNotasDeCredito.Name = "lblNotasDeCredito";
            this.lblNotasDeCredito.Size = new System.Drawing.Size(421, 25);
            this.lblNotasDeCredito.TabIndex = 8;
            this.lblNotasDeCredito.Text = "Nota de Crédito Pendiente";
            this.lblNotasDeCredito.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNroFactura
            // 
            this.lblNroFactura.AutoSize = true;
            this.lblNroFactura.Location = new System.Drawing.Point(14, 179);
            this.lblNroFactura.Name = "lblNroFactura";
            this.lblNroFactura.Size = new System.Drawing.Size(119, 15);
            this.lblNroFactura.TabIndex = 114;
            this.lblNroFactura.Text = "Nro. Factura / Débito";
            // 
            // frmNotaDeCredito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 730);
            this.Controls.Add(this.pnlDerecho);
            this.Controls.Add(this.pnlIzquierda);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmNotaDeCredito";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nota de Crédito";
            this.Load += new System.EventHandler(this.frmNotaDeCredito_Load);
            this.pnlIzquierda.ResumeLayout(false);
            this.pnlIzquierda.PerformLayout();
            this.pnlDerecho.ResumeLayout(false);
            this.tbcNotasDeCredito.ResumeLayout(false);
            this.tbpNroNotaDeCredito.ResumeLayout(false);
            this.tbpNroNotaDeCredito.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotasDeCredito)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlIzquierda;
        private System.Windows.Forms.Label lblDatosDelClienteForm;
        private System.Windows.Forms.TextBox txtImporte;
        private System.Windows.Forms.Button btnProcesar;
        private System.Windows.Forms.Label lblImporte;
        private System.Windows.Forms.Label lblCodCliente;
        private System.Windows.Forms.Label lblDetalle;
        private System.Windows.Forms.TextBox txtDetalle;
        private System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.ComboBox cbxMotivo;
        private System.Windows.Forms.ComboBox cbxCodCliente;
        private System.Windows.Forms.ComboBox cbxNombreDelCliente;
        private System.Windows.Forms.Label lblNombreDelCliente;
        private System.Windows.Forms.Panel pnlDerecho;
        private System.Windows.Forms.Label lblNotasDeCredito;
        private System.Windows.Forms.TabControl tbcNotasDeCredito;
        private System.Windows.Forms.TabPage tbpNroNotaDeCredito;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtBonificacion;
        private System.Windows.Forms.Label lblIva;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.TextBox txtIva;
        private System.Windows.Forms.TextBox txtSubtotal;
        private System.Windows.Forms.DataGridView dgvNotasDeCredito;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Label lblBonificacion;
        private System.Windows.Forms.Label lblTipoFactura;
        private System.Windows.Forms.Label lblNroNotaDeCredito;
        private System.Windows.Forms.Label lblDatosDelCliente;
        private System.Windows.Forms.TextBox txtNroNotaDeCredito;
        private System.Windows.Forms.Button btnCambiarFactura;
        private System.Windows.Forms.Button btnVistaDefinitiva;
        private System.Windows.Forms.Label lblVistaPreliminar;
        private System.Windows.Forms.TextBox txtNroFactura;
        private System.Windows.Forms.Button btnX;
        private System.Windows.Forms.Label lblDatosDelItem;
        private System.Windows.Forms.Button btnXCliente;
        private System.Windows.Forms.Button btnVistaPreliminar;
        private System.Windows.Forms.Label lblNroFactura;
    }
}