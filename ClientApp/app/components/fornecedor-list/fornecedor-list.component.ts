import { GuardarFornecedor } from './../../models/fornecedor';
import { Component, OnInit } from '@angular/core';
import { ProdutoService } from '../app/services/produto.service';

@Component({
  selector: 'app-fornecedor-list',
  templateUrl: './fornecedor-list.component.html',
  styleUrls: ['./fornecedor-list.component.css']
})
export class FornecedorListComponent implements OnInit {

  fornecedores: GuardarFornecedor[];
  fornecedores$: any;

  constructor( private produtoService: ProdutoService) {

    this.fornecedores$ = produtoService.getFornecedores();

   }

  ngOnInit() {

    this.produtoService.getFornecedores()
    .subscribe(fornecedores => this.fornecedores = fornecedores);

  }

}
