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
        public DbSet<LogProceso> LogProceso => Set<LogProceso>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DetalleVentas>()
                .Property(d => d.PrecioUnitario)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Producto>()
                .Property(p => p.PrecioProducto)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Venta>()
                .Property(v => v.ImporteTotal)
                .HasPrecision(10, 2);

            modelBuilder.Entity<EjecucionProceso>()
    .HasOne(e => e.Proceso)
    .WithMany(p => p.Ejecuciones)
    .HasForeignKey(e => e.IdProceso)
    .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Empleado>()
                .HasOne(e => e.Sucursal)
                .WithMany(s => s.Empleados)
                .HasForeignKey(e => e.IdSucursal)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<LogProceso>()
                .HasOne(l => l.Ejecucion)
                .WithMany(e => e.Logs)
                .HasForeignKey(l => l.IdEjecucion)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Empleados)
                .WithMany()
                .HasForeignKey(u => u.IdEmpleado)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Venta>()
                .HasOne(v => v.Cliente)
                .WithMany(c => c.Ventas)
                .HasForeignKey(v => v.idCliente)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Venta>()
                .HasOne(v => v.Empleado)
                .WithMany(e => e.Ventas)
                .HasForeignKey(v => v.idEmpleado)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Venta>()
                .HasOne(v => v.Sucursal)
                .WithMany(s => s.Ventas)
                .HasForeignKey(v => v.idSucursal)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<DetalleVentas>()
                .HasOne(d => d.Venta)
                .WithMany(v => v.Detalles)
                .HasForeignKey(d => d.IdVenta)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<DetalleVentas>()
                .HasOne(d => d.ProductoNavegacion)
                .WithMany(p => p.DetallesVenta)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Cliente>()
                .HasIndex(c => c.DniCliente)
                .IsUnique();

            modelBuilder.Entity<Empleado>()
                .HasIndex(e => e.DniEmpleado)
                .IsUnique();

            modelBuilder.Entity<Empleado>()
                .HasIndex(e => e.EmailEmpleado)
                .IsUnique();

            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.NombreUsuario)
                .IsUnique();

            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.IdEmpleado)
                .IsUnique();
        }
    }
}
