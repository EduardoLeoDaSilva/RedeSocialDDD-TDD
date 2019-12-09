import {HttpClient, HttpHeaders} from '@angular/common/http'
import {Injectable, Inject} from '@angular/core'
import {Observable} from 'rxjs'
import { Postagem } from '../../modelos/postagem.modelo';
import { Usuario } from '../../modelos/usuario.modelo';
import { Like } from '../../modelos/like.modelo';


@Injectable({
    providedIn: "root"
})
export class LikeServico{
   
     public baseURL: string;

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string){
     this.baseURL = baseUrl;
    }

    darLike(postagem:Postagem):Observable<Like>{

        const headers = new HttpHeaders().set("content-type", "application/json").set('x-requested-width', 'XMLHttpRequest');
        
        var body = {
           id:postagem.id,
           usuario : postagem.usuario,
           texto : postagem.texto,
           likePostagens: postagem.likePostagens
        }

        return this.http.post<Like>(`https://localhost:44376/api/PostagemLike/DarLike`, body, {headers})

    }
}