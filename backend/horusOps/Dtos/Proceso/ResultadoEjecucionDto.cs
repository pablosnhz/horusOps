namespace horusOps.Dtos.Proceso
{
    public class ResultadoEjecucionDto
    {
        public long IdEjecucion {  get; set; }
        public string EstadoEjecucion { get; set; } = string.Empty;
        public int RegistrosProcesados { get; set; }
        public int CantidadErrores { get; set; }
    }
}
