import GetCustomerDto from '@/model/GetCustomerDto';
import GetShipmentDto from '@/model/GetShipmentDto';
import { FormProvider, useForm, useFormContext } from 'react-hook-form';
import Status from '@/constants/Status';
import { useState } from 'react';
import { Button } from '@mui/material';
import Currency from '@/constants/Currency';
import GetRouteDto from '@/model/GetRouteDto';
import CustomSingleSelect from './customSingleSelect/CustomSingleSelect';
import AddRouteContainer from './AddRouteContainer';
import GetCarrierDto from '@/model/GetCarrierDto';
import CustomAddRouteContainer from './CustomAddRouteContainer';
import GetShipmentCustomsDto from '@/model/GetShipmentCustomsDto';
import CustomsDto from '@/model/CustomsDto';
import GetBorderCrossingDto from '@/model/GetBorderCrossingDto';
import VehicleType from '@/constants/VehicleType';

type FormFields = {
  externalId: string;
  customer: string;
  description: string;
  status: string;
  income: string;
  currency: string;
  profit: string;
};
const EditShipmentDrawerContainer = ({
  form,
  setValue,
  shipment,
  customers,
  values,
  listOfCarriers,
  borderCrossings,
  customs,
  loadLocations,
  control,
  onSubmit,
  trigger,
  register,
  openAddCarrierDialog,
  carriers,
}: {
  form: any;
  setValue: any;
  shipment: GetShipmentDto | undefined;
  customers: GetCustomerDto[] | [];
  listOfCarriers: any;
  borderCrossings: GetBorderCrossingDto[] | [];
  customs: CustomsDto[] | [];
  values: any;
  loadLocations: any;
  control: any;
  onSubmit: any;
  trigger: any;
  register: any;
  openAddCarrierDialog: any;
  carriers: GetCarrierDto[] | [];
}) => {
  const [existingRoutes, setExistingRoutes] = useState<GetRouteDto[] | []>();
  // useEffect(() => {
  // setValue('externalId', shipment?.externalId);
  // setValue('description', shipment?.description);
  // setValue('income', shipment?.income);
  // setValue('incomeCurrency', shipment?.incomeCurrency);
  // setValue('profit', shipment?.profit);
  // setExistingRoutes(shipment?.shipmentRoutes);
  // // setValue('customer', shipment?.customer);
  // setValue('status', shipment?.status);
  // setValue('incomeCurrency', shipment?.incomeCurrency);
  // setRouteValues(shipment);
  // }, [shipment]);
  const methods = useForm<FormFields>();
  const sub = (data: FormFields) => {
    const selectedCustomer = customers.find(
      (customer) => customer.id === parseInt(data.customer)
    );
    console.log('A?', { ...data, customer: selectedCustomer });

    onSubmit({
      ...data,
      customer: selectedCustomer,
    });
  };
  const addCarrier = () => {
    openAddCarrierDialog();
  };
  const remapedCustomers = customers.map((customer) => {
    return {
      value: customer.id,
      label: customer.name,
    };
  });
  const remapedStatuses = Status.map((stat) => {
    return {
      value: stat.id,
      label: stat.name,
    };
  });
  const remapedCurrencies = Currency.map((curr) => {
    return {
      value: curr.id,
      label: curr.name,
    };
  });

  const remapedCarrier = carriers.map((carr) => {
    return {
      value: carr.id,
      label: carr.name,
    };
  });

  const remapedExportDuty = customs.map((cust) => {
    return {
      value: cust.id,
      label: cust.name,
    };
  });

  const remapedBorderCrossing = borderCrossings.map((borderCross) => {
    return {
      value: borderCross.id,
      label: borderCross.name,
    };
  });

  const remapedVehicleType = VehicleType.map((vehType) => {
    return {
      value: vehType.id,
      label: vehType.name,
    };
  });

  const remapedDefaultCustomer = {
    value: shipment?.customer.id,
  };

  const remapedDefaultStatus = {
    value: shipment?.status,
  };

  const remapedDefaultIncomeCurrency = {
    value: shipment?.incomeCurrency,
  };
  const remapedDefaultCarrier = {
    value: shipment?.shipmentRoutes[0].carrier.id,
  };
  const remapedDefaultExportDuty = {
    value: shipment?.shipmentRoutes[0].shipmentCustoms.find(
      (shipmentCustom) => shipmentCustom.type === 1
    )?.id,
  };
  const remapedDefaultImportDuty = {
    value: shipment?.shipmentRoutes[0].shipmentCustoms.find(
      (shipmentCustom) => shipmentCustom.type === 0
    )?.id,
  };
  const remapedDefaultBorderCrossing = {
    value: shipment?.shipmentRoutes[0].borderCrossing?.id,
  };
  const remapedDefaultVehicleType = {
    value: shipment?.shipmentRoutes[0].vehicleType,
  };
  const remapedDefaultOutcomeCurrency = {
    value: shipment?.shipmentRoutes[0].outcomeCurrency,
  };
  return (
    <FormProvider {...methods}>
      <form onSubmit={methods.handleSubmit(sub)} className='edit-shipment-form'>
        <div className='text-input-container'>
          <label htmlFor='externalId'>Referenca</label>
          <input
            {...methods.register('externalId')}
            type='text'
            defaultValue={shipment?.externalId}
            id='externalId'
          />
        </div>
        <CustomSingleSelect
          options={remapedCustomers}
          name={'customer'}
          optionLabel='Klijent'
          selected={false}
          defaultValue={remapedDefaultCustomer}
          register={methods.register}
        />
        <div className='text-input-container'>
          <label htmlFor='description'>Referenca</label>
          <input
            {...methods.register('description')}
            type='text'
            defaultValue={shipment?.description}
            id='description'
          />
        </div>
        <CustomSingleSelect
          options={remapedStatuses}
          name={'status'}
          optionLabel='Status'
          selected={false}
          defaultValue={remapedDefaultStatus}
          register={methods.register}
        />

        <div className='price-container'>
          <div className='text-input-container'>
            <label htmlFor='income'>Priliv</label>
            <input
              type='text'
              defaultValue={shipment?.income}
              {...methods.register('income')}
            ></input>
          </div>

          <CustomSingleSelect
            options={remapedCurrencies}
            name={'incomeCurrency'}
            optionLabel='Valuta'
            selected={false}
            defaultValue={remapedDefaultIncomeCurrency}
            register={methods.register}
          />
        </div>

        <CustomAddRouteContainer
          values={values}
          setValue={setValue}
          control={control}
          form={form}
          listOfCarriers={listOfCarriers}
          loadLocations={loadLocations}
          customs={customs}
          borderCrossings={borderCrossings}
          addCarrier={addCarrier}
          formRules={undefined}
          errors={undefined}
          remapedCarrier={remapedCarrier}
          remapedDefaultCarrier={remapedDefaultCarrier}
          methods={methods}
          remapedExportDuty={remapedExportDuty}
          remapedDefaultExportDuty={remapedDefaultExportDuty}
          remapedBorderCrossing={remapedBorderCrossing}
          remapedDefaultBorderCrossing={remapedDefaultBorderCrossing}
          remapedDefaultImportDuty={remapedDefaultImportDuty}
          remapedVehicleType={remapedVehicleType}
          remapedDefaultVehicleType={remapedDefaultVehicleType}
          licencePlate={shipment?.shipmentRoutes[0].licencePlate}
          remapedCurrencies={remapedCurrencies}
          outcome={shipment?.shipmentRoutes[0].outcome}
          remapedDefaultOutcomeCurrency={remapedDefaultOutcomeCurrency}
          dateOfPayment={shipment?.shipmentRoutes[0].dateOfPayment}
        />

        <div className='text-input-container'>
          <label htmlFor='profit'>Profit</label>
          <input
            type='text'
            defaultValue={shipment?.profit}
            {...methods.register('profit')}
          ></input>
        </div>

        <Button type='submit' className='submit-btn'>
          Potvrdi
        </Button>
      </form>
    </FormProvider>
    // <FormProvider {...form}>
    //   <form id='shipments-form' className='shipments-form' onSubmit={onSubmit}>
    //     <TextFieldControl label='ID' name='externalId' />
    //     <SelectControl
    //       name='customer'
    //       label='Klijent'
    //       nameKey={'name'}
    //       control={control}
    //       valueKey={'id'}
    //       value={shipment?.customer}
    //       setValue={setValue}
    //       options={customers}
    //     />
    //     <TextFieldControl
    //       label='Referenca'
    //       name='description'
    //       defaultValue={shipment?.description}
    //     />
    //     <SelectControl
    //       name='status'
    //       label={'Status'}
    //       nameKey={'name'}
    //       valueKey={'id'}
    //       // value={values['status']}
    //       value={shipment?.status}
    //       options={Status}
    //       setValue={setValue}
    //       control={control}
    //     />
    //     <div className='price-container'>
    //       <TextFieldControl
    //         className='price'
    //         label='Priliv'
    //         type='number'
    //         value={shipment?.income}
    //         name='income'
    //       />
    //       <SelectControl
    //         name={'incomeCurrency'}
    //         // value={values['incomeCurrency']}
    //         value={shipment?.incomeCurrency}
    //         label={'Valuta'}
    //         nameKey={'name'}
    //         valueKey={'id'}
    //         options={Currency}
    //         setValue={setValue}
    //         control={control}
    //       />
    //     </div>
    //     <EditShipmentRouteContainer
    //       existingRoutes={existingRoutes}
    //       values={values}
    //       setValue={setValue}
    //       control={control}
    //       form={form}
    //       listOfCarriers={listOfCarriers}
    //       loadLocations={loadLocations}
    //       customs={customs}
    //       borderCrossings={borderCrossings}
    //       addCarrier={addCarrier}
    //     />
    //     <TextFieldControl
    //       label='Profit'
    //       type='number'
    //       InputProps={{
    //         inputProps: { min: 0 },
    //       }}
    //       name='profit'
    //     />
    //     <Button type='submit' className='submit-btn'>
    //       Potvrdi izmenu
    //     </Button>
    //   </form>
    // </FormProvider>
  );
};

export default EditShipmentDrawerContainer;
