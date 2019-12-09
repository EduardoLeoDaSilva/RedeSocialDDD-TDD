import  { Component, OnInit } from '@angular/core';
import {FormGroup, FormBuilder} from '@angular/forms'
import 'bootstrap'
import {Router} from '@angular/router'
import { LoginServico } from '../servicos/usuario/login/login.servico';

@Component({
    selector: 'login-tag',
    styleUrls: ['login.component.css'],
    templateUrl: 'login.component.html'
})
export class LoginComponent implements OnInit {

    public email: string;
    public senha: string;
    public formLogin: FormGroup;

    constructor(private fb: FormBuilder, private servicoLogin: LoginServico, private router: Router) { 
        
    }

    ngOnInit() {
        this.formLogin = this.fb.group({
            emailCampo: [''],
            senhaCampo: ['']
        });
     }

    get emailCampo (){
        return this.formLogin.get('emailCampo');
    }

    get senhaCampo(){
        return this.formLogin.get('senhaCampo');
    }

     entrar():void{ 
         this.email = this.emailCampo.value;
         this.senha = this.senhaCampo.value;
         this.servicoLogin.entrar(this.email,this.senha).subscribe(
             data => {
                 sessionStorage.setItem("usuario", JSON.stringify(data));
                 sessionStorage.setItem("autenticado", "1");
                this.router.navigate(["home"])
             },
             err => {
                 console.log(err.error)
             }
         )

     }

}