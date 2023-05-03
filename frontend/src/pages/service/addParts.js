import { useState } from "react"
import handlePost from "./handlePost";

export default function AddParts(props) {
    const addPartUrl = "http://localhost:5002/service/addPart"

    const [part, setPart] = useState("");
    const [service, setService] = useState("");
    const [quantity, setQuantity] = useState("");

    const handleButton = () => {
        handlePost(addPartUrl, JSON.stringify({
            partId: part,
            serviceId: service,
            quantity: quantity
        }), "Peça Adicionada com Sucesso!", props.updateServicesData);
    }

    return (
        <div>
            <h1>Adicionar peças</h1>
            <ul>
                <li>Busque o Id de peças na banco e insira as que forem selecionadas aqui</li>
                <li>O valor do custo total do serviço em questão deve ser atualizado em tempo real</li>
            </ul>
            <div>
                <label htmlFor="serviceId">Digite o Id do serviço:</label>
                <input type="text" name="serviceId" autoComplete="off" onChange={event => setService(event.target.value)}/>
                
                <br/>
                
                <label htmlFor="partId">Digite o Id da peça:</label>
                <input type="text" name="partId" autoComplete="off" onChange={event => setPart(event.target.value)}/>
                
                <br/>

                <label htmlFor="quantity">Digite a quantidade de peças:</label>
                <input type="number" name="quantity" autoComplete="off" onChange={event => setQuantity(event.target.value)}/>

                <br/>

                <button type="button" onClick={() => {
                    handleButton();
                    
                }}>
                    Inserir Peça
                </button>
            </div>
        </div>
    )
}