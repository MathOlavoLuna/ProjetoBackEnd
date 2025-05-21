using API_VidaPlus.Classes;
using API_VidaPlus.Data;
using API_VidaPlus.Models;
using API_VidaPlus.Services.Geral;

namespace API_VidaPlus.Services
{
    public class LeitosService
    {
        readonly CRUDService<Leitos> _crud;
        readonly DataContext _context;
        readonly ILogger<Leitos> _logger;
        public LeitosService(CRUDService<Leitos> crud, DataContext context, ILogger<Leitos> logger)
        {
            _crud = crud;
            _context = context;
            _logger = logger;
        }

        private readonly RetornoApi<Leitos> Response = new();

        public async Task<RetornoApi<Leitos>> RelatorioInternacoes()
        {
            try
            {
                Response.Sucesso = true;
                Response.Mensagem = "Exibindo Internações";
                Response.Data = await _crud.ReadAll();
                return Response;
            }
            catch (Exception e)
            {
                Response.Erro = $"Falha ao exibir Leitos: {e.Message}";
                return Response;
            }
        }
        public async Task<RetornoApi<Leitos>> AlocarPacienteLeito(int PacienteId, int LeitoId)
        {
            try
            {
                var Leito = await _context.Leitos.FindAsync(LeitoId);

               

                if (Leito != null)
                {
                    if (Leito.Ocupado)
                    {
                        Response.Erro = "Erro: Leito já Ocupado.";
                        return Response;
                    }
                    Leito.PacienteId = PacienteId;

                    Response.Sucesso = true;
                    Response.Data.Add(await _crud.Update(Leito));
                    Response.Mensagem = "Leito Ocupado Com Sucesso";
                    return Response;
                }
                Response.Erro = "Erro: Leito não encontrado.";
                return Response;

            }
            catch (Exception e) 
            {
                _logger.LogError($"Erro: Falha ao Ocupar Leito: {e.Message}");
                Response.Erro = $"Erro: Falha ao Ocupar Leito: {e.Message}";
                return Response;
            }
        }
    }
}
