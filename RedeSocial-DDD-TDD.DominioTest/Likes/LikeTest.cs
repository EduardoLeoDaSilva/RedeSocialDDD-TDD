using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ExpectedObjects;
using RedeSocial_DDD_TDD.Dominio.Entidades;
using RedeSocial_DDD_TDD.Dominio.Utils.Excecoes;
using RedeSocial_DDD_TDD.DominioTest.Builders;
using RedeSocial_DDD_TDD.DominioTest.Extencoes;
using Xunit;

namespace RedeSocial_DDD_TDD.DominioTest.Likes
{
    public class LikeTest
    {
        [Fact]
        public void DeveCriarLikes()
        {
            var likeEsperado = new
            {
                Usuario = UsuarioBuilder.Novo().Build(),
                LikePostagens = new List<LikePostagem>()
            };

            var like = new Like(likeEsperado.Usuario, new List<LikePostagem>());

            likeEsperado.ToExpectedObject().ShouldMatch(like);

        }

        [Fact]
        public void NaoDeveUsuarioSerInvalido()
        {
            Usuario usuario = null;

            Assert.Throws<EntitadeExcecao>(() => LikeBuilder.Novo().ComUsuario(usuario).Build()).ComMensagem("Usuario inválido para o like");
        }

        [Fact]
        public void NaoDevePostagemSerInvalida()
        {
            List<LikePostagem> listaPostagensInvalidas = null;

            Assert.Throws<EntitadeExcecao>(() => LikeBuilder.Novo().ComPostagens(listaPostagensInvalidas).Build()).ComMensagem("Há uma ou mais postagens inválidas");

        }


    }
}
