using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace horusOps.Entities
{
    [Table("SUCURSALES")]
    public class Sucursales
    {
        [Key]
        [Column("ID_SUCURSAL")]
        public int IdSucursal {  get; set; }

        [Column("NOMBRE_SUCURSAL")]
        public string NombreSucursal { get; set; } = string.Empty;

        [Column("DIRECCION_SUCURSAL")]
        public string DireccionSucursal { get; set; } = string.Empty;

        [Column("CIUDAD")]
        public string? Ciudad {  get; set; }

        [Column("ACTIVO")]
        public bool Activo {  get; set; }
        
        [Column("FECHA_ALTA")]
        public DateTime FechaAlta {  get; set; }

        public ICollection<Empleado> Empleados { get; set; }
                = new List<Empleado>();

        public ICollection<Venta> Ventas { get; set; }
                = new List<Venta>();

        [ForeignKey(nameof(IdSucursal))]
        public Sucursales Sucursal { get; set; } = null!;
    }
}
