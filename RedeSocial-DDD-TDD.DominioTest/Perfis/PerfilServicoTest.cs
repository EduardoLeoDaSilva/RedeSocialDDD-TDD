using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using RedeSocial_DDD_TDD.Dominio.Entidades;
using RedeSocial_DDD_TDD.Dominio.Interfaces.Repositories;
using RedeSocial_DDD_TDD.Dominio.Servicos;
using RedeSocial_DDD_TDD.DominioTest.Builders;
using Xunit;

namespace RedeSocial_DDD_TDD.DominioTest.Perfis
{
    public class PerfilServicoTest
    {
        private readonly Mock<IPerfilRepositorio> _perfilRepositorioMock;
        private readonly PerfilServico _perfilServico;
        public PerfilServicoTest()
        {
            _perfilRepositorioMock = new Mock<IPerfilRepositorio>();
            _perfilServico = new PerfilServico(_perfilRepositorioMock.Object);
        }

        [Fact]
        public void DeveSalvarPerfil()
        {
            var perfilParaSerSalvo = PerfilBuilder.Novo().Build();

            _perfilServico.Salvar(perfilParaSerSalvo);
            _perfilRepositorioMock.Verify(x => x.Salvar(It.Is<Perfil>(t => t.Usuario.Email == perfilParaSerSalvo.Usuario.Email)));

        }

    }
}
