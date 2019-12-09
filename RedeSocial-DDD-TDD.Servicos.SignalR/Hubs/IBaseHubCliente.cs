using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedeSocial_DDD_TDD.Servicos.SignalR.Hubs
{
    public interface IBaseHubCliente
    {
        Task EnviarMensagensParaTodos(string metodo, string msg);
    }
}
