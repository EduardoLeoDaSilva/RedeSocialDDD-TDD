using System.Threading.Tasks;
using RedeSocial_DDD_TDD.DTOs;

namespace RedeSocial_DDD_TDD.Servicos.SignalR.HttpClientes.Interfaces
{
    public interface IPostagemHttpCliente
    {
        Task<string> SalvarEObterPostagemAsync(PostagemDTO postagem);
    }
}