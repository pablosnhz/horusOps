namespace horusOps.Dtos.EjecucionProceso
{
    public class EjecucionProcesoDto
    {
        public long IdEjecucion { get; set; }
        public int IdProceso { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string EstadoEjecucion { get; set; } = string.Empty;
        public int RegistrosProcesados { get; set; }
        public int CantidadErrores { get; set; }
    }
}
