using System.Threading.Tasks;
using Domain.Entity;

namespace AplicationApp.Interfaces
{
    public interface IProdutoService
    {
         
        Task<Produto> AddProdutos(Produto model);
        Task<Produto> UpdateProdutos(int eventoId, Produto model);
        Task<bool> DeleteProduto(int produtoId);

        Task<Produto[]> GetAllProdutosAsync();
        Task<Produto[]> GetAllProdutosAsyncByNome( string nome);
        Task<Produto> GetProdutoAsyncById(int ProdutosId);
    }
}