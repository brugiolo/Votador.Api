using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Votador.Api.ViewModels;
using Votador.Business.Models;

namespace Votador.Api.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Recurso, UsuarioViewModel>().ReverseMap();
        }
    }
}
