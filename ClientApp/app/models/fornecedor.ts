export interface GuardarFornecedor {
    id: number;
    codigoDoFornecedor: string;
    nomeDoFornecedor: string;
    cpf: string;
    cnpj: string;
    telefone: string;
    endereco: string;
    complemento: string;
    cidade: string;
    estado: string;
}

export interface KeyValuePair { 
    id: number; 
    nomeDoFornecedor: string; 
  } 