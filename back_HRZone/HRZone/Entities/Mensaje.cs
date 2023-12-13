using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Mensaje
    {

        public Mensaje()
        {

        }

        private int _Status;
        public int Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        private string _Mensaje;
        public string mensaje
        {
            get { return _Mensaje; }
            set { _Mensaje = value; }
        }
    }
}
