import { FormProvider } from 'react-hook-form';
import TextFieldControl from './controls/inputs/TextFieldControl';
import SelectControl from './controls/inputs/SelectControl';
import AddShipmentDto from '@/model/AddShipmentDto';
import GetShipmentDto from '@/model/GetShipmentDto';
import { useEffect } from 'react';
import Status from '@/constants/Status';
import GetCustomerDto from '@/model/GetCustomerDto';
import Currency from '@/constants/Currency';
import VehicleType from '@/constants/VehicleType';
import DateTimeControl from './controls/inputs/DateTimeControl';
import dayjs from 'dayjs';

const PreviewShipmentsDrawerContainer = ({
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
}: {
  form: any;
  setValue: any;
  shipment: GetShipmentDto | undefined;
  customers: GetCustomerDto[] | [];
  listOfCarriers: any;
  borderCrossings: any;
  customs: any;
  values: any;
  loadLocations: any;
  control: any;
}) => {
  useEffect(() => {
    setValue('externalId', shipment?.externalId);
    setValue('description', shipment?.description);
    setValue('income', shipment?.income);
    setValue('incomeCurrency', shipment?.incomeCurrency);
    setValue('profit', shipment?.profit);
    setRouteValues(shipment);
  }, [shipment]);

  const setRouteValues = (shipment: GetShipmentDto | undefined) => {
    shipment?.shipmentRoutes.forEach((route, index) => {
      setValue('dateOfPayment' + index, route.dateOfPayment);
      route.shipmentLoadOnLocations.forEach((loadOnLocation) => {
        if (loadOnLocation.type === 0) {
          setValue('loadOnLocationMerch-' + index + '-', loadOnLocation.merch);
          setValue(
            'loadOnLocationMerchAmount-' + index + '-',
            loadOnLocation.merchAmount
          );
        }
      });
    });
  };
  return (
    <FormProvider {...form}>
      <form id='shipments-form' className='shipments-form'>
        <TextFieldControl label='ID' name='externalId' disabled={true} />
        <SelectControl
          name='customer'
          label='Klijent'
          nameKey={'name'}
          valueKey={'id'}
          disabled={true}
          value={shipment?.customer.id}
          options={customers}
        />
        <TextFieldControl
          label='Referenca'
          name='description'
          value={shipment?.description}
          disabled={true}
        />
        <SelectControl
          name='status'
          label={'Status'}
          nameKey={'name'}
          valueKey={'id'}
          value={shipment?.status}
          options={Status}
          disabled={true}
        />
        <div className='price-container'>
          <TextFieldControl
            className='price'
            label='Priliv'
            type='number'
            value={shipment?.income}
            name='income'
            disabled={true}
          />
          <SelectControl
            name={'incomeCurrency'}
            value={shipment?.incomeCurrency}
            label={'Valuta'}
            nameKey={'name'}
            valueKey={'id'}
            options={Currency}
            disabled={true}
          />
        </div>
        {shipment?.shipmentRoutes.map((route, index) => {
          return (
            <div key={route.id}>
              <hr />
              <span>{'Ruta' + index + 1} </span>
              <SelectControl
                name='carrier'
                value={route.carrier}
                setValue={setValue}
                label={'Prevoznik'}
                options={listOfCarriers}
                nameKey={'name'}
                valueKey={'id'}
                disabled={true}
              />
              <span className='load-on-limitter'>Utovar</span>
              {route.shipmentLoadOnLocations
                .filter((loadOnLocation) => loadOnLocation.type === 0)
                ?.map(
                  (shipmentLoadOnLocation, indexOfShipmentLoadOnLocation) => {
                    return (
                      <div key={shipmentLoadOnLocation.id}>
                        <SelectControl
                          name={'loadOnLocation-' + route + '-'}
                          setValue={setValue}
                          label={
                            'Mesto utovara' + indexOfShipmentLoadOnLocation + 1
                          }
                          nameKey={'name'}
                          valueKey={'id'}
                          value={shipmentLoadOnLocation.loadOnLocation}
                          options={loadLocations}
                          className='load-on-location-input'
                          disabled={true}
                        />
                        <DateTimeControl
                          dateTime={true}
                          label={'Datum i vreme utovara'}
                          name={'loadOnLocationDate-' + route + '-'}
                          fullWidth
                          margin='normal'
                          value={dayjs(shipmentLoadOnLocation.date)}
                          setValue={setValue}
                          variant='filled'
                          disabled={true}
                          data={control}
                        />
                        <TextFieldControl
                          label='Vrsta robe'
                          name={'loadOnLocationMerch-' + index + '-'}
                          disabled={true}
                        />
                        <TextFieldControl
                          label='Količina robe'
                          name={'loadOnLocationMerchAmount-' + index + '-'}
                          disabled={true}
                        />
                      </div>
                    );
                  }
                )}
              <SelectControl
                name='exportDuty'
                value={
                  route.shipmentCustoms.find((custom) => custom.type === 1)
                    ?.custom
                }
                setValue={setValue}
                label={'Izvozna carina'}
                options={customs}
                nameKey={'name'}
                valueKey={'id'}
                disabled={true}
              />
              <SelectControl
                name='borderCrossings'
                value={route.borderCrossing}
                setValue={setValue}
                label={'Granični prelaz'}
                options={borderCrossings}
                nameKey={'name'}
                valueKey={'id'}
                disabled={true}
              />
              <SelectControl
                name='importDuty'
                value={
                  route.shipmentCustoms.find((custom) => custom.type === 0)
                    ?.custom
                }
                setValue={setValue}
                label={'Uvozna carina'}
                options={customs}
                nameKey={'name'}
                valueKey={'id'}
                disabled={true}
              />
              <span className='load-on-limitter'>Istovar</span>
              {route.shipmentLoadOnLocations
                .filter((loadOnLocation) => loadOnLocation.type === 1)
                ?.map(
                  (shipmentLoadOffLocation, indexOfShipmentLoadOffLocation) => {
                    return (
                      <div key={shipmentLoadOffLocation.id}>
                        <SelectControl
                          name={'loadOnLocation-' + route + '-'}
                          setValue={setValue}
                          label={
                            'Mesto istovara' +
                            indexOfShipmentLoadOffLocation +
                            1
                          }
                          nameKey={'name'}
                          valueKey={'id'}
                          value={shipmentLoadOffLocation.loadOnLocation}
                          options={loadLocations}
                          className='load-on-location-input'
                          disabled={true}
                        />
                        <DateTimeControl
                          dateTime={true}
                          label={'Datum i vreme istovara'}
                          name={'loadOffLocationDate-' + route + '-'}
                          fullWidth
                          margin='normal'
                          value={dayjs(shipmentLoadOffLocation.date)}
                          setValue={setValue}
                          variant='filled'
                          disabled={true}
                          data={control}
                        />
                      </div>
                    );
                  }
                )}
              <SelectControl
                name='vehicleType'
                value={route.vehicleType}
                setValue={setValue}
                label={'Tip vozila'}
                options={VehicleType}
                nameKey={'name'}
                valueKey={'id'}
                disabled={true}
              />
              <TextFieldControl
                label='Registarske tablice'
                name='licencePlate'
                defaultValue={route.licencePlate}
                disabled={true}
              />
              <div className='price-container'>
                <TextFieldControl
                  className='price'
                  label='Odliv'
                  type='number'
                  InputProps={{
                    inputProps: { min: 0 },
                  }}
                  name='outcome'
                  defaultValue={route.outcome}
                  disabled={true}
                />
                <SelectControl
                  name='outcomeCurrency'
                  value={route.outcomeCurrency}
                  setValue={setValue}
                  label={'Valuta'}
                  options={Currency}
                  nameKey={'name'}
                  valueKey={'id'}
                  disabled={true}
                />
              </div>
              <TextFieldControl
                label='Rok plaćanja'
                type='number'
                InputProps={{
                  inputProps: { min: 0 },
                }}
                name={'dateOfPayment' + index}
                disabled={true}
              />
              <TextFieldControl label='Beleške' name='note' />
            </div>
          );
        })}
        <hr />

        <TextFieldControl
          label='Profit'
          type='number'
          name='profit'
          disabled={true}
          value={shipment?.profit}
        />
      </form>
    </FormProvider>
  );
};

export default PreviewShipmentsDrawerContainer;
