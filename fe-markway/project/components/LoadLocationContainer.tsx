import { Button, TextField } from "@mui/material";
import SelectControl from "./controls/inputs/SelectControl";
import React, { useEffect, useState } from "react";
import IconButton from '@mui/material/IconButton';
import AddIcon from '@mui/icons-material/Add'
import DeleteIcon from '@mui/icons-material/Delete'
import { DatePicker } from '@mui/x-date-pickers/DatePicker';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';


const LoadLocationContainer = ({
    values,
    setValue,
    control,
    formRules,
    errors,
    form,
    loadLocations
}) => {

    const [divs, setDivs] = useState([]);
    const [counter, setCounter] = useState(1);

    const addNewDiv = () => {
        const newDiv = { id: counter };
        setDivs([...divs, newDiv]);
        setCounter(counter + 1);
    };

    const removeDiv = (index: number) => {
        let listOfDivs = [...divs];
        listOfDivs.splice(index, 1);
        setDivs(listOfDivs);
    }

    return <div className="loadLocationContainerVertical">
        <div className="loadLocationContainer">
            <div className="load-location-container-inputs">
                <SelectControl name='loadOnLocation' value={values['loadOnLocation']} setValue={setValue} control={control} label={"Mesto utovara 1"} nameKey={'name'} valueKey={'id'} options={loadLocations} className="load-on-location-input" />
                <LocalizationProvider dateAdapter={AdapterDayjs}>
                    <DatePicker label="Datum i vreme utovara" />
                </LocalizationProvider>
            </div>
            <IconButton className="loadOnLocationButton" onClick={addNewDiv}>
                <AddIcon fontSize="small" />
            </IconButton>
        </div>
        {divs.map((div, index) => {
            return <div key={div.id} className="loadLocationContainer">
                <div className="load-location-container-inputs">
                    <SelectControl name={'loadOnLocation-' + index} value={values['loadOnLocation-' + index]} setValue={setValue} control={control} label={"Mesto utovara " + (index + 2)} nameKey={'name'} valueKey={'id'} options={loadLocations} />
                    <LocalizationProvider dateAdapter={AdapterDayjs}>
                        <DatePicker label={"Datum i vreme utovara"} />
                    </LocalizationProvider>
                </div>
                <div>
                    <IconButton className="loadOnLocationButton" onClick={addNewDiv}>
                        <AddIcon fontSize="small" />
                    </IconButton>
                    <IconButton className="loadOnLocationButton" onClick={() => removeDiv(index)}>
                        <DeleteIcon fontSize="small" />
                    </IconButton>
                </div>
            </div>
        })}
    </div>
}

export default LoadLocationContainer;