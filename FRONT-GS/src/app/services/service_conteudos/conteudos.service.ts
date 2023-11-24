import { HttpClient, HttpHeaders, HttpParamsOptions, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';


export const URL: any = {
  API: environment.urlApi
}
@Injectable({
  providedIn: 'root'
})
export class ConteudosService {


  constructor(private httpClient: HttpClient) {
  }
  teste(): Observable<any>{
    return this.httpClient.get<any>(URL.API + "ODS/Objetivos");
  }

  getIndicadorById(idCodigo: any): Observable<any>{
    const body = { codigo: idCodigo };
    return this.httpClient.post<any>(URL.API + "ODS/Indicador", body);
  }
  getIndicadorByRegiao(regiao: any, idCodigo: any): Observable<any>{
    const body = { regiao: regiao, codigo: idCodigo };
    return this.httpClient.post<any>(URL.API + "ODS/BuscarPorRegiao", body);
  }
}
