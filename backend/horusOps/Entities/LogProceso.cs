using System.ComponentModel.DataAnnotations.Schema;

namespace horusOps.Entities
{
    [Table("LOGS_PROCESOS")]
    public class LogProceso
    {
        [Column("ID_LOG")]
        public long idLog {  get; set; }

        [Column("ID_EJECUCION")]
        public long idEjecucion { get; set; }

        [Column("FECHA_LOG")]
        public DateTime FechaLog { get; set; }

        [Column("NIVEL_LOG")]
        public string NivelLog { get; set; }

        [Column("MENSAJE_LOG")]
        public string MensajeLog { get; set; }

        [Column("DETALLE_ERROR")]
        public string? DetalleError { get; set; }

        [ForeignKey(nameof(idEjecucion))]
        public EjecucionProceso Ejecucion { get; set; } = null!;
    }
}
