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

        [Column("DNI_CLIENTE")]
        public string DniCliente { get; set; } = string.Empty;

        [Column("NOMBRE_CLIENTE")]
        public string NombreCliente { get; set; } = string.Empty;

        [Column("DIRECCION_ENVIO_CLIENTE")]
        public string? DireccionEnvioCliente { get; set; }

        [Column("EMAIL_CLIENTE")]
        public string? EmailCliente { get; set; }

        [Column("TELEFONO_CLIENTE")]
        public string? TelefonoCliente { get; set; }

        [Column("FECHA_ALTA")]
        public DateTime FechaAlta { get; set; }

        public ICollection<Venta> Ventas { get; set; } = new List<Venta>();
    }
}
