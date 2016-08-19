namespace OFC
{
    partial class frmABMDeConceptos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlIzquierda = new System.Windows.Forms.Panel();
            this.cbxFiltroCodigo = new System.Windows.Forms.ComboBox();
            this.lblConsultaDeConceptos = new System.Windows.Forms.Label();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.lblFiltroCodigo = new System.Windows.Forms.Label();
            this.lblFiltroMedidaCubierta = new System.Windows.Forms.Label();
            this.lblResultadoConceptos = new System.Windows.Forms.Label();
            this.dgvConceptos = new System.Windows.Forms.DataGridView();
            this.cbxFiltroDescripcion = new System.Windows.Forms.ComboBox();
            this.pnlDerecha = new System.Windows.Forms.Panel();
            this.cbhVigente = new System.Windows.Forms.CheckBox();
            this.cbxPorcentajeIvaCompras = new System.Windows.Forms.ComboBox();
            this.lblPorcentajeIva = new System.Windows.Forms.Label();
            this.cbxDescripcionCuentaCompra = new System.Windows.Forms.ComboBox();
            this.cbxCodigoCuentaCompra = new System.Windows.Forms.ComboBox();
            this.lblDescripcionCuentaCompra = new System.Windows.Forms.Label();
            this.cbxIvaCompras = new System.Windows.Forms.ComboBox();
            this.lblIvaCompras = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblDatosDelCliente = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.lblCodigoCuentaCompra = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.pnlIzquierda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConceptos)).BeginInit();
            this.pnlDerecha.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlIzquierda
            // 
            this.pnlIzquierda.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlIzquierda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlIzquierda.Controls.Add(this.cbxFiltroCodigo);
            this.pnlIzquierda.Controls.Add(this.lblConsultaDeConceptos);
            this.pnlIzquierda.Controls.Add(this.btnFiltrar);
            this.pnlIzquierda.Controls.Add(this.btnBorrar);
            this.pnlIzquierda.Controls.Add(this.lblFiltroCodigo);
            this.pnlIzquierda.Controls.Add(this.lblFiltroMedidaCubierta);
            this.pnlIzquierda.Controls.Add(this.lblResultadoConceptos);
            this.pnlIzquierda.Controls.Add(this.dgvConceptos);
            this.pnlIzquierda.Controls.Add(this.cbxFiltroDescripcion);
            this.pnlIzquierda.Location = new System.Drawing.Point(12, 12);
            this.pnlIzquierda.Name = "pnlIzquierda";
            this.pnlIzquierda.Size = new System.Drawing.Size(650, 678);
            this.pnlIzquierda.TabIndex = 1;
            // 
            // cbxFiltroCodigo
            // 
            this.cbxFiltroCodigo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxFiltroCodigo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxFiltroCodigo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxFiltroCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxFiltroCodigo.FormattingEnabled = true;
            this.cbxFiltroCodigo.Location = new System.Drawing.Point(168, 52);
            this.cbxFiltroCodigo.Name = "cbxFiltroCodigo";
            this.cbxFiltroCodigo.Size = new System.Drawing.Size(309, 23);
            this.cbxFiltroCodigo.TabIndex = 1;
            this.cbxFiltroCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxFiltro_KeyDown);
            // 
            // lblConsultaDeConceptos
            // 
            this.lblConsultaDeConceptos.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblConsultaDeConceptos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblConsultaDeConceptos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsultaDeConceptos.Location = new System.Drawing.Point(16, 11);
            this.lblConsultaDeConceptos.Name = "lblConsultaDeConceptos";
            this.lblConsultaDeConceptos.Size = new System.Drawing.Size(618, 25);
            this.lblConsultaDeConceptos.TabIndex = 58;
            this.lblConsultaDeConceptos.Text = "Consulta de Conceptos";
            this.lblConsultaDeConceptos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrar.Location = new System.Drawing.Point(538, 69);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(96, 35);
            this.btnFiltrar.TabIndex = 3;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBorrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrar.Location = new System.Drawing.Point(16, 628);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(96, 35);
            this.btnBorrar.TabIndex = 5;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // lblFiltroCodigo
            // 
            this.lblFiltroCodigo.AutoSize = true;
            this.lblFiltroCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltroCodigo.Location = new System.Drawing.Point(13, 55);
            this.lblFiltroCodigo.Name = "lblFiltroCodigo";
            this.lblFiltroCodigo.Size = new System.Drawing.Size(97, 15);
            this.lblFiltroCodigo.TabIndex = 14;
            this.lblFiltroCodigo.Text = "Filtro por Código";
            // 
            // lblFiltroMedidaCubierta
            // 
            this.lblFiltroMedidaCubierta.AutoSize = true;
            this.lblFiltroMedidaCubierta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltroMedidaCubierta.Location = new System.Drawing.Point(13, 84);
            this.lblFiltroMedidaCubierta.Name = "lblFiltroMedidaCubierta";
            this.lblFiltroMedidaCubierta.Size = new System.Drawing.Size(123, 15);
            this.lblFiltroMedidaCubierta.TabIndex = 12;
            this.lblFiltroMedidaCubierta.Text = "Filtro por Descripción";
            // 
            // lblResultadoConceptos
            // 
            this.lblResultadoConceptos.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblResultadoConceptos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblResultadoConceptos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultadoConceptos.Location = new System.Drawing.Point(16, 122);
            this.lblResultadoConceptos.Name = "lblResultadoConceptos";
            this.lblResultadoConceptos.Size = new System.Drawing.Size(618, 25);
            this.lblResultadoConceptos.TabIndex = 8;
            this.lblResultadoConceptos.Text = "Resultado";
            this.lblResultadoConceptos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvConceptos
            // 
            this.dgvConceptos.AllowUserToAddRows = false;
            this.dgvConceptos.AllowUserToDeleteRows = false;
            this.dgvConceptos.AllowUserToResizeColumns = false;
            this.dgvConceptos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConceptos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvConceptos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvConceptos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvConceptos.Location = new System.Drawing.Point(16, 150);
            this.dgvConceptos.MultiSelect = false;
            this.dgvConceptos.Name = "dgvConceptos";
            this.dgvConceptos.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConceptos.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvConceptos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConceptos.Size = new System.Drawing.Size(618, 463);
            this.dgvConceptos.TabIndex = 4;
            this.dgvConceptos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConceptos_CellContentClick);
            // 
            // cbxFiltroDescripcion
            // 
            this.cbxFiltroDescripcion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxFiltroDescripcion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxFiltroDescripcion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxFiltroDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxFiltroDescripcion.FormattingEnabled = true;
            this.cbxFiltroDescripcion.Location = new System.Drawing.Point(168, 81);
            this.cbxFiltroDescripcion.Name = "cbxFiltroDescripcion";
            this.cbxFiltroDescripcion.Size = new System.Drawing.Size(309, 23);
            this.cbxFiltroDescripcion.TabIndex = 2;
            this.cbxFiltroDescripcion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxFiltro_KeyDown);
            // 
            // pnlDerecha
            // 
            this.pnlDerecha.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlDerecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDerecha.Controls.Add(this.cbhVigente);
            this.pnlDerecha.Controls.Add(this.cbxPorcentajeIvaCompras);
            this.pnlDerecha.Controls.Add(this.lblPorcentajeIva);
            this.pnlDerecha.Controls.Add(this.cbxDescripcionCuentaCompra);
            this.pnlDerecha.Controls.Add(this.cbxCodigoCuentaCompra);
            this.pnlDerecha.Controls.Add(this.lblDescripcionCuentaCompra);
            this.pnlDerecha.Controls.Add(this.cbxIvaCompras);
            this.pnlDerecha.Controls.Add(this.lblIvaCompras);
            this.pnlDerecha.Controls.Add(this.btnGuardar);
            this.pnlDerecha.Controls.Add(this.lblDatosDelCliente);
            this.pnlDerecha.Controls.Add(this.btnLimpiar);
            this.pnlDerecha.Controls.Add(this.lblCodigoCuentaCompra);
            this.pnlDerecha.Controls.Add(this.txtCodigo);
            this.pnlDerecha.Controls.Add(this.lblCodigo);
            this.pnlDerecha.Controls.Add(this.txtDescripcion);
            this.pnlDerecha.Controls.Add(this.lblDescripcion);
            this.pnlDerecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlDerecha.Location = new System.Drawing.Point(705, 12);
            this.pnlDerecha.Name = "pnlDerecha";
            this.pnlDerecha.Size = new System.Drawing.Size(649, 680);
            this.pnlDerecha.TabIndex = 2;
            // 
            // cbhVigente
            // 
            this.cbhVigente.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbhVigente.Checked = true;
            this.cbhVigente.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbhVigente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbhVigente.Location = new System.Drawing.Point(12, 172);
            this.cbhVigente.Name = "cbhVigente";
            this.cbhVigente.Size = new System.Drawing.Size(159, 24);
            this.cbhVigente.TabIndex = 7;
            this.cbhVigente.Text = "Vigente";
            this.cbhVigente.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.cbhVigente.UseVisualStyleBackColor = true;
            // 
            // cbxPorcentajeIvaCompras
            // 
            this.cbxPorcentajeIvaCompras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPorcentajeIvaCompras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxPorcentajeIvaCompras.FormattingEnabled = true;
            this.cbxPorcentajeIvaCompras.Location = new System.Drawing.Point(367, 144);
            this.cbxPorcentajeIvaCompras.Name = "cbxPorcentajeIvaCompras";
            this.cbxPorcentajeIvaCompras.Size = new System.Drawing.Size(263, 23);
            this.cbxPorcentajeIvaCompras.TabIndex = 6;
            // 
            // lblPorcentajeIva
            // 
            this.lblPorcentajeIva.AutoSize = true;
            this.lblPorcentajeIva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPorcentajeIva.Location = new System.Drawing.Point(289, 147);
            this.lblPorcentajeIva.Name = "lblPorcentajeIva";
            this.lblPorcentajeIva.Size = new System.Drawing.Size(66, 15);
            this.lblPorcentajeIva.TabIndex = 139;
            this.lblPorcentajeIva.Text = "Porcentaje";
            // 
            // cbxDescripcionCuentaCompra
            // 
            this.cbxDescripcionCuentaCompra.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxDescripcionCuentaCompra.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxDescripcionCuentaCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxDescripcionCuentaCompra.FormattingEnabled = true;
            this.cbxDescripcionCuentaCompra.Location = new System.Drawing.Point(367, 115);
            this.cbxDescripcionCuentaCompra.Name = "cbxDescripcionCuentaCompra";
            this.cbxDescripcionCuentaCompra.Size = new System.Drawing.Size(263, 23);
            this.cbxDescripcionCuentaCompra.TabIndex = 4;
            // 
            // cbxCodigoCuentaCompra
            // 
            this.cbxCodigoCuentaCompra.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxCodigoCuentaCompra.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxCodigoCuentaCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxCodigoCuentaCompra.FormattingEnabled = true;
            this.cbxCodigoCuentaCompra.Location = new System.Drawing.Point(158, 115);
            this.cbxCodigoCuentaCompra.Name = "cbxCodigoCuentaCompra";
            this.cbxCodigoCuentaCompra.Size = new System.Drawing.Size(125, 23);
            this.cbxCodigoCuentaCompra.TabIndex = 3;
            // 
            // lblDescripcionCuentaCompra
            // 
            this.lblDescripcionCuentaCompra.AutoSize = true;
            this.lblDescripcionCuentaCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcionCuentaCompra.Location = new System.Drawing.Point(289, 118);
            this.lblDescripcionCuentaCompra.Name = "lblDescripcionCuentaCompra";
            this.lblDescripcionCuentaCompra.Size = new System.Drawing.Size(72, 15);
            this.lblDescripcionCuentaCompra.TabIndex = 136;
            this.lblDescripcionCuentaCompra.Text = "Descripción";
            // 
            // cbxIvaCompras
            // 
            this.cbxIvaCompras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxIvaCompras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxIvaCompras.FormattingEnabled = true;
            this.cbxIvaCompras.Location = new System.Drawing.Point(158, 144);
            this.cbxIvaCompras.Name = "cbxIvaCompras";
            this.cbxIvaCompras.Size = new System.Drawing.Size(125, 23);
            this.cbxIvaCompras.TabIndex = 5;
            // 
            // lblIvaCompras
            // 
            this.lblIvaCompras.AutoSize = true;
            this.lblIvaCompras.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIvaCompras.Location = new System.Drawing.Point(14, 147);
            this.lblIvaCompras.Name = "lblIvaCompras";
            this.lblIvaCompras.Size = new System.Drawing.Size(22, 15);
            this.lblIvaCompras.TabIndex = 134;
            this.lblIvaCompras.Text = "Iva";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.Location = new System.Drawing.Point(534, 226);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(96, 35);
            this.btnGuardar.TabIndex = 9;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblDatosDelCliente
            // 
            this.lblDatosDelCliente.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblDatosDelCliente.Location = new System.Drawing.Point(3, 12);
            this.lblDatosDelCliente.Name = "lblDatosDelCliente";
            this.lblDatosDelCliente.Size = new System.Drawing.Size(641, 25);
            this.lblDatosDelCliente.TabIndex = 100;
            this.lblDatosDelCliente.Text = "Datos del Concepto";
            this.lblDatosDelCliente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.Location = new System.Drawing.Point(17, 226);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(96, 35);
            this.btnLimpiar.TabIndex = 8;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // lblCodigoCuentaCompra
            // 
            this.lblCodigoCuentaCompra.AutoSize = true;
            this.lblCodigoCuentaCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigoCuentaCompra.Location = new System.Drawing.Point(14, 118);
            this.lblCodigoCuentaCompra.Name = "lblCodigoCuentaCompra";
            this.lblCodigoCuentaCompra.Size = new System.Drawing.Size(138, 15);
            this.lblCodigoCuentaCompra.TabIndex = 103;
            this.lblCodigoCuentaCompra.Text = "Cód. de Cuenta Compra";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(158, 62);
            this.txtCodigo.MaxLength = 4;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(472, 21);
            this.txtCodigo.TabIndex = 1;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigo.Location = new System.Drawing.Point(14, 64);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(46, 15);
            this.lblCodigo.TabIndex = 101;
            this.lblCodigo.Text = "Código";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(158, 89);
            this.txtDescripcion.MaxLength = 80;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(472, 21);
            this.txtDescripcion.TabIndex = 2;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.Location = new System.Drawing.Point(14, 91);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(72, 15);
            this.lblDescripcion.TabIndex = 102;
            this.lblDescripcion.Text = "Descripción";
            // 
            // frmABMDeConceptos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 730);
            this.Controls.Add(this.pnlDerecha);
            this.Controls.Add(this.pnlIzquierda);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmABMDeConceptos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conceptos";
            this.Load += new System.EventHandler(this.frmABMDeConceptos_Load);
            this.pnlIzquierda.ResumeLayout(false);
            this.pnlIzquierda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConceptos)).EndInit();
            this.pnlDerecha.ResumeLayout(false);
            this.pnlDerecha.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlIzquierda;
        private System.Windows.Forms.ComboBox cbxFiltroCodigo;
        private System.Windows.Forms.Label lblConsultaDeConceptos;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Label lblFiltroCodigo;
        private System.Windows.Forms.Label lblFiltroMedidaCubierta;
        private System.Windows.Forms.Label lblResultadoConceptos;
        private System.Windows.Forms.DataGridView dgvConceptos;
        private System.Windows.Forms.ComboBox cbxFiltroDescripcion;
        private System.Windows.Forms.Panel pnlDerecha;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblDatosDelCliente;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblCodigoCuentaCompra;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.ComboBox cbxIvaCompras;
        private System.Windows.Forms.Label lblIvaCompras;
        private System.Windows.Forms.Label lblDescripcionCuentaCompra;
        private System.Windows.Forms.ComboBox cbxDescripcionCuentaCompra;
        private System.Windows.Forms.ComboBox cbxCodigoCuentaCompra;
        private System.Windows.Forms.ComboBox cbxPorcentajeIvaCompras;
        private System.Windows.Forms.Label lblPorcentajeIva;
        private System.Windows.Forms.CheckBox cbhVigente;
    }
}