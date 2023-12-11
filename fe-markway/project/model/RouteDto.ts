import GetCarrierDto from "./GetCarrierDto";
import VehicleType from "@/constants/VehicleType";
import Currency from "@/constants/Currency";
import ShipmentLoadOnLocationDto from "./ShipmentLoadOnLocationDto";
import ShipmentCustomsDto from "./ShipmentCustomsDto";
import BorderCrossingDto from "./BorderCrossingDto";

class RouteDto {
    constructor(public carrier: GetCarrierDto,public outcome: number,public vehicleType: typeof VehicleType,public licencePlate: string,public currency: typeof Currency,public status: number,public shipmentLoadOnLocations: ShipmentLoadOnLocationDto[],public shipmentCustoms: ShipmentCustomsDto[],public borderCrossing: BorderCrossingDto) {}
}

export default RouteDto;