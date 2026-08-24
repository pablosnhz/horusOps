namespace horusOps.Dtos.Cliente
{
    public class CrearClienteDto
    {
        public string DniCliente { get; set; } = string.Empty;
        public string NombreCliente {  get; set; } = string.Empty;
        public string? DireccionEnvioCliente { get; set; }
        public string? EmailCliente {  get; set; }
        public string? TelefonoCliente { get; set; }
    }
}
