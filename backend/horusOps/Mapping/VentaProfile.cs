using AutoMapper;
using horusOps.Dtos.Venta;
using horusOps.Entities;

namespace horusOps.Mapping
{
    public class VentaProfile : Profile
    {
        public VentaProfile() 
        {
            CreateMap<Venta, VentaDto>();
            CreateMap<CrearVentaDto, Venta>();
            CreateMap<ActualizarVentaDto,Venta>();
        }
    }
}
