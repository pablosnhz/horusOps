namespace horusOps.Dtos.Proceso
{
    public class CrearProcesoDto
    {
        public string NombreProceso { get; set; } = string.Empty;
        public string DescripcionProceso { get; set; } = string.Empty;
        public string ExpresionCron {  get; set; } = string.Empty;
        public decimal ProbabilidadError { get; set; }
    }
}
