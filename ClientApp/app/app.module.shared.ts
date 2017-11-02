import { FornecedorListComponent } from './components/fornecedor-list/fornecedor-list.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { ToastyModule } from 'ng2-toasty';
import { TypeaheadModule } from 'ngx-bootstrap/typeahead';


import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { CategoriaFormComponent } from './components/categoria-form/categoria-form.component';
import { CategoriasListComponent } from './categorias-list/categorias-list.component';
import { ProdutoService } from './components/app/services/produto.service';
import { ComponentLoaderFactory } from 'ngx-bootstrap/component-loader';
import { PositioningService } from 'ngx-bootstrap/positioning';
import { FornecedorFormComponent } from './components/fornecedor-form/fornecedor-form.component';

import { ProdutoFormComponent } from './components/produto-form/produto-form.component';
import { SubcategoriaFormComponent } from './components/subcategoria-form/subcategoria-form.component';
import { ViewProdutoComponent } from './components/view-produto/view-produto.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        CategoriaFormComponent,
        CategoriasListComponent,
        FornecedorFormComponent,
        FornecedorListComponent,
        ProdutoFormComponent,
        SubcategoriaFormComponent,
        ViewProdutoComponent
    ],
    imports: [
        CommonModule,
      
        HttpModule,
        FormsModule,
        TypeaheadModule,
        ToastyModule.forRoot(),
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'categorias/novo', component: CategoriaFormComponent },
            { path: 'categorias', component: CategoriasListComponent },
            { path: 'categorias/subcategorias/novo', component: SubcategoriaFormComponent },
            { path: 'fornecedores/novo', component: FornecedorFormComponent },
            { path: 'fornecedores/lista', component: FornecedorListComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [
        ProdutoService,
        ComponentLoaderFactory,
        PositioningService
        
    ]
})
export class AppModuleShared {
}
