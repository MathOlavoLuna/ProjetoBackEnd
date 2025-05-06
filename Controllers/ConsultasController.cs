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

        [HttpGet]
        public async Task<ActionResult<List<Consultas>>> ExibirConsultas()
        {
            return Ok(await _service.ExibirConsultas());
        }

        [HttpPost]
        public async Task<ActionResult<List<Consultas>>> CriarConsulta(TiposConsultas Tipo, int PacienteId, int MedicoId, DateTime MarcadoPara)
        {
            return Ok(await _service.MarcarConsulta(Tipo, PacienteId, MedicoId, MarcadoPara));

        }

        [HttpPut]
        public async Task<ActionResult<List<Consultas>>> EditarConsulta(int ConsultaId, DateTime MarcadoPara, bool? Compareceu, TiposConsultas Tipo)
        {
            return Ok(await _service.EditarConsulta(ConsultaId, Compareceu, MarcadoPara, Tipo));
        }

        [HttpDelete]
        public async Task<ActionResult<List<Consultas>>> DeletarConsulta(int ConsultaId)
        {
            return Ok(await _service.DesmarcarConsulta(ConsultaId));
        }
    }
}
