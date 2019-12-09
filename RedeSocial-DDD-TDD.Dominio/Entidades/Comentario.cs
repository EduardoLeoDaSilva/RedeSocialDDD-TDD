using System;
using System.Collections.Generic;
using System.Text;
using RedeSocial_DDD_TDD.Dominio.Utils;

namespace RedeSocial_DDD_TDD.Dominio.Entidades
{
    public class Comentario : EntidadeBase
    {
        public Usuario Usuario { get;private set; }
        public string Texto { get; private set; }

        public Postagem Postagem { get; private set; }

        private Comentario()
        {
            
        }

        public Comentario(Usuario usuario, string texto, Postagem postagem)
        {

            ValidadorRegra.Novo().Quando(usuario == null, "Usuário é nulo")
                .Quando(string.IsNullOrEmpty(texto), "Texto é inválido")
                .Quando(postagem == null, "Postagem é nula");

            Usuario = usuario;
            Texto = texto;
            Postagem = postagem;
        }
    }
}
