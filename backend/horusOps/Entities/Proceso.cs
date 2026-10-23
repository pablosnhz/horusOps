
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace horusOps.Entities
{
    [Table("PROCESOS")]
    public class Proceso
    {
        [Key]
        [Column("ID_PROCESO")]
        public int IdProceso { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("NOMBRE_PROCESO", TypeName = "varchar(100)")]
        public string NombreProceso { get; set; } = string.Empty;

        [MaxLength(300)]
        [Column("DESCRIPCION_PROCESO", TypeName = "varchar(300)")]
        public string? DescripcionProceso { get; set; }

        [MaxLength(50)]
        [Column("EXPRESION_CRON", TypeName = "varchar(50)")]
        public string? ExpresionCron { get; set; }

        [Column("PROBABILIDAD_ERROR", TypeName = "decimal(5,2)")]
        public decimal ProbabilidadError { get; set; }

        [Column("ACTIVO")]
        public bool Activo { get; set; }

        [Column("FECHA_ALTA", TypeName = "datetime")]
        public DateTime FechaAlta { get; set; }

        public ICollection<EjecucionProceso> Ejecuciones { get; set; }
            = new List<EjecucionProceso>();
    }
}
