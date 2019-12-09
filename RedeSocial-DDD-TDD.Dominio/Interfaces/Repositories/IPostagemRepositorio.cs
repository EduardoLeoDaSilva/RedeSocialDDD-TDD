using System.Collections.Generic;
using RedeSocial_DDD_TDD.Dominio.Entidades;

namespace RedeSocial_DDD_TDD.Dominio.Interfaces.Repositories
{
    public interface IPostagemRepositorio : IBaseRepositorio<Postagem>
    {
        List<Postagem> ObterPostagensPeloEmail(string email);
        Postagem SalvarERetornarSalva(Postagem postagem);
    }
}