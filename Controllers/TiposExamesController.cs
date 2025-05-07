using API_VidaPlus.Models;
using API_VidaPlus.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_VidaPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposExamesController : Controller
    {
        private readonly TiposExamesService _service;

        public TiposExamesController(TiposExamesService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<TiposExames>> ExibirTiposExames()
        {
            return Ok(await _service.ExibirTiposExames());
        }

        [HttpPost]
        public async Task<ActionResult<TiposExames>> CriarTipoExame(string Nome, string Descritivo)
        {
            return Ok(await _service.CriarTipoExame(Nome, Descritivo));
        }
    }
}
