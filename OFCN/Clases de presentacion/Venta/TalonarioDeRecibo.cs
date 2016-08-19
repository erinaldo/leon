using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

//feb 1.8
namespace OFC
{
    public partial class TalonarioDeRecibo : Form
    {
        private Talonario _talonario;
        private TalonarioDetalle _talonario_detalle;
        private Recibo _recibo;

        public TalonarioDeRecibo()
        {
            InitializeComponent();
            _talonario = new Talonario();
            _talonario_detalle = new TalonarioDetalle();
            _recibo = new Recibo();
        }

        private void TalonarioDeRecibo_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(1376, 762);
            if (Resolucion.Escalar())
            {
                Resolucion _ajusteResolucion = new Resolucion();
                _ajusteResolucion.ResizeForm(this, 1376, 762);
                this.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width - 1, Screen.PrimaryScreen.Bounds.Height - 1);
            }

            cargarFiltroTalonario();
            configurarGridTalonario();

            lblGenerandoNumeracion.Visible = false;
        }

        void cargarFiltroTalonario()
        {
            _talonario.refreshOwnData();
            this.cbxNroTalonario.DataSource = _talonario.OwnDataList;

            List<string> aux = new List<string>(_talonario.OwnDataList);
            this.cbxNroDeTalonario.DataSource = aux;
        }

        private void configurarGridTalonario()
        {
            this.dgvTalonario.AutoGenerateColumns = false;

            DataGridViewCheckBoxColumn procesar = new DataGridViewCheckBoxColumn();
            procesar.CellTemplate = new DataGridViewCheckboxCellFilter();
            procesar.Width = 26;
            procesar.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            procesar.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            procesar.ReadOnly = false;

            DataGridViewTextBoxColumn _identificador = new DataGridViewTextBoxColumn();
            _identificador.DataPropertyName = "id_talonario";
            _identificador.HeaderText = "Nro. de Talonario";
            _identificador.Width = 142;
            _identificador.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _identificador.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _identificador.ReadOnly = true;

            DataGridViewTextBoxColumn _numero_comprobante = new DataGridViewTextBoxColumn();
            _numero_comprobante.DataPropertyName = "numero_comprobante";
            _numero_comprobante.HeaderText = "Cod. comprobante";
            _numero_comprobante.Width = 210;
            _numero_comprobante.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _numero_comprobante.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _numero_comprobante.ReadOnly = true;

            DataGridViewTextBoxColumn _estado = new DataGridViewTextBoxColumn();
            _estado.DataPropertyName = "estado";
            _estado.HeaderText = "Estado";
            _estado.Width = 175;
            _estado.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _estado.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _estado.ReadOnly = true;

            this.dgvTalonario.Columns.Add(procesar);
            this.dgvTalonario.Columns.Add(_identificador);
            this.dgvTalonario.Columns.Add(_numero_comprobante);
            this.dgvTalonario.Columns.Add(_estado);
            show_chkBox();
        }

        private void show_chkBox()
        {
            Rectangle rect = dgvTalonario.GetCellDisplayRectangle(0, -1, true);

            // set checkbox header to center of header cell. +1 pixel to position 
            rect.Y = 3;
            rect.X = rect.Location.X + (rect.Width / 4);
            CheckBox checkboxHeader = new CheckBox();
            checkboxHeader.Name = "checkboxHeader";
            //dgvOrdenesDeTrabajo[0, 0].ToolTipText = "P.";
            checkboxHeader.Size = new Size(18, 18);
            checkboxHeader.Location = rect.Location;
            checkboxHeader.BackColor = dgvTalonario.RowHeadersDefaultCellStyle.BackColor;
            checkboxHeader.CheckedChanged += new EventHandler(checkboxHeader_CheckedChanged);
            dgvTalonario.Controls.Add(checkboxHeader);
        }

        private void checkboxHeader_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox headerBox = ((CheckBox)dgvTalonario.Controls.Find("checkboxHeader", true)[0]);

            int valor;

            if (headerBox.Checked)
            {
                valor = 1;
            }
            else
            {
                valor = 0;
            }

            for (int i = 0; i < dgvTalonario.RowCount; i++)
            {

                dgvTalonario.Rows[i].Cells[0].Value = valor;

            }

            dgvTalonario.EndEdit();

        }

        private void btnBuscarTalonario_Click(object sender, EventArgs e)
        {
            try
            {

                cargarGridTalonario();

            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Validación Talonaro de Recibo");

            }
        }

        //feb 1.8 fix
        private void cbxNroTalonario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                try
                {
                    cargarGridTalonario();
                }
                catch (Exception ex)
                {
                    string inner = "";
                    if (ex.InnerException != null)
                        inner = ex.InnerException.Message;
                    MessageBox.Show(ex.Message + ' ' + inner, "Validación Talonaro de Recibo");

                }
            }
        }

        private void cargarGridTalonario()
        {
            _talonario_detalle.refreshGridData(cbxNroTalonario.Text, txtNumeroDeRecibo.Text);
            this.dgvTalonario.DataSource = _talonario_detalle.GridDataList;
            this.dgvTalonario.Font = txtNumeroFinal.Font;
            dgvTalonario.ClearSelection();

        }

        private void btnAnular_Click(object sender, EventArgs e)
        {

            try
            {
                bool tildoAlMenosUno = false;
                DialogResult dialogResult = MessageBox.Show("¿Desea anular los recibos seleccionados? Solo se anularán los recibos con estado DISPONIBLE.", "Talonario de Recibo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int cantidad = dgvTalonario.Rows.Count;

                    for (int i = 0; i < cantidad; i++)
                    {
                        DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgvTalonario.Rows[i].Cells[0];
                        if (chk.Value.ToString() == "1")
                        {

                            if (((TalonarioDetalleDTO)dgvTalonario.Rows[i].DataBoundItem).Estado == "DISPONIBLE")
                            {
                                tildoAlMenosUno = true;
                                TalonarioDetalleDTO.actualizarEstado(((TalonarioDetalleDTO)dgvTalonario.Rows[i].DataBoundItem).Numero_comprobante, "ANULADO");
                            }

                        }
                    }

                    cargarGridTalonario();

                    if (tildoAlMenosUno)
                    {
                        MessageBox.Show("La operación fue realizada con éxito.", "Talonario de Recibo");
                    }
                    else
                    {
                        MessageBox.Show("No ha seleccionado ningún recibo en estado DISPONIBLE.", "Talonario de Recibo");
                    }


                }

            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Validación Talonaro de Recibo");
            }


        }

        private void btnCrearTalonario_Click(object sender, EventArgs e)
        {
            try
            {

                DialogResult dialogResult = MessageBox.Show("¿Desea crear el talonario?", "Talonario de Recibo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    TalonarioDTO data = this.formToObject();
                    _talonario.insert(data);

                    this.cargarFiltroTalonario();
                    this.txtNuevoNroDeTalonario.Text = string.Empty;
                    this.txtNuevoNroDeTalonario.Focus();
                    MessageBox.Show("La operación fue realizada con éxito.", "Talonario de Recibo");
                }

            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Validación Talonaro de Recibo");
            }
        }

        private TalonarioDTO formToObject()
        {
            TalonarioDTO rv = new TalonarioDTO();

            if (txtNuevoNroDeTalonario.Text != string.Empty)
            {
                rv.Id = long.Parse(txtNuevoNroDeTalonario.Text);
            }

            return rv;
        }

        private TalonarioDTO formToObject2()
        {
            TalonarioDTO rv = new TalonarioDTO();

            if (cbxNroDeTalonario.Text != string.Empty)
            {
                rv.Id = long.Parse(cbxNroDeTalonario.Text);
            }

            return rv;
        }

        private void btnCrearRecibos_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("¿Desea crear los recibos en el rango indicado?", "Talonario de Recibo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    activarBloqueo();
                    TalonarioDTO data = this.formToObject2();
                    _talonario_detalle.insert(data, txtNumeroInicial.Text, txtNumeroFinal.Text);
                    desactivarBloqueo();

                    txtNumeroInicial.Text = string.Empty;
                    txtNumeroFinal.Text = string.Empty;
                    cbxNroDeTalonario.Text = string.Empty;
                    this.txtNumeroInicial.Focus();

                    MessageBox.Show("La operación fue realizada con éxito.", "Talonario de Recibo");
                }


            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                lblGenerandoNumeracion.Visible = false;
                MessageBox.Show(ex.Message + ' ' + inner, "Validación Talonaro de Recibo");
                desactivarBloqueo();
            }
        }

        public void activarBloqueo()
        {
            lblGenerandoNumeracion.Visible = true;
            lblGenerandoNumeracion.Update(); //loco pero hay que ponerlo sino no pone visible el label
            Cursor.Current = Cursors.WaitCursor;
            this.Enabled = false;
        }

        public void desactivarBloqueo()
        {
            lblGenerandoNumeracion.Visible = false;
            Cursor.Current = Cursors.Default;
            this.Enabled = true;
        }

        private void cbxNroTalonario_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Se aceptan teclas de control
            if (Char.IsControl(e.KeyChar))
                e.Handled = false;
            else
            {
                // Se acepta la tecla, si el texto resultante es un número decimal
                long aux;
                bool rv = long.TryParse(this.cbxNroTalonario.Text + e.KeyChar, out aux);
                e.Handled = (!rv);
            }
        }

        private void txtNuevoNroDeTalonario_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Se aceptan teclas de control
            if (Char.IsControl(e.KeyChar))
                e.Handled = false;
            else
            {
                // Se acepta la tecla, si el texto resultante es un número decimal
                long aux;
                bool rv = long.TryParse(this.txtNuevoNroDeTalonario.Text + e.KeyChar, out aux);
                e.Handled = (!rv);
            }
        }

        private void txtNumeroInicial_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Se aceptan teclas de control
            if (Char.IsControl(e.KeyChar))
                e.Handled = false;
            else
            {
                // Se acepta la tecla, si el texto resultante es un número decimal
                long aux;
                bool rv = long.TryParse(this.txtNumeroInicial.Text + e.KeyChar, out aux);
                e.Handled = (!rv);
            }
        }

        private void txtNumeroFinal_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Se aceptan teclas de control
            if (Char.IsControl(e.KeyChar))
                e.Handled = false;
            else
            {
                // Se acepta la tecla, si el texto resultante es un número decimal
                long aux;
                bool rv = long.TryParse(this.txtNumeroFinal.Text + e.KeyChar, out aux);
                e.Handled = (!rv);
            }
        }

        private void cbxNroDeTalonario_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Se aceptan teclas de control
            if (Char.IsControl(e.KeyChar))
                e.Handled = false;
            else
            {
                // Se acepta la tecla, si el texto resultante es un número decimal
                long aux;
                bool rv = long.TryParse(this.cbxNroDeTalonario.Text + e.KeyChar, out aux);
                e.Handled = (!rv);
            }
        }

        private void btnRecuperarRecibo_Click(object sender, EventArgs e)
        {
            try
            {
                bool tildoAlMenosUno = false;
                DialogResult dialogResult = MessageBox.Show("¿Desea recuperar los recibos seleccionados? Solo se recuperarán los recibos con estado INGRESADO. Esta operación borra definitivamente todos los datos del comprobante ingresado.", "Talonario de Recibo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int cantidad = dgvTalonario.Rows.Count;

                    for (int i = 0; i < cantidad; i++)
                    {
                        DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgvTalonario.Rows[i].Cells[0];
                        if (chk.Value.ToString() == "1")
                        {
                            if (((TalonarioDetalleDTO)dgvTalonario.Rows[i].DataBoundItem).Estado == "INGRESADO")
                            {
                                tildoAlMenosUno = true;
                                _recibo.refreshGridDataReg(ComprobanteDTO.obtenerIdOrigenRecibo(((TalonarioDetalleDTO)dgvTalonario.Rows[i].DataBoundItem).Numero_comprobante));
                                _recibo.recalcularMovimientosPost(_recibo.GridDataListReg[0]);
                                _recibo.anular(_recibo.GridDataListReg[0]);

                                TalonarioDetalleDTO.actualizarEstado(((TalonarioDetalleDTO)dgvTalonario.Rows[i].DataBoundItem).Numero_comprobante, "DISPONIBLE");
                            }
                        }
                    }

                    cargarGridTalonario();

                    if (tildoAlMenosUno)
                    {
                        MessageBox.Show("La operación fue realizada con éxito.", "Talonario de Recibo");
                    }
                    else
                    {
                        MessageBox.Show("No ha seleccionado ningún recibo en estado INGRESADO.", "Talonario de Recibo");
                    }


                }

            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Validación Talonaro de Recibo");
            }
        }

    }
}
