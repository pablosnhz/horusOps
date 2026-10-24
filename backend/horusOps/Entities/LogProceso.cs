
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace horusOps.Entities
{
    [Table("LOGS_PROCESOS")]
    public class LogProceso
    {
        [Key]
        [Column("ID_LOG")]
        public long IdLog { get; set; }

        [Column("ID_EJECUCION")]
        public long IdEjecucion { get; set; }

        [Column("FECHA_LOG", TypeName = "datetime")]
        public DateTime FechaLog { get; set; }

        [MaxLength(20)]
        [Column("NIVEL_LOG", TypeName = "varchar(20)")]
        public string NivelLog { get; set; } = string.Empty;

        [MaxLength(2000)]
        [Column("MENSAJE_LOG", TypeName = "varchar(2000)")]
        public string MensajeLog { get; set; } = string.Empty;

        [Column("DETALLE_ERROR", TypeName = "varchar(max)")]
        public string? DetalleError { get; set; }

        [ForeignKey(nameof(IdEjecucion))]
        public EjecucionProceso Ejecucion { get; set; } = null!;
    }
}
