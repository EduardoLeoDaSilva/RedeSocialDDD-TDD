using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using RedeSocial_DDD_TDD.Dominio.Interfaces.Repositories;
using RedeSocial_DDD_TDD.Dominio.Interfaces.Servicos;
using RedeSocial_DDD_TDD.Dominio.Servicos;
using RedeSocial_DDD_TDD.Infra.Dados.Repositorios;
using RedeSocial_DDD_TDD.Aplicacao.Interfaces;
using RedeSocial_DDD_TDD.Aplicacao.Servicos;
using RedeSocial_DDD_TDD.Dominio.Interfaces;
using RedeSocial_DDD_TDD.Infra.Dados.Contexto;

namespace RedeSocial_DDD_TDD.Infra.Ioc
{
    public  static class InjetorDeDependencias
    {
        public static void InjetarDependencias(IServiceCollection services)
        {
            //servicos dominio
            services.AddTransient(typeof(IBaseServico<>), typeof(BaseServico<>));
            services.AddTransient<ILikeServico, LikeServico>();
            services.AddTransient<IPerfilServico, PerfilServico>();
            services.AddTransient<IPostagemServico, PostagemServico>();
            services.AddTransient<IUsuarioServico, UsuarioServico>();
            services.AddTransient<IFotoServico, FotoServico>();
            services.AddTransient<IComentarioServico, ComentarioServico>();

            //infra.dados
            services.AddTransient(typeof(IBaseRepositorio<>), typeof(BaseRepositorio<>));
            services.AddTransient<ILikeRepositorio, LikeRepositorio>();
            services.AddTransient<IPerfilRepositorio, PerfilRepositorio>();
            services.AddTransient<IPostagemRepositorio, PostagemRepositorio>();
            services.AddTransient<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddTransient<ILikePostagemRepositorio, LikePostagemRepositorio>();
            services.AddTransient<IFotoRepositorio, FotoRepositorio>();
            services.AddTransient<IComentarioRepositorio, ComentarioRepositorio>();

            //servicos.Aplicacao
            services.AddTransient(typeof(IBaseAppServico<,>), typeof(BaseAppServico<,>));
            services.AddTransient<IAppLikeServico, AppLikeServico>();
            services.AddTransient<IAppPostagemServico, AppPostagemServico>();
            services.AddTransient<IAppUsuarioAmigo, AppUsuarioAmigo>();
            services.AddTransient<IAppUsuarioServico, AppUsuarioServico>();
            services.AddTransient<IAppFotoServico, AppFotoServico>();
            services.AddTransient<IAppComentarioServico, AppComentarioServico>();


            services.AddTransient<IComitador, Comitador>();

        }
    }
}
