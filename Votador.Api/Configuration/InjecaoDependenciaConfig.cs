using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Votador.Business.Interfaces;
using Votador.Business.Services;
using Votador.Data.Context;
using Votador.Data.Repositorio;

namespace Votador.Api.Configuration
{
    public static class InjecaoDependenciaConfig 
    {
        public static IServiceCollection ResolverDependencias(this IServiceCollection services)
        {
            services.AddScoped<VotadorContext>();

            services.AddScoped<IRecursoRepositorio, RecursoRepositorio>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddScoped<IVotoRepositorio, VotoRepositorio>();

            services.AddScoped<IRecursoService, RecursoService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IVotoService, VotoService>();
            
            services.AddScoped<IMediator, Mediator>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddSwaggerGen();

            return services;
        }
    }
}
