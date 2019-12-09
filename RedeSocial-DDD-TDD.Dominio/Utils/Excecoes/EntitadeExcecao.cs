using System;
using System.Collections.Generic;
using System.Text;

namespace RedeSocial_DDD_TDD.Dominio.Utils.Excecoes
{
    public class EntitadeExcecao : ArgumentException
    {
        public List<string> Mensagens { get; private set; }


        public EntitadeExcecao(List<string> mensagens) 
        {
            Mensagens = mensagens;
        }

        
    }
}
