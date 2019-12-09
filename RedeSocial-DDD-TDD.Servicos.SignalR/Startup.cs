using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RedeSocial_DDD_TDD.Servicos.SignalR.HttpClientes.Clientes;
using RedeSocial_DDD_TDD.Servicos.SignalR.HttpClientes.Interfaces;
using RedeSocial_DDD_TDD.Servicos.SignalR.Hubs;

namespace RedeSocial_DDD_TDD.Servicos.SignalR
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddHttpClient<IPostagemHttpCliente, PostagemHttpCliente>(x =>
            {
                x.BaseAddress = new Uri("https://localhost:5001/api/Postagem");
                x.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                x.Timeout = TimeSpan.FromMinutes(1);
            });

            services.AddHttpClient<ILikeHttpClient, LikeHttpClient>(x =>
                {
                    x.BaseAddress = new Uri("https://localhost:5001/api/Like");
                    x.DefaultRequestHeaders.Accept.Clear();
                    x.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    x.Timeout = TimeSpan.FromMinutes(1);
                });

            services.AddHttpClient<IComentarioHttpClient, ComentarioHttpClient>(x =>
            {
                x.BaseAddress = new Uri("https://localhost:5001/api/Comentario/comentar");
                x.DefaultRequestHeaders.Accept.Clear();
                x.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                x.Timeout = TimeSpan.FromMinutes(1);
            });

            services.AddCors(t => t.AddPolicy("defaultPolicy", x =>

                x.AllowAnyHeader()
                    .AllowAnyMethod()
                    .WithOrigins("http://localhost:4200")
                    .AllowCredentials()));


            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors("defaultPolicy");
            app.UseSignalR(x => x.MapHub<HubLikePostagem>("/feed"));
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
