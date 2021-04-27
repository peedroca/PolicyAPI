using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PolicyAPI.Models;

namespace PolicyAPI.Controllers
{
    [ApiController]
    [Route("api")]
    public class HomeController : ControllerBase
    {
        [HttpGet("Pedidos")]
        [Authorize(Policy = "ListarPedidos")]
        public IActionResult Pedidos()
        {
            return Ok(new[] { "Pedido1", "Pedido2" });
        }

        [HttpPost("Produtos")]
        [Authorize(Policy = "CriarProdutos")]
        public IActionResult CriarProdutos([FromBody] string nome)
        {
            return Created(string.Empty, string.Format("Produto {0} criado com sucesso!", nome));
        }

        [HttpGet("Produtos")]
        [Authorize(Policy = "ListarProdutos")]
        public IActionResult Produtos()
        {
            return Ok(new[] { "Produto1", "Produto2" });
        }
    }
}