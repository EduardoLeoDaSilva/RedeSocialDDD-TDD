using System;
using System.Collections.Generic;
using System.Text;
using RedeSocial_DDD_TDD.Dominio.Entidades;
using RedeSocial_DDD_TDD.DominioTest.Likes;

namespace RedeSocial_DDD_TDD.DominioTest.Builders
{
    public class LikeBuilder
    {
        private Usuario _usuario;
        private List<LikePostagem> _likePostagens;

        private LikeBuilder()
        {
            _usuario = UsuarioBuilder.Novo().Build();
            _likePostagens = new List<LikePostagem> {new LikePostagem(1,2,new Like(_usuario , new List<LikePostagem>()), PostagemBuilder.Novo().Build())};
        }

        public static LikeBuilder Novo()
        {
            return new LikeBuilder();
        }

        public LikeBuilder ComUsuario( Usuario usuario)
        {
            _usuario = usuario;
            return this;
        }

        public LikeBuilder ComPostagens(List<LikePostagem> likePostagens)
        {
            _likePostagens = likePostagens;
            return this;
        }

        public Like Build()
        {
            return new Like(_usuario, _likePostagens);
        }
    }
}
