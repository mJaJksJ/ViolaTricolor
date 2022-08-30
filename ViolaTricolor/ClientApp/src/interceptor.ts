import { AxiosInstance, AxiosRequestConfig } from "axios";
import { LOCAL_STORAGE_TOKEN } from "./constsAndDicts/localStorageConsts";

/**
 * Non-automatically add to api.ts
 * Need add in api.ts in constuctor line 'addInterceptor(this.instance);' after line 'this.instance = instance ? instance : axios.create();'
 */
export const addInterceptor = (instance: AxiosInstance) => {
    instance.interceptors.request.use(function (config: AxiosRequestConfig) {
        config.headers = { ...config.headers, Authorization: `Bearer ${localStorage.getItem(LOCAL_STORAGE_TOKEN)}` }
        return config;
    }, function (error) {
        return Promise.reject(error);
    });
}
