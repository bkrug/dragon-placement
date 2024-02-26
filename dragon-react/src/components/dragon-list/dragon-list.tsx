import React, { useState, useEffect } from 'react';
import axios from 'axios';
import './dragon-list.css';

//TODO: Move this to some "model" folder. Add more properties
class dragon {
    id: number = 0;
    name: string = "";
    title: string = "";
    hasFire: boolean = false;
    hasFlight: boolean = false;
}

function DragonList() {
    let emptyList: dragon[] = [];
    let [dragons, setDragons] = useState(emptyList);

    useEffect(() => {
        axios.get('http://localhost:5044/dragon/all-dragons?skip=0&take=10')
            .then(response => setDragons(response.data));
    }, []);

    let dragonElements = dragons.map(d => (
        <div key={d.id} className="dragon-card">
            <span>{d.name}</span>
            <span>{d.title}</span>
            <span>{d.hasFire ? "breathes fire" : "does not breath fire"}</span>
            <span>{d.hasFlight ? "flies" : "does not fly"}</span>
        </div>
    ));

    return (
        <div className='dragon-list'>
            Dragons available for hire!
            <div>
                { dragonElements }
            </div>
        </div>
    );
};

export default DragonList;