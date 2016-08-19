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
    public partial class frmANM : Form
    {
        public frmANM()
        {
            InitializeComponent();
        }

        private void btnArticulosYNeumaticos_Click(object sender, EventArgs e)
        {
            frmArticulosYNeumaticos frmAyN = new frmArticulosYNeumaticos();
            frmAyN.ShowDialog();
            frmAyN.Dispose();
        }

        private void btnMovimientos_Click(object sender, EventArgs e)
        {
            frmMovimientosDeStock frmMStock = new frmMovimientosDeStock();
            frmMStock.ShowDialog();
            frmMStock.Dispose();
        }

        private void btnTrabajosYCubiertas_Click(object sender, EventArgs e)
        {
            frmTrabajoCubierta frmTrabajoCub = new frmTrabajoCubierta();
            frmTrabajoCub.ShowDialog();
            frmTrabajoCub.Dispose();
        }

        private void frmANM_Load(object sender, EventArgs e)
        {

        }
    }
}
