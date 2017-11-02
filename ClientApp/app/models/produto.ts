export interface KeyValuePair {
    id: number;
    name: string;
}

export interface Produto {

    id: number;
    codigoDoProduto: string;
    nomeDoProduto: string;
    quantidade: number;
    categoria: KeyValuePair;
    categoriaId: number;
    subCategoria: KeyValuePair;
    subCategoriaId: number;
    precoDeCusto: number;
    precoDeVenda: number;
    fornecedor: KeyValuePair;
    fornecedorId: number;
    
}

export interface GravarProduto {
    
        id: number;
        codigoDoProduto: string;
        nomeDoProduto: string;
        quantidade: number;
        categoriaId: number;
        subCategoriaId: number;
        precoDeCusto: number;
        precoDeVenda: number;
        fornecedorId: number;
    }