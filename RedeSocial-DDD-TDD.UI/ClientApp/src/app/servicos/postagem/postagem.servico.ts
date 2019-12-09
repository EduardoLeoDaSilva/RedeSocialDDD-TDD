import { HttpClient, HttpHeaders } from '@angular/common/http'
import { Injectable, Inject } from '@angular/core'
import { Observable } from 'rxjs'
import { Postagem } from '../../modelos/postagem.modelo';
import { Usuario } from '../../modelos/usuario.modelo';



@Injectable({
    providedIn: "root"
})
export class PostagemServico {

    public baseURL: string;

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.baseURL = baseUrl;
    }

    enviarPostagem(postagem: Postagem, fotos: any): Observable<Postagem> {
        debugger;
        var formData = new FormData();
        var usuario = JSON.parse(sessionStorage.getItem("usuario"))
        formData.append("texto", postagem.texto)
        formData.append("usuario.id", JSON.stringify(usuario.id))
        debugger;
        // fotos. (element => {
        //     formData.append(`foto`, element)
        // });

        if (fotos != null) {
            for (let index = 0; index < fotos.length; index++) {
                formData.append(`fotos${index}`, fotos[index])
            }
        }
        const headers = new HttpHeaders().set("content-type", "application/json").set('x-requested-width', 'XMLHttpRequest');

        // var body = {
        //    texto : texto,
        //    usuario : usuario
        // }

        return this.http.post<Postagem>(`https://localhost:44376/api/PostagemLike/Postar`, formData)

    }

    obterTodas(): Observable<Postagem[]> {

        const headers = new HttpHeaders().set("content-type", "application/json").set('x-requested-width', 'XMLHttpRequest');
        return this.http.get<any>(`${this.baseURL}/api/Postagem`, { headers })
    }
}