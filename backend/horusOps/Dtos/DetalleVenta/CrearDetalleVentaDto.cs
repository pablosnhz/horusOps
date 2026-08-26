namespace horusOps.Dtos.DetalleVenta
{
    public class CrearDetalleVentaDto
    {
        public int IdVenta { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}
