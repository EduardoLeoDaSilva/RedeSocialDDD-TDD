using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using RedeSocial_DDD_TDD.Dominio.Entidades;
using RedeSocial_DDD_TDD.DominioTest.Usuarios;

namespace RedeSocial_DDD_TDD.DominioTest.Builders
{
    public class UsuarioBuilder
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public DateTime Nascimento { get; private set; }
        public string Senha { get; private set; }


        private UsuarioBuilder()
        {
            Nome = "Eduardo";
            Email = "eduardo@gmail.com";
            Nascimento = new DateTime(1004,11,30);
            Senha = "02121441";

        }

        public static UsuarioBuilder Novo()
        {
            return new UsuarioBuilder();
        }

        public UsuarioBuilder ComNome(string Nome)
        {
            this.Nome = Nome;
            return this;
        }

        public UsuarioBuilder ComEmail(string email)
        {
            Email = email;
            return this;
        }

        public UsuarioBuilder ComNascimento(DateTime nascimento)
        {
            Nascimento = nascimento;
            return this;

        }

        public UsuarioBuilder ComSenha(string senha)
        {
            Senha =senha;
            return this;
        }


        public Usuario Build()
        {
            return new Usuario(Nome,Email, Nascimento, Senha);
        }
    }
}
