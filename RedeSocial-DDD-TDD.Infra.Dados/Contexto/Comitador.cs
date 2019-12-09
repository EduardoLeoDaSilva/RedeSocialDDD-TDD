using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RedeSocial_DDD_TDD.Dominio.Interfaces;

namespace RedeSocial_DDD_TDD.Infra.Dados.Contexto
{
    public class Comitador : IComitador
    {
        private  readonly AplicacaoContexto _context;
        public Comitador(AplicacaoContexto context)
        {
            _context = context;
        }

        public async Task Comitar()
        {
            await _context.SaveChangesAsync();
        }
    }
}
