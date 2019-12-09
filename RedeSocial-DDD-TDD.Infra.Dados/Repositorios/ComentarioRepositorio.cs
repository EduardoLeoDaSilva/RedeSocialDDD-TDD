using System;
using System.Collections.Generic;
using System.Text;
using RedeSocial_DDD_TDD.Dominio.Entidades;
using RedeSocial_DDD_TDD.Dominio.Interfaces.Repositories;
using RedeSocial_DDD_TDD.Infra.Dados.Contexto;

namespace RedeSocial_DDD_TDD.Infra.Dados.Repositorios
{
    public class ComentarioRepositorio : BaseRepositorio<Comentario>, IComentarioRepositorio
    {
        private readonly AplicacaoContexto _contexto;
        public ComentarioRepositorio(AplicacaoContexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }
    }
}
