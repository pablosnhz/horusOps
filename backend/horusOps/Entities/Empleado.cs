

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace horusOps.Entities;

    [Table("EMPLEADOS")]
    public class Empleado
{
    [Key]
    [Column("ID_EMPLEADO")]
    public int idEmpleado { get; set; }

    [Column("NOMBRE_EMPLEADO")]
    public string NombreEmpleado { get; set; } = string.Empty;

    [Column("APELLIDO_EMPLEADO")]
    public string ApellidoEmpleado { get; set; } = string.Empty;

    [Column("DNI_EMPLEADO")]
    public string DniEmpleado { get; set; } = string.Empty;

    [Column("EMAIL_EMPLEADO")]
    public string EmailEmpleado { get; set;  } = string.Empty;

    [Column("ID_SUCURSAL")]
    public int IdSucursal { get; set; }

    [Column("ACTIVO")]
    public bool Activo { get; set; }
}