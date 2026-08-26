using horusOps.Dtos.DetalleVenta;

namespace horusOps.Dtos.Venta
{
    public class ActualizarVentaDto
    {
        public string DireccionEnvioCliente { get; set; } = string.Empty;
        public List<ActualizarDetalleVentaDto> Detalles { get; set; }
            = new();
    }
}
