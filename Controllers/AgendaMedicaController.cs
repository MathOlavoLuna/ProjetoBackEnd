using API_VidaPlus.Classes;
using API_VidaPlus.Data;
using API_VidaPlus.Models;
using API_VidaPlus.Services;
using API_VidaPlus.Services.Geral;
using Microsoft.AspNetCore.Mvc;

namespace API_VidaPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaMedicaController : Controller
    {
        readonly AgendaMedicaService _service;
        public AgendaMedicaController(AgendaMedicaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<RetornoAgendaMedica>> ExibirAgenda(int MedicoId)
        {
            return Ok(await _service.VisualizarAgenda(MedicoId));
        }
    }
}
