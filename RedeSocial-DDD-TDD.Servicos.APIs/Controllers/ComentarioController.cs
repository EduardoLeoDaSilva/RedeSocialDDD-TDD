using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedeSocial_DDD_TDD.Aplicacao.DTOs;
using RedeSocial_DDD_TDD.Aplicacao.Interfaces;
using RedeSocial_DDD_TDD.Aplicacao.Servicos;

namespace RedeSocial_DDD_TDD.Servicos.AplicacaoAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        private readonly IAppComentarioServico _appComentarioServico;
        public ComentarioController(IAppComentarioServico appComentarioServico)
        {
            _appComentarioServico = appComentarioServico;
        }

        [HttpPost("Comentar")]
        public IActionResult Comentar(ComentarioDTO comentario)
        {
            var comentarioSalvoRetornado = _appComentarioServico.SalvarERecuperar(comentario);
            return Ok(comentarioSalvoRetornado);
        }

        [HttpPost("Deletar")]
        public IActionResult DeletarComentario(ComentarioDTO comentario)
        {
            _appComentarioServico.Excluir(comentario);
            return Ok("Comentário deletado");
        }
        
    }
}