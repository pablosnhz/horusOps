using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace horusOps.Entities
{
    [Table("CLIENTES")]
    public class Cliente
    {
        [Key]
        [Column("ID_CLIENTE")]
        public int IdCliente { get; set; }


        [Required]
        [MaxLength(20)]
        [Column("DNI_CLIENTE", TypeName = "varchar(20)")]
        public string DniCliente { get; set; } = string.Empty;

        [Required]
        [MaxLength(150)]
        [Column("NOMBRE_CLIENTE", TypeName = "varchar(150)")]
        public string NombreCliente { get; set; } = string.Empty;

        [MaxLength(200)]
        [Column("DIRECCION_ENVIO_CLIENTE", TypeName = "varchar(200)")]
        public string? DireccionEnvioCliente { get; set; }

        [MaxLength(150)]
        [Column("EMAIL_CLIENTE", TypeName = "varchar(150)")]
        public string? EmailCliente { get; set; }

        [MaxLength(30)]
        [Column("TELEFONO_CLIENTE", TypeName = "varchar(30)")]
        public string? TelefonoCliente { get; set; }

        [Column("FECHA_ALTA", TypeName = "datetime")]
        public DateTime FechaAlta { get; set; }

        public ICollection<Venta> Ventas { get; set; } = new List<Venta>();
    }
}
