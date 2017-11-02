import { GravarProduto } from './../../../models/produto';
import { Http } from '@angular/http';
import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';


@Injectable()
export class ProdutoService {



//private readonly categoriasEndPoint = '/api/categorias';
private readonly produtosEndpoint = '/api/produtos';

  constructor(private http: Http) {
    
   }

 /*  getCategorias() {
    return this.http.get('/api/categorias')
      .map(res => res.json());
  } */

  getProd(productKeyword: string): Observable <any> {
    
            return this.http.get('/api/categorias')
                .map(this.extractData);
        }
    
 private extractData(res: any) {
          let body = res.json();
          return body || { };
} 
      
  
  getCategorias() {
    return this.http.get('/api/categorias')
      .map(res => res.json());
  }

  toQueryString(obj:any) {
    var parts = [];
    for (var property in obj) {
      var value = obj[property];
      if (value != null && value != undefined) 
        parts.push(encodeURIComponent(property) + '=' + encodeURIComponent(value));
    }

    return parts.join('&');
  }

  getProduto(id: any) {
    return this.http.get(this.produtosEndpoint + '/' + id)
    .map(res => res.json());
  }
  
  getProdutos(filter:any) {
    return this.http.get(this.produtosEndpoint + '?' + this.toQueryString(filter))
    .map(res => res.json());
  }
  
  getProdutos2() {
    return this.http.get(this.produtosEndpoint)
    .map(res => res.json());
  }
  
  getSubCategorias() {
    return this.http.get('/api/categorias/subcategorias')
      .map(res => res.json());
  }

  getFornecedores() {
    return this.http.get('/api/fornecedores')
    .map(res => res.json());
  }

  createCategorias(categorias:any) {
    return this.http.post('/api/categorias', categorias)
    .map(res => res.json());
  }

  createSubCategorias(subCategorias:any) {
    return this.http.post('/api/categorias/subcategorias', subCategorias)
    .map(res => res.json());
  }

  create(fornecedores:any) {
    return this.http.post('/api/fornecedores', fornecedores)
    .map(res => res.json());
  }

  createProduto(produto: any) {
    return this.http.post(this.produtosEndpoint, produto)
    .map(res => res.json());
  }

  update(produto: GravarProduto) {
    return this.http.put(this.produtosEndpoint + '/' + produto.id, produto)
      .map(res => res.json());
  }

  delete(id: any) {
    return this.http.delete(this.produtosEndpoint + '/' + id)
      .map(res => res.json());
  }

}
