import { HttpClient, HttpHeaders } from '@angular/common/http'
import { Observable } from 'rxjs'
import { Inject, Injectable, inject } from '@angular/core'
import { Usuario } from '../../../modelos/usuario.modelo';

Injectable({
    providedIn: "root"
})
export class LoginServico {

    public baseUrl: string;

    constructor(private http: HttpClient, @Inject("BASE_URL") baseUrl: string) {
        this.baseUrl = baseUrl;
    }

    entrar(email:string, senha: string): Observable<Usuario> {
        var headers = new HttpHeaders().set('x-requested-width', 'XMLHttpRequest');

        var usuario ={
            email,
            senha
        }

        return this.http.post<Usuario>(`${this.baseUrl}/api/Usuario/Entrar`, usuario , {headers})
    }

}