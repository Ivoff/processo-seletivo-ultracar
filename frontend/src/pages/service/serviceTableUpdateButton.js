export default function ServiceTableUpdateButton(props) {
    return (
        <div className="w-full">
            <button 
                className="w-full p-3 mb-3 text-xl font-bold"
                type="button"
                onClick={() => {props.updateServicesData()}}
            >
                Atualizar{" "}
                <i className="fa fa-refresh"></i>
            </button>
        </div>
    )
}