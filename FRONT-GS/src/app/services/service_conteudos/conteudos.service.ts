import { Conteudo, ConteudosParam } from '../../models/conteudos.model';
import { HttpClient, HttpHeaders, HttpParamsOptions, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { data } from 'jquery';


export const URL: any = {
  API: environment.urlApi
}
@Injectable({
  providedIn: 'root'
})
export class ConteudosService {
  private listaTransferencia: any[];
  token: any;
  idConteudo: any;

  constructor(private httpClient: HttpClient) {
    this.listaTransferencia= [];

  }
  // postIdConteudo(currentId: any) {
  //   this.idConteudo = currentId;
  // }
  // getIdConteudo() {
  //   return this.idConteudo;
  // }
  teste(): Observable<any>{
    return this.httpClient.get<any>(URL.API + "ODS/Objetivos");
  }
  getConteudosGeral(auth_token: any, conteudosParam: any): Observable<any>{
  const headers = auth_token;
  const body = conteudosParam;
    return this.httpClient.post<any>(URL.API + "Conteudo/ListarConteudoGeral", body , {headers});
  }
  getConteudosSemLogin(): Observable<any>{
    return this.httpClient.post<any>(URL.API + "Conteudo/ListarTipoConteudoHome", {});
  }
  getListaMateriais(auth_token: any, componenteParam: any): Observable<any>{
    const headers = auth_token;
    const body = componenteParam;
    return this.httpClient.post<any>(URL.API + "Conteudo/ListarMaterias", body , {headers});
  }
  getListaSerie(auth_token: any, serieParam: any): Observable<any>{
    const headers = auth_token;
    const body = serieParam;
    return this.httpClient.post<any>(URL.API + "Conteudo/ListarSeries", body , {headers});
  }
  getListaTipoConteudo(auth_token: any, tipoConteudoParam: any): Observable<any>{
    const headers = auth_token;
    const body = tipoConteudoParam;
    return this.httpClient.post<any>(URL.API + "Conteudo/ListarTipoConteudo", body);
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
