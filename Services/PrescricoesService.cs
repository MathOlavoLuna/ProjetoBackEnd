using API_VidaPlus.Classes;
using API_VidaPlus.Data;
using API_VidaPlus.Models;
using API_VidaPlus.Services.Geral;
using Microsoft.EntityFrameworkCore;

namespace API_VidaPlus.Services
{
    public class PrescricoesService
    {
        private readonly CRUDService<Prescricoes> _crud;
        private readonly DataContext _context;
        public PrescricoesService(CRUDService<Prescricoes> crud, DataContext context)
        {
            _crud = crud;
            _context = context;
        }

        public RetornoApi<Prescricoes> Response = new();

        public async Task<RetornoApi<Prescricoes>> Prescrever(int ConsultaId = 0, int MedicoId = 0, int HospitalId = 0, string Descricao = "")
        {
            try
            {
                if (MedicoId != 0 && HospitalId != 0 && Descricao != "")
                {
                    Prescricoes Prescricao = new()
                    {
                        Descricao = Descricao,
                        HospitalId = HospitalId,
                        MedicoId = MedicoId
                    };
                    if(ConsultaId != 0)
                    {
                        var Consulta = await _context.Consultas.FindAsync(ConsultaId);
                        if (Consulta != null)
                        {
                            Consulta.Prescricao = Prescricao;

                            _context.Consultas.Update(Consulta);
                            _context.SaveChanges();
                        }
                    }

                    Response.Sucesso = true;
                    Response.Data = [await _crud.Create(Prescricao)];
                    return Response;
                }
                Response.Erro = "Erro: Porfavor Preencha Todos os Campos.";
                return Response;
            } 
            catch (Exception e)
            {
                Response.Erro = $"Erro: Falha ao criar Prescrição, {e.Message}";
                return Response;
            }
        }
    }
}
