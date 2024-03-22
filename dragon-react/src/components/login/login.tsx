import { useState, ChangeEvent, FormEvent } from 'react';
import loginData from '../../models/loginData';
import DragonApi from '../../services/dragonApi';

interface LoginFormProps {
    dragonApi: DragonApi;
}

export default function Login({ dragonApi }: LoginFormProps) {
    let [isLoggedIn, setIsLoggedIn] = useState(false);
    let [formData, setFormData] = useState(new loginData())

    const handleChange = (event: ChangeEvent<HTMLInputElement>) => {
        const { name, value } = event.target;
        setFormData((prevFormData) => ({ ...prevFormData, [name]: value }));
    };

    const handleSubmit = async (event: FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        let response = await dragonApi.login(formData);
        console.log(response);
        //setIsLoggedIn(true);
    };

    if (isLoggedIn) {
        return (
            <a href="#">Log Out</a>
        );
    }
    else {
        return (
            <form onSubmit={handleSubmit}>
                <label htmlFor="email">Email:</label>
                <input type="text" id="email" name="email" value={formData.email} onChange={handleChange}/>
    
                <label htmlFor="password">Password:</label>
                <input type="text" id="password" name="password" value={formData.password} onChange={handleChange}/>

                <span>Someday, error messages will go here.</span>
    
                <button type="submit">Login</button>
            </form>
        );
    }
};