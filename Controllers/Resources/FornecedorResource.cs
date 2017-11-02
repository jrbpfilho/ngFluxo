using System;

namespace ngFluxo.Controllers.Resources
{
    public class FornecedorResource
    {
        public int Id { get; set; }

        public string CodigoDoFornecedor { get; set; }

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