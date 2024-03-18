import GetCustomerDto from '@/model/GetCustomerDto';
import GetShipmentDto from '@/model/GetShipmentDto';
import { Drawer } from '@mui/material';
import { FormEvent, Fragment, useContext } from 'react';
import EditShipmentDrawerContainer from './EditShipmentDrawerContainer';
import { useForm, useFormContext } from 'react-hook-form';
import EditShipmentDrawerContext from '@/context/EditShipmentDrawerContext';

const EditShipmentDrawer = ({
  shipment,
  customers,
  carriers,
  borderCrossings,
  customs,
  loadLocations,
}: {
  shipment: GetShipmentDto | undefined;
  customers: GetCustomerDto[] | [];
  carriers: any;
  borderCrossings: any;
  customs: any;
  loadLocations: any;
}) => {
  const form = useForm();
  const { setValue, getValues, control, handleSubmit, trigger, register } =
    form;
  const { isOpened, setOpened } = useContext(EditShipmentDrawerContext);
  const toggleDrawer =
    () => (event: React.KeyboardEvent | React.MouseEvent) => {
      if (
        event.type === 'keydown' &&
        ((event as React.KeyboardEvent).key === 'Tab' ||
          (event as React.KeyboardEvent).key === 'Shift')
      ) {
        return;
      }

      setOpened(!isOpened);
    };

  const onSubmitEditShipmentForm = (data: any) => {
    console.log('Mijao', data);
  };

  const drawer = (
    <div>
      <Fragment key='right'>
        <Drawer anchor='right' open={isOpened} onClose={toggleDrawer()}>
          <div id='shipments-drawer-container'>
            <span>Izmeni turu</span>
            <EditShipmentDrawerContainer
              form={form}
              setValue={setValue}
              shipment={shipment}
              customers={customers}
              onSubmit={handleSubmit(onSubmitEditShipmentForm)}
              values={getValues()}
              listOfCarriers={carriers}
              borderCrossings={borderCrossings}
              customs={customs}
              loadLocations={loadLocations}
              control={control}
              trigger={trigger}
              register={register}
            />
          </div>
        </Drawer>
      </Fragment>
    </div>
  );

  return drawer;
};

export default EditShipmentDrawer;
