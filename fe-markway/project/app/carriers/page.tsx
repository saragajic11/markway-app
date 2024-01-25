'use client';

import AddCarrierDrawer from '@/components/AddCarrierDrawer';
import CarriersTableComponent from '@/components/CarriersTableComponent';
import DeleteCarrierDialog from '@/components/DeleteCarrierDialog';
import AddCarrierDrawerContext from '@/context/AddCarrierDrawerContext';
import DeleteCarrierDialogContext from '@/context/DeleteCarrierDialogContext';
import { deleteCarrier, getAllCarriers } from '@/services/ShipmentService';
import { Button } from '@mui/material';
import { Fragment, useEffect, useState } from 'react';

export default function Carriers() {
  const [carriers, setCarriers] = useState([]);
  const [isOpened, setOpened] = useState(false);
  const [isOpenedDeleteCarrierDialog, setOpenedDeleteCarrierDialog] =
    useState(false);
  const value = { isOpened: isOpened, setOpened: setOpened };
  const valueDeleteCarrier = {
    isOpenedDeleteDialog: isOpenedDeleteCarrierDialog,
    setOpenedDeleteDialog: setOpenedDeleteCarrierDialog,
  };

  const [carrierId, setCarrierId] = useState(1);

  const [isEditMode, setIsEditMode] = useState(false);

  const [carrierToEdit, setCarrierToEdit] = useState(null);

  useEffect(() => {
    getAllCarriers().then((response) => {
      setCarriers(response?.data);
    });
  }, []);

  const openDeleteCarrierDialog = (id: number) => {
    setCarrierId(id);
    setOpenedDeleteCarrierDialog(true);
  };

  const closeDeleteCarrierDialog = () => {
    setOpenedDeleteCarrierDialog(false);
  };

  const setEditMode = (isEditMode: boolean, carrierId: number) => {
    const carrierForEdit = carriers.find((carrier) => carrier.id === carrierId);
    setCarrierToEdit(carrierForEdit);
    setCarrierId(carrierId);
    setIsEditMode(isEditMode);
    setOpened(true);
  };

  const toggleDrawer = () => {
    setOpened(!isOpened);
    setIsEditMode(false);
    setCarrierToEdit(null);
  };

  const confirmDeleteCarrier = async (id: number) => {
    try {
      // Call the deleteShipment function to delete the shipment
      await deleteCarrier(id);

      // Update the shipments state by filtering out the shipment with the specified ID
      setCarriers((carriers) =>
        carriers.filter((carrier) => carrier.id !== id)
      );
      closeDeleteCarrierDialog();
    } catch (error) {
      console.error('Error deleting carrier:', error);
    }
  };

  return (
    <div>
      <AddCarrierDrawerContext.Provider value={value}>
        <Fragment>
          <div id='carriers-page'>
            <div className='heading-container'>
              <span>Pregled prevoznika</span>
              <Button onClick={toggleDrawer}>Dodaj novog prevoznika</Button>
            </div>
            <CarriersTableComponent
              carriers={carriers}
              openDeleteCarrierDialog={openDeleteCarrierDialog}
              closeDeleteCarrierDialog={closeDeleteCarrierDialog}
              setEditMode={setEditMode}
            />
          </div>
          <AddCarrierDrawer
            carrierId={carrierId}
            isEditMode={isEditMode}
            carrierToEdit={carrierToEdit}
          />
        </Fragment>
      </AddCarrierDrawerContext.Provider>
      <DeleteCarrierDialogContext.Provider value={valueDeleteCarrier}>
        <DeleteCarrierDialog
          carrierId={carrierId}
          confirmDeleteCarrier={confirmDeleteCarrier}
        />
      </DeleteCarrierDialogContext.Provider>
    </div>
  );
}
