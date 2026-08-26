namespace horusOps.Dtos.LogProceso
{
    public class LogProcesoDto
    {
        public long IdLog {  get; set; }
        public long IdEjecucion { get; set; }
        public DateTime FechaLog { get; set; }
        public string NivelLog { get; set; } = string.Empty;
        public string MensajeLog {  get; set; } = string.Empty;
        public string? DetalleError { get; set; }
    }
}
