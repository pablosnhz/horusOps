namespace horusOps.Dtos.Producto
{
    public class ProductoDto
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; } = string.Empty;
        public decimal PrecioProducto { get; set; }
        public bool Activo {  get; set; }
    }
}