using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using AutoMapper;
using Humanizer;
using RedeSocial_DDD_TDD.Aplicacao.DTOs;
using RedeSocial_DDD_TDD.Dominio.Entidades;
using RedeSocial_DDD_TDD.Dominio.Interfaces.Servicos;
using RedeSocial_DDD_TDD.DTOs;
using RedeSocial_DDD_TDD.Aplicacao.Interfaces;
using RedeSocial_DDD_TDD.Aplicacao.Utils;

namespace RedeSocial_DDD_TDD.Aplicacao.Servicos
{
    public class AppPostagemServico : BaseAppServico<PostagemDTO, Postagem>, IAppPostagemServico
    {
        private readonly IMapper _mapper;
        private readonly IPostagemServico _postagemServico;
        private readonly IAppFotoServico _appFotoServico;

        public AppPostagemServico(IMapper mapper, IPostagemServico postagemServico, IAppFotoServico appFotoServico) : base(mapper, postagemServico)
        {
            _mapper = mapper;
            _postagemServico = postagemServico;
            _appFotoServico = appFotoServico;
        }

        public List<Postagem> ObterPostagensPeloEmail(string email)
        {
            var postagens = _postagemServico.ObterPostagensPeloEmail(email);
            return postagens;
        }

        public PostagemDTO SalvarERetornarSalva(PostagemDTO postagem)
        {
            var postagemParaSerSalva =_mapper.Map<Postagem>(postagem);
            postagemParaSerSalva.Fotos.ForEach(x => x.SetarUsuario(postagemParaSerSalva.Usuario));
            var postagemSalva = _postagemServico.SalvarERetornarSalva(postagemParaSerSalva);
            var fotos = postagemSalva.Fotos.Select(t => _mapper.Map<FotoDTO>(t)).ToList();

            var postagemRetornada = _mapper.Map<PostagemDTO>(postagemSalva);
            postagemRetornada.Fotos = fotos;
           postagemRetornada.DataPublicacao = postagemSalva.DataPublicacao.Humanize(false);
           return postagemRetornada;


        }

        public override List<PostagemDTO> ObterTodos()
        {

            var postagens = _postagemServico.ObterTodos();
            var postagensDTo = postagens.Select(x => new PostagemDTO(x.Id, _mapper.Map<UsuarioDTO>(x.Usuario), x.Texto,
                x.LikePostagens.Select(d => _mapper.Map<LikePostagemDTO>(d)).ToList(),
                 x.DataPublicacao.Humanize(false), x.Comentarios.Select(t => _mapper.Map<ComentarioDTO>(t)).ToList(), x.Fotos.Select(t => _mapper.Map<FotoDTO>(t)).ToList())).ToList();
            

            return postagensDTo;
        }

    }
}
