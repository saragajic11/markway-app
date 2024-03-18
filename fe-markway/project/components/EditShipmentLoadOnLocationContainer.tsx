import { IconButton } from '@mui/material';
import DateTimeControl from './controls/inputs/DateTimeControl';
import SelectControl from './controls/inputs/SelectControl';
import TextFieldControl from './controls/inputs/TextFieldControl';
import AddIcon from '@mui/icons-material/Add';
import { useEffect, useState } from 'react';
import dayjs from 'dayjs';
import GetShipmentLoadOnLocationDto from '@/model/GetShipmentLoadOnLocationDto';

const EditShipmentLoadOnLocationContainer = ({
  values,
  setValue,
  control,
  form,
  loadLocations,
  loadLocationType,
  route,
  shipmentLoadOnLocations,
}: {
  values: any;
  setValue: any;
  control: any;
  form: any;
  loadLocations: any;
  loadLocationType: any;
  route: any;
  shipmentLoadOnLocations: GetShipmentLoadOnLocationDto[] | undefined;
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

  useEffect(() => {
    if (shipmentLoadOnLocations)
      setLoadOnLocationValues(shipmentLoadOnLocations);
  }, shipmentLoadOnLocations);

  const setLoadOnLocationValues = (
    shipmentLoadOnLocations: GetShipmentLoadOnLocationDto[]
  ) => {
    shipmentLoadOnLocations.forEach((shipmentLoadOnLocation, index) => {
      if (shipmentLoadOnLocation.type === 0) {
        setValue(
          'loadOnLocationMerch-' + route + '-' + index,
          shipmentLoadOnLocation.merch
        );
        setValue(
          'loadOnLocationMerchAmount-' + route + '-' + index,
          shipmentLoadOnLocation.merchAmount
        );
      }
    });
  };
  return (
    <div className='loadLocationContainerVertical'>
      {shipmentLoadOnLocations?.map((shipmentLoadOnLocation, index) => {
        return (
          <div
            key={shipmentLoadOnLocation.id}
            className='loadLocationContainer'
          >
            <div className='load-location-container-inputs'>
              <SelectControl
                name={
                  loadLocationType === 0
                    ? 'loadOnLocation-' + route + '-'
                    : 'loadOffLocation-' + route + '-'
                }
                value={shipmentLoadOnLocation.loadOnLocation}
                setValue={setValue}
                control={control}
                label={
                  loadLocationType === 0
                    ? 'Mesto utovara 1'
                    : 'Mesto istovara 1'
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
                value={dayjs(shipmentLoadOnLocation.date)}
                setValue={setValue}
                variant='filled'
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
            <IconButton className='loadOnLocationButton' onClick={addNewDiv}>
              <AddIcon fontSize='small' />
            </IconButton>
          </div>
        );
      })}
    </div>
  );
};

export default EditShipmentLoadOnLocationContainer;
