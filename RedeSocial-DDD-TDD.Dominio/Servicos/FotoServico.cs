using System;
using System.Collections.Generic;
using System.Text;
using RedeSocial_DDD_TDD.Dominio.Entidades;
using RedeSocial_DDD_TDD.Dominio.Interfaces.Repositories;
using RedeSocial_DDD_TDD.Dominio.Interfaces.Servicos;

namespace RedeSocial_DDD_TDD.Dominio.Servicos
{
    public class FotoServico : BaseServico<Foto>, IFotoServico
    {
        private readonly IFotoRepositorio _fotoRepositorio;
        public FotoServico(IFotoRepositorio fotoRepositorio) : base(fotoRepositorio)
        {
            _fotoRepositorio = fotoRepositorio;
        }
    }
}
