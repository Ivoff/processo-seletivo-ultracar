import { Outlet, Link } from "react-router-dom";

const Layout = () => {
  return (
    <>
      <nav>
        <ul>
          <li>
            <Link to="/qrcode">
              QrCode (Cliente)
            </Link>
          </li>
          <li>
            <Link to="/service">
              Serviço (Colaborador)
            </Link>
          </li>
        </ul>
      </nav>

      <Outlet />
    </>
  )
};

export default Layout;