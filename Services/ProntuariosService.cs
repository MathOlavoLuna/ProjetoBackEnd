using API_VidaPlus.Classes;
using API_VidaPlus.Data;
using API_VidaPlus.Models;
using API_VidaPlus.Services.Geral;
using Microsoft.EntityFrameworkCore;

namespace API_VidaPlus.Services
{
    public class ProntuariosService
    {
        readonly CRUDService<Prontuarios> _crud;
        readonly DataContext _context;

        public ProntuariosService(DataContext context, CRUDService<Prontuarios> crud)
        {
            _crud = crud;
            _context = context;
        }

        public RetornoApi<Prontuarios> Response = new();
        public RetornoApi<RetornoProntuario> ResponseGet = new();   
        public async Task<RetornoApi<RetornoProntuario>> ExibirProntuario()
        {
            try
            {
                var Prontuarios = await _context.Prontuarios.Select(p => new RetornoProntuario
                {
                    Id = p.Id,
                    ExamesPaciente = p.ExamesPaciente,
                    ConsultasPaciente = p.ConsultasPaciente,
                    NomePaciente = p.Paciente.Nome
                }
                ).ToListAsync();


                if(Prontuarios != null)
                {
                    ResponseGet.Data = Prontuarios;
                    ResponseGet.Sucesso = true;
                    ResponseGet.Mensagem = "Exibindo Prontuário do Paciente.";
                    return ResponseGet;
                }

                Response.Erro = "Erro: Paciente não possui prontuário";
                return ResponseGet;
            }
            catch (Exception e)
            {
                Response.Erro = $"Erro: Falha ao Buscar Prontuário: {e.Message}";
                return ResponseGet;
            }
        }

        public async Task<RetornoApi<Prontuarios>> CriarProntuario(string Descritivo, int PacienteId)
        {
            try
            {
                if(Descritivo != null && PacienteId != 0)
                {
                    var Paciente = await _context.Usuarios.FindAsync(PacienteId);
                    Prontuarios Prontuario = new()
                    {
                        Descritivo = Descritivo,
                        PacienteId = PacienteId,
                        Paciente = Paciente
                    };

                    Response.Data.Add(await _crud.Create(Prontuario));
                    Response.Sucesso = true;
                    Response.Mensagem = "Prontuario criado!";
                    return Response;
                }

                Response.Erro = "Erro: Porfavor preencha todos os campos";
                return Response;
          
            }
            catch (Exception e)
            {
                Response.Erro = $"Erro: falha ao criar prontuário: {e.Message}";
                return Response;
            }
        }
    }
}
