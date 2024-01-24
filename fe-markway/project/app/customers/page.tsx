'use client';
import AddCustomerDrawer from '@/components/AddCustomerDrawer';
import AddCustomerDrawerContainer from '@/components/AddCustomerDrawerContainer';
import CustomersTableComponent from '@/components/CustomersTableComponent';
import AddCustomerDrawerContext from '@/context/AddCustomerDrawerContext';
import { getAllCustomers } from '@/services/ShipmentService';
import { Button } from '@mui/material';
import { Fragment, useEffect, useState } from 'react';

export default function Customers() {
  const [customers, setCustomers] = useState([]);
  const [isOpened, setOpened] = useState(false);
  const value = { isOpened: isOpened, setOpened: setOpened };

  useEffect(() => {
    getAllCustomers().then((response) => {
      console.log('Caos', response?.data);
      setCustomers(response?.data);
    });
  }, []);

  const toggleDrawer = () => {
    console.log('cao', isOpened);
    setOpened(!isOpened);
  };
  return (
    <AddCustomerDrawerContext.Provider value={value}>
      <Fragment>
        <div id='customers-page'>
          <div className='heading-container'>
            <span>Pregled klijenata</span>
            <Button onClick={toggleDrawer}>Dodaj novog klijenta</Button>
          </div>
          <CustomersTableComponent customers={customers} />
        </div>
        <AddCustomerDrawer />
      </Fragment>
    </AddCustomerDrawerContext.Provider>
  );
}
