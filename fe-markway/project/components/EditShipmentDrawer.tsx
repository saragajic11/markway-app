import GetCustomerDto from '@/model/GetCustomerDto';
import GetShipmentDto from '@/model/GetShipmentDto';
import { Drawer } from '@mui/material';
import { Fragment, useContext } from 'react';
import EditShipmentDrawerContainer from './EditShipmentDrawerContainer';
import { useForm } from 'react-hook-form';
import EditShipmentDrawerContext from '@/context/EditShipmentDrawerContext';
import { editShipment } from '@/services/ShipmentService';
import ToastContext from '@/context/ToastContext';
import CustomsDto from '@/model/CustomsDto';
import GetBorderCrossingDto from '@/model/GetBorderCrossingDto';

const EditShipmentDrawer = ({
  shipment,
  customers,
  carriers,
  borderCrossings,
  customs,
  loadLocations,
  openAddCarrierDialog,
}: {
  shipment: GetShipmentDto | undefined;
  customers: GetCustomerDto[] | [];
  carriers: any;
  borderCrossings: GetBorderCrossingDto[] | [];
  customs: CustomsDto[] | [];
  loadLocations: any;
  openAddCarrierDialog: any;
}) => {
  const form = useForm();
  const { setToastOpened } = useContext(ToastContext);
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
    console.log('?ne razumem', data);
    editShipment(shipment?.id, data).then((response) => {
      if (response?.status === 200) {
        //TODO: implementirati refresh stranice u slucaju uspesnog dodavanja klijenta
        setToastOpened(true, true, 'Uspešno izmenjen prevoznik');
      } else {
        setToastOpened(true, false, 'Greška prilikom izmene prevoznika');
      }
      setOpened(false);
    });
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
              onSubmit={onSubmitEditShipmentForm}
              values={getValues()}
              listOfCarriers={carriers}
              borderCrossings={borderCrossings}
              customs={customs}
              loadLocations={loadLocations}
              control={control}
              trigger={trigger}
              register={register}
              openAddCarrierDialog={openAddCarrierDialog}
              carriers={carriers}
            />
          </div>
        </Drawer>
      </Fragment>
    </div>
  );

  return drawer;
};

export default EditShipmentDrawer;
