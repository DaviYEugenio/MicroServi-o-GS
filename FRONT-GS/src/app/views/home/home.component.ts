import { Component } from '@angular/core';
import { Router } from '@angular/router';
import {
  ConteudosService
} from '../../services/service_conteudos/conteudos.service';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class NewHomeComponent {
  islogged?: boolean;
  User_Name?: any;
  tipo: any;
  constructor(private service: ConteudosService, private router: Router) { }
  ngOnInit(){
  }
}
