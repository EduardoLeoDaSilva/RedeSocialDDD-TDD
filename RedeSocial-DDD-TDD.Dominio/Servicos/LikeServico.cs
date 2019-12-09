using System.Collections.Generic;
using System.Linq;
using RedeSocial_DDD_TDD.Dominio.Entidades;
using RedeSocial_DDD_TDD.Dominio.Interfaces.Repositories;
using RedeSocial_DDD_TDD.Dominio.Interfaces.Servicos;
using RedeSocial_DDD_TDD.Dominio.Utils;

namespace RedeSocial_DDD_TDD.Dominio.Servicos
{
    public class LikeServico : BaseServico<Like>, ILikeServico
    {
        private readonly ILikeRepositorio _likeRepositorio;
        private readonly ILikePostagemRepositorio _likePostagemRepositorio;
        private readonly IPostagemRepositorio _postagemRepositorio;
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public LikeServico(ILikeRepositorio likeRepositorio, ILikePostagemRepositorio likePostagemRepositorio, IPostagemRepositorio postagemRepositorio, IUsuarioRepositorio usuarioRepositorio) : base(likeRepositorio)
        {
            _likeRepositorio = likeRepositorio;
            _likePostagemRepositorio = likePostagemRepositorio;
            _postagemRepositorio = postagemRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
        }

        public override void Salvar(Like like)
        {
            var esseLikeJaFoiDado = JaFoiLiked(like);

            ValidadorRegra.Novo().Quando(esseLikeJaFoiDado, "Não pode dar mais de um like para uma mesma postagem!").DispararExcecaoSeExistir();

            base.Salvar(like);
        }


        public Like ObterTodosLikePorUsuarioId(int idUsuario)
        {
            return _likeRepositorio.ObterTodosLikePorUsuarioId(idUsuario);
        }

        public bool JaFoiLiked(Like like)
        {
            if (like.LikePostagens.Count <= 0)
                return false;
            var postagemLike = like.LikePostagens.First();
            var likeVindoDoBanco = _likeRepositorio.ObterPorId(like.Id);

            if (likeVindoDoBanco.LikePostagens.Any(x =>
                 x.LikeId == like.Id && x.PostagemId == postagemLike.PostagemId))
                return true;
            return false;

        }

        public Postagem AtualizarQuantLike(Postagem postagem)
        {
            var likeUser = _likeRepositorio.ObterTodosLikePorUsuarioId(postagem.Usuario.Id);

            if (likeUser != null)
            {
                var likePostagemParaAdd = new LikePostagem(0, postagem.Id, likeUser, null);

                if (likeUser.LikePostagens.Any(x => x.LikeId == likeUser.Id && x.PostagemId == postagem.Id))
                    _likePostagemRepositorio.Excluir(likeUser.LikePostagens.SingleOrDefault(x => x.LikeId == likeUser.Id && x.PostagemId == postagem.Id));
                else
                    likeUser.LikePostagens.Add(likePostagemParaAdd);

                _likeRepositorio.Atualizar(likeUser);
            }
            else
            {
                var usuarioDoBanco = _usuarioRepositorio.ObterPorId(postagem.Usuario.Id);
                var postagemDobanco = _postagemRepositorio.ObterPorId(postagem.Id);
                var like = new Like(usuarioDoBanco, new List<LikePostagem> { new LikePostagem(0, postagem.Id, null, postagemDobanco) });
                _likeRepositorio.Salvar(like);
            }

            return _postagemRepositorio.ObterPorId(postagem.Id);
        }
    }
}