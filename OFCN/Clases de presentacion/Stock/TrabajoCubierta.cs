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
    public partial class frmTrabajoCubierta : Form
    {
        private Servicio _servicio;
        private MedidaCubierta _medidas;
        private FiltrosOrden _filtrosOrden;
        private OrdenDetalle _ordenDetalle;

        public frmTrabajoCubierta()
        {
            InitializeComponent();
            _servicio = new Servicio();
            _medidas = new MedidaCubierta();
            _ordenDetalle = new OrdenDetalle();
            _filtrosOrden = new FiltrosOrden();
        }

        private void frmTrabajoCubierta_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(1376, 762);
            if (Resolucion.Escalar())
            {
                Resolucion _ajusteResolucion = new Resolucion();
                _ajusteResolucion.ResizeForm(this, 1376, 762);
                this.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width - 1, Screen.PrimaryScreen.Bounds.Height - 1);
            }

            cargarFiltros();
            configurarGridHistoricoCubiertas();
        }

        private void configurarGridHistoricoCubiertas()
        {
            this.dgvTrabajoCubiertas.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn _fechaCreacion = new DataGridViewTextBoxColumn();
            _fechaCreacion.DataPropertyName = "v_fecha_orden";
            _fechaCreacion.HeaderText = "Fecha de la Orden";
            _fechaCreacion.Width = 135;
            _fechaCreacion.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _fechaCreacion.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _fechaCreacion.ReadOnly = true;

            DataGridViewTextBoxColumn _clienteColum = new DataGridViewTextBoxColumn();
            _clienteColum.DataPropertyName = "id_cliente";
            _clienteColum.HeaderText = "Cod. Cliente";
            _clienteColum.Width = 97;
            _clienteColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _clienteColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _clienteColum.ReadOnly = true;

            DataGridViewTextBoxColumn _nombreClienteColum = new DataGridViewTextBoxColumn();
            _nombreClienteColum.DataPropertyName = "nombre_cliente";
            _nombreClienteColum.HeaderText = "Nombre del Cliente";
            _nombreClienteColum.Width = 190;
            _nombreClienteColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _nombreClienteColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _nombreClienteColum.ReadOnly = true;

            DataGridViewTextBoxColumn _nroDeOrdenColum = new DataGridViewTextBoxColumn();
            _nroDeOrdenColum.DataPropertyName = "id_orden_de_trabajo";
            _nroDeOrdenColum.HeaderText = "Orden";
            _nroDeOrdenColum.Width = 65;
            _nroDeOrdenColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _nroDeOrdenColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _nroDeOrdenColum.ReadOnly = true;

            DataGridViewTextBoxColumn _nroRenglonColum = new DataGridViewTextBoxColumn();
            _nroRenglonColum.DataPropertyName = "renglon";
            _nroRenglonColum.HeaderText = "R.";
            _nroRenglonColum.Width = 25;
            _nroRenglonColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _nroRenglonColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _nroRenglonColum.ReadOnly = true;

            DataGridViewTextBoxColumn _coche = new DataGridViewTextBoxColumn();
            _coche.DataPropertyName = "coche";
            _coche.HeaderText = "Subcliente/Coche";
            _coche.Width = 120;
            _coche.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _coche.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _coche.ReadOnly = true;

            DataGridViewTextBoxColumn _medidaCubiertaColum = new DataGridViewTextBoxColumn();
            _medidaCubiertaColum.DataPropertyName = "medida_cubierta";
            _medidaCubiertaColum.HeaderText = "Cubierta";
            _medidaCubiertaColum.Width = 135;
            _medidaCubiertaColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _medidaCubiertaColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _medidaCubiertaColum.ReadOnly = true;

            DataGridViewTextBoxColumn _marca = new DataGridViewTextBoxColumn();
            _marca.DataPropertyName = "marca";
            _marca.HeaderText = "Marca";
            _marca.Width = 90;
            _marca.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _marca.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _marca.ReadOnly = true;

            DataGridViewTextBoxColumn _NroSerieColum = new DataGridViewTextBoxColumn();
            _NroSerieColum.DataPropertyName = "serie";
            _NroSerieColum.HeaderText = "Serie";
            _NroSerieColum.Width = 90;
            _NroSerieColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _NroSerieColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _NroSerieColum.ReadOnly = true;

            DataGridViewTextBoxColumn _trabajoColum = new DataGridViewTextBoxColumn();
            _trabajoColum.DataPropertyName = "trabajo";
            _trabajoColum.HeaderText = "Trabajo";
            _trabajoColum.Width = 140;
            _trabajoColum.ReadOnly = true;

            DataGridViewTextBoxColumn _NroInternoColum = new DataGridViewTextBoxColumn();
            _NroInternoColum.DataPropertyName = "interno";
            _NroInternoColum.HeaderText = "Interno";
            _NroInternoColum.Width = 65;
            _NroInternoColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _NroInternoColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _NroInternoColum.ReadOnly = true;

            DataGridViewTextBoxColumn _servicioAdicionalColum = new DataGridViewTextBoxColumn();
            _servicioAdicionalColum.DataPropertyName = "servicio_adicional";
            _servicioAdicionalColum.HeaderText = "Servicio Adicional";
            _servicioAdicionalColum.Width = 140;
            _servicioAdicionalColum.ReadOnly = true;

            this.dgvTrabajoCubiertas.Columns.Add(_fechaCreacion);
            this.dgvTrabajoCubiertas.Columns.Add(_clienteColum);
            this.dgvTrabajoCubiertas.Columns.Add(_nombreClienteColum);
            this.dgvTrabajoCubiertas.Columns.Add(_nroDeOrdenColum);
            this.dgvTrabajoCubiertas.Columns.Add(_nroRenglonColum);
            this.dgvTrabajoCubiertas.Columns.Add(_coche);
            this.dgvTrabajoCubiertas.Columns.Add(_medidaCubiertaColum);
            this.dgvTrabajoCubiertas.Columns.Add(_marca);
            this.dgvTrabajoCubiertas.Columns.Add(_NroSerieColum);
            this.dgvTrabajoCubiertas.Columns.Add(_trabajoColum);
            this.dgvTrabajoCubiertas.Columns.Add(_NroInternoColum);
            this.dgvTrabajoCubiertas.Columns.Add(_servicioAdicionalColum);

        }

        private void cargarFiltros()
        {
            IList<ProductoDTO> medidaFiltro = new List<ProductoDTO>(_medidas.OwnDataList); //independencia

            this.cbxFiltroMedidaDeCubierta.DataSource = medidaFiltro;
            this.cbxFiltroMedidaDeCubierta.DisplayMember = "medida_cubierta";
            this.cbxFiltroMedidaDeCubierta.ValueMember = "id";

            this.cbxFiltroTrabajo.DataSource = _servicio.OwnServList;
            this.cbxFiltroTrabajo.DisplayMember = "descripcion";
            this.cbxFiltroTrabajo.ValueMember = "id";

        }

        private void cargarGridCubiertas()
        {
            _ordenDetalle.refreshGridDataRegistrado3(_filtrosOrden);
            this.dgvTrabajoCubiertas.DataSource = _ordenDetalle.GridDataList;
            dgvTrabajoCubiertas.ClearSelection();
        }

        private void FilterToObjectOrden()
        {
               _filtrosOrden.FiltroTrabajo = long.Parse(this.cbxFiltroTrabajo.SelectedValue.ToString());
               _filtrosOrden.FiltroMedida = long.Parse(this.cbxFiltroMedidaDeCubierta.SelectedValue.ToString());
        }

        private void FilterToObjectOrdenFalse()
        {
            _filtrosOrden.FiltroTrabajo = 99999999;
            _filtrosOrden.FiltroMedida = 99999999;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbxFiltroTrabajo.Text == "" && cbxFiltroMedidaDeCubierta.Text == "")
            {
                this.dgvTrabajoCubiertas.DataSource = null;
            }
            else
            {
                if (!validarDatosFiltros())
                {
                    this.dgvTrabajoCubiertas.DataSource = null;
                }
                else
                {
                    FilterToObjectOrden();
                    cargarGridCubiertas();
                }
            }
         }

        private bool validarDatosFiltros()
        {

            bool rv = true;

            if (this.cbxFiltroTrabajo.Text != "")
            {
                int resultIndex = this.cbxFiltroTrabajo.FindStringExact(cbxFiltroTrabajo.Text);
                if (resultIndex == -1)
                {
                    rv = false;
                }
            }

            if (this.cbxFiltroMedidaDeCubierta.Text != "")
            {
                int resultIndex = this.cbxFiltroMedidaDeCubierta.FindStringExact(cbxFiltroMedidaDeCubierta.Text);
                if (resultIndex == -1)
                {
                    rv = false;
                }
            }
            
            return rv;

        }

        private void cbxFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cbxFiltroTrabajo.Text == "" && cbxFiltroMedidaDeCubierta.Text == "")
                {
                    this.dgvTrabajoCubiertas.DataSource = null;
                }
                else
                {
                    if (!validarDatosFiltros())
                    {
                        this.dgvTrabajoCubiertas.DataSource = null;
                    }
                    else
                    {
                        FilterToObjectOrden();
                        cargarGridCubiertas();
                    }
                }
            }
        }

        private void btnLimpiarGrilla_Click(object sender, EventArgs e)
        {
            clearFilter();
            this.dgvTrabajoCubiertas.DataSource = null;
            this.cbxFiltroTrabajo.Focus();
        }

        private void clearFilter()
        {
            this.objectToFilterOrden(new FiltrosOrden());
        }

        private void objectToFilterOrden(FiltrosOrden filtro)
        {
            this.cbxFiltroTrabajo.Text = filtro.FiltroCodCliente;
            this.cbxFiltroMedidaDeCubierta.Text = filtro.FiltroNroOrden;
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            try
            {
                FilterToObjectOrden();
                frmVerTrabajoCubierta frmReporte = new frmVerTrabajoCubierta();
                crTrabajoCubierta rptLista = frmReporte.cargarReporte(_filtrosOrden);
                frmReporte.crvTrabajoCubierta.ReportSource = rptLista;
                frmReporte.ShowDialog();
                rptLista.Dispose();
                frmReporte.Dispose();
            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Reporte Trabajos y Neumáticos en Planta");
            }
        }

    }
}
