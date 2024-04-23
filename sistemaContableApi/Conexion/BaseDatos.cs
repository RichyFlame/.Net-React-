using OracleBdd;
using SistemaContableApi.Models;
using System.Data;
using System.Drawing;

namespace SistemaContable.Conexion
{
    public class BaseDatos
    {
        private readonly ConexionBdd conexion = new ConexionBdd();
        public BaseDatos() { }

        public List<Cliente> ConsultaClientes()
        {
            List<Cliente> clientes = new List<Cliente>();
            if (this.conexion.QueryReturDataSet("SELECT * FROM CLIENTES ORDER BY CLIEN_ID ASC"))
            {
                DataSet data = conexion.ResultDataSet();
                foreach (DataRow item in data.Tables[0].Rows)
                {
                    clientes.Add(new Cliente()
                    {
                        Clien_Id = int.Parse(item["CLIEN_ID"].ToString()),
                        Nombre = item["NOMBRE"].ToString(),
                        Direccion = item["DIRECCION"].ToString(),
                        Email = item["EMAIL"].ToString(),
                        Telefono = item["TELEFONO"].ToString(),
                        Nit = item["NIT"].ToString()
                    });
                }
            }

            return clientes;

        }

        public Cliente BuscarCliente(string cliente_id)
        {
            var cliente = new Cliente();
            if (this.conexion.QueryReturDataSet($"SELECT * FROM CLIENTES WHERE CLIEN_ID = {cliente_id}"))
            {
                DataSet data = conexion.ResultDataSet();
                foreach (DataRow item in data.Tables[0].Rows)
                {
                    cliente = new Cliente()
                    {
                        Clien_Id = int.Parse(item["CLIEN_ID"].ToString()),
                        Nombre = item["NOMBRE"].ToString(),
                        Direccion = item["DIRECCION"].ToString(),
                        Email = item["EMAIL"].ToString(),
                        Telefono = item["TELEFONO"].ToString(),
                        Nit = item["NIT"].ToString()
                    };
                }
            }

            return cliente;

        }

        public bool InsertarCliente(Cliente nuevoCliente)
        {
            if (this.conexion.Query($"INSERT INTO CLIENTES (CLIEN_ID, NOMBRE, DIRECCION, TELEFONO, EMAIL, NIT) VALUES ({nuevoCliente.Clien_Id}, '{nuevoCliente.Nombre}', '{nuevoCliente.Direccion}', '{nuevoCliente.Telefono}', '{nuevoCliente.Email}', '{nuevoCliente.Nit}')"))
            {
                return true;
            }
            return false;
        }

        public bool EliminarCliente(string clien_id)
        {
            if (this.conexion.Query($"DELETE FROM CLIENTES WHERE CLIEN_ID = {clien_id}"))
            {
                return true;
            }
            return false;
        }

        public bool ActualizarCliente(string cliente_id, Cliente cli)
        {
            if (this.conexion.Query($"UPDATE CLIENTES SET NOMBRE = '{cli.Nombre}', DIRECCION = '{cli.Direccion}', TELEFONO = '{cli.Telefono}', EMAIL = '{cli.Email}', NIT = '{cli.Nit}' WHERE CLIEN_ID = {cliente_id}"))
            {
                return true;
            }
            return false;
        }
    }
}

