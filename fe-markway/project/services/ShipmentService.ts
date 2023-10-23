import { request } from "../base/HTTP";
import HttpMethod from "../constants/HttpMethod";

export async function getAllShipments() {
    return await request(`/shipmentloadonlocation/all`, [], HttpMethod.GET);
}

export async function getShipmentLoadOnLocationByShipmentIdAndType(data) {
    return await request(`/shipmentloadonlocation/getByShipmentAndType?shipmentId=${data.shipmentId}&type=${data.type}`)
}