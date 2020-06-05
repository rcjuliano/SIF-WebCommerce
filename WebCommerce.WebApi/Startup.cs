using System;
using Aula09.Servico;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WebCommerce.Dados;
using WebCommerce.Dominio.Interfaces;

namespace Aula09.WebApi
{
    /// <summary>
    /// Startup
    /// </summary>
    public class Startup
    {

        /// <summary>
        /// Startup
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IProdutoServico, ProdutoServico>();
            services.AddTransient<IProdutoRepositorio, ProdutoRepositorio>();
            services.AddScoped(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));

            services.AddCors();
            services.AddControllers();

            //services.AddAuthorization((x) => x.AddPolicy("AutenticacaoBasica"));

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "WebCommerce da disciplina de Lab 2 - 2020",
                        Version = "v1",
                        Description = "Projeto de WebApi - Descritivo",
                        Contact = new OpenApiContact
                        {
                            Name = "Sistemas de Informação 2020",
                            Url = new Uri("https://github.com/rcjuliano")
                        }
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x =>
                x.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );

            // Ativando middlewares para uso do Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebCommerce - v1");
            });

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
