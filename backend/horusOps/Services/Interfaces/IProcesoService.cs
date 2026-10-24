using horusOps.Dtos.Proceso;

namespace horusOps.Services.Interfaces
{
    public interface IProcesoService
    {
        Task<ResultadoEjecucionDto> EjecutarProcesoAsync(int IdProceso);
    }
}
