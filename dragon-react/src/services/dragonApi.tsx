import axios, { AxiosResponse, AxiosRequestConfig } from 'axios';
import dragon from '../models/dragon';
import loginData from '../models/loginData';
import rowsWithRowCount from '../models/rowsWithRowCount';

export default class DragonApi {
    webOrigin: string = 'https://localhost:7009';
    config: AxiosRequestConfig<any> = {
        withCredentials: true,
        headers: {'Content-Type': 'application/json'}
    };

    errorHandler(error: any): void {
        if (error.message != null) {
            console.log('The following error message was recieved: ' + error.message);
        } else {
            console.error('This error occurred:', error);
        }
    }

    async getDragons(): Promise<rowsWithRowCount<dragon>> {
        const response = await axios
            .get(`${this.webOrigin}/dragon/all-dragons?skip=0&take=10`, this.config)
            .catch((error) => this.errorHandler(error));
        if (response != null)
            return response.data;
        else
            return new rowsWithRowCount<dragon>();
    }

    async editDragon(formData: dragon): Promise<AxiosResponse<any, any>> {
        const response = await axios
            .put(`${this.webOrigin}/dragon/${formData.id}`, formData, this.config);
        return response.data;
    }

    async login(formData: loginData): Promise<boolean> {
        const response = await axios
            .post(`${this.webOrigin}/login?useCookies=true&useSessionCookies=true`, formData, this.config)
            .catch((error) => this.errorHandler(error));
        if (response != null)
            return true;
        else
            return false;
    }

    async logout(): Promise<boolean> {
        const response = await axios
            .post(`${this.webOrigin}/logout`, {}, this.config)
            .catch((error) => this.errorHandler(error));
        if (response != null)
            return true;
        else
            return false;        
    }
}