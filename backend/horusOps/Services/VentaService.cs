using AutoMapper;
using horusOps.Context;
using horusOps.Dtos.Venta;
using horusOps.Entities;
using Microsoft.EntityFrameworkCore;

namespace horusOps.Services
{
    public class VentaService
    {
        private readonly HorusOpsDbContext _context;
        private readonly IMapper _mapper;

        public VentaService(HorusOpsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<VentaDto> CrearVentaAsync(CrearVentaDto dto)
        {
            var cliente = await _context.Cliente
                .FirstOrDefaultAsync(c => c.IdCliente == dto.IdCliente);

            if (cliente == null)
            {
                throw new Exception("El cliente no existe.");
            }

            var empleado = await _context.Empleados
                .FirstOrDefaultAsync(e => e.IdEmpleado == dto.IdEmpleado && e.Activo);

            if (empleado == null)
            {
                throw new Exception("El empleado no existe o esta inactivo.");
            }

            var sucursal = await _context.Sucursales
                .FirstOrDefaultAsync(s =>
                    s.IdSucursal == dto.IdSucursal &&
                    s.Activo);

            if(sucursal == null)
            {
                throw new Exception("La sucursal no existe o esta inactiva.");
            }

            var venta = new Venta
            {
                FechaVenta = DateTime.Now,

                idCliente = cliente.IdCliente,
                idEmpleado = empleado.IdEmpleado,
                idSucursal = sucursal.IdSucursal,

                DniCliente = cliente.DniCliente,
                NombreCliente = cliente.NombreCliente,
                DireccionEnvioCliente = cliente.DireccionEnvioCliente,

                NombreEmpleado = $"{empleado.NombreEmpleado} {empleado.ApellidoEmpleado}",

                NombreSucursalVenta = sucursal.NombreSucursal,
                DireccionSucursalVenta = sucursal.DireccionSucursal,

                ImporteTotal = 0
            };

            foreach(var detalleDto in dto.Detalles)
            {
                var producto = await _context.Productos
                    .FirstOrDefaultAsync(p =>
                        p.IdProducto == detalleDto.IdProducto &&
                        p.Activo);

                if(producto == null)
                {
                    throw new Exception($"El producto {detalleDto.IdProducto} no existe o esta inactivo.");
                }

                var detalle = new DetalleVentas
                {
                    IdProducto = producto.IdProducto,
                    Producto = producto.NombreProducto,
                    Cantidad = detalleDto.Cantidad,
                    PrecioUnitario = producto.PrecioProducto
                };

                venta.Detalles.Add(detalle);

                venta.ImporteTotal +=
                    producto.PrecioProducto * detalleDto.Cantidad;
            }

            _context.Ventas.Add(venta);

            await _context.SaveChangesAsync();

            return _mapper.Map<VentaDto>(venta);
        }
    }
}
