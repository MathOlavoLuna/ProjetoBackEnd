using API_VidaPlus.Classes;
using API_VidaPlus.Data;
using API_VidaPlus.Models;
using API_VidaPlus.Services.Geral;

namespace API_VidaPlus.Services
{
    public class ProdutosService
    {
        private readonly CRUDService<Produtos> _crud;
        private readonly DataContext _context;

        public ProdutosService(CRUDService<Produtos> crud, DataContext context)
        {
            _crud = crud;
            _context = context;
        }

        private readonly RetornoApi<Produtos> Response = new();
        public async Task<RetornoApi<Produtos>> CadastrarProduto(string Nome, float Preco)
        {
            try
            {
                Produtos Produto = new Produtos();
                Produto.Preco = Preco;
                Produto.Name = Nome;
                Response.Sucesso = true;
                Response.Mensagem = "Produto Cadastrado";
                Response.Data.Add(await _crud.Create(Produto));
                return Response;
            }
            catch (Exception e)
            {
                Response.Erro = $"Erro: Falha ao criar Produto: {e.Message}";
                return Response;
            }
        }
    }
}
