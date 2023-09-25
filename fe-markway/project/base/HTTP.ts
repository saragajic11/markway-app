import axios, { AxiosInstance, AxiosResponse } from 'axios';
import HttpMethod from '../constants/HttpMethod';

export const Axios = (function () {
    let instance: AxiosInstance;

    function createInstance() {
        return axios.create({
            baseURL: process.env.NEXT_PUBLIC_APP_BASE_URL,
        });
    }

    return {
        getInstance: function () {
            if (!instance) {
                instance = createInstance();
            }

            instance.all = axios.all;

            return instance;
        },
    };
})();

Axios.getInstance().interceptors.response.use(
    (response: AxiosResponse) => {

        response.ok = response.status >= 200 && response.status < 300;
        return response;
    },
    async (error) => {
        const { response } = error;
        // if (response && response.status === 404) {
        //     window.location.href = '/404';
        // } else if (response && response.status === 500) {
        //     if (!isLocalhost()) {
        //         window.location.href = '/500';
        //     }
        // } else if (response && response.status === 403) {
        //     window.location.href = '/403';
        // } else if (response && response.status === 401) {
        //     window.location.href = '/401';
        // }

        return error;
    }
);

export async function request(
    url: string,
    data: any[] = [],
    method: HttpMethod = HttpMethod.GET,
    options: Record<string, any> = {}
) {
    try {
        return await connect(url, data, method, options);
    } catch {
        if (!isLocalhost()) {
            // window.location.href = '/500';
        }
    }
}

export async function connect(
    url: string,
    data: any,
    method: HttpMethod,
    options: Record<string, any>
) {
    switch (method) {
        case HttpMethod.GET:
            return await Axios.getInstance().get(url + makeParametersList(data), options);
        case HttpMethod.POST:
            return Axios.getInstance().post(url, data, options);
        case HttpMethod.PUT:
            return Axios.getInstance().put(url, data, options);
        case HttpMethod.PATCH:
            return Axios.getInstance().patch(url, data, options);
        case HttpMethod.DELETE:
            return Axios.getInstance().delete(url, options);
    }
}

export function makeParametersList(parameters: Record<string, any>): string {
    let parametersList = `?`;

    Object.keys(parameters).map((key, index) => {
        parametersList += parameters[key] ? `${key}=${parameters[key]}&` : '';
    });

    parametersList = parametersList.slice(0, -1);

    return parametersList === '?' ? '' : parametersList;
}

function isLocalhost() {
    // return window.location.href.includes('localhost');
    return true;
}
