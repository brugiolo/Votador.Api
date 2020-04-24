using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Votador.Business.Interfaces;
using Votador.Business.Services;
using Votador.Data.Context;
using Votador.Data.Repositorio;

namespace Votador.Api.Controllers
{
    public static class InjecaoDependenciaConfig 
    {
        public static IServiceCollection ResolverDependencias(this IServiceCollection services)
        {
            services.AddScoped<VotadorContext>();

            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

            services.AddScoped<IUsuarioService, UsuarioService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            return services;
        }
    }
}
