using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using RedeSocial_DDD_TDD.Dominio.Entidades;
using RedeSocial_DDD_TDD.Dominio.Interfaces.Repositories;
using RedeSocial_DDD_TDD.Dominio.Servicos;
using RedeSocial_DDD_TDD.Dominio.Utils.Excecoes;
using RedeSocial_DDD_TDD.DominioTest.Builders;
using RedeSocial_DDD_TDD.DominioTest.Extencoes;
using Xunit;

namespace RedeSocial_DDD_TDD.DominioTest.Postagens
{
    public class PostagemServicoTest
    {
        private readonly Mock<IPostagemRepositorio> _postagemRepositorio;
        private readonly PostagemServico _postagemServico;

        public PostagemServicoTest()
        {
            _postagemRepositorio = new Mock<IPostagemRepositorio>();
            _postagemServico = new PostagemServico(_postagemRepositorio.Object);
        }

        [Fact]
        public void DeveSalvarPostagem()
        {
            var postagemParaSerSalvo = PostagemBuilder.Novo().Build();


           _postagemServico.Salvar(postagemParaSerSalvo);

            _postagemRepositorio.Verify(x => x.Salvar(It.Is<Postagem>(t=> t.Usuario.Email == postagemParaSerSalvo.Usuario.Email)));

        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveTerEmailInvalido(string emailInvalido)
        {
            Assert.Throws<EntitadeExcecao>(() => _postagemServico.ObterPostagensPeloEmail(emailInvalido)).ComMensagem("Email inválido");
        }

        [Fact]
        public void DeveObterPostagensPorEmail()
        {
            string email = "eduardoleodasilva@gmail.com";

            var listaPostagem = new List<Postagem> ();

            _postagemRepositorio.Setup(x => x.ObterPostagensPeloEmail(email)).Returns(listaPostagem);

            Assert.True(_postagemServico.ObterPostagensPeloEmail(email) != null);
        }

    }
}
