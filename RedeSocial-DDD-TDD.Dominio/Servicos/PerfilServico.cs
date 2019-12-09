using RedeSocial_DDD_TDD.Dominio.Entidades;
using RedeSocial_DDD_TDD.Dominio.Interfaces.Repositories;
using RedeSocial_DDD_TDD.Dominio.Interfaces.Servicos;

namespace RedeSocial_DDD_TDD.Dominio.Servicos
{
    public class PerfilServico : BaseServico<Perfil>, IPerfilServico
    {
        private readonly IPerfilRepositorio _perfilRepositorio;
        public PerfilServico(IPerfilRepositorio perfilRepositorio):base(perfilRepositorio)
        {
            _perfilRepositorio = perfilRepositorio;
        }
    }
}