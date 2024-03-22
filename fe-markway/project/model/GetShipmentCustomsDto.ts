import CustomsDto from './CustomsDto';

class GetShipmentCustomsDto {
  constructor(
    public id: number,
    public custom: CustomsDto,
    public type: number
  ) {}
}

export default GetShipmentCustomsDto;
