using System;
using System.Collections.Generic;
using System.Text;
using RedeSocial_DDD_TDD.Dominio.Entidades;
using RedeSocial_DDD_TDD.DTOs;

namespace RedeSocial_DDD_TDD.Aplicacao.Interfaces
{
    public interface IAppPostagemServico : IBaseAppServico<PostagemDTO, Postagem>

    {
        List<Postagem> ObterPostagensPeloEmail(string email);
        PostagemDTO SalvarERetornarSalva(PostagemDTO postagem);
    }
}
