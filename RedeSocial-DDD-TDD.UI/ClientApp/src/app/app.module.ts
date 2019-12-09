import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { LoginComponent } from './login/login.component';
import { CadastroComponent } from './cadastro/cadastro.component';
import { CadastroServico } from './servicos/usuario/cadastro/cadastro.servico';
import { LoginServico } from './servicos/usuario/login/login.servico';
import { GuardaRotas } from './autorizacao/guardaRotas';
import { LikeServico } from './servicos/like/like.servico';
import { PostagemLikeSignalR } from './servicos/signalR/postagemLike.servicoSignalR';
import { HomeComponent2 } from './tudoNovo/home/home2.component';
import { Postagem2Component } from './tudoNovo/shared/postagem/postagem2.component';
import { Info2Component } from './tudoNovo/shared/infoPerfil/infoPerfil2.component';
import { TopTopicos2Component } from './tudoNovo/shared/topTopicos/topTopicos2.component';
import { ListaParaFollow2Component } from './tudoNovo/listaPessoasParaSeguir/listaPessoasParaSeguir.component';
import { NavBar2 } from './tudoNovo/nav-bar/nav-bar2.component';
import { FormPostagem2Component } from './tudoNovo/shared/formPostagem/formPostagem2.component';
import { ComentarioComponent } from './tudoNovo/shared/comentario/comentario.component';
import { ComentarioServico } from './servicos/comentario/comentario.servico';
import { FormComentarioComponent } from './tudoNovo/shared/formComentario/formComentario.component';
import { UsuarioSeguidorServico } from './servicos/usuarioSeguidor/usuarioSeguidor.servico';
import { CarrosselComponent } from './tudoNovo/shared/carrossel/carrossel.component';
@NgModule({
  declarations: [
    AppComponent,
    CounterComponent,
    FetchDataComponent,
    LoginComponent,
    CadastroComponent,
    HomeComponent2,
    Postagem2Component,
    Info2Component,
    TopTopicos2Component,
    ListaParaFollow2Component,
    NavBar2,
    FormPostagem2Component,
    ComentarioComponent,
    FormComentarioComponent,
    CarrosselComponent

  ],
  entryComponents:[Postagem2Component,ComentarioComponent],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: LoginComponent },
      { path: 'login', component: LoginComponent },
      { path: 'cadastrar', component: CadastroComponent },
      {path: 'home', component: HomeComponent2},
      {path: 'navbar', component: NavBar2},
      {path: 'formPostagem', component: FormPostagem2Component},
    ])
  ],
  providers: [CadastroServico, {provide: "BASE_URL", useValue: "https://localhost:5001"  },LoginServico, GuardaRotas, LikeServico, PostagemLikeSignalR, ComentarioServico,UsuarioSeguidorServico],
  bootstrap: [AppComponent]
})
export class AppModule { }
