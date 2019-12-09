using System;
using System.Collections.Generic;
using RedeSocial_DDD_TDD.Aplicacao.DTOs;

namespace RedeSocial_DDD_TDD.DTOs
{
    public class PostagemDTO : BaseDTO
    {
        public UsuarioDTO Usuario { get;  set; }
        public string Texto { get;  set; }

        public List<LikePostagemDTO> LikePostagens { get; set; }

        public List<FotoDTO> Fotos { get;  set; }

        public string DataPublicacao { get; set; }
        public List<ComentarioDTO> Comentarios { get; set; }

        public PostagemDTO()
        {
            
        }

        public PostagemDTO(int id, UsuarioDTO usuario, string texto, List<LikePostagemDTO> likePostagens, string dataPublicacao, List<ComentarioDTO> comentarios, List<FotoDTO> fotos)
        {
            Usuario = usuario;
            Texto = texto;
            LikePostagens = likePostagens;
            DataPublicacao = dataPublicacao;
            Comentarios = comentarios;
            Fotos = fotos;
            Id = id;
        }

    }
}