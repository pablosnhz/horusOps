using AutoMapper;
using horusOps.Context;
using horusOps.Dtos.Empleado;
using horusOps.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace horusOps.Controllers;

[ApiController]
[Route("api/[controller]")]

public class EmpleadosController : ControllerBase
{
    private readonly HorusOpsDbContext _context;
    private readonly IMapper _mapper;

    public EmpleadosController(HorusOpsDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EmpleadoDto>>> ObtenerEmpleados()
    {
        var empleados = await _context.Empleados
            .Where(e => e.Activo)
            .ToListAsync();

        var empleadosDto = _mapper.Map<IEnumerable<EmpleadoDto>>(empleados);

        return Ok(empleadosDto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EmpleadoDto>> ObtenerEmpleado(int id)
    {
        var empleado = await _context.Empleados
            .FirstOrDefaultAsync(e => e.IdEmpleado == id);

        if (empleado == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<EmpleadoDto>(empleado));
    }

    [HttpPost]
    public async Task<ActionResult<EmpleadoDto>> CrearEmpleado(CrearEmpleadoDto dto)
    {
        var empleado = _mapper.Map<Empleado>(dto);

        empleado.Activo = true;
        empleado.FechaAlta = DateTime.Now;

        _context.Empleados.Add(empleado);
        await _context.SaveChangesAsync();

        var empleadoDto = _mapper.Map<EmpleadoDto>(empleado);

        return CreatedAtAction(
                nameof(ObtenerEmpleado),
                new { id = empleado.IdEmpleado },
                empleadoDto
            );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> ActualizarEmpleado(int id, ActualizarEmpleadoDto dto)
    {
        var empleado = await _context.Empleados.FindAsync(id);

        if (empleado == null)
        {
            return NotFound();
        }

        _mapper.Map(dto, empleado);

        await _context.SaveChangesAsync();

        return NoContent();
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> EliminarEmpleado(int id)
    {
        var empleado = await _context.Empleados.FindAsync(id);

        if(empleado == null)
        {
            return NotFound();
        }

        empleado.Activo = false;

        await _context.SaveChangesAsync();

        return NoContent();
    }
}
