using ngFluxo.Extensions;

namespace ngFluxo.Controllers.Resources
{
    public class ProdutoQueryResource : IQueryObject
    {
         
        public int? CategoriaId { get; set;}
        public int? SubCategoriaId { get; set; }

        public int? FornecedorId { get; set; }
        public string SortBy { get; set;}
        public bool IsSortAscending { get; set; }

        public int Page { get; set; }
        public byte PageSize { get; set;}
    }
}