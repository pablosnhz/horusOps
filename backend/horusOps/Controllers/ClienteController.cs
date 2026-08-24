using AutoMapper;
using horusOps.Context;
using horusOps.Dtos.Cliente;
using horusOps.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace horusOps.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly HorusOpsDbContext _context;
        private readonly IMapper _mapper;

        public ClienteController(HorusOpsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDto>>> ObtenerClientes()
        {
            var clientes = await _context.Cliente
                .ToListAsync();

            var clientesDto = _mapper.Map<IEnumerable<ClienteDto>>(clientes);

            return Ok(clientesDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDto>> ObtenerCliente(int id)
        {
            var cliente = await _context.Cliente
                .FirstOrDefaultAsync(c => c.IdCliente == id);

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ClienteDto>(cliente));
        }

        [HttpPost]
        public async Task<ActionResult<ClienteDto>> CrearCliente(CrearClienteDto dto)
        {
            var cliente = _mapper.Map<Cliente>(dto);

            cliente.FechaAlta = DateTime.Now;

            _context.Add(cliente);
            await _context.SaveChangesAsync();

            var clienteDto = _mapper.Map<ClienteDto>(cliente);

            return CreatedAtAction(
                    nameof(ObtenerCliente),
                    new { id = cliente.IdCliente },
                    clienteDto
                );
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ActualizarClienteDto>> ActualizarCliente(int id, ActualizarClienteDto dto)
        {
            var cliente = await _context.Cliente.FindAsync(id);

            if(cliente == null)
            {
                return NotFound();
            }

            _mapper.Map(dto,cliente);

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> EliminarCliente(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);

            if(cliente == null)
            {
                return NotFound();
            }

            _context.Cliente.Remove(cliente);

            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
