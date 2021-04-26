using Microsoft.AspNetCore.Mvc;
using PolicyAPI.Models;
using PolicyAPI.Repositories;
using PolicyAPI.Services;

namespace PolicyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        // Obter token
        [HttpPost]
        public IActionResult Logar([FromBody] UserRequest user)
        {
            var userModel = UserRepository.Get(user.Usuario, user.Senha);
            var token = TokenService.GenerateToken(userModel);

            return Ok(token);
        }
    }
}