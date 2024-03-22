'use client';
import { TableComponent } from '@/components';
import {
  deleteShipment,
  getAllBorderCrossings,
  getAllCarriers,
  getAllCustomers,
  getAllCustoms,
  getAllLoadLocations,
  getAllShipments,
} from '../../services/ShipmentService';
import { Fragment, useEffect, useState } from 'react';
import { Button, Drawer } from '@mui/material';
import DrawerContext from '@/context/DrawerContext';
import ShipmentsDrawer from '@/components/ShipmentsDrawer';
import AddCarrierDialog from '@/components/AddCarrierDialog';
import CarrierDialogContext from '@/context/CarrierDialogContext';
import GetCarrierDto from '@/model/GetCarrierDto';
import DragDropPdfContext from '@/context/DragDropPdfContext';
import DragDropPdfDialog from '@/components/DragDropPdfDialog';
import DeleteShipmentDialogContext from '@/context/DeleteShipmentDialogContext';
import DeleteShipmentDialog from '@/components/DeleteShipmentDialog';
import PreviewShipmentDrawerContext from '@/context/PreviewShipmentDrawerContext';
import PreviewShipmentsDrawer from '@/components/PreviewShipmentsDrawer';
import GetShipmentDto from '@/model/GetShipmentDto';
import GetCustomerDto from '@/model/GetCustomerDto';
import CustomsDto from '@/model/CustomsDto';
import BorderCrossingDto from '@/model/BorderCrossingDto';
import LoadOnLocationDto from '@/model/LoadOnLocationDto';
import EditShipmentDrawerContext from '@/context/EditShipmentDrawerContext';
import EditShipmentDrawer from '@/components/EditShipmentDrawer';

