using AutoMapper;
using horusOps.Dtos.Producto;
using horusOps.Entities;

namespace horusOps.Mapping
{
    public class ProductoProfile : Profile
    {
        public ProductoProfile() 
        {
            CreateMap<Producto, ProductoDto>();
            CreateMap<CrearProductoDto, Producto>();
            CreateMap<ActualizarProductoDto, Producto>();
        }
    }
}
