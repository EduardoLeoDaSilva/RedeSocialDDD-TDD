using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RedeSocial_DDD_TDD.DTOs;
using RedeSocial_DDD_TDD.Servicos.SignalR.HttpClientes.Interfaces;

namespace RedeSocial_DDD_TDD.Servicos.SignalR.HttpClientes.Clientes
{
    public class LikeHttpClient : ILikeHttpClient
    {
        private readonly HttpClient _httpClient;
        public LikeHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> AtualizarLike(PostagemDTO postagem)
        {
            var response = await _httpClient.PostAsync("",
                new StringContent(JsonConvert.SerializeObject(postagem), Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                var likeJson =await response.Content.ReadAsStringAsync();
                return likeJson;
            }

            return "Um erro correu";
        }

    }
}
