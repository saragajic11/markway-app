const LoadOffData = ({ shipmentLoadOnLocation, index }) => {

    return <div className="load-on-data-container">
        <span>Mesto istovara: {shipmentLoadOnLocation.loadOnLocation.name}</span>
        <span>Adresa istovara: {shipmentLoadOnLocation.loadOnLocation.address}</span>
        <span>Datum istovara: {shipmentLoadOnLocation.date} </span>
    </div>
}

export default LoadOffData;