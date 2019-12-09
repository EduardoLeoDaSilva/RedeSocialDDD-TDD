using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RedeSocial_DDD_TDD.Aplicacao.DTOs;
using RedeSocial_DDD_TDD.DTOs;
using RedeSocial_DDD_TDD.Servicos.SignalR.HttpClientes.Interfaces;

namespace RedeSocial_DDD_TDD.Servicos.SignalR.HttpClientes.Clientes
{
    public class ComentarioHttpClient : IComentarioHttpClient
    {
        private readonly HttpClient _comentarioHttpClient;
        public ComentarioHttpClient(HttpClient comentarioHttpClient)
        {
            _comentarioHttpClient = comentarioHttpClient;
        }

        public async Task<string> Comentar(ComentarioDTO comentario)
        {
          var response = await _comentarioHttpClient.PostAsync("", 
                new StringContent(JsonConvert.SerializeObject(comentario), Encoding.UTF8, "application/json"));

          if (response.IsSuccessStatusCode)
          {
              var postagemRetornada =await response.Content.ReadAsStringAsync();
              return postagemRetornada;
          }

          return "Erro ao tentar acessar a api comentario";
        }

    }
}
