using API_VidaPlus.Classes;
using API_VidaPlus.Data;
using API_VidaPlus.Models;
using API_VidaPlus.Services.Geral;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace API_VidaPlus.Services
{
    public class ExamesService
    {
        private readonly DataContext _context;
        private readonly CRUDService<Exames> _crud;

        public ExamesService(CRUDService<Exames> crud, DataContext context)
        {
            _context = context;
            _crud = crud;
        }

        readonly RetornoApi<Exames> Response = new();
        public async Task<RetornoApi<Exames>> MarcarExame(int TipoExameId, DateTime MarcadoPara, int PacienteId, int MedicoId) {
            Exames Exame = new();
            try
            {
                if(TipoExameId != 0 && PacienteId != 0)
                {
                    var Paciente = await _context.Usuarios.FindAsync(PacienteId);
                    var Prontuario = await _context.Prontuarios.FirstAsync(p => p.PacienteId == PacienteId);
                    var Medico = await _context.Usuarios.FindAsync(MedicoId);

                    if (Prontuario != null) //Cria um Prontuário caso o paciente seja novo e seja seu primeiro exame;
                    {
                        Exame.ProntuarioId = Prontuario.Id;
                    }
                    else
                    {
                        Prontuarios NovoProntuario = new()
                        {
                            Descritivo = "Descritivo Generico Para Novo Paciente",
                            PacienteId = PacienteId
                        };
                        await _context.Prontuarios.AddAsync(NovoProntuario);
                    }

                    Exame.TipoExameId = TipoExameId;
                    Exame.MarcadoPara = MarcadoPara;
                    Exame.PacienteId = PacienteId;
                    Exame.Paciente = Paciente;
                    Exame.Medico = Medico;
                    Exame.MedicoId = MedicoId;

                    Response.Sucesso = true;
                    Response.Data.Add(await _crud.Create(Exame));
                    Response.Mensagem = "Exame Marcado!";
                    return Response;
                }
                Response.Erro = "Erro: Porfavor preencha todos os campos!";
                return Response;
            }
            catch (Exception e)
            {
                Response.Erro = $"Erro: {e.Message}";
                return Response;
            }
        }   

        public async Task<RetornoApi<Exames>> ComparecerExame(int ExameID)
        {
            try
            {
                var Exame = await _context.Exames.FindAsync(ExameID);

                if(Exame != null)
                {
                    Exame.Compareceu = true;

                    _context.SaveChanges();
                    Response.Sucesso = true;
                    Response.Data.Add(Exame);
                    return Response;
                }
                Response.Erro = "Erro: Exame não encontrado !";
                return Response;
            }
            catch (Exception e) 
            {
                Response.Erro = $"Erro: Falha ao procurar exame: {e.Message}";
                return Response;
            }
        }

        public async Task<RetornoApi<Exames>> ExibirExames()
        {
            try
            {
                Response.Data = await _crud.ReadAll();
                Response.Sucesso = true;
                Response.Mensagem = "Exibindo Exames";
                return Response;
            }
            catch (Exception e)
            {
                Response.Erro = $"Erro: falha ao buscar exames: {e.Message}";
                return Response;
            }
        }
    } 
}

