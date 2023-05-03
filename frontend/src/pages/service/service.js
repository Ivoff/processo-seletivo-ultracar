import CreateService from "./createService"
import ServiceTable from "./serviceTable";
import { useEffect, useState } from "react";
import AddParts from "./addParts";
import ServiceState from "./serviceState";
import ServiceTableUpdateButton from "./serviceTableUpdateButton";

export default function Service() {
    const getServicesUrl = "http://localhost:5002/service";

    const [services, setServices] = useState([]);
    
    console.log("Service");
    
    useEffect(() => {
        console.log("useEffect");

        updateServicesData();
    }, [])

    const updateServicesData = () => {
        console.log("updateServicesData");

        fetch(getServicesUrl, {
            "method": "GET",
            mode: 'cors',
            headers: {
                'Access-Control-Allow-Origin': '*',
                'content-type': 'application/json'
            }
        }).then((res) => {
            if (res.status === 200) {
                res.json().then((data) => {
                    setServices(data);
                });
            }
        }).catch(err => console.error(err));
    }
    
    return (
        <div className="flex">
            <div className="basis-2/5">
                <CreateService updateServicesData={updateServicesData}/>
                <AddParts updateServicesData={updateServicesData}/>
                <ServiceState updateServicesData={updateServicesData}/>
            </div>
            <div className="grow p-5">
                <ServiceTableUpdateButton updateServicesData={updateServicesData}/>
               <ServiceTable services={services}/>
            </div>
        </div>
    )
}