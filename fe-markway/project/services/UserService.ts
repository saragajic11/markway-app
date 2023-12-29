import { request } from '../base/HTTP';
import HttpMethod from '../constants/HttpMethod';

export async function register(data: any) {
  return await request(`/users`, data, HttpMethod.POST);
}

export async function login(data: any) {
  const headers = {
    'Content-Type': 'application/x-www-form-urlencoded',
  };
  return await request(`/connect/token`, data, HttpMethod.POST, { headers });
}
