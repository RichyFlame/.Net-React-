using Microsoft.AspNetCore.Mvc;
using SistemaContable.Conexion;
using SistemaContableApi.Models;

namespace SistemaContableApi.Controllers
{
        
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly BaseDatos _bdd = new BaseDatos();

        [HttpGet]
        [Route("api/Clientes/ConsultarClientes")]
        public async Task<ActionResult<ListadoClientes>> ConsultarClientes()
        {
            var clientes = new ListadoClientes();
            try
            {
                clientes.ListaClientes = _bdd.ConsultaClientes();
            }
            catch (Exception ex)
            {
                clientes.Respuesta.OcurrioError = true;
                clientes.Respuesta.RespuestaTecnica = ex.ToString();
                clientes.Respuesta.RespuestaCliente = "Ocurrio un error al consultar los clientes";
            }
            
            return clientes;
        }

        [HttpGet]
        [Route("api/Clientes/BuscarCliente/{cliente_id}")]
        public async Task<ActionResult<Cliente>> BuscarCliente(string cliente_id)
        {
            var cliente = new Cliente();
            try
            {
                cliente = _bdd.BuscarCliente(cliente_id);
            }
            catch (Exception ex)
            {
                cliente.Respuesta.OcurrioError = true;
                cliente.Respuesta.RespuestaTecnica = ex.ToString();
                cliente.Respuesta.RespuestaCliente = "Ocurrio un error al consultar los clientes";
            }

            return cliente;
        }

        [HttpPost]
        [Route("api/Clientes/NuevoCliente")]
        public async Task<ActionResult<Respuesta>> NuevoCliente(Cliente cliente)
        {
            var respuesta = new Respuesta();
            var rnd = new Random();
            cliente.Clien_Id = rnd.Next(100000, 1000000);
            try
            {
                respuesta.OcurrioError = _bdd.InsertarCliente(cliente);
            }
            catch (Exception ex)
            {
                respuesta.OcurrioError = true;
                respuesta.RespuestaTecnica = ex.ToString();
                respuesta.RespuestaCliente = "Ocurrio un error al consultar los clientes";
            }

            return respuesta;
        }

        [HttpPost]
        [Route("api/Clientes/EliminarCliente/{cliente_id}")]
        public async Task<ActionResult<Respuesta>> EliminarCliente(string cliente_id)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta.OcurrioError = _bdd.EliminarCliente(cliente_id);
            }
            catch (Exception ex)
            {
                respuesta.OcurrioError = true;
                respuesta.RespuestaTecnica = ex.ToString();
                respuesta.RespuestaCliente = "Ocurrio un error al consultar los clientes";
            }

            return respuesta;
        }

        [HttpPost]
        [Route("api/Clientes/ActualizarCliente/{cliente_id}")]
        public async Task<ActionResult<Respuesta>> ActualizarCliente(string cliente_id, Cliente cliente)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta.OcurrioError = _bdd.ActualizarCliente(cliente_id, cliente);
            }
            catch (Exception ex)
            {
                respuesta.OcurrioError = true;
                respuesta.RespuestaTecnica = ex.ToString();
                respuesta.RespuestaCliente = "Ocurrio un error al consultar los clientes";
            }

            return respuesta;
        }
    }
}
