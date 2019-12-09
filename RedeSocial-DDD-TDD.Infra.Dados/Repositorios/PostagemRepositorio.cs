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
    public class PostagemRepositorio : BaseRepositorio<Postagem>, IPostagemRepositorio
    {
        private readonly AplicacaoContexto _contexto;
        public PostagemRepositorio(AplicacaoContexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public List<Postagem> ObterPostagensPeloEmail(string email)
        {
            var postagens = _contexto.Postagem.Where(x => x.Usuario.Email == email).Include(x => x.Usuario)
                .Include(x => x.LikePostagens).ThenInclude(x => x.Like).ToList();

            return postagens;
        }

        public override IList<Postagem> ObterTodos()
        {
            var postagens = _contexto.Postagem.Include(x => x.LikePostagens).ThenInclude(x => x.Like).Include(x => x.Usuario).Include(x => x.Comentarios).ThenInclude(x => x.Usuario).Include(x => x.Fotos).ToList();
            return postagens;
        }

        public Postagem SalvarERetornarSalva(Postagem postagem)
        {
            _contexto.Postagem.Add(postagem);
            _contexto.SaveChanges();
            return postagem;
        }

        public override Postagem ObterPorId(int id)
        {
            return _contexto.Postagem.Where(x => x.Id == id).Include(x => x.Usuario).Include(x => x.LikePostagens)
                .ThenInclude(x => x.Like).Include(x => x.Comentarios).ThenInclude(x => x.Usuario).Include(x => x.Fotos).SingleOrDefault();
        }
    }
}
