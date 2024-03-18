import GetCarrierDto from './GetCarrierDto';
import VehicleType from '@/constants/VehicleType';
import Currency from '@/constants/Currency';
import ShipmentLoadOnLocationDto from './ShipmentLoadOnLocationDto';
import ShipmentCustomsDto from './ShipmentCustomsDto';
import BorderCrossingDto from './BorderCrossingDto';
import NoteDto from './NoteDto';

class RouteDto {
  constructor(
    public carrier: GetCarrierDto,
    public outcome: number,
    public outcomeCurrency: typeof Currency,
    public vehicleType: typeof VehicleType,
    public licencePlate: string,
    public shipmentLoadOnLocations: ShipmentLoadOnLocationDto[],
    public shipmentCustoms: ShipmentCustomsDto[],
    public borderCrossing: BorderCrossingDto,
    public note: NoteDto,
    public dateOfPayment: number
  ) {}
}

export default RouteDto;
