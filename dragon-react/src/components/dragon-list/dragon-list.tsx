import React, { useState, useEffect } from 'react';
import axios from 'axios';
import './dragon-list.css';

//TODO: Move this to some "model" folder. Add more properties
class dragon {
    name: string = "";
}

function DragonList() {
    let emptyList: dragon[] = [];
    let [dragons, setDragons] = useState(emptyList);

    useEffect(() => {
        axios.get('http://localhost:5044/dragon/all-dragons?skip=0&take=10')
            .then(response => setDragons(response.data));
    }, []);

    let dragonElements = dragons.map(d => (<li>{d.name}</li>));

    return (
        <div className='dragon-list'>
            Dragons available for hire!
            {
                dragons.length
            }
            <ul>
                { dragonElements }
            </ul>
        </div>
    );
};

export default DragonList;