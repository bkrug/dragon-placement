import React, { useState, useEffect, MouseEvent } from 'react';
import { DataGrid, GridRowsProp, GridColDef } from '@mui/x-data-grid';
import dragon from '../../models/dragon';
import rowsWithRowCount from '../../models/rowsWithRowCount';
import DragonForm from '../dragon-form/dragon-form';
import DragonApi from '../../services/dragonApi';
import './dragon-list.css';

interface DragonListProps {
    dragonApi: DragonApi;
}

function DragonList({ dragonApi }: DragonListProps) {
    let [dragons, setDragons] = useState(new rowsWithRowCount<dragon>());
    let [dragonToEdit, setDragonToEdit] = useState(new dragon());

    useEffect(() => {
        dragonApi.getDragons()
            .then(response => setDragons(response));
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
                    const selectedDragon = dragons.items.find((d: dragon) => d.id === params.id) || new dragon();
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
            { dragonToEdit.id > 0 ? <DragonForm formData={dragonToEdit} setFormData={setDragonToEdit} dragonApi={dragonApi} /> : <div/> }
        </div>
    );
};

export default DragonList;