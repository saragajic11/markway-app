import { Button, TextField } from '@mui/material';
import SelectControl from './controls/inputs/SelectControl';
import React, { useEffect, useState } from 'react';
import IconButton from '@mui/material/IconButton';
import AddIcon from '@mui/icons-material/Add';
import DeleteIcon from '@mui/icons-material/Delete';
import { DatePicker } from '@mui/x-date-pickers/DatePicker';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import DateTimeControl from './controls/inputs/DateTimeControl';
import dayjs from 'dayjs';
import TextFieldControl from './controls/inputs/TextFieldControl';

const LoadLocationContainer = ({
  values,
  setValue,
  control,
  formRules,
  errors,
  form,
  loadLocations,
  loadLocationType,
  route,
}: {
  values: any;
  setValue: any;
  control: any;
  formRules: any;
  errors: any;
  form: any;
  loadLocations: any;
  loadLocationType: any;
  route: any;
}) => {
  const [divs, setDivs] = useState([]);
  const [counter, setCounter] = useState(1);

  const getCurrentDate = () => {
    return dayjs().format('YYYY-MM-DD');
  };

  const addNewDiv = () => {
    const newDiv = { id: counter };
    setDivs([...divs, newDiv]);
    setCounter(counter + 1);
  };

  const removeDiv = (index: number) => {
    let listOfDivs = [...divs];
    listOfDivs.splice(index, 1);
    setDivs(listOfDivs);
  };

  //TODO: u dom-u, mozda umesto indexa treba koristiti div.id za name i value, ali proveri
  //TODO: disable-uj datum stariji od danasnjeg

  return (
    <div className='loadLocationContainerVertical'>
      <div className='loadLocationContainer'>
        <div className='load-location-container-inputs'>
          <SelectControl
            name={
              loadLocationType === 0
                ? 'loadOnLocation-' + route + '-'
                : 'loadOffLocation-' + route + '-'
            }
            value={
              loadLocationType === 0
                ? values['loadOnLocation-' + route + '-']
                : values['loadOffLocation-' + route + '-']
            }
            setValue={setValue}
            control={control}
            label={
              loadLocationType === 0 ? 'Mesto utovara 1' : 'Mesto istovara 1'
            }
            nameKey={'name'}
            valueKey={'id'}
            options={loadLocations}
            className='load-on-location-input'
          />
          <DateTimeControl
            dateTime={true}
            label={
              loadLocationType === 0
                ? 'Datum i vreme utovara'
                : 'Datum i vreme istovara'
            }
            name={
              loadLocationType === 0
                ? 'loadOnLocationDate-' + route + '-'
                : 'loadOffLocationDate-' + route + '-'
            }
            data={control}
            fullWidth
            margin='normal'
            value={
              loadLocationType === 0
                ? values['loadOnLocationDate-' + route + '-']
                  ? values['loadOnLocationDate-' + route + '-']
                  : NaN
                : values['loadOffLocationDate-' + route + '-']
                ? values['loadOffLocationDate-' + route + '-']
                : NaN
            }
            setValue={setValue}
            variant='filled'
            minDate={getCurrentDate()}
          />
          {loadLocationType === 0 && (
            <div>
              <TextFieldControl
                label='Vrsta robe'
                name={'loadOnLocationMerch-' + route + '-'}
              />
              <TextFieldControl
                label='Količina robe'
                name={'loadOnLocationMerchAmount-' + route + '-'}
              />
            </div>
          )}
        </div>
        <IconButton className='loadOnLocationButton' onClick={addNewDiv}>
          <AddIcon fontSize='small' />
        </IconButton>
      </div>
      {divs.map((div, index) => {
        return (
          <div key={div.id} className='loadLocationContainer'>
            <div className='load-location-container-inputs'>
              <SelectControl
                name={
                  loadLocationType === 0
                    ? 'loadOnLocation-' + route + '-' + index
                    : 'loadOffLocation-' + route + '-' + index
                }
                value={
                  loadLocationType === 0
                    ? values['loadOnLocation-' + route + '-' + index]
                    : values['loadOffLocation-' + route + '-' + index]
                }
                setValue={setValue}
                control={control}
                label={
                  loadLocationType === 0
                    ? 'Mesto utovara ' + (index + 2)
                    : 'Mesto istovara ' + (index + 2)
                }
                nameKey={'name'}
                valueKey={'id'}
                options={loadLocations}
              />
              <DateTimeControl
                dateTime={true}
                label={
                  loadLocationType === 0
                    ? 'Datum i vreme utovara'
                    : 'Datum i vreme istovara'
                }
                name={
                  loadLocationType === 0
                    ? 'loadOnLocationDate-' + route + '-' + index
                    : 'loadOffLocationDate-' + route + '-' + index
                }
                value={
                  loadLocationType === 0
                    ? values['loadOnLocationDate-' + route + '-' + index]
                    : values['loadOffLocationDate-' + route + '-' + index]
                }
                data={control}
                fullWidth
                margin='normal'
                setValue={setValue}
                variant='filled'
                minDate={getCurrentDate()}
              />
              {loadLocationType === 0 && (
                <div>
                  <TextFieldControl
                    label='Vrsta robe'
                    name={'loadOnLocationMerch-' + route + '-' + index}
                  />
                  <TextFieldControl
                    label='Količina robe'
                    name={'loadOnLocationMerchAmount-' + route + '-' + index}
                  />
                </div>
              )}
            </div>
            <div>
              <IconButton className='loadOnLocationButton' onClick={addNewDiv}>
                <AddIcon fontSize='small' />
              </IconButton>
              <IconButton
                className='loadOnLocationButton'
                onClick={() => removeDiv(index)}
              >
                <DeleteIcon fontSize='small' />
              </IconButton>
            </div>
          </div>
        );
      })}
    </div>
  );
};

export default LoadLocationContainer;
