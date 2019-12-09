using System.Threading.Tasks;
using RedeSocial_DDD_TDD.DTOs;

namespace RedeSocial_DDD_TDD.Servicos.SignalR.HttpClientes.Interfaces
{
    public interface ILikeHttpClient
    {
        Task<string> AtualizarLike(PostagemDTO postagem);
    }
}