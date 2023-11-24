import { BrowserModule } from '@angular/platform-browser';
import { DEFAULT_CURRENCY_CODE, LOCALE_ID, NgModule} from '@angular/core';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { NewHomeComponent } from './views/home/home.component';
import { NewMateriais_digitaisComponent } from './views/home/componentes_home/materiais_digitais/materiais_digitais.component';
import { NewModal_open_conteudoComponent } from './modais/modal_open_conteudo/modal_open_conteudo.component';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CarouselModule } from 'ngx-owl-carousel-o';
import { DataTablesModule } from "angular-datatables";
import { ModalCadastroSucessoComponent } from './modais/modal-cadastro-sucesso/modal-cadastro-sucesso.component'
import { NgxMaskModule, IConfig } from 'ngx-mask';
import { NgxLoadingModule } from 'ngx-loading';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HashLocationStrategy, LocationStrategy } from '@angular/common';
import { MatAutocompleteModule } from '@angular/material/autocomplete';


@NgModule({
  declarations: [
    AppComponent,
    NewHomeComponent,
    NewMateriais_digitaisComponent,
    NewModal_open_conteudoComponent,
    ModalCadastroSucessoComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    CommonModule,
    CarouselModule,
    DataTablesModule,
    NgxMaskModule.forRoot(),
    NgxLoadingModule.forRoot({}),
    NgbModule,
    MatAutocompleteModule
  ],
  providers: [
    {provide: LOCALE_ID, useValue: 'pt'},
    {
      provide: DEFAULT_CURRENCY_CODE,
      useValue:'BRL',
    },
    {
      provide: LocationStrategy,
      useClass: HashLocationStrategy
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }





