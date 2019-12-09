using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RedeSocial_DDD_TDD.Dominio.Entidades;
using RedeSocial_DDD_TDD.Dominio.Interfaces.Repositories;
using RedeSocial_DDD_TDD.Infra.Dados.Contexto;

namespace RedeSocial_DDD_TDD.Infra.Dados.Repositorios
{
    public class LikeRepositorio : BaseRepositorio<Like>, ILikeRepositorio
    {
        private readonly  AplicacaoContexto _contexto;
        public LikeRepositorio(AplicacaoContexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public Like ObterTodosLikePorUsuarioId(int idUsuario)
        {
            return _contexto.Like.Where(x => x.Usuario.Id == idUsuario).Include(x => x.Usuario).Include(x => x.LikePostagens).ThenInclude(x => x.Postagem).AsNoTracking().SingleOrDefault();
        }

    }
}
