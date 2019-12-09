using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using RedeSocial_DDD_TDD.Dominio.Utils.Excecoes;

namespace RedeSocial_DDD_TDD.Dominio.Utils
{
    public class ValidadorRegra
    {
        public List<string> ListaMensagensErro { get; set; }

        private ValidadorRegra()
        {
            ListaMensagensErro = new List<string>();
        }

        public static ValidadorRegra Novo()
        {
            return new ValidadorRegra();
        }

        public ValidadorRegra Quando(bool regra, string mensagem)
        {
            if (regra)
            {
                ListaMensagensErro.Add(mensagem);
            }



            return this;
        }

        public void DispararExcecaoSeExistir()
        {
            if (ListaMensagensErro.Count > 0)
                throw new EntitadeExcecao(ListaMensagensErro);
        }

        public ValidadorRegra RegExpQuando(string valorAComparar, string pattern, string mensagem)
        {
            var padrao = new Regex(pattern);
            if (valorAComparar != null)
            {
                if (padrao.IsMatch(valorAComparar) == false)
                {
                    ListaMensagensErro.Add(mensagem);
                }
            }
            

            return this;
        }
    }
}
