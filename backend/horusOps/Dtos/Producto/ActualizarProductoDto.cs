namespace horusOps.Dtos.Producto
{
    public class ActualizarProductoDto
    {
        public string NombreProducto { get; set; } = string.Empty;
        public decimal PrecioProducto {  get; set; }
        public bool Activo {  get; set; }
    }
}