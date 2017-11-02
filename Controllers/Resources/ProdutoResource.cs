using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ngFluxo.Controllers.Resources
{
    public class ProdutoResource
    {
        public int Id { get; set;}

        public string CodigoDoProduto { get; set; }

        public string NomeDoProduto { get; set; }
        
        public int Quantidade { get; set; }

        public KeyValuePairResource Categoria { get; set; }

        public int CategoriaId { get; set;}

        public KeyValuePairResource SubCategoria { get; set; }

        public int SubCategoriaId {get; set;}

        public decimal PrecoDeCusto { get; set; }

        public decimal PrecoDeVenda { get; set; }

        public KeyValuePairResource Fornecedor { get; set; }

        public int FornecedorId { get; set; }

        public DateTime AdicionadoEm { get; set; }

        public DateTime ModificadoEm { get; set; }

    }
}