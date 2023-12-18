using Data;
using Entities;
using System.Data;


namespace Buisnes
{
    public class HrzoneControllogical
    {
        private readonly DAOHrzone _dAOHrzone;

        public HrzoneControllogical(DAOHrzone daoHrzone)
        {
            _dAOHrzone = daoHrzone;

        }

        public List<HRzone> GetHrzs()
        {
            Task<DataTable> taskDataTable = _dAOHrzone.GetHrzs();
            DataTable usuario = taskDataTable.Result;
            List<HRzone> usuarios = MapDataTableToHrzList(usuario);
            return usuarios;
        }

        public List<HRzone> GetHrzById(string Id)
        {
            Task<DataTable> taskDataTable = _dAOHrzone.GetHrzById(Id);
            DataTable Hrz = taskDataTable.Result;
            List<HRzone> Hrzs = MapDataTableToHrzList(Hrz);
            return Hrzs;
        }


        public async Task<HRzone> CreateHrz(HRzone hrzone)
        {
            //calculo de las zonas
            int bmpmax = hrzone.BMPMax;
            HRzone hrz = new HRzone
            {
                Id = "",
                Id_users = hrzone.Id_users,
                BMPMax = bmpmax,
                Light = Convert.ToSingle(bmpmax * 0.7),
                Intensive = Convert.ToSingle(bmpmax * 0.8),
                Aerobic = Convert.ToSingle(bmpmax * 0.87),
                Anaerobic = Convert.ToSingle(bmpmax * 0.92),
                VoMax = Convert.ToSingle(bmpmax),
                Eliminado = "",
                Fecha_log = "",
            };               
           

            // la lógica para crear un nuevo usuario en el repositorio de datos
             _dAOHrzone.CreateHrz(hrz);

            return hrz;
        }

        public async Task<Mensaje> UpdateUser(String Id, HRzone user)
        {
            // agregar el id al objeto user 
            user.Id = Id;
            // lógica para actualizar un usuario en el repositorio de datos
            return await _dAOHrzone.UpdateHrz(user);
        }

        public async Task<Mensaje> DeleteHrz(string Id)
        {
            // eliminar un usuario del repositorio de datos
            return await _dAOHrzone.DeleteHrz(Id);
        }

        private static List<HRzone> MapDataTableToHrzList(DataTable dataTable)
        {
            List<HRzone> usuariosList = new List<HRzone>();

            foreach (DataRow row in dataTable.Rows)
            {
                HRzone usuario = new HRzone
                {
                    Id = row["Id"].ToString(),
                    Id_users = row["Id_users"].ToString(),
                    BMPMax = Convert.ToInt32(row["BMPMax"]),
                    Light = Convert.ToSingle(row["Light"]),
                    Intensive = Convert.ToSingle(row["Intensive"]),
                    Aerobic = Convert.ToSingle(row["Aerobic"]),
                    Anaerobic = Convert.ToSingle(row["Anaerobic"]),
                    VoMax = Convert.ToSingle(row["VoMax"]),
                    Eliminado = row["Eliminado"].ToString(),
                    Fecha_log = row["Fecha_log"].ToString(),
                };
                usuariosList.Add(usuario);
            }
            return usuariosList;
        }
    }
}
