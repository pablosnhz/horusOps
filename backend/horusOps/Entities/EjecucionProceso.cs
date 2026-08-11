using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace horusOps.Entities
{
    [Table("EJECUCIONES_PROCESOS")]
    public class EjecucionProceso
    {
        [Key]
        [Column("ID_EJECUCION")]
        public long IdEjecucion {  get; set; }

        [Column("ID_PROCESO")]
        public int IdProceso { get; set; }

        [Column("FECHA_INICIO")]
        public DateTime FechaInicio { get; set; }

        [Column("FECHA_FIN")]
        public DateTime? FechaFin { get; set; }

        [Column("ESTADO_EJECUCION")]
        public string EstadoEjecucion { get; set; }

        [Column("REGISTROS_PROCESADOS")]
        public int RegistrosProcesados { get; set; }

        [Column("CANTIDAD_ERRORES")]
        public int CantidadErrores { get; set; }

        [ForeignKey(nameof(IdProceso))]
        public Proceso Proceso { get; set; } = null!;

        public ICollection<LogProceso> Logs { get; set; } = new List<LogProceso>();
    }
}
