using API_VidaPlus.Classes;
using API_VidaPlus.Data;
using API_VidaPlus.Models;
using API_VidaPlus.Services;
using API_VidaPlus.Services.Geral;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_VidaPlus.Services
{
    public class UsuariosService 
    {
        private readonly DataContext _context;
        private readonly CRUDService<Usuarios> _crud;
        public UsuariosService(DataContext context, CRUDService<Usuarios> crud)
        { 
            _context = context;
            _crud = crud;
        }

        RetornoApi<Usuarios> Response = new RetornoApi<Usuarios>();
        public async Task<RetornoApi<Usuarios>> RetornaUsuarios()
        {
            try
            {
                Response.Data = await _context.Usuarios.Include(u => u.ConsultasPaciente).Include(u => u.ConsultasMedico).ToListAsync();
                Response.Sucesso = true;
                Response.Mensagem = "Exibindo Usuários";
                return Response;
            }
            catch (Exception e)
            {
                Response.Erro = $"Erro: Falha ao exibir Usuários: {e.Message}";
                return Response;
            }
        }

        public async Task<RetornoApi<Usuarios>> RetornaUsuarioID(int Id)
        {
            try
            {
                Response.Data = [await _crud.ReadId(Id)];
                Response.Sucesso = true;
                Response.Mensagem = "Exibindo Usuário";
                return Response;
            }
            catch (Exception e)  
            {
                Response.Erro = $"Erro: Falha ao exibir Usuário: {e.Message}";
                return Response;
            }
        }

        public async Task<RetornoApi<Usuarios>> CriarUsuario(string Nome, int Idade, string Senha, string Cpf, string Email,
            TiposUsuarios Tipo = TiposUsuarios.Paciente)
        {
            try
            {
                Usuarios Usuario = new Usuarios(Nome, Idade, Senha, Cpf, Email, Tipo);

                if (await _context.Usuarios.AnyAsync(u => u.Email == Usuario.Email))
                {
                    Response.Erro = "Erro: Email já cadastrado";
                    return Response;
                }

                if (await _context.Usuarios.AnyAsync(u => u.Cpf == Usuario.Cpf))
                {
                    Response.Erro = "Erro: CPF já cadastrado";
                    return Response;
                }

                
                Response.Sucesso = true;
                Response.Mensagem = "Usuário criado com sucesso.";
                Response.Data.Add(await _crud.Create(Usuario));
                return Response;

            }
            catch (Exception e)
            {
                Response.Erro = $"Erro: {e.Message}";
                return Response;
            }
        }

        public async Task<RetornoApi<Usuarios>> EditarUsuario(int UsuarioID, string Nome, int Idade, string Cpf, 
            string Email)
        {
            try
            {
                var Usuario = await _context.Usuarios.FindAsync(UsuarioID);

                if (Usuario != null)
                {
                    Usuario.Nome = Nome != "" ? Nome : Usuario.Nome;
                    Usuario.Idade = Idade != 0 ? Idade : Usuario.Idade;
                    Usuario.Cpf = Cpf != "" ? Cpf : Usuario.Cpf;
                    Usuario.Email = Email != string.Empty ? Email : Usuario.Email;
                    
                    Response.Data = [await _crud.Update(Usuario)];
                    Response.Mensagem = "Usuário editado com sucesso.";
                    Response.Sucesso = true;
                    return Response;
                }
                Response.Erro = "Erro: Usuário não encontrado";
                return Response;
            }
            catch (Exception e)
            {
                Response.Erro = $"Erro: {e.Message}";
                return Response;
            }
        }

        public async Task<RetornoApi<Usuarios>> RemoverUsuario(int UsuarioID)
        {
            try
            {
                var Usuario = await _context.Usuarios.FindAsync(UsuarioID);
                if (Usuario != null)
                {

                    Response.Data = [await _crud.Delete(Usuario)];
                    Response.Sucesso = true;
                    Response.Mensagem = "Usuário removido com sucesso.";
                    return Response;
                }
                Response.Erro = "Erro: Usuário não encontrado";
                return Response;
            }
            catch (Exception e) 
            {
                Response.Erro = $"Erro: {e.Message}";
                return Response;
            }
        }
    }
}
