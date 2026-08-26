using System.Security.Cryptography.X509Certificates;

namespace horusOps.Dtos.LogProceso
{
    public class CrearLogProcesoDto
    {
        public long IdEjecucion {  get; set; }
        public string NivelLog { get; set; } = string.Empty;
        public string MensajeLog {  get; set; } = string.Empty;
        public string? DetalleError { get; set; }
    }
}
