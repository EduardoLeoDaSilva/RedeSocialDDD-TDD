import {HttpClient, HttpHeaders} from '@angular/common/http'
import {Inject, Injectable} from '@angular/core'
import {Observable} from 'rxjs'
import { Usuario } from '../../../modelos/usuario.modelo';


Injectable({
    providedIn: "root"
})
export class CadastroServico{
  
    public baseUrl: string;

    constructor(private http: HttpClient, @Inject("BASE_URL") baseUrl:string){
        this.baseUrl = baseUrl;
    }


    public  Cadastrar(usuario: Usuario) : Observable<Usuario>{


            var form = new FormData();
            form.append('nome', usuario.nome)
            form.append('email', usuario.email)
            form.append('senha', usuario.senha)
            form.append('nascimento', usuario.nascimento)
            form.append('fotoPerfil', usuario.fotoPerfil)
            

           return this.http.post<Usuario>(`${this.baseUrl}/api/Usuario/Cadastrar`, form);

    }
}