using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedeSocial_DDD_TDD.Dominio.Entidades;
using RedeSocial_DDD_TDD.Dominio.Interfaces.Repositories;
using RedeSocial_DDD_TDD.Infra.Dados.Contexto;

namespace RedeSocial_DDD_TDD.Infra.Dados.Repositorios
{
    public class UsuarioRepositorio : BaseRepositorio<Usuario>, IUsuarioRepositorio
    {
        private readonly AplicacaoContexto _contexto;
        public UsuarioRepositorio(AplicacaoContexto contexto) :base(contexto)
        {
            _contexto = contexto;
        }

        public Usuario Entrar(string email, string senha)
        {
           var usuario = _contexto.Usuario.SingleOrDefault(x => x.Email == email && x.Senha == senha);
           return usuario;
        }

        public Usuario ObterPorEmail(string email)
        {
            var usuario = _contexto.Usuario.SingleOrDefault(x => x.Email == email);
            return usuario;
        }
    }
}
