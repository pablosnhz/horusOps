using AutoMapper;
using horusOps.Dtos.Cliente;
using horusOps.Entities;

namespace horusOps.Mapping
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile() 
        {
            CreateMap<Cliente, ClienteDto>();
            CreateMap<CrearClienteDto, Cliente>();
            CreateMap<ActualizarClienteDto, Cliente>();
        }
    }
}
