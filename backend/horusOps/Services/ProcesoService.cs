using horusOps.Context;
using horusOps.Dtos.Proceso;
using horusOps.Entities;
using horusOps.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace horusOps.Services
{
    public class ProcesoService : IProcesoService
    {
        private readonly HorusOpsDbContext _context;
        private readonly ILogger<ProcesoService> _logger;

        public ProcesoService(HorusOpsDbContext context, ILogger<ProcesoService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<ResultadoEjecucionDto> EjecutarProcesoAsync(int IdProceso)
        {
            var proceso = await _context.Proceso
                .FirstOrDefaultAsync(p =>
                    p.IdProceso == IdProceso &&
                    p.Activo);

            if (proceso == null)
            {
                throw new Exception(
                    "El proceso no existe o esta inactivo.");
            }

            var ejecucion = new EjecucionProceso
            {
                IdProceso = proceso.IdProceso,
                FechaInicio = DateTime.Now,
                EstadoEjecucion = "EN_PROCESO",
                RegistrosProcesados = 0,
                CantidadErrores = 0,
            };

            _context.EjecucionProceso.Add(ejecucion);
            await _context.SaveChangesAsync();

            try
            {
                var ventas = await _context.Ventas
                    .AsTracking()
                    .ToListAsync();

                var random = new Random();

                foreach (var venta in ventas)
                {
                    var ocurrioError =
                        random.Next(0, 100) < proceso.ProbabilidadError;

                    LogProceso log;

                    if (ocurrioError)
                    {
                        ejecucion.CantidadErrores++;

                        log = new LogProceso
                        {
                            IdEjecucion = ejecucion.IdEjecucion,
                            FechaLog = DateTime.Now,
                            NivelLog = "ERROR",
                            MensajeLog =
                                $"Error al procesar venta {venta.IdVenta}.",
                            DetalleError =
                                "Error simulado durante el procesamiento."
                        };
                    }
                    else
                    {
                        ejecucion.RegistrosProcesados++;

                        log = new LogProceso
                        {
                            IdEjecucion = ejecucion.IdEjecucion,
                            FechaLog = DateTime.Now,
                            NivelLog = "INFO",
                            MensajeLog =
                                $"Venta {venta.IdVenta} procesada correctamente.",
                            DetalleError = null
                        };
                    }

                    _context.LogProceso.Add(log);
                }

                ejecucion.FechaFin = DateTime.Now;
                ejecucion.EstadoEjecucion =
                    ejecucion.CantidadErrores > 0
                        ? "COMPLETADO_CON_ERRORES"
                        : "COMPLETADO";

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Falló la ejecución del proceso {IdProceso}. " +
                    "Ejecución: {IdEjecucion}.",
                    proceso.IdProceso,
                    ejecucion.IdEjecucion);

                ejecucion.FechaFin = DateTime.Now;
                ejecucion.EstadoEjecucion = "ERROR";

                _context.LogProceso.Add(new LogProceso
                {
                    IdEjecucion = ejecucion.IdEjecucion,
                    FechaLog = DateTime.Now,
                    NivelLog = "ERROR",
                    MensajeLog = "La ejecución del proceso falló.",
                    DetalleError = ex.ToString()
                });

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception persistenciaEx)
                {
                    _logger.LogError(
                        persistenciaEx,
                        "No se pudo guardar el estado ERROR ni el log " +
                        "de la ejecución {IdEjecucion}.",
                        ejecucion.IdEjecucion);
                }

                throw;
            }

            return new ResultadoEjecucionDto
            {
                IdEjecucion = ejecucion.IdEjecucion,
                EstadoEjecucion = ejecucion.EstadoEjecucion,
                RegistrosProcesados = ejecucion.RegistrosProcesados,
                CantidadErrores = ejecucion.CantidadErrores,
            };
        }
    }
}
