using API_VidaPlus.Models;
using Microsoft.AspNetCore.Mvc;
using API_VidaPlus.Services;
using Microsoft.AspNetCore.Components.Web;
namespace API_VidaPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamesController : Controller
    {
        private readonly ExamesService _service;
        public ExamesController (ExamesService service) 
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<Exames>> ExibirExames()
        {
            return Ok(await _service.ExibirExames());
        }

        [HttpPost]
        public async Task<ActionResult<Exames>> CriarExame(int TipoExameId, DateTime MarcadoPara)
        {
            return Ok(await _service.MarcarExame(TipoExameId, MarcadoPara));
        }

        [HttpPut]
        public async Task<ActionResult<Exames>> EditarExame(int ExameID)
        {
            return Ok(await _service.ComparecerExame(ExameID));
        }
    }
}
