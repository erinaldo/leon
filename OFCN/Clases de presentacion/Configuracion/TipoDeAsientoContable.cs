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
    public partial class frmTipoDeAsientoContable : Form
    {
        public frmTipoDeAsientoContable()
        {
            InitializeComponent();
        }

        private void btnCrearTipoDeAsiento_Click(object sender, EventArgs e)
        {
            frmCrearTipoDeAsiento frmCrearTA = new frmCrearTipoDeAsiento();
            frmCrearTA.ShowDialog();
            frmCrearTA.Dispose();
        }

        private void frmTipoDeAsientoContable_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(1376, 762);
            if (Resolucion.Escalar())
            {
                Resolucion _ajusteResolucion = new Resolucion();
                _ajusteResolucion.ResizeForm(this, 1376, 762);
                this.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width - 1, Screen.PrimaryScreen.Bounds.Height - 1);
            }

            configurarGridTipoDeAsiento();
            configurarGridDetalleTipoDeAsiento();
        }

        private void configurarGridTipoDeAsiento()
        {
            this.dgvListaDeTipoDeAsiento.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn _CodTAColum = new DataGridViewTextBoxColumn();
            _CodTAColum.DataPropertyName = "Cod.";
            _CodTAColum.HeaderText = "Cod. Tipo de Asiento";
            _CodTAColum.Width = 200;
            _CodTAColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _CodTAColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _CodTAColum.ReadOnly = true;

            DataGridViewTextBoxColumn _ConceptoColum = new DataGridViewTextBoxColumn();
            _ConceptoColum.DataPropertyName = "Concepto";
            _ConceptoColum.HeaderText = "Concepto";
            _ConceptoColum.Width = 358;
            _ConceptoColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _ConceptoColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _ConceptoColum.ReadOnly = true;

            this.dgvListaDeTipoDeAsiento.Columns.Add(_CodTAColum);
            this.dgvListaDeTipoDeAsiento.Columns.Add(_ConceptoColum);
        }


        private void configurarGridDetalleTipoDeAsiento()
        {
            this.dgvDetalleDelTipoDeAsiento.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn _codCuentaColum = new DataGridViewTextBoxColumn();
            _codCuentaColum.DataPropertyName = "codCuenta";
            _codCuentaColum.HeaderText = "Cuenta";
            _codCuentaColum.Width = 150;
            _codCuentaColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _codCuentaColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _codCuentaColum.ReadOnly = true;

            DataGridViewTextBoxColumn _debeColum = new DataGridViewTextBoxColumn();
            _debeColum.DataPropertyName = "debe";
            _debeColum.HeaderText = "Debe";
            _debeColum.Width = 100;
            _debeColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _debeColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _debeColum.ReadOnly = true;

            DataGridViewTextBoxColumn _haberColum = new DataGridViewTextBoxColumn();
            _haberColum.DataPropertyName = "haber";
            _haberColum.HeaderText = "Haber";
            _haberColum.Width = 100;
            _haberColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _haberColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _haberColum.ReadOnly = true;

            DataGridViewTextBoxColumn _descripcionColum = new DataGridViewTextBoxColumn();
            _descripcionColum.DataPropertyName = "descripcion";
            _descripcionColum.HeaderText = "Descripción";
            _descripcionColum.Width = 208;
            _descripcionColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _descripcionColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _descripcionColum.ReadOnly = true;

            this.dgvDetalleDelTipoDeAsiento.Columns.Add(_codCuentaColum);
            this.dgvDetalleDelTipoDeAsiento.Columns.Add(_debeColum);
            this.dgvDetalleDelTipoDeAsiento.Columns.Add(_haberColum);
            this.dgvDetalleDelTipoDeAsiento.Columns.Add(_descripcionColum);
        }
    }
}
