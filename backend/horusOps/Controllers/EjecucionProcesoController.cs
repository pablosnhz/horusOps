using AutoMapper;
using horusOps.Context;
using horusOps.Dtos.EjecucionProceso;
using horusOps.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace horusOps.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EjecucionProcesoController : ControllerBase
    {
        private readonly HorusOpsDbContext _context;
        private readonly IMapper _mapper;

        public EjecucionProcesoController(HorusOpsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EjecucionProcesoDto>>> ObtenerEjecucionProcesos()
        {
            var ejecucionProcesos = await _context.EjecucionProceso
                .ToListAsync();

            var ejecucionProcesosDto = _mapper.Map<IEnumerable<EjecucionProcesoDto>>(ejecucionProcesos);

            return Ok(ejecucionProcesosDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EjecucionProcesoDto>> ObtenerEjecucionProceso(long id)
        {
            var ejecucionProcesos = await _context.EjecucionProceso
                .FirstOrDefaultAsync(e => e.IdEjecucion == id);

            if (ejecucionProcesos == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<EjecucionProcesoDto>(ejecucionProcesos));
        }

        [HttpPost]
        public async Task<ActionResult<EjecucionProcesoDto>> CrearEjecucionProceso(CrearEjecucionProcesoDto dto)
        {
            var ejecucionProceso = _mapper.Map<EjecucionProceso>(dto);

            _context.Add(ejecucionProceso);
            await _context.SaveChangesAsync();

            var ejecucionProcesoDto = _mapper.Map<EjecucionProcesoDto>(ejecucionProceso);

            return CreatedAtAction(
                    nameof(ObtenerEjecucionProceso),
                    new { id = ejecucionProceso.IdEjecucion },
                    ejecucionProcesoDto
                );
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ActualizarEjecucionProcesoDto>> ActualizarEjecucionProceso(int id, ActualizarEjecucionProcesoDto dto)
        {
            var ejecucionProceso = await _context.EjecucionProceso.FindAsync(id);

            if (ejecucionProceso == null)
            {
                return NotFound();
            }

            _mapper.Map(dto, ejecucionProceso);

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> EliminarEjecucionProceso(int id)
        {
            var ejecucionProceso = await _context.EjecucionProceso.FindAsync(id);

            if (ejecucionProceso == null)
            {
                return NotFound();
            }

            _context.EjecucionProceso.Remove(ejecucionProceso);

            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
