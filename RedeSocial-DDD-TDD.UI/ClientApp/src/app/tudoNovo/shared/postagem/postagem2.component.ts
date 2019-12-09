import { Component, OnInit, Input, ElementRef, Inject } from '@angular/core';
import { Postagem } from 'src/app/modelos/postagem.modelo';
import { LikeServico } from 'src/app/servicos/like/like.servico';
import { PostagemLikeSignalR } from 'src/app/servicos/signalR/postagemLike.servicoSignalR';
import 'bootstrap'

@Component({
    selector: 'post',
    templateUrl: 'postagem2.component.html',
    styleUrls: ['postagem2.component.css']
})

export class Postagem2Component implements OnInit {
    @Input("postagem") postagem: Postagem
    public endPointFoto: string
    public formComentarioClicado: boolean = false
    public quantLikes: number
    public temFoto: boolean = false;

    constructor(@Inject('BASE_URL') private baseUrl: string, private likeServico: LikeServico, private el: ElementRef, private postagemLikeSignalR: PostagemLikeSignalR) {
    }

    ngOnInit() {
        this.temFoto = this.postagem.fotos!= null ? true: false;

        if(this.postagem.likePostagens == null)
         this.quantLikes = 0
         else
           this.quantLikes = this.postagem.likePostagens.length
           
        this.endPointFoto = `${this.baseUrl}/api/Usuario/ObterFoto?id=${this.postagem.usuario.id}`;

        this.postagemLikeSignalR.startConnection();

        this.postagemLikeSignalR._hubConnection.on('like', (data) => {
            var likeQuant = this.el.nativeElement.querySelector(`span[idSpan][idSpan="${data.id}"`);
            likeQuant.innerText = data.likePostagens != null ? data.likePostagens.length : "0"
        })
    }

    like(item): void {
        debugger
        var userLogado = sessionStorage.getItem("usuario")
        item.usuario = JSON.parse(userLogado);
        this.likeServico.darLike(item).subscribe(
            data => {
                console.log(data)
                console.log(data)
                var likeQuant = this.el.nativeElement.querySelector(`span[idSpan][idSpan="${data.id}"`);

                debugger;
                likeQuant.innerText = data.likePostagens != null ? data.likePostagens.length : "0"
            },
            err => {
                console.log(err.error)
            }

        )
    }

    mostrarFormComentario(): void {
        if (this.formComentarioClicado == false)
            this.formComentarioClicado = true
        else
            this.formComentarioClicado = false;

    }


}