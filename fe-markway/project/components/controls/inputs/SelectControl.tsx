import { Controller } from 'react-hook-form';
import React, { useEffect, useState } from 'react';
import {
  Box,
  Chip,
  FormControl,
  FormHelperText,
  InputLabel,
  MenuItem,
  Select,
} from '@mui/material';
import { getDropdownOptions } from '../util/DropdownUtil';
import ArrowDropDownIcon from '@mui/icons-material/ArrowDropDown';

const SelectControl = (props) => {
  const [value, setValue] = useState(
    props.value && props.value[props.valueKey]
      ? props.value[props.valueKey]
      : props.value
  );
  const [multipleValues, setMultipleValues] = useState([]);

  const handleMultipleValues = (event) => {
    setMultipleValues(event.target.value);
    props.setValue(props.name, findMultipleObjects(event.target.value));
  };

  const findObjectName = (value) => {
    let object = props.options.find((x) => x.id == value);
    return object?.name;
  };

  const findMultipleObjects = (values) => {
    let result = [];
    for (let option of props.options) {
      for (let value of values) {
        if (option.id == value) {
          result.push(option);
        }
      }
    }
    return result;
  };

  const changeValue = (newValue) => {
    props.setValue(props.name, getValue(newValue));
    setValue(newValue);
  };

  // useEffect(() => {
  //   if (props.value && !(props.value instanceof Object)) {
  //     setValue(props.value);
  //     return;
  //   }

  //   setValue(
  //     props.value && props.value[props.valueKey]
  //       ? props.value[props.valueKey]
  //       : -1
  //   );
  // }, [props.value]);

  const getValue = (value) => {
    if (!props.valueKey || !props.options) {
      return value;
    }

    return props.options.find((x) => x[props.valueKey] === value);
  };

  return (
    <Box sx={{ minWidth: 120 }} className={'select-box ' + props.className}>
      <FormControl fullWidth>
        <InputLabel id='demo-simple-select-label' error={props.error}>
          {props.label}
        </InputLabel>
        {props.control && (
          <Controller
            rules={props.rules}
            name={props.name}
            defaultValue={props.value}
            render={({ field }) => (
              <Select
                {...field}
                disabled={props.disabled}
                value={value}
                size={props.size ? props.size : 'small'}
                onOpen={props?.onOpen}
                label={props.label}
                error={props.error}
                onChange={(e) => {
                  if (field?.onChange) {
                    field.onChange(() => changeValue(e.target.value));
                    return;
                  }
                  changeValue(e.target.value);
                }}
              >
                {getDropdownOptions(
                  props.options,
                  props.nameKey,
                  props.valueKey,
                  props.selectOptions,
                  props.imgKey,
                  false,
                  props.addCarrier
                )}
              </Select>
            )}
          />
        )}
        {!props.control && !props.multiple && (
          <Select
            disabled={props.disabled}
            value={value}
            size={props.size ? props.size : 'small'}
            label={props.label}
            error={props.error}
            onChange={(e) => changeValue(e.target.value)}
          >
            {getDropdownOptions(
              props.options,
              props.nameKey,
              props.valueKey,
              props.selectOptions
            )}
          </Select>
        )}

        {props.multiple && (
          <Select
            disabled={props.disabled}
            value={multipleValues}
            size={props.size ? props.size : 'small'}
            label={props.label}
            error={props.error}
            multiple
            onChange={handleMultipleValues}
            renderValue={(selected) => (
              <Box sx={{ display: 'flex', flexWrap: 'wrap', gap: 0.5 }}>
                {selected.map((value) => {
                  return <Chip key={value} label={findObjectName(value)} />;
                })}
              </Box>
            )}
            IconComponent={() =>
              props.iconPath ? (
                <img src={props.iconPath} />
              ) : (
                <ArrowDropDownIcon />
              )
            }
          >
            {getDropdownOptions(
              props.options,
              props.nameKey,
              props.valueKey,
              props.selectOptions,
              props.disableMenuItem
            )}
          </Select>
        )}

        {props.error && <FormHelperText>{props.helperText}</FormHelperText>}
      </FormControl>
    </Box>
  );
};

export default SelectControl;
