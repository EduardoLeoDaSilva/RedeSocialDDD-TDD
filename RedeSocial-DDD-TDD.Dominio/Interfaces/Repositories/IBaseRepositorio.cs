using System;
using System.Collections.Generic;
using System.Text;
using RedeSocial_DDD_TDD.Dominio.Entidades;

namespace RedeSocial_DDD_TDD.Dominio.Interfaces.Repositories
{
    public interface IBaseRepositorio<TEntidade> 
    {
        void Salvar(TEntidade e);
        void Excluir(TEntidade e);
        void Atualizar(TEntidade e);
        IList<TEntidade> ObterTodos();

        TEntidade ObterPorId(int id);
    }
}
