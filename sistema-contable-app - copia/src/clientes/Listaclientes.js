import axios from "axios";
import React, { useEffect, useState } from "react";
import { Link, useNavigate } from "react-router-dom";

const urlBase = "https://localhost:7018/api/Clientes/";

export default function Listaclientes() {
  let navegacion = useNavigate();
  const [empleados, setEmpleados] = useState([]);

  useEffect(() => {
    cargarEmpleados();
  }, []);

  const cargarEmpleados = async () => {
    const resultado = await axios.get(urlBase + "ConsultarClientes");
    console.log(resultado.data);
    setEmpleados(resultado.data.listaClientes);
  };

  const EliminarCliente = async (clien_id) => {
    await axios.post(`${urlBase}EliminarCliente/${clien_id}`);
    cargarEmpleados();
  };

  return (
    <div className="container">
      <div className="container text-center" style={{ margin: "30px" }}>
        <h3>Listado de Clientes</h3>
      </div>

      <table className="table table-striped table-hover align-middle">
        <thead className="table-dark">
          <tr>
            <th scope="col">ID CLIENTE</th>
            <th scope="col">NOMBRE</th>
            <th scope="col">DIRECCION</th>
            <th scope="col">TELEFONO</th>
            <th scope="col">EMAIL</th>
            <th scope="col">NIT</th>
            <th scope="col">Acciones</th>
          </tr>
        </thead>
        <tbody>
          {empleados.map((cliente, indice) => (
            <tr key={indice}>
              <td>{cliente.clien_Id}</td>
              <td>{cliente.nombre}</td>
              <td>{cliente.direccion}</td>
              <td>{cliente.telefono}</td>
              <td>{cliente.email}</td>
              <td>{cliente.nit}</td>
              <td>
                <div className="mb-3">
                  <Link
                    to={`/editarCliente/${cliente.clien_Id}`}
                    className="btn btn-sm btn-warning ms-1"
                  >
                    <i className="bi bi-pencil"></i>
                  </Link>
                  <button
                    className="btn btn-sm btn-danger ms-1"
                    onClick={() => EliminarCliente(cliente.clien_Id)}
                  >
                    <i className="bi bi-trash"></i>
                  </button>
                </div>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}
