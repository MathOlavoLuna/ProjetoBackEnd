using API_VidaPlus.Classes;
using API_VidaPlus.Data;
using API_VidaPlus.Models;
using API_VidaPlus.Services.Geral;
using Microsoft.EntityFrameworkCore;

namespace API_VidaPlus.Services
{
    public class AgendaMedicaService
    {
        readonly ILogger<AgendaMedica> _logger;
        readonly CRUDService<AgendaMedica> _crud;
        readonly DataContext _context;

        public AgendaMedicaService(CRUDService<AgendaMedica> crud, DataContext context, ILogger<AgendaMedica> logger    )
        {
            _crud = crud;
            _context = context;
            _logger = logger;
        }

        public RetornoApi<RetornoAgendaMedica> Response = new();
        public async Task<RetornoApi<RetornoAgendaMedica>> VisualizarAgenda(int MedicoId)
        {
            try
            {
                var Agenda = await _context.AgendaMedica.Select(ag => new RetornoAgendaMedica { 
                    Id = ag.Id,
                    MedicoId = ag.Medico.Id,
                    MedicoNome = ag.Medico.Nome,
                    MedicoIdade = ag.Medico.Idade,
                    ExamesMedico = ag.Medico.ExamesMedico,
                    ConsultasMedico = ag.Medico.ConsultasMedico
                }).ToListAsync();
             

                if (Agenda != null)
                {
                    Response.Sucesso = true;
                    Response.Data = Agenda;
                    Response.Mensagem = "Exibindo Agenda";

                    _logger.LogInformation($"Usuário Acesando Agenda");
                    return Response;
                }
                Response.Erro = "Erro: Agenda não encontrada";
                return Response;
            }
            catch(Exception e) { 
                _logger.LogError($"Falha na exibição de agenda");
                Response.Erro = $"Erro: Falha ao procurar agenda: {e.Message}";
                return Response;
            }
        }
    }
}
