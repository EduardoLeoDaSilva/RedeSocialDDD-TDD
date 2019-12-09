using System;
using System.Collections.Generic;
using System.Text;
using RedeSocial_DDD_TDD.Dominio.Entidades;
using RedeSocial_DDD_TDD.Dominio.Interfaces.Repositories;
using RedeSocial_DDD_TDD.Infra.Dados.Contexto;

namespace RedeSocial_DDD_TDD.Infra.Dados.Repositorios
{
    public class PerfilRepositorio : BaseRepositorio<Perfil>, IPerfilRepositorio
    {
        private readonly AplicacaoContexto _contexto;
        public PerfilRepositorio(AplicacaoContexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }
    }
}
