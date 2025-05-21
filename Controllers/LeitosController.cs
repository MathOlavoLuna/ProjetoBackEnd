using API_VidaPlus.Classes;
using API_VidaPlus.Models;
using API_VidaPlus.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_VidaPlus.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeitosController : Controller
    {
        private readonly LeitosService _service;
        public LeitosController(LeitosService service)
        {
                _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<Leitos>> FluxoInternaçoes()
        {
            return Ok(await _service.RelatorioInternacoes());
        }
        [HttpPut]
        public async Task<ActionResult<Leitos>> AlocarPacienteLeito(int PacienteId, int LeitoId)
        {
            return Ok(await _service.AlocarPacienteLeito(PacienteId, LeitoId));
        }
    }
}
