import { useState } from "react";
import handlePost from "./handlePost";

export default function CreateService(props) {
    const createUrl = "http://localhost:5002/service/create";
    
    const [collaborator, setCollaborator] = useState("");
    const [car, setCar] = useState("");

    const handleButton = () => {
        handlePost(
            createUrl, 
            JSON.stringify({
                CollaboratorId: collaborator,
                CarId: car
            }), 
            "Serviço Criado com Sucesso!",
            props.updateServicesData
        );
    }
    
    return (
        <div className="flex">
            <div>
                <h1>Criar Serviço</h1>
                <h3>Avaliação do veículo e adição das peças</h3>
                <ul>
                    <li>Escaneie o QrCode do cliente selecionado por uma aplicação de terceiros</li>
                    <li>Preencha os campos com os dados decodificados do QrCode</li>
                </ul>
                <div className="">
                    <label htmlFor="carId">Digite o Id do carro:</label>
                    <input type="text" 
                        name="carId" 
                        autoComplete="off" 
                        onChange={(event) => setCar(event.target.value)}
                    />
                    <br/>
                    <label htmlFor="collaboratorId">Digite o Id do colaborador:</label>
                    <input type="text" 
                        name="collaboratorId" 
                        autoComplete="off" 
                        onChange={(event) => setCollaborator(event.target.value)}
                    />
                    <br/>
                    <button type="button" onClick={() => {
                        handleButton();
                    }}>
                        Criar Serviço
                    </button>
                </div>
            </div>
        </div>
    );
}