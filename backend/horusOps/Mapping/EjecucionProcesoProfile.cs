using AutoMapper;
using horusOps.Dtos.EjecucionProceso;
using horusOps.Entities;

namespace horusOps.Mapping
{
    public class EjecucionProcesoProfile : Profile
    {
        public EjecucionProcesoProfile() 
        {
            CreateMap<EjecucionProceso, EjecucionProcesoDto>();
            CreateMap<CrearEjecucionProcesoDto, EjecucionProceso>();
            CreateMap<ActualizarEjecucionProcesoDto, EjecucionProceso>();
        }
    }
}
