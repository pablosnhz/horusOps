using horusOps.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace horusOps.Controllers;

[ApiController]
[Route("api/[controller]")]

public class EmpleadosController : ControllerBase
{
    private readonly HorusOpsDbContext _context;

    public EmpleadosController(HorusOpsDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerEmpleados()
    {
        var empleados = await _context.Empleados
            .Where(e => e.Activo)
            .ToListAsync();

        return Ok(empleados);
    }
}
