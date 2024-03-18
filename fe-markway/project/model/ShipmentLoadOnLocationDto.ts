import LoadOnLocationDto from './LoadOnLocationDto';

class ShipmentLoadOnLocationDto {
  constructor(
    public date: Date,
    public type: number,
    public loadOnLocation: LoadOnLocationDto,
    public merch: string | undefined,
    public merchAmount: number | undefined
  ) {}
}

export default ShipmentLoadOnLocationDto;
