import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  
  title = 'app';
  public estaLogado: boolean;

  ngOnInit(): void {

    
  }

  verificarLogin():boolean{
    var estaAutenticado = sessionStorage.getItem("autenticado");
    this.estaLogado = estaAutenticado == '1' ? true:false;
    return this.estaLogado;
  }

}
