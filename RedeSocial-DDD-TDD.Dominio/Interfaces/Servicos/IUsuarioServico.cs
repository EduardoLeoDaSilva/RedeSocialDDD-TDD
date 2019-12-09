using RedeSocial_DDD_TDD.Dominio.Entidades;

namespace RedeSocial_DDD_TDD.Dominio.Interfaces.Servicos
{
    public interface IUsuarioServico : IBaseServico<Usuario>
    {
        Usuario Entrar(string email, string senha);
    }
}