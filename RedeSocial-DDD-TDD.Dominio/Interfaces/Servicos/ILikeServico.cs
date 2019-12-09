using RedeSocial_DDD_TDD.Dominio.Entidades;

namespace RedeSocial_DDD_TDD.Dominio.Interfaces.Servicos
{
    public interface ILikeServico : IBaseServico<Like>
    {
        Like ObterTodosLikePorUsuarioId(int idUsuario);
        bool JaFoiLiked(Like like);

        Postagem AtualizarQuantLike(Postagem postagem);
    }
}