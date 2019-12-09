import { Component, OnInit, Inject, Renderer2, ElementRef, Input, ComponentRef, ComponentFactoryResolver, ComponentFactory, ViewChild, ViewContainerRef} from '@angular/core';
import { ComentarioServico } from 'src/app/servicos/comentario/comentario.servico';
import { Comentario } from 'src/app/modelos/comentario.modelo';
import { Usuario } from 'src/app/modelos/usuario.modelo';
import { Postagem } from 'src/app/modelos/postagem.modelo';
import { PostagemLikeSignalR } from 'src/app/servicos/signalR/postagemLike.servicoSignalR';
import { ComentarioComponent } from '../comentario/comentario.component';


@Component({
    selector: 'formComentario',
    templateUrl: 'formComentario.component.html',
    styleUrls: ['formComentario.component.css']
})

export class FormComentarioComponent implements OnInit {
    public usuario: Usuario 
    @Input('postagem') postagem: Postagem
    @ViewChild('comentarioNovo',{ read: ViewContainerRef}) container
    componentRef: ComponentRef<any>
    public comentarioParaEnviar: Comentario;
    constructor(private resolver: ComponentFactoryResolver ,@Inject("BASE_URL") private baseUrl: string,private comentarioServico: ComentarioServico, private el : ElementRef, private rd: Renderer2, private postagemSignalR: PostagemLikeSignalR) { }

    ngOnInit() { 
        debugger;
        var teste = sessionStorage.getItem("usuario");
        this.usuario = JSON.parse(sessionStorage.getItem("usuario"));
        this.comentarioParaEnviar = new Comentario(0,this.usuario, '', this.postagem);

      this.postagemSignalR.startConnection();
      this.postagemSignalR._hubConnection.on("comentar", (data)=> {
          debugger;
          var comentario = JSON.parse(data);

          this.criarElementoComentario2(comentario);
      })

    }

    enviarComentario():void{
        debugger
        this.comentarioServico.Comentar(this.comentarioParaEnviar).subscribe(
            response=> {
               console.log(response)
            },
            err => {
             console.log(err.error)
 
            }
        )
     }


     criarElementoComentario(comentario: Comentario){
         var elemtentoComentario = this.rd.createElement("coment-tag");
         var teste = this.el.nativeElement.parentElement;
         debugger;
         var postagem = this.el.nativeElement.parentElement.querySelector(`ul[idPostagem][idPostagem="${comentario.postagem.id}"]`);
         debugger;
         elemtentoComentario.innerHTML = `
             <li>
                 <div class="comment-list">
                     <div class="bg-img">
                         <img class="imgComentario" src="${this.baseUrl}/api/usuario/ObterFoto?id=${comentario.usuario.id}" alt="">
                     </div>
                     <div class="comment">
                         <h3>${comentario.usuario.nome}</h3>
                         <span><img src="images/clock.png" alt=""> 3 min ago</span>
                         <p>${comentario.texto} </p>
                         <a href="#" title="" class="active"><i class="fa fa-reply-all"></i>Reply</a>
                     </div>
                 </div>
                 <!--comment-list end-->
             </li>`


     this.rd.appendChild(postagem,elemtentoComentario );
     }

    criarElementoComentario2(comentario: Comentario){
        var postagem = this.el.nativeElement.parentElement.querySelector(`ul[idPostagem][idPostagem="${comentario.postagem.id}"]`);
        this.rd.appendChild(postagem, this.container.element.nativeElement)
        const factory: ComponentFactory<any> = this.resolver.resolveComponentFactory(ComentarioComponent);
        this.componentRef = this.container.createComponent(factory);
        this.componentRef.instance.comentario = comentario;
        
    }
 

}