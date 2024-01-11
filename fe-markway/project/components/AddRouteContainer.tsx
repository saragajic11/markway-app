import { useState } from 'react';
import SelectControl from './controls/inputs/SelectControl';
import TextFieldControl from './controls/inputs/TextFieldControl';
import LoadLocationContainer from './LoadLocationContainer';
import { Button } from '@mui/material';
import Currency from '@/constants/Currency';
import VehicleType from '@/constants/VehicleType';
import Status from '@/constants/Status';

const AddRouteContainer = ({
  values,
  setValue,
  control,
  formRules,
  errors,
  form,
  listOfCarriers,
  loadLocations,
  customs,
  borderCrossings,
  addCarrier,
}: {
  values: any;
  setValue: any;
  control: any;
  formRules: any;
  errors: any;
  form: any;
  listOfCarriers: any;
  loadLocations: any;
  customs: any;
  borderCrossings: any;
  addCarrier: any;
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
  };

  return (
    <div className='ad-route-container-vertical'>
      <div className='add-route-container'>
        <hr />
        <span>Ruta 1</span>
        <SelectControl
          name='carrier'
          value={values['carrier']}
          setValue={setValue}
          control={control}
          label={'Prevoznik'}
          options={listOfCarriers}
          nameKey={'name'}
          valueKey={'id'}
          addCarrier={addCarrier}
        />
        <TextFieldControl
          label='Odliv'
          type='number'
          InputProps={{
            inputProps: { min: 0 },
          }}
          name='outcome'
        />
        <SelectControl
          name='currency'
          value={values['currency']}
          setValue={setValue}
          control={control}
          label={'Valuta'}
          options={Currency}
          nameKey={'name'}
          valueKey={'id'}
        />
        <SelectControl
          name='vehicleType'
          value={values['vehicleType']}
          setValue={setValue}
          control={control}
          label={'Tip vozila'}
          options={VehicleType}
          nameKey={'name'}
          valueKey={'id'}
        />
        <TextFieldControl label='Registarske tablice' name='licencePlate' />
        <span className='load-on-limitter'>Utovar</span>
        <LoadLocationContainer
          values={values}
          setValue={setValue}
          control={control}
          formRules={formRules}
          errors={errors}
          form={form}
          loadLocations={loadLocations}
          loadLocationType={0}
          route={''}
        />
        <span className='load-on-limitter'>Istovar</span>
        <LoadLocationContainer
          values={values}
          setValue={setValue}
          control={control}
          formRules={formRules}
          errors={errors}
          form={form}
          loadLocations={loadLocations}
          loadLocationType={1}
          route={''}
        />

        <SelectControl
          name='importDuty'
          value={values['importDuty']}
          setValue={setValue}
          control={control}
          label={'Uvozna carina'}
          options={customs}
          nameKey={'name'}
          valueKey={'id'}
        />
        <SelectControl
          name='exportDuty'
          value={values['exportDuty']}
          setValue={setValue}
          control={control}
          label={'Izvozna carina'}
          options={customs}
          nameKey={'name'}
          valueKey={'id'}
        />
        <SelectControl
          name='borderCrossings'
          value={values['borderCrossings']}
          setValue={setValue}
          control={control}
          label={'Granični prelaz'}
          options={borderCrossings}
          nameKey={'name'}
          valueKey={'id'}
        />
        <SelectControl
          name='status'
          value={values['status']}
          setValue={setValue}
          control={control}
          label={'Status'}
          options={Status}
          nameKey={'name'}
          valueKey={'id'}
        />
        <Button
          variant='outlined'
          onClick={addNewDiv}
          className='add-route-btn'
        >
          Dodaj još 1 rutu
        </Button>
        <hr />
      </div>
      {divs.map((div, index) => {
        return (
          <div key={div.id} className='add-route-container'>
            <span>Ruta {index + 2}</span>
            <SelectControl
              name={'carrier' + index}
              value={values['carrier']}
              setValue={setValue}
              control={control}
              label={'Prevoznik'}
              options={listOfCarriers}
              nameKey={'name'}
              valueKey={'id'}
              addCarrier={addCarrier}
            />
            <TextFieldControl
              label='Odliv'
              type='number'
              InputProps={{
                inputProps: { min: 0 },
              }}
              name={'outcome' + index}
            />
            <SelectControl
              name={'currency' + index}
              value={values['currency']}
              setValue={setValue}
              control={control}
              label={'Valuta'}
              options={Currency}
              nameKey={'name'}
              valueKey={'id'}
            />
            <SelectControl
              name={'vehicleType' + index}
              value={values['vehicleType']}
              setValue={setValue}
              control={control}
              label={'Tip vozila'}
              options={VehicleType}
              nameKey={'name'}
              valueKey={'id'}
            />
            <TextFieldControl
              label='Registarske tablice'
              name={'licencePlate' + index}
            />
            <span className='load-on-limitter'>Utovar</span>
            <LoadLocationContainer
              values={values}
              setValue={setValue}
              control={control}
              formRules={formRules}
              errors={errors}
              form={form}
              loadLocations={loadLocations}
              loadLocationType={0}
              route={index}
            />
            <span className='load-on-limitter'>Istovar</span>
            <LoadLocationContainer
              values={values}
              setValue={setValue}
              control={control}
              formRules={formRules}
              errors={errors}
              form={form}
              loadLocations={loadLocations}
              loadLocationType={1}
              route={index}
            />

            <SelectControl
              name={'importDuty' + index}
              value={values['importDuty']}
              setValue={setValue}
              control={control}
              label={'Uvozna carina'}
              options={customs}
              nameKey={'name'}
              valueKey={'id'}
            />
            <SelectControl
              name={'exportDuty' + index}
              value={values['exportDuty']}
              setValue={setValue}
              control={control}
              label={'Izvozna carina'}
              options={customs}
              nameKey={'name'}
              valueKey={'id'}
            />
            <SelectControl
              name={'borderCrossings' + index}
              value={values['borderCrossings']}
              setValue={setValue}
              control={control}
              label={'Granični prelaz'}
              options={borderCrossings}
              nameKey={'name'}
              valueKey={'id'}
            />
            <SelectControl
              name={'status' + index}
              value={values['status']}
              setValue={setValue}
              control={control}
              label={'Status'}
              options={Status}
              nameKey={'name'}
              valueKey={'id'}
            />
            <Button
              variant='outlined'
              onClick={addNewDiv}
              className='add-route-btn'
            >
              Dodaj još 1 rutu
            </Button>

            <Button
              variant='outlined'
              onClick={() => removeDiv(index)}
              className='add-route-btn'
            >
              Obriši rutu
            </Button>
            <hr />
          </div>
        );
      })}
      {/* {divs.map((div, index) => {
        return (
          <div key={div.id} className='loadLocationContainer'>
            <div className='load-location-container-inputs'>
              <SelectControl
                name={
                  loadLocationType === 0
                    ? 'loadOnLocation' + index
                    : 'loadOffLocation' + index
                }
                value={
                  loadLocationType === 0
                    ? values['loadOnLocation' + index]
                    : values['loadOffLocation' + index]
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
                    ? 'loadOnLocationDate' + index
                    : 'loadOffLocationDate' + index
                }
                value={
                  loadLocationType === 0
                    ? values['loadOnLocationDate' + index]
                    : values['loadOffLocationDate' + index]
                }
                data={control}
                fullWidth
                margin='normal'
                setValue={setValue}
                variant='filled'
                minDate={getCurrentDate()}
              />
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
      })} */}
    </div>
  );
};

export default AddRouteContainer;
