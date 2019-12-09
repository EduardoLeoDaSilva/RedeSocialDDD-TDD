using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RedeSocial_DDD_TDD.Dominio.Utils.Excecoes;

namespace RedeSocial_DDD_TDD.Servicos.AplicacaoAPIs.Filters
{
    public class EntidadeExcecaoFiltro : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var isAjax = context.HttpContext.Request.Headers["x-requested-width"] == "XMLHttpRequest";

            if (isAjax)
            {
                context.HttpContext.Response.ContentType = "application/json";
                context.HttpContext.Response.StatusCode = context.Exception is EntitadeExcecao ? 502 : 500;
                context.Result = context.Exception is EntitadeExcecao entitadeExcecao
                    ? new JsonResult(entitadeExcecao.Mensagens)
                    : new JsonResult("Um erro Ocorreu");
                context.ExceptionHandled = true;
            }

            base.OnException(context);
        }
    }
}
