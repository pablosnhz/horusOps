namespace horusOps.Dtos.Proceso
{
    public class ProcesoDto
    {
        public int IdProceso { get; set; }
        public string NombreProceso { get; set; } = string.Empty;
        public string DescripcionProceso { get; set; } = string.Empty;
        public string ExpresionCron {  get; set; } = string.Empty;
        public decimal ProbabilidadError { get; set; } 
        public bool Activo {  get; set; }
        public DateTime FechaAlta { get; set; }
    }
}
