using System;
using System.Collections.Generic;
using System.Text;
using RedeSocial_DDD_TDD.Dominio.Entidades;
using RedeSocial_DDD_TDD.DTOs;

namespace RedeSocial_DDD_TDD.Aplicacao.Interfaces
{
    public interface IAppUsuarioServico : IBaseAppServico<UsuarioDTO, Usuario>
    {
        UsuarioDTO Entrar(string email, string senha);
        byte[] ObterFoto(int id);
    }
}
