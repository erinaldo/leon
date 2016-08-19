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
    public partial class frmABMProductosYServicios : Form
    {
        private Servicio _servicios;

        public frmABMProductosYServicios()
        {
            InitializeComponent();
            _servicios = new Servicio();
        }

        private void frmABMProductosYServicios_Load(object sender, EventArgs e)
        {
            //this.Size = new System.Drawing.Size(1376, 762);
            //if (Resolucion.Escalar())
            //{
            //    Resolucion _ajusteResolucion = new Resolucion();
            //    _ajusteResolucion.ResizeForm(this, 1376, 762);
            //    this.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width - 1, Screen.PrimaryScreen.Bounds.Height - 1);
            //}

            cargarFiltrosServicio();
            configurarGridServicios();
            cargarGridServicios();
        }


        private void cargarFiltrosServicio()
        {
            _servicios.refreshServDataTotal2();
            this.cbxFiltroDescripcionServicio.DataSource = null;
            this.cbxFiltroDescripcionServicio.DataSource = _servicios.OwnServListTotal2;
            this.cbxFiltroDescripcionServicio.DisplayMember = "descripcion";
            this.cbxFiltroDescripcionServicio.ValueMember = "id";

        }

        private void configurarGridServicios()
        {

            this.dgvServicios.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn _descripcion = new DataGridViewTextBoxColumn();
            _descripcion.DataPropertyName = "descripcion";
            _descripcion.HeaderText = "Descripción";
            _descripcion.Width = 358;
            _descripcion.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _descripcion.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _descripcion.ReadOnly = true;

            DataGridViewTextBoxColumn _esAdicional = new DataGridViewTextBoxColumn();
            _esAdicional.DataPropertyName = "es_adicional";
            _esAdicional.HeaderText = "Es adicional";
            _esAdicional.Width = 100;
            _esAdicional.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _esAdicional.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _esAdicional.ReadOnly = true;

            DataGridViewTextBoxColumn _vigente = new DataGridViewTextBoxColumn();
            _vigente.DataPropertyName = "vigente";
            _vigente.HeaderText = "Vigente";
            _vigente.Width = 100;
            _vigente.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _vigente.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _vigente.ReadOnly = true;

            this.dgvServicios.Columns.Add(_descripcion);
            this.dgvServicios.Columns.Add(_esAdicional);
            this.dgvServicios.Columns.Add(_vigente);

        }

        private void cargarGridServicios()
        {
            _servicios.refreshGridData(cbxFiltroDescripcionServicio.Text);
            this.dgvServicios.DataSource = null;
            this.dgvServicios.DataSource = _servicios.GridDataList;
            this.dgvServicios.ClearSelection();
        }

        private void btnFiltrarServicio_Click(object sender, EventArgs e)
        {
            clearFormServ();
            cargarGridServicios();
        }

        private bool ErrorDuplicidadServ(ref string msg)
        {

            bool rv = false;


            if (this.txtDescripcionServicio.Text != "")
            {
                int resultIndex = this.cbxFiltroDescripcionServicio.FindStringExact(txtDescripcionServicio.Text);
                if (resultIndex != -1)
                {
                    msg = "\nExiste un servicio con la descripción ingresada.";
                    rv = true;
                }
            }

            return rv;

        }



        private void btnNuevoServicio_Click(object sender, EventArgs e)
        {
            clearFormServ();
        }

        private void btnGuardarServicio_Click(object sender, EventArgs e)
        {
            try
            {
                ServicioDTO actual = formToObjectServ();

                if (txtDescripcionServicio.Enabled == false && cbhEsAdicional.Enabled == false)
                {
                    DialogResult dialogResult = MessageBox.Show("¿Desea actualizar el servicio?", "Servicios", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        this._servicios.update(actual);
                        //cargarFiltrosServicio();
                        cargarGridServicios();
                        clearFormServ();
                    }
                }
                else 
                {
                    DialogResult dialogResult = MessageBox.Show("¿Desea crear el nuevo servicio?", "Servicios", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        string msg = "";

                        if (!ErrorDuplicidadServ(ref msg))
                        {
                            this._servicios.insert(actual);
                            cargarFiltrosServicio();
                            cargarGridServicios();
                            clearFormServ();
                        }
                        else
                        {
                            MessageBox.Show("No ha sido posible crear el nuevo servicio. Corrija los siguientes errores y vuelva a intentarlo: \n" + msg, "Servicios");
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Validación Guardar Servicio");
            }
        }

        private void btnBorrarServicio_Click(object sender, EventArgs e)
        {
            try
            {
                ServicioDTO actual = formToObjectServ();

                if (actual.Id != -1)
                {
                    DialogResult dialogResult = MessageBox.Show("¿Desea borrar el servicio del sistema?", "Servicios", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        this._servicios.delete(actual);
                        cargarFiltrosServicio();
                        cargarGridServicios();
                        clearFormServ();
                    }
                }
                else
                {
                    MessageBox.Show("No es posible borrar un servicio inexistente.", "Validación Borrar Servicio");
                }

            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Validación Borrar Servicio");
            }
        }

        private void clearFormServ()
        {
            this.cbhVigenteServicio.Checked = true;
            this.txtDescripcionServicio.Text = "";
            this.txtDescripcionServicio.Enabled = true;
            this.cbhEsAdicional.Checked = false;
            this.cbhEsAdicional.Enabled = true;
        }

        private void objectToFormServ(ServicioDTO s)
        {
            txtDescripcionServicio.Text = s.Descripcion;

            if (s.Es_adicional == 'S')
            {
                cbhEsAdicional.Checked = true;
            }
            else
            {
                cbhEsAdicional.Checked = false;
            }

            if (s.Vigente == 'S')
            {
                cbhVigenteServicio.Checked = true;
            }
            else
            {
                cbhVigenteServicio.Checked = false;
            }

        }


        private ServicioDTO formToObjectServ()
        {
            ServicioDTO s = new ServicioDTO();

            s.Descripcion = this.txtDescripcionServicio.Text;

            if (cbhEsAdicional.Checked == true)
            {
                s.Es_adicional = 'S';
            }
            else
            {
                s.Es_adicional = 'N';

            }

            if (cbhVigenteServicio.Checked == true)
            {
                s.Vigente = 'S';
            }
            else
            {
                s.Vigente = 'N';

            }

            s.Id = ServicioDTO.buscarId(s.Descripcion);

            return s;
        }


        private void cbxFiltroServicio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                clearFormServ();
                cargarGridServicios();
            }
        }

        private void dgvServicios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvServicios.SelectedRows.Count > 0)
            {
                this.objectToFormServ((ServicioDTO)this.dgvServicios.SelectedRows[0].DataBoundItem);
                txtDescripcionServicio.Enabled = false;
                cbhEsAdicional.Enabled = false;
            }
        }
    }
}
