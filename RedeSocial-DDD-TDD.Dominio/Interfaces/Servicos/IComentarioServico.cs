﻿using RedeSocial_DDD_TDD.Dominio.Entidades;

namespace RedeSocial_DDD_TDD.Dominio.Interfaces.Servicos
{
    public interface IComentarioServico : IBaseServico<Comentario>
    {
        Comentario SalvarERecuperar(Comentario comentario);
    }
}