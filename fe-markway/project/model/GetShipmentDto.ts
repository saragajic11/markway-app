import Currency from '@/constants/Currency';
import CustomerDto from './CustomerDto';
import RouteDto from './RouteDto';
import Status from '@/constants/Status';
import GetCustomerDto from './GetCustomerDto';
import GetCarrierDto from './GetCarrierDto';
import NoteDto from './NoteDto';
import GetRouteDto from './GetRouteDto';

class GetShipmentDto {
  constructor(
    public id: number,
    public externalId: number,
    public description: string,
    public customerID: number,
    public customer: GetCustomerDto,
    public status: number,
    public income: number,
    public incomeCurrency: number,
    public shipmentRoutes: GetRouteDto[],
    public profit: number,
    public carrierId: number,
    public carrier: GetCarrierDto
  ) {}
}

export default GetShipmentDto;
