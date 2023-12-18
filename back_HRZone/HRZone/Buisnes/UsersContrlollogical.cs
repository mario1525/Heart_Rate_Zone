using Data;
using Entities;
using System.Data;

namespace Buisnes
{
    public class UsersContrlollogical
    {
        private readonly DAOUsers _daoUser;

        public UsersContrlollogical(DAOUsers daoUsuario)
        {
            _daoUser = daoUsuario;

        }

        public List<Users> GetUsers()
        {
            Task<DataTable> taskDataTable = _daoUser.GetUsers();
            DataTable usuario = taskDataTable.Result;           
            List<Users> usuarios = MapDataTableToUsuariosList(usuario);            
            return usuarios;
        }

        public List<Users> GetUserById(string userId)
        {
            Task<DataTable> taskDataTable = _daoUser.GetUserById(userId);
            DataTable usuario = taskDataTable.Result;
            List<Users> usuarios = MapDataTableToUsuariosList(usuario);           
            return usuarios;
        }

        public async  Task<List<Users>> FindByNameAsync(string username)
        {
            Task<DataTable> taskDataTable =  _daoUser.GetUserByUser(username);
            DataTable usuario = taskDataTable.Result;
            List<Users> usuarios = MapDataTableToUsuariosList(usuario);
            return usuarios;
        }

        public async Task<bool> CheckPasswordAsync(List<Users> users, string pasww)
        {
            Task<DataTable> taskDataTable = _daoUser.GetUserByUserpsw(users[0].Usuario, pasww);

            if (taskDataTable == null)
            {
                return false;
            }
            
            return true;
        }

        public async Task<Mensaje> CreateUser(Users user)
        {
            // la lógica para crear un nuevo usuario en el repositorio de datos
            return await _daoUser.CreateUser(user);
        }

        public async Task<Mensaje> UpdateUser(String Id, Users user)
        { 
            // agregar el id al objeto user 
             user.Id = Id;
            // lógica para actualizar un usuario en el repositorio de datos
            return await _daoUser.UpdateUser(user);
        }

        public async Task<Mensaje> DeleteUser(string userId)
        {
            // eliminar un usuario del repositorio de datos
            return await _daoUser.DeleteUser(userId);
        }
        private static List<Users> MapDataTableToUsuariosList(DataTable dataTable)
        {
            List<Users> usuariosList = new List<Users>();

            foreach (DataRow row in dataTable.Rows)
            {
                Users usuario = new Users
                {
                    Id = row["Id"].ToString(),
                    Nombre = row["Nombre"].ToString(),
                    Usuario = row["Usuario"].ToString(),
                    password = row["Contraseña"].ToString(),
                    Rol = row["Rol"].ToString(),
                    Estado = row["Estado"].ToString(),
                    Eliminado = row["Eliminado"].ToString(),
                    Fecha_log = row["Fecha_log"].ToString(),
                    // Asigna otras propiedades según tu DataTable y clase Usuarios
                };
                usuariosList.Add(usuario);
            }
            return usuariosList;
        }
    }
}