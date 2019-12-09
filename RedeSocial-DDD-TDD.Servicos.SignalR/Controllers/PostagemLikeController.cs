using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using RedeSocial_DDD_TDD.Aplicacao.Utils;
using RedeSocial_DDD_TDD.DTOs;
using RedeSocial_DDD_TDD.Servicos.SignalR.HttpClientes.Interfaces;
using RedeSocial_DDD_TDD.Servicos.SignalR.Hubs;
using System.Threading.Tasks;

namespace RedeSocial_DDD_TDD.Servicos.SignalR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostagemLikeController : ControllerBase
    {
        private readonly IHubContext<HubLikePostagem> _hubContext;
        private readonly IPostagemHttpCliente _postagemHttpCliente;
        private readonly ILikeHttpClient _likeHttpClient;
        public PostagemLikeController(IPostagemHttpCliente postagemHttpCliente, ILikeHttpClient likeHttpClient,
            IHubContext<HubLikePostagem> hubContext)
        {
            _hubContext = hubContext;
            _postagemHttpCliente = postagemHttpCliente;
            _likeHttpClient = likeHttpClient;
        }
        [HttpPost("Postar")]
        public async Task<IActionResult> Postar([FromForm]PostagemDTO postagem)
        {
            var fotos = HttpContext.Request.Form.Files;
            var fotosDTO = fotos.ObterListaFotosDeIFormCollection();
            postagem.Fotos = fotosDTO;

            var postagemRetorno = await _postagemHttpCliente.SalvarEObterPostagemAsync(postagem);
            var postagemDTORetorno = JsonConvert.DeserializeObject<PostagemDTO>(postagemRetorno);
            await _hubContext.Clients.All.SendAsync("teste", postagemDTORetorno);
            return Ok(postagemDTORetorno);
        }

      

        [HttpPost("DarLike")]
        public async Task<IActionResult> DarLike(PostagemDTO postagem)
        {
            var postagemLikeJson = await _likeHttpClient.AtualizarLike(postagem);
            var postagemLikeDto = JsonConvert.DeserializeObject<PostagemDTO>(postagemLikeJson);
            await _hubContext.Clients.All.SendAsync("like", postagemLikeDto);
            return Ok(postagemLikeDto);
        }

    }
}