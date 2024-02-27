import axios, { AxiosResponse } from 'axios';
import dragon from '../models/dragon';
import rowsWithRowCount from '../models/rowsWithRowCount';

export default class DragonApi {
    async getDragons(): Promise<rowsWithRowCount<dragon>> {
        const response = await axios.get('http://localhost:5044/dragon/all-dragons?skip=0&take=10');
        return response.data;
    }

    async editDragon(formData: dragon): Promise<AxiosResponse<any, any>> {
        const response = await axios.put(`http://localhost:5044/dragon/${formData.id}`, formData);
        return response.data;
    }
}