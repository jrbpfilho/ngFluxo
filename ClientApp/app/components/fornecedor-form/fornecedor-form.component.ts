import { GuardarFornecedor } from './../../models/fornecedor';

import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from "@angular/router";
import { ToastyService } from "ng2-toasty";
import { ProdutoService } from '../app/services/produto.service';

@Component({
  selector: 'app-fornecedor-form',
  templateUrl: './fornecedor-form.component.html',
  styleUrls: ['./fornecedor-form.component.css']
})
export class FornecedorFormComponent implements OnInit {

fornecedores: GuardarFornecedor = {
  id: 0,
  codigoDoFornecedor: '',
  nomeDoFornecedor: '',
  cpf: '',
  cnpj: '',
  telefone: '',
  endereco: '',
  complemento: '',
  cidade: '',
  estado: ''
};


  constructor(
    private produtoService: ProdutoService,
    private route: ActivatedRoute,
    private router: Router,
    private toastyService: ToastyService) {

        route.params.subscribe

     }

  ngOnInit() {

    var sources = [
      this.produtoService.getFornecedores()
    ];

    //this.produtoService.getFornecedores().subscribe(fornecedores => this.fornecedores = fornecedores);
  }

  submit() {
     var result$ = this.produtoService.create(this.fornecedores);
        // result$.subscribe(x => console.log(x));

        result$.subscribe(fornecedores => {
          this.toastyService.success({
            title:'Success',
            msg: 'Fornecedor cadastrado com sucesso',
            theme: 'bootstrap',
            showClose: true,
            timeout: 5000
          });
          this.router.navigate(['/fornecedores/novo/'])
        });


      /* var result$ = (this.fornecedores.id) ? this.produtoService.update(this.fornecedores) : 
      this.produtoService.create(this.fornecedores); */

  }

}
