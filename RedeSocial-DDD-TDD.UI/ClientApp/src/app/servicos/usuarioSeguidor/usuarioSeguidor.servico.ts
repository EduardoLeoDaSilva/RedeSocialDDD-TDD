import {HttpClient, HttpHeaders} from '@angular/common/http'
import {Inject, Injectable} from '@angular/core'
import {Observable} from 'rxjs'
import { Usuario } from 'src/app/modelos/usuario.modelo';



Injectable({
    providedIn: "root"
})
export class UsuarioSeguidorServico{
  
    public baseUrl: string;

    constructor(  private http: HttpClient, @Inject("BASE_URL") baseUrl:string){
        this.baseUrl = baseUrl;
    }


    public  buscarPessoas(nome:string) : Observable<Array<Usuario>>{

        const headers = new HttpHeaders().set('content-type', 'application/json')

            var body ={
                nome : nome
            }
            

           return this.http.post<Array<Usuario>>(`${this.baseUrl}/api/UsuarioSeguidor/ProcurarPessoas`, body, {headers});

    }
}