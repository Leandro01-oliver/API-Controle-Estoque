
using AutoMapper;
using Businnes.Data.Models;
using Data.Entity;

namespace Bussines.Mappings
{
    public class ConfigurationMapping : Profile
    {
        public ConfigurationMapping()
        {
            CreateMap<Usuario, UsuarioVm>().ReverseMap().PreserveReferences();
        }
    }
}
