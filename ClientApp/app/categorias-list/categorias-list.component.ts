import { ListarSub } from './../models/subCategoria';
import { KeyValuePair } from './../models/produto';
import { GuardarCategoria } from './../models/categoria';
import { Component, OnInit } from '@angular/core';
import { ProdutoService } from '../components/app/services/produto.service';


@Component({
  selector: 'app-categorias-list',
  templateUrl: './categorias-list.component.html',
  styleUrls: ['./categorias-list.component.css']
})

export class CategoriasListComponent implements OnInit {

 // categorias: GuardarCategoria[];

    categorias: GuardarCategoria[];
    subCategorias: ListarSub[];

    categorias$:any;
    subCategorias$:any;

  constructor(private produtoService: ProdutoService) { 

    this.categorias$ = produtoService.getCategorias();
    this.subCategorias$ = produtoService.getSubCategorias();
  }

  ngOnInit() {
    this.produtoService.getCategorias()
    .subscribe(categorias => this.categorias = categorias);

    this.produtoService.getSubCategorias()
    .subscribe(subCategorias => this.subCategorias = subCategorias);

    }
    

}
