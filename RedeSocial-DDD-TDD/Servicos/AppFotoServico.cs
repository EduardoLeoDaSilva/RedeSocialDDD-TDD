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
    public class AppFotoServico : BaseAppServico<FotoDTO,Foto>, IAppFotoServico
    {
        private readonly IMapper _mapper;
        private readonly IFotoServico _fotoServico;
        public AppFotoServico(IMapper mapper,  IFotoServico fotoServico) : base(mapper, fotoServico)
        {
            _mapper = mapper;
            _fotoServico = fotoServico;
        }


        public byte[] ObterFoto(int id)
        {
            var foto = _fotoServico.ObterPorId(id);
            return foto.Imagem;
        }
    }
}
