using System.Collections.Generic;
using RedeSocial_DDD_TDD.Dominio.Entidades;

namespace RedeSocial_DDD_TDD.Dominio.Interfaces.Servicos
{
    public interface IPostagemServico : IBaseServico<Postagem>
    {
        List<Postagem> ObterPostagensPeloEmail(string email);
        Postagem SalvarERetornarSalva(Postagem postagem);
    }
}