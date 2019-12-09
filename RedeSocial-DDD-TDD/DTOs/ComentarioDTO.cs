using System;
using System.Collections.Generic;
using System.Text;
using RedeSocial_DDD_TDD.DTOs;

namespace RedeSocial_DDD_TDD.Aplicacao.DTOs
{
    public class ComentarioDTO : BaseDTO
    {
        public UsuarioDTO Usuario { get;  set; }
        public string Texto { get; set; }

        public PostagemDTO Postagem { get;  set; }

        public ComentarioDTO()
        {
            
        }

        public ComentarioDTO(UsuarioDTO usuario, string texto, PostagemDTO postagem)
        {
            Usuario = usuario;
            Texto = texto;
            Postagem = postagem;
        }
    }
}
