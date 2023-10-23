const LoadOnData = ({ shipmentLoadOnLocation, index }) => {

    return <div className="load-on-data-container">
        <span>Mesto utovara: {shipmentLoadOnLocation.loadOnLocation.name}</span>
        <span>Adresa utovara: {shipmentLoadOnLocation.loadOnLocation.address}</span>
        <span>Datum utovara: {shipmentLoadOnLocation.date} </span>
    </div>
}

export default LoadOnData;