
import {Injectable} from "@angular/core"
import {HubConnection, HubConnectionBuilder} from "@aspnet/signalr"

@Injectable({
    providedIn: "root"
})
export class PostagemLikeSignalR{

    public _hubConnection : HubConnection
    startConnection(){
   this._hubConnection = new HubConnectionBuilder().withUrl("https://localhost:44376/feed").build();
    this._hubConnection.start().then(() => console.log("Connection started!")).catch(err => console.log("Erro ocorreu ao tentar realtime " + err));
    }

   
}