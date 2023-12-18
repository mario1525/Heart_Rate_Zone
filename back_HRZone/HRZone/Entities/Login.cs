using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Login
    {
        private string _Usuario;
        public string Usuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }

        private string _Contraseña;
        public string password
        {
            get { return _Contraseña; }
            set { _Contraseña = value; }
        }
    }
}
