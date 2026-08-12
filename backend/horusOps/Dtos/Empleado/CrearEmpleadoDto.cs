namespace horusOps.Dtos.Empleado
{
    public class CrearEmpleadoDto
    {
        public string NombreEmpleado { get; set; } = string.Empty;
        public string ApellidoEmpleado { get; set; } = string.Empty;
        public string DniEmpleado { get; set; } = string.Empty;

        public string EmailEmpleado { get; set; } = string.Empty;

        public DateTime FechaIngreso { get; set; }

        public int IdSucursal { get; set; }
    }
}
