using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedeSocial_DDD_TDD.Aplicacao.Interfaces;
using RedeSocial_DDD_TDD.Aplicacao.Utils;
using RedeSocial_DDD_TDD.Dominio.Entidades;
using RedeSocial_DDD_TDD.DTOs;

namespace RedeSocial_DDD_TDD.Servicos.AplicacaoAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostagemController : ControllerBase
    {
        private readonly IAppPostagemServico _postagemServico;
        private readonly IAppUsuarioServico _usuarioServico;
        private readonly IAppFotoServico _fotoServico;
        public PostagemController(IAppPostagemServico postagemServico, IAppUsuarioServico usuarioServico, IAppFotoServico fotoServico)
        {
            _postagemServico = postagemServico;
            _usuarioServico = usuarioServico;
            _fotoServico = fotoServico;
        }

        [HttpPost]
        public IActionResult NovaPostagem([FromForm]PostagemDTO postagemDto)
        {
            var usuario = _usuarioServico.ObterPorId(postagemDto.Usuario.Id);
            var fotos = HttpContext.Request.Form.Files;
            var listaFotosDTo = fotos.ObterListaFotosDeIFormCollection();

            listaFotosDTo.ForEach(x => x.Usuario = usuario);

            postagemDto.Fotos = listaFotosDTo;
            postagemDto.Usuario = usuario;

            var postagemRetornadaSalva = _postagemServico.SalvarERetornarSalva(postagemDto);
            return Ok(postagemRetornadaSalva);
        }

        [HttpGet]
        public List<PostagemDTO> ObterTodos()
        {
            return _postagemServico.ObterTodos();
        }

        [HttpGet("ObterFotosPostagem")]
        public IActionResult ObterFotosPostagem(int id)
        {
            var usuarioFoto = _fotoServico.ObterFoto(id);
            if (usuarioFoto != null)
            {
                return File(usuarioFoto, "img/png");
            }

            return Ok();
        }

    }
}