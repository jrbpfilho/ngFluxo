using ngFluxo.Models;
using Microsoft.EntityFrameworkCore;

namespace ngFluxo.Persistence
{
    public class FluxoDeCaixaDAO : DbContext
    {
        public FluxoDeCaixaDAO(DbContextOptions<FluxoDeCaixaDAO> options)
         : base(options)
         {

         }
         
         public DbSet<Categoria> Categorias { get; set; }
         public DbSet<Fornecedor> Fornecedores { get; set; }

         public DbSet<Produto> Produtos { get; set; }
         public DbSet<SubCategoria> SubCategorias { get; set; }
         
    }
}