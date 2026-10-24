using AutoMapper;
using horusOps.Context;
using horusOps.Dtos.LogProceso;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace horusOps.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogProcesoController : ControllerBase
    {
        private readonly HorusOpsDbContext _context;
        private readonly IMapper _mapper;

        public LogProcesoController(
            HorusOpsDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LogProcesoDto>>> ObtenerLogs() 
        {
            var logs = await _context.LogProceso
                .AsNoTracking()
                .ToListAsync();

            var logsDto = _mapper.Map<IEnumerable<LogProcesoDto>>(logs);

            return Ok(logsDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LogProcesoDto>> ObtenerLog(long id)
        {
            var log = await _context.LogProceso
                .AsNoTracking()
                .FirstOrDefaultAsync(l => l.IdLog == id);

            if (log == null) 
                return NotFound();

            return Ok(_mapper.Map<LogProcesoDto>(log));
        }
    }
}
