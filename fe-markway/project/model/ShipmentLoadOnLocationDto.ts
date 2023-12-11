import LoadOnLocationDto from "./LoadOnLocationDto";

class ShipmentLoadOnLocationDto {

    constructor(public date: Date, public type: number, public loadOnLocation: LoadOnLocationDto) {};
}

export default ShipmentLoadOnLocationDto;