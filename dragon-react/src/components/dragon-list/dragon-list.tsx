import React, { useEffect } from 'react';
import axios from 'axios';
import './dragon-list.css';

function DragonList() {
    useEffect(() => {
        axios.get('http://localhost:5044/dragon/all-dragons?skip=0&take=10')
            .then(response => console.log(response.data));
    }, []);

    return (
        <div className='dragon-list'>
            Dragons available for hire!
        </div>
    );
};

export default DragonList;