

namespace Entities
{
    public class Users
    {
        public Users()
        {
        }  
        private string _Id;
        public string Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private string _Nombre;
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

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

        private string _Rol;
        public string Rol
        {
            get { return _Rol; }
            set { _Rol = value; }
        }

        private string _Estado;
        public string Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

        private string _Eliminado;
        public string Eliminado
        {
            get { return _Eliminado; }
            set { _Eliminado = value; }
        }

        private string _FechaLog;
        public string Fecha_log
        {
            get { return _FechaLog; }
            set { _FechaLog = value; }
        }
    }
}
