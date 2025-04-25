using API_VidaPlus.Models;
using API_VidaPlus.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_VidaPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : Controller
    {
        private readonly ConsultasService _service;
        public ConsultasController(ConsultasService service) { 
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<List<Consultas>>> CriarConsulta(TiposConsultas Tipo, int PacienteId, int MedicoId, DateTime MarcadoPara)
        {
            return Ok(await _service.MarcarConsulta(Tipo, PacienteId, MedicoId, MarcadoPara));

        }

        [HttpPut]
        public async Task<ActionResult<List<Consultas>>> EditarUsuario(int ConsultaId)
        {
            return Ok(await _service.EditarConsulta(ConsultaId));
        }
    }
}
