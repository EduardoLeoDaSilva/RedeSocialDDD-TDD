using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RedeSocial_DDD_TDD.AutoMapper;
using RedeSocial_DDD_TDD.Dominio.Interfaces;
using RedeSocial_DDD_TDD.Infra.Dados.Contexto;
using RedeSocial_DDD_TDD.Infra.Ioc;
using RedeSocial_DDD_TDD.Servicos.AplicacaoAPIs.Filters;

namespace RedeSocial_DDD_TDD.Servicos.AplicacaoAPIs
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            InjetorDeDependencias.InjetarDependencias(services);
            services.AddDbContext<AplicacaoContexto>(x => x.UseSqlServer(Configuration.GetConnectionString("Default"), s => s.MigrationsAssembly("RedeSocial-DDD-TDD.Servicos.AplicacaoAPIs")));
            services.AddMvc(x => x.Filters.Add(typeof(EntidadeExcecaoFiltro))).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddCors(x => x.AddPolicy("todosTudo", t =>
                {
                    t.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                    t.WithHeaders("Accept", "Content-type", "multipart/form-data");
                }));
            services.AddAutoMapper(x => x.AddProfile<MapeamentoEntidade>(), typeof(MapeamentoEntidade));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //app.Use(async (context, next) =>
            //{
            //    await next.Invoke();

            //    var comitador = (IComitador) context.RequestServices.GetService(typeof(IComitador));
            //   await comitador.Comitar();
            //});

            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials());
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
