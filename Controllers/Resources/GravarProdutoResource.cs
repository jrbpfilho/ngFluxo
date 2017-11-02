using System;

namespace ngFluxo.Controllers.Resources
{
    public class GravarProdutoResource
    {
         public int Id { get; set;}

        public string CodigoDoProduto { get; set; }

        public string NomeDoProduto { get; set; }
        
        public int Quantidade { get; set; }

        public int CategoriaId { get; set;}

        public int SubCategoriaId {get; set;}

        public decimal PrecoDeCusto { get; set; }

        public decimal PrecoDeVenda { get; set; }

        public int FornecedorId { get; set; }

        public DateTime AdicionadoEm { get; set; }

        public DateTime ModificadoEm { get; set; }
    }
}