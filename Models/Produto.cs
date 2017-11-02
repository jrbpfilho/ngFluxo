using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ngFluxo.Models
{
    [Table("Produtos")]
    public class Produto
    {
        
        public int Id { get; set;}

        [Required]
        [StringLength(255)]
        public string CodigoDoProduto { get; set; }

        [Required]
        [StringLength(255)]
        public string NomeDoProduto { get; set; }

        public int Quantidade { get; set; }

        public Categoria Categoria { get; set; }

        public int? CategoriaId { get; set; }

        public SubCategoria SubCategoria { get; set; }

        public int? SubCategoriaId { get; set; }

        [DataType(DataType.Currency)]
        public decimal PrecoDeCusto { get; set; }

        [DataType(DataType.Currency)]
        public decimal PrecoDeVenda { get; set; }

        public Fornecedor Fornecedor { get; set; }

        public int? FornecedorId { get; set; }

        public DateTime AdicionadoEm { get; set; }

        public DateTime ModificadoEm { get; set; }

    }
}