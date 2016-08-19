using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace OFC
{
    public partial class frmPrincipal : Form
    {
        private UsuarioDatos CurrentUser = null;
        frmOFC ofc = null;
        frmCPC cpc = null;
        frmANM anm = null;
        frmCONF conf = null;
        Thread currentThread = null;
        Parametro _parametro = null;
        delegate void habilizarBarraProgresoDelegate();
        delegate void deshabilizarBarraProgresoDelegate();

        public frmPrincipal(UsuarioDatos user)
        {
            InitializeComponent();
            CurrentUser = user;
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            //para que tome el color definido en la propiedad backcolor
            MdiClient ctlMDI;
            foreach (Control ctl in this.Controls)
            {
                try
                {
                    ctlMDI = (MdiClient)ctl;
                    ctlMDI.BackColor = this.BackColor;
                }
                catch (InvalidCastException exc)
                {
                    //hacer algo
                }
            }

            //muestro empresa
            txtEmpresa.Text = BaseDeDatos.empresa;

            //carga de complementos.
            try
            {
                _parametro = new Parametro();
                _parametro.refreshOwnData("INICIAR COMPLEMENTOS");
                if (_parametro.OwnDataListGrid[0].Parametro_1 == 1)
                {
                    StartThread();
                }
            }
            catch (Exception)
            {
                //hacer algo
            }


        }

        private void StartThread()
        {
            if (currentThread == null)
            {
                currentThread = new System.Threading.Thread(DoProcess);
                currentThread.Start();
            }
        }

        private void DoProcess()
        {
            this.Invoke(new habilizarBarraProgresoDelegate(habilizarBarraProgreso));
            IniciarCrystalReports.ejecutarDummy();
            this.Invoke(new deshabilizarBarraProgresoDelegate(deshabilizarBarraProgreso));
        }

        public void habilizarBarraProgreso()
        {
            this.lblCargandoComplementos.Visible = true;
            this.pbrCargandoComplementos.Style = ProgressBarStyle.Marquee;
            this.pbrCargandoComplementos.MarqueeAnimationSpeed = 30;
            this.pbrCargandoComplementos.Visible = true;
        }

        public void deshabilizarBarraProgreso()
        {
            this.lblCargandoComplementos.Visible = false;
            this.pbrCargandoComplementos.MarqueeAnimationSpeed = 0;
            this.pbrCargandoComplementos.Visible = false;
        }

        private void btnVenta_Click(object sender, EventArgs e)
        {
            if (ofc == null)
            {
                ofc = new frmOFC(CurrentUser);
                ofc.MdiParent = this;
            }
            ofc.Hide();
            ofc.Show();
        }

        private void btnCompra_Click(object sender, EventArgs e)
        {
            if (cpc == null)
            {
                cpc = new frmCPC();
                cpc.MdiParent = this;
            }
            cpc.Hide();
            cpc.Show();
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            if (anm == null)
            {
                anm = new frmANM();
                anm.MdiParent = this;
            }
            anm.Hide();
            anm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (conf == null)
            {
                conf = new frmCONF();
                conf.MdiParent = this;
            }
            else
            {
                conf.Dispose();
                conf = new frmCONF();
                conf.MdiParent = this;
            }

            conf.Hide();
            conf.Show();
        }

    }
}
