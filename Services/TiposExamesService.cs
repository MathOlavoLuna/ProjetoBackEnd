using API_VidaPlus.Classes;
using API_VidaPlus.Data;
using API_VidaPlus.Models;
using API_VidaPlus.Services.Geral;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_VidaPlus.Services
{
    public class TiposExamesService 
    {
        private readonly DataContext _context;
        private readonly CRUDService<TiposExames> _crud;
        readonly ILogger<TiposExames> _logger;
        public TiposExamesService(DataContext context, CRUDService<TiposExames> crud, ILogger<TiposExames> logger)
        {
            _context = context;
            _crud = crud;
            _logger = logger;
        }
        public RetornoApi<TiposExames> Response = new();

        public async Task<RetornoApi<TiposExames>> CriarTipoExame(string Nome, string Descritivo)
        {
            try
            {
                if (Nome != "" || Descritivo != "")
                {
                    TiposExames TipoExame = new()
                    {
                        Descritivo = Descritivo,
                        Nome = Nome
                    };

                    Response.Data.Add(await _crud.Create(TipoExame));
                    _context.SaveChanges();
                    Response.Sucesso = true;
                    Response.Mensagem = "Tipo Criado com Sucesso!";
                    return Response;
                }
                Response.Erro = "Erro: Porfavor preencha todas os campos.";
                return Response;
            }
            catch (Exception e)
            {
                _logger.LogError($"Erro: Falha ao criar Tipo de Exame {e.Message}");
                Response.Erro = $"Erro: Falha ao criar Tipo de Exame {e.Message}";
                return Response;
            }
        }

        public async Task<RetornoApi<TiposExames>> ExibirTiposExames()
        {
            try
            {
                Response.Data = await _context.TiposExames.Include(te => te.PertenceExames).ToListAsync();
                Response.Sucesso = true;
                Response.Mensagem = "Exibindo Tipos de Exames";
                return Response;
            }
            catch(Exception e)
            {
                Response.Erro = $"Erro: falha ao exibir Tipos de Exames: {e.Message}";
                return Response;    
            }
        }
    }
}
