import axios, { AxiosResponse } from 'axios';
import dragon from '../models/dragon';
import rowsWithRowCount from '../models/rowsWithRowCount';

export default class DragonApi {
    async getDragons(): Promise<rowsWithRowCount<dragon>> {
        const response = await axios.get('http://localhost:5044/dragon/all-dragons?skip=0&take=10')
            .catch((error) => {
                if (error.message != null) {
                    console.log('The following error message was recieved: ' + error.message);
                } else {
                    console.error('This error occurred:', error);
                }
            });
        if (response != null)
            return response.data;
        else
            return new rowsWithRowCount<dragon>();
    }

    async editDragon(formData: dragon): Promise<AxiosResponse<any, any>> {
        const response = await axios.put(`http://localhost:5044/dragon/${formData.id}`, formData);
        return response.data;
    }
}