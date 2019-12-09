import { Component, OnInit, Inject} from '@angular/core';
import { Usuario } from 'src/app/modelos/usuario.modelo';
import { UsuarioSeguidorServico } from 'src/app/servicos/usuarioSeguidor/usuarioSeguidor.servico';

@Component({
    selector: 'navbar2',
    templateUrl: 'nav-bar2.component.html',
    styleUrls: ['nav-bar2.component.css']
})

export class NavBar2 implements OnInit {
    public endPointFoto: string;
    public usuario: Usuario
    public pessoasSearch: string;
    public listaPessoas: Array<Usuario>
    constructor(private usuarioSeguidorServico:UsuarioSeguidorServico,@Inject("BASE_URL") private baseURl:string ) { }

    ngOnInit() { 
        this.usuario = JSON.parse(sessionStorage.getItem("usuario"));
        this.endPointFoto = `${this.baseURl}/api/usuario/ObterFoto?id=${this.usuario.id}`
    }

    buscarAmigos():void{
        debugger;
         this.listaPessoas = new Array<Usuario>()
         this.usuarioSeguidorServico.buscarPessoas(this.pessoasSearch).subscribe(
             data => {
                 Object.assign(this.listaPessoas, data);
                 debugger
             },
             err => {
                 console.log(err.error)
             }

         )
    }
}