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
        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Venta> Ventas => Set<Venta>();
        public DbSet<DetalleVentas> DetalleVentas => Set<DetalleVentas>();
        public DbSet<Cliente> Cliente => Set<Cliente>();
        public DbSet<Proceso> Proceso => Set<Proceso>();
        public DbSet<EjecucionProceso> EjecucionProceso => Set<EjecucionProceso>();
    }
}
