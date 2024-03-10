using democrud.DataContext;
using democrud.models.ComercioModels;

namespace democrud.Service.Comercio
{
    public class ProdutoService : IProdutoInterface
    {
        private readonly ComercioContext _comercioContext;

        public ProdutoService(ComercioContext comercioContext)
        {
            _comercioContext = comercioContext;
        }

        public async Task<Produto> CreateProduto(Produto produto)
        {
            _comercioContext.Produto.Add(produto);
            await _comercioContext.SaveChangesAsync();
            return produto;
        }

        public Task<Produto> GetProduto(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Produto>> GetProdutos()
        {
            List<Produto> produtos = _comercioContext.Produto.ToList();
            return await Task.FromResult(produtos);
            //return produtos;
        }
    }
}
