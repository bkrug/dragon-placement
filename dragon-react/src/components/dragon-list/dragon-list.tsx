import React, { useState, useEffect } from 'react';
import { DataGrid, GridRowsProp, GridColDef } from '@mui/x-data-grid';
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

    const rows: GridRowsProp = dragons;
      
      const columns: GridColDef[] = [
        { field: 'name', headerName: 'Name', width: 150, editable: true },
        { field: 'title', headerName: 'Title', width: 150, editable: true },
        { field: 'hasFire', headerName: 'Breathes Fire', width: 150, editable: true },
        { field: 'hasFlight', headerName: 'Can Fly', width: 150, editable: true },
      ];

    return (
        <div className='dragon-list'>
            Dragons available for hire!
            <DataGrid rows={rows} columns={columns} />
        </div>
    );
};

export default DragonList;