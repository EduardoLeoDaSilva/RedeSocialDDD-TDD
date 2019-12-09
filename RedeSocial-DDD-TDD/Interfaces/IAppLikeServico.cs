using RedeSocial_DDD_TDD.Dominio.Entidades;
using RedeSocial_DDD_TDD.DTOs;

namespace RedeSocial_DDD_TDD.Aplicacao.Interfaces
{
    public interface IAppLikeServico : IBaseAppServico<LikeDTO,Like>
    {
        LikeDTO ObterTodosLikePorUsuarioId(int idUsuario);
        bool JaFoiLiked(LikeDTO like);
        PostagemDTO AtualizarQuantLike(PostagemDTO postagem);
    }
}