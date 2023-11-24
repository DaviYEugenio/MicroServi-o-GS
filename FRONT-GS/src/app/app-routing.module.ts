import { NgModule } from '@angular/core';
import { NewHomeComponent } from './views/home/home.component';
import { NewIndicadorComponent } from './views/home/componentes_home/indicador/Indicador.component';
import { RouterModule, Routes } from "@angular/router";
const routes: Routes = [
  {path: '', redirectTo: 'home', pathMatch: 'full'},
  {path: '', component: NewHomeComponent},
  {path: 'indicador', component: NewIndicadorComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
