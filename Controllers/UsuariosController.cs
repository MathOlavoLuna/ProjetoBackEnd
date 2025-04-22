using API_VidaPlus.Data;
using API_VidaPlus.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_VidaPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : Controller
    {
        private readonly DataContext _context;
        public UsuariosController(DataContext context) { //injeção de dependência;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuarios>>> GetUsuarios()
        { 
           var UsuarioTeste = await _context.Usuarios.ToListAsync();
           return Ok(UsuarioTeste);
        }
    }
}
