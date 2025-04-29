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
                var Paciente = await _context.Usuarios.FindAsync(PacienteId);
                var Medico = await _context.Usuarios.FindAsync(MedicoId);
                Consultas Consulta = new()
                {
                    Tipo = Tipo,
                    PacienteId = PacienteId,
                    MedicoId = MedicoId,
                    MarcadoPara = MarcadoPara,
                };

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
                Response.Erro = $"Erro: Falha ao Desmarcar Consulta: {e.Message}";
                return Response;
            }
        }
    }
}
