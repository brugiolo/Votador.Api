using AutoMapper;
using Votador.Api.ViewModels;
using Votador.Business.Models;

namespace Votador.Api.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<RecursoVoto, RecursoVotoViewModel>().ReverseMap();
            CreateMap<Recurso, RecursoViewModel>().ReverseMap();
            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
            CreateMap<Voto, VotoViewModel>().ReverseMap();
        }
    }
}
