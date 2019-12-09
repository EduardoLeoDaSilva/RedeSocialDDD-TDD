import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, Validators} from '@angular/forms'
import { Usuario } from '../modelos/usuario.modelo';
import { CadastroServico } from '../servicos/usuario/cadastro/cadastro.servico';



@Component({
    selector: 'cadastro',
    styleUrls:['cadastro.component.css'],
    templateUrl: 'cadastro.component.html'
})

export class CadastroComponent implements OnInit {
    public usuarioForm : FormGroup;
    public usuario: Usuario;
    
    constructor(private cadastroServico: CadastroServico) { }

    ngOnInit() {
        this.usuario = new Usuario();
           this.usuarioForm = new FormGroup({
               nome: new FormControl(this.usuario.nome,[Validators.required, Validators.minLength(4), Validators.maxLength(20)]),
               email: new FormControl(this.usuario.email, [Validators.required, Validators.email]),
               senha: new FormControl(this.usuario.senha, [Validators.required,Validators.required, Validators.minLength(5)]),
               nascimento: new FormControl(this.usuario.nascimento,[Validators.required, Validators.minLength(4)])
           });
     }

get nome(){
return this.usuarioForm.get('nome')
}

get email(){
    return this.usuarioForm.get('email')
}

get senha(){
    return this.usuarioForm.get('senha')
}

get nascimento(){
    return this.usuarioForm.get('nascimento')
}

formValido():boolean{     
    var valido:boolean;
          valido = this.usuarioForm.invalid
          return ! valido;
}
     cadastrar():void{
         debugger;
         this.usuario = Object.assign(this.usuario, this.usuarioForm.value)
            debugger
        this.cadastroServico.Cadastrar(this.usuario).subscribe(
            data => {
                   console.log(data);
            },
            err => {
                console.log(err.error)
            }
        )


         console.log( this.usuario);
     }

     verificarFoto(evento){
         debugger
         this.usuario.fotoPerfil = evento.target.files[0];
     }
}