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
        [Column("NOMBRE_USUARIO")]
        [StringLength(50)]
        public string NombreUsuario { get; set; }

        [Required]
        [Column("CLAVE_HASH")]
        [StringLength(500)]
        public string ClaveHash { get; set; }

        [Required]
        [Column("ROL_USUARIO")]
        [StringLength (30)]
        public string RolUsuario { get; set; }

        [Column("ID_EMPLEADO")]
        public int? IdEmpleado { get; set; }

        [Column("ACTIVO")]
        public bool Activo { get; set; }

        [Column("FECHA_ALTA")]
        public DateTime FechaAlta { get; set; }

        [ForeignKey(nameof(IdEmpleado))]
        public Empleado? Empleados { get; set; }
    }
}
