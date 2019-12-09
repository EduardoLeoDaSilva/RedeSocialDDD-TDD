using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using RedeSocial_DDD_TDD.Dominio.Entidades;
using RedeSocial_DDD_TDD.Dominio.Interfaces.Repositories;
using RedeSocial_DDD_TDD.Dominio.Servicos;
using RedeSocial_DDD_TDD.Dominio.Utils.Excecoes;
using RedeSocial_DDD_TDD.DominioTest.Builders;
using RedeSocial_DDD_TDD.DominioTest.Extencoes;
using Xunit;

namespace RedeSocial_DDD_TDD.DominioTest.Likes
{
    public class LikeServicoTest
    {
        private readonly Mock<ILikeRepositorio> _likeRepositorioMock;
        private readonly LikeServico _likeServico;


        public LikeServicoTest()
        {
            _likeRepositorioMock = new Mock<ILikeRepositorio>();
           // _likeServico = new LikeServico(_likeRepositorioMock.Object);
        }

        [Fact]
        public void DeveSalvarLike()
        {
            var likeParaSalvar = LikeBuilder.Novo().Build();
            likeParaSalvar.LikePostagens.Clear();

            _likeRepositorioMock.Setup(x => x.ObterPorId(likeParaSalvar.Id)).Returns(likeParaSalvar);


            _likeServico.Salvar(likeParaSalvar);

            _likeRepositorioMock.Verify(x => x.Salvar(It.Is<Like>(t => t.Usuario.Id == likeParaSalvar.Usuario.Id)));

        }


        [Fact]
        public void NaoDeveTerLikeRepetidoParaMesmaPostagem()
        {
            var likeParaSalvar = LikeBuilder.Novo().Build();
            var likeParaRetorno = LikeBuilder.Novo().Build();

            likeParaSalvar.SetarId(0);
            likeParaRetorno.SetarId(0);
            likeParaSalvar.LikePostagens.Add(new LikePostagem(0, 2, likeParaSalvar, PostagemBuilder.Novo().Build()));
            likeParaRetorno.LikePostagens.Add(new LikePostagem(0, 2, likeParaSalvar, PostagemBuilder.Novo().Build()));
            
            _likeRepositorioMock.Setup(x => x.ObterPorId(likeParaSalvar.Id)).Returns(likeParaRetorno);
            Assert.Throws<EntitadeExcecao>(() => _likeServico.Salvar(likeParaSalvar)).ComMensagem("Não pode dar mais de um like para uma mesma postagem!");

        }

        [Fact]
        public void DeveRetornarLike()
        {
            var likeParaSalvar = LikeBuilder.Novo().Build();
            var likeParaRetorno = LikeBuilder.Novo().Build();

            likeParaSalvar.SetarId(0);
            likeParaRetorno.SetarId(0);
            likeParaSalvar.LikePostagens.Add(new LikePostagem(0, 2, likeParaSalvar, PostagemBuilder.Novo().Build()));
            likeParaRetorno.LikePostagens.Add(new LikePostagem(0, 2, likeParaSalvar, PostagemBuilder.Novo().Build()));

            _likeRepositorioMock.Setup(x => x.ObterPorId(likeParaSalvar.Id)).Returns(likeParaRetorno);
             
            Assert.True(_likeServico.JaFoiLiked(likeParaSalvar));


        }


    }
}
