namespace SistemaContableApi.Models
{
    public class Respuesta
    {
        public string RespuestaTecnica { get; set; }
        public string RespuestaCliente { get; set; }
        public bool OcurrioError { get; set; }

        public Respuesta()
        {
            RespuestaCliente = string.Empty;
            RespuestaTecnica = string.Empty;
            OcurrioError = false;
        }
    }
}
