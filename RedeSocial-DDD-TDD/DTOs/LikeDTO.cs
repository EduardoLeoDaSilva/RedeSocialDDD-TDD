using System.Collections.Generic;

namespace RedeSocial_DDD_TDD.DTOs
{
    public class LikeDTO  : BaseDTO
    {
        public LikeDTO()
        {
            
        }

        public LikeDTO(UsuarioDTO usuario, List<LikePostagemDTO> likePostagens)
        {
            Usuario = usuario;
            LikePostagens = likePostagens;
        }

        public UsuarioDTO Usuario { get;  set; }
        public List<LikePostagemDTO> LikePostagens { get; set; }
    }
}