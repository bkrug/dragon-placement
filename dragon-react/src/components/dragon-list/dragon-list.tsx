import React, { useState, useEffect, MouseEvent } from 'react';
import { DataGrid, GridRowsProp, GridColDef } from '@mui/x-data-grid';
import axios from 'axios';
import dragon from '../../models/dragon';
import rowsWithRowCount from '../../models/rowsWithRowCount';
import DragonForm from '../dragon-form/dragon-form';
import './dragon-list.css';

function DragonList() {
    let [dragons, setDragons] = useState(new rowsWithRowCount<dragon>());
    let [dragonToEdit, setDragonToEdit] = useState(new dragon());

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
                    e.stopPropagation();
                    const selectedDragon = dragons.items.find((d: dragon) => d.id == params.id) || new dragon();
                    setDragonToEdit(selectedDragon);
                    return params.id;
                };
                return <button onClick={onClick}>Click</button>;
            }
          }
    ];

    return (
        <div className='dragon-list'>
            <DataGrid rows={rows} columns={columns} />
            { dragonToEdit.id > 0 ? <DragonForm formData={dragonToEdit} setFormData={setDragonToEdit} /> : <div/> }
        </div>
    );
};

export default DragonList;