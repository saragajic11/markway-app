import PreviewShipmentDrawerContext from '@/context/PreviewShipmentDrawerContext';
import { Drawer } from '@mui/material';
import { Fragment, useContext, useEffect } from 'react';
import PreviewShipmentsDrawerContainer from './PreviewShipmentsDrawerContainer';
import { useForm } from 'react-hook-form';
import AddShipmentDto from '@/model/AddShipmentDto';
import GetShipmentDto from '@/model/GetShipmentDto';
import GetCustomerDto from '@/model/GetCustomerDto';

const PreviewShipmentsDrawer = ({
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
  const { setValue, getValues, control } = form;
  const { isOpened, setOpened } = useContext(PreviewShipmentDrawerContext);
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

  const drawer = (
    <div>
      <Fragment key='right'>
        <Drawer anchor='right' open={isOpened} onClose={toggleDrawer()}>
          <div id='shipments-drawer-container'>
            <span>Pregledaj turu</span>
            <PreviewShipmentsDrawerContainer
              form={form}
              setValue={setValue}
              shipment={shipment}
              customers={customers}
              values={getValues()}
              listOfCarriers={carriers}
              borderCrossings={borderCrossings}
              customs={customs}
              loadLocations={loadLocations}
              control={control}
            />
          </div>
        </Drawer>
      </Fragment>
    </div>
  );

  return drawer;
};

export default PreviewShipmentsDrawer;
