using RedeSocial_DDD_TDD.Dominio.Entidades;

namespace RedeSocial_DDD_TDD.Dominio.Interfaces.Repositories
{
    public interface IUsuarioRepositorio : IBaseRepositorio<Usuario>
    {
        Usuario ObterPorEmail(string email);
        Usuario Entrar(string email, string senha);

    }
}