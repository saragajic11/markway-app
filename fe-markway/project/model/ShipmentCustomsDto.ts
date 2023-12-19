import CustomsDto from './CustomsDto';

class ShipmentCustomsDto {
  constructor(public custom: CustomsDto, public type: number) {}
}

export default ShipmentCustomsDto;
