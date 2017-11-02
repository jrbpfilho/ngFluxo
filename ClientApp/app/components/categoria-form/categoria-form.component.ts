import { GuardarCategoria } from './../../models/categoria';
import { GuardarSubCategoria } from './../../models/subCategoria';
import { ToastyService } from 'ng2-toasty';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';

import { Component, OnInit } from '@angular/core';
import { ProdutoService } from '../app/services/produto.service';

@Component({
  selector: 'app-categoria-form',
  templateUrl: './categoria-form.component.html',
  styleUrls: ['./categoria-form.component.css']
})
export class CategoriaFormComponent implements OnInit {

  categoria: GuardarCategoria = {
    id: 0,
    nomeDaCategoria: ''
  };

  categorias: any[];

  produto: any = {};

  constructor(
    private produtoService: ProdutoService,
    private route: ActivatedRoute,
    private router: Router,
    private toastyService: ToastyService
    ) { }

  ngOnInit() {

    var sources = [
      this.produtoService.getCategorias()
    ];

    this.produtoService.getCategorias().subscribe(categorias => 
      this.categorias = categorias); 
  }

  onCategoriaChange() {
    var selectedCategoria = this.categorias.find(c => c.id == this.produto.categoria);
  }

  submit() {
    var result$ = this.produtoService.createCategorias(this.categoria);
       // result$.subscribe(x => console.log(x));

       result$.subscribe(categoria => {
         this.toastyService.success({
           title:'Success',
           msg: 'Categoria cadastrada com sucesso',
           theme: 'bootstrap',
           showClose: true,
           timeout: 5000
         });
         this.router.navigate(['/categorias/novo/'])
       });
    }
  }