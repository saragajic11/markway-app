import { File } from 'buffer';
import { request } from '../base/HTTP';
import HttpMethod from '../constants/HttpMethod';

export async function getAllShipments() {
  return await request(`/shipment`, [], HttpMethod.GET);
}

export async function getShipmentLoadOnLocationByShipmentIdAndType(data) {
  return await request(
    `/shipmentloadonlocation/getByShipmentAndType?shipmentId=${data.shipmentId}&type=${data.type}`
  );
}

export async function getAllCarriers() {
  return await request(`/carrier`, [], HttpMethod.GET);
}

export async function addCarrier(data: any) {
  return await request(`/carrier`, data, HttpMethod.POST);
}

export async function getAllLoadLocations() {
  return await request(`/loadonlocation`, [], HttpMethod.GET);
}

export async function getAllCustoms() {
  return await request(`/customs`, [], HttpMethod.GET);
}

export async function getAllBorderCrossings() {
  return await request(`/bordercrossing`, [], HttpMethod.GET);
}

export async function getAllCustomers() {
  return await request(`/customer`, [], HttpMethod.GET);
}

export async function addShipment(shipment: any) {
  return await request(`/shipment`, shipment, HttpMethod.POST);
}

export async function attachFile(file: any) {
  return await request(`/pdfs`, file, HttpMethod.POST);
}
