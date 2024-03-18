import Currency from '@/constants/Currency';
import CustomerDto from './CustomerDto';
import RouteDto from './RouteDto';
import Status from '@/constants/Status';

class GetCustomerDto {
  constructor(public id: number, public name: string) {}
}

export default GetCustomerDto;
