using System;
using System.Collections.Generic;
using System.Text;

namespace RedeSocial_DDD_TDD.Dominio.Entidades
{
    public abstract class EntidadeBase
    {
        public int Id { get; protected set; }

        protected EntidadeBase()
        {
            
        }

        protected EntidadeBase(int id)
        {
            Id = id;
        }

        public void SetarId(int id)
        {
            this.Id = id;
        }
    }
}
