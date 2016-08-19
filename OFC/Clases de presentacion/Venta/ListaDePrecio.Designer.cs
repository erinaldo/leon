namespace OFC
{
    partial class frmListaDePrecio
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
            this.cbxFiltroMedidaDeCubierta = new System.Windows.Forms.ComboBox();
            this.cbxFiltroListaDePrecio = new System.Windows.Forms.ComboBox();
            this.lblConsultaDePrecios = new System.Windows.Forms.Label();
            this.lblFiltroListaDePrecio = new System.Windows.Forms.Label();
            this.lblFiltroMedidaDeCubierta = new System.Windows.Forms.Label();
            this.dgvListaDePrecio = new System.Windows.Forms.DataGridView();
            this.btnX = new System.Windows.Forms.Button();
            this.cbxListaDePrecio = new System.Windows.Forms.ComboBox();
            this.lblListaDePrecio = new System.Windows.Forms.Label();
            this.cbxProducto = new System.Windows.Forms.ComboBox();
            this.lblProducto = new System.Windows.Forms.Label();
            this.cbxMedidaDeCubierta = new System.Windows.Forms.ComboBox();
            this.lblMedidaDeCubierta = new System.Windows.Forms.Label();
            this.cbxTrabajoServicio = new System.Windows.Forms.ComboBox();
            this.lblTrabajoServicio = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.txtAplicarIva = new System.Windows.Forms.TextBox();
            this.lblP = new System.Windows.Forms.Label();
            this.chbAplicarIva = new System.Windows.Forms.CheckBox();
            this.pnlActualizacionDePrecios = new System.Windows.Forms.Panel();
            this.lblPorcentaje = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.txtPorcentaje = new System.Windows.Forms.TextBox();
            this.lblActualizarPreciosTrabajos = new System.Windows.Forms.Label();
            this.pnlFiltrosDeBusqueda = new System.Windows.Forms.Panel();
            this.cbxFiltroArticulo = new System.Windows.Forms.ComboBox();
            this.lblFiltroArticulo = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.pblAplicarIva = new System.Windows.Forms.Panel();
            this.prbActualizarPrecios = new System.Windows.Forms.ProgressBar();
            this.btnActualizarConIVA = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaDePrecio)).BeginInit();
            this.pnlActualizacionDePrecios.SuspendLayout();
            this.pnlFiltrosDeBusqueda.SuspendLayout();
            this.pblAplicarIva.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxFiltroMedidaDeCubierta
            // 
            this.cbxFiltroMedidaDeCubierta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxFiltroMedidaDeCubierta.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxFiltroMedidaDeCubierta.BackColor = System.Drawing.SystemColors.Window;
            this.cbxFiltroMedidaDeCubierta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxFiltroMedidaDeCubierta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxFiltroMedidaDeCubierta.FormattingEnabled = true;
            this.cbxFiltroMedidaDeCubierta.Location = new System.Drawing.Point(446, 18);
            this.cbxFiltroMedidaDeCubierta.Name = "cbxFiltroMedidaDeCubierta";
            this.cbxFiltroMedidaDeCubierta.Size = new System.Drawing.Size(151, 23);
            this.cbxFiltroMedidaDeCubierta.TabIndex = 2;
            this.cbxFiltroMedidaDeCubierta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxFiltro_KeyDown);
            // 
            // cbxFiltroListaDePrecio
            // 
            this.cbxFiltroListaDePrecio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFiltroListaDePrecio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxFiltroListaDePrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxFiltroListaDePrecio.FormattingEnabled = true;
            this.cbxFiltroListaDePrecio.Location = new System.Drawing.Point(148, 18);
            this.cbxFiltroListaDePrecio.Name = "cbxFiltroListaDePrecio";
            this.cbxFiltroListaDePrecio.Size = new System.Drawing.Size(120, 23);
            this.cbxFiltroListaDePrecio.TabIndex = 1;
            this.cbxFiltroListaDePrecio.SelectedIndexChanged += new System.EventHandler(this.cbxFiltroListaDePrecio_SelectedIndexChanged);
            this.cbxFiltroListaDePrecio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxFiltro_KeyDown);
            // 
            // lblConsultaDePrecios
            // 
            this.lblConsultaDePrecios.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblConsultaDePrecios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblConsultaDePrecios.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsultaDePrecios.Location = new System.Drawing.Point(12, 9);
            this.lblConsultaDePrecios.Name = "lblConsultaDePrecios";
            this.lblConsultaDePrecios.Size = new System.Drawing.Size(1346, 25);
            this.lblConsultaDePrecios.TabIndex = 100;
            this.lblConsultaDePrecios.Text = "Consulta de Precios";
            this.lblConsultaDePrecios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFiltroListaDePrecio
            // 
            this.lblFiltroListaDePrecio.AutoSize = true;
            this.lblFiltroListaDePrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltroListaDePrecio.Location = new System.Drawing.Point(3, 21);
            this.lblFiltroListaDePrecio.Name = "lblFiltroListaDePrecio";
            this.lblFiltroListaDePrecio.Size = new System.Drawing.Size(139, 15);
            this.lblFiltroListaDePrecio.TabIndex = 101;
            this.lblFiltroListaDePrecio.Text = "Filtro por Lista de Precio";
            // 
            // lblFiltroMedidaDeCubierta
            // 
            this.lblFiltroMedidaDeCubierta.AutoSize = true;
            this.lblFiltroMedidaDeCubierta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltroMedidaDeCubierta.Location = new System.Drawing.Point(274, 21);
            this.lblFiltroMedidaDeCubierta.Name = "lblFiltroMedidaDeCubierta";
            this.lblFiltroMedidaDeCubierta.Size = new System.Drawing.Size(166, 15);
            this.lblFiltroMedidaDeCubierta.TabIndex = 102;
            this.lblFiltroMedidaDeCubierta.Text = "Filtro por Medida de Cubierta";
            // 
            // dgvListaDePrecio
            // 
            this.dgvListaDePrecio.AllowUserToAddRows = false;
            this.dgvListaDePrecio.AllowUserToDeleteRows = false;
            this.dgvListaDePrecio.AllowUserToResizeColumns = false;
            this.dgvListaDePrecio.AllowUserToResizeRows = false;
            this.dgvListaDePrecio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaDePrecio.Location = new System.Drawing.Point(12, 135);
            this.dgvListaDePrecio.MultiSelect = false;
            this.dgvListaDePrecio.Name = "dgvListaDePrecio";
            this.dgvListaDePrecio.ReadOnly = true;
            this.dgvListaDePrecio.RowHeadersVisible = false;
            this.dgvListaDePrecio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvListaDePrecio.Size = new System.Drawing.Size(1346, 440);
            this.dgvListaDePrecio.TabIndex = 2;
            this.dgvListaDePrecio.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListaDePrecio_CellContentClick);
            // 
            // btnX
            // 
            this.btnX.BackColor = System.Drawing.Color.Transparent;
            this.btnX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnX.Location = new System.Drawing.Point(603, 43);
            this.btnX.Name = "btnX";
            this.btnX.Size = new System.Drawing.Size(93, 29);
            this.btnX.TabIndex = 5;
            this.btnX.Text = "Buscar";
            this.btnX.UseVisualStyleBackColor = false;
            this.btnX.Click += new System.EventHandler(this.btnX_Click);
            // 
            // cbxListaDePrecio
            // 
            this.cbxListaDePrecio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxListaDePrecio.Enabled = false;
            this.cbxListaDePrecio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxListaDePrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxListaDePrecio.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cbxListaDePrecio.FormattingEnabled = true;
            this.cbxListaDePrecio.Location = new System.Drawing.Point(108, 596);
            this.cbxListaDePrecio.Name = "cbxListaDePrecio";
            this.cbxListaDePrecio.Size = new System.Drawing.Size(299, 23);
            this.cbxListaDePrecio.TabIndex = 3;
            // 
            // lblListaDePrecio
            // 
            this.lblListaDePrecio.AutoSize = true;
            this.lblListaDePrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListaDePrecio.Location = new System.Drawing.Point(14, 599);
            this.lblListaDePrecio.Name = "lblListaDePrecio";
            this.lblListaDePrecio.Size = new System.Drawing.Size(88, 15);
            this.lblListaDePrecio.TabIndex = 101;
            this.lblListaDePrecio.Text = "Lista de Precio";
            // 
            // cbxProducto
            // 
            this.cbxProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxProducto.Enabled = false;
            this.cbxProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxProducto.FormattingEnabled = true;
            this.cbxProducto.Location = new System.Drawing.Point(108, 625);
            this.cbxProducto.Name = "cbxProducto";
            this.cbxProducto.Size = new System.Drawing.Size(299, 23);
            this.cbxProducto.TabIndex = 4;
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProducto.Location = new System.Drawing.Point(55, 628);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(47, 15);
            this.lblProducto.TabIndex = 102;
            this.lblProducto.Text = "Artículo";
            // 
            // cbxMedidaDeCubierta
            // 
            this.cbxMedidaDeCubierta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMedidaDeCubierta.DropDownWidth = 299;
            this.cbxMedidaDeCubierta.Enabled = false;
            this.cbxMedidaDeCubierta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxMedidaDeCubierta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxMedidaDeCubierta.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cbxMedidaDeCubierta.FormattingEnabled = true;
            this.cbxMedidaDeCubierta.Location = new System.Drawing.Point(597, 596);
            this.cbxMedidaDeCubierta.Name = "cbxMedidaDeCubierta";
            this.cbxMedidaDeCubierta.Size = new System.Drawing.Size(299, 23);
            this.cbxMedidaDeCubierta.TabIndex = 5;
            // 
            // lblMedidaDeCubierta
            // 
            this.lblMedidaDeCubierta.AutoSize = true;
            this.lblMedidaDeCubierta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMedidaDeCubierta.Location = new System.Drawing.Point(476, 599);
            this.lblMedidaDeCubierta.Name = "lblMedidaDeCubierta";
            this.lblMedidaDeCubierta.Size = new System.Drawing.Size(115, 15);
            this.lblMedidaDeCubierta.TabIndex = 103;
            this.lblMedidaDeCubierta.Text = "Medida de Cubierta";
            // 
            // cbxTrabajoServicio
            // 
            this.cbxTrabajoServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTrabajoServicio.Enabled = false;
            this.cbxTrabajoServicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxTrabajoServicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxTrabajoServicio.FormattingEnabled = true;
            this.cbxTrabajoServicio.Location = new System.Drawing.Point(597, 625);
            this.cbxTrabajoServicio.Name = "cbxTrabajoServicio";
            this.cbxTrabajoServicio.Size = new System.Drawing.Size(299, 23);
            this.cbxTrabajoServicio.TabIndex = 6;
            // 
            // lblTrabajoServicio
            // 
            this.lblTrabajoServicio.AutoSize = true;
            this.lblTrabajoServicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrabajoServicio.Location = new System.Drawing.Point(490, 628);
            this.lblTrabajoServicio.Name = "lblTrabajoServicio";
            this.lblTrabajoServicio.Size = new System.Drawing.Size(101, 15);
            this.lblTrabajoServicio.TabIndex = 104;
            this.lblTrabajoServicio.Text = "Trabajo / Servicio";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio.Location = new System.Drawing.Point(966, 599);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(42, 15);
            this.lblPrecio.TabIndex = 105;
            this.lblPrecio.Text = "Precio";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecio.Location = new System.Drawing.Point(1014, 596);
            this.txtPrecio.MaxLength = 10;
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(205, 21);
            this.txtPrecio.TabIndex = 7;
            this.txtPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecio_KeyPress);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.Transparent;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.Location = new System.Drawing.Point(1265, 592);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(93, 29);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.BackColor = System.Drawing.Color.Transparent;
            this.btnBorrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBorrar.Location = new System.Drawing.Point(1265, 627);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(93, 31);
            this.btnBorrar.TabIndex = 9;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = false;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // txtAplicarIva
            // 
            this.txtAplicarIva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAplicarIva.Location = new System.Drawing.Point(96, 35);
            this.txtAplicarIva.MaxLength = 2;
            this.txtAplicarIva.Name = "txtAplicarIva";
            this.txtAplicarIva.Size = new System.Drawing.Size(45, 21);
            this.txtAplicarIva.TabIndex = 2;
            this.txtAplicarIva.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAplicarIva_KeyPress);
            // 
            // lblP
            // 
            this.lblP.AutoSize = true;
            this.lblP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblP.Location = new System.Drawing.Point(147, 38);
            this.lblP.Name = "lblP";
            this.lblP.Size = new System.Drawing.Size(18, 15);
            this.lblP.TabIndex = 101;
            this.lblP.Text = "%";
            // 
            // chbAplicarIva
            // 
            this.chbAplicarIva.AutoSize = true;
            this.chbAplicarIva.Location = new System.Drawing.Point(7, 37);
            this.chbAplicarIva.Name = "chbAplicarIva";
            this.chbAplicarIva.Size = new System.Drawing.Size(83, 19);
            this.chbAplicarIva.TabIndex = 1;
            this.chbAplicarIva.Text = "Aplicar IVA";
            this.chbAplicarIva.UseVisualStyleBackColor = true;
            this.chbAplicarIva.CheckedChanged += new System.EventHandler(this.chbAplicarIva_CheckedChanged);
            // 
            // pnlActualizacionDePrecios
            // 
            this.pnlActualizacionDePrecios.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlActualizacionDePrecios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlActualizacionDePrecios.Controls.Add(this.btnActualizarConIVA);
            this.pnlActualizacionDePrecios.Controls.Add(this.lblPorcentaje);
            this.pnlActualizacionDePrecios.Controls.Add(this.label1);
            this.pnlActualizacionDePrecios.Controls.Add(this.btnActualizar);
            this.pnlActualizacionDePrecios.Controls.Add(this.txtPorcentaje);
            this.pnlActualizacionDePrecios.Controls.Add(this.lblActualizarPreciosTrabajos);
            this.pnlActualizacionDePrecios.Location = new System.Drawing.Point(825, 37);
            this.pnlActualizacionDePrecios.Name = "pnlActualizacionDePrecios";
            this.pnlActualizacionDePrecios.Size = new System.Drawing.Size(359, 92);
            this.pnlActualizacionDePrecios.TabIndex = 2;
            // 
            // lblPorcentaje
            // 
            this.lblPorcentaje.AutoSize = true;
            this.lblPorcentaje.Location = new System.Drawing.Point(4, 50);
            this.lblPorcentaje.Name = "lblPorcentaje";
            this.lblPorcentaje.Size = new System.Drawing.Size(66, 15);
            this.lblPorcentaje.TabIndex = 101;
            this.lblPorcentaje.Text = "Porcentaje";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(127, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 15);
            this.label1.TabIndex = 102;
            this.label1.Text = "%";
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.Transparent;
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.Location = new System.Drawing.Point(154, 27);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(200, 29);
            this.btnActualizar.TabIndex = 2;
            this.btnActualizar.Text = "Actualizar precio sin incluir el IVA";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // txtPorcentaje
            // 
            this.txtPorcentaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPorcentaje.Location = new System.Drawing.Point(76, 47);
            this.txtPorcentaje.MaxLength = 4;
            this.txtPorcentaje.Name = "txtPorcentaje";
            this.txtPorcentaje.Size = new System.Drawing.Size(45, 21);
            this.txtPorcentaje.TabIndex = 1;
            this.txtPorcentaje.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPorcentaje_KeyPress);
            // 
            // lblActualizarPreciosTrabajos
            // 
            this.lblActualizarPreciosTrabajos.AutoSize = true;
            this.lblActualizarPreciosTrabajos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActualizarPreciosTrabajos.ForeColor = System.Drawing.Color.Maroon;
            this.lblActualizarPreciosTrabajos.Location = new System.Drawing.Point(45, 4);
            this.lblActualizarPreciosTrabajos.Name = "lblActualizarPreciosTrabajos";
            this.lblActualizarPreciosTrabajos.Size = new System.Drawing.Size(249, 20);
            this.lblActualizarPreciosTrabajos.TabIndex = 1;
            this.lblActualizarPreciosTrabajos.Text = "Actualizar el precio de los trabajos";
            // 
            // pnlFiltrosDeBusqueda
            // 
            this.pnlFiltrosDeBusqueda.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlFiltrosDeBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFiltrosDeBusqueda.Controls.Add(this.cbxFiltroArticulo);
            this.pnlFiltrosDeBusqueda.Controls.Add(this.lblFiltroArticulo);
            this.pnlFiltrosDeBusqueda.Controls.Add(this.btnImprimir);
            this.pnlFiltrosDeBusqueda.Controls.Add(this.cbxFiltroMedidaDeCubierta);
            this.pnlFiltrosDeBusqueda.Controls.Add(this.lblFiltroMedidaDeCubierta);
            this.pnlFiltrosDeBusqueda.Controls.Add(this.lblFiltroListaDePrecio);
            this.pnlFiltrosDeBusqueda.Controls.Add(this.cbxFiltroListaDePrecio);
            this.pnlFiltrosDeBusqueda.Controls.Add(this.btnX);
            this.pnlFiltrosDeBusqueda.Location = new System.Drawing.Point(12, 37);
            this.pnlFiltrosDeBusqueda.Name = "pnlFiltrosDeBusqueda";
            this.pnlFiltrosDeBusqueda.Size = new System.Drawing.Size(807, 92);
            this.pnlFiltrosDeBusqueda.TabIndex = 1;
            // 
            // cbxFiltroArticulo
            // 
            this.cbxFiltroArticulo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxFiltroArticulo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxFiltroArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxFiltroArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxFiltroArticulo.FormattingEnabled = true;
            this.cbxFiltroArticulo.Location = new System.Drawing.Point(148, 47);
            this.cbxFiltroArticulo.Name = "cbxFiltroArticulo";
            this.cbxFiltroArticulo.Size = new System.Drawing.Size(449, 23);
            this.cbxFiltroArticulo.TabIndex = 4;
            this.cbxFiltroArticulo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxFiltro_KeyDown);
            // 
            // lblFiltroArticulo
            // 
            this.lblFiltroArticulo.AutoSize = true;
            this.lblFiltroArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltroArticulo.Location = new System.Drawing.Point(3, 50);
            this.lblFiltroArticulo.Name = "lblFiltroArticulo";
            this.lblFiltroArticulo.Size = new System.Drawing.Size(98, 15);
            this.lblFiltroArticulo.TabIndex = 104;
            this.lblFiltroArticulo.Text = "Filtro por Artículo";
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.Transparent;
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.Location = new System.Drawing.Point(702, 43);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(93, 29);
            this.btnImprimir.TabIndex = 6;
            this.btnImprimir.Text = "Reporte";
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // pblAplicarIva
            // 
            this.pblAplicarIva.BackColor = System.Drawing.Color.Gainsboro;
            this.pblAplicarIva.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pblAplicarIva.Controls.Add(this.txtAplicarIva);
            this.pblAplicarIva.Controls.Add(this.lblP);
            this.pblAplicarIva.Controls.Add(this.chbAplicarIva);
            this.pblAplicarIva.Location = new System.Drawing.Point(1190, 37);
            this.pblAplicarIva.Name = "pblAplicarIva";
            this.pblAplicarIva.Size = new System.Drawing.Size(168, 92);
            this.pblAplicarIva.TabIndex = 3;
            // 
            // prbActualizarPrecios
            // 
            this.prbActualizarPrecios.Location = new System.Drawing.Point(474, 335);
            this.prbActualizarPrecios.Name = "prbActualizarPrecios";
            this.prbActualizarPrecios.Size = new System.Drawing.Size(418, 23);
            this.prbActualizarPrecios.TabIndex = 130;
            // 
            // btnActualizarConIVA
            // 
            this.btnActualizarConIVA.BackColor = System.Drawing.Color.Transparent;
            this.btnActualizarConIVA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizarConIVA.Location = new System.Drawing.Point(154, 58);
            this.btnActualizarConIVA.Name = "btnActualizarConIVA";
            this.btnActualizarConIVA.Size = new System.Drawing.Size(200, 29);
            this.btnActualizarConIVA.TabIndex = 3;
            this.btnActualizarConIVA.Text = "Actualizar precio incluyendo el IVA";
            this.btnActualizarConIVA.UseVisualStyleBackColor = false;
            this.btnActualizarConIVA.Click += new System.EventHandler(this.btnActualizarConIVA_Click);
            // 
            // frmListaDePrecio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1366, 730);
            this.Controls.Add(this.prbActualizarPrecios);
            this.Controls.Add(this.pblAplicarIva);
            this.Controls.Add(this.pnlFiltrosDeBusqueda);
            this.Controls.Add(this.pnlActualizacionDePrecios);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.cbxTrabajoServicio);
            this.Controls.Add(this.lblTrabajoServicio);
            this.Controls.Add(this.cbxMedidaDeCubierta);
            this.Controls.Add(this.lblMedidaDeCubierta);
            this.Controls.Add(this.cbxProducto);
            this.Controls.Add(this.lblProducto);
            this.Controls.Add(this.cbxListaDePrecio);
            this.Controls.Add(this.lblListaDePrecio);
            this.Controls.Add(this.dgvListaDePrecio);
            this.Controls.Add(this.lblConsultaDePrecios);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmListaDePrecio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de Precio Venta";
            this.Load += new System.EventHandler(this.frmListaDePrecio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaDePrecio)).EndInit();
            this.pnlActualizacionDePrecios.ResumeLayout(false);
            this.pnlActualizacionDePrecios.PerformLayout();
            this.pnlFiltrosDeBusqueda.ResumeLayout(false);
            this.pnlFiltrosDeBusqueda.PerformLayout();
            this.pblAplicarIva.ResumeLayout(false);
            this.pblAplicarIva.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxFiltroMedidaDeCubierta;
        private System.Windows.Forms.ComboBox cbxFiltroListaDePrecio;
        private System.Windows.Forms.Label lblConsultaDePrecios;
        private System.Windows.Forms.Label lblFiltroListaDePrecio;
        private System.Windows.Forms.Label lblFiltroMedidaDeCubierta;
        private System.Windows.Forms.DataGridView dgvListaDePrecio;
        private System.Windows.Forms.Button btnX;
        private System.Windows.Forms.ComboBox cbxListaDePrecio;
        private System.Windows.Forms.Label lblListaDePrecio;
        private System.Windows.Forms.ComboBox cbxProducto;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.ComboBox cbxMedidaDeCubierta;
        private System.Windows.Forms.Label lblMedidaDeCubierta;
        private System.Windows.Forms.ComboBox cbxTrabajoServicio;
        private System.Windows.Forms.Label lblTrabajoServicio;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.TextBox txtAplicarIva;
        private System.Windows.Forms.Label lblP;
        private System.Windows.Forms.CheckBox chbAplicarIva;
        private System.Windows.Forms.Panel pnlActualizacionDePrecios;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Label lblActualizarPreciosTrabajos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPorcentaje;
        private System.Windows.Forms.Label lblPorcentaje;
        private System.Windows.Forms.Panel pnlFiltrosDeBusqueda;
        private System.Windows.Forms.Panel pblAplicarIva;
        private System.Windows.Forms.ProgressBar prbActualizarPrecios;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.ComboBox cbxFiltroArticulo;
        private System.Windows.Forms.Label lblFiltroArticulo;
        private System.Windows.Forms.Button btnActualizarConIVA;
    }
}