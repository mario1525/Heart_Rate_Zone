using Data.SqlClient;
using System.Data.SqlClient;
using System.Data;
using Entities;

namespace Data
{
    public class DAOHrzone
    {
        private readonly ClientSql _sqlClient;

        public DAOHrzone(ClientSql dbContext)
        {
            _sqlClient = dbContext;
        }
        Guid uid = Guid.NewGuid();

        // Obtener todo
        public async Task<DataTable> GetHrzs()
        {
            string procedureName = "dbo.db_sp_HRzone_Get";
            SqlParameter[] parameters =
           {
                new SqlParameter("@Id", "" ),
                new SqlParameter("@Id_users", ""),
                new SqlParameter("@BMPMax", ""),
                new SqlParameter("@Light", ""),
                new SqlParameter("@Intensive", ""),
                new SqlParameter("@Aerobic", ""),
                new SqlParameter("@Anaerobic", ""),
                new SqlParameter("@VoMax", "")
            };            
            DataTable dataTable = await _sqlClient.ExecuteStoredProcedure(procedureName, parameters);
            return dataTable;
        }

        // Obtener uno
        public async Task<DataTable> GetHrzById(string hrzId)
        {
            string procedureName = "dbo.db_sp_HRzone_Get";
            SqlParameter[] parameters =
            {
                new SqlParameter("@Id",""),
                new SqlParameter("@Id_users", hrzId),
                new SqlParameter("@BMPMax", ""),
                new SqlParameter("@Light", ""),
                new SqlParameter("@Intensive", ""),
                new SqlParameter("@Aerobic", ""),
                new SqlParameter("@Anaerobic", ""),
                new SqlParameter("@VoMax", "")
            };           
            return await _sqlClient.ExecuteStoredProcedure(procedureName, parameters);

        }

        // Crear 
        public void CreateHrz(HRzone hrzone)
        {
            
            if (hrzone == null)
            {               
              
                throw new ArgumentNullException(nameof(hrzone));
            }

            string procedureName = "dbo.db_sp_HRzone_Set";
            SqlParameter[] parameters =
            {
                new SqlParameter("@Id", uid),
                new SqlParameter("@Id_users", hrzone.Id_users),
                new SqlParameter("@BMPMax", hrzone.BMPMax),
                new SqlParameter("@Light", hrzone.Light),
                new SqlParameter("@Intensive", hrzone.Intensive),
                new SqlParameter("@Aerobic", hrzone.Aerobic),
                new SqlParameter("@Anaerobic", hrzone.Anaerobic),
                new SqlParameter("@VoMax", hrzone.VoMax),
                new SqlParameter("@Operacion", "I"),
            };
            _sqlClient.ExecuteStoredProcedure(procedureName, parameters);
            // _sqlClient.
            
                      
        }

        // Actualizar 
        public async Task<Mensaje> UpdateHrz(HRzone hrzone)
        {
            Mensaje mensaje = new Mensaje();
            if (hrzone == null)
            {
                mensaje.Status = 400;
                mensaje.mensaje = "no se cargo ningun Hrz";
                return mensaje;
                throw new ArgumentNullException(nameof(hrzone));
            }

            string procedureName = "dbo.db_sp_HRzone_Set";
            SqlParameter[] parameters =
            {
                new SqlParameter("@Id", uid),
                new SqlParameter("@Id_users", hrzone.Id_users),
                new SqlParameter("@BMPMax", hrzone.BMPMax),
                new SqlParameter("@Light", hrzone.Light),
                new SqlParameter("@Intensive", hrzone.Intensive),
                new SqlParameter("@Aerobic", hrzone.Aerobic),
                new SqlParameter("@Anaerobic", hrzone.Anaerobic),
                new SqlParameter("@VoMax", hrzone.VoMax),
                new SqlParameter("@Operacion", "A"),
            };
            await _sqlClient.ExecuteStoredProcedure(procedureName, parameters);
            // _sqlClient.

            mensaje.Status = 200;
            mensaje.mensaje = "actualizado correctamente";
            return mensaje;
        }

        // Eliminar 
        public async Task<Mensaje> DeleteHrz(string hrzId)
        {
            string procedureName = "dbo.db_sp_HRzone_Del";
            SqlParameter[] parameters =
            {
                new SqlParameter("@Id", hrzId)
            };
            await _sqlClient.ExecuteStoredProcedure(procedureName, parameters);
            Mensaje mensaje = new Mensaje();
            mensaje.Status = 200;
            mensaje.mensaje = "registro eliminado";
            return mensaje;
        }

    }
}
