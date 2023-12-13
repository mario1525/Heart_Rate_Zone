using System.Data.SqlClient;
using System.Data;
using Data.SqlClient;
using Entities;

namespace Data
{
    public class DAOUsers
    {       

        #region Metodos 

        private readonly ClientSql _sqlClient;

        public DAOUsers(ClientSql dbContext)
        {
            _sqlClient = dbContext;
        }
        Guid uid = Guid.NewGuid();

        // Obtener todos los usuarios
        public async Task<DataTable> GetUsers()
        {
            string procedureName = "dbo.db_sp_Usuarios_Get";
            SqlParameter[] parameters =
           {
                new SqlParameter("@Id", "" ),
                new SqlParameter("@Usuario", ""),
                new SqlParameter("@Usuario_validacion", ""),
                new SqlParameter("@Contraseña", " "),
                new SqlParameter("@Contraseña_validacion", ""),
                new SqlParameter("@Rol", "cliente"),
                new SqlParameter("@Estado", 1)

            };            
            DataTable dataTable = await _sqlClient.ExecuteStoredProcedure(procedureName, parameters);            
            return dataTable;
        }

        // Obtener un usuario por ID
        public async Task<DataTable> GetUserById(string userId)
        {
            string procedureName = "dbo.db_sp_Users_Get";
            SqlParameter[] parameters =
            {
                new SqlParameter("@Id", userId),
                new SqlParameter("@Nombre", ""),
                new SqlParameter("@Usuario", ""),
                new SqlParameter("@Usuario_validacion", ""),
                new SqlParameter("@Contraseña", ""),
                new SqlParameter("@Contraseña_validacion", ""),
                new SqlParameter("@Rol", ""),
                new SqlParameter("@Estado", 1)
            };
            //Console.WriteLine($"Id: {parameters[0].Value}, Usuario: {parameters[1].Value}, Usuario_vali: {parameters[3].Value}, ...");
            return await _sqlClient.ExecuteStoredProcedure(procedureName, parameters);

        }

        // Crear un nuevo usuario
        public async Task<Mensaje> CreateUser(Users user)
        {
            Mensaje mensaje = new Mensaje();
            if (user == null)
            {
                mensaje.Status = 400;
                mensaje.mensaje = "no se cargo ningun usuario";
                return mensaje;
                throw new ArgumentNullException(nameof(user));
            }

            string procedureName = "dbo.db_sp_Users_Set";
            SqlParameter[] parameters =
            {
                new SqlParameter("@Id", uid),
                new SqlParameter("@Nombre", user.Nombre),
                new SqlParameter("@Usuario", user.Usuario),
                new SqlParameter("@contraseña", user.password),
                new SqlParameter("@Rol", user.Rol),
                new SqlParameter("@Estado", 1),
                new SqlParameter("@Operacion", "I"),
            };
            await _sqlClient.ExecuteStoredProcedure(procedureName, parameters);
            // _sqlClient.
            mensaje.Status = 200;
            mensaje.mensaje = "cargado correctamente";
            return mensaje;
        }

        // Actualizar un usuario existente
        public async Task<Mensaje> UpdateUser( Users user)
        {
            Mensaje mensaje = new Mensaje();
            if (user == null)
            {
                mensaje.Status = 400;
                mensaje.mensaje = "no se cargo ningun usuario";
                return mensaje;
                throw new ArgumentNullException(nameof(user));
            }

            string procedureName = "dbo.db_sp_Users_Set";
            SqlParameter[] parameters =
            {
                new SqlParameter("@Id", user.Id),
                new SqlParameter("@Nombre", user.Nombre),
                new SqlParameter("@Usuario", user.Usuario),
                new SqlParameter("@contraseña", user.password),
                new SqlParameter("@Rol", user.Rol),
                new SqlParameter("@Estado", user.Estado),
                new SqlParameter("@Operacion", "A"),
            };
            await _sqlClient.ExecuteStoredProcedure(procedureName, parameters);
            mensaje.Status = 200;
            mensaje.mensaje = "cargado correctamente";
            return mensaje;
        }

        // Eliminar un usuario por ID
        public async Task<Mensaje> DeleteUser(string userId)
        {
            string procedureName = "dbo.db_sp_Users_Del";
            SqlParameter[] parameters =
            {
                new SqlParameter("@Id", userId)
            };
            await _sqlClient.ExecuteStoredProcedure(procedureName, parameters);
            Mensaje mensaje = new Mensaje();
            mensaje.Status = 200;
            mensaje.mensaje = "registro eliminado";
            return mensaje;
        }

        // valida el usuario
        public async Task<DataTable> ValidateUserCredential(string Usuario, string Contraseña)
        {
            string procedureName = "dbo.db_sp_Users_Get";
            SqlParameter[] parameters =
            {
                new SqlParameter("@Id", "" ),
                new SqlParameter("@Usuario", ""),
                new SqlParameter("@Usuario_validacion", Usuario),
                new SqlParameter("@Contraseña", ""),
                new SqlParameter("@Contraseña_validacion", Contraseña),
                new SqlParameter("@Rol", ""),
                new SqlParameter("@Estado", 1)

            };
            return await _sqlClient.ExecuteStoredProcedure(procedureName, parameters);
        }
        #endregion
    }
}