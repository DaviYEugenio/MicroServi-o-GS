import { NgModule } from '@angular/core';
import { NewHomeComponent } from './views/home/home.component';
import { NewModal_open_conteudoComponent } from './modais/modal_open_conteudo/modal_open_conteudo.component';
import { NewMateriais_digitaisComponent } from './views/home/componentes_home/materiais_digitais/materiais_digitais.component';
import { RouterModule, Routes } from "@angular/router";
const routes: Routes = [
  {path: '', redirectTo: 'home', pathMatch: 'full'},
  {path: '', component: NewHomeComponent},
  {path: 'materiais_digitais', component: NewMateriais_digitaisComponent},
  {path: 'modal_open_conteudo', component: NewModal_open_conteudoComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
