using System;
using System.Collections.Generic;
using RedeSocial_DDD_TDD.Dominio.Utils;

namespace RedeSocial_DDD_TDD.Dominio.Entidades
{
    public class Usuario: EntidadeBase
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public DateTime Nascimento { get; private set; }
        public string Senha { get; private set; }
        public int Idade { get; private set; }

        public byte[] FotoPerfil { get; private set; }

        public Usuario(string nome, string email,  DateTime nascimento, string senha)
        {

            ValidadorRegra.Novo()
                .Quando(string.IsNullOrEmpty(nome),
                    "Nome inválido - Campo Vazio")
                .Quando(string.IsNullOrEmpty(email),
                    "Email inválido - Campo vazio")
                .RegExpQuando(email, "[a-zA-Z0-9]+@[a-zA-Z0-9]{3,10}\\.com",
                    "Formato email inválido")
                .Quando(string.IsNullOrEmpty(senha) || senha.Length < 5,
                    "Senha inválida - Deve ter no minimo 5 caracteres")
                .Quando(ObterIdade(nascimento) < 18, "Idade não permitida - Somente 18+")
                .Quando(nome != null && senha != null &&senha.Contains(nome), "Senha não pode conter seu nome").DispararExcecaoSeExistir();

            Nome = nome;
            Email = email;
            Nascimento = nascimento;
            Senha = senha;
            Idade = ObterIdade(nascimento);
        }


        private Usuario()
        {
            
        }

        public void SetarFotoPerfil(byte[] fotoPerfil)
        {
            this.FotoPerfil = fotoPerfil;
        }

        public int ObterIdade(DateTime nascimento)
        {
            var anos = DateTime.Now.Year - nascimento.Year;
            var meses = DateTime.Now.Month - nascimento.Month;
            var days =   nascimento.Day -DateTime.Now.Day;
            var idadeCalculo = (anos) - (meses * 0.4) - (days * 0.013);
            var idade= Convert.ToInt32(Math.Floor(idadeCalculo));
            return idade;
        }

        public void AlterarNascimento(DateTime nascimento)
        {
            ValidadorRegra.Novo().Quando(ObterIdade(nascimento) < 18, "Idade não permitida - Somente 18+");
            Nascimento = nascimento;
        }

        public void AlterarSenha(string senha)
        {
            ValidadorRegra.Novo()
                .Quando(senha.Contains(Nome),
                    "Senha não pode conter seu nome")
                .Quando(string.IsNullOrEmpty(senha) || senha.Length < 5,
                    "Senha inválida - Deve ter no minimo 5 caracteres");

            Senha = senha;
        }
    }
}