using API_VidaPlus.Classes;
using API_VidaPlus.Data;
using API_VidaPlus.Models;
using API_VidaPlus.Services.Geral;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace API_VidaPlus.Services
{
    public class ExamesService
    {
        private readonly DataContext _context;
        private readonly CRUDService<Exames> _crud;

        public ExamesService(CRUDService<Exames> crud, DataContext context)
        {
            _context = context;
            _crud = crud;
        }

        readonly RetornoApi<Exames> Response = new();
        public async Task<RetornoApi<Exames>> MarcarExame(int TipoExameId, DateTime MarcadoPara) {
            Exames Exame = new();
            try
            {
                if(TipoExameId != 0)
                {
                    Exame.TipoExameId = TipoExameId;
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

        public async Task<RetornoApi<Exames>> ComparecerExame(int ExameID)
        {
            try
            {
                var Exame = await _context.Exames.FindAsync(ExameID);

                if(Exame != null)
                {
                    Exame.Compareceu = true;

                    _context.SaveChanges();
                    Response.Sucesso = true;
                    Response.Data.Add(Exame);
                    return Response;
                }
                Response.Erro = "Erro: Exame não encontrado !";
                return Response;
            }
            catch (Exception e) 
            {
                Response.Erro = $"Erro: Falha ao procurar exame: {e.Message}";
                return Response;
            }
        }

        public async Task<RetornoApi<Exames>> ExibirExames()
        {
            try
            {
                Response.Data = await _crud.ReadAll();
                Response.Sucesso = true;
                Response.Mensagem = "Exibindo Exames";
                return Response;
            }
            catch (Exception e)
            {
                Response.Erro = $"Erro: falha ao buscar exames: {e.Message}";
                return Response;
            }
        }
    } 
}

