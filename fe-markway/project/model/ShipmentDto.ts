import BorderCrossingDto from "./BorderCrossingDto";
import CarrierDto from "./CarrierDto";
import CustomerDto from "./CustomerDto";
import NoteDto from "./NoteDto";

class ShipmentDto {
    constructor(public description: string, public status: string, public merch: string, public merchAmount: number, public vehicleType: string, public licencePlate: string, public income: number, public outcome: number, public profit: number, public carrierId: number, public carrier: CarrierDto, public customerID: number, public customer: CustomerDto, public borderCrossingId: number, public borderCrossing: BorderCrossingDto, public noteId: number, public note: NoteDto) { }
}

export default ShipmentDto;