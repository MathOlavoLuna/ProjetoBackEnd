using API_VidaPlus.Classes;
using API_VidaPlus.Data;
using API_VidaPlus.Models;
using API_VidaPlus.Services.Geral;
using Microsoft.EntityFrameworkCore;

namespace API_VidaPlus.Services
{
    public class RelatorioFinanceiroService
    {
        private readonly DataContext _context;
        private readonly CRUDService<RelatorioFinanceiroHospital> _crud;

        public RelatorioFinanceiroService(CRUDService<RelatorioFinanceiroHospital> crud, DataContext context)
        {
            _context = context;
            _crud = crud;
        }
        private readonly RetornoApi<RelatorioFinanceiroHospital> Response = new();
        public async Task<RetornoApi<RelatorioFinanceiroHospital>> Comprar(int ProdutoId)
        {
            var Produto = await _context.Produtos.FindAsync(ProdutoId);
            try
            {
                RelatorioFinanceiroHospital Compra = new();
        
                if (Produto!= null)
                {
                    Compra.Preco = Produto.Preco;
                    Compra.HospitalId = 1;
                    Compra.Total = Compra.Total - Produto.Preco;
                    Compra.Desconto = true;
                    Compra.Provento = false;
                    Compra.ProdutoId = ProdutoId;
                    Response.Data.Add(await _crud.Create(Compra));
                    Response.Sucesso = true;
                    Response.Mensagem = "Compra Realizada!";
                    Produto.RelatorioId = Compra.Id;
                    _context.Produtos.Update(Produto);
                    await _context.SaveChangesAsync();
                    return Response;
                }
                Response.Erro = "Erro: Produto não encontrado.";
                return Response;
            }
            catch (Exception e)
            {
                Response.Erro = $"Erro: Falha ao realizar compra: {e.Message}";
                return Response;
            }
        }
    }
}
