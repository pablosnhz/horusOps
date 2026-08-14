namespace horusOps.Dtos.Sucursal
{
    public class ActualizarSucursalDto
    {
        public string NombreSucursal { get; set; } = string.Empty;
        public string DireccionSucursal { get; set; } = string.Empty;
        public string? Ciudad {  get; set; }
        public bool Activo {  get; set; }
    }
}
