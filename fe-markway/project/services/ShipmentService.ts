import AddCarrierDto from "@/model/AddCarrierDto";
import { request } from "../base/HTTP";
import HttpMethod from "../constants/HttpMethod";

export async function getAllShipments() {
    return await request(`/shipmentloadonlocation/all`, [], HttpMethod.GET);
}

export async function getShipmentLoadOnLocationByShipmentIdAndType(data) {
    return await request(`/shipmentloadonlocation/getByShipmentAndType?shipmentId=${data.shipmentId}&type=${data.type}`)
}

export async function getAllCarriers() {
    return await request(`/carrier`, [], HttpMethod.GET);
}

export async function addCarrier(data: any) {
    return await request(`/carrier`, data, HttpMethod.POST);
}