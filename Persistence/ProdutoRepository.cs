using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ngFluxo.Core;
using ngFluxo.Extensions;
using ngFluxo.Models;
using Microsoft.EntityFrameworkCore;

namespace ngFluxo.Persistence
{
    public class ProdutoRepository : IProdutoRepository    
    {
        private readonly FluxoDeCaixaDAO context;
        public ProdutoRepository(FluxoDeCaixaDAO context)
        {
            this.context = context;
        }

        public async Task<Produto> GetProduto(int id, bool includeRelated = true)
        {
        if (!includeRelated)
          return await context.Produtos.FindAsync(id);

        return await context.Produtos
          .Include(s => s.SubCategoria)
            .ThenInclude(c => c.Categoria)
        .Include(f => f.Fornecedor)
          .SingleOrDefaultAsync(v => v.Id == id);
        }
        public void Add(Produto produto) 
        {
        context.Produtos.Add(produto);
        }

        public void Remove(Produto produto)
        {
        context.Remove(produto);
        }
        public async Task<QueryResult<Produto>> GetProdutos(ProdutoQuery queryObj)
        {
            var result = new QueryResult<Produto>();
            var query = context.Produtos
            .Include(p => p.SubCategoria )
            .ThenInclude(p => p.Categoria)
            .Include(f =>  f.Fornecedor)
            .AsQueryable();

            query = query.ApplyFiltering(queryObj);

            var columnsMap = new Dictionary<string, Expression<Func<Produto, object>>>()
         {
            ["nomeDaCategoria"] = v => v.SubCategoria.Categoria.NomeDaCategoria,
            ["nomeDaSubCategoria"] = v => v.SubCategoria.NomeDaSubCategoria,
            ["nomeDoProduto"] = v => v.NomeDoProduto,
            ["quantidade"] = v => v.Quantidade,
            ["codigoDoProduto"] = v => v.CodigoDoProduto,
            ["quantidade"] = v => v.Quantidade,
            ["precoDeVenda"] = v => v.PrecoDeVenda,
            ["precoDeCusto"] = v => v.PrecoDeCusto,
            ["nomeDoFornecedor"] = v => v.Fornecedor.NomeDoFornecedor,
            ["AdicionadoEm"] = v => v.AdicionadoEm,
            ["ModificadoEm"] = v => v.ModificadoEm
            
         };
            query = query.ApplyOrdering(queryObj, columnsMap);
            
            result.TotalItems = await query.CountAsync();

            query = query.ApplyPaging(queryObj);

            result.Items = await query.ToListAsync();

            return result; 
        }
    }
}