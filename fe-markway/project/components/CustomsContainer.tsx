import ShipmentCustomsDto from '@/model/ShipmentCustomsDto';

const CustomsContainer = ({
  shipmentCustom,
  index,
}: {
  shipmentCustom: ShipmentCustomsDto;
  index: number;
}) => {
  return (
    <div className='customs-container'>
      {shipmentCustom.type === 0 && (
        <span>Uvozna carina: {shipmentCustom.custom.name}</span>
      )}
      {shipmentCustom.type === 1 && (
        <span>Izlazna carina: {shipmentCustom.custom.name}</span>
      )}
      <span></span>
    </div>
  );
};

export default CustomsContainer;
