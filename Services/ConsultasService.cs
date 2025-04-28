using API_VidaPlus.Classes;
using API_VidaPlus.Data;
using API_VidaPlus.Models;
using API_VidaPlus.Services.Geral;

namespace API_VidaPlus.Services
{
    public class ConsultasService
    {
        private readonly DataContext _context;
        private readonly CRUDService<Consultas> _crud;
        public ConsultasService(DataContext context, CRUDService<Consultas> crud)
        {
            _context = context;
            _crud = crud;
        }

        readonly RetornoApi<Consultas> Response = new();
      
        public async Task<RetornoApi<Consultas>> MarcarConsulta(TiposConsultas Tipo, int PacienteId, int MedicoId, DateTime MarcadoPara)
        {
            try
            {
                Consultas Consulta = new();
                Consulta.Tipo = Tipo;
                Consulta.PacienteId = PacienteId;
                Consulta.MedicoId = MedicoId;
                Consulta.MarcadoPara = MarcadoPara;

                
                Response.Sucesso = true;
                Response.Mensagem = "Consulta Marcada!";
                Response.Data.Add(await _crud.Create(Consulta));
                return Response;

            }
            catch (Exception e)
            {
                Response.Erro = $"Erro: {e.Message}";
                return Response;
            }
        }

        public async Task<RetornoApi<Consultas>> EditarConsulta(int ConsultaId, TiposConsultas Tipo = 0,  bool? Compareceu = false)
        {
            try
            {
                Consultas Consulta = await _context.Consultas.FindAsync(ConsultaId) ?? new();

                if (Consulta != null)
                {
                    Consulta.Tipo = Tipo != 0 ? Tipo : Consulta.Tipo;
                    Consulta.Compareceu = Compareceu is null ? Consulta.Compareceu : Compareceu;
                    
                    Response.Data = [await _crud.Update(Consulta)];
                    Response.Mensagem = "Consulta Editada!";
                    Response.Sucesso = true;
                    return Response;
                }
                Response.Erro = "Erro: Consulta não encontrada.";
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
