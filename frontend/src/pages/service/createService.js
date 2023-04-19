export default function CreateService() {
    const apiurl = "http://localhost:5002/service/create";
    let collaboratorId;
    let carId;

    const handleButton = () => {
        fetch(apiurl, {
            "method": "POST",
            mode: 'cors',
            headers: {
                'Access-Control-Allow-Origin': '*',
                'content-type': 'application/json'
            },
            "body": JSON.stringify({
                collaboratorId,
                carId
            })
        }).then((res) => {
            if (res.status !== 200)
                alert("Algo de errado aconteceu");
        })
        .catch(err => console.log(err));
    }

    
    return (
        <div>
            <h1>Criar Serviço</h1>
            <h3>Avaliação do veículo e adição das peças</h3>
            <ul>
                <li>Escaneie o QrCode do cliente selecionado por uma aplicação de terceiros</li>
                <li>Preencha os campos com os dados decodificados do QrCode</li>
            </ul>
            <div>
                <label for="carId">Digite o Id do carro:</label>
                <input type="text" name="carId" onChange={(event) => collaboratorId = event.target.value}/>
                <br/>
                <label for="collaboratorId">Digite o Id do colaborador:</label>
                <input type="text" name="collaboratorId" onChange={(event) => carId = event.target.value}/>
                <br/>
                <button type="button" onClick={() => handleButton()}>Criar Serviço</button>
            </div>
        </div>
    );
}