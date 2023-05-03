import { useState } from "react";
import handlePost from "./handlePost";

export default function ServiceState(props) {
    const apiUrl = "http://localhost:5002/service/"
    const [service, setService] = useState("");

    const handleStateChange = (type) => {
        handlePost(
            apiUrl+type, 
            JSON.stringify({serviceId: service}), 
            "Serviço Alterado com Sucesso!", 
            props.updateServicesData
        );
    }

    return (
        <div>
            <h1>Alterar estado de serviço</h1>
            <ul>
                <li>"Iniciar Serviço" determina a data de início em que o colaborador começou o trabalho efetivo de resolver o problema alvo do serviço.</li>
                <li>"Terminar Serviço" determina a data de finalização em que o colaborador terminou o trabalho efetivo de resolver o problema alvo do serviço.</li>
            </ul>
            <div>
                <label htmlFor="serviceId">Digite o Id do serviço:</label>
                <input type="text" name="serviceId" autoComplete="off" onChange={(e) => {setService(e.target.value)}}/>
                <br/>
                <div className="flex flex-row mt-5">
                    <button type="button"
                        className="p-3 ml-7"
                        onClick={() => handleStateChange("begin")}
                    >
                        Iniciar Serviço
                    </button>
                    <button type="button"
                        className="ml-10"
                        onClick={() => handleStateChange("finish")}
                    >
                        Terminar Serviço
                    </button>
                </div>
            </div>
        </div>
    );
}