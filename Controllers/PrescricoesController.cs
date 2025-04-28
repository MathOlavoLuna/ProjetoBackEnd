using API_VidaPlus.Models;
using API_VidaPlus.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_VidaPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescricoesController : Controller
    {
        private readonly PrescricoesService _service;
        public PrescricoesController(PrescricoesService service) { 
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<Prescricoes>> CriarPrescricao(string Descricao, int MedicoId, int HospitalId)
        {
            return Ok(await _service.Prescrever(MedicoId, HospitalId, Descricao));
        }
    }
}
