using System;
using System.Collections.Generic;
using System.Text;
using Bogus;
using RedeSocial_DDD_TDD.Dominio.Entidades;
using RedeSocial_DDD_TDD.DominioTest.Postagens;

namespace RedeSocial_DDD_TDD.DominioTest.Builders
{
    public class PostagemBuilder
    {
        private readonly Faker _faker;
        private string _texto ;
        private Usuario _usuario;


        private PostagemBuilder()
        {
            _faker = new Faker();
            _texto = _faker.Lorem.Paragraph(3);
            _usuario = UsuarioBuilder.Novo().Build();
        }

        public static PostagemBuilder Novo()
        {
            return new PostagemBuilder();
        }

        public PostagemBuilder ComUsuario(Usuario usuario)
        {
            _usuario = usuario;
            return this;
        }

        public PostagemBuilder ComTexto(string texto)
        {
            _texto = texto;
            return this;
        }

        public Postagem Build()
        {
            return new Postagem(_usuario, _texto);
        }
    }
}
