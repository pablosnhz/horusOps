using AutoMapper;
using horusOps.Context;
using horusOps.Dtos.Venta;
using horusOps.Entities;
using horusOps.Services;
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
        private readonly VentaService _ventaService;

        public VentasController(HorusOpsDbContext context, IMapper mapper, VentaService ventaService)
        {
            _context = context;
            _mapper = mapper;
            _ventaService = ventaService;
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
        public async Task<ActionResult<VentaDto>> CrearVenta(CrearVentaDto dto)
        {
            var ventaDto = await _ventaService.CrearVentaAsync(dto);

            return CreatedAtAction(
                    nameof(ObtenerVenta),
                    new { id = ventaDto.IdVenta },
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
