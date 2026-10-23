using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace horusOps.Entities
{
    [Table("DETALLE_VENTAS")]
    public class DetalleVentas
    {
        [Key]
        [Column("ID_DETALLE_VENTA")]
        public int IdDetalleVenta { get; set; }

        [Column("ID_VENTA")]
        public int IdVenta { get; set; }

        [Column("ID_PRODUCTO")]
        public int IdProducto { get; set; }

        [MaxLength(100)]
        [Column("PRODUCTO", TypeName = "varchar(100)")]
        public string Producto { get; set; } = string.Empty;

        [Column("CANTIDAD")]
        public int Cantidad { get; set; }

        [Column("PRECIO_UNITARIO", TypeName = "decimal(10,2)")]
        public decimal PrecioUnitario { get; set; }

        [ForeignKey(nameof(IdVenta))]
        public Venta Venta { get; set; } = null!;

        [ForeignKey(nameof(IdProducto))]
        public Producto ProductoNavegacion { get; set; } = null!;
    }
}
