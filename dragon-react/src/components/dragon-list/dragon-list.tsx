import React, { useState, useEffect, MouseEvent } from 'react';
import { DataGrid, GridRowsProp, GridColDef, GridApi } from '@mui/x-data-grid';
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

class dragonRows {
    rowCount: number = 0;
    items: dragon[] = [];
}

function DragonList() {
    let [dragons, setDragons] = useState(new dragonRows());

    useEffect(() => {
        axios.get('http://localhost:5044/dragon/all-dragons?skip=0&take=10')
            .then(response => setDragons(response.data));
    }, []);

    const rows: GridRowsProp = dragons.items;
      
    const columns: GridColDef[] = [
        { field: 'name', headerName: 'Name', width: 150 },
        { field: 'title', headerName: 'Title', width: 150 },
        { field: 'hasFire', headerName: 'Breathes Fire', width: 150 },
        { field: 'hasFlight', headerName: 'Can Fly', width: 150 },
        {
            field: "action",
            headerName: "Action",
            sortable: false,
            filterable: false,
            renderCell: (params: any) => {
                const onClick = (e: MouseEvent<HTMLButtonElement>) => {
                    e.stopPropagation(); // don't select this row after clicking
                    return alert(params.id);
                };
                return <button onClick={onClick}>Click</button>;
            }
          }
    ];

    return (
        <div className='dragon-list'>
            Dragons available for hire!
            <DataGrid rows={rows} columns={columns} />
        </div>
    );
};

export default DragonList;