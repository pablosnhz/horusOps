namespace horusOps.Dtos.Sucursal
{
    public class SucursalDto
    {
        public int IdSucursal {  get; set; }
        public string NombreSucursal { get; set; } = string.Empty;
        public string DireccionSucursal { get; set; } = string.Empty;
        public string? Ciudad {  get; set; }
        public bool Activo { get; set; }
        public DateTime FechaAlta { get; set; }
    }
}
