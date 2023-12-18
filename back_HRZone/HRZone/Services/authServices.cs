using Buisnes;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Services
{
    [Route("api/auth")]
    [ApiController]
    public class AuhtController : ControllerBase
    {
        private readonly UsersContrlollogical _UsConLogical;
        private readonly authControllogical _AuthControlLogical;

        public AuhtController(UsersContrlollogical usConLogical, authControllogical authControlLogical)
        {
            _UsConLogical = usConLogical;
            _AuthControlLogical = authControlLogical;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Login model)
        {
            List<Users> user = await _UsConLogical.FindByNameAsync(model.Usuario);

            if (user != null &&  await _UsConLogical.CheckPasswordAsync(user, model.password))
            {
                // Verifica el estado y eliminación del usuario si es necesario
                if (user[0].Estado == "1" && user[0].Eliminado == "0")
                {
                    Token token = _AuthControlLogical.GenerateJwtToken(user);
                    return Ok(token);
                }
                else
                {
                    return Unauthorized("Usuario no activo o eliminado");
                }
            }

            return Unauthorized("Credenciales inválidas");
        }
    }
}
