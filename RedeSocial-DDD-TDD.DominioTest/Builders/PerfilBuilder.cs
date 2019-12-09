using System;
using System.Collections.Generic;
using System.Text;
using RedeSocial_DDD_TDD.Dominio.Entidades;
using RedeSocial_DDD_TDD.DominioTest.Perfis;

namespace RedeSocial_DDD_TDD.DominioTest.Builders
{
    public class PerfilBuilder
    {
        private List<string> _viagens = new List<String> { "Marrocos", "France" };
        private string _interesse = "Futebol";
        private Usuario _usuario =UsuarioBuilder.Novo().Build();

        public static PerfilBuilder Novo()
        {
            return new PerfilBuilder();
        }

        public PerfilBuilder ComUsuario(Usuario usuario)
        {
            _usuario = usuario;
            return this;

        }

        public PerfilBuilder ComInteresse(string interesse)
        {
            _interesse = interesse;
            return this;

        }


        public Perfil Build()
        {
            return new Perfil(_usuario, _interesse);
        }

    }
}
