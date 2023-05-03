export default function ServiceTable(props) {
    
    const renderServicesTable = () => {
        return props.services.map((service) => {
            return (
                <tr key={service.serviceId}>
                    <td className="border-solid border border-black">
                        <p>{service.serviceId}</p>
                        <p>{new Date(Date.parse(service.createdAt)).toLocaleString('en-GB')}</p>
                    </td>
                    <td className="border-solid border border-black">
                        <p>{service.collaboratorName}</p>
                    </td>
                    <td className="border-solid border border-black">
                        <p>{service.carModel} / {service.carYear}</p>
                    </td>
                    <td className="border-solid border border-black">
                        <p>{service.ownerName}</p>
                    </td>
                    <td className="border-solid border border-black">
                        <p>{service.totalCost}</p>
                    </td>
                    <td className="border-solid border border-black">
                        <p>{service.currentState}</p>
                    </td>
                    <td className="border-solid border border-black">
                        <p>{service.elapsedTime == null ? "--" : service.elapsedTime}</p>
                    </td>
                </tr>
            )
        });
    }

    return (
        <table className="border-solid border border-black text-center table-auto w-full">
            <thead>
                <tr>
                    <th className="border-solid border border-black">Id/Data de criação</th>
                    <th className="border-solid border border-black">Colaborador</th>
                    <th className="border-solid border border-black">Carro</th>
                    <th className="border-solid border border-black">Cliente</th>
                    <th className="border-solid border border-black">Custo Total</th>
                    <th className="border-solid border border-black">Estado</th>
                    <th className="border-solid border border-black">Tempo gasto</th>
                </tr>
            </thead>
            <tbody>
                {renderServicesTable()}
            </tbody>
        </table>
    );
}