export default function Shipments() {
  const [shipments, setShipments] = useState<GetShipmentDto[] | []>([]);
  const [isOpened, setOpened] = useState(false);
  const [newCarrier, setNewCarrier] = useState<GetCarrierDto>();
  const [customers, setCustomers] = useState<GetCustomerDto[] | []>([]);
  const [listOfCarriers, setListOfCarriers] = useState<GetCarrierDto[] | []>(
    []
  );
  const [customs, setCustoms] = useState<CustomsDto[] | []>([]);
  const [borderCrossings, setBorderCrossings] = useState<
    BorderCrossingDto[] | []
  >([]);
  const [loadLocations, setLoadLocations] = useState<LoadOnLocationDto[] | []>(
    []
  );

  const value = { isOpened: isOpened, setOpened: setOpened };

  const [shipmentForPreview, setShipmentForPreview] =
    useState<GetShipmentDto>();

  const [isOpenedPreviewDrawer, setOpenedPreviewDrawer] = useState(false);
  const [isOpenedEditShipmentDrawer, setOpenedEditShipmentDrawer] =
    useState(false);

  const [isOpenedCarrierDialog, setOpenedCarrierDialog] = useState(false);
  const [isOpenedDragDropPdfDialog, setOpenedDragDropPdfDialog] =
    useState(false);
  const [isOpenedDeleteShipmentDialog, setOpenedDeleteShipmentDialog] =
    useState(false);

  const valueCarrier = {
    isOpenedCarrierDialog: isOpenedCarrierDialog,
    setOpenedCarrierDialog: setOpenedCarrierDialog,
  };

  const valueDragDropPdf = {
    isOpenedDragDropDialog: isOpenedDragDropPdfDialog,
    setOpenedDragDropDialog: setOpenedDragDropPdfDialog,
  };

  const valueDeleteShipment = {
    isOpenedDeleteDialog: isOpenedDeleteShipmentDialog,
    setOpenedDeleteDialog: setOpenedDeleteShipmentDialog,
  };

  const valuePreviewShipment = {
    isOpened: isOpenedPreviewDrawer,
    setOpened: setOpenedPreviewDrawer,
  };

  const valueEditShipment = {
    isOpened: isOpenedEditShipmentDrawer,
    setOpened: setOpenedEditShipmentDrawer,
  };

  const [shipmentId, setShipmentId] = useState(1);

  useEffect(() => {
    getAllShipments().then((response) => {
      setShipments(response?.data);
    });
    getAllCustomers().then((response) => {
      setCustomers(response?.data);
    });
    getAllCarriers().then((response) => {
      setListOfCarriers(response?.data);
    });
    getAllLoadLocations().then((response) => {
      setLoadLocations(response?.data);
    });
    getAllCustoms().then((response) => {
      setCustoms(response?.data);
    });
    getAllBorderCrossings().then((response) => {
      setBorderCrossings(response?.data);
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

  const openDeleteShipmentDialog = (id: number) => {
    setShipmentId(id);
    setOpenedDeleteShipmentDialog(true);
  };

  const closeDeleteShipmentDialog = () => {
    setOpenedDeleteShipmentDialog(false);
  };

  const confirmDeleteShipment = async (id: number) => {
    try {
      // Call the deleteShipment function to delete the shipment
      await deleteShipment(id);

      // Update the shipments state by filtering out the shipment with the specified ID
      setShipments((shipments) =>
        shipments.filter((shipment) => shipment.id !== id)
      );
      closeDeleteShipmentDialog();
    } catch (error) {
      console.error('Error deleting shipment:', error);
    }
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

  const statusUpdated = (shipmentId: number, statusId: number) => {
    const shipmentIndex = shipments.findIndex(
      (shipment) => shipment.id === shipmentId
    );
    if (shipmentIndex !== -1) {
      const updatedShipments = [...shipments];
      updatedShipments[shipmentIndex].status = statusId;
      setShipments(updatedShipments);
    }
  };

  const togglePreviewShipmentsDrawer = (id: number) => {
    setOpenedPreviewDrawer(!isOpenedPreviewDrawer);
    setShipmentForPreview(shipments.find((shipment) => shipment.id === id));
  };

  const toggleEditShipmentDrawer = (id: number) => {
    setOpenedEditShipmentDrawer(!isOpenedEditShipmentDrawer);
    setShipmentForPreview(shipments.find((shipment) => shipment.id === id));
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
              openDeleteShipmentDialog={openDeleteShipmentDialog}
              closeDeleteShipmentDialog={closeDeleteShipmentDialog}
              notifyParentOfStatusUpdate={statusUpdated}
              togglePreviewShipmentsDrawer={togglePreviewShipmentsDrawer}
              toggleEditShipmentDrawer={toggleEditShipmentDrawer}
            ></TableComponent>
          </div>
          <ShipmentsDrawer
            openAddCarrierDialog={openAddCarrierDialog}
            newCarrier={newCarrier}
            closeAddCarrierDialog={closeAddCarrierDialog}
            startCustomers={customers}
            startBorderCrossings={borderCrossings}
            startCustoms={customs}
            startCarriers={listOfCarriers}
            startLoadLocations={loadLocations}
          />
        </Fragment>
      </DrawerContext.Provider>
      <PreviewShipmentDrawerContext.Provider value={valuePreviewShipment}>
        <PreviewShipmentsDrawer
          shipment={shipmentForPreview}
          customers={customers}
          carriers={listOfCarriers}
          borderCrossings={borderCrossings}
          customs={customs}
          loadLocations={loadLocations}
        />
      </PreviewShipmentDrawerContext.Provider>
      <EditShipmentDrawerContext.Provider value={valueEditShipment}>
        <EditShipmentDrawer
          shipment={shipmentForPreview}
          customers={customers}
          carriers={listOfCarriers}
          borderCrossings={borderCrossings}
          customs={customs}
          loadLocations={loadLocations}
          openAddCarrierDialog={openAddCarrierDialog}
        />
      </EditShipmentDrawerContext.Provider>
      <CarrierDialogContext.Provider value={valueCarrier}>
        <AddCarrierDialog addNewCarrier={addNewCarrier} />
      </CarrierDialogContext.Provider>
      <DragDropPdfContext.Provider value={valueDragDropPdf}>
        <DragDropPdfDialog shipmentId={shipmentId} />
      </DragDropPdfContext.Provider>
      <DeleteShipmentDialogContext.Provider value={valueDeleteShipment}>
        <DeleteShipmentDialog
          shipmentId={shipmentId}
          confirmDeleteShipment={confirmDeleteShipment}
        />
      </DeleteShipmentDialogContext.Provider>
    </div>
  );
}
