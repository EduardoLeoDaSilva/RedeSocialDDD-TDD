using ExpectedObjects;
using RedeSocial_DDD_TDD.Dominio.Entidades;
using RedeSocial_DDD_TDD.DominioTest.Builders;
using RedeSocial_DDD_TDD.DominioTest.Extencoes;
using System;
using RedeSocial_DDD_TDD.Dominio.Utils.Excecoes;
using Xunit;

namespace RedeSocial_DDD_TDD.DominioTest.Usuarios
{
    public class UsuarioTest
    {
        private readonly Usuario _usuario;

        public UsuarioTest()
        {
            _usuario = new Usuario("Eduardo", "eduardoleodasilva@gmail.com", new DateTime(1994, 11, 30), "02121441");

        }

        [Fact]
        public void DeveCriarUsuario()
        {
            var usuarioEsperado = new
            {
                Nome = "Eduardo",
                Email = "eduardoleodasilva@gmail.com",
                Nascimento = new DateTime(1994, 11, 30),
                Senha = "02121441"
            };

            var usuario = new Usuario(usuarioEsperado.Nome, usuarioEsperado.Email, usuarioEsperado.Nascimento,
                usuarioEsperado.Senha);

            usuarioEsperado.ToExpectedObject().ShouldMatch(usuario);

        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveNomeSerInvalido(string nomeInvalido)
        {
            Assert.Throws<EntitadeExcecao>(() =>
                new Usuario(nomeInvalido, _usuario.Email, _usuario.Nascimento, _usuario.Senha)).ComMensagem("Nome inválido - Campo Vazio");
        }


        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveEmailEstarVazioOunulo(string emailInvalido)
        {
            Assert.Throws<EntitadeExcecao>(() =>
                new Usuario(_usuario.Nome, emailInvalido, _usuario.Nascimento, _usuario.Senha)).ComMensagem("Email inválido - Campo vazio");
        }

        [Fact]
        public void NaoDeveFormatoEmailEstarErrado()
        {
            var emailInvalido = "eduardo.com";

            Assert.Throws<EntitadeExcecao>(() => UsuarioBuilder.Novo().ComEmail(emailInvalido).Build()).ComMensagem("Formato email inválido");
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("1234")]
        public void NaoDeveSenhaSerInvalida(string senhaInvalida)
        {
            Assert.Throws<EntitadeExcecao>(() => UsuarioBuilder.Novo()
                    .ComSenha(senhaInvalida)
                    .Build())
                .ComMensagem("Senha inválida - Deve ter no minimo 5 caracteres");
        }

        [Fact]
        public void NaoDeveIdadeSerMenorQue18()
        {
            var nascimentoInvalido = new DateTime(2008,11,30);

            Assert.Throws<EntitadeExcecao>(() => UsuarioBuilder.Novo().ComNascimento(nascimentoInvalido).Build()).ComMensagem("Idade não permitida - Somente 18+");
        }


        [Fact]
        public void DeveCalcularIdade()
        {
            var nascimento = new DateTime(1994, 11, 30);
            var idadeEsperada = 25;

            var usuario = UsuarioBuilder.Novo().ComNascimento(nascimento).Build();
            var idadeCalculada = usuario.ObterIdade(usuario.Nascimento);


            Assert.Equal(idadeEsperada, idadeCalculada);
            }
        [Fact]
        public void NaoDeveTerNomeNaSenha()
        {
            var senhaInvalida = _usuario.Nome + "123123";


            Assert.Throws<EntitadeExcecao>(() => UsuarioBuilder.Novo().ComNome(_usuario.Nome).ComSenha(senhaInvalida).Build()).ComMensagem("Senha não pode conter seu nome");
        }
    }
}
