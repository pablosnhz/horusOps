using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace horusOps.Entities
{
    [Table("VENTAS")]
    public class Venta
    {
        [Key]
        [Column("ID_VENTA")]
        public int IdVenta { get; set; }

        [Column("FECHA_VENTA")]
        public DateTime FechaVenta { get; set; }

        [Column("ID_CLIENTE")]
        public int idCliente { get; set; }

        [Column("ID_EMPLEADO")]
        public int idEmpleado { get; set; }

        [Column("ID_SUCURSAL")]
        public int idSucursal {  get; set; }

        [Column("DNI_CLIENTE")]
        public string DniCliente { get; set; } = string.Empty;

        [Column("NOMBRE_CLIENTE")]
        public string NombreCliente { get; set; } = string.Empty;

        [Column("DIRECCION_ENVIO_CLIENTE")]
        public string DireccionEnvioCliente { get; set; }

        [Column("NOMBRE_EMPLEADO")]
        public string NombreEmpleado { get; set; } = string.Empty;

        [Column("NOMBRE_SUCURSAL_VENTA")]
        public string NombreSucursalVenta { get; set; } = string.Empty;

        [Column("DIRECCION_SUCURSAL_VENTA")]
        public string DireccionSucursalVenta { get; set; } = string.Empty;

        [Column("IMPORTE_TOTAL")]
        public decimal ImporteTotal { get; set; }

        [ForeignKey(nameof(idCliente))]
        public Cliente Cliente { get; set; } = null!;

        [ForeignKey(nameof(idEmpleado))]
        public Empleado Empleado { get; set; } = null!;

        [ForeignKey(nameof(idSucursal))]
        public Sucursales Sucursal { get; set; } = null!;

        public ICollection<DetalleVentas> Detalles { get; set; }
                = new List<DetalleVentas>();
    }
}
