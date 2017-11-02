using System.Threading.Tasks;
using System.Collections.Generic;
using ngFluxo.Models;

namespace ngFluxo.Core
{
    public interface IProdutoRepository
    {
        Task<Produto> GetProduto(int id, bool includeRelated = true);
        void Add(Produto produto);
        void Remove(Produto produto);
        Task<QueryResult<Produto>> GetProdutos(ProdutoQuery filter);
    }
}