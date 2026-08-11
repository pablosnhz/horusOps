using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace horusOps.Entities
{
    [Table("PRODUCTOS")]
    public class Producto
    {
        [Key]
        [Column("ID_PRODUCTO")]
        public int idProducto { get; set; }

        [Required]
        [Column("NOMBRE_PRODUCTO")]
        public string NombreProducto { get; set; } = string.Empty;

        [Column("PRECIO_PRODUCTO")]
        public decimal PrecioProducto { get; set; }

        [Column("ACTIVO")]
        public bool Activo {  get; set; }

        public ICollection<DetalleVentas> DetallesVenta { get; set; }
                = new List<DetalleVentas>();
    }
}
