using System;
using System.Collections.Generic;
using System.Text;
using Bogus;
using Bogus.DataSets;
using ExpectedObjects;
using RedeSocial_DDD_TDD.Dominio.Entidades;
using RedeSocial_DDD_TDD.Dominio.Utils.Excecoes;
using RedeSocial_DDD_TDD.DominioTest.Builders;
using RedeSocial_DDD_TDD.DominioTest.Extencoes;
using Xunit;

namespace RedeSocial_DDD_TDD.DominioTest.Postagens
{
    public class PostagemTest
    {
        private readonly Faker _faker;
        private readonly Postagem _postagem;

        public PostagemTest()
        {
            _faker = new Faker();
            _postagem = new Postagem(UsuarioBuilder.Novo().Build(), _faker.Lorem.Paragraph(3));
        }

        [Fact]
        public void DeveCriarPostagem()
        {
            var postagemEsperada = new
            {
                Usuario = UsuarioBuilder.Novo().Build(),
                Texto = _faker.Lorem.Text()
            };

            var postagem = new Postagem(postagemEsperada.Usuario, postagemEsperada.Texto);

            postagemEsperada.ToExpectedObject().ShouldMatch(postagem);

        }

        [Theory]
        [InlineData("Tex")]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveTerTextoInvalido(string textoInvalido)
        {
            Assert.Throws<EntitadeExcecao>(() => PostagemBuilder.Novo().ComTexto(textoInvalido).Build()).ComMensagem("Texto da postagem inválido");
        }

        [Fact]
        public void NaoDeveTerUsuarioNulo()
        {
            Usuario usuario = null;
            Assert.Throws<EntitadeExcecao>(() => PostagemBuilder.Novo().ComUsuario(usuario).Build()).ComMensagem("Usuário Invalido para a postagem");
        }

    }
}
