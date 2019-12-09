import { Component, OnInit, Input,Renderer2, ElementRef, Inject, ComponentRef,ComponentFactoryResolver, ViewContainerRef, TemplateRef, ChangeDetectorRef, ViewChild, Output,  EventEmitter, ComponentFactory  } from '@angular/core';
import { FormBuilder,FormGroup, Validators  } from '@angular/forms';
import { Postagem } from 'src/app/modelos/postagem.modelo';
import { Usuario } from 'src/app/modelos/usuario.modelo';
import {BrowserModule} from '@angular/platform-browser';
import { PostagemServico } from 'src/app/servicos/postagem/postagem.servico';
import { PostagemLikeSignalR } from 'src/app/servicos/signalR/postagemLike.servicoSignalR';
import { Postagem2Component } from '../postagem/postagem2.component';


@Component({
    selector: 'form-postagem2',
    templateUrl: 'formPostagem2.component.html',
    styleUrls: ['formPostagem2.component.html']
})

export class FormPostagem2Component implements OnInit {
    @Input("ativo") ativo: boolean;
    @ViewChild("postagemComponent",{ read : ViewContainerRef}) container;


    componentRef: ComponentRef<any>;
    public classeParaMostrarElemento: string;
    public formPostagem: FormGroup
    public usuario: Usuario
    public fotos: FileList;
    public baseUrl: string
    public formComentarioClicado: boolean = false

    constructor(private resolver: ComponentFactoryResolver, @Inject('BASE_URL') baseUrl: string,private el: ElementRef ,private rd : Renderer2, private fb: FormBuilder, private postagemServico: PostagemServico, private postagemLikeSingalR : PostagemLikeSignalR) {
         this.baseUrl = baseUrl;
     }

    ngOnInit() { 

        this.criarReactiveFormPostagem();
        this.usuario = JSON.parse(sessionStorage.getItem("usuario"));

        if(this.ativo)
           this.classeParaMostrarElemento = "active"

           this.postagemLikeSingalR.startConnection();
           
           this.postagemLikeSingalR._hubConnection.on('teste', (data)=>{
               debugger;
                 var postagem = new Postagem(); Object.assign(postagem, data);
                 //this.criarPostagemElemento(postagem);
                 this.criarPostagemElemento(postagem);
           });

    }


    private criarReactiveFormPostagem(){
        this.formPostagem = this.fb.group({
            texto: ['',[Validators.required]]
        });
    }

    //getter campos Reactive forms

    get texto(){
        return this.formPostagem.get("texto");
    }

    fecharFormPostagem(evento){
        var formPostagem = evento.target.parentElement.parentElement.parentElement.parentElement.parentElement.parentElement.parentElement
         this.rd.removeClass(formPostagem, "active")
    }

    enviarPostagem(){
        var postagem = new Postagem();

        postagem.texto = this.texto.value;
        postagem.usuario = this.usuario;

        this.postagemServico.enviarPostagem(postagem, this.fotos).subscribe(
            data => {
                   console.log("Criado")
            },
            err => {
                console.log(err.error)
            }
        )

    }
    
    onChangeFotos(evento):void{
        this.fotos = evento.target.files;
        debugger;
    }

    mostrarFormComentario(): void {
        if (this.formComentarioClicado == false)
            this.formComentarioClicado = true
        else
            this.formComentarioClicado = false;
    
    }
    criarPostagemElemento(postagem:any){
        var elementoPai = this.el.nativeElement.parentElement.querySelector('.posts-section')
        this.rd.appendChild(elementoPai, this.container.element.nativeElement);
        const factory: ComponentFactory<any> = this.resolver.resolveComponentFactory(Postagem2Component);
        this.componentRef = this.container.createComponent(factory);
        this.componentRef.instance.postagem = postagem;
     // this.componentRef.instance.output.subscribe(event => console.log(event))
    }
}