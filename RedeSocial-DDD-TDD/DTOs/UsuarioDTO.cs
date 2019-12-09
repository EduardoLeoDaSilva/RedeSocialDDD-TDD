using System;
using Microsoft.AspNetCore.Http;

namespace RedeSocial_DDD_TDD.DTOs
{
    public class UsuarioDTO : BaseDTO
    {
        public string Nome { get;  set; }
        public string Email { get;  set; }
        public DateTime Nascimento { get;  set; }
        public string Senha { get;  set; }
        public int Idade { get;  set; }

        public IFormFile FotoPerfil { get; set; }

        public UsuarioDTO()
        {
            
        }

        public UsuarioDTO(string nome, string email, DateTime nascimento, string senha, int idade, IFormFile fotoPerfil)
        {
            Nome = nome;
            Email = email;
            Nascimento = nascimento;
            Senha = senha;
            Idade = idade;
            FotoPerfil = fotoPerfil;
        }
    }
}