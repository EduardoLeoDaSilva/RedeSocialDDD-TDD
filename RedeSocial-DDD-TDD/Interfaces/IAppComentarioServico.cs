using RedeSocial_DDD_TDD.Aplicacao.DTOs;
using RedeSocial_DDD_TDD.Dominio.Entidades;

namespace RedeSocial_DDD_TDD.Aplicacao.Interfaces
{
    public interface IAppComentarioServico : IBaseAppServico<ComentarioDTO, Comentario>
    {
        ComentarioDTO SalvarERecuperar(ComentarioDTO comentario);
    }
}