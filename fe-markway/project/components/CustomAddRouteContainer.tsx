import { useState } from 'react';
import SelectControl from './controls/inputs/SelectControl';
import TextFieldControl from './controls/inputs/TextFieldControl';
import LoadLocationContainer from './LoadLocationContainer';
import { Button } from '@mui/material';
import Currency from '@/constants/Currency';
import VehicleType from '@/constants/VehicleType';
import Status from '@/constants/Status';
import CustomSingleSelect from './customSingleSelect/CustomSingleSelect';
import GetCarrierDto from '@/model/GetCarrierDto';

const CustomAddRouteContainer = ({
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
  methods,
  remapedCarrier,
  remapedDefaultCarrier,
  remapedExportDuty,
  remapedDefaultExportDuty,
  remapedBorderCrossing,
  remapedDefaultBorderCrossing,
  remapedDefaultImportDuty,
  remapedVehicleType,
  remapedDefaultVehicleType,
  licencePlate,
  remapedCurrencies,
  outcome,
  remapedDefaultOutcomeCurrency,
  dateOfPayment,
}: {
  values: any;
  setValue: any;
  control: any;
  formRules: any | undefined;
  errors: any | undefined;
  form: any;
  listOfCarriers: any;
  loadLocations: any;
  customs: any;
  borderCrossings: any;
  addCarrier: any;
  methods: any;
  remapedCarrier: any;
  remapedDefaultCarrier: any;
  remapedExportDuty: any;
  remapedDefaultExportDuty: any;
  remapedBorderCrossing: any;
  remapedDefaultBorderCrossing: any;
  remapedDefaultImportDuty: any;
  remapedVehicleType: any;
  remapedDefaultVehicleType: any;
  licencePlate: any;
  remapedCurrencies: any;
  outcome: any;
  remapedDefaultOutcomeCurrency: any;
  dateOfPayment: any;
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

  //TODO: srediti beleske

  return (
    <div className='ad-route-container-vertical'>
      <div className='add-route-container'>
        <hr />
        <span>Ruta 1</span>
        <CustomSingleSelect
          options={remapedCarrier}
          name={'carrier'}
          optionLabel='Prevoznik'
          selected={false}
          defaultValue={remapedDefaultCarrier}
          register={methods.register}
        />
        <span className='load-on-limitter'>Utovar</span>
        {/* <LoadLocationContainer
          values={values}
          setValue={setValue}
          control={control}
          formRules={formRules}
          errors={errors}
          form={form}
          loadLocations={loadLocations}
          loadLocationType={0}
          route={''}
        /> */}
        <CustomSingleSelect
          options={remapedExportDuty}
          name={'exportDuty'}
          optionLabel='Izvozna carina'
          selected={false}
          defaultValue={remapedDefaultExportDuty}
          register={methods.register}
        />
        <CustomSingleSelect
          options={remapedBorderCrossing}
          name={'borderCrossings'}
          optionLabel='Granični prelaz'
          selected={false}
          defaultValue={remapedDefaultBorderCrossing}
          register={methods.register}
        />
        <CustomSingleSelect
          options={remapedExportDuty}
          name={'importDuty'}
          optionLabel='Uvozna carina'
          selected={false}
          defaultValue={remapedDefaultImportDuty}
          register={methods.register}
        />
        <span className='load-on-limitter'>Istovar</span>
        {/* <LoadLocationContainer
          values={values}
          setValue={setValue}
          control={control}
          formRules={formRules}
          errors={errors}
          form={form}
          loadLocations={loadLocations}
          loadLocationType={1}
          route={''}
        /> */}
        <CustomSingleSelect
          options={remapedVehicleType}
          name={'vehicleType'}
          optionLabel='Tip vozila'
          selected={false}
          defaultValue={remapedDefaultVehicleType}
          register={methods.register}
        />
        <div className='text-input-container'>
          <label htmlFor='licencePlate'>Registarske tablice</label>
          <input
            {...methods.register('licencePlate')}
            type='text'
            defaultValue={licencePlate}
            id='description'
          />
        </div>
        <div className='price-container'>
          <div className='text-input-container'>
            <label htmlFor='outcome'>Odliv</label>
            <input
              type='text'
              defaultValue={outcome}
              {...methods.register('outcome')}
            ></input>
          </div>

          <CustomSingleSelect
            options={remapedCurrencies}
            name={'outcomeCurrency'}
            optionLabel='Valuta'
            selected={false}
            defaultValue={remapedDefaultOutcomeCurrency}
            register={methods.register}
          />
        </div>
        <div className='text-input-container'>
          <label htmlFor='dateOfPayment'>Rok placanja</label>
          <input
            {...methods.register('dateOfPayment')}
            type='text'
            defaultValue={dateOfPayment}
            id='description'
          />
        </div>
        {/* <TextFieldControl label='Beleške' name='note' /> */}
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
      })}
    </div>
  );
};

export default CustomAddRouteContainer;
