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
    public partial class frmDetalleDeOrdenesDeTrabajo : Form
    {
        private FiltrosOrden _filtrosOrden;
        private Clientes _clientes;
        private Orden _orden;
        private OrdenDetalle _ordenDetalle;
        private MedidaCubierta _medidas;
        private Servicio _servicios;
        private Marca _marcas;
        private MotivoDescuento _motivoDescuento;

        public frmDetalleDeOrdenesDeTrabajo()
        {
            InitializeComponent();
            _clientes = new Clientes();
            _orden = new Orden();
            _ordenDetalle = new OrdenDetalle();
            _filtrosOrden = new FiltrosOrden();
            _medidas = new MedidaCubierta();
            _servicios = new Servicio();
            _marcas = new Marca();
            _motivoDescuento = new MotivoDescuento();
        }

        private void lblNombre_Click(object sender, EventArgs e)
        {

        }

        private void frmDetalleDeOrdenesDeTrabajo_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(1376, 762);
            if (Resolucion.Escalar())
            {
                Resolucion _ajusteResolucion = new Resolucion();
                _ajusteResolucion.ResizeForm(this, 1376, 762);
                this.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width - 1, Screen.PrimaryScreen.Bounds.Height - 1);
            }

            cargarFiltroCompleto();
            FilterToObjectOrdenFalse();
            configurarGridDetalleTrabajo();
            cargarFormularioDetalleOrden();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbxFiltroCodCliente.Text == "" && cbxFiltroNombreDeCliente.Text == "" && cbxFiltroNroDeOrden.Text == "")
            {
                FilterToObjectOrdenFalse();
            }
            else
            {
                FilterToObjectOrden();
            }
            cargarGridDetalleTrabajo();
            this.clearForm();
        }

        private void cbxFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cbxFiltroCodCliente.Text == "" && cbxFiltroNombreDeCliente.Text == "" && cbxFiltroNroDeOrden.Text == "")
                {
                    FilterToObjectOrdenFalse();
                }
                else
                {
                    FilterToObjectOrden();
                }
                cargarGridDetalleTrabajo();
                this.clearForm();
            }
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

            this.cbxMotivoDescuento.DataSource = _motivoDescuento.OwnDataList;
            this.cbxMotivoDescuento.DisplayMember = "valor";
            this.cbxMotivoDescuento.ValueMember = "id";

            this.txtPorcentajeAPagar.Text = getPorcentajeAPagar();
            this.txtNroInterno.Text = "0";

        }

        private string getPorcentajeAPagar()
        {
            return "100";
        }

        private void clearForm()
        {
            this.objectToForm(new OrdenDetalleDTO());
        }


        private void FilterToObjectOrden()
        {
            _filtrosOrden.FiltroCodCliente = this.cbxFiltroCodCliente.Text;
            _filtrosOrden.FiltroNombreCliente = this.cbxFiltroNombreDeCliente.Text;
            _filtrosOrden.FiltroNroOrden = this.cbxFiltroNroDeOrden.Text;
        }

        private void FilterToObjectOrdenFalse()
        {
            _filtrosOrden.FiltroCodCliente = "XXXXXXXX";
            _filtrosOrden.FiltroNombreCliente = "XXXXXXXXXXXXXXX";
            _filtrosOrden.FiltroNroOrden = "99999999";
        }


        private void cargarFiltroCompleto()
        {
            //this.cbxCodCliente.DataSource = null;
            this.cbxFiltroCodCliente.DataSource = _clientes.CodDataList; //evaluar de que forma ingresen si o si los datos

            //this.cbxNombreDelCliente.DataSource = null;
            this.cbxFiltroNombreDeCliente.DataSource = _clientes.NombreDataList;

            _orden.refreshOwnData();
            this.cbxFiltroNroDeOrden.DataSource = _orden.OwnDataList;
        }

        private void cargarFiltroOrden()
        {
            _orden.refreshOwnData();
            this.cbxFiltroNroDeOrden.DataSource = null;
            this.cbxFiltroNroDeOrden.DataSource = _orden.OwnDataList;
        }

        private void configurarGridDetalleTrabajo()
        {
            this.dgvOrdenesDeTrabajo.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn _nroDeOrdenColum = new DataGridViewTextBoxColumn();
            _nroDeOrdenColum.DataPropertyName = "id_orden_de_trabajo";
            _nroDeOrdenColum.HeaderText = "Orden";
            _nroDeOrdenColum.Width = 55;
            _nroDeOrdenColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _nroDeOrdenColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _nroDeOrdenColum.ReadOnly = true;

            DataGridViewTextBoxColumn _nroRenglonColum = new DataGridViewTextBoxColumn();
            _nroRenglonColum.DataPropertyName = "renglon";
            _nroRenglonColum.HeaderText = "R.";
            _nroRenglonColum.Width = 20;
            _nroRenglonColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _nroRenglonColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _nroRenglonColum.ReadOnly = true;

            DataGridViewTextBoxColumn _coche = new DataGridViewTextBoxColumn();
            _coche.DataPropertyName = "coche";
            _coche.HeaderText = "Coche";
            _coche.Width = 90;
            _coche.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _coche.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _coche.ReadOnly = true;

            DataGridViewTextBoxColumn _medidaCubiertaColum = new DataGridViewTextBoxColumn();
            _medidaCubiertaColum.DataPropertyName = "medida_cubierta";
            _medidaCubiertaColum.HeaderText = "Cubierta";
            _medidaCubiertaColum.Width = 104;
            _medidaCubiertaColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _medidaCubiertaColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _medidaCubiertaColum.ReadOnly = true;

            DataGridViewTextBoxColumn _marcaColum = new DataGridViewTextBoxColumn();
            _marcaColum.DataPropertyName = "marca";
            _marcaColum.HeaderText = "Marca";
            _marcaColum.Width = 55;
            _marcaColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _marcaColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _marcaColum.ReadOnly = true;

            DataGridViewTextBoxColumn _NroSerieColum = new DataGridViewTextBoxColumn();
            _NroSerieColum.DataPropertyName = "serie";
            _NroSerieColum.HeaderText = "Serie";
            _NroSerieColum.Width = 65;
            _NroSerieColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _NroSerieColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _NroSerieColum.ReadOnly = true;

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
            _trabajoColum.Width = 87;
            _trabajoColum.ReadOnly = true;

            DataGridViewTextBoxColumn _servicioAdicionalColum = new DataGridViewTextBoxColumn();
            _servicioAdicionalColum.DataPropertyName = "servicio_adicional";
            _servicioAdicionalColum.HeaderText = "Adicional";
            _servicioAdicionalColum.Width = 65;
            _servicioAdicionalColum.ReadOnly = true;

            this.dgvOrdenesDeTrabajo.Columns.Add(_nroDeOrdenColum);
            this.dgvOrdenesDeTrabajo.Columns.Add(_nroRenglonColum);
            this.dgvOrdenesDeTrabajo.Columns.Add(_coche);
            this.dgvOrdenesDeTrabajo.Columns.Add(_medidaCubiertaColum);
            this.dgvOrdenesDeTrabajo.Columns.Add(_marcaColum);
            this.dgvOrdenesDeTrabajo.Columns.Add(_NroSerieColum);
            this.dgvOrdenesDeTrabajo.Columns.Add(_internoColum);
            this.dgvOrdenesDeTrabajo.Columns.Add(_trabajoColum);
            this.dgvOrdenesDeTrabajo.Columns.Add(_servicioAdicionalColum);

        }

        private void objectToForm(OrdenDetalleDTO data)
        {


            this.txtRenglon.Text = data.Renglon.ToString();

            if (data.Id_orden_de_trabajo == -1)
            {
                this.txtNroOrden.Text = "";
                this.txtRenglon.Text = "";
            }
            else
            {
                this.txtNroOrden.Text = data.Id_orden_de_trabajo.ToString();
            }

            if (data.Porcentaje_a_pagar == -1)
            {
                this.txtPorcentajeAPagar.Text = getPorcentajeAPagar();
            }
            else
            {
                this.txtPorcentajeAPagar.Text = data.Porcentaje_a_pagar.ToString();
            }

            this.txtNroSerie.Text = data.Serie;

            if (data.Interno == -1)
            {
                this.txtNroInterno.Text = "0";
            }
            else
            {
                this.txtNroInterno.Text = data.Interno.ToString();
            }

            this.txtCoche.Text = data.Coche;

            if (data.Id_marca == -1 && this.cbxMarca.Items.Count != 0)
            {
                this.cbxMarca.SelectedIndex = 0;
            }
            else
            {
                this.cbxMarca.SelectedValue = data.Id_marca;
            }

            this.cbxMedidaDeCubierta.Text = data.Medida_cubierta;

            if (data.Id_servicio == -1 && this.cbxTrabajo.Items.Count != 0)
            {
                this.cbxTrabajo.SelectedIndex = 0;
            }
            else
            {
                this.cbxTrabajo.SelectedValue = data.Id_servicio;
            }

            if (data.Id_servicio_adicional == -1 && this.cbxServicioAdicional.Items.Count != 0)
            {
                this.cbxServicioAdicional.SelectedIndex = 0;
            }
            else
            {
                this.cbxServicioAdicional.SelectedValue = data.Id_servicio_adicional;
            }

            this.txtCodCliente.Text = data.Id_cliente;
            this.txtNombreDelCliente.Text = data.Nombre_cliente;
            this.dtpFechaDeEntrada.Value = data.Fecha;
            this.cbxMotivoDescuento.Text = data.Motivo_descuento;

        }

        private void cargarGridDetalleTrabajo()
        {
            _ordenDetalle.refreshGridDataRegistrado2(_filtrosOrden);
            this.dgvOrdenesDeTrabajo.DataSource = _ordenDetalle.GridDataList;
            this.dgvOrdenesDeTrabajo.Font = txtCoche.Font;
            dgvOrdenesDeTrabajo.ClearSelection();
        }

        private OrdenDetalleDTO formToObject()
        {
            OrdenDetalleDTO rv = new OrdenDetalleDTO();

            rv.Id_orden_de_trabajo = long.Parse(this.txtNroOrden.Text);
            rv.Renglon = int.Parse(this.txtRenglon.Text);
            rv.Porcentaje_a_pagar = decimal.Parse(this.txtPorcentajeAPagar.Text);
            rv.Serie = this.txtNroSerie.Text;
            rv.Interno = long.Parse(this.txtNroInterno.Text);
            rv.Coche = this.txtCoche.Text;
            rv.Id_marca = long.Parse(this.cbxMarca.SelectedValue.ToString());
            rv.Medida_cubierta = this.cbxMedidaDeCubierta.Text;
            rv.Id_producto = long.Parse(this.cbxMedidaDeCubierta.SelectedValue.ToString());
            rv.Id_servicio = long.Parse(this.cbxTrabajo.SelectedValue.ToString());

            if (this.cbxServicioAdicional.SelectedValue != null)
            {
                rv.Id_servicio_adicional = long.Parse(this.cbxServicioAdicional.SelectedValue.ToString());
            }
            else
            {
                rv.Id_servicio_adicional = -1;
            }

            rv.Motivo_descuento = this.cbxMotivoDescuento.Text;

            return rv;
        }

        private bool validarNulidadDatosForm(ref string msg)
        {
            bool rv = true;

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

        private void dgvOrdenesDeTrabajo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvOrdenesDeTrabajo.SelectedRows.Count > 0)
            {
                this.objectToForm((OrdenDetalleDTO)this.dgvOrdenesDeTrabajo.SelectedRows[0].DataBoundItem);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {

            clearFormParcial();
        }

        private void clearFormParcial()
        {
            OrdenDetalleDTO actual = new OrdenDetalleDTO();

            actual.Id_cliente = txtCodCliente.Text;
            actual.Nombre_cliente = txtNombreDelCliente.Text;
            if (txtNroOrden.Text != "")
            {
                actual.Id_orden_de_trabajo = long.Parse(txtNroOrden.Text);
                actual.Fecha = dtpFechaDeEntrada.Value;
                actual.Renglon = OrdenDetalleDTO.buscarSiguienteRenglon(actual.Id_orden_de_trabajo);
                actual.Porcentaje_a_pagar = 100;
            }
            

            this.objectToForm(actual);
        }

        private void btnLimpiarGrilla_Click(object sender, EventArgs e)
        {
            clearFilter();
            FilterToObjectOrdenFalse();
            cargarGridDetalleTrabajo();
            this.clearForm();
            this.cbxFiltroCodCliente.Focus();
        }

        private void clearFilter()
        {
            this.objectToFilterOrden(new FiltrosOrden());
        }

        private void objectToFilterOrden(FiltrosOrden filtro)
        {
            this.cbxFiltroCodCliente.Text = filtro.FiltroCodCliente;
            this.cbxFiltroNombreDeCliente.Text = filtro.FiltroNombreCliente;
            this.cbxFiltroNroDeOrden.Text = filtro.FiltroNroOrden;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (this.dgvOrdenesDeTrabajo.SelectedRows.Count > 0)
            {

                DialogResult dialogResult = MessageBox.Show("¿Desea borrar el renglon seleccionado?", "Órdenes de Trabajo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    this._ordenDetalle.delete(((OrdenDetalleDTO)this.dgvOrdenesDeTrabajo.SelectedRows[0].DataBoundItem).Id_orden_de_trabajo, ((OrdenDetalleDTO)this.dgvOrdenesDeTrabajo.SelectedRows[0].DataBoundItem).Renglon);
                    cargarFiltroOrden();
                    cargarGridDetalleTrabajo(); //cargo grilla
                    clearForm();
                }

            }
            else
            {
                MessageBox.Show("No hay un renglón seleccionado.", "Órdenes de Trabajo");
            }
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

        private void cbxFiltroNroDeOrden_KeyPress(object sender, KeyPressEventArgs e)
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
                    bool rv = Decimal.TryParse(this.cbxFiltroNroDeOrden.Text + e.KeyChar, out aux);
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = "";

                if (validarNulidadDatosForm(ref msg))
                {
                    OrdenDetalleDTO data = this.formToObject();
                    OrdenDTO dataAux = new OrdenDTO();

                    if (data.Renglon == OrdenDetalleDTO.buscarSiguienteRenglon(long.Parse(txtNroOrden.Text)))
                    {
                        DialogResult dialogResult = MessageBox.Show("¿Desea crear el nuevo renglón de la orden?", "Ordenes de Trabajo", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            if (OrdenDetalle.isValid(dataAux, data, ref msg))
                            {
                                this._ordenDetalle.insert(data);
                                cargarGridDetalleTrabajo();
                                this.clearForm();
                                MessageBox.Show("La operación fue realizada con éxito.", "Órdenes de Trabajo");
                            }
                            else
                            {
                                MessageBox.Show("No ha sido posible guardar la orden de trabajo. Corrija los siguientes errores y vuelva a intentarlo: \n" + msg, "Órdenes de Trabajo");
                            }
                        }

                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("¿Desea actualizar el renglón de la orden?", "Órdenes de Trabajo", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            if (OrdenDetalle.isValid(dataAux, data, ref msg))
                            {
                                this._ordenDetalle.update(data);
                                cargarGridDetalleTrabajo();
                                this.clearForm();
                                MessageBox.Show("La operación fue realizada con éxito.", "Ordenes de Trabajo");
                            }
                            else
                            {
                                MessageBox.Show("No ha sido posible guardar la orden de trabajo. Corrija los siguientes errores y vuelva a intentarlo: \n" + msg, "Órdenes de Trabajo");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No ha sido posible guardar la orden de trabajo. Corrija los siguientes errores y vuelva a intentarlo: \n" + msg, "Ordenes de Trabajo");
                }


            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Validación Guardar Orden");
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

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxFiltroCodCliente.Text == "" && cbxFiltroNombreDeCliente.Text == "" && cbxFiltroNroDeOrden.Text == "")
                {
                    DialogResult dialogResult = MessageBox.Show("¿Desea visualizar el stock completo de la planta?", "Órdenes de Trabajo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        frmVerStock frmReporte = new frmVerStock();
                        crStock rptLista = frmReporte.cargarReporte();
                        frmReporte.crvStock.ReportSource = rptLista;
                        frmReporte.ShowDialog();
                        rptLista.Dispose();
                        frmReporte.Dispose();
                    }
                }
                else
                {
                    FilterToObjectOrden();
                    frmVerStock frmReporte = new frmVerStock();
                    frmReporte.crvStock.ReportSource = frmReporte.cargarReporte(_filtrosOrden);
                    frmReporte.ShowDialog();
                    frmReporte.Dispose();
                }

            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Reporte Stock en Planta");
            }
        }

        private void cbxFiltroCodCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbxFiltroNombreDeCliente.Text = _clientes.obtenerNombre(this.cbxFiltroCodCliente.Text);
        }

        private void cbxFiltroNombreDeCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbxFiltroCodCliente.Text = _clientes.obtenerCodigo(this.cbxFiltroNombreDeCliente.Text);
        }

    }
}
