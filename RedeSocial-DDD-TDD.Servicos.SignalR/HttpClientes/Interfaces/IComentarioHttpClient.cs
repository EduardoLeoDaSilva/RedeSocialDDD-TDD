using System.Threading.Tasks;
using RedeSocial_DDD_TDD.Aplicacao.DTOs;
using RedeSocial_DDD_TDD.DTOs;

namespace RedeSocial_DDD_TDD.Servicos.SignalR.HttpClientes.Interfaces
{
    public interface IComentarioHttpClient
    {
        Task<string> Comentar(ComentarioDTO comentario);
    }
}