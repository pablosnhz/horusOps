

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace horusOps.Entities;

    [Table("EMPLEADOS")]
    public class Empleado
{
    [Key]
    [Column("ID_EMPLEADO")]
    public int IdEmpleado { get; set; }

    [MaxLength(100)]
    [Column("NOMBRE_EMPLEADO", TypeName = "varchar(100)")]
    public string NombreEmpleado { get; set; } = string.Empty;

    [MaxLength(100)]
    [Column("APELLIDO_EMPLEADO", TypeName = "varchar(100)")]
    public string ApellidoEmpleado { get; set; } = string.Empty;

    [MaxLength(20)]
    [Column("DNI_EMPLEADO", TypeName = "varchar(20)")]
    public string DniEmpleado { get; set; } = string.Empty;

    [MaxLength(150)]
    [Column("EMAIL_EMPLEADO", TypeName = "varchar(150)")]
    public string EmailEmpleado { get; set; } = string.Empty;

    [MaxLength(30)]
    [Column("TELEFONO_EMPLEADO", TypeName = "varchar(30)")]
    public string? TelefonoEmpleado { get; set; }

    [Column("FECHA_INGRESO", TypeName = "date")]
    public DateTime FechaIngreso { get; set; }

    [Column("ID_SUCURSAL")]
    public int IdSucursal { get; set; }

    [Column("ACTIVO")]
    public bool Activo { get; set; }

    [Column("FECHA_ALTA", TypeName = "datetime")]
    public DateTime FechaAlta { get; set; }

    [ForeignKey(nameof(IdSucursal))]
    public Sucursal Sucursal { get; set; } = null!;

    public ICollection<Venta> Ventas { get; set; } = new List<Venta>();
}