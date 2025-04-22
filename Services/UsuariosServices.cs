using API_VidaPlus.Data;
using API_VidaPlus.Models;
using API_VidaPlus.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_VidaPlus.Services
{
    public class UsuariosServices
    {
        private readonly DataContext _context;
        public UsuariosServices(DataContext context)
        { 
            _context = context;
        }
        //public async Task<List<Usuarios>> RetornaUsuarios()
        //{
        //    var UsuarioTeste = await _context.Usuarios.ToListAsync();

        //    Models.RetornoService<List<Usuarios>> response = new RetornoService<List<Usuarios>>(true, UsuarioTeste, "");

        //    return response;   
        //}
    }
}
