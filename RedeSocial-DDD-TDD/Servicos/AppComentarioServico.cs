using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using RedeSocial_DDD_TDD.Aplicacao.DTOs;
using RedeSocial_DDD_TDD.Aplicacao.Interfaces;
using RedeSocial_DDD_TDD.Dominio.Entidades;
using RedeSocial_DDD_TDD.Dominio.Interfaces.Servicos;

namespace RedeSocial_DDD_TDD.Aplicacao.Servicos
{
    public class AppComentarioServico: BaseAppServico<ComentarioDTO,Comentario>, IAppComentarioServico
    {
        private readonly IMapper _mapper;
        private readonly IComentarioServico _comentarioServico;
        private readonly IUsuarioServico _usuarioServico;
        private readonly IPostagemServico _postagemServico;
        public AppComentarioServico(IMapper mapper, IComentarioServico comentarioServico, IUsuarioServico usuarioServico, IPostagemServico postagemServico) : base(mapper, comentarioServico)
        {
            _mapper = mapper;
            _comentarioServico = comentarioServico;
            _usuarioServico = usuarioServico;
            _postagemServico = postagemServico;
        }


        public ComentarioDTO SalvarERecuperar(ComentarioDTO comentario)
        {
            var usuario = _usuarioServico.ObterPorId(comentario.Usuario.Id);
            var postagem = _postagemServico.ObterPorId(comentario.Postagem.Id);
            var comentarioParaSalvar = new Comentario(usuario, comentario.Texto, postagem);
            var comentarioSalvoRetornado = _comentarioServico.SalvarERecuperar(comentarioParaSalvar);
         return _mapper.Map<ComentarioDTO>(comentarioSalvoRetornado);
        }
    }
}
