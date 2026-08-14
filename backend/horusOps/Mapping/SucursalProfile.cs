using AutoMapper;
using horusOps.Dtos.Sucursal;
using horusOps.Entities;

namespace horusOps.Mapping
{
    public class SucursalProfile : Profile
    {
        public SucursalProfile()
        {
            CreateMap<Sucursal, SucursalDto>();
            CreateMap<CrearSucursalDto, Sucursal>();
            CreateMap<ActualizarSucursalDto, Sucursal>();
        }
    }
}
