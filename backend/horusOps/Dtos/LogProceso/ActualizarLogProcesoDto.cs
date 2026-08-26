namespace horusOps.Dtos.LogProceso
{
    public class ActualizarLogProcesoDto
    {
        public string NivelLog {  get; set; } = string.Empty;
        public string MensajeLog {  get; set; } = string.Empty;
        public string? DetalleError {  get; set; }
    }
}
