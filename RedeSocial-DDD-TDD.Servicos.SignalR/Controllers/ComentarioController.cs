using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RedeSocial_DDD_TDD.Aplicacao.DTOs;
using RedeSocial_DDD_TDD.Servicos.SignalR.HttpClientes.Interfaces;
using RedeSocial_DDD_TDD.Servicos.SignalR.Hubs;

namespace RedeSocial_DDD_TDD.Servicos.SignalR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        private readonly IComentarioHttpClient _comentarioHttpClient;
        private readonly IHubContext<HubLikePostagem> _hubContext;
        public ComentarioController(IComentarioHttpClient comentarioHttpClient, IHubContext<HubLikePostagem> hubContext)
        {
            _comentarioHttpClient = comentarioHttpClient;
            _hubContext = hubContext;
        }


        [HttpPost("Comentar")]
        public async Task<IActionResult> Comentar(ComentarioDTO comentario)
        {
           var postagemRetorno = await _comentarioHttpClient.Comentar(comentario);
           await _hubContext.Clients.All.SendAsync("comentar", postagemRetorno);
           return Ok(postagemRetorno);
        }

    }
}