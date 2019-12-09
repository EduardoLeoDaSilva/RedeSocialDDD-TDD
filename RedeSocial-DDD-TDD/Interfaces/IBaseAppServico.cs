using System;
using System.Collections.Generic;
using System.Text;
using RedeSocial_DDD_TDD.Dominio.Entidades;
using RedeSocial_DDD_TDD.DTOs;

namespace RedeSocial_DDD_TDD.Aplicacao.Interfaces
{
    public interface IBaseAppServico<TEntidadeDto, TEntidade> where TEntidadeDto : BaseDTO
            where TEntidade : EntidadeBase
        {
            void Salvar(TEntidadeDto entidadeDto);
            void Excluir(TEntidadeDto entidadeDto);
            void Atualizar(TEntidadeDto entidadeDto);
            List<TEntidadeDto> ObterTodos();
            TEntidadeDto ObterPorId(int id);
        }
    
}
