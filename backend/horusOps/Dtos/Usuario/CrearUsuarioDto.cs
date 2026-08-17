namespace horusOps.Dtos.Usuario
{
    public class CrearUsuarioDto
    {
        public string NombreUsuario { get; set; } = string.Empty;
        public string Clave {  get; set; } = string.Empty;
        public string RolUsuario { get; set; } = string.Empty;
        public int? IdEmpleado { get; set; }
    }
}
