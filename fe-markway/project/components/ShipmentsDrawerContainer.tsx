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
        <TextFieldControl label='Opis' name='description' />
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
        {/* <TextField label="Status" /> */}
        {/* <SelectControl value={values['listOfStatus']} setValue={setValue} name='status' control={control} label={'Status'} options={listOfStatus} nameKey='status' valueKey={'id'} /> */}
        <TextFieldControl label='Roba' name='merch' />
        <TextFieldControl
          label='Količina robe'
          type='number'
          InputProps={{
            inputProps: { min: 0 },
          }}
          name='merchAmount'
        />
        <TextFieldControl
          label='Priliv'
          type='number'
          InputProps={{
            inputProps: { min: 0 },
          }}
          name='income'
        />
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
        <TextFieldControl label='Beleške' name='note' />
        <Button type='submit' className='submit-btn'>
          Potvrdi
        </Button>
      </form>
    </FormProvider>
  );
};

export default ShipmentsDrawerContainer;
