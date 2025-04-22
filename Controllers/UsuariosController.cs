using API_VidaPlus.Data;
using API_VidaPlus.Models;
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
        public async Task<ActionResult<List<Usuarios>>> RetornarUsuarios()
        { 
           var UsuarioTeste = await _context.Usuarios.ToListAsync();
           return Ok(UsuarioTeste);
        }

        [HttpPost]
        public async Task<string> CriarUsuario(string Nome = "", int Idade = 0, string Cpf = "", string Email = "", TiposUsuarios Tipo = TiposUsuarios.Paciente)
        {
            Usuarios user = new Usuarios(Nome, Idade, Cpf, Email, Tipo);

            await _context.Usuarios.AddAsync(user);
            return "Criado com Sucesso";

        }
        [HttpPut]
        public async Task<JsonResult> EditarUsuario(int UsuarioID, string Nome = "", int Idade = 0, string Cpf = "", string Email = "")
        {
            var Usuario = await _context.Usuarios.FindAsync(UsuarioID);

            if (Usuario != null) {
               Usuario.Nome = Nome != "" ? Nome : Usuario.Nome;
               Usuario.Idade = Idade != 0 ? Idade : Usuario.Idade;
               Usuario.Cpf = Cpf != "" ? Cpf : Usuario.Cpf;
               Usuario.Email = Email != string.Empty ? Email : Usuario.Email;
               _context.Update(Usuario);
               return Json(Usuario);
            }
            return Json(null);
        }

        [HttpDelete]
        public async Task<bool> ExcluirUsuario(int UsuarioID)
        {
            var Usuario = await _context.Usuarios.FindAsync(UsuarioID);
            if (Usuario != null) {
                _context.Usuarios.Remove(Usuario);
                return true;
            }
            return false;
        }
    }
}
