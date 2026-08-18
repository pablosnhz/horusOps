using AutoMapper;
using horusOps.Context;
using horusOps.Dtos.DetalleVenta;
using horusOps.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace horusOps.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DetalleVentasController : ControllerBase
    {
        private readonly HorusOpsDbContext _context;
        private readonly IMapper _mapper;

        public DetalleVentasController(HorusOpsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleVentaDto>>> ObtenerDetalleVentas()
        {
            var detalleVentas = await _context.DetalleVentas
                .ToListAsync();

            var detalleVentasDto = _mapper.Map<IEnumerable<DetalleVentaDto>>(detalleVentas);

            return Ok(detalleVentasDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleVentaDto>> ObtenerDetalleVenta(int id)
        {
            var detalleVenta = await _context.DetalleVentas
                .FirstOrDefaultAsync(d => d.IdDetalleVenta == id);

            if (detalleVenta == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<DetalleVentaDto>(detalleVenta));
        }

        [HttpPost]
        public async Task<ActionResult<CrearDetalleVentaDto>> CrearDetalleVenta(CrearDetalleVentaDto dto)
        {
            var detalleVenta = _mapper.Map<DetalleVentas>(dto);

            _context.Add(detalleVenta);
            await _context.SaveChangesAsync();

            var detalleVentaDto = _mapper.Map<DetalleVentaDto>(detalleVenta);

            return CreatedAtAction(
                    nameof(ObtenerDetalleVenta),
                    new { id = detalleVenta.IdDetalleVenta },
                    detalleVentaDto
                );
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ActualizarDetalleVentaDto>> ActualizarDetalleVenta(int id, ActualizarDetalleVentaDto dto)
        {
            var detalleVenta = await _context.DetalleVentas.FindAsync(id);

            if (detalleVenta == null)
            { 
                return NotFound();
            }

            _mapper.Map(dto, detalleVenta);

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> EliminarDetalleVenta(int id)
        {
            var detalleVenta = await _context.DetalleVentas.FindAsync(id);

            if(detalleVenta == null)
            {
                return NotFound();
            }

            _context.DetalleVentas.Remove(detalleVenta);

            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
