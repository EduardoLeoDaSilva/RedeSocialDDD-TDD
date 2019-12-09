using System;
using System.Collections.Generic;
using System.Linq;
using RedeSocial_DDD_TDD.Dominio.Entidades;
using RedeSocial_DDD_TDD.Dominio.Interfaces.Repositories;
using RedeSocial_DDD_TDD.Infra.Dados.Contexto;

namespace RedeSocial_DDD_TDD.Infra.Dados.Repositorios
{
    public class BaseRepositorio<TEntity> : IBaseRepositorio<TEntity> where TEntity: class
    {
        private readonly AplicacaoContexto _contexto;

        public BaseRepositorio(AplicacaoContexto contexto)
        {
            _contexto = contexto;
        }

        public virtual void Atualizar(TEntity e)
        {
            _contexto.Set<TEntity>().Update(e);
            _contexto.SaveChanges();
        }

        public virtual void Excluir(TEntity e)
        {
            _contexto.Set<TEntity>().Remove(e);
            _contexto.SaveChanges();


        }

        public virtual TEntity ObterPorId(int id)
        {
          return _contexto.Set<TEntity>().Find(id);

        }

        public virtual IList<TEntity> ObterTodos()
        {
            return _contexto.Set<TEntity>().ToList();
        }

        public virtual void Salvar(TEntity e)
        {
            _contexto.Set<TEntity>().Add(e);
            _contexto.SaveChanges();

        }
    }
}