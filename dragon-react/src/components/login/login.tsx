import { useState, ChangeEvent, MouseEvent, FormEvent } from 'react';
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
        let success = await dragonApi.login(formData);
        setIsLoggedIn(success);
    };

    const handleLogout = async (event: MouseEvent<HTMLButtonElement>) => {
        event.preventDefault();
        await dragonApi.logout();
        setIsLoggedIn(false);
    };

    if (isLoggedIn) {
        return (
            <button onClick={handleLogout}>Log Out</button>
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