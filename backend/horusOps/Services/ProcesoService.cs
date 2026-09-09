using horusOps.Context;
using horusOps.Services.Interfaces;

namespace horusOps.Services
{
    public class ProcesoService : IProcesoService
    {
        private readonly HorusOpsDbContext _context;

        public ProcesoService(HorusOpsDbContext context) 
        { 
            _context = context;
        }

        public async Task EjecutarProceso(int IdProceso) 
        { 
            
        }
    }
}
