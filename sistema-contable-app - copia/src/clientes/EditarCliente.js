import axios from "axios";
import React, { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";

export default function editarCliente() {
  const urlBase = "https://localhost:7018/api/Clientes/";
  let navegacion = useNavigate();

  const { cliente_id } = useParams();

  const [cliente, setCliente] = useState({
    nombre: "",
    direccion: "",
    telefono: "",
    email: "",
    nit: "",
  });

  const { nombre, direccion, telefono, email, nit } = cliente;

  useEffect(() => {
    cargarCliente();
  }, []);

  const cargarCliente = async () => {
    const resultado = await axios.get(`${urlBase}BuscarCliente/${cliente_id}`);
    setCliente(resultado.data);
  };

  const onInputChange = (e) => {
    setCliente({ ...cliente, [e.target.name]: e.target.value });
  };

  const onSubmit = async (e) => {
    e.preventDefault();

    await axios.post(`${urlBase}ActualizarCliente/${cliente_id}`, cliente);
    navegacion("/listaClientes");
  };

  return (
    <div className="container">
      <div className="container text-center" style={{ margin: "30px" }}>
        <h3>Editar Cliente</h3>
      </div>
      <form onSubmit={(e) => onSubmit(e)}>
        <div className="mb-3">
          <label htmlFor="nombre" className="form-label">
            Nombre
          </label>
          <input
            type="text"
            className="form-control"
            id="nombre"
            name="nombre"
            required={true}
            value={nombre}
            onChange={(e) => onInputChange(e)}
          />
        </div>
        <div className="mb-3">
          <label htmlFor="direccion" className="form-label">
            Direccion
          </label>
          <input
            type="text"
            className="form-control"
            id="direccion"
            name="direccion"
            required={true}
            value={direccion}
            onChange={(e) => onInputChange(e)}
          />
        </div>
        <div className="mb-3">
          <label htmlFor="telefono" className="form-label">
            Telefono
          </label>
          <input
            type="text"
            className="form-control"
            id="telefono"
            name="telefono"
            required={true}
            value={telefono}
            onChange={(e) => onInputChange(e)}
          />
        </div>
        <div className="mb-3">
          <label htmlFor="email" className="form-label">
            Email
          </label>
          <input
            type="email"
            className="form-control"
            id="email"
            name="email"
            value={email}
            onChange={(e) => onInputChange(e)}
          />
        </div>
        <div className="mb-3">
          <label htmlFor="nit" className="form-label">
            Nit
          </label>
          <input
            type="text"
            className="form-control"
            id="nit"
            name="nit"
            required={true}
            value={nit}
            onChange={(e) => onInputChange(e)}
          />
        </div>
        <div className="text-center">
          <button type="submit" className="btn btn-success me-3">
            Actualizar
          </button>
          <a href="/listaClientes" className="btn btn-danger me-3">
            Regresar
          </a>
        </div>
      </form>
    </div>
  );
}
