import { BrowserRouter, Route, Routes } from "react-router-dom";
import Navegacion from "./plantilla/navegacion";
import Home from "./plantilla/home";
import Listaclientes from "./clientes/Listaclientes";
import NuevoCliente from "./clientes/nuevoCliente";
import EditarCliente from "./clientes/EditarCliente";

function App() {
  return (
    <div className="container">
      <BrowserRouter>
        <Navegacion />
        <Routes>
          <Route exact path="/" element={<Home />} />
          <Route exact path="/listaClientes" element={<Listaclientes />} />
          <Route exact path="/nuevoCliente" element={<NuevoCliente />} />
          <Route
            exact
            path="/editarCliente/:cliente_id"
            element={<EditarCliente />}
          />
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
