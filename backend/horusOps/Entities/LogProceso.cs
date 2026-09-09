using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace horusOps.Entities
{
    [Table("LOGS_PROCESOS")]
    public class LogProceso
    {
        [Key]
        [Column("ID_LOG")]
        public long IdLog {  get; set; }

        [Column("ID_EJECUCION")]
        public long IdEjecucion { get; set; }

        [Column("FECHA_LOG")]
        public DateTime FechaLog { get; set; }

        [Column("NIVEL_LOG")]
        public string NivelLog { get; set; } = string.Empty;

        [Column("MENSAJE_LOG")]
        public string MensajeLog { get; set; } = string.Empty;

        [Column("DETALLE_ERROR")]
        public string? DetalleError { get; set; }

        [ForeignKey(nameof(IdEjecucion))]
        public EjecucionProceso Ejecucion { get; set; } = null!;
    }
}
