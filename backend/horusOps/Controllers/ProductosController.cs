using AutoMapper;
using horusOps.Context;
using horusOps.Dtos.Producto;
using horusOps.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace horusOps.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly HorusOpsDbContext _context;
        private readonly IMapper _mapper;

        public ProductosController(HorusOpsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoDto>>> ObtenerProductos()
        {
            var productos = await _context.Productos
                .Where(p => p.Activo)
                .ToListAsync();

            var productosDto = _mapper.Map<IEnumerable<ProductoDto>>(productos);

            return Ok(productosDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoDto>> ObtenerProducto(int id)
        {
            var producto = await _context.Productos
                .FirstOrDefaultAsync(p => p.IdProducto == id);

            if (producto == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ProductoDto>(producto));
        }

        [HttpPost]
        public async Task<ActionResult<ProductoDto>> CrearProducto(CrearProductoDto dto)
        {
            var producto = _mapper.Map<Producto>(dto);

            producto.Activo = true;

            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();

            var productoDto = _mapper.Map<ProductoDto>(producto);

            return CreatedAtAction(
                    nameof(ObtenerProducto),
                    new { id = producto.IdProducto },
                    productoDto
                );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarProducto(int id, ActualizarProductoDto dto)
        {
            var producto = await _context.Productos.FindAsync(id);

            if(producto  == null)
            {
                return NotFound();
            }

            _mapper.Map(dto, producto);

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarProducto(int id) 
        {
            var producto = await _context.Productos.FindAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            producto.Activo = false;

            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
