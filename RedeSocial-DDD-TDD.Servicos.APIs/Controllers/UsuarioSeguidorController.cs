using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedeSocial_DDD_TDD.Aplicacao.Interfaces;
using RedeSocial_DDD_TDD.Dominio.Entidades;
using RedeSocial_DDD_TDD.DTOs;

namespace RedeSocial_DDD_TDD.Servicos.AplicacaoAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioSeguidorController : ControllerBase
    {
        private readonly IAppUsuarioServico _usuarioAppServico;
        public UsuarioSeguidorController(IAppUsuarioServico usuarioAppServico)
        {
            _usuarioAppServico = usuarioAppServico;
        }

        [HttpPost("ProcurarPessoas")]
        public IActionResult ProcurarUsuarios(UsuarioDTO usuarioDto)
        {
            var listaUsuarioBanco = _usuarioAppServico.ObterTodos();
            if (string.IsNullOrEmpty(usuarioDto.Nome))
                return Ok(new List<UsuarioAmigoDTO>());
            
            var usuariosFiltrados = listaUsuarioBanco.Where(x => x.Nome.Contains(usuarioDto.Nome, StringComparison.OrdinalIgnoreCase)).ToList();
            return Ok(usuariosFiltrados);
        }
    }
}