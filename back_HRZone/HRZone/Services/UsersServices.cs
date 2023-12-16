using Buisnes;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace Services
{
    [Route("api/Users")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsersContrlollogical _UsConLogical;

        public UsuarioController(UsersContrlollogical usConLogical)
        {
            _UsConLogical = usConLogical;
        }

        // get: api/todoitems
        [HttpGet]
        public List<Users> getusers()
        {
            return _UsConLogical.GetUsers();

        }

        // get: api/todoitems/5
        // <snippet_getbyid>
        [HttpGet("{id}")]
        public List<Users> getuser(string id)
        {

            var useritem = _UsConLogical.GetUserById(id);
            return useritem;
        }
        // </snippet_getbyid>

        // put: api/todoitems/5
        // <snippet_update>
        [HttpPut("{id}")]
        public async Task<Mensaje> putusuario(string id, Users usuario)
        {
           return await _UsConLogical.UpdateUser(id, usuario);
        }
        // </snippet_update>

        // post: api/todoitems
        // <snippet_create>
        [HttpPost]
        public async Task<Mensaje> postuser(Users usuario)
        {
           return await _UsConLogical.CreateUser(usuario);
        }
        // </snippet_create>

        // delete: api/todoitems/5
        [HttpDelete("{id}")]
        public async Task<Mensaje> deleteuser(string id)
        {
            return await _UsConLogical.DeleteUser(id);

        }
    }
}
