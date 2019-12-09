using System;
using System.Text;
using Moq;
using RedeSocial_DDD_TDD.Dominio.Entidades;
using RedeSocial_DDD_TDD.Dominio.Interfaces.Repositories;
using RedeSocial_DDD_TDD.Dominio.Servicos;
using RedeSocial_DDD_TDD.Dominio.Utils.Excecoes;
using RedeSocial_DDD_TDD.DominioTest.Builders;
using RedeSocial_DDD_TDD.DominioTest.Extencoes;
using Xunit;

namespace RedeSocial_DDD_TDD.DominioTest.Usuarios
{
    public class UsuarioServicoTest
    {
        private readonly Mock<IUsuarioRepositorio> _usuarioRepositorioMock;
        private readonly  UsuarioServico _usuarioServico;


        public UsuarioServicoTest()
        {
            _usuarioRepositorioMock = new Mock<IUsuarioRepositorio>();
            _usuarioServico = new UsuarioServico(_usuarioRepositorioMock.Object);
        }

        [Fact]
        public void DeveSalvarUsuario()
        {

            var usuario = UsuarioBuilder.Novo().Build();
            Usuario usuarioNUlo = null;
            _usuarioServico.Salvar(usuario);

            _usuarioRepositorioMock.Setup(x => x.ObterPorEmail(usuario.Email)).Returns(usuarioNUlo);

            _usuarioRepositorioMock.Verify(x => x.Salvar(It.Is<Usuario>(t => t.Nome == usuario.Nome && t.Email == usuario.Email)) , Times.AtLeastOnce);

        }

        [Fact]
        public void NaoDeveSalvarSeUsuarioJaECadastrado()
        {


            var usuario = UsuarioBuilder.Novo().Build();

            _usuarioRepositorioMock.Setup(x => x.ObterPorEmail(usuario.Email)).Returns(usuario);

            Assert.Throws<EntitadeExcecao>(() => _usuarioServico.Salvar(usuario)).ComMensagem("Já existe usuário com esse email");

        }

        [Fact]
        public void DeveAtualizarUsuario()
        {


            var usuario = UsuarioBuilder.Novo().Build();
            _usuarioRepositorioMock.Setup(x => x.ObterPorEmail(usuario.Email)).Returns(usuario);

            _usuarioServico.Atualizar(usuario);
            
            _usuarioRepositorioMock.Verify(
                x => x.Atualizar(It.Is<Usuario>(t => t.Email == usuario.Email && t.Nome == usuario.Nome)),
                Times.AtLeastOnce);
        }

        [Fact]
        public void NaoDeveAtualizarQuandoUsuarioNaoExiste()
        {


            var usuarioParaSerAtualizado = UsuarioBuilder.Novo().Build();
            Usuario usuarioInexistente = null;

            _usuarioRepositorioMock.Setup(x => x.ObterPorEmail(usuarioParaSerAtualizado.Email))
                .Returns(usuarioInexistente);

            Assert.Throws<EntitadeExcecao>(() => _usuarioServico.Atualizar(usuarioParaSerAtualizado)).ComMensagem("Não existe esse usuário no sitesma");
        }

        [Fact]
        public void DeveEntrar()
        {


            string email = "eduardoleodasivla@gmail.com";
            string senha = "02121441";

            var usuarioLogado = UsuarioBuilder.Novo().ComEmail(email).ComSenha(senha).Build();

            _usuarioRepositorioMock.Setup(x => x.Entrar(email, senha)).Returns(usuarioLogado);

            _usuarioServico.Entrar(email, senha);

        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]

        public void NaoDeveEntrarEmailInvalido(string emailInvalido)
        {

            var senha = "02121441";



            Assert.Throws<EntitadeExcecao>(() => _usuarioServico.Entrar(emailInvalido, senha)).ComMensagem("Email Invalido");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void NaoDeveEntrarSenhaInvalida(string senhaInvalida)
        {

            var email = "eduardoleodasilva@gmail.com";
            Assert.Throws<EntitadeExcecao>(() => _usuarioServico.Entrar(email,senhaInvalida)).ComMensagem("Senha inválida");
        }
    }


    /////////////////////////////////////////////////////////
}
