using democrud.models.ComercioModels;

namespace democrud.Service.Comercio
{
    public interface IProdutoInterface
    {
        Task<Produto> CreateProduto(Produto produto);
        Task<Produto> GetProduto(int id);
        Task<List<Produto>> GetProdutos();
    }
}
