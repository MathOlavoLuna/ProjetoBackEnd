using API_VidaPlus.Classes;
using API_VidaPlus.Models;
using API_VidaPlus.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_VidaPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProntuariosController : Controller
    {
        readonly ProntuariosService _service;

        public ProntuariosController(ProntuariosService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<Prontuarios>> ExibirProntuario()
        {
            return Ok(await _service.ExibirProntuario());
        }

        [HttpPost]
        public async Task<ActionResult<RetornoProntuario>> CriarPronturario(string Descritivo, int PacienteId)
        {
            return Ok(await _service.CriarProntuario(Descritivo, PacienteId));
        }
    }
}
