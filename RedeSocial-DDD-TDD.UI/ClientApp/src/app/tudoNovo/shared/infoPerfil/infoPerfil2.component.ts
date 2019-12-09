import  { Component, OnInit,Input, Inject } from '@angular/core';
import { Usuario } from 'src/app/modelos/usuario.modelo';

@Component({
    selector: 'info-perfil',
    templateUrl: 'infoPerfil2.component.html',
    styleUrls: ['infoPerfil2.component.css']
})

export class Info2Component implements OnInit {
    @Input("usuario") usuario: Usuario
    public baseUrl: string
    public endPointFoto: string;
    constructor(@Inject("BASE_URL") baseUrl: string) { 
        this.baseUrl =baseUrl;
    }

    ngOnInit() { 
        this.endPointFoto = `${this.baseUrl}/api/usuario/ObterFoto?id=${this.usuario.id}`
    }
}