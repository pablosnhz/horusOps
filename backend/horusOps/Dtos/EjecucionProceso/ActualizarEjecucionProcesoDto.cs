namespace horusOps.Dtos.EjecucionProceso
{
    public class ActualizarEjecucionProcesoDto
    {
        public DateTime? FechaFin {  get; set; }
        public string EstadoEjecucion { get; set; } = string.Empty;
        public int RegistrosProcesados { get; set; }
        public int CantidadErrores { get; set; }
    }
}
