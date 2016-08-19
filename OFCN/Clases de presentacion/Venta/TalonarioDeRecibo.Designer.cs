namespace OFC
{
    partial class TalonarioDeRecibo
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
            this.lblGenerandoNumeracion = new System.Windows.Forms.Label();
            this.pnlDerechoInferior = new System.Windows.Forms.Panel();
            this.lblCrearRecibos = new System.Windows.Forms.Label();
            this.btnCrearRecibos = new System.Windows.Forms.Button();
            this.lblNumeroInicial = new System.Windows.Forms.Label();
            this.cbxNroDeTalonario = new System.Windows.Forms.ComboBox();
            this.txtNumeroInicial = new System.Windows.Forms.TextBox();
            this.lblNroDeTalonario = new System.Windows.Forms.Label();
            this.lblNumeroFinal = new System.Windows.Forms.Label();
            this.txtNumeroFinal = new System.Windows.Forms.TextBox();
            this.pnlDerechoSuperior = new System.Windows.Forms.Panel();
            this.lblCrearTalonarioDeRecibo = new System.Windows.Forms.Label();
            this.btnCrearTalonario = new System.Windows.Forms.Button();
            this.txtNuevoNroDeTalonario = new System.Windows.Forms.TextBox();
            this.lblNuevoNroDeTalonario = new System.Windows.Forms.Label();
            this.pnlIzquierdoSuperior = new System.Windows.Forms.Panel();
            this.btnRecuperarRecibo = new System.Windows.Forms.Button();
            this.btnBuscarTalonario = new System.Windows.Forms.Button();
            this.cbxNroTalonario = new System.Windows.Forms.ComboBox();
            this.txtNumeroDeRecibo = new System.Windows.Forms.TextBox();
            this.btnAnular = new System.Windows.Forms.Button();
            this.dgvTalonario = new System.Windows.Forms.DataGridView();
            this.lblNumeroDeRecibo = new System.Windows.Forms.Label();
            this.lblConsultarTalonarioDeRecibo = new System.Windows.Forms.Label();
            this.lblNroTalonario = new System.Windows.Forms.Label();
            this.pnlDerechoInferior.SuspendLayout();
            this.pnlDerechoSuperior.SuspendLayout();
            this.pnlIzquierdoSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTalonario)).BeginInit();
            this.SuspendLayout();
            // 
            // lblGenerandoNumeracion
            // 
            this.lblGenerandoNumeracion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGenerandoNumeracion.Location = new System.Drawing.Point(728, 309);
            this.lblGenerandoNumeracion.Name = "lblGenerandoNumeracion";
            this.lblGenerandoNumeracion.Size = new System.Drawing.Size(612, 56);
            this.lblGenerandoNumeracion.TabIndex = 146;
            this.lblGenerandoNumeracion.Text = "SE ESTÁ GENERANDO LA NUMERACIÓN, AGUARDE UNOS INSTANTES POR FAVOR...";
            this.lblGenerandoNumeracion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblGenerandoNumeracion.Visible = false;
            // 
            // pnlDerechoInferior
            // 
            this.pnlDerechoInferior.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlDerechoInferior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDerechoInferior.Controls.Add(this.lblCrearRecibos);
            this.pnlDerechoInferior.Controls.Add(this.btnCrearRecibos);
            this.pnlDerechoInferior.Controls.Add(this.lblNumeroInicial);
            this.pnlDerechoInferior.Controls.Add(this.cbxNroDeTalonario);
            this.pnlDerechoInferior.Controls.Add(this.txtNumeroInicial);
            this.pnlDerechoInferior.Controls.Add(this.lblNroDeTalonario);
            this.pnlDerechoInferior.Controls.Add(this.lblNumeroFinal);
            this.pnlDerechoInferior.Controls.Add(this.txtNumeroFinal);
            this.pnlDerechoInferior.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlDerechoInferior.Location = new System.Drawing.Point(704, 116);
            this.pnlDerechoInferior.Name = "pnlDerechoInferior";
            this.pnlDerechoInferior.Size = new System.Drawing.Size(650, 168);
            this.pnlDerechoInferior.TabIndex = 3;
            // 
            // lblCrearRecibos
            // 
            this.lblCrearRecibos.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblCrearRecibos.Location = new System.Drawing.Point(3, 16);
            this.lblCrearRecibos.Name = "lblCrearRecibos";
            this.lblCrearRecibos.Size = new System.Drawing.Size(641, 25);
            this.lblCrearRecibos.TabIndex = 140;
            this.lblCrearRecibos.Text = "Crear Recibos";
            this.lblCrearRecibos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCrearRecibos
            // 
            this.btnCrearRecibos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCrearRecibos.Location = new System.Drawing.Point(537, 105);
            this.btnCrearRecibos.Name = "btnCrearRecibos";
            this.btnCrearRecibos.Size = new System.Drawing.Size(107, 35);
            this.btnCrearRecibos.TabIndex = 4;
            this.btnCrearRecibos.Text = "Crear Recibos";
            this.btnCrearRecibos.UseVisualStyleBackColor = true;
            this.btnCrearRecibos.Click += new System.EventHandler(this.btnCrearRecibos_Click);
            // 
            // lblNumeroInicial
            // 
            this.lblNumeroInicial.AutoSize = true;
            this.lblNumeroInicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroInicial.Location = new System.Drawing.Point(14, 61);
            this.lblNumeroInicial.Name = "lblNumeroInicial";
            this.lblNumeroInicial.Size = new System.Drawing.Size(87, 15);
            this.lblNumeroInicial.TabIndex = 73;
            this.lblNumeroInicial.Text = "Número Inicial";
            // 
            // cbxNroDeTalonario
            // 
            this.cbxNroDeTalonario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxNroDeTalonario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxNroDeTalonario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxNroDeTalonario.FormattingEnabled = true;
            this.cbxNroDeTalonario.Location = new System.Drawing.Point(160, 112);
            this.cbxNroDeTalonario.Name = "cbxNroDeTalonario";
            this.cbxNroDeTalonario.Size = new System.Drawing.Size(112, 23);
            this.cbxNroDeTalonario.TabIndex = 3;
            // 
            // txtNumeroInicial
            // 
            this.txtNumeroInicial.Location = new System.Drawing.Point(160, 58);
            this.txtNumeroInicial.MaxLength = 10;
            this.txtNumeroInicial.Name = "txtNumeroInicial";
            this.txtNumeroInicial.Size = new System.Drawing.Size(112, 21);
            this.txtNumeroInicial.TabIndex = 1;
            // 
            // lblNroDeTalonario
            // 
            this.lblNroDeTalonario.AutoSize = true;
            this.lblNroDeTalonario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroDeTalonario.Location = new System.Drawing.Point(14, 115);
            this.lblNroDeTalonario.Name = "lblNroDeTalonario";
            this.lblNroDeTalonario.Size = new System.Drawing.Size(102, 15);
            this.lblNroDeTalonario.TabIndex = 138;
            this.lblNroDeTalonario.Text = "Nro. de Talonario";
            // 
            // lblNumeroFinal
            // 
            this.lblNumeroFinal.AutoSize = true;
            this.lblNumeroFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroFinal.Location = new System.Drawing.Point(14, 88);
            this.lblNumeroFinal.Name = "lblNumeroFinal";
            this.lblNumeroFinal.Size = new System.Drawing.Size(82, 15);
            this.lblNumeroFinal.TabIndex = 136;
            this.lblNumeroFinal.Text = "Numero Final";
            // 
            // txtNumeroFinal
            // 
            this.txtNumeroFinal.Location = new System.Drawing.Point(160, 85);
            this.txtNumeroFinal.MaxLength = 10;
            this.txtNumeroFinal.Name = "txtNumeroFinal";
            this.txtNumeroFinal.Size = new System.Drawing.Size(112, 21);
            this.txtNumeroFinal.TabIndex = 2;
            // 
            // pnlDerechoSuperior
            // 
            this.pnlDerechoSuperior.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlDerechoSuperior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDerechoSuperior.Controls.Add(this.lblCrearTalonarioDeRecibo);
            this.pnlDerechoSuperior.Controls.Add(this.btnCrearTalonario);
            this.pnlDerechoSuperior.Controls.Add(this.txtNuevoNroDeTalonario);
            this.pnlDerechoSuperior.Controls.Add(this.lblNuevoNroDeTalonario);
            this.pnlDerechoSuperior.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlDerechoSuperior.Location = new System.Drawing.Point(704, 12);
            this.pnlDerechoSuperior.Name = "pnlDerechoSuperior";
            this.pnlDerechoSuperior.Size = new System.Drawing.Size(650, 98);
            this.pnlDerechoSuperior.TabIndex = 2;
            // 
            // lblCrearTalonarioDeRecibo
            // 
            this.lblCrearTalonarioDeRecibo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblCrearTalonarioDeRecibo.Location = new System.Drawing.Point(3, 15);
            this.lblCrearTalonarioDeRecibo.Name = "lblCrearTalonarioDeRecibo";
            this.lblCrearTalonarioDeRecibo.Size = new System.Drawing.Size(641, 25);
            this.lblCrearTalonarioDeRecibo.TabIndex = 135;
            this.lblCrearTalonarioDeRecibo.Text = "Crear Talonario de Recibo";
            this.lblCrearTalonarioDeRecibo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCrearTalonario
            // 
            this.btnCrearTalonario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCrearTalonario.Location = new System.Drawing.Point(537, 50);
            this.btnCrearTalonario.Name = "btnCrearTalonario";
            this.btnCrearTalonario.Size = new System.Drawing.Size(107, 35);
            this.btnCrearTalonario.TabIndex = 2;
            this.btnCrearTalonario.Text = "Crear Talonario";
            this.btnCrearTalonario.UseVisualStyleBackColor = true;
            this.btnCrearTalonario.Click += new System.EventHandler(this.btnCrearTalonario_Click);
            // 
            // txtNuevoNroDeTalonario
            // 
            this.txtNuevoNroDeTalonario.Location = new System.Drawing.Point(160, 57);
            this.txtNuevoNroDeTalonario.MaxLength = 4;
            this.txtNuevoNroDeTalonario.Name = "txtNuevoNroDeTalonario";
            this.txtNuevoNroDeTalonario.Size = new System.Drawing.Size(112, 21);
            this.txtNuevoNroDeTalonario.TabIndex = 1;
            // 
            // lblNuevoNroDeTalonario
            // 
            this.lblNuevoNroDeTalonario.AutoSize = true;
            this.lblNuevoNroDeTalonario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNuevoNroDeTalonario.Location = new System.Drawing.Point(14, 60);
            this.lblNuevoNroDeTalonario.Name = "lblNuevoNroDeTalonario";
            this.lblNuevoNroDeTalonario.Size = new System.Drawing.Size(140, 15);
            this.lblNuevoNroDeTalonario.TabIndex = 132;
            this.lblNuevoNroDeTalonario.Text = "Nuevo Nro. de Talonario";
            // 
            // pnlIzquierdoSuperior
            // 
            this.pnlIzquierdoSuperior.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlIzquierdoSuperior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlIzquierdoSuperior.Controls.Add(this.btnRecuperarRecibo);
            this.pnlIzquierdoSuperior.Controls.Add(this.btnBuscarTalonario);
            this.pnlIzquierdoSuperior.Controls.Add(this.cbxNroTalonario);
            this.pnlIzquierdoSuperior.Controls.Add(this.txtNumeroDeRecibo);
            this.pnlIzquierdoSuperior.Controls.Add(this.btnAnular);
            this.pnlIzquierdoSuperior.Controls.Add(this.dgvTalonario);
            this.pnlIzquierdoSuperior.Controls.Add(this.lblNumeroDeRecibo);
            this.pnlIzquierdoSuperior.Controls.Add(this.lblConsultarTalonarioDeRecibo);
            this.pnlIzquierdoSuperior.Controls.Add(this.lblNroTalonario);
            this.pnlIzquierdoSuperior.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlIzquierdoSuperior.Location = new System.Drawing.Point(12, 12);
            this.pnlIzquierdoSuperior.Name = "pnlIzquierdoSuperior";
            this.pnlIzquierdoSuperior.Size = new System.Drawing.Size(649, 685);
            this.pnlIzquierdoSuperior.TabIndex = 1;
            // 
            // btnRecuperarRecibo
            // 
            this.btnRecuperarRecibo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRecuperarRecibo.Location = new System.Drawing.Point(384, 634);
            this.btnRecuperarRecibo.Name = "btnRecuperarRecibo";
            this.btnRecuperarRecibo.Size = new System.Drawing.Size(120, 35);
            this.btnRecuperarRecibo.TabIndex = 5;
            this.btnRecuperarRecibo.Text = "Recuperar Recibo";
            this.btnRecuperarRecibo.UseVisualStyleBackColor = true;
            this.btnRecuperarRecibo.Click += new System.EventHandler(this.btnRecuperarRecibo_Click);
            // 
            // btnBuscarTalonario
            // 
            this.btnBuscarTalonario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarTalonario.Location = new System.Drawing.Point(523, 45);
            this.btnBuscarTalonario.Name = "btnBuscarTalonario";
            this.btnBuscarTalonario.Size = new System.Drawing.Size(107, 35);
            this.btnBuscarTalonario.TabIndex = 3;
            this.btnBuscarTalonario.Text = "Buscar";
            this.btnBuscarTalonario.UseVisualStyleBackColor = true;
            this.btnBuscarTalonario.Click += new System.EventHandler(this.btnBuscarTalonario_Click);
            // 
            // cbxNroTalonario
            // 
            this.cbxNroTalonario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxNroTalonario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxNroTalonario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxNroTalonario.FormattingEnabled = true;
            this.cbxNroTalonario.Location = new System.Drawing.Point(122, 52);
            this.cbxNroTalonario.Name = "cbxNroTalonario";
            this.cbxNroTalonario.Size = new System.Drawing.Size(128, 23);
            this.cbxNroTalonario.TabIndex = 1;
            this.cbxNroTalonario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbxNroTalonario_KeyPress); //feb 1.8 fix
            // 
            // txtNumeroDeRecibo
            // 
            this.txtNumeroDeRecibo.Location = new System.Drawing.Point(373, 52);
            this.txtNumeroDeRecibo.MaxLength = 15;
            this.txtNumeroDeRecibo.Name = "txtNumeroDeRecibo";
            this.txtNumeroDeRecibo.Size = new System.Drawing.Size(128, 21);
            this.txtNumeroDeRecibo.TabIndex = 2;
            this.txtNumeroDeRecibo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxNroTalonario_KeyDown); //feb 1.8 fix
            // 
            // btnAnular
            // 
            this.btnAnular.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnular.Location = new System.Drawing.Point(510, 634);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(120, 35);
            this.btnAnular.TabIndex = 6;
            this.btnAnular.Text = "Anular Recibo";
            this.btnAnular.UseVisualStyleBackColor = true;
            this.btnAnular.Click += new System.EventHandler(this.btnAnular_Click);
            // 
            // dgvTalonario
            // 
            this.dgvTalonario.AllowUserToAddRows = false;
            this.dgvTalonario.AllowUserToDeleteRows = false;
            this.dgvTalonario.AllowUserToResizeColumns = false;
            this.dgvTalonario.AllowUserToResizeRows = false;
            this.dgvTalonario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTalonario.Location = new System.Drawing.Point(17, 87);
            this.dgvTalonario.MultiSelect = false;
            this.dgvTalonario.Name = "dgvTalonario";
            this.dgvTalonario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvTalonario.Size = new System.Drawing.Size(613, 534);
            this.dgvTalonario.TabIndex = 4;
            // 
            // lblNumeroDeRecibo
            // 
            this.lblNumeroDeRecibo.AutoSize = true;
            this.lblNumeroDeRecibo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroDeRecibo.Location = new System.Drawing.Point(256, 55);
            this.lblNumeroDeRecibo.Name = "lblNumeroDeRecibo";
            this.lblNumeroDeRecibo.Size = new System.Drawing.Size(111, 15);
            this.lblNumeroDeRecibo.TabIndex = 142;
            this.lblNumeroDeRecibo.Text = "Número de Recibo";
            // 
            // lblConsultarTalonarioDeRecibo
            // 
            this.lblConsultarTalonarioDeRecibo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblConsultarTalonarioDeRecibo.Location = new System.Drawing.Point(3, 12);
            this.lblConsultarTalonarioDeRecibo.Name = "lblConsultarTalonarioDeRecibo";
            this.lblConsultarTalonarioDeRecibo.Size = new System.Drawing.Size(641, 25);
            this.lblConsultarTalonarioDeRecibo.TabIndex = 70;
            this.lblConsultarTalonarioDeRecibo.Text = "Consultar Talonario de Recibo";
            this.lblConsultarTalonarioDeRecibo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNroTalonario
            // 
            this.lblNroTalonario.AutoSize = true;
            this.lblNroTalonario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroTalonario.Location = new System.Drawing.Point(14, 55);
            this.lblNroTalonario.Name = "lblNroTalonario";
            this.lblNroTalonario.Size = new System.Drawing.Size(102, 15);
            this.lblNroTalonario.TabIndex = 119;
            this.lblNroTalonario.Text = "Nro. de Talonario";
            // 
            // TalonarioDeRecibo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 730);
            this.Controls.Add(this.lblGenerandoNumeracion);
            this.Controls.Add(this.pnlDerechoInferior);
            this.Controls.Add(this.pnlDerechoSuperior);
            this.Controls.Add(this.pnlIzquierdoSuperior);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "TalonarioDeRecibo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Talonario de Recibo";
            this.Load += new System.EventHandler(this.TalonarioDeRecibo_Load);
            this.pnlDerechoInferior.ResumeLayout(false);
            this.pnlDerechoInferior.PerformLayout();
            this.pnlDerechoSuperior.ResumeLayout(false);
            this.pnlDerechoSuperior.PerformLayout();
            this.pnlIzquierdoSuperior.ResumeLayout(false);
            this.pnlIzquierdoSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTalonario)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblGenerandoNumeracion;
        private System.Windows.Forms.Panel pnlDerechoInferior;
        private System.Windows.Forms.Label lblCrearRecibos;
        private System.Windows.Forms.Button btnCrearRecibos;
        private System.Windows.Forms.Label lblNumeroInicial;
        private System.Windows.Forms.ComboBox cbxNroDeTalonario;
        private System.Windows.Forms.TextBox txtNumeroInicial;
        private System.Windows.Forms.Label lblNroDeTalonario;
        private System.Windows.Forms.Label lblNumeroFinal;
        private System.Windows.Forms.TextBox txtNumeroFinal;
        private System.Windows.Forms.Panel pnlDerechoSuperior;
        private System.Windows.Forms.Label lblCrearTalonarioDeRecibo;
        private System.Windows.Forms.Button btnCrearTalonario;
        private System.Windows.Forms.TextBox txtNuevoNroDeTalonario;
        private System.Windows.Forms.Label lblNuevoNroDeTalonario;
        private System.Windows.Forms.Panel pnlIzquierdoSuperior;
        private System.Windows.Forms.Button btnRecuperarRecibo;
        private System.Windows.Forms.Button btnBuscarTalonario;
        private System.Windows.Forms.ComboBox cbxNroTalonario;
        private System.Windows.Forms.TextBox txtNumeroDeRecibo;
        private System.Windows.Forms.Button btnAnular;
        private System.Windows.Forms.DataGridView dgvTalonario;
        private System.Windows.Forms.Label lblNumeroDeRecibo;
        private System.Windows.Forms.Label lblConsultarTalonarioDeRecibo;
        private System.Windows.Forms.Label lblNroTalonario;
    }
}