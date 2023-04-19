import { BrowserRouter, Routes, Route } from "react-router-dom";
import QrCode from "./pages/qrcode";
import Service from "./pages/service/service";
import './App.css';
import Layout from "./pages/layout";

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Layout/>}>
          <Route index element={<QrCode/>} />
          <Route path="service" element={<Service/>} />
        </Route>
      </Routes>
    </BrowserRouter>
  );
}

export default App;
