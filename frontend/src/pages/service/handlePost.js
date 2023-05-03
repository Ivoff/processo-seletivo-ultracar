export default function handlePost(url, body, successMessage, callback=()=>{}) {
    console.log(body);
    fetch(url, {
        "method": "POST",
        mode: 'cors',
        headers: {
            'Access-Control-Allow-Origin': '*',
            'content-type': 'application/json'
        },
        "body": body
    }).then((res) => {
        if (res.status !== 200) {
            let message = "Algo de errado aconteceu\n";
            res.json().then((data) => {
                alert(message);
                if (data.title !== null && data.title !== undefined ) {

                    console.log(message + data.title);
                    console.log(data);
                } 
            }).catch((err) => {
                alert(message);
                console.error(err);
            });
        } else {            
            alert(successMessage);
            callback();
        }
    }).catch(err => console.error(err));
}