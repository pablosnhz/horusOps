using AutoMapper;
using horusOps.Context;
using horusOps.Dtos.Sucursal;
using horusOps.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace horusOps.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SucursalesController : ControllerBase
    {
        private readonly HorusOpsDbContext _context;
        private readonly IMapper _mapper;

        public SucursalesController(HorusOpsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SucursalDto>>> ObtenerSucursales()
        {
            var sucursales = await _context.Sucursales
                .Where(s => s.Activo)
                .ToListAsync();

            var sucursalesDto = _mapper.Map<IEnumerable<SucursalDto>>(sucursales);

            return Ok(sucursalesDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SucursalDto>> ObtenerSucursal(int id)
        {
            var sucursal = await _context.Sucursales
                .FirstOrDefaultAsync(e => e.IdSucursal == id);

            if (sucursal == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<SucursalDto>(sucursal));
        }

        [HttpPost]
        public async Task<ActionResult<SucursalDto>> CrearSucursal(CrearSucursalDto dto)
        {
            var sucursal = _mapper.Map<Sucursal>(dto);

            sucursal.Activo = true;
            sucursal.FechaAlta = DateTime.UtcNow;

            _context.Sucursales.Add(sucursal);
            await _context.SaveChangesAsync();

            var sucursalDto = _mapper.Map<SucursalDto>(sucursal);

            return CreatedAtAction(
                  nameof(ObtenerSucursal),
                  new
                  {
                      id = sucursal.IdSucursal
                  },
                  sucursalDto
                );
        }

        [HttpPut("{id}")] 
        public async Task<IActionResult> ActualizarSucursal(int id, ActualizarSucursalDto dto) 
        { 
            var sucursal = await _context.Sucursales.FindAsync(id); 
            
            if (sucursal == null) 
            { 
                return NotFound(); 
            } 
            
            _mapper.Map(dto, sucursal); 

            await _context.SaveChangesAsync(); 
            return NoContent(); 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarSucursal(int id)
        {
            var sucural = await _context.Sucursales.FindAsync(id);

            if (sucural == null)
            {
                return NotFound();
            }

            sucural.Activo = false;

            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
