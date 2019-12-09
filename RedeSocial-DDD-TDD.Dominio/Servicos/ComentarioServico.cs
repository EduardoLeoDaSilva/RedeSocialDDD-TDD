using System;
using System.Collections.Generic;
using System.Text;
using RedeSocial_DDD_TDD.Dominio.Entidades;
using RedeSocial_DDD_TDD.Dominio.Interfaces.Repositories;
using RedeSocial_DDD_TDD.Dominio.Interfaces.Servicos;

namespace RedeSocial_DDD_TDD.Dominio.Servicos
{
    public class ComentarioServico: BaseServico<Comentario>, IComentarioServico
    {
        private readonly IComentarioRepositorio _comentarioRepositorio;
        public ComentarioServico(IComentarioRepositorio comentarioRepositorio) : base(comentarioRepositorio)
        {
            _comentarioRepositorio = comentarioRepositorio;
        }

        public Comentario SalvarERecuperar(Comentario comentario)
        {
            _comentarioRepositorio.Salvar(comentario);
            return comentario;
        }
    }
}
