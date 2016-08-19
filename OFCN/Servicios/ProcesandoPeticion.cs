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
    public partial class frmProcesandoPeticion : Form
    {
        public frmProcesandoPeticion()
        {
            InitializeComponent();
        }

        private void frmProcesandoPeticion_Load(object sender, EventArgs e)
        {
            configurarBarraProgreso();
        }


        public void configurarBarraProgreso()
        {
            this.pgbProcesandoPeticion.Style = ProgressBarStyle.Marquee;
            this.pgbProcesandoPeticion.MarqueeAnimationSpeed = 30;
        }

    }
}
