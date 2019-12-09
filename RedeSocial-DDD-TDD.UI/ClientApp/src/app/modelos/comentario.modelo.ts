import { Usuario } from "./usuario.modelo";
import { Postagem } from "./postagem.modelo";

export class Comentario{
    id: number;
    usuario: Usuario;
    texto: string;
    postagem: Postagem;


    
    constructor(id: number,usuario:Usuario,texto: string, postagem: Postagem){
        this.usuario = usuario;
        this.postagem = postagem;
        this.texto = texto;
        this.id = id;
    }

}