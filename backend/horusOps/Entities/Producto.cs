using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace horusOps.Entities
{
    [Table("PRODUCTOS")]
    public class Producto
    {
        [Key]
        [Column("ID_PRODUCTO")]
        public int IdProducto { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("NOMBRE_PRODUCTO", TypeName = "varchar(100)")]
        public string NombreProducto { get; set; } = string.Empty;

        [Column("PRECIO_PRODUCTO", TypeName = "decimal(10,2)")]
        public decimal PrecioProducto { get; set; }

        [Column("ACTIVO")]
        public bool Activo {  get; set; }

        public ICollection<DetalleVentas> DetallesVenta { get; set; }
                = new List<DetalleVentas>();
    }
}
