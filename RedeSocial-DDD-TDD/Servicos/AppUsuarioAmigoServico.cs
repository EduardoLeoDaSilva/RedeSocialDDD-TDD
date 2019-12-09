using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using RedeSocial_DDD_TDD.Dominio.Entidades;
using RedeSocial_DDD_TDD.Dominio.Interfaces.Servicos;
using RedeSocial_DDD_TDD.DTOs;
using RedeSocial_DDD_TDD.Aplicacao.Interfaces;

namespace RedeSocial_DDD_TDD.Aplicacao.Servicos
{
    public class AppUsuarioAmigo : BaseAppServico<UsuarioAmigoDTO, UsuarioAmigo>, IAppUsuarioAmigo
    {
        private readonly IMapper _mapper;
        private readonly IBaseServico<UsuarioAmigo> _baseServico;

        public AppUsuarioAmigo(IMapper mapper, IBaseServico<UsuarioAmigo> baseServico) : base(mapper, baseServico)
        {
            _mapper = mapper;
            _baseServico = baseServico;
        }
    }
}
