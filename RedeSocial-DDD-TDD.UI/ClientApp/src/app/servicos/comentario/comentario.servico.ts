import { Inject, Injectable } from "@angular/core"
import { HttpClient, HttpHeaders } from "@angular/common/http"
import { Observable } from "rxjs"
import { Comentario } from "src/app/modelos/comentario.modelo";

@Injectable({
    providedIn: "root"
})
export class ComentarioServico {

    public baseUrl: string;

    constructor(private http: HttpClient, @Inject("BASE_URL") baseUrl: string) {
        this.baseUrl = baseUrl;
    };


    Comentar(comentario: Comentario):Observable<Comentario>{
        const headers = new HttpHeaders().set('content-type', 'application/json');


        var body ={
            usuario: comentario.usuario,
            texto: comentario.texto,
            postagem: comentario.postagem
        }

        return this.http.post<Comentario>(`https://localhost:44376/api/Comentario/Comentar`, body, {headers})
    }

    DeletarComentario(comentario: Comentario): Observable<string>{
        const headers = new HttpHeaders().set('content-type', 'application/json');
        var body ={
            usuario: comentario.usuario,
            texto: comentario.texto,
            postagem: comentario.postagem
        }
        return this.http.post<string>(`${this.baseUrl}/api/Comentario/Deletar`, body, {headers})

    }

}