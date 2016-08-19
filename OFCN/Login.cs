using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;


namespace OFC
{
    public partial class Login : Form
    {
        UsuarioDatos CurrentUser = null;

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            loadEmpresas();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(frmLogin_KeyDown); //capturo cualquier evento del teclado
        }


        private void loadEmpresas()
        {
            try
            {
                if (File.Exists(Application.StartupPath + "\\empresas.ini"))
                {
                    IDictionary data = new Hashtable();
                    string[] parameters = File.ReadAllLines(Application.StartupPath + "\\empresas.ini");
                    cbxEmpresa.DataSource = parameters;
                }
            }
            catch
            {
                throw new Exception("No fue posible obtener las empresas. Asegúrese de configurar el archivo empresas.ini con los parámetros correspondientes.");
            }
        }

        private void frmLogin_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if ((Keys)e.KeyValue == Keys.Escape)
                this.Close();
        }

        private void txtPassword_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.login(cbxEmpresa.Text);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.login(cbxEmpresa.Text);
        }

        private void login(string empresa)
        {
            try
            {
                Encriptacion passUser = new Encriptacion();
                string passEncriptado = passUser.Encriptar(this.txtPassword.Text);

                BaseDeDatos.empresa = empresa; //truchada, no tengo ganas de hacerlo bien...
                CurrentUser = UsuarioDatos.existeUsuario(this.txtUserName.Text, passEncriptado);
                
                if (CurrentUser != null) //con que exista el usuario por ahora alcanza
                {
                    //instancio el usuario por unica vez...
                    Usuario.GetInstance(CurrentUser.Login);
                    //arrancamos
                    frmPrincipal principal = new frmPrincipal(CurrentUser);
                    principal.FormClosed += new FormClosedEventHandler(this.OFC_FormClosed);
                    principal.Text += " - " + empresa;
                    principal.Show();

                    //oculto el login
                    this.Visible = false;
                }
                else
                    MessageBox.Show("No ha sido posible concretar el ingreso al sistema. Por favor, verifique el usuario y contraseña ingresado.", "Login");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No ha sido posible concretar el ingreso al sistema. Inténtelo nuevamente, si el problema persiste contacte al administrador del sistema: " + ex, "Login");
            }
        }

        private void OFC_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.salir();
        }

        private void salir()
        {
            this.Dispose();
            this.Close();
        }

 

    }
}
