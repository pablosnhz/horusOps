using horusOps.Entities;
using Microsoft.EntityFrameworkCore;

namespace horusOps.Context
{
    public class HorusOpsDbContext: DbContext
    {
        public HorusOpsDbContext(DbContextOptions<HorusOpsDbContext> options)
            : base(options) 
        { 
        }

        public DbSet<Empleado> Empleados => Set<Empleado>();
        public DbSet<Sucursal> Sucursales => Set<Sucursal>();
        public DbSet<Producto> Productos => Set<Producto>();
    }
}
