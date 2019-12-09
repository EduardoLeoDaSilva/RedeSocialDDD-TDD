using System;
using System.Collections.Generic;
using System.Text;
using RedeSocial_DDD_TDD.Dominio.Entidades;

namespace RedeSocial_DDD_TDD.Dominio.Interfaces.Servicos
{
    public interface IBaseServico<TEntidade> where TEntidade : EntidadeBase
    {
        void Salvar(TEntidade e);
        void Excluir(TEntidade e);
        void Atualizar(TEntidade e);
        IList<TEntidade> ObterTodos();

        TEntidade ObterPorId(int id);
    }
}
