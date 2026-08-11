using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace horusOps.Entities
{
    [Table("PROCESOS")]
    public class Proceso
    {
        [Key]
        [Column("ID_PROCESO")]
        public int idProceso { get; set; }

        [Column("NOMBRE_PROCESO")]
        public string NombreProceso { get; set; } = string.Empty;

        [Column("DESCRIPCION_PROCESO")]
        public string DescripcionProceso { get; set; }

        [Column("EXPRESION_CRON")]
        public string ExpresionCron {  get; set; }

        [Column("PROBABILIDAD_ERROR")]
        public decimal ProbabilidadError { get; set; }

        [Column("ACTIVO")]
        public bool Activo {  get; set; }

        [Column("FECHA_ALTA")]
        public DateTime FechaAlta { get; set; }

        public ICollection<EjecucionProceso> Ejecuciones { get; set; }
                = new List <EjecucionProceso>();
    }
}
