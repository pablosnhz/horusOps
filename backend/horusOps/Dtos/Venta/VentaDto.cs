namespace horusOps.Dtos.Venta
{
    public class VentaDto
    {
        public int IdVenta { get; set; }
        public DateTime FechaVenta { get; set; }
        public string DniCliente { get; set; } = string.Empty;
        public string NombreCliente { get; set; }
        public string DireccionEnvioCliente { get; set; }
        public string NombreEmpleado {  get; set; }
        public string NombreSucursalVenta { get; set; }
        public string DireccionSucursalVenta { get; set; }
        public decimal ImporteTotal { get; set; }
    }
}
