using System;
using System.Collections.Generic;
using System.Text;
using RedeSocial_DDD_TDD.Dominio.Entidades;
using RedeSocial_DDD_TDD.Dominio.Interfaces.Repositories;
using RedeSocial_DDD_TDD.Dominio.Interfaces.Servicos;
using RedeSocial_DDD_TDD.Dominio.Utils;

namespace RedeSocial_DDD_TDD.Dominio.Servicos
{
    public class BaseServico<TEntidade> : IBaseServico<TEntidade> where TEntidade : EntidadeBase
    {


        private readonly IBaseRepositorio<TEntidade> _baseRepository;

        public BaseServico(IBaseRepositorio<TEntidade> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public virtual void Atualizar(TEntidade e)
        {
            ValidadorRegra.Novo().Quando(e == null, "Objeto inválido").DispararExcecaoSeExistir();

            _baseRepository.Atualizar(e);

        }

        public virtual void Excluir(TEntidade e)
        {
            ValidadorRegra.Novo().Quando(e == null, "Objeto inválido").DispararExcecaoSeExistir();

            _baseRepository.Excluir(e);
        }

        public virtual TEntidade ObterPorId(int id)
        {
            
            var entidadeVindoBanco = _baseRepository.ObterPorId(id);

            ValidadorRegra.Novo().Quando(entidadeVindoBanco == null, "Não existe na base com esse id").DispararExcecaoSeExistir();

            return entidadeVindoBanco;
        }

        public virtual IList<TEntidade> ObterTodos()
        {
            var listaDeEntidadeDabase= _baseRepository.ObterTodos();
            ValidadorRegra.Novo().Quando(listaDeEntidadeDabase.Count <=0, "Não existe dados na base").DispararExcecaoSeExistir();

            return listaDeEntidadeDabase;

        }

        public virtual void Salvar(TEntidade e)
        {
            ValidadorRegra.Novo().Quando(e == null, "Objeto inválido").DispararExcecaoSeExistir();

            _baseRepository.Salvar(e);
        }
    }
}
