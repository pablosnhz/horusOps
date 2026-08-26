using AutoMapper;
using horusOps.Dtos.LogProceso;
using horusOps.Entities;

namespace horusOps.Mapping
{
    public class LogProcesoProfile : Profile
    {   
        public LogProcesoProfile() 
        {
            CreateMap<LogProceso, LogProcesoDto>();
            CreateMap<CrearLogProcesoDto, LogProceso>();
            CreateMap<ActualizarLogProcesoDto, LogProceso>();
        }
    }
}
