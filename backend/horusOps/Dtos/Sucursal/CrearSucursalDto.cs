namespace horusOps.Dtos.Sucursal
{
    public class CrearSucursalDto
    {
        public string NombreSucursal { get; set; } = string.Empty;
        public string DireccionSucursal { get; set; } = string.Empty;
        public string? Ciudad {  get; set; }
    }
}
