'use client';
import AddCustomerDrawer from '@/components/AddCustomerDrawer';
import AddCustomerDrawerContainer from '@/components/AddCustomerDrawerContainer';
import CustomersTableComponent from '@/components/CustomersTableComponent';
import DeleteCustomerDialog from '@/components/DeleteCustomerDialog';
import AddCustomerDrawerContext from '@/context/AddCustomerDrawerContext';
import DeleteCustomerDialogContext from '@/context/DeleteCustomerDialogContext';
import CustomerDto from '@/model/CustomerDto';
import { deleteCustomer, getAllCustomers } from '@/services/ShipmentService';
import { Button } from '@mui/material';
import { Fragment, useEffect, useState } from 'react';

export default function Customers() {
  const [customers, setCustomers] = useState([]);
  const [isOpened, setOpened] = useState(false);
  const [isOpenedDeleteCustomerDialog, setOpenedDeleteCustomerDialog] =
    useState(false);
  const value = { isOpened: isOpened, setOpened: setOpened };
  const valueDeleteCustomer = {
    isOpenedDeleteDialog: isOpenedDeleteCustomerDialog,
    setOpenedDeleteDialog: setOpenedDeleteCustomerDialog,
  };
  const [customerId, setCustomerId] = useState(1);

  const [isEditMode, setIsEditMode] = useState(false);

  const [customerToEdit, setCustomerToEdit] = useState(null);

  useEffect(() => {
    getAllCustomers().then((response) => {
      setCustomers(response?.data);
    });
  }, []);

  const toggleDrawer = () => {
    setOpened(!isOpened);
    setIsEditMode(false);
    setCustomerToEdit(null);
  };

  const openDeleteCustomerDialog = (id: number) => {
    setCustomerId(id);
    setOpenedDeleteCustomerDialog(true);
  };

  const closeDeleteCustomerDialog = () => {
    setOpenedDeleteCustomerDialog(false);
  };

  const confirmDeleteCustomer = async (id: number) => {
    try {
      // Call the deleteShipment function to delete the shipment
      await deleteCustomer(id);

      // Update the shipments state by filtering out the shipment with the specified ID
      setCustomers((customers) =>
        customers.filter((customer) => customer.id !== id)
      );
      closeDeleteCustomerDialog();
    } catch (error) {
      console.error('Error deleting shipment:', error);
    }
  };

  const setEditMode = (isEditMode: boolean, customerId: number) => {
    const customerForEdit = customers.find(
      (customer) => customer.id === customerId
    );
    setCustomerToEdit(customerForEdit);
    setCustomerId(customerId);
    setIsEditMode(isEditMode);
    setOpened(true);
  };

  return (
    <div>
      <AddCustomerDrawerContext.Provider value={value}>
        <Fragment>
          <div id='customers-page'>
            <div className='heading-container'>
              <span>Pregled klijenata</span>
              <Button onClick={toggleDrawer}>Dodaj novog klijenta</Button>
            </div>
            <CustomersTableComponent
              customers={customers}
              openDeleteCustomerDialog={openDeleteCustomerDialog}
              closeDeleteCustomerDialog={closeDeleteCustomerDialog}
              setEditMode={setEditMode}
            />
          </div>
          <AddCustomerDrawer
            customerId={customerId}
            isEditMode={isEditMode}
            customerToEdit={customerToEdit}
          />
        </Fragment>
      </AddCustomerDrawerContext.Provider>
      <DeleteCustomerDialogContext.Provider value={valueDeleteCustomer}>
        <DeleteCustomerDialog
          customerId={customerId}
          confirmDeleteCustomer={confirmDeleteCustomer}
        />
      </DeleteCustomerDialogContext.Provider>
    </div>
  );
}
