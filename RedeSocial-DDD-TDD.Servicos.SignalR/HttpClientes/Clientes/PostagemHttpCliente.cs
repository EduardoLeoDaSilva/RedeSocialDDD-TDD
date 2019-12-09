using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RedeSocial_DDD_TDD.DTOs;
using RedeSocial_DDD_TDD.Servicos.SignalR.HttpClientes.Interfaces;
using MediaTypeHeaderValue = Microsoft.Net.Http.Headers.MediaTypeHeaderValue;

namespace RedeSocial_DDD_TDD.Servicos.SignalR.HttpClientes.Clientes
{
    public class PostagemHttpCliente : IPostagemHttpCliente
    {

        private readonly HttpClient _httpClient;

        public PostagemHttpCliente(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<string> SalvarEObterPostagemAsync(PostagemDTO postagem)
        {
            var request = new MultipartFormDataContent("root");
            foreach (var foto in postagem.Fotos)
            {
                var imagemStream = foto.Imagem.OpenReadStream();

            var memoryStream = new MemoryStream();

                    request.Add(new StreamContent(imagemStream) ,foto.Imagem.Name, foto.Imagem.FileName);
                
            }
            request.Add(new StringContent(postagem.Texto,Encoding.UTF8),"texto");
            request.Add(new StringContent(postagem.Usuario.Id.ToString(),Encoding.UTF8), "usuario.id");

            var retorno= await _httpClient.PostAsync("", request);
           if (retorno.IsSuccessStatusCode)
           {
               return await retorno.Content.ReadAsStringAsync();

           }
           return "Um erro ocorreu";
        }

    }
}
