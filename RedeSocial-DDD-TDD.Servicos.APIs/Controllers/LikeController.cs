using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RedeSocial_DDD_TDD.Aplicacao.Interfaces;
using RedeSocial_DDD_TDD.Dominio.Entidades;
using RedeSocial_DDD_TDD.DTOs;


namespace RedeSocial_DDD_TDD.Servicos.AplicacaoAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {

        private readonly IAppLikeServico _likeServico;
        private readonly IAppPostagemServico _postagemServico;
        private readonly IAppUsuarioServico _usuarioServico;

       // private readonly IAppLike
        public LikeController(IAppLikeServico likeServico, IAppPostagemServico postagemServico, IAppUsuarioServico usuarioServico)
        {
            _likeServico = likeServico;
            _postagemServico = postagemServico;
            _usuarioServico = usuarioServico;
        }

        [HttpPost]
        public IActionResult AtualizarLike(PostagemDTO postagemDTO)
        {

          var postagem = _likeServico.AtualizarQuantLike(postagemDTO);
          return Ok(postagem);

        }
    }
}