import BorderCrossingDto from "./BorderCrossingDto";
import CustomerDto from "./CustomerDto";
import NoteDto from "./NoteDto";
import RouteDto from "./RouteDto";
import ShipmentLoadOnLocationDto from "./ShipmentLoadOnLocationDto";

class AddShipmentDto {
    constructor(public description: string,public customer: CustomerDto,public merch: string,public merchAmount: number,public income: number,public shipmentRoutes: RouteDto[],public profit: number,public note: NoteDto ) { }
}

export default AddShipmentDto;