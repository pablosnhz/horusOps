namespace horusOps.Dtos.Empleado
{
    public class ActualizarEmpleadoDto
    {
        public string NombreEmpleado { get; set; } = string.Empty;
        public string ApellidoEmpleado { get; set; } = string.Empty;
        public string EmailEmpleado { get; set; } = string.Empty;
        public bool Activo {  get; set; }
    }
}
