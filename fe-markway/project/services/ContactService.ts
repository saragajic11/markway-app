import { request } from "../base/HTTP";
import HttpMethod from "../constants/HttpMethod";

export async function getAllShipments() {
    return await request(`/shipment`, [], HttpMethod.GET);
}