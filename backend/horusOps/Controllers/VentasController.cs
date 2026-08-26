using AutoMapper;
using horusOps.Context;
using horusOps.Dtos.Venta;
using horusOps.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace horusOps.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentasController : ControllerBase
    {
        private readonly HorusOpsDbContext _context;
        private readonly IMapper _mapper;

        public VentasController(HorusOpsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VentaDto>>> ObtenerVentas()
        {
            var ventas = await _context.Ventas
                .ToListAsync();

            var ventasDto = _mapper.Map<IEnumerable<VentaDto>>(ventas);

            return Ok(ventasDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VentaDto>> ObtenerVenta(int id)
        {
            var venta = await _context.Ventas
                .FirstOrDefaultAsync(v => v.IdVenta == id);

            if (venta == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<VentaDto>(venta));
        }

        [HttpPost]
        public async Task<ActionResult<CrearVentaDto>> CrearVenta(CrearVentaDto dto)
        {
            var venta = _mapper.Map<Venta>(dto);

            venta.FechaVenta = DateTime.Now;

            _context.Add(venta);
            await _context.SaveChangesAsync();

            var ventaDto = _mapper.Map<Venta>(venta);

            return CreatedAtAction(
                    nameof(ObtenerVenta),
                    new { id = venta.IdVenta },
                    ventaDto
                );
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ActualizarVentaDto>> ActualizarVenta(int id, ActualizarVentaDto dto)
        {
            var venta = await _context.Ventas.FindAsync(id);

            if (venta == null)
            {
                return NotFound();
            }

            _mapper.Map(dto, venta);

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> EliminarVenta(int id)
        {
            var venta = await _context.Ventas.FindAsync(id);

            if (venta == null)
            { 
                return NotFound();
            }

            _context.Ventas.Remove(venta);

            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
