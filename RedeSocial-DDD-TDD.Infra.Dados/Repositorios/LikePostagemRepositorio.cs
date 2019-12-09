using System;
using System.Collections.Generic;
using System.Text;
using RedeSocial_DDD_TDD.Dominio.Entidades;
using RedeSocial_DDD_TDD.Dominio.Interfaces.Repositories;
using RedeSocial_DDD_TDD.Infra.Dados.Contexto;

namespace RedeSocial_DDD_TDD.Infra.Dados.Repositorios
{
    public class LikePostagemRepositorio : BaseRepositorio<LikePostagem>, ILikePostagemRepositorio
    {
        private readonly AplicacaoContexto _contexto;
        public LikePostagemRepositorio(AplicacaoContexto contexto):base(contexto)
        {
            _contexto = contexto;
        }
    }
}
