using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class HRzone
    {
        public HRzone() { }

        private string _Id;
        public string Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private string _Id_users;
        public string Id_users
        {
            get { return _Id_users; }
            set { _Id_users = value; }
        }

        private int _BMPMax;
        public int BMPMax
        {
            get { return _BMPMax; }
            set { _BMPMax = value; }
        }

        private float _Light;
        public float Light
        {
            get { return _Light; }
            set { _Light = value; }
        }

        private float _Intensive;
        public float Intensive
        {
            get { return _Intensive; }
            set { _Intensive = value; }
        }

        private float _Aerobic;
        public float Aerobic
        {
            get { return _Aerobic; }
            set { _Aerobic = value; }
        }

        private float _Anaerobic;
        public float Anaerobic
        {
            get { return _Anaerobic; }
            set { _Anaerobic = value; }
        }

        private float _VoMax;
        public float VoMax
        {
            get { return _VoMax; }
            set { _VoMax = value; }
        }

        private bool _Eliminado;
        public bool Eliminado
        {
            get { return _Eliminado; }
            set { _Eliminado = value; }
        }

        private string _Fecha_log;
        public string Fecha_log
        {
            get { return _Fecha_log; }
            set { _Fecha_log = value; }
        }
    }
}
