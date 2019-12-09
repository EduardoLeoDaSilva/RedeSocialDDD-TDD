using System;
using System.Collections.Generic;
using System.Text;

namespace RedeSocial_DDD_TDD.Dominio.Entidades
{
    public class Foto : EntidadeBase
    {
        public byte[] Imagem { get; private set; }      
        public string Nome { get; private set; }

        public Usuario Usuario { get; private set; }


        private Foto()
        {
            
        }

        public Foto(byte[] imagem, string nome, Usuario usuario)
        {
            Imagem = imagem;
            Nome = nome;
            Usuario = usuario;
        }

        public void SetarImagem(byte[] image)
        {
            this.Imagem = image;
        }

        public void SetarNome(string nome)
        {
            this.Nome = nome;
        }

        public void SetarUsuario(Usuario usuario)
        {
            this.Usuario = usuario;
        }
    }
}
