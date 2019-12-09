using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using RedeSocial_DDD_TDD.DTOs;

namespace RedeSocial_DDD_TDD.Aplicacao.DTOs
{
    public class FotoDTO : BaseDTO
    {
        public IFormFile Imagem { get; set; }
        public string Nome { get; set; }

        public UsuarioDTO Usuario { get; set; }

        public FotoDTO()
        {
            
        }

        public FotoDTO(IFormFile imagem, string nome, UsuarioDTO usuario)
        {
            Imagem = imagem;
            Nome = nome;
            Usuario = usuario;
        }
    }
}
