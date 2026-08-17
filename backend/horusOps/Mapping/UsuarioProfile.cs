using AutoMapper;
using horusOps.Dtos.Usuario;
using horusOps.Entities;

namespace horusOps.Mapping
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile() 
        {
            CreateMap<Usuario, UsuarioDto>();
            CreateMap<CrearUsuarioDto, Usuario>();
            CreateMap<ActualizarUsuarioDto, Usuario>();
        }
    }
}
