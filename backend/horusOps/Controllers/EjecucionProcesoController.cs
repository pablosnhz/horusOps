using AutoMapper;
using horusOps.Context;
using horusOps.Dtos.EjecucionProceso;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace horusOps.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EjecucionProcesoController : ControllerBase
    {
        private readonly HorusOpsDbContext _context;
        private readonly IMapper _mapper;

        public EjecucionProcesoController(
            HorusOpsDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EjecucionProcesoDto>> ObtenerEjecucion(long id)
        {
            var ejecucion = await _context.EjecucionProceso
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.IdEjecucion == id);

            if (ejecucion == null)
                return NotFound();
            
            return Ok(_mapper.Map<EjecucionProcesoDto>(ejecucion));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EjecucionProcesoDto>>> ObtenerTodas()
        {
            var ejecuciones = await _context.EjecucionProceso
                .AsNoTracking()
                .ToListAsync();

            return Ok(_mapper.Map<IEnumerable<EjecucionProcesoDto>>(ejecuciones));
        }

    }
}
