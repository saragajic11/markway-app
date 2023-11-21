import TextField from "@mui/material/TextField";
import { Controller } from "react-hook-form";
import React from "react";

const TextFieldControl = (props) => {

    const options = {}

    if (props.onChange) {
        options.onChange = props.onChange;
    }

    if (props.className) {
        options.className = props.className;
    }
    if (props.InputProps) {
        options.InputProps = props.InputProps;
    }

    if (props.extendImage) {
        options.InputProps = { ...props.InputProps, endAdornment: <img src={!props.isHideIcon ? "/images/eye.svg" : "/images/eye-off.svg"} onClick={() => props.setHideIcon(!props.isHideIcon)} /> }
    }

    return <Controller
        {...props}
        control={props.control}
        name={props.name}
        defaultValue={props.defaultValue}
        rules={props.rules}
        render={({ field }) =>
            <TextField {...field}
                {...options}
                onKeyPress={props?.onKeyPress}
                inputProps={{ maxLength: props?.maxLength, minLength: props?.minLength }}

                InputLabelProps={{ ...field, shrink: true }}
                size={props.size ? props.size : 'small'}
                fullWidth={props.fullWidth ? props.fullWidth : true}
                type={props.type}
                margin={props.margin ? props.margin : 'normal'}
                error={props.error}
                helperText={props.helperText}
                label={props.label}
                disabled={props.disabled}
                multiline={props.multiline}
                rows={props.rows}
                maxRows={props.maxRows}
                minRows={props.minRows}
                placeholder={props.placeholder}
            />}
    />
}

export default TextFieldControl;