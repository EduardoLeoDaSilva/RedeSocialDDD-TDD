using System.Collections.Generic;
using System.Linq;
using RedeSocial_DDD_TDD.Dominio.Utils;

namespace RedeSocial_DDD_TDD.Dominio.Entidades
{
    public class Perfil : EntidadeBase
    {
        public Usuario Usuario { get; private set; }
        public string Interesse { get; private set; }

        private Perfil()
        {
                
        }
        public Perfil(Usuario usuario, string interesse)
        {
            ValidadorRegra.Novo()
                .Quando(usuario == null,
                    "Usuario relacionado com esse perfil é inválido")
                .Quando(string.IsNullOrEmpty(interesse),
                    "Interesse inválido").DispararExcecaoSeExistir();

            Usuario = usuario;
            Interesse = interesse;
        }
    }
}