'use client';
import { TableComponent } from '@/components';
import { getAllShipments } from '../../services/ShipmentService';
import { Fragment, useEffect, useState } from 'react';
import ShipmentDto from '../../model/ShipmentDto';
import { Button, Drawer } from '@mui/material';
import DrawerContext from '@/context/DrawerContext';
import ShipmentsDrawer from '@/components/ShipmentsDrawer';
import AddCarrierDialog from '@/components/AddCarrierDialog';
import CarrierDialogContext from '@/context/CarrierDialogContext';
import GetCarrierDto from '@/model/GetCarrierDto';
import DragDropPdfContext from '@/context/DragDropPdfContext';
import DragDropPdfDialog from '@/components/DragDropPdfDialog';

export default function Shipments() {
  const [shipments, setShipments] = useState<ShipmentDto[] | []>([]);
  const [isOpened, setOpened] = useState(false);
  const [newCarrier, setNewCarrier] = useState<GetCarrierDto>();
  const value = { isOpened: isOpened, setOpened: setOpened };

  const [isOpenedCarrierDialog, setOpenedCarrierDialog] = useState(false);
  const [isOpenedDragDropPdfDialog, setOpenedDragDropPdfDialog] =
    useState(false);

  const valueCarrier = {
    isOpenedCarrierDialog: isOpenedCarrierDialog,
    setOpenedCarrierDialog: setOpenedCarrierDialog,
  };

  const valueDragDropPdf = {
    isOpenedDragDropDialog: isOpenedDragDropPdfDialog,
    setOpenedDragDropDialog: setOpenedDragDropPdfDialog,
  };

  const [shipmentId, setShipmentId] = useState(1);

  useEffect(() => {
    getAllShipments().then((response) => {
      setShipments(response?.data);
    });
  }, []);

  const toggleDrawer = () => {
    setOpened(!isOpened);
  };

  const openAddCarrierDialog = () => {
    setOpenedCarrierDialog(true);
  };

  const closeAddCarrierDialog = () => {
    setOpenedCarrierDialog(false);
  };

  const addNewCarrier = (response: any) => {
    const carrierDto = new GetCarrierDto(
      response.data.id,
      response.data.name,
      response.data.email
    );
    setNewCarrier(carrierDto);
  };

  const openDragDropDialog = (id: number) => {
    setShipmentId(id);
    setOpenedDragDropPdfDialog(true);
  };

  const closeDragDropDialog = (id: number) => {
    setOpenedDragDropPdfDialog(false);
  };

  return (
    <div>
      <DrawerContext.Provider value={value}>
        <Fragment>
          <div id='shipments-container'>
            <div className='heading-container'>
              <span>Pregled tura</span>
              <Button onClick={toggleDrawer}>Dodaj novu turu</Button>
            </div>
            <TableComponent
              shipments={shipments}
              openDragDropDialog={openDragDropDialog}
              closeDragDropDialog={closeDragDropDialog}
            ></TableComponent>
          </div>
          <ShipmentsDrawer
            openAddCarrierDialog={openAddCarrierDialog}
            newCarrier={newCarrier}
            closeAddCarrierDialog={closeAddCarrierDialog}
          />
        </Fragment>
      </DrawerContext.Provider>
      <CarrierDialogContext.Provider value={valueCarrier}>
        <AddCarrierDialog addNewCarrier={addNewCarrier} />
      </CarrierDialogContext.Provider>
      <DragDropPdfContext.Provider value={valueDragDropPdf}>
        <DragDropPdfDialog shipmentId={shipmentId} />
      </DragDropPdfContext.Provider>
    </div>
  );
}
