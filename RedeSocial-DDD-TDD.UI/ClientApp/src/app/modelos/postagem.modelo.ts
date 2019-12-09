import { Usuario } from "./usuario.modelo"
import { Comentario } from "./comentario.modelo";

export class Postagem{
    id:number;
    usuario: Usuario;
    texto: string;
    likePostagens: any;
    dataPublicacao: string;
    comentarios: Array<Comentario>;
    fotos: any;
}