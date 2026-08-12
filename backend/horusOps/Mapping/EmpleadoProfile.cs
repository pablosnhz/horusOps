
using AutoMapper;
using horusOps.Dtos.Empleado;
using horusOps.Entities;

namespace horusOps.Mapping
{
    public class EmpleadoProfile : Profile
    {
        public EmpleadoProfile() 
        {
            CreateMap<Empleado, EmpleadoDto>();
            CreateMap<CrearEmpleadoDto, Empleado>();
            CreateMap<ActualizarEmpleadoDto, Empleado>();
        }
    }
}
