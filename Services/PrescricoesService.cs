using API_VidaPlus.Classes;
using API_VidaPlus.Data;
using API_VidaPlus.Models;
using API_VidaPlus.Services.Geral;

namespace API_VidaPlus.Services
{
    public class PrescricoesService
    {

        private readonly CRUDService<Prescricoes> _crud;
        public PrescricoesService(CRUDService<Prescricoes> crud)
        {
            _crud = crud;
        }

        public RetornoApi<Prescricoes> Response = new();

        public async Task<RetornoApi<Prescricoes>> Prescrever(int MedicoId = 0, int HospitalId = 0, string Descricao = "")
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
