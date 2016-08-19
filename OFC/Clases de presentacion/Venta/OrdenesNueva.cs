using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OFC
{
    public partial class frmNuevaOrdenDeTrabajo : Form
    {

        private Clientes _clientes;
        private MedidaCubierta _medidas;
        private Servicio _servicios;
        private Marca _marcas;
        private Orden _orden;
        private OrdenDetalle _ordenDetalle;
        private MotivoDescuento _motivoDescuento;

        public frmNuevaOrdenDeTrabajo()
        {
            InitializeComponent();
            _clientes = new Clientes();
            _medidas = new MedidaCubierta();
            _marcas = new Marca();
            _servicios = new Servicio();
            _orden = new Orden();
            _ordenDetalle = new OrdenDetalle();
            _motivoDescuento = new MotivoDescuento();
        }

        private void frmNuevaOrdenDeTrabajo_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(1376, 762);
            if (Resolucion.Escalar())
            {
                Resolucion _ajusteResolucion = new Resolucion();
                _ajusteResolucion.ResizeForm(this, 1376, 762);
                this.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width - 1, Screen.PrimaryScreen.Bounds.Height - 1);
            }

            cargarFormularioOrden();
            cargarFormularioDetalleOrden();
            configurarGridDetalleTrabajo();
            cargarGridDetalleTrabajo();
        }

        private void cargarGridDetalleTrabajo()
        {
            _ordenDetalle.refreshGridDataPendiente();
            this.dgvDetalleDeOrdenesDeTrabajo.DataSource = _ordenDetalle.GridDataList;
            this.dgvDetalleDeOrdenesDeTrabajo.Font = txtCoche.Font;
            this.dgvDetalleDeOrdenesDeTrabajo.ClearSelection();
        }


        private void configurarGridDetalleTrabajo()
        {
            this.dgvDetalleDeOrdenesDeTrabajo.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn _nroDeOrdenColum = new DataGridViewTextBoxColumn();
            _nroDeOrdenColum.DataPropertyName = "id_orden_de_trabajo";
            _nroDeOrdenColum.HeaderText = "Orden";
            _nroDeOrdenColum.Width = 55;
            _nroDeOrdenColum.HeaderCell.Style.Font = this.txtCoche.Font;

            DataGridViewTextBoxColumn _nroRenglonColum = new DataGridViewTextBoxColumn();
            _nroRenglonColum.DataPropertyName = "renglon";
            _nroRenglonColum.HeaderText = "R.";
            _nroRenglonColum.Width = 20;
            _nroRenglonColum.HeaderCell.Style.Font = this.txtCoche.Font;

            DataGridViewTextBoxColumn _cocheColum = new DataGridViewTextBoxColumn();
            _cocheColum.DataPropertyName = "coche";
            _cocheColum.HeaderText = "Coche";
            _cocheColum.Width = 100;
            _cocheColum.HeaderCell.Style.Font = this.txtCoche.Font;

            DataGridViewTextBoxColumn _medidaCubiertaColum = new DataGridViewTextBoxColumn();
            _medidaCubiertaColum.DataPropertyName = "medida_cubierta";
            _medidaCubiertaColum.HeaderText = "Cubierta";
            _medidaCubiertaColum.Width = 117;
            _medidaCubiertaColum.HeaderCell.Style.Font = this.txtCoche.Font;

            DataGridViewTextBoxColumn _marcaColum = new DataGridViewTextBoxColumn();
            _marcaColum.DataPropertyName = "marca";
            _marcaColum.HeaderText = "Marca";
            _marcaColum.Width = 60;
            _marcaColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _marcaColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _marcaColum.ReadOnly = true;

            DataGridViewTextBoxColumn _NroSerieColum = new DataGridViewTextBoxColumn();
            _NroSerieColum.DataPropertyName = "serie";
            _NroSerieColum.HeaderText = "Serie";
            _NroSerieColum.Width = 65;
            _NroSerieColum.HeaderCell.Style.Font = this.txtCoche.Font;

            DataGridViewTextBoxColumn _internoColum = new DataGridViewTextBoxColumn();
            _internoColum.DataPropertyName = "interno";
            _internoColum.HeaderText = "Interno";
            _internoColum.Width = 57;
            _internoColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _internoColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _internoColum.ReadOnly = true;

            DataGridViewTextBoxColumn _trabajoColum = new DataGridViewTextBoxColumn();
            _trabajoColum.DataPropertyName = "trabajo";
            _trabajoColum.HeaderText = "Trabajo";
            _trabajoColum.Width = 140;
            _trabajoColum.HeaderCell.Style.Font = this.txtCoche.Font;

            DataGridViewTextBoxColumn _adicionalColum = new DataGridViewTextBoxColumn();
            _adicionalColum.DataPropertyName = "servicio_adicional";
            _adicionalColum.HeaderText = "Adicional";
            _adicionalColum.Width = 140;
            _adicionalColum.HeaderCell.Style.Font = this.txtCoche.Font;

            this.dgvDetalleDeOrdenesDeTrabajo.Columns.Add(_nroDeOrdenColum);
            this.dgvDetalleDeOrdenesDeTrabajo.Columns.Add(_nroRenglonColum);
            this.dgvDetalleDeOrdenesDeTrabajo.Columns.Add(_cocheColum);
            this.dgvDetalleDeOrdenesDeTrabajo.Columns.Add(_medidaCubiertaColum);
            this.dgvDetalleDeOrdenesDeTrabajo.Columns.Add(_marcaColum);
            this.dgvDetalleDeOrdenesDeTrabajo.Columns.Add(_NroSerieColum);
            this.dgvDetalleDeOrdenesDeTrabajo.Columns.Add(_internoColum);
            this.dgvDetalleDeOrdenesDeTrabajo.Columns.Add(_trabajoColum);
            this.dgvDetalleDeOrdenesDeTrabajo.Columns.Add(_adicionalColum);
        }


        private void cargarFormularioOrden()
        {
            //this.cbxCodCliente.DataSource = null;
            this.cbxCodCliente.DataSource = _clientes.CodDataList; //evaluar de que forma ingresen si o si los datos

            //this.cbxNombreDelCliente.DataSource = null;
            this.cbxNombreDelCliente.DataSource = _clientes.NombreDataList;
        }

        private void cargarFormularioDetalleOrden()
        {
            //
            this.cbxMedidaDeCubierta.DataSource = _medidas.OwnDataList;
            this.cbxMedidaDeCubierta.DisplayMember = "medida_cubierta";
            this.cbxMedidaDeCubierta.ValueMember = "id";

            this.cbxMarca.DataSource = _marcas.OwnDataList;
            this.cbxMarca.DisplayMember = "valor";
            this.cbxMarca.ValueMember = "id";

            this.cbxTrabajo.DataSource = _servicios.OwnServList;
            this.cbxTrabajo.DisplayMember = "descripcion";
            this.cbxTrabajo.ValueMember = "id";

            this.cbxServicioAdicional.DataSource = _servicios.OwnServAdicionalList;
            this.cbxServicioAdicional.DisplayMember = "descripcion";
            this.cbxServicioAdicional.ValueMember = "id";

            this.txtPorcentajeAPagar.Text = getPorcentajeAPagar();
            this.txtNroInterno.Text = "0";

            this.cbxMotivoDescuento.DataSource = _motivoDescuento.OwnDataList;
            this.cbxMotivoDescuento.DisplayMember = "valor";
            this.cbxMotivoDescuento.ValueMember = "id";

        }

        private void txtNroInterno_KeyPress(object sender, KeyPressEventArgs e)
        {
            // No se acepta el punto ya que el separador de decimales es la ','
            if (e.KeyChar == '.')
                e.Handled = true;
            else
            {
                // Se aceptan teclas de control
                if (Char.IsControl(e.KeyChar))
                    e.Handled = false;
                else
                {
                    // Se acepta la tecla, si el texto resultante es un número decimal
                    Decimal aux = new Decimal();
                    bool rv = Decimal.TryParse(this.txtNroInterno.Text + e.KeyChar, out aux);
                    e.Handled = (!rv);
                }
            }
        }

        private void txtPorcentajeAPagar_KeyPress(object sender, KeyPressEventArgs e)
        {
            // No se acepta el punto ya que el separador de decimales es la ','
            if (e.KeyChar == '.')
                e.Handled = true;
            else
            {
                // Se aceptan teclas de control
                if (Char.IsControl(e.KeyChar))
                    e.Handled = false;
                else
                {
                    // Se acepta la tecla, si el texto resultante es un número decimal
                    Decimal aux = new Decimal();
                    bool rv = Decimal.TryParse(this.txtPorcentajeAPagar.Text + e.KeyChar, out aux);
                    e.Handled = (!rv);
                }
            }
        }

        private void txtNroOrden_KeyPress(object sender, KeyPressEventArgs e)
        {
            // No se acepta el punto ya que el separador de decimales es la ','
            if (e.KeyChar == '.')
                e.Handled = true;
            else
            {
                // Se aceptan teclas de control
                if (Char.IsControl(e.KeyChar))
                    e.Handled = false;
                else
                {
                    // Se acepta la tecla, si el texto resultante es un número decimal
                    Decimal aux = new Decimal();
                    bool rv = Decimal.TryParse(this.txtNroOrden.Text + e.KeyChar, out aux);
                    e.Handled = (!rv);
                }
            }
        }

        private void cbxCodCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbxNombreDelCliente.Text = _clientes.obtenerNombre(this.cbxCodCliente.Text);
        }

        private void cbxNombreDelCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbxCodCliente.Text = _clientes.obtenerCodigo(this.cbxNombreDelCliente.Text);
        }

        private OrdenDTO formToObjectOrden()
        {
            OrdenDTO ord = new OrdenDTO();
            //set objeto
            ord.Id = long.Parse(this.txtNroOrden.Text.ToString());
            ord.Id_cliente = this.cbxCodCliente.Text;
            ord.Nombre_cliente = this.cbxNombreDelCliente.Text;
            ord.Fecha = this.dtpFechaDeEntrada.Value;

            return ord;
        }

        private OrdenDetalleDTO formToObjectOrdenDetalle()
        {
            OrdenDetalleDTO ord = new OrdenDetalleDTO();
            //set objeto
            ord.Serie = this.txtNroSerie.Text.ToString();
            ord.Interno = long.Parse(this.txtNroInterno.Text.ToString());

            Decimal aux = new Decimal();
            if (Decimal.TryParse(this.txtPorcentajeAPagar.Text, out aux))
                ord.Porcentaje_a_pagar = aux;
            else
                ord.Porcentaje_a_pagar = 100;

            ord.Id_servicio = long.Parse(this.cbxTrabajo.SelectedValue.ToString());

            if (this.cbxServicioAdicional.SelectedValue.ToString() == "")
            {
                ord.Id_servicio_adicional = -1;
            }
            else
            {
                ord.Id_servicio_adicional = long.Parse(this.cbxServicioAdicional.SelectedValue.ToString());
            }

            ord.Id_marca = long.Parse(this.cbxMarca.SelectedValue.ToString());
            ord.Id_producto = long.Parse(this.cbxMedidaDeCubierta.SelectedValue.ToString());
            ord.Id_orden_de_trabajo = long.Parse(this.txtNroOrden.Text.ToString());
            ord.Coche = this.txtCoche.Text;
            ord.Motivo_descuento = this.cbxMotivoDescuento.Text;

            return ord;
        }

        private bool validarNulidadDatosForm(ref string msg)
        {
            bool rv = true;

            if (this.cbxCodCliente.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar el Código de cliente.";
            }
            else
            {
                int resultIndex = this.cbxCodCliente.FindStringExact(cbxCodCliente.Text);
                if (resultIndex == -1)
                {
                    rv = false;
                    msg += "\nEl código de cliente ingresado es incorrecto. Seleccione uno de la lista.";
                }
            }

            if (this.txtNroOrden.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar el Número de orden.";
            }

            //if (this.txtCoche.Text == "")
            //{
            //    rv = false;
            //    msg += "\nDebe ingresar el Coche.";
            //}

            if (this.txtNroSerie.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar el Número de serie.";
            }

            if (this.txtNroInterno.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar el Número de interno.";
            }

            if (this.txtPorcentajeAPagar.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar el Porcentaje a pagar.";
            }

            if (int.Parse(this.txtPorcentajeAPagar.Text) < 0)
            {
                rv = false;
                msg += "\nEl porcentaje a pagar no puede ser negativo.";
            }

            if (int.Parse(this.txtPorcentajeAPagar.Text) < 100 && this.cbxMotivoDescuento.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar el Motivo de descuento.";
            }

            if (int.Parse(this.txtPorcentajeAPagar.Text) >= 100 && this.cbxMotivoDescuento.Text != "")
            {
                rv = false;
                msg += "\nNo debe ingresar un Motivo de descuento.";
            }

            if (this.cbxTrabajo.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar el Trabajo a realizar.";
            }
            else
            {
                int resultIndex = this.cbxTrabajo.FindStringExact(cbxTrabajo.Text);
                if (resultIndex == -1)
                {
                    rv = false;
                    msg += "\nEl trabajo ingresado es incorrecto. Seleccione uno de la lista.";
                }
            }

            if (this.cbxServicioAdicional.Text != "")
            {
                int resultIndex = this.cbxServicioAdicional.FindStringExact(cbxServicioAdicional.Text);
                if (resultIndex == -1)
                {
                    rv = false;
                    msg += "\nEl servicio adicional ingresado es incorrecto. Seleccione uno de la lista.";
                }
            }

            if (this.cbxMarca.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar la Marca.";
            }
            else
            {
                int resultIndex = this.cbxMarca.FindStringExact(cbxMarca.Text);
                if (resultIndex == -1)
                {
                    rv = false;
                    msg += "\nLa marca ingresada es incorrecta. Seleccione una de la lista.";
                }
            }

            if (this.cbxMedidaDeCubierta.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar la Medida de cubierta.";
            }
            else
            {
                int resultIndex = this.cbxMedidaDeCubierta.FindStringExact(cbxMedidaDeCubierta.Text);
                if (resultIndex == -1)
                {
                    rv = false;
                    msg += "\nLa medida de cubierta ingresada es incorrecta. Seleccione una de la lista.";
                }
            }

            if (this.cbxMotivoDescuento.Text != "")
            {
                int resultIndex = this.cbxMotivoDescuento.FindStringExact(cbxMotivoDescuento.Text);
                if (resultIndex == -1)
                {
                    rv = false;
                    msg += "\nEl motivo de descuento ingresado es incorrecto. Seleccione uno de la lista.";
                }
            }

            return rv;

        }

        private bool validarTemporalidad(ref string msg)
        {
            bool rv = true;

            if ((OrdenDTO.existeNroOrden(long.Parse(txtNroOrden.Text)) && !OrdenDTO.isTemp(long.Parse(txtNroOrden.Text))) || OrdenDTO.existeNroOrdenHist(long.Parse(txtNroOrden.Text)))
            {
                rv = false;
                msg += "\nLa orden de trabajo ya existe. Si desea modificar la misma (siendo que no está facturada) diríjase al botón Búsqueda presente en la pantalla de Inicio";
            }

            return rv;
        }



        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = "";

                if (validarNulidadDatosForm(ref msg) && validarTemporalidad(ref msg))
                {
                    OrdenDTO dataOrden = this.formToObjectOrden();
                    OrdenDetalleDTO dataOrdenDetalle = this.formToObjectOrdenDetalle();

                    if (OrdenDetalle.isValid(dataOrden, dataOrdenDetalle, ref msg)) //hay precio en lista
                    {
                        //si no existe orden de trabajo, la creo. 
                        if (!OrdenDTO.existeNroOrden(dataOrden.Id))
                        {
                            _orden.insert(dataOrden, true);
                        }

                        //siempre inserto el renglon
                        _ordenDetalle.insert(dataOrdenDetalle);

                        cargarGridDetalleTrabajo();
                        inhabilitarCamposOrden();
                        clearCamposDetalle();
                        this.txtCoche.Focus();
                    }
                    else
                    {
                        MessageBox.Show("No ha sido posible guardar la orden de trabajo. Corrija los siguientes errores y vuelva a intentarlo: \n" + msg, "Orden de Trabajo");
                    }
                }
                else
                {
                    MessageBox.Show("No ha sido posible guardar la orden de trabajo. Corrija los siguientes errores y vuelva a intentarlo: \n" + msg, "Orden de Trabajo");
                }

            }

            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Orden de Trabajo");
            }


        }

        private void btnNuevaOrden_Click(object sender, EventArgs e)
        {
            clearCamposOrden();
            habilitarCamposOrden();
            clearCamposDetalle();
            this.cbxCodCliente.Focus();
        }

        private void inhabilitarCamposOrden()
        {
            this.cbxCodCliente.Enabled = false;
            this.cbxNombreDelCliente.Enabled = false;
            this.txtNroOrden.Enabled = false;
            this.dtpFechaDeEntrada.Enabled = false;
        }

        private void clearCamposDetalle()
        {
            this.txtPorcentajeAPagar.Text = getPorcentajeAPagar();
            this.txtCoche.Text = "";
            this.cbxMedidaDeCubierta.Text = "";
            this.cbxMarca.Text = "";
            this.txtNroSerie.Text = "";
            this.cbxTrabajo.Text = "";
            this.txtNroInterno.Text = "0";
            this.cbxServicioAdicional.Text = "";
            this.cbxMotivoDescuento.Text = "";

        }


        private string getPorcentajeAPagar()
        {
            return "100";
        }


        private void habilitarCamposOrden()
        {
            this.cbxCodCliente.Enabled = true;
            this.cbxNombreDelCliente.Enabled = true;
            this.txtNroOrden.Enabled = true;
            this.dtpFechaDeEntrada.Enabled = true;
        }

        private void clearCamposOrden()
        {
            this.cbxCodCliente.Text = "";
            this.cbxNombreDelCliente.Text = "";
            this.txtNroOrden.Text = "";
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (this.dgvDetalleDeOrdenesDeTrabajo.SelectedRows.Count > 0)
            {

                DialogResult dialogResult = MessageBox.Show("¿Desea borrar el renglon seleccionado?", "Orden de Trabajo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    this._ordenDetalle.delete(((OrdenDetalleDTO)this.dgvDetalleDeOrdenesDeTrabajo.SelectedRows[0].DataBoundItem).Id_orden_de_trabajo, ((OrdenDetalleDTO)this.dgvDetalleDeOrdenesDeTrabajo.SelectedRows[0].DataBoundItem).Renglon);
                    cargarGridDetalleTrabajo(); //cargo grilla
                }

            }
            else
            {
                MessageBox.Show("No hay un renglón seleccionado.", "Orden de Trabajo");
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (this.dgvDetalleDeOrdenesDeTrabajo.Rows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("¿Desea registrar los trabajos ingresados?", "Orden de Trabajo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    this._orden.registrar();
                    cargarGridDetalleTrabajo(); //cargo grilla

                    clearCamposOrden();
                    habilitarCamposOrden();
                    clearCamposDetalle();
                    this.cbxCodCliente.Focus();

                    MessageBox.Show("La operación fue realizada con éxito.", "Orden de Trabajo");
                }
            }
            else
            {
                MessageBox.Show("No hay órdenes de trabajo pendientes.", "Orden de Trabajo");
            }
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            if (int.Parse(txtPorcentajeAPagar.Text) < 100 && int.Parse(txtPorcentajeAPagar.Text) > 0)
            {
                cbxMotivoDescuento.Text = "BONIFICACION";
            }
            if (int.Parse(txtPorcentajeAPagar.Text) == 0)
            {
                cbxMotivoDescuento.Text = "SIN CARGO";
            }
            if (int.Parse(txtPorcentajeAPagar.Text) >= 100)
            {
                cbxMotivoDescuento.Text = "";
            }
        }

    }
}
