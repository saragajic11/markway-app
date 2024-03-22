import GetCarrierDto from './GetCarrierDto';
import VehicleType from '@/constants/VehicleType';
import Currency from '@/constants/Currency';
import ShipmentLoadOnLocationDto from './ShipmentLoadOnLocationDto';
import ShipmentCustomsDto from './ShipmentCustomsDto';
import BorderCrossingDto from './BorderCrossingDto';
import NoteDto from './NoteDto';
import GetShipmentLoadOnLocationDto from './GetShipmentLoadOnLocationDto';
import GetShipmentCustomsDto from './GetShipmentCustomsDto';
import GetBorderCrossingDto from './GetBorderCrossingDto';

class GetRouteDto {
  constructor(
    public id: number,
    public carrier: GetCarrierDto,
    public outcome: number,
    public outcomeCurrency: typeof Currency,
    public vehicleType: typeof VehicleType,
    public licencePlate: string,
    public shipmentLoadOnLocations: GetShipmentLoadOnLocationDto[],
    public shipmentCustoms: GetShipmentCustomsDto[],
    public borderCrossing: GetBorderCrossingDto,
    public note: NoteDto,
    public dateOfPayment: number
  ) {}
}

export default GetRouteDto;
