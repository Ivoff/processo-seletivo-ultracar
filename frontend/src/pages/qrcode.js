import {  useState } from "react"

export default function QrCode() {
    const apiurl = "http://localhost:5002/client/car/qrcode";
    let clientId;
    let carId;

    const [ qrcode, setQrcode ] = useState("");

    const handleButton = () => {
        fetch(apiurl, {
            "method": "POST",
            mode: 'cors',
            headers: {
                'Access-Control-Allow-Origin': '*',
                'content-type': 'application/json'
            },
            "body": JSON.stringify({
                ClientId: clientId,
                CarId: carId
            })
        }).then((res) => {
            if (res.status !== 200) {
                alert("Algo de errado aconteceu");
            }
            else{
                res.json().then((data) => {
                    setQrcode("data:image/png;base64,"+data.base64QrCode);
                });
            }
        })
        .catch(err => console.log(err));
    }

    const QrCodeImage = () => {
        if (qrcode !== "")
        {
            return (
                <div>
                    <img src={qrcode} alt="QrCode" />
                </div>
            );
        }
    }

    return (
        <div>
            <h1>Cliente seleciona carro</h1>
            <h3>Aqui o cliente selecionaria o carro cadastrado que ele queira realizar a visita</h3>
            <p>Na minha modelagem, clientes podem ter mais de um carro cadastrado, porém não existem casos assim no banco</p>
            <label for="clientId">Digite o Id do cliente:</label>
            <input type="text" name="clientId" onChange={(event) => clientId = event.target.value}/>
            <br/>
            <label for="carId">Digite o Id do Carro:</label>
            <input type="text" name="carId" onChange={(event) => carId = event.target.value}/>
            <br/>
            <button type="button" onClick={() => handleButton()}>Gerar QrCode</button>
            {QrCodeImage()}
        </div>
    ); 
}