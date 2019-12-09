import { Component, OnInit, Input, Inject } from '@angular/core';

@Component({
    selector: 'carrossel',
    templateUrl: 'carrossel.component.html',
    styleUrls: ['carrossel.component.css']
})

export class CarrosselComponent implements OnInit {
    @Input('fotos') fotos: Array<any>

    constructor(@Inject('BASE_URL') private baseUrl: string) { }

    ngOnInit() {
        var listaAux = new Array<any>();
        var i = 0;
        this.fotos.forEach(element => {
            if (i == 0) 
                element.estado = "active"
             else 
                element.estado = ""
            listaAux.push(element);
            i++;

        });
        debugger;
    }
}