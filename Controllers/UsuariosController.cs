using API_VidaPlus.Data;
using API_VidaPlus.Models;
using API_VidaPlus.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace API_VidaPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : Controller
    {
        private readonly UsuariosService _services;
        public UsuariosController(UsuariosService service) { //injeção de dependência;
            _services = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuarios>>> RetornarUsuarios()
        {
            return Ok(await _services.RetornaUsuarios());
        }

        //[Route("id")]
        //[HttpGet]
        //public async Task<ActionResult<List<Usuarios>>> RetornarUsuario(int Id)
        //{
        //    return Ok(await _services.RetornaUsuarioID(Id));
        //}

        [HttpPost]
        public async Task<ActionResult<List<Usuarios>>> CriarUsuario(string Nome = "", int Idade = 0, string Senha = "", string Cpf = "", string Email = "",
            TiposUsuarios Tipo = TiposUsuarios.Paciente)
        {
            return Ok(await _services.CriarUsuario(Nome, Idade,Senha, Cpf, Email, Tipo));

        }

        [HttpPut]
        public async Task<ActionResult<List<Usuarios>>> EditarUsuario(int UsuarioID, string Nome = "", int Idade = 0, string Cpf = "", string Email = "")
        {
            return Ok(await _services.EditarUsuario(UsuarioID, Nome, Idade, Cpf, Email));
        }

        [HttpDelete]
        public async Task<ActionResult<List<Usuarios>>> ExcluirUsuario(int UsuarioID)
        {
            return Ok(await _services.RemoverUsuario(UsuarioID));
        }
    }
}
