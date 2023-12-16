using Buisnes;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace Services
{
    [Route("api/Hrz")]
    [ApiController]
    public class HrzController : ControllerBase
    {
        private readonly HrzoneControllogical _HrzoneControllogical;

        public HrzController(HrzoneControllogical HrzoneControllogical)
        {
            _HrzoneControllogical = HrzoneControllogical;
        }

        // get: api/todoitems
        [HttpGet]
        public List<HRzone> getHrz()
        {
            return _HrzoneControllogical.GetHrzs();

        }

        // get: api/todoitems/5
        // <snippet_getbyid>
        [HttpGet("{id}")]
        public List<HRzone> getHrz(string id)
        {

            var useritem = _HrzoneControllogical.GetHrzById(id);
            return useritem;
        }
        // </snippet_getbyid>

        // put: api/todoitems/5
        // <snippet_update>
        [HttpPut("{id}")]
        public async Task<Mensaje> putHrz(string id, HRzone usuario)
        {
            return await _HrzoneControllogical.UpdateUser(id, usuario);
        }
        // </snippet_update>

        // post: api/todoitems
        // <snippet_create>
        [HttpPost]
        public async Task<HRzone> postHrz(HRzone hrzone)
        {
            return await _HrzoneControllogical.CreateHrz(hrzone);
             
             
        }
        // </snippet_create>

        // delete: api/todoitems/5
        [HttpDelete("{id}")]
        public async Task<Mensaje> deleteHrz(string id)
        {
            return await _HrzoneControllogical.DeleteHrz(id);

        }
    }
}
