using API_VidaPlus.Data;
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
        private readonly DataContext _context;
        public PrescricoesController(PrescricoesService service, DataContext context) { 
            _service = service;
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<Prescricoes>> ExibirPrescricoes()
        {
            return Ok(await _service.ExibirTodasPrescricoes());
        }

        [HttpPost]
        public async Task<ActionResult<Prescricoes>> CriarPrescricao(int ConsultaId, string Descricao, int MedicoId, int HospitalId)
        {
            return Ok(await _service.Prescrever(ConsultaId, MedicoId, HospitalId, Descricao));
        }
    }
}
