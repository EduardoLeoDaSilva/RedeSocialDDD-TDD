import { Component, OnInit, ElementRef, Renderer2 } from '@angular/core';
import { PostagemServico } from 'src/app/servicos/postagem/postagem.servico';
import { Postagem } from 'src/app/modelos/postagem.modelo';
import { Usuario } from 'src/app/modelos/usuario.modelo';
import { PostagemLikeSignalR } from 'src/app/servicos/signalR/postagemLike.servicoSignalR';
import { LikeServico } from 'src/app/servicos/like/like.servico';

@Component({
    selector: 'home2',
    templateUrl: 'home2.component.html',
    styleUrls: ['home2.component.css']
})

export class HomeComponent2 implements OnInit {
    public listaPostagens: Array<Postagem>
    public usuario: Usuario
    public formComentarioClicado: boolean = false

    constructor(private postagemServico: PostagemServico, private el: ElementRef, private rd: Renderer2, private postagemLikeSingalR: PostagemLikeSignalR, private likeServico: LikeServico) { }

    ngOnInit() { 
      this.usuario =   JSON.parse(sessionStorage.getItem("usuario"))
        this.postagemServico.obterTodas().subscribe(
            data => {
                debugger;
                   this.listaPostagens = data;
            },
            err => {
                 console.log(err.error)
            }
        )

        this.postagemLikeSingalR.startConnection();

        this.postagemLikeSingalR._hubConnection.on('like', (data) => {
            var likeQuant = this.el.nativeElement.querySelector(`span[idSpan][idSpan="${data.id}"`);

            debugger;
            likeQuant.innerText = data.likePostagens != null ? data.likePostagens.length: "0"
        });

    }

    abrirFormPostagem(){
        var postagemForm=  this.el.nativeElement.querySelector("div[postagemForm]");
        this.rd.addClass(postagemForm, "active")
    }

    like(item):void{
        debugger
        var userLogado = sessionStorage.getItem("usuario")
        item.usuario = JSON.parse(userLogado);
        this.likeServico.darLike(item).subscribe(
            data => {
              console.log(data)
              console.log(data)
              var likeQuant = this.el.nativeElement.querySelector(`span[idSpan][idSpan="${data.id}"`);

              debugger;
              likeQuant.innerText = data.likePostagens != null ? data.likePostagens.length: "0"
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