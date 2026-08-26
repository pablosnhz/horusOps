using AutoMapper;
using horusOps.Context;
using horusOps.Dtos.Proceso;
using horusOps.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace horusOps.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProcesoController : ControllerBase
    {
        private readonly HorusOpsDbContext _context;
        private readonly IMapper _mapper;

        public ProcesoController(HorusOpsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProcesoDto>>> ObtenerProcesos() 
        {
            var proceso = await _context.Proceso
                .Where(p => p.Activo)
                .ToListAsync();

            var procesodto = _mapper.Map<IEnumerable<ProcesoDto>>(proceso);

            return Ok(procesodto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProcesoDto>> ObtenerProceso(int id)
        {
            var proceso = await _context.Proceso
                .FirstOrDefaultAsync(p => p.IdProceso == id);

            if (proceso == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ProcesoDto>(proceso));
        }

        [HttpPost]
        public async Task<ActionResult<ProcesoDto>> CrearProceso(CrearProcesoDto dto)
        {
            var proceso = _mapper.Map<Proceso>(dto);

            proceso.Activo = true;
            proceso.FechaAlta = DateTime.Now;

            _context.Proceso.Add(proceso);
            await _context.SaveChangesAsync();

            var procesoDto = _mapper.Map<ProcesoDto>(proceso);

            return CreatedAtAction(
                    nameof(ObtenerProceso),
                    new { id = proceso.IdProceso },
                    procesoDto
                );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarProceso(int id, ActualizarProcesoDto dto)
        {
            var proceso = await _context.Proceso.FindAsync(id);

            if (proceso == null)
            {
                return NotFound();
            }

            _mapper.Map(dto, proceso);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarProceso(int id)
        {
            var proceso = await _context.Proceso.FindAsync(id);

            if(proceso == null)
            {
                return NotFound();
            }

            proceso.Activo = false;

            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
