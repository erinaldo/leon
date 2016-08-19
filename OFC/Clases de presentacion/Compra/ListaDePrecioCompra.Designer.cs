namespace OFC
{
    partial class frmListaDePrecioCompra
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlDerecha = new System.Windows.Forms.Panel();
            this.cbxFiltroCodArticuloDisponible = new System.Windows.Forms.ComboBox();
            this.lblFiltroPorArticuloDisponible = new System.Windows.Forms.Label();
            this.cbxFiltroNombreArticuloDisponible = new System.Windows.Forms.ComboBox();
            this.lblConsultaDeArticulos = new System.Windows.Forms.Label();
            this.btnFiltrarArticuloDisponible = new System.Windows.Forms.Button();
            this.lblResultadoArticulosDisponibles = new System.Windows.Forms.Label();
            this.dgvArticulosDisponibles = new System.Windows.Forms.DataGridView();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.pnlIzquierda = new System.Windows.Forms.Panel();
            this.cbxFiltroCodArticuloEnLista = new System.Windows.Forms.ComboBox();
            this.lblFiltroPorArticuloEnLista = new System.Windows.Forms.Label();
            this.cbxFiltroNombreArticuloEnLista = new System.Windows.Forms.ComboBox();
            this.lblArticulosEnLista = new System.Windows.Forms.Label();
            this.btnFiltrarArticuloEnLista = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.txtCodDeArticulo = new System.Windows.Forms.TextBox();
            this.txtCodDeProveedor = new System.Windows.Forms.TextBox();
            this.lblCodDeProveedor = new System.Windows.Forms.Label();
            this.lblCodDeArticulo = new System.Windows.Forms.Label();
            this.lblResultadoArticulosEnLista = new System.Windows.Forms.Label();
            this.dgvArticulosEnLista = new System.Windows.Forms.DataGridView();
            this.lblConsultaDeProveedores = new System.Windows.Forms.Label();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.cbxFiltroNombreDeProveedor = new System.Windows.Forms.ComboBox();
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.lblFiltroPorProveedor = new System.Windows.Forms.Label();
            this.cbxFiltroCodDeProveedor = new System.Windows.Forms.ComboBox();
            this.pnlDerecha.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulosDisponibles)).BeginInit();
            this.pnlIzquierda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulosEnLista)).BeginInit();
            this.pnlSuperior.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDerecha
            // 
            this.pnlDerecha.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlDerecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDerecha.Controls.Add(this.cbxFiltroCodArticuloDisponible);
            this.pnlDerecha.Controls.Add(this.lblFiltroPorArticuloDisponible);
            this.pnlDerecha.Controls.Add(this.cbxFiltroNombreArticuloDisponible);
            this.pnlDerecha.Controls.Add(this.lblConsultaDeArticulos);
            this.pnlDerecha.Controls.Add(this.btnFiltrarArticuloDisponible);
            this.pnlDerecha.Controls.Add(this.lblResultadoArticulosDisponibles);
            this.pnlDerecha.Controls.Add(this.dgvArticulosDisponibles);
            this.pnlDerecha.Location = new System.Drawing.Point(704, 114);
            this.pnlDerecha.Name = "pnlDerecha";
            this.pnlDerecha.Size = new System.Drawing.Size(650, 576);
            this.pnlDerecha.TabIndex = 3;
            // 
            // cbxFiltroCodArticuloDisponible
            // 
            this.cbxFiltroCodArticuloDisponible.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxFiltroCodArticuloDisponible.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxFiltroCodArticuloDisponible.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxFiltroCodArticuloDisponible.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxFiltroCodArticuloDisponible.FormattingEnabled = true;
            this.cbxFiltroCodArticuloDisponible.Location = new System.Drawing.Point(115, 52);
            this.cbxFiltroCodArticuloDisponible.Name = "cbxFiltroCodArticuloDisponible";
            this.cbxFiltroCodArticuloDisponible.Size = new System.Drawing.Size(101, 23);
            this.cbxFiltroCodArticuloDisponible.TabIndex = 1;
            this.cbxFiltroCodArticuloDisponible.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxFiltroArticulosDisponibles_KeyDown);
            // 
            // lblFiltroPorArticuloDisponible
            // 
            this.lblFiltroPorArticuloDisponible.AutoSize = true;
            this.lblFiltroPorArticuloDisponible.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltroPorArticuloDisponible.Location = new System.Drawing.Point(11, 55);
            this.lblFiltroPorArticuloDisponible.Name = "lblFiltroPorArticuloDisponible";
            this.lblFiltroPorArticuloDisponible.Size = new System.Drawing.Size(98, 15);
            this.lblFiltroPorArticuloDisponible.TabIndex = 60;
            this.lblFiltroPorArticuloDisponible.Text = "Filtro por Artículo";
            // 
            // cbxFiltroNombreArticuloDisponible
            // 
            this.cbxFiltroNombreArticuloDisponible.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxFiltroNombreArticuloDisponible.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxFiltroNombreArticuloDisponible.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxFiltroNombreArticuloDisponible.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxFiltroNombreArticuloDisponible.FormattingEnabled = true;
            this.cbxFiltroNombreArticuloDisponible.Location = new System.Drawing.Point(222, 52);
            this.cbxFiltroNombreArticuloDisponible.Name = "cbxFiltroNombreArticuloDisponible";
            this.cbxFiltroNombreArticuloDisponible.Size = new System.Drawing.Size(308, 23);
            this.cbxFiltroNombreArticuloDisponible.TabIndex = 2;
            this.cbxFiltroNombreArticuloDisponible.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxFiltroArticulosDisponibles_KeyDown);
            // 
            // lblConsultaDeArticulos
            // 
            this.lblConsultaDeArticulos.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblConsultaDeArticulos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblConsultaDeArticulos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsultaDeArticulos.Location = new System.Drawing.Point(14, 11);
            this.lblConsultaDeArticulos.Name = "lblConsultaDeArticulos";
            this.lblConsultaDeArticulos.Size = new System.Drawing.Size(618, 25);
            this.lblConsultaDeArticulos.TabIndex = 58;
            this.lblConsultaDeArticulos.Text = "Artículos Disponibles";
            this.lblConsultaDeArticulos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnFiltrarArticuloDisponible
            // 
            this.btnFiltrarArticuloDisponible.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrarArticuloDisponible.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrarArticuloDisponible.Location = new System.Drawing.Point(536, 45);
            this.btnFiltrarArticuloDisponible.Name = "btnFiltrarArticuloDisponible";
            this.btnFiltrarArticuloDisponible.Size = new System.Drawing.Size(96, 35);
            this.btnFiltrarArticuloDisponible.TabIndex = 3;
            this.btnFiltrarArticuloDisponible.Text = "Filtrar";
            this.btnFiltrarArticuloDisponible.UseVisualStyleBackColor = true;
            this.btnFiltrarArticuloDisponible.Click += new System.EventHandler(this.btnFiltrarArticuloDisponible_Click);
            // 
            // lblResultadoArticulosDisponibles
            // 
            this.lblResultadoArticulosDisponibles.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblResultadoArticulosDisponibles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblResultadoArticulosDisponibles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultadoArticulosDisponibles.Location = new System.Drawing.Point(14, 90);
            this.lblResultadoArticulosDisponibles.Name = "lblResultadoArticulosDisponibles";
            this.lblResultadoArticulosDisponibles.Size = new System.Drawing.Size(618, 25);
            this.lblResultadoArticulosDisponibles.TabIndex = 4;
            this.lblResultadoArticulosDisponibles.Text = "Resultado";
            this.lblResultadoArticulosDisponibles.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvArticulosDisponibles
            // 
            this.dgvArticulosDisponibles.AllowUserToAddRows = false;
            this.dgvArticulosDisponibles.AllowUserToDeleteRows = false;
            this.dgvArticulosDisponibles.AllowUserToResizeColumns = false;
            this.dgvArticulosDisponibles.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvArticulosDisponibles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvArticulosDisponibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvArticulosDisponibles.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvArticulosDisponibles.Location = new System.Drawing.Point(14, 118);
            this.dgvArticulosDisponibles.MultiSelect = false;
            this.dgvArticulosDisponibles.Name = "dgvArticulosDisponibles";
            this.dgvArticulosDisponibles.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvArticulosDisponibles.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvArticulosDisponibles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvArticulosDisponibles.Size = new System.Drawing.Size(618, 440);
            this.dgvArticulosDisponibles.TabIndex = 4;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(668, 379);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(30, 28);
            this.btnAgregar.TabIndex = 5;
            this.btnAgregar.Text = "<<";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // pnlIzquierda
            // 
            this.pnlIzquierda.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlIzquierda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlIzquierda.Controls.Add(this.cbxFiltroCodArticuloEnLista);
            this.pnlIzquierda.Controls.Add(this.lblFiltroPorArticuloEnLista);
            this.pnlIzquierda.Controls.Add(this.cbxFiltroNombreArticuloEnLista);
            this.pnlIzquierda.Controls.Add(this.lblArticulosEnLista);
            this.pnlIzquierda.Controls.Add(this.btnFiltrarArticuloEnLista);
            this.pnlIzquierda.Controls.Add(this.btnGuardar);
            this.pnlIzquierda.Controls.Add(this.txtPrecio);
            this.pnlIzquierda.Controls.Add(this.lblPrecio);
            this.pnlIzquierda.Controls.Add(this.txtCodDeArticulo);
            this.pnlIzquierda.Controls.Add(this.txtCodDeProveedor);
            this.pnlIzquierda.Controls.Add(this.lblCodDeProveedor);
            this.pnlIzquierda.Controls.Add(this.lblCodDeArticulo);
            this.pnlIzquierda.Controls.Add(this.lblResultadoArticulosEnLista);
            this.pnlIzquierda.Controls.Add(this.dgvArticulosEnLista);
            this.pnlIzquierda.Location = new System.Drawing.Point(12, 114);
            this.pnlIzquierda.Name = "pnlIzquierda";
            this.pnlIzquierda.Size = new System.Drawing.Size(650, 576);
            this.pnlIzquierda.TabIndex = 2;
            // 
            // cbxFiltroCodArticuloEnLista
            // 
            this.cbxFiltroCodArticuloEnLista.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxFiltroCodArticuloEnLista.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxFiltroCodArticuloEnLista.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxFiltroCodArticuloEnLista.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxFiltroCodArticuloEnLista.FormattingEnabled = true;
            this.cbxFiltroCodArticuloEnLista.Location = new System.Drawing.Point(117, 52);
            this.cbxFiltroCodArticuloEnLista.Name = "cbxFiltroCodArticuloEnLista";
            this.cbxFiltroCodArticuloEnLista.Size = new System.Drawing.Size(101, 23);
            this.cbxFiltroCodArticuloEnLista.TabIndex = 1;
            this.cbxFiltroCodArticuloEnLista.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxFiltroArticulosEnLista_KeyDown);
            // 
            // lblFiltroPorArticuloEnLista
            // 
            this.lblFiltroPorArticuloEnLista.AutoSize = true;
            this.lblFiltroPorArticuloEnLista.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltroPorArticuloEnLista.Location = new System.Drawing.Point(13, 55);
            this.lblFiltroPorArticuloEnLista.Name = "lblFiltroPorArticuloEnLista";
            this.lblFiltroPorArticuloEnLista.Size = new System.Drawing.Size(98, 15);
            this.lblFiltroPorArticuloEnLista.TabIndex = 158;
            this.lblFiltroPorArticuloEnLista.Text = "Filtro por Artículo";
            // 
            // cbxFiltroNombreArticuloEnLista
            // 
            this.cbxFiltroNombreArticuloEnLista.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxFiltroNombreArticuloEnLista.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxFiltroNombreArticuloEnLista.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxFiltroNombreArticuloEnLista.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxFiltroNombreArticuloEnLista.FormattingEnabled = true;
            this.cbxFiltroNombreArticuloEnLista.Location = new System.Drawing.Point(224, 52);
            this.cbxFiltroNombreArticuloEnLista.Name = "cbxFiltroNombreArticuloEnLista";
            this.cbxFiltroNombreArticuloEnLista.Size = new System.Drawing.Size(308, 23);
            this.cbxFiltroNombreArticuloEnLista.TabIndex = 2;
            this.cbxFiltroNombreArticuloEnLista.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxFiltroArticulosEnLista_KeyDown);
            // 
            // lblArticulosEnLista
            // 
            this.lblArticulosEnLista.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblArticulosEnLista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblArticulosEnLista.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArticulosEnLista.Location = new System.Drawing.Point(16, 11);
            this.lblArticulosEnLista.Name = "lblArticulosEnLista";
            this.lblArticulosEnLista.Size = new System.Drawing.Size(618, 25);
            this.lblArticulosEnLista.TabIndex = 157;
            this.lblArticulosEnLista.Text = "Artículos en Lista";
            this.lblArticulosEnLista.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnFiltrarArticuloEnLista
            // 
            this.btnFiltrarArticuloEnLista.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrarArticuloEnLista.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrarArticuloEnLista.Location = new System.Drawing.Point(538, 45);
            this.btnFiltrarArticuloEnLista.Name = "btnFiltrarArticuloEnLista";
            this.btnFiltrarArticuloEnLista.Size = new System.Drawing.Size(96, 35);
            this.btnFiltrarArticuloEnLista.TabIndex = 3;
            this.btnFiltrarArticuloEnLista.Text = "Filtrar";
            this.btnFiltrarArticuloEnLista.UseVisualStyleBackColor = true;
            this.btnFiltrarArticuloEnLista.Click += new System.EventHandler(this.btnFiltrarArticuloEnLista_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(538, 525);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(96, 35);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtPrecio
            // 
            this.txtPrecio.BackColor = System.Drawing.SystemColors.Window;
            this.txtPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecio.Location = new System.Drawing.Point(127, 494);
            this.txtPrecio.MaxLength = 12;
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(507, 21);
            this.txtPrecio.TabIndex = 7;
            this.txtPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecio_KeyPress);
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio.Location = new System.Drawing.Point(13, 497);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(42, 15);
            this.lblPrecio.TabIndex = 153;
            this.lblPrecio.Text = "Precio";
            // 
            // txtCodDeArticulo
            // 
            this.txtCodDeArticulo.BackColor = System.Drawing.SystemColors.Window;
            this.txtCodDeArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodDeArticulo.Location = new System.Drawing.Point(127, 467);
            this.txtCodDeArticulo.MaxLength = 12;
            this.txtCodDeArticulo.Name = "txtCodDeArticulo";
            this.txtCodDeArticulo.ReadOnly = true;
            this.txtCodDeArticulo.Size = new System.Drawing.Size(507, 21);
            this.txtCodDeArticulo.TabIndex = 6;
            // 
            // txtCodDeProveedor
            // 
            this.txtCodDeProveedor.BackColor = System.Drawing.SystemColors.Window;
            this.txtCodDeProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodDeProveedor.Location = new System.Drawing.Point(127, 440);
            this.txtCodDeProveedor.MaxLength = 12;
            this.txtCodDeProveedor.Name = "txtCodDeProveedor";
            this.txtCodDeProveedor.ReadOnly = true;
            this.txtCodDeProveedor.Size = new System.Drawing.Size(507, 21);
            this.txtCodDeProveedor.TabIndex = 5;
            // 
            // lblCodDeProveedor
            // 
            this.lblCodDeProveedor.AutoSize = true;
            this.lblCodDeProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodDeProveedor.Location = new System.Drawing.Point(13, 443);
            this.lblCodDeProveedor.Name = "lblCodDeProveedor";
            this.lblCodDeProveedor.Size = new System.Drawing.Size(108, 15);
            this.lblCodDeProveedor.TabIndex = 152;
            this.lblCodDeProveedor.Text = "Cód. de Proveedor";
            // 
            // lblCodDeArticulo
            // 
            this.lblCodDeArticulo.AutoSize = true;
            this.lblCodDeArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodDeArticulo.Location = new System.Drawing.Point(13, 470);
            this.lblCodDeArticulo.Name = "lblCodDeArticulo";
            this.lblCodDeArticulo.Size = new System.Drawing.Size(92, 15);
            this.lblCodDeArticulo.TabIndex = 151;
            this.lblCodDeArticulo.Text = "Cód. de Artículo";
            // 
            // lblResultadoArticulosEnLista
            // 
            this.lblResultadoArticulosEnLista.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblResultadoArticulosEnLista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblResultadoArticulosEnLista.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultadoArticulosEnLista.Location = new System.Drawing.Point(16, 90);
            this.lblResultadoArticulosEnLista.Name = "lblResultadoArticulosEnLista";
            this.lblResultadoArticulosEnLista.Size = new System.Drawing.Size(618, 25);
            this.lblResultadoArticulosEnLista.TabIndex = 4;
            this.lblResultadoArticulosEnLista.Text = "Resultado";
            this.lblResultadoArticulosEnLista.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvArticulosEnLista
            // 
            this.dgvArticulosEnLista.AllowUserToAddRows = false;
            this.dgvArticulosEnLista.AllowUserToDeleteRows = false;
            this.dgvArticulosEnLista.AllowUserToResizeColumns = false;
            this.dgvArticulosEnLista.AllowUserToResizeRows = false;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvArticulosEnLista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvArticulosEnLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvArticulosEnLista.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvArticulosEnLista.Location = new System.Drawing.Point(16, 118);
            this.dgvArticulosEnLista.MultiSelect = false;
            this.dgvArticulosEnLista.Name = "dgvArticulosEnLista";
            this.dgvArticulosEnLista.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvArticulosEnLista.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvArticulosEnLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvArticulosEnLista.Size = new System.Drawing.Size(618, 307);
            this.dgvArticulosEnLista.TabIndex = 4;
            this.dgvArticulosEnLista.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArticulosEnLista_CellContentClick);
            // 
            // lblConsultaDeProveedores
            // 
            this.lblConsultaDeProveedores.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblConsultaDeProveedores.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblConsultaDeProveedores.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsultaDeProveedores.Location = new System.Drawing.Point(16, 10);
            this.lblConsultaDeProveedores.Name = "lblConsultaDeProveedores";
            this.lblConsultaDeProveedores.Size = new System.Drawing.Size(1308, 25);
            this.lblConsultaDeProveedores.TabIndex = 58;
            this.lblConsultaDeProveedores.Text = "Consulta de Proveedor";
            this.lblConsultaDeProveedores.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnQuitar
            // 
            this.btnQuitar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitar.Location = new System.Drawing.Point(668, 413);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(30, 28);
            this.btnQuitar.TabIndex = 6;
            this.btnQuitar.Text = ">>";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // cbxFiltroNombreDeProveedor
            // 
            this.cbxFiltroNombreDeProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFiltroNombreDeProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxFiltroNombreDeProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxFiltroNombreDeProveedor.FormattingEnabled = true;
            this.cbxFiltroNombreDeProveedor.Location = new System.Drawing.Point(235, 53);
            this.cbxFiltroNombreDeProveedor.Name = "cbxFiltroNombreDeProveedor";
            this.cbxFiltroNombreDeProveedor.Size = new System.Drawing.Size(297, 23);
            this.cbxFiltroNombreDeProveedor.TabIndex = 2;
            this.cbxFiltroNombreDeProveedor.SelectedIndexChanged += new System.EventHandler(this.cbxFiltroNombreDeProveedor_SelectedIndexChanged);
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlSuperior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSuperior.Controls.Add(this.lblFiltroPorProveedor);
            this.pnlSuperior.Controls.Add(this.cbxFiltroCodDeProveedor);
            this.pnlSuperior.Controls.Add(this.lblConsultaDeProveedores);
            this.pnlSuperior.Controls.Add(this.cbxFiltroNombreDeProveedor);
            this.pnlSuperior.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlSuperior.Location = new System.Drawing.Point(12, 12);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(1342, 96);
            this.pnlSuperior.TabIndex = 1;
            // 
            // lblFiltroPorProveedor
            // 
            this.lblFiltroPorProveedor.AutoSize = true;
            this.lblFiltroPorProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltroPorProveedor.Location = new System.Drawing.Point(13, 56);
            this.lblFiltroPorProveedor.Name = "lblFiltroPorProveedor";
            this.lblFiltroPorProveedor.Size = new System.Drawing.Size(114, 15);
            this.lblFiltroPorProveedor.TabIndex = 159;
            this.lblFiltroPorProveedor.Text = "Filtro por Proveedor";
            // 
            // cbxFiltroCodDeProveedor
            // 
            this.cbxFiltroCodDeProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFiltroCodDeProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxFiltroCodDeProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxFiltroCodDeProveedor.FormattingEnabled = true;
            this.cbxFiltroCodDeProveedor.Location = new System.Drawing.Point(133, 53);
            this.cbxFiltroCodDeProveedor.Name = "cbxFiltroCodDeProveedor";
            this.cbxFiltroCodDeProveedor.Size = new System.Drawing.Size(96, 23);
            this.cbxFiltroCodDeProveedor.TabIndex = 1;
            this.cbxFiltroCodDeProveedor.SelectedIndexChanged += new System.EventHandler(this.cbxFiltroCodDeProveedor_SelectedIndexChanged);
            // 
            // frmListaDePrecioCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 730);
            this.Controls.Add(this.pnlSuperior);
            this.Controls.Add(this.pnlIzquierda);
            this.Controls.Add(this.pnlDerecha);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.btnAgregar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmListaDePrecioCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de Precio de Proveedores";
            this.Load += new System.EventHandler(this.ListaDePrecioCompra_Load);
            this.pnlDerecha.ResumeLayout(false);
            this.pnlDerecha.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulosDisponibles)).EndInit();
            this.pnlIzquierda.ResumeLayout(false);
            this.pnlIzquierda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulosEnLista)).EndInit();
            this.pnlSuperior.ResumeLayout(false);
            this.pnlSuperior.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDerecha;
        private System.Windows.Forms.ComboBox cbxFiltroNombreArticuloDisponible;
        private System.Windows.Forms.Label lblConsultaDeArticulos;
        private System.Windows.Forms.Button btnFiltrarArticuloDisponible;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label lblResultadoArticulosDisponibles;
        private System.Windows.Forms.DataGridView dgvArticulosDisponibles;
        private System.Windows.Forms.Panel pnlIzquierda;
        private System.Windows.Forms.Label lblConsultaDeProveedores;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Label lblResultadoArticulosEnLista;
        private System.Windows.Forms.DataGridView dgvArticulosEnLista;
        private System.Windows.Forms.ComboBox cbxFiltroNombreDeProveedor;
        private System.Windows.Forms.ComboBox cbxFiltroCodArticuloDisponible;
        private System.Windows.Forms.Label lblFiltroPorArticuloDisponible;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.TextBox txtCodDeArticulo;
        private System.Windows.Forms.TextBox txtCodDeProveedor;
        private System.Windows.Forms.Label lblCodDeProveedor;
        private System.Windows.Forms.Label lblCodDeArticulo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.ComboBox cbxFiltroCodArticuloEnLista;
        private System.Windows.Forms.Label lblFiltroPorArticuloEnLista;
        private System.Windows.Forms.ComboBox cbxFiltroNombreArticuloEnLista;
        private System.Windows.Forms.Label lblArticulosEnLista;
        private System.Windows.Forms.Button btnFiltrarArticuloEnLista;
        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.Label lblFiltroPorProveedor;
        private System.Windows.Forms.ComboBox cbxFiltroCodDeProveedor;
    }
}