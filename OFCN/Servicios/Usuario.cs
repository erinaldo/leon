using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OFC
{
    class Usuario
    {
        private static Usuario instancia = null;
        private string login;

        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        private Usuario() { }
        private Usuario(string p_login) { login = p_login; }

        public static Usuario GetInstance(string p_login)
        {
            if (instancia == null)
            {
                instancia = new Usuario(p_login);
            }

            return instancia;
        }

        public static Usuario GetInstance()
        {
            if (instancia == null)
            {
                instancia = new Usuario();
            }

            return instancia;
        }

    }
}
