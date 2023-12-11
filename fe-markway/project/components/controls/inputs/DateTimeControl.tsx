import {Box, TextField} from "@mui/material";
import { LocalizationProvider } from '@mui/x-date-pickers';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs'
import { DatePicker } from '@mui/x-date-pickers/DatePicker';
import React, {useEffect, useState} from "react";
import { DateTimePicker } from '@mui/x-date-pickers/DateTimePicker';
import {Controller} from "react-hook-form";
import { dateAsUTCDate } from "@/util/DateUtil";
import DateFormats from "@/constants/DateFormats";
const DateTimeControl = ({data, value, setValue, size, label, name, disabled, rules, minDateTime, minDate, maxDate, form, ...props}) => {

    const [date, setDate] = useState(value);

    useEffect(() => {
        if(props.dateTime){
            setDate(new Date(value))
            return;
        }
        setDate(value)

    }, [value])

    const changeDate = (date) => {
        let newValue = dateAsUTCDate(date)
        setValue(name, newValue);
        setDate(newValue);
    }

    const changeDateTime = (date) => {
        if(!date){
            date = '';
        }

        setValue(name, date);
        setDate(date);
    }

    return (<Controller
            name={name}
            control={data}
            rules={rules}
            render={({ field }) =>
                <Box className='data-picker-box'>
                    <LocalizationProvider dateAdapter={AdapterDayjs}>
                        {
                            !props.dateTime &&
                            <DatePicker
                                disabled={disabled}
                                label={label}
                                value={date}
                                minDate={minDate}
                                maxDate={maxDate}
                                onChange={(date) => {
                                    if (field?.onChange) {
                                        field.onChange(() => changeDate(date));
                                        return
                                    }
                                    changeDate(date);
                                }}
                                slots={(params) => <TextField {...params} error={props.error} helperText={props.helperText} size={size ? size : 'small'}/>}
                            />
                        }
                        {
                            props.dateTime &&
                            <DateTimePicker
                                label={label}
                                value={date}
                                minDateTime={minDateTime}
                                onChange={(date) => {
                                    if (field?.onChange) {
                                        field.onChange(() => changeDateTime(date));
                                        return
                                    }
                                    changeDateTime(date);
                                }}
                                disableFuture={false}
                                ampm={false}
                                ampmInClock={false}
                                disabled={disabled}
                                slots={(params) => <TextField {...params} error={props.error} helperText={props.helperText} size={size ? size : 'small'}/>}
                            />
                        }
                    </LocalizationProvider>
                </Box>
            }
        >
        </Controller>
    )

}

export default DateTimeControl;