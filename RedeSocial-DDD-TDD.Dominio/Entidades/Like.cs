using System.Collections.Generic;
using System.Linq;
using RedeSocial_DDD_TDD.Dominio.Utils;

namespace RedeSocial_DDD_TDD.Dominio.Entidades
{
    public class Like : EntidadeBase
    {
        public Usuario Usuario { get; private set; }
        public List<LikePostagem> LikePostagens { get; set; }

        private Like()
        {
                
        }

        public Like(Usuario usuario, List<LikePostagem> likePostagens)
        {

            ValidadorRegra.Novo().Quando(usuario == null, "Usuario inválido para o like")
                .Quando(likePostagens == null, "Há uma ou mais postagens inválidas")
                .Quando(likePostagens != null && likePostagens.Any(x => x == null), "Há uma ou mais postagens inválidas").DispararExcecaoSeExistir();

            Usuario = usuario;
            LikePostagens = likePostagens;
        }
    }
}