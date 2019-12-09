using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedeSocial_DDD_TDD.Dominio.Entidades;
using RedeSocial_DDD_TDD.Dominio.Utils.Excecoes;
using Xunit;

namespace RedeSocial_DDD_TDD.DominioTest.Extencoes
{
    public static class ArgExceptionExtensao
    {
        public static void ComMensagem(this EntitadeExcecao exception, string mensagemEsperada)
        {

            if (exception.Mensagens.Any(x => x == mensagemEsperada))
            {
                Assert.True(true);
            }
            else
            {
                Assert.False(true, $"Esperava a mensagem {mensagemEsperada}");

            }
        }
    }
}
