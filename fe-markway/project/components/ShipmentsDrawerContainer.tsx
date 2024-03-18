import { Button, FormControl, Select, TextField } from '@mui/material';
import { FormProvider, useFormContext } from 'react-hook-form';
import SelectControl from '../components/controls/inputs/SelectControl';
import GetCarrierDto from '@/model/GetCarrierDto';
import { useContext, useEffect } from 'react';
import CarrierDialogContext from '@/context/CarrierDialogContext';
import Currency from '@/constants/Currency';
import VehicleType from '@/constants/VehicleType';
import Status from '@/constants/Status';
import LoadLocationContainer from './LoadLocationContainer';
import TextFieldControl from './controls/inputs/TextFieldControl';
import AddRouteContainer from './AddRouteContainer';

const ShipmentsDrawerContainer = ({
  values,
  setValue,
  control,
  formRules,
  errors,
  form,
  onSubmit,
  listOfStatus,
  listOfCarriers,
  openAddCarrierDialog,
  newCarrier,
  trigger,
  loadLocations,
  customs,
  borderCrossings,
  customers,
}) => {
  useEffect(() => {
    setValue('carrier', newCarrier);
    trigger('carrier');
  }, [newCarrier]);

  const addCarrier = () => {
    openAddCarrierDialog();
  };

  const addMoreRoutes = () => {};

  const { setOpenedCarrierDialog } = useContext(CarrierDialogContext);

  return (
    <FormProvider {...form}>
      <form id='shipments-form' className='shipments-form' onSubmit={onSubmit}>
        <TextFieldControl label='ID' name='externalId' />
        <SelectControl
          name='customer'
          value={values['customer']}
          setValue={setValue}
          control={control}
          label='Klijent'
          options={customers}
          nameKey={'name'}
          valueKey={'id'}
        />
        <TextFieldControl label='Referenca' name='description' />
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
        <div className='price-container'>
          <TextFieldControl
            className='price'
            label='Priliv'
            type='number'
            InputProps={{
              inputProps: { min: 0 },
            }}
            name='income'
          />
          <SelectControl
            name={'incomeCurrency'}
            value={values['currency']}
            setValue={setValue}
            control={control}
            label={'Valuta'}
            options={Currency}
            nameKey={'name'}
            valueKey={'id'}
          />
        </div>
        <AddRouteContainer
          values={values}
          setValue={setValue}
          control={control}
          formRules={formRules}
          errors={errors}
          form={form}
          listOfCarriers={listOfCarriers}
          loadLocations={loadLocations}
          customs={customs}
          borderCrossings={borderCrossings}
          addCarrier={addCarrier}
        />

        <TextFieldControl
          label='Profit'
          type='number'
          InputProps={{
            inputProps: { min: 0 },
          }}
          name='profit'
        />
        <Button type='submit' className='submit-btn'>
          Potvrdi
        </Button>
      </form>
    </FormProvider>
  );
};

export default ShipmentsDrawerContainer;
