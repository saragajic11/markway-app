import BorderCrossingDto from './BorderCrossingDto';
import CarrierDto from './RouteDto';
import CustomerDto from './CustomerDto';
import NoteDto from './NoteDto';
import ShipmentLoadOnLocationDto from './ShipmentLoadOnLocationDto';
import RouteDto from './RouteDto';

class ShipmentDto {
  constructor(
    public id: number,
    public description: string,
    public merch: string,
    public merchAmount: number,
    public income: number,
    public profit: number,
    public status: number,
    public carrierId: number,
    public carrier: CarrierDto,
    public customerID: number,
    public customer: CustomerDto,
    public noteId: number,
    public note: NoteDto,
    public shipmentRoutes: RouteDto[]
  ) {}
}

export default ShipmentDto;
