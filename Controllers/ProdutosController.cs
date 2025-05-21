using API_VidaPlus.Models;
using API_VidaPlus.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_VidaPlus.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : Controller
    {
        readonly ProdutosService _service;
        public ProdutosController(ProdutosService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<Produtos>> CadastrarProduto(string Nome, float Preco)
        {
            return Ok(await _service.CadastrarProduto(Nome, Preco));
        }
    }
}
