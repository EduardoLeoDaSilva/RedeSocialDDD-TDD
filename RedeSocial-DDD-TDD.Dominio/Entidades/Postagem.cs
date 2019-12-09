using System;
using System.Collections.Generic;
using RedeSocial_DDD_TDD.Dominio.Utils;

namespace RedeSocial_DDD_TDD.Dominio.Entidades
{
    public class Postagem : EntidadeBase
    {
        public Usuario Usuario { get; private set; }
        public string Texto { get; private set; }

        public List<LikePostagem> LikePostagens { get; set; }

        public DateTime DataPublicacao { get; private set; }

        public List<Foto> Fotos { get; private set; }

        public List<Comentario> Comentarios { get; private set; }

        private Postagem(DateTime dataPublicacao)
        {
            DataPublicacao = dataPublicacao;
        }

        public Postagem(Usuario usuario, string texto)
        {
            ValidadorRegra.Novo()
                .Quando(string.IsNullOrEmpty(texto) || texto.Length < 4,
                    "Texto da postagem inválido")
                .Quando(usuario == null,
                    "Usuário Invalido para a postagem").DispararExcecaoSeExistir();

            Usuario = usuario;
            Texto = texto;
            DataPublicacao = DateTime.Now;
        }

        public void SetarDataPublicacao(DateTime dataPublicacao)
        {
            this.DataPublicacao = dataPublicacao;
        }

        public void SetarFotos(List<Foto> fotos)
        {
            this.Fotos = fotos;
        }

        public void SetarComentarios(List<Comentario> comentarios)
        {
            this.Comentarios = comentarios;
        }
    }

}
