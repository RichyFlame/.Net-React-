namespace SistemaContableApi.Models
{
    public class Cliente
    {
        public int Clien_Id { get; set; }
        public string  Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Nit { get; set; }
        public Respuesta Respuesta { get; set; }

        public Cliente()
        {
            Clien_Id = 0;
            Nombre = string.Empty;
            Direccion = string.Empty;
            Telefono = string.Empty;
            Email = string.Empty;
            Nit = string.Empty;
            Respuesta = new Respuesta();
        }
    }
}
