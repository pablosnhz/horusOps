using AutoMapper;
using horusOps.Context;
using horusOps.Dtos.Usuario;
using horusOps.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace horusOps.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly HorusOpsDbContext _context;
        private readonly IMapper _mapper;

        public UsuariosController(HorusOpsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> ObtenerUsuarios()
        {
            var usuarios = await _context.Usuarios
                .Where(u => u.Activo)
                .ToListAsync();

            var usuariosDto = _mapper.Map<IEnumerable<UsuarioDto>>(usuarios);

            return Ok(usuariosDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDto>> ObtenerUsuario(int id)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.IdUsuario == id);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<UsuarioDto>(usuario));
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioDto>> CrearUsuario(CrearUsuarioDto dto)
        {
            var usuario = _mapper.Map<Usuario>(dto);

            usuario.Activo = true;
            usuario.FechaAlta = DateTime.Now;

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            var usuarioDto = _mapper.Map<UsuarioDto>(usuario);

            return CreatedAtAction(
                    nameof(ObtenerUsuario),
                    new { id = usuario.IdUsuario },
                    usuarioDto
                ); 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarUsuario(int id, ActualizarUsuarioDto dto)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            _mapper.Map(dto, usuario);

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if(usuario == null)
            {
                return NotFound();
            }

            usuario.Activo = false;

            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
