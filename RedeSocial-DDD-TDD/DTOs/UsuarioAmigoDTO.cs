using System.Collections.Generic;

namespace RedeSocial_DDD_TDD.DTOs
{
    public class UsuarioAmigoDTO : BaseDTO
    {
        public UsuarioDTO Usuario { get;  set; }
        public List<UsuarioDTO> Amigos { get;  set; }
    }
}