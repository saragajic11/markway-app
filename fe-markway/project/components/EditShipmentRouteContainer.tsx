import GetRouteDto from '@/model/GetRouteDto';
import { useEffect, useState } from 'react';
import SelectControl from './controls/inputs/SelectControl';
import EditShipmentLoadOnLocationContainer from './EditShipmentLoadOnLocationContainer';
import VehicleType from '@/constants/VehicleType';
import TextFieldControl from './controls/inputs/TextFieldControl';
import Currency from '@/constants/Currency';
import { Button } from '@mui/material';
import GetShipmentLoadOnLocationDto from '@/model/GetShipmentLoadOnLocationDto';

const EditShipmentRouteContainer = ({
  existingRoutes,
  values,
  setValue,
  control,
  form,
  listOfCarriers,
  loadLocations,
  customs,
  borderCrossings,
  addCarrier,
}: {
  existingRoutes: GetRouteDto[] | [] | undefined;
  values: any;
  setValue: any;
  control: any;
  form: any;
  listOfCarriers: any;
  loadLocations: any;
  customs: any;
  borderCrossings: any;
  addCarrier: any;
}) => {
  const [existingShipmentLoadOnLocations, setExistingShipmentLoadOnLocations] =
    useState<GetShipmentLoadOnLocationDto[] | []>();

  const [divs, setDivs] = useState([]);
  const [counter, setCounter] = useState(1);

  useEffect(() => {
    if (existingRoutes) {
      setRouteValues(existingRoutes);
      setCounter(existingRoutes.length);
    }
  }, existingRoutes);

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

  const setRouteValues = (routes: GetRouteDto[]) => {
    routes.forEach((route, index) => {
      setValue('dateOfPayment' + index, route.dateOfPayment);
      setValue('outcome' + index, route.outcome);
      setValue('licencePlate' + index, route.licencePlate);
    });
  };

  return (
    <div className='ad-route-container-vertical'>
      {existingRoutes?.map((route, index) => {
        return (
          <div key={route.id} className='add-route-container'>
            <hr />
            <span>{'Ruta ' + (index + 1)}</span>
            <SelectControl
              name={'carrier' + index}
              value={route.carrier}
              setValue={setValue}
              control={control}
              label={'Prevoznik'}
              options={listOfCarriers}
              nameKey={'name'}
              valueKey={'id'}
              addCarrier={addCarrier}
            />
            <span className='load-on-limitter'>Utovar</span>
            <EditShipmentLoadOnLocationContainer
              values={values}
              setValue={setValue}
              control={control}
              form={form}
              loadLocations={loadLocations}
              route={''}
              loadLocationType={0}
              shipmentLoadOnLocations={route.shipmentLoadOnLocations.filter(
                (shipmentLoadOnLocation) => shipmentLoadOnLocation.type === 0
              )}
            />
            <SelectControl
              name={'exportDuty' + index}
              value={
                route.shipmentCustoms.find((custom) => custom.type === 1)
                  ?.custom
              }
              setValue={setValue}
              control={control}
              label={'Izvozna carina'}
              options={customs}
              nameKey={'name'}
              valueKey={'id'}
            />
            <SelectControl
              name={'borderCrossings' + index}
              value={route.borderCrossing}
              setValue={setValue}
              control={control}
              label={'Granični prelaz'}
              options={borderCrossings}
              nameKey={'name'}
              valueKey={'id'}
            />
            <SelectControl
              name={'importDuty' + index}
              value={
                route.shipmentCustoms.find((custom) => custom.type === 0)
                  ?.custom
              }
              setValue={setValue}
              control={control}
              label={'Uvozna carina'}
              options={customs}
              nameKey={'name'}
              valueKey={'id'}
            />
            <span className='load-on-limitter'>Istovar</span>
            <EditShipmentLoadOnLocationContainer
              values={values}
              setValue={setValue}
              control={control}
              form={form}
              loadLocations={loadLocations}
              loadLocationType={1}
              shipmentLoadOnLocations={route.shipmentLoadOnLocations.filter(
                (shipmentLoadOnLocation) => shipmentLoadOnLocation.type === 1
              )}
              route={''}
            />
            <SelectControl
              name={'vehicleType' + index}
              value={route.vehicleType}
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
            <div className='price-container'>
              <TextFieldControl
                className='price'
                label='Odliv'
                type='number'
                InputProps={{
                  inputProps: { min: 0 },
                }}
                name={'outcome' + index}
              />
              <SelectControl
                name={'outcomeCurrency' + index}
                value={route.outcomeCurrency}
                setValue={setValue}
                control={control}
                label={'Valuta'}
                options={Currency}
                nameKey={'name'}
                valueKey={'id'}
              />
            </div>
            <TextFieldControl
              label='Rok plaćanja'
              type='number'
              InputProps={{
                inputProps: { min: 0 },
              }}
              name={'dateOfPayment' + index}
            />
            <TextFieldControl label='Beleške' name='note' />
            <Button
              variant='outlined'
              onClick={addNewDiv}
              className='add-route-btn'
            >
              Dodaj još 1 rutu
            </Button>
            <hr />
          </div>
        );
      })}
      {/* {divs.map((div, index) => {
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
              name={'importDuty' + index}
              value={values['importDuty']}
              setValue={setValue}
              control={control}
              label={'Uvozna carina'}
              options={customs}
              nameKey={'name'}
              valueKey={'id'}
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
            <div className='price-container'>
              <TextFieldControl
                label='Odliv'
                type='number'
                InputProps={{
                  inputProps: { min: 0 },
                }}
                name={'outcome' + index}
                className='price'
              />
              <SelectControl
                name={'outcomeCurrency' + index}
                value={values['currency']}
                setValue={setValue}
                control={control}
                label={'Valuta'}
                options={Currency}
                nameKey={'name'}
                valueKey={'id'}
              />
            </div>
            <TextFieldControl
              label='Rok plaćanja'
              type='number'
              InputProps={{
                inputProps: { min: 0 },
              }}
              name={'dateOfPayment' + index}
            />
            <TextFieldControl label='Beleške' name='note' />

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
      })} */}
    </div>
  );
};

export default EditShipmentRouteContainer;
