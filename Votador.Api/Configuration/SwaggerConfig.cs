using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Votador.Api.Configuration
{
    public static class SwaggerConfig
    {
        public static IServiceCollection ConfigurarSwagger(this IServiceCollection services)
        {
            // Configurando o serviço de documentação do Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Avaliador de Idéias",
                        Version = "v1",
                        Description = "API Asp.Net Core WebAPI criada para divulgação e seleção de novas idéias.",
                        Contact = new OpenApiContact
                        {
                            Name = "Rafael Brugiolo Souza",
                            Url = new Uri("https://www.linkedin.com/in/rafael-brugiolo/")
                        }
                    });
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerConfig(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Avaliador de Idéias");
            });

            return app;
        }   
    }
}
