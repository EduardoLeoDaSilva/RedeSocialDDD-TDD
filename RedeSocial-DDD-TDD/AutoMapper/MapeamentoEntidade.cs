using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using RedeSocial_DDD_TDD.Aplicacao.DTOs;
using RedeSocial_DDD_TDD.Aplicacao.Utils;
using RedeSocial_DDD_TDD.Dominio.Entidades;
using RedeSocial_DDD_TDD.DTOs;

namespace RedeSocial_DDD_TDD.AutoMapper
{
    public class MapeamentoEntidade : Profile
    {
        public MapeamentoEntidade()
        {
            CreateMap<Usuario, UsuarioDTO>().ForMember(x => x.FotoPerfil,  x => x.Ignore());
            CreateMap<Postagem, PostagemDTO>();
            CreateMap<Like, LikeDTO>().ForMember(x => x.LikePostagens, t => t.MapFrom(d => d.LikePostagens));
            CreateMap<UsuarioAmigo, UsuarioAmigoDTO>();
            CreateMap<Perfil, PerfilDTO>();
            CreateMap<LikePostagem, LikePostagemDTO>();
            CreateMap<List<LikePostagem>, List<LikePostagemDTO>>();
            CreateMap<Comentario, ComentarioDTO>();
            CreateMap<Foto, FotoDTO>();
            CreateMap<List<Foto>, List<FotoDTO>>();
            CreateMap<List<Comentario>, List<ComentarioDTO>>().IncludeMembers();
            CreateMap<byte[], IFormFile>().ConvertUsing(x => null);

            CreateMap<UsuarioDTO, Usuario>().ForMember(x => x.FotoPerfil, x => x.Ignore());
            CreateMap<PostagemDTO, Postagem>().ForMember(x => x.Fotos, x => x.MapFrom(t => t.ObterListaFotoDeDTOParMapper()));
            CreateMap<LikeDTO, Like>().ForMember(x => x.LikePostagens, t=> t.MapFrom(x => x.LikePostagens));
            CreateMap<UsuarioAmigoDTO, UsuarioAmigo>();
            CreateMap<PerfilDTO, Perfil>();
            CreateMap<LikePostagemDTO, LikePostagem>();
            CreateMap<List<LikePostagemDTO>, List<LikePostagem>>();
            CreateMap<ComentarioDTO, Comentario>();
            CreateMap<FotoDTO, Foto>();
            CreateMap<List<FotoDTO>, List<Foto>>();
            CreateMap<IFormFile, byte[]>().ConvertUsing(x => x.ParaFotoEntidade());



        }

    }
}
