export interface GuardarSubCategoria {
    id: number;
    categoriaId: number;
    nomeDaSubCategoria: string;
}

export interface ListarSub {
    id: number;
    categoriaId: number;
    nomeDaSubCategoria: string;
    nomeDaCategoria: string;
}