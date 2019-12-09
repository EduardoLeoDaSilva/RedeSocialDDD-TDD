import { Component, OnInit, Input, Inject } from '@angular/core';
import { Comentario } from 'src/app/modelos/comentario.modelo';

@Component({
    selector: 'coment-tag',
    templateUrl: 'comentario.component.html',
    styleUrls: ['comentario.component.css']
})

export class ComentarioComponent implements OnInit {

    @Input("comentario") comentario: Comentario
    public endPointFoto: string;
    constructor(@Inject("BASE_URL") private baseUrl: string) { }

    ngOnInit() {
        debugger;
        this.endPointFoto = `${this.baseUrl}/api/Usuario/ObterFoto?id=${this.comentario.usuario.id}`
     }

    

}