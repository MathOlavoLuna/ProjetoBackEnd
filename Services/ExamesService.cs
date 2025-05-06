using API_VidaPlus.Classes;
using API_VidaPlus.Models;
using API_VidaPlus.Services.Geral;
using Microsoft.AspNetCore.Http.HttpResults;

namespace API_VidaPlus.Services
{
    public class ExamesService
    {
        private readonly CRUDService<Exames> _crud;

        public ExamesService(CRUDService<Exames> crud)
        {
            _crud = crud;
        }

        readonly RetornoApi<Exames> Response = new();
        public async Task<RetornoApi<Exames>> MarcarExame(TiposExames Tipo, bool Compareceu, DateTime MarcadoPara) {
            Exames Exame = new();
            try
            {
                if(Tipo != null)
                {
                    Exame.Tipo = Tipo;
                    Exame.Compareceu = Compareceu;
                    Exame.MarcadoPara = MarcadoPara;

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
    } 
}

