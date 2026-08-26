namespace horusOps.Dtos.EjecucionProceso
{
    public class CrearEjecucionProcesoDto
    {
        public int IdProceso { get; set; }
        public string EstadoEjecucion { get; set; } = string.Empty;
        public int RegistrosProcesados { get; set; }
        public int CantidadErrores { get; set; }
    }
}
