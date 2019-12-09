using System;
using System.Collections.Generic;
using System.Text;
using ExpectedObjects;
using RedeSocial_DDD_TDD.Dominio.Entidades;
using RedeSocial_DDD_TDD.Dominio.Utils.Excecoes;
using RedeSocial_DDD_TDD.DominioTest.Builders;
using RedeSocial_DDD_TDD.DominioTest.Extencoes;
using Xunit;

namespace RedeSocial_DDD_TDD.DominioTest.Perfis
{
    public class PerfilTest
    {
        private readonly Perfil _perfilEsperado;

        public PerfilTest()
        {
                _perfilEsperado = new Perfil
                (
                UsuarioBuilder.Novo().Build(),
                "Futebol"
                );
        }
        [Fact]
        public void DeveCriarPerfil()
        {
            var perfilEsperado = new
            {
                Usuario = UsuarioBuilder.Novo().Build(),
                Interesse = "Futebol"
            };

            var perfil = new Perfil(perfilEsperado.Usuario, perfilEsperado.Interesse);
            perfilEsperado.ToExpectedObject().ShouldMatch(perfil);

        }

        [Fact]
        public void NaoDeveCriarSemUsuario()
        {
            Usuario usuario = null;

            Assert.Throws<EntitadeExcecao>(() => PerfilBuilder.Novo().ComUsuario(usuario).Build()).ComMensagem("Usuario relacionado com esse perfil é inválido");
        }

        [Fact]
        public void NaoDeveTerInteresseInvalido()
        {
            var interesseInvalido = "";

            Assert.Throws<EntitadeExcecao>(() => PerfilBuilder.Novo().ComInteresse(interesseInvalido).Build()).ComMensagem("Interesse inválido");
        }



    }
}
