using System.Collections.Generic;
using System.Linq;
using RedeSocial_DDD_TDD.Dominio.Utils;

namespace RedeSocial_DDD_TDD.Dominio.Entidades
{
    public class UsuarioAmigo: EntidadeBase
    {
        public Usuario Usuario { get; private set; }
        public List<Usuario> Amigos { get; private set; }


        private UsuarioAmigo()
        {
            
        }

        public UsuarioAmigo(Usuario usuario, List<Usuario> amigos)
        {

            ValidadorRegra.Novo().Quando(usuario == null, "O usuario é nulo")
                .Quando(amigos !=  null && ExisteAmigosDuplicados(amigos),
                    "Lista amigos com duplicidade")
                .Quando(usuario != null && usuario != null && amigos.Any(x => x.Email.Equals(usuario.Email) ==true),
                    "Usuario está se adicionando na própria  lista amigo").DispararExcecaoSeExistir();

            Usuario = usuario;
            Amigos = amigos;
        }

        private bool ExisteAmigosDuplicados(List<Usuario> listaAmigos)
        {
            var listaRepetidos = new List<string>();
            var isEmailDuplicado = false;
            foreach (var item in listaAmigos)
            {
                var usuario = listaAmigos.FirstOrDefault(x => x.Email == item.Email);
                if (!listaRepetidos.Contains(usuario.Email))
                {
                    listaRepetidos.Add(usuario.Email);
                }
                else
                {
                    isEmailDuplicado = true;
                }
            }
            return isEmailDuplicado;
            //throw  new NotImplementedException();
        }
    }
}