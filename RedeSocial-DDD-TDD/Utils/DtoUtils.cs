using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using RedeSocial_DDD_TDD.Aplicacao.DTOs;
using RedeSocial_DDD_TDD.Dominio.Entidades;
using RedeSocial_DDD_TDD.DTOs;

namespace RedeSocial_DDD_TDD.Aplicacao.Utils
{
    public static class DtoUtils
    {
        public static byte[] ParaFotoEntidade(this IFormFile foto)
        {
            if (foto != null)
            {
                using (var reader = foto.OpenReadStream())
                using (var memoryStream = new MemoryStream())
                {
                    reader.CopyTo(memoryStream);
                    return memoryStream.ToArray();
                }
            }
            throw new ArgumentException("A parametro foto passada é nulo");
        }

        public static List<FotoDTO> ObterListaFotosDeIFormCollection(this IFormFileCollection fotos)
        {
            var listaFotosDto = new List<FotoDTO>();

            foreach (var foto in fotos)
            {
                listaFotosDto.Add(new FotoDTO(foto, foto.FileName, null));
            }

            return listaFotosDto;
        }


        public static List<Foto> ObterListaFotoDeDTOParMapper(this PostagemDTO postagem)
        {
            var lista = new List<Foto>();
            foreach (var item in postagem.Fotos)
            {
                lista.Add(new Foto(item.Imagem.ParaFotoEntidade(), item.Nome,  null));
            }

            return lista;
        }
    }
}
