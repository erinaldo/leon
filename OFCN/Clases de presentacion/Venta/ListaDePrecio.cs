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
    public partial class frmListaDePrecio : Form
    {
        private MedidaCubierta _medidas;
        private ListaDePrecio _lista;
        private Servicio _servicio;
        private Producto _producto;
        private Parametro _parametro;

        public frmListaDePrecio()
        {
            InitializeComponent();
            _medidas = new MedidaCubierta();
            _lista = new ListaDePrecio();
            _servicio = new Servicio();
            _producto = new Producto();
            _parametro = new Parametro();

        }

        private void frmListaDePrecio_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(1376, 762);
            if (Resolucion.Escalar())
            {
                Resolucion _ajusteResolucion = new Resolucion();
                _ajusteResolucion.ResizeForm(this, 1376, 762);
                this.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width - 1, Screen.PrimaryScreen.Bounds.Height - 1);
            }

            cargarFiltros();
            configurarGridLista();
            cargarGridLista();
            this.prbActualizarPrecios.Visible = false;
        }

        private void cargarFiltros()
        {
            this.cbxListaDePrecio.DataSource = _lista.OwnDataList2;
            this.cbxListaDePrecio.DisplayMember = "valor";
            this.cbxListaDePrecio.ValueMember = "id";

            this.cbxFiltroListaDePrecio.DataSource = _lista.OwnDataList;
            this.cbxFiltroListaDePrecio.DisplayMember = "valor";
            this.cbxFiltroListaDePrecio.ValueMember = "id";

            //
            this.cbxMedidaDeCubierta.DataSource = _medidas.OwnDataList;
            this.cbxMedidaDeCubierta.DisplayMember = "medida_cubierta";
            this.cbxMedidaDeCubierta.ValueMember = "id";

            IList<ProductoDTO> medidaFiltro = new List<ProductoDTO>(_medidas.OwnDataList); //independencia

            this.cbxFiltroMedidaDeCubierta.DataSource = medidaFiltro;
            this.cbxFiltroMedidaDeCubierta.DisplayMember = "medida_cubierta";
            this.cbxFiltroMedidaDeCubierta.ValueMember = "id";

            //
            this.cbxTrabajoServicio.DataSource = _servicio.OwnServListTotal;
            this.cbxTrabajoServicio.DisplayMember = "descripcion";
            this.cbxTrabajoServicio.ValueMember = "id";

            //
            this.cbxProducto.DataSource = _producto.OwnDataList;
            this.cbxProducto.DisplayMember = "descripcion";

            //
            IList<ProductoDTO> descripcionArticulo = new List<ProductoDTO>(_producto.OwnDataList); //independencia

            this.cbxFiltroArticulo.DataSource = descripcionArticulo;
            this.cbxFiltroArticulo.DisplayMember = "descripcion";

            //
            this.txtAplicarIva.Text = _parametro.Iva.ToString();
        }


        private void cargarGridLista()
        {

            //1.LEVANTA DE LA BASE
            _lista.OwnDataModeloPrecio.Clear();

            if (this.cbxFiltroMedidaDeCubierta.Text != "")
            {
                int resultIndex = this.cbxFiltroMedidaDeCubierta.FindStringExact(cbxFiltroMedidaDeCubierta.Text);
                if (resultIndex != -1 && (cbxFiltroArticulo.Text == string.Empty || cbxFiltroArticulo.Text == "CUBIERTA"))
                {
                    _lista.refreshOwnDataModeloPrecio(long.Parse(this.cbxFiltroListaDePrecio.SelectedValue.ToString()), cbxFiltroMedidaDeCubierta.Text, "");
                }
            }
            else if(this.cbxFiltroArticulo.Text != ""){
                int resultIndex = this.cbxFiltroArticulo.FindStringExact(cbxFiltroArticulo.Text);
                if (resultIndex != -1)
                {
                    _lista.refreshOwnDataModeloPrecio(long.Parse(this.cbxFiltroListaDePrecio.SelectedValue.ToString()), "", cbxFiltroArticulo.Text);
                }
            }
            else
            {
                _lista.refreshOwnDataModeloPrecio(long.Parse(this.cbxFiltroListaDePrecio.SelectedValue.ToString()), "", "");
            }

            List<string> columnas = new List<string>(_lista.OwnDataColum);
            IList<ProductoDTO> medidaSinPrecio = new List<ProductoDTO>(_medidas.OwnDataList); //independencia
            medidaSinPrecio.RemoveAt(0); //borro el espacio en blanco

            IList<ProductoDTO> productoSinServicio = new List<ProductoDTO>(_producto.OwnDataList);
            productoSinServicio.RemoveAt(0); //borro el espacio en blanco


            int r = 0;
            int r_ant = 0;
            bool encontrado = false;
            this.dgvListaDePrecio.Rows.Clear();

            string producto_ant = string.Empty;
            string medida_ant = string.Empty;

            //2.PROCESA
            if (_lista.OwnDataModeloPrecio.Count != 0)
            {
                producto_ant = _lista.OwnDataModeloPrecio.First().Producto;
                medida_ant = _lista.OwnDataModeloPrecio.First().Medida_cubierta;
                this.dgvListaDePrecio.Rows.Add();
            }

            foreach (PrecioDTO p in _lista.OwnDataModeloPrecio)
            {
                if (producto_ant == p.Producto && medida_ant == p.Medida_cubierta)
                {
                    this.dgvListaDePrecio.Rows[r].Cells[columnas.IndexOf("ARTICULO")].Value = p.Producto;

                    if (p.Medida_cubierta == String.Empty)
                    {
                        this.dgvListaDePrecio.Rows[r].Cells[columnas.IndexOf("PRECIO")].Value = p.V_precio;
                        this.dgvListaDePrecio.Rows[r].DefaultCellStyle.BackColor = Color.Wheat;
                    }
                    else
                    {
                        this.dgvListaDePrecio.Rows[r].Cells[columnas.IndexOf("CUBIERTA")].Value = p.Medida_cubierta;
                        this.dgvListaDePrecio.Rows[r].Cells[columnas.IndexOf(p.Servicio)].Value = p.V_precio;
                        this.dgvListaDePrecio.Rows[r].DefaultCellStyle.BackColor = Color.Azure;
                    }

                }
                else
                {
                    r += 1;
                    r_ant = r;
                    this.dgvListaDePrecio.Rows.Add();
                    this.dgvListaDePrecio.Rows[r].Cells[columnas.IndexOf("ARTICULO")].Value = p.Producto;

                    if (p.Medida_cubierta == String.Empty)
                    {
                        this.dgvListaDePrecio.Rows[r].Cells[columnas.IndexOf("PRECIO")].Value = p.V_precio;
                        this.dgvListaDePrecio.Rows[r].DefaultCellStyle.BackColor = Color.Wheat;
                    }
                    else
                    {
                        this.dgvListaDePrecio.Rows[r].Cells[columnas.IndexOf("CUBIERTA")].Value = p.Medida_cubierta;
                        this.dgvListaDePrecio.Rows[r].Cells[columnas.IndexOf(p.Servicio)].Value = p.V_precio;
                        this.dgvListaDePrecio.Rows[r].DefaultCellStyle.BackColor = Color.Azure;
                    }

                    producto_ant = p.Producto;
                    medida_ant = p.Medida_cubierta;
                }

                if (r == r_ant)
                {
                    //quito del total de la lista
                    for (int g = 0; g < medidaSinPrecio.Count && !encontrado && p.Medida_cubierta != string.Empty; g++)
                    {
                        if (p.Medida_cubierta == medidaSinPrecio[g].Medida_cubierta) //si la medida tiene precio
                        {
                            medidaSinPrecio.Remove(medidaSinPrecio[g]);
                            encontrado = true;
                        }
                    }

                    encontrado = false;

                    for (int g = 0; g < productoSinServicio.Count && !encontrado; g++)
                    {
                        if (p.Producto == productoSinServicio[g].Descripcion) //si el producto tiene precio
                        {
                            productoSinServicio.Remove(productoSinServicio[g]);
                            encontrado = true;
                        }
                    }

                    encontrado = false;

                }
                r_ant += 5; //para que no entre la proxima vez a la condicion anterior.

            }

            //3.CARGA LOS FALTANTES, ARTICULOS SIN PRECIO
            //si filtra por cubierta y no se encontro nada en la base, busco en memoria sobre las q estan sin precio.
            if (this.cbxFiltroMedidaDeCubierta.Text != "" && (cbxFiltroArticulo.Text == "" || cbxFiltroArticulo.Text == "CUBIERTA"))
            {
                int resultIndex = this.cbxFiltroMedidaDeCubierta.FindStringExact(cbxFiltroMedidaDeCubierta.Text);
                if (resultIndex != -1)
                {
                    foreach (ProductoDTO medida in medidaSinPrecio)
                    {
                        if (medida.Medida_cubierta == cbxFiltroMedidaDeCubierta.Text && !encontrado)
                        {
                            this.dgvListaDePrecio.Rows.Add();
                            this.dgvListaDePrecio.Rows[r].Cells[columnas.IndexOf("ARTICULO")].Value = "CUBIERTA";
                            this.dgvListaDePrecio.Rows[r].Cells[columnas.IndexOf("CUBIERTA")].Value = medida.Medida_cubierta;
                            this.dgvListaDePrecio.Rows[r].DefaultCellStyle.BackColor = Color.Azure;
                            encontrado = true;
                        }
                    }
                }
            }

            //encontrado = false;

            if (this.cbxFiltroArticulo.Text != "" && this.cbxFiltroMedidaDeCubierta.Text == "")
            {
                int resultIndex = this.cbxFiltroArticulo.FindStringExact(cbxFiltroArticulo.Text);
                if (resultIndex != -1)
                {
                    foreach (ProductoDTO articulo in productoSinServicio)
                    {
                        if (articulo.Descripcion == cbxFiltroArticulo.Text && !encontrado)
                        {
                            this.dgvListaDePrecio.Rows.Add();
                            this.dgvListaDePrecio.Rows[r].Cells[columnas.IndexOf("ARTICULO")].Value = articulo.Descripcion;
                            this.dgvListaDePrecio.Rows[r].DefaultCellStyle.BackColor = Color.Wheat;
                            encontrado = true;
                        }
                    }
                }
            }

            if (this.cbxFiltroMedidaDeCubierta.Text == "" && this.cbxFiltroArticulo.Text == "")
            {
                if (_lista.OwnDataModeloPrecio.Count > 0)
                {
                    r += 1;
                }

                foreach (ProductoDTO medida in medidaSinPrecio)
                {
                    this.dgvListaDePrecio.Rows.Add();
                    this.dgvListaDePrecio.Rows[r].Cells[columnas.IndexOf("ARTICULO")].Value = "CUBIERTA";
                    this.dgvListaDePrecio.Rows[r].Cells[columnas.IndexOf("CUBIERTA")].Value = medida.Medida_cubierta;
                    this.dgvListaDePrecio.Rows[r].DefaultCellStyle.BackColor = Color.Azure;
                    r += 1;
                }

                foreach (ProductoDTO prod in productoSinServicio)
                {
                    //si ninguna cubierta tiene precio, se mostraria la cubierta como producto.
                    if (prod.Descripcion != "CUBIERTA")
                    {
                        this.dgvListaDePrecio.Rows.Add();
                        this.dgvListaDePrecio.Rows[r].Cells[columnas.IndexOf("ARTICULO")].Value = prod.Descripcion;
                        this.dgvListaDePrecio.Rows[r].DefaultCellStyle.BackColor = Color.Wheat;
                        r += 1;
                    }
                }
            }

            dgvListaDePrecio.Sort(this.dgvListaDePrecio.Columns[2], ListSortDirection.Descending);

            dgvListaDePrecio.ClearSelection();
        }

        private void configurarGridLista()
        {
            this.dgvListaDePrecio.AutoGenerateColumns = false;

            _lista.refreshOwnDataColum();

            foreach (String columna in _lista.OwnDataColum)
            {
                if (columna.Equals("ARTICULO"))
                {
                    DataGridViewTextBoxColumn _AuxColum = new DataGridViewTextBoxColumn();
                    _AuxColum.HeaderText = columna;
                    _AuxColum.Width = 260;
                    _AuxColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    _AuxColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    _AuxColum.ReadOnly = true;
                    _AuxColum.SortMode = DataGridViewColumnSortMode.NotSortable;
                    this.dgvListaDePrecio.Columns.Add(_AuxColum);
                }
                else
                {

                    DataGridViewTextBoxColumn _AuxColum = new DataGridViewTextBoxColumn();
                    _AuxColum.HeaderText = columna;
                    _AuxColum.Width = 130;
                    _AuxColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    _AuxColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    _AuxColum.ReadOnly = true;
                    _AuxColum.SortMode = DataGridViewColumnSortMode.NotSortable;
                    this.dgvListaDePrecio.Columns.Add(_AuxColum);
                }
                               
            }
        }


        private void dgvListaDePrecio_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            clearForm();

            if (e.RowIndex == -1 || e.ColumnIndex == -1 || e.ColumnIndex == 0 || e.ColumnIndex == 2)
                return;

            if (e.ColumnIndex == 1 && this.dgvListaDePrecio.Rows[e.RowIndex].Cells[2].Value != null)
                return;

            if (e.ColumnIndex > 2 && this.dgvListaDePrecio.Rows[e.RowIndex].Cells[2].Value == null)
                return;

            objectToForm(gridToObject(e));
        }

        private PrecioDTO gridToObject(DataGridViewCellEventArgs e)
        {
            List<string> columnas = new List<string>(_lista.OwnDataColum);
            PrecioDTO actual = new PrecioDTO();

            actual.Servicio = columnas[e.ColumnIndex].ToString();
            actual.Lista_de_precio = this.cbxFiltroListaDePrecio.Text;
            actual.Id_lista_precio = long.Parse(this.cbxFiltroListaDePrecio.SelectedValue.ToString());
            actual.Producto = this.dgvListaDePrecio.Rows[e.RowIndex].Cells[0].Value.ToString();


            if (this.dgvListaDePrecio.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
            {
                actual.Valor = 0;
            }
            else
            {
                actual.Valor = decimal.Parse(this.dgvListaDePrecio.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            }

            if (this.dgvListaDePrecio.Rows[e.RowIndex].Cells[2].Value == null)
            {
                actual.Medida_cubierta = "";
            }
            else
            {
                actual.Medida_cubierta = this.dgvListaDePrecio.Rows[e.RowIndex].Cells[2].Value.ToString();
            }

            return actual;

        }

        //
        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            // No se acepta el punto ya que el separador de decimales es la ','
            if (e.KeyChar == ',')
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
                    bool rv = Decimal.TryParse(this.txtPrecio.Text + e.KeyChar, out aux);
                    e.Handled = (!rv);
                }
            }
        }


        private void txtPorcentaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            // No se acepta la coma ya que el separador de decimales es la '.'
            if (e.KeyChar == ',')
                e.Handled = true;
            else
            {
                if (e.KeyChar == '-')
                {
                    e.Handled = false;
                }
                else
                {
                    // Se aceptan teclas de control
                    if (Char.IsControl(e.KeyChar))
                        e.Handled = false;
                    else
                    {
                        // Se acepta la tecla, si el texto resultante es un número decimal
                        Decimal aux = new Decimal();
                        bool rv = Decimal.TryParse(this.txtPorcentaje.Text + e.KeyChar, out aux);
                        e.Handled = (!rv);
                    }
                }
            }
        }

        private void txtAplicarIva_KeyPress(object sender, KeyPressEventArgs e)
        {
            // No se acepta la coma ya que el separador de decimales es la '.'
            if (e.KeyChar == ',')
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
                    bool rv = Decimal.TryParse(this.txtAplicarIva.Text + e.KeyChar, out aux);
                    e.Handled = (!rv);
                }
            }
        }

        private PrecioDTO gridToObject(int i, int j)
        {
            List<string> columnas = new List<string>(_lista.OwnDataColum);
            PrecioDTO actual = new PrecioDTO();

            actual.Servicio = columnas[j].ToString();
            actual.Id_servicio = ServicioDTO.buscarId(actual.Servicio);
            actual.Lista_de_precio = this.cbxFiltroListaDePrecio.Text;
            actual.Id_lista_precio = long.Parse(this.cbxFiltroListaDePrecio.SelectedValue.ToString());

            if (this.dgvListaDePrecio.Rows[i].Cells[j].Value == null)
            {
                actual.Valor = 0;
            }
            else
            {
                actual.Valor = decimal.Parse(this.dgvListaDePrecio.Rows[i].Cells[j].Value.ToString());
            }

            if (this.dgvListaDePrecio.Rows[i].Cells[2].Value == null)
            {
                actual.Medida_cubierta = "";
            }
            else
            {
                actual.Medida_cubierta = this.dgvListaDePrecio.Rows[i].Cells[2].Value.ToString();
            }

            actual.Producto = this.dgvListaDePrecio.Rows[i].Cells[0].Value.ToString();
            actual.Id_producto = ProductoDTO.buscarId3(actual.Producto, actual.Medida_cubierta);

            actual.Id = PrecioDTO.buscarId(actual);

            return actual;

        }

        private void objectToForm(PrecioDTO p)
        {
            this.cbxListaDePrecio.Text = p.Lista_de_precio;
            this.cbxProducto.Text = p.Producto;
            this.cbxMedidaDeCubierta.Text = p.Medida_cubierta;
            this.cbxTrabajoServicio.Text = p.Servicio;
            if (p.Valor != 0)
            {
                this.txtPrecio.Text = p.Valor.ToString();
            }
            else
            {
                this.txtPrecio.Text = "";
            }
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            cargarGridLista();
            clearForm();
            habilitarForm();
            this.chbAplicarIva.Checked = false;
        }


        private void clearForm()
        {
            this.cbxListaDePrecio.Text = "";
            this.cbxProducto.Text = "";
            this.cbxMedidaDeCubierta.Text = "";
            this.cbxTrabajoServicio.Text = "";
            this.txtPrecio.Text = "";

        }


        private void cbxFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                cargarGridLista();
                clearForm();
                habilitarForm();
                this.chbAplicarIva.Checked = false;
            }
        }


        private void actualizarPrecios(decimal multiplicador)
        {

            for (int i = 0; i < dgvListaDePrecio.Rows.Count; i++)
            {

                for (int j = 1; j < _lista.OwnDataColum.Count; j++)
                { //la columna 0 es producto

                    if (this.dgvListaDePrecio.Rows[i].Cells[j].Value != null && j != 2)
                    {

                        decimal valorCell = decimal.Parse(this.dgvListaDePrecio.Rows[i].Cells[j].Value.ToString());
                        valorCell *= multiplicador;
                        valorCell = decimal.Round(valorCell, 2, MidpointRounding.AwayFromZero);
                        string v_valorCell = String.Format("{0:0.00}", valorCell);
                        this.dgvListaDePrecio.Rows[i].Cells[j].Value = v_valorCell;

                    }

                }

            }

        }

        //feb 1.7
        private void actualizarPreciosBase(decimal multiplicador, decimal multiplicadorIva)
        {
            habilizarBarraProgreso();

            List<PrecioDTO> listap = new List<PrecioDTO>();

            for (int i = 0; i < dgvListaDePrecio.Rows.Count; i++)
            {

                for (int j = 1; j < _lista.OwnDataColum.Count; j++)
                { //la columna 0 es producto

                    if (this.dgvListaDePrecio.Rows[i].Cells[j].Value != null && j != 2 && this.dgvListaDePrecio.Rows[i].Cells[2].Value != null)
                    {
                        decimal valorCell = decimal.Parse(this.dgvListaDePrecio.Rows[i].Cells[j].Value.ToString());
                        valorCell *= multiplicadorIva; //calculo el precio con iva
                        valorCell *= multiplicador; //aplico el porcentaje de aumento o decremento
                        valorCell = decimal.Round(valorCell, 0, MidpointRounding.AwayFromZero); //aplico redondeo para que no tenga decimales
                        valorCell /= multiplicadorIva; //calculo el precio sin iva con el aumento o decremento aplicado
                        valorCell = decimal.Round(valorCell, 2, MidpointRounding.AwayFromZero);
                        string v_valorCell = String.Format("{0:0.00}", valorCell);
                        this.dgvListaDePrecio.Rows[i].Cells[j].Value = v_valorCell;
                        listap.Add(gridToObject(i, j));

                        if (prbActualizarPrecios.Value < 400000)
                        {
                            prbActualizarPrecios.PerformStep();
                        }
                    }

                }

            }

            this._lista.update(listap);
            this.prbActualizarPrecios.Value = 1000000;

            deshabilizarBarraProgreso();
        }

        private void actualizarPreciosBase(decimal multiplicador)
        {
            habilizarBarraProgreso();

            List<PrecioDTO> listap = new List<PrecioDTO>();

            for (int i = 0; i < dgvListaDePrecio.Rows.Count; i++)
            {

                for (int j = 1; j < _lista.OwnDataColum.Count; j++)
                { //la columna 0 es producto

                    if (this.dgvListaDePrecio.Rows[i].Cells[j].Value != null && j != 2 && this.dgvListaDePrecio.Rows[i].Cells[2].Value != null)
                    {
                        decimal valorCell = decimal.Parse(this.dgvListaDePrecio.Rows[i].Cells[j].Value.ToString());
                        valorCell *= multiplicador;
                        valorCell = decimal.Round(valorCell, 2, MidpointRounding.AwayFromZero);
                        string v_valorCell = String.Format("{0:0.00}", valorCell);
                        this.dgvListaDePrecio.Rows[i].Cells[j].Value = v_valorCell;
                        listap.Add(gridToObject(i, j));

                        if (prbActualizarPrecios.Value < 400000)
                        {
                            prbActualizarPrecios.PerformStep();
                        }
                    }

                }

            }

            this._lista.update(listap);
            this.prbActualizarPrecios.Value = 1000000;

            deshabilizarBarraProgreso();


        }

        public void habilizarBarraProgreso()
        {

            this.Enabled = false;
            this.prbActualizarPrecios.Maximum = 1000000;
            this.prbActualizarPrecios.Minimum = 0;
            this.prbActualizarPrecios.Value = 0;
            this.prbActualizarPrecios.Step = 1;
            this.prbActualizarPrecios.Visible = true;

        }

        public void deshabilizarBarraProgreso()
        {

            this.prbActualizarPrecios.Visible = false;
            this.Enabled = true;

        }


        private void chbAplicarIva_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                if (chbAplicarIva.Checked)
                {
                    if (txtAplicarIva.Text != "")
                    {
                        decimal iva = decimal.Parse(txtAplicarIva.Text);
                        decimal multiplicador = 1 + (iva / 100);

                        //recorrer matriz
                        actualizarPrecios(multiplicador);
                        clearForm();
                        deshabilitarForm();
                        pnlActualizacionDePrecios.Enabled = false;
                        txtAplicarIva.Enabled = false;
                    }
                    else
                    {

                        MessageBox.Show("Debe ingresar el porcentaje de iva.", "Lista de precios");
                        chbAplicarIva.Checked = false;
                    }

                }
                if (!chbAplicarIva.Checked)
                {
                    cargarGridLista();
                    clearForm();
                    habilitarForm();
                    pnlActualizacionDePrecios.Enabled = true;
                    txtAplicarIva.Enabled = true;
                }

            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Validación Aplicar Iva");
                chbAplicarIva.Checked = false;
            }
        }

        private void deshabilitarForm()
        {
            this.txtPrecio.Enabled = false;
            this.btnGuardar.Enabled = false;
            this.btnBorrar.Enabled = false;
        }

        private void habilitarForm()
        {
            this.txtPrecio.Enabled = true;
            this.btnGuardar.Enabled = true;
            this.btnBorrar.Enabled = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //si es nuevo precio
                PrecioDTO actual = formToObject();

                if (actual.Id == -1)
                {
                    DialogResult dialogResult = MessageBox.Show("¿Desea cargar el nuevo precio?", "Lista de Precios", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        this._lista.insert(actual);
                        cargarGridLista();
                        clearForm();
                    }
                }
                else //en actualizacion
                {
                    DialogResult dialogResult = MessageBox.Show("¿Desea actualizar el precio?", "Lista de Precios", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        this._lista.update(actual);
                        cargarGridLista();
                        clearForm();
                    }
                }
            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Validación Guardar Precio");
            }


        }


        private PrecioDTO formToObject()
        {
            PrecioDTO actual = new PrecioDTO();

            if (this.cbxListaDePrecio.Text != "")
            {
                actual.Id_lista_precio = long.Parse(this.cbxListaDePrecio.SelectedValue.ToString());
            }
            else
            {
                actual.Id_lista_precio = -1;
            }

            if (this.cbxTrabajoServicio.Text != "")
            {
                actual.Id_servicio = long.Parse(this.cbxTrabajoServicio.SelectedValue.ToString());
            }
            else
            {
                actual.Id_servicio = -1;
            }

            //la medida es blanqueada si no es cubierta
            if (this.cbxMedidaDeCubierta.Text != "")
            {
                actual.Id_producto = long.Parse(this.cbxMedidaDeCubierta.SelectedValue.ToString());
                actual.Codigo = actual.Id_producto + "A" + actual.Id_servicio;
            }
            else
            {
                actual.Id_producto = ProductoDTO.buscarId(this.cbxProducto.Text); //si cbxproducto es "" devuelve -1 :)
                actual.Codigo = ProductoDTO.buscarCodigo(actual.Id_producto);
            }

            if (this.txtPrecio.Text != "")
            {
                actual.Valor = decimal.Parse(this.txtPrecio.Text);
            }
            else
            {
                actual.Valor = -1;
            }

            actual.Id = PrecioDTO.buscarId(actual);
            return actual;

        }

        private void cbxFiltroListaDePrecio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgvListaDePrecio.ColumnCount > 0) //para q no explote cuando carga la pantalla
            {
                cargarGridLista();
                clearForm();
                this.chbAplicarIva.Checked = false;
            }

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                PrecioDTO actual = formToObject();

                if (actual.Id != -1)
                {
                    DialogResult dialogResult = MessageBox.Show("¿Desea borrar el precio de la lista?", "Lista de Precios", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        this._lista.delete(actual);
                        cargarGridLista();
                        clearForm();
                    }
                }
                else
                {
                    MessageBox.Show("No es posible borrar un precio inexistente.", "Validación Borrar Precio");
                }

            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Validación Borrar Precio");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.txtPorcentaje.Text != "")
                {
                    DialogResult dialogResult = MessageBox.Show("¿Desea actualizar todos los precios que visualiza en la lista según el porcentaje ingresado?. Solo se actualizará los precios de los trabajos y/o servicios y el nuevo precio se calcula a partir del precio actual sin el IVA aplicado (no aplica redondeo de decimales al precio sin iva)", "Lista de Precios", MessageBoxButtons.YesNo); //feb 1.7
                    if (dialogResult == DialogResult.Yes)
                    {
                        decimal porcentaje = decimal.Parse(this.txtPorcentaje.Text);
                        decimal multiplicador = 1 + (porcentaje / 100);

                        actualizarPreciosBase(multiplicador);
                        cargarGridLista();
                        clearForm();
                        habilitarForm();
                        this.chbAplicarIva.Checked = false;
                    }
                }
                else
                {
                    MessageBox.Show("Debe ingresar un porcentaje de incremento o disminución de los precios.", "Lista de precios");
                }

            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Validación Actualizar Precio");
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                frmReporteListaDePrecio frmReporte = new frmReporteListaDePrecio();
                crListaDePrecio rptLista = frmReporte.cargarReporte(long.Parse(this.cbxFiltroListaDePrecio.SelectedValue.ToString()));
                frmReporte.crvListaDePrecio.ReportSource = rptLista;
                frmReporte.ShowDialog();
                rptLista.Dispose();
                frmReporte.Dispose();
            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Reporte Lista de Precio");
            }

        }

        private void btnActualizarConIVA_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.txtPorcentaje.Text != "")
                {
                    DialogResult dialogResult = MessageBox.Show("¿Desea actualizar todos los precios que visualiza en la lista según el porcentaje ingresado?. Solo se actualizará los precios de los trabajos y/o servicios y el nuevo precio se calcula a partir del precio actual con el IVA aplicado (aplica redondeo de decimales en el precio final).", "Lista de Precios", MessageBoxButtons.YesNo); //feb 1.7
                    if (dialogResult == DialogResult.Yes)
                    {
                        decimal porcentaje = decimal.Parse(this.txtPorcentaje.Text);
                        decimal multiplicador = 1 + (porcentaje / 100);

                        decimal iva = decimal.Parse(txtAplicarIva.Text);
                        decimal multiplicadorIva = 1 + (iva / 100);

                        actualizarPreciosBase(multiplicador, multiplicadorIva);
                        cargarGridLista();
                        clearForm();
                        habilitarForm();
                        this.chbAplicarIva.Checked = false;
                    }
                }
                else
                {
                    MessageBox.Show("Debe ingresar un porcentaje de incremento o disminución de los precios.", "Lista de precios");
                }

            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Validación Actualizar Precio");
            }
        }




    }
}
