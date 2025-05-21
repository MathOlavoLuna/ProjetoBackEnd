using API_VidaPlus.Models;
using API_VidaPlus.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_VidaPlus.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RelatorioFinanceiroController : Controller
    {
        private readonly RelatorioFinanceiroService _service;
        public RelatorioFinanceiroController(RelatorioFinanceiroService service)
        {
            _service = service;
        }

        [HttpPost]        
        public async Task<ActionResult<RelatorioFinanceiroHospital>> ComprarProduto(int ProdutoId)
        {
            return Ok(await _service.Comprar(ProdutoId));
        }
    }
}
