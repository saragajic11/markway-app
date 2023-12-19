import RouteDto from '@/model/RouteDto';
import LoadOnData from './LoadOnData';
import LoadOffData from './LoadOffData';
import CustomsContainer from './CustomsContainer';

const RouteContainer = ({
  route,
  index,
}: {
  route: RouteDto;
  index: number;
}) => {
  return (
    <div className='route-container'>
      <h3>Ruta {index + 1}:</h3>
      <span>Prevoznik: {route.carrier.name}</span>
      <span>Odliv: {route.outcome}</span>
      <span>Tip vozila: {route.vehicleType}</span>
      <span>Registarske tablice: {route.licencePlate}</span>
      <span>Valuta: {route.currency}</span>
      <span>Status: {route.status}</span>
      <div>
        {route.shipmentLoadOnLocations.map((shipmentLoadOnLocation, index) =>
          shipmentLoadOnLocation.type === 0 ? (
            <LoadOnData
              shipmentLoadOnLocation={shipmentLoadOnLocation}
              index={index}
              key={index}
            />
          ) : (
            <LoadOffData
              shipmentLoadOnLocation={shipmentLoadOnLocation}
              index={index}
              key={index}
            />
          )
        )}
      </div>
      <div>
        {route.shipmentCustoms.map((shipmentCustom, index) => (
          <CustomsContainer
            shipmentCustom={shipmentCustom}
            index={index}
            key={index}
          />
        ))}
      </div>
      <span>Granični prelaz: {route.borderCrossing.name}</span>
    </div>
  );
};

export default RouteContainer;
