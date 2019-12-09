using RedeSocial_DDD_TDD.Dominio.Entidades;
using RedeSocial_DDD_TDD.Dominio.Interfaces.Repositories;
using RedeSocial_DDD_TDD.Dominio.Interfaces.Servicos;
using RedeSocial_DDD_TDD.Dominio.Utils;

namespace RedeSocial_DDD_TDD.Dominio.Servicos
{
    public class UsuarioServico : BaseServico<Usuario>, IUsuarioServico
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioServico(IUsuarioRepositorio usuarioRepositorio):base(usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }


        public override void Salvar(Usuario usuario)
        {
            var usuarioExistente = _usuarioRepositorio.ObterPorEmail(usuario.Email);

            ValidadorRegra.Novo()
                .Quando(usuarioExistente != null,
                    "Já existe usuário com esse email").DispararExcecaoSeExistir();

            _usuarioRepositorio.Salvar(usuario);
        }

        public override void Atualizar(Usuario usuario)
        {
            var usuarioDoBanco = _usuarioRepositorio.ObterPorEmail(usuario.Email);

            ValidadorRegra.Novo().Quando(usuarioDoBanco == null, "Não existe esse usuário no sitesma").DispararExcecaoSeExistir();


            usuarioDoBanco.AlterarNascimento(usuario.Nascimento);
            usuarioDoBanco.AlterarSenha(usuario.Senha);

            _usuarioRepositorio.Atualizar(usuarioDoBanco);

        }

        public Usuario Entrar(string email, string senha)
        {
            ValidadorRegra.Novo().Quando(string.IsNullOrEmpty(email), "Email Invalido")
                .Quando(string.IsNullOrEmpty(senha), "Senha inválida").DispararExcecaoSeExistir();

            var usuarioDobanco = _usuarioRepositorio.Entrar(email, senha);
            ValidadorRegra.Novo().Quando(usuarioDobanco == null, "Não existe esse usuário no sitesma").DispararExcecaoSeExistir();

            return usuarioDobanco;
        }




    }
}