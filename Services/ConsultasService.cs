using API_VidaPlus.Classes;
using API_VidaPlus.Data;
using API_VidaPlus.Models;
using API_VidaPlus.Services.Geral;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace API_VidaPlus.Services
{
    public class ConsultasService
    {
        readonly ILogger<Consultas> _logger;
        private readonly DataContext _context;
        private readonly CRUDService<Consultas> _crud;
        public ConsultasService(DataContext context, CRUDService<Consultas> crud, ILogger<Consultas> logger)
        {
            _context = context;
            _crud = crud;
            _logger = logger;
        }

        readonly RetornoApi<Consultas> Response = new();

      public async Task<RetornoApi<Consultas>> ExibirConsultas()
        {
            Response.Sucesso = true;
            Response.Mensagem = "Exibindo todas consultas";
            Response.Data = await _context.Consultas.Include(c => c.Prescricao).ToListAsync();
            return Response;
        }
        public async Task<RetornoApi<Consultas>> MarcarConsulta(TiposConsultas Tipo, int PacienteId, int MedicoId, DateTime MarcadoPara)
        {
            try
            {
                var Paciente = await _context.Usuarios.FindAsync(PacienteId);
                var Medico = await _context.Usuarios.FindAsync(MedicoId);
                var Prontuario = await _context.Prontuarios.FirstOrDefaultAsync(p => p.PacienteId == PacienteId);
                Consultas Consulta = new()
                {
                    Tipo = Tipo,
                    PacienteId = PacienteId,
                    MedicoId = MedicoId,
                    MarcadoPara = MarcadoPara,
                };

                if (Prontuario != null) //Cria um Prontuário caso o paciente seja novo e seja seu primeiro exame;
                {
                    Consulta.ProntuarioId = Prontuario.Id;
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


                Response.Sucesso = true;
                Response.Mensagem = "Consulta Marcada!";
                Response.Data.Add(await _crud.Create(Consulta));
                return Response;

            }
            catch (Exception e)
            {
                _logger.LogError($"Falha na criação da Consulta: {e.Message}");
                Response.Erro = $"Erro: {e.Message}";
                return Response;
            }
        }

        public async Task<RetornoApi<Consultas>> EditarConsulta(int ConsultaId, bool? Compareceu, DateTime? MarcadoPara , TiposConsultas Tipo = 0)
        {
            try
            {
                var Consulta = await _context.Consultas.FindAsync(ConsultaId);

                if (Consulta != null)
                {
                    Consulta.Tipo = Tipo != 0 ? Tipo : Consulta.Tipo;
                    Consulta.Compareceu = Compareceu != null ? Compareceu : Consulta.Compareceu;
                    Consulta.MarcadoPara = MarcadoPara != null ? (DateTime) MarcadoPara : Consulta.MarcadoPara;
                    Response.Data = [await _crud.Update(Consulta)];
                    Response.Mensagem = "Consulta Remarcada!";
                    Response.Sucesso = true;
                    return Response;
                }
                Response.Erro = "Erro: Consulta não encontrada.";
                return Response;
            }
            catch (Exception e)
            {
                _logger.LogError($"Falha na edição da Consulta: {e.Message}");
                Response.Erro = $"Erro: {e.Message}";
                return Response;
            }
        }

        public async Task<RetornoApi<Consultas>> DesmarcarConsulta(int ConsultaId)
        {
            try
            {
                var Consulta = await _context.Consultas.FindAsync(ConsultaId);

                if (Consulta != null) { 
                    await _crud.Delete(Consulta);
                    _context.SaveChanges();

                    Response.Data = [Consulta];
                    Response.Mensagem = "Consulta Desmarcada!";
                    Response.Sucesso = true;
                    return Response;
                }
                Response.Erro = "Erro: Falha ao encontrar Consulta";
                return Response;
            }
            catch (Exception e) 
            {
                _logger.LogError($" Falha ao Desmarcar Consulta : {e.Message}");
                Response.Erro = $"Erro: Falha ao Desmarcar Consulta: {e.Message}";
                return Response;
            }
        }
    }
}
