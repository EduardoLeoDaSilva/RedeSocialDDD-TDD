﻿using RedeSocial_DDD_TDD.Dominio.Entidades;

namespace RedeSocial_DDD_TDD.Dominio.Interfaces.Repositories
{
    public interface ILikeRepositorio : IBaseRepositorio<Like>
    {
        Like ObterTodosLikePorUsuarioId(int idUsuario);
    }
}