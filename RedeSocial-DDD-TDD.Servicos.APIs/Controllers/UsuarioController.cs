using System;
using Microsoft.AspNetCore.Mvc;
using RedeSocial_DDD_TDD.Aplicacao.Interfaces;
using RedeSocial_DDD_TDD.Aplicacao.Utils;
using RedeSocial_DDD_TDD.DTOs;

namespace RedeSocial_DDD_TDD.Servicos.AplicacaoAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IAppUsuarioServico _appUsuarioServico;
        public UsuarioController(IAppUsuarioServico appUsuarioServico)
        {
            _appUsuarioServico = appUsuarioServico;
        }

        [HttpPost("Cadastrar")]
        public IActionResult Cadastrar([FromForm]UsuarioDTO usuario)
        {

            if (ModelState.IsValid)
            {
                _appUsuarioServico.Salvar(usuario);
                return Ok("Usuário cadastrado!");
            }
            return BadRequest("Um erro ocorreu durante sua solicitação!");


        }

        [HttpPost("Entrar")]
        public IActionResult Entrar(UsuarioDTO usuarioDto)
        {
            var usuario = _appUsuarioServico.Entrar(usuarioDto.Email, usuarioDto.Senha);
            if (usuario != null)
                return Ok(usuario);
            return BadRequest("Usuário e senha não existem na base de dados!");
        }

        [HttpGet("ObterFoto")]
        public IActionResult ObterFotoPerfil(int id)
        {
            var usuarioFoto = _appUsuarioServico.ObterFoto(id);
            if (usuarioFoto != null)
            {
                return File(usuarioFoto, "img/png");
            }

            return Ok();
        }
    }
}