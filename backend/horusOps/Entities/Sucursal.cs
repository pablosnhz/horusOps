using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace horusOps.Entities
{
    [Table("SUCURSALES")]
    public class Sucursal
    {
        [Key]
        [Column("ID_SUCURSAL")]
        public int IdSucursal { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("NOMBRE_SUCURSAL", TypeName = "varchar(100)")]
        public string NombreSucursal { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        [Column("DIRECCION_SUCURSAL", TypeName = "varchar(200)")]
        public string DireccionSucursal { get; set; } = string.Empty;

        [MaxLength(100)]
        [Column("CIUDAD", TypeName = "varchar(100)")]
        public string? Ciudad { get; set; }

        [Column("ACTIVO")]
        public bool Activo { get; set; }

        [Column("FECHA_ALTA", TypeName = "datetime")]
        public DateTime FechaAlta { get; set; }

        public ICollection<Empleado> Empleados { get; set; }
            = new List<Empleado>();

        public ICollection<Venta> Ventas { get; set; }
            = new List<Venta>();
    }
}