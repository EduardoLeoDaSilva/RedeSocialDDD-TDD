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


    public class BaseAppServico<TEntidadeDto, TEntidade> : IBaseAppServico<TEntidadeDto, TEntidade> where TEntidadeDto: BaseDTO where TEntidade : EntidadeBase
    {
        private readonly IBaseServico<TEntidade> _baseServico;
        private readonly IMapper _mapper;

        public BaseAppServico(IMapper mapper, IBaseServico<TEntidade> baseServico)
        {
            _mapper = mapper;
            _baseServico = baseServico;
        }

        public virtual void Salvar(TEntidadeDto entidadeDto)
        {
            _baseServico.Salvar(_mapper.Map<TEntidade>(entidadeDto));
        }

        public virtual void Excluir(TEntidadeDto entidadeDto)
        {
            _baseServico.Excluir(_mapper.Map<TEntidade>(entidadeDto));
        }

        public virtual void Atualizar(TEntidadeDto entidadeDto)
        {
            _baseServico.Atualizar(_mapper.Map<TEntidade>(entidadeDto));
        }

        public virtual List<TEntidadeDto> ObterTodos()
        {
            return _mapper.Map<List<TEntidadeDto>>(_baseServico.ObterTodos());
        }

        public  virtual TEntidadeDto ObterPorId(int id)
        {
            return _mapper.Map<TEntidadeDto>(_baseServico.ObterPorId(id));
        }
    }
}
