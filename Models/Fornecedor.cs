using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ngFluxo.Models
{
    [Table("Fornecedores")]
    public class Fornecedor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string CodigoDoFornecedor { get; set; }

        [Required]
        [StringLength(255)]
        public string NomeDoFornecedor { get; set; }

        public string CPF { get; set; }

        public string CNPJ { get; set; }


        public string Telefone { get; set; }

        public string Endereco { get; set; }

        public string Complemento { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

         public DateTime AdicionadoEm { get; set; }

    }
}