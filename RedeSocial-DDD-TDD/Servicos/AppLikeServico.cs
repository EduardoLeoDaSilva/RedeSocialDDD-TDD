using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using RedeSocial_DDD_TDD.Dominio.Entidades;
using RedeSocial_DDD_TDD.Dominio.Interfaces.Servicos;
using RedeSocial_DDD_TDD.DTOs;
using RedeSocial_DDD_TDD.Aplicacao.Interfaces;

namespace RedeSocial_DDD_TDD.Aplicacao.Servicos
{
    public class AppLikeServico : BaseAppServico<LikeDTO, Like>, IAppLikeServico
    {
        private readonly IMapper _mapper;
        private readonly ILikeServico _likeServico;

        public AppLikeServico(IMapper mapper, ILikeServico likeServico) : base(mapper, likeServico)
        {
            _mapper = mapper;
            _likeServico = likeServico;
        }

        public LikeDTO ObterTodosLikePorUsuarioId(int idUsuario)
        {
            var likeNormal = _likeServico.ObterTodosLikePorUsuarioId(idUsuario);
            var likeDTO = _mapper.Map<LikeDTO>(likeNormal);
            likeDTO.LikePostagens =
                likeNormal.LikePostagens.Select(x => new LikePostagemDTO(x.LikeId, x.PostagemId, _mapper.Map<LikeDTO>(x.Like), _mapper.Map<PostagemDTO>(x.Postagem))).ToList();
            return likeDTO;
        }

        public bool JaFoiLiked(LikeDTO like)
        {
            return _likeServico.JaFoiLiked( _mapper.Map<Like>(like));
        }


        public PostagemDTO AtualizarQuantLike(PostagemDTO postagem)
        {
          var postageRetornada =  _likeServico.AtualizarQuantLike(_mapper.Map<Postagem>(postagem));
          var postagemDTO = _mapper.Map<PostagemDTO>(postageRetornada);
          postagemDTO.LikePostagens = postageRetornada.LikePostagens.Select(x => new LikePostagemDTO(x.LikeId, x.PostagemId, _mapper.Map<LikeDTO>(x.Like), _mapper.Map<PostagemDTO>(x.Postagem))).ToList();
          return postagemDTO;

        }

    }
}
