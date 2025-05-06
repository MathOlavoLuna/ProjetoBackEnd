using API_VidaPlus.Classes;
using API_VidaPlus.Models;
using API_VidaPlus.Services.Geral;
using Microsoft.AspNetCore.Http.HttpResults;

namespace API_VidaPlus.Services
{
    public class ExamesService
    {
        private readonly CRUDService<Exames> _crud;
        private readonly ExamesService _service;
        public ExamesService(ExamesService service, CRUDService<Exames> crud)
        {
            _service = service;
            _crud = crud;
        }

        readonly RetornoApi<Exames> Response = new();
        public async Task<RetornoApi<Exames>> MarcarExame(TiposExames Tipo, bool Compareceu, DateTime MarcadoPara) {
            Exames Exame = new();
            try
            {
                Exame.Tipo = Tipo;  
                Exame.Compareceu = Compareceu;
                Exame.MarcadoPara = MarcadoPara;
                return Response;
            }
            catch (Exception ex)
            {
                return Response;
            }
        }   
    } 
}

