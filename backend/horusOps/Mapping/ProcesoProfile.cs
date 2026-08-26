using AutoMapper;
using horusOps.Dtos.Proceso;
using horusOps.Entities;

namespace horusOps.Mapping
{
    public class ProcesoProfile : Profile
    {
        public ProcesoProfile() 
        {
            CreateMap<Proceso, ProcesoDto>();
            CreateMap<CrearProcesoDto, Proceso>();
            CreateMap<ActualizarProcesoDto, Proceso>();
        }
    }
}
