using AutoMapper;
using horusOps.Dtos.DetalleVenta;
using horusOps.Entities;

namespace horusOps.Mapping
{
    public class DetalleVentaProfile : Profile
    {
        public DetalleVentaProfile()
        {
            CreateMap<DetalleVentas, DetalleVentaDto>();
            CreateMap<CrearDetalleVentaDto, DetalleVentas>();
            CreateMap<ActualizarDetalleVentaDto, DetalleVentas>();
        }
    }
}
