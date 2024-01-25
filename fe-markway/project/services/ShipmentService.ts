import { File } from 'buffer';
import { request } from '../base/HTTP';
import HttpMethod from '../constants/HttpMethod';

export async function getAllShipments() {
  const accessToken = window.localStorage.getItem('access_token');

  const headers = {
    Authorization: `Bearer ${accessToken}`,
    'Content-Type': 'application/json',
  };

  return await request(`/shipment`, [], HttpMethod.GET, { headers: headers });
}

export async function getShipmentLoadOnLocationByShipmentIdAndType(data: any) {
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
  const accessToken = window.localStorage.getItem('access_token');

  const headers = {
    Authorization: `Bearer ${accessToken}`,
    'Content-Type': 'application/json',
  };
  return await request(`/shipment`, shipment, HttpMethod.POST, { headers });
}

export async function deleteShipment(shipmentId: any) {
  const accessToken = window.localStorage.getItem('access_token');

  const headers = {
    Authorization: `Bearer ${accessToken}`,
    'Content-Type': 'application/json',
  };

  return await request(`/shipment/${shipmentId}`, [], HttpMethod.DELETE, {
    headers,
  });
}

export async function attachFile(file: any) {
  return await request(`/pdfs`, file, HttpMethod.POST);
}

export async function addCustomer(customer: any) {
  const accessToken = window.localStorage.getItem('access_token');

  const headers = {
    Authorization: `Bearer ${accessToken}`,
    'Content-Type': 'application/json',
  };
  return await request(`/customer`, customer, HttpMethod.POST, { headers });
}

export async function deleteCustomer(customerId: any) {
  const accessToken = window.localStorage.getItem('access_token');

  const headers = {
    Authorization: `Bearer ${accessToken}`,
    'Content-Type': 'application/json',
  };

  return await request(`/customer/${customerId}`, [], HttpMethod.DELETE, {
    headers,
  });
}

export async function editCustomer(customerId: number, customer: any) {
  const accessToken = window.localStorage.getItem('access_token');

  const headers = {
    Authorization: `Bearer ${accessToken}`,
    'Content-Type': 'application/json',
  };
  return await request(`/customer/${customerId}`, customer, HttpMethod.PUT, {
    headers,
  });
}

export async function editCarrier(carrierId: number, carrier: any) {
  const accessToken = window.localStorage.getItem('access_token');

  const headers = {
    Authorization: `Bearer ${accessToken}`,
    'Content-Type': 'application/json',
  };
  return await request(`/carrier/${carrierId}`, carrier, HttpMethod.PUT, {
    headers,
  });
}

export async function deleteCarrier(carrierId: any) {
  const accessToken = window.localStorage.getItem('access_token');

  const headers = {
    Authorization: `Bearer ${accessToken}`,
    'Content-Type': 'application/json',
  };

  return await request(`/carrier/${carrierId}`, [], HttpMethod.DELETE, {
    headers,
  });
}
