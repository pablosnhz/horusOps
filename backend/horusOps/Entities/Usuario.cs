using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace horusOps.Entities
{
    [Table("USUARIOS")]
    public class Usuario
    {
        [Key]
        [Column("ID_USUARIO")]
        public int IdUsuario { get; set; }

        [Required]
        [StringLength(50)]
        [Column("NOMBRE_USUARIO", TypeName = "varchar(50)")]
        public string NombreUsuario { get; set; } = string.Empty;

        [Required]
        [StringLength(500)]
        [Column("CLAVE_HASH", TypeName = "varchar(500)")]
        public string ClaveHash { get; set; } = string.Empty;

        [Required]
        [StringLength(30)]
        [Column("ROL_USUARIO", TypeName = "varchar(30)")]
        public string RolUsuario { get; set; } = string.Empty;

        [Column("ID_EMPLEADO")]
        public int? IdEmpleado { get; set; }

        [Column("ACTIVO")]
        public bool Activo { get; set; }

        [Column("FECHA_ALTA", TypeName = "datetime")]
        public DateTime FechaAlta { get; set; }

        [ForeignKey(nameof(IdEmpleado))]
        public Empleado? Empleados { get; set; }
    }
}
