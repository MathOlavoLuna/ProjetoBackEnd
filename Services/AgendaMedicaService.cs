using API_VidaPlus.Classes;
using API_VidaPlus.Data;
using API_VidaPlus.Models;
using API_VidaPlus.Services.Geral;
using Microsoft.EntityFrameworkCore;

namespace API_VidaPlus.Services
{
    public class AgendaMedicaService
    {
        readonly CRUDService<AgendaMedica> _crud;
        readonly DataContext _context;

        public AgendaMedicaService(CRUDService<AgendaMedica> crud, DataContext context)
        {
            _crud = crud;
            _context = context;
        }

        public RetornoApi<AgendaMedica> Response = new();
        public async Task<RetornoApi<AgendaMedica>> VisualizarAgenda()
        {
            try
            {
                var Agenda = await _context.AgendaMedica
                    .Include(ag => ag.Medico
                        .ToListAsync();
                if(Agenda != null)
                {
                    Response.Sucesso = true;
                    Response.Data = Agenda;
                    Response.Mensagem = "Exibindo Agenda";
                    return Response;
                }
                Response.Erro = "Erro: Agenda não encontrada";
                return Response;
            }
            catch(Exception e)
            {
                Response.Erro = $"Erro: Falha ao procurar agenda: {e.Message}";
                return Response;
            }
        }
    }
}
