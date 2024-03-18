import Currency from '@/constants/Currency';
import CustomerDto from './CustomerDto';
import RouteDto from './RouteDto';
import Status from '@/constants/Status';

class AddShipmentDto {
  constructor(
    public externalId: number,
    public description: string,
    public customer: CustomerDto,
    public status: typeof Status,
    public income: number,
    public incomeCurrency: typeof Currency,
    public shipmentRoutes: RouteDto[],
    public profit: number
  ) {}
}

export default AddShipmentDto;
