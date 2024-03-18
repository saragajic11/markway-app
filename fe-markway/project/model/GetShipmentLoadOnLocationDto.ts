import LoadOnLocationDto from './LoadOnLocationDto';

class GetShipmentLoadOnLocationDto {
  constructor(
    public id: number,
    public date: Date,
    public type: number,
    public loadOnLocation: LoadOnLocationDto,
    public merch: string | undefined,
    public merchAmount: number | undefined
  ) {}
}
export default GetShipmentLoadOnLocationDto;
