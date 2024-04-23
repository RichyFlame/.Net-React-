namespace SistemaContableApi.Models
{
    public class ListadoClientes
    {
        public List<Cliente> ListaClientes { get; set; }
        public Respuesta Respuesta { get; set; }

        public ListadoClientes()
        {
            ListaClientes = new List<Cliente>();
            Respuesta = new Respuesta();
        }
    }
}
