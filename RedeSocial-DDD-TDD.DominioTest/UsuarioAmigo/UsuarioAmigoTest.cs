using RedeSocial_DDD_TDD.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using ExpectedObjects;
using RedeSocial_DDD_TDD.Dominio.Utils.Excecoes;
using RedeSocial_DDD_TDD.DominioTest.Builders;
using RedeSocial_DDD_TDD.DominioTest.Extencoes;
using Xunit;

namespace RedeSocial_DDD_TDD.DominioTest.UsuarioAmigo
{
    public class UsuarioAmigoTest
    {
        private readonly Dominio.Entidades.UsuarioAmigo _usuarioAmigoEsperado;

        public UsuarioAmigoTest()
        {
            _usuarioAmigoEsperado = new Dominio.Entidades.UsuarioAmigo(
                UsuarioBuilder.Novo().ComEmail("eduardo@gmail.com").Build(), new List<Usuario> { UsuarioBuilder.Novo().ComEmail("edu22@gmail.com").Build(), UsuarioBuilder.Novo().ComEmail("eduardoTeste@gmail.com").Build() });

        }

        [Fact]
        public void DeveCriarAmigoTest()
        {
            var usuarioAmigoEsperado = new
            {
                Usuario = UsuarioBuilder.Novo().Build(),
                Amigos = new List<Usuario> { UsuarioBuilder.Novo().ComEmail("email@teste1.com").Build(), UsuarioBuilder.Novo().ComEmail("email@teste2.com").Build() }
            };

            var usuarioAmigo = new Dominio.Entidades.UsuarioAmigo(usuarioAmigoEsperado.Usuario, usuarioAmigoEsperado.Amigos);


            usuarioAmigoEsperado.ToExpectedObject().ShouldMatch(usuarioAmigo);

        }

        [Fact]
        public void NaoDeveUsuarioSerNulo()
        {
            Usuario usuario = null;

            Assert.Throws<EntitadeExcecao>(() => new Dominio.Entidades.UsuarioAmigo(usuario, _usuarioAmigoEsperado.Amigos)).ComMensagem("O usuario é nulo");
        }

        [Fact]
        public void NaoDeveTerAmigosComEmailRepetido()
        {

            var amigos = _usuarioAmigoEsperado.Amigos;

            amigos.Add(UsuarioBuilder.Novo().ComEmail("edu22@gmail.com").Build());

            Assert.Throws<EntitadeExcecao>(() => new Dominio.Entidades.UsuarioAmigo(_usuarioAmigoEsperado.Usuario, amigos)).ComMensagem("Lista amigos com duplicidade");
        }

        [Fact]
        public void NaoDeveTerUsuarioNaSuaListaDeAmigosSeuProprioEmailComoUmAmigo()
        {

            var listaAmigos = _usuarioAmigoEsperado.Amigos;

            listaAmigos.Add(UsuarioBuilder.Novo().ComEmail("eduardo@gmail.com").Build());

            Assert.Throws<EntitadeExcecao>(() =>
                    new Dominio.Entidades.UsuarioAmigo(_usuarioAmigoEsperado.Usuario, listaAmigos)).ComMensagem("Usuario está se adicionando na própria  lista amigo");
        }

    }
}
