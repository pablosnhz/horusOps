namespace horusOps.Dtos.Usuario
{
    public class UsuarioDto
    {
        public int IdUsuario {  get; set; }
        public string NombreUsuario { get; set; } = string.Empty;
        public string RolUsuario { get; set; } = string.Empty;
        public int? IdEmpleado { get; set; }
        public bool Activo { get; set; }
    }
}
