using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using RedeSocial_DDD_TDD.Dominio.Entidades;
using RedeSocial_DDD_TDD.Dominio.Interfaces.Servicos;
using RedeSocial_DDD_TDD.DTOs;
using RedeSocial_DDD_TDD.Aplicacao.Interfaces;
using RedeSocial_DDD_TDD.Aplicacao.Utils;

namespace RedeSocial_DDD_TDD.Aplicacao.Servicos
{
    public class AppUsuarioServico: BaseAppServico<UsuarioDTO, Usuario>, IAppUsuarioServico
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioServico _usuarioServico;


        public AppUsuarioServico(IMapper mapper, IUsuarioServico usuarioServico) : base(mapper, usuarioServico)
        {
            _mapper = mapper;
            _usuarioServico = usuarioServico;
        }

        public UsuarioDTO Entrar(string email, string senha)
        {
            return  _mapper.Map<UsuarioDTO>(_usuarioServico.Entrar(email, senha));
        }

        public override void Salvar(UsuarioDTO entidadeDto)
        {
            var usuario = _mapper.Map<Usuario>(entidadeDto);
            usuario.SetarFotoPerfil(entidadeDto.FotoPerfil.ParaFotoEntidade());
            _usuarioServico.Salvar(usuario);
        }

        public  byte[] ObterFoto(int id)
        {
            var usuario = _usuarioServico.ObterPorId(id);
            return usuario.FotoPerfil;
        }
    }
}
