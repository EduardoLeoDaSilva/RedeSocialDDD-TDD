
using System;
using System.Collections.Generic;
using RedeSocial_DDD_TDD.Dominio.Entidades;
using RedeSocial_DDD_TDD.Dominio.Interfaces.Repositories;
using RedeSocial_DDD_TDD.Dominio.Interfaces.Servicos;
using RedeSocial_DDD_TDD.Dominio.Utils;

namespace RedeSocial_DDD_TDD.Dominio.Servicos
{
    public class PostagemServico : BaseServico<Postagem>, IPostagemServico
    {
        private readonly IPostagemRepositorio _postagemRepository;
        public PostagemServico(IPostagemRepositorio postagemRepositorio):base(postagemRepositorio)
        {
            _postagemRepository = postagemRepositorio;
        }


        public List<Postagem> ObterPostagensPeloEmail(string email)
        {
            ValidadorRegra.Novo().Quando(string.IsNullOrEmpty(email), "Email inválido").DispararExcecaoSeExistir();

            var listPostagens = _postagemRepository.ObterPostagensPeloEmail(email);

            return listPostagens;

        }

        public Postagem SalvarERetornarSalva(Postagem postagem)
        {
            postagem.SetarDataPublicacao(DateTime.Now);


            return _postagemRepository.SalvarERetornarSalva(postagem);

        }


    }
